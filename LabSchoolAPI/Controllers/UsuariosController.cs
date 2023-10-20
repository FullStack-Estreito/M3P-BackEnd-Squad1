using Microsoft.AspNetCore.Mvc;
using LabSchoolAPI.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using LabSchoolAPI.DTOs;

namespace LabSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UsuarioController> _logger; // Para log de erros

        public UsuarioController(IUsuarioRepository usuarioRepository, IConfiguration configuration, ILogger<UsuarioController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
            _logger = logger;
        }

        // Listar todos os usuários
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _usuarioRepository.GetAllAsync();
            return Ok(users);
        }

        // Obter um usuário pelo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _usuarioRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(UsuarioCreateDTO userDto)
        {
            var user = await _usuarioRepository.CreateAsync(userDto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);// estava pedindo ID aki no lugar da matricula. Adicione a propriedade "Id" em UsuarioReadDTO.
        }


        // Atualizar um usuário
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UsuarioUpdateDTO userDto)
        {
            if (await _usuarioRepository.ExistsAsync(id))
            {
                await _usuarioRepository.UpdateAsync(userDto);
                return NoContent();
            }
            return NotFound();
        }

        // Deletar um usuário
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _usuarioRepository.ExistsAsync(id))
            {
                await _usuarioRepository.DeleteAsync(id);
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioLoginDTO loginDto)
        {
            try
            {
                var user = await _usuarioRepository.LoginAsync(loginDto);
                if (user == null)
                    return Unauthorized("Credenciais inválidas.");

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? string.Empty);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Nome.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new
                {
                    Token = tokenString,
                    Id = user.Id,
                    Nome = user.Nome,
                    Email = user.Email
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro durante a autenticação.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Ocorreu um erro durante a autenticação." });
            }
        }

        [HttpPut("changepassword")]
        public async Task<IActionResult> ChangePassword(UsuarioResetarSenhaDTO resetDTO)
        {
            bool result = await _usuarioRepository.ResetPasswordAsync(resetDTO);
            if (!result)
                return BadRequest("Não foi possível alterar a senha.");

            return Ok("Senha alterada com sucesso.");
        }
    }
}