using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.Services.Repositories
{
    public class AuthRepositories : IAuthRepositories
    {
        private readonly LabSchoolContext _context; 

        public AuthRepositories(LabSchoolContext context) 
        {
            _context = context;
        }

        public async Task<UsuarioModel> Register(UsuarioCreateDTO userDto, string password)
        {

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new UsuarioModel
            {
                NomeCompleto = userDto.NomeCompleto,
                Genero = userDto.Genero,
                CPF = userDto.CPF,
                Telefone = userDto.Telefone,
                Email = userDto.Email,
                Tipo = userDto.Tipo,
                Endereco = new Endereco
                {
                    CEP = userDto.CEP,
                    Cidade = userDto.Cidade,
                    Estado = userDto.Estado,
                    Logradouro = userDto.Logradouro,
                    Numero = userDto.Numero,
                    Complemento = userDto.Complemento,
                    Bairro = userDto.Bairro,
                    PontoReferencia = userDto.PontoReferencia
                },
                StatusSistema = userDto.StatusSistema ?? true, // Iniciar como 'ativo' se não for fornecido
                Matricula = userDto.Matricula,
                CodigoRegistroProfessor = userDto.CodigoRegistroProfessor,
                IdentificadorEmpresa = userDto.IdentificadorEmpresa,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            // Verificar unicidade de campos como Email e CPF antes de salvar
            if (await _context.Usuarios.AnyAsync(u => u.Email == user.Email || u.CPF == user.CPF))
            {
                throw new Exception("Email ou CPF já existente.");
            }

            await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<UsuarioModel> Login(UserLoginDTO userLoginDto)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == userLoginDto.Email);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.Usuarios.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> ChangePassword(string email, string oldPassword, string newPassword)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return false;

            if (!VerifyPasswordHash(oldPassword, user.PasswordHash, user.PasswordSalt))
                return false;

            byte[] newPasswordHash, newPasswordSalt;
            CreatePasswordHash(newPassword, out newPasswordHash, out newPasswordSalt);
            user.PasswordHash = newPasswordHash;
            user.PasswordSalt = newPasswordSalt;

            await _context.SaveChangesAsync();
            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}