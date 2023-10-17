using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using LabSchoolAPI.Context;
using LabSchoolAPI.DTOs;
using LabSchoolAPI.Enums;
using LabSchoolAPI.Models;
using LabSchoolAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LabSchoolAPI.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
       private readonly LabSchoolContext _labSchoolContext;
       private readonly IUsuarioRepository _usuarioRepository;
       private readonly IMapper _mapper; 
       private readonly ILogger<UsuariosController> _logger;
       private readonly IConfiguration _configuration;

       public UsuariosController(LabSchoolContext labSchoolContext, IUsuarioRepository usuarioRepository, IMapper mapper, ILogger<UsuariosController> logger, IConfiguration configuration) 
       {
            _labSchoolContext = labSchoolContext;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
       } 

       [HttpGet]
       [ProducesResponseType(StatusCodes.Status200OK)]
       [ProducesResponseType(StatusCodes.Status500InternalServerError)]
       [ProducesResponseType(StatusCodes.Status404NotFound)]
       [ProducesResponseType(StatusCodes.Status400BadRequest)]
       public async Task<IActionResult> GetAll([FromQuery] string? tipoUsuario, string? nome, string? telefone, string? cpf)
       {
            try
            {
                List<UsuarioModel> usuarioModels;

                if (nome.IsNullOrEmpty() && telefone.IsNullOrEmpty() && cpf.IsNullOrEmpty() && tipoUsuario.IsNullOrEmpty()) 
                {
                    usuarioModels = _labSchoolContext.Usuarios.ToList();

                    if (usuarioModels.Count == 0)
                        {
                            return NotFound(new { erro = "Não há registros de usuários no banco." });
                        }
                }
                else
                {
                    if (!nome.IsNullOrEmpty())
                    {
                        usuarioModels = _labSchoolContext.Usuarios
                                                            .Where(w => w.Nome == nome)
                                                            .ToList();
                        
                        if (usuarioModels.Count == 0)
                        {
                            return NotFound(new { erro = "Nome não encontrado." });
                        }
                    }
                    else if (!telefone.IsNullOrEmpty())
                    {
                        usuarioModels = _labSchoolContext.Usuarios
                                                            .Where(w => w.Telefone == telefone)
                                                            .ToList();
                        
                        if (usuarioModels.Count == 0)
                        {
                            return NotFound(new { erro = "Telefone não encontrado." });
                        }
                    }
                    else if (!cpf.IsNullOrEmpty())
                    {
                        usuarioModels = _labSchoolContext.Usuarios
                                                            .Where(w => w.Cpf == cpf)
                                                            .ToList();
                        
                        if (usuarioModels.Count == 0)
                        {
                            return NotFound(new { erro = "Cpf não encontrado." });
                        }
                    }
                    else if (!tipoUsuario.IsNullOrEmpty() && (tipoUsuario != "Administrador" && tipoUsuario != "Pedagogo" && tipoUsuario != "Professor" && tipoUsuario != "Aluno"))
                    {
                        return BadRequest("Valor informado inválido. Tente novamente com um dos valores válidos para o Tipo de Usuário: Administrador, Pedagogo, Professor ou Aluno.");
                    }
                    else 
                    {
                        usuarioModels = _labSchoolContext.Usuarios
                                                            .Where(w => w.TipoUsuario == (TipoUsuario)Enum.Parse(typeof(TipoUsuario), tipoUsuario))
                                                            .ToList();
                        
                        if (usuarioModels.Count == 0)
                        {
                            return NotFound(new { erro = "Cpf não encontrado." });
                        }
                    }
                    

                }

                var usuarioReadDTO = await _usuarioRepository.GetAllAsync();
                return Ok(usuarioReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
       }

       [HttpGet("{id}")]
       [ProducesResponseType(StatusCodes.Status200OK)]
       [ProducesResponseType(StatusCodes.Status404NotFound)]
       [ProducesResponseType(StatusCodes.Status500InternalServerError)]
       public async Task<IActionResult> GetById(int id)
       {
            try
            {
                var usuarioReadDTO = _usuarioRepository.GetByIdAsync(id);

                if (usuarioReadDTO == null)
                {
                    return NotFound(new { erro = "Usuário não encontrado." });
                }

                return Ok(usuarioReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
       }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] UsuarioCreateDTO usuarioCreateDTO)
        {
            try
            {
                var usuarioReadDTO = await _usuarioRepository.CreateAsync(usuarioCreateDTO);

                return StatusCode(StatusCodes.Status201Created, usuarioReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError.GetHashCode(), ex.Message);
            }

        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] UsuarioLoginDTO usuarioLoginDTO)
        {
            try
            {
                var user = await _usuarioRepository.LoginAsync(usuarioLoginDTO);
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
                    Matricula = user.Matricula,
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

        [HttpPatch("resetar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch([FromBody] UsuarioResetarSenhaDTO usuarioResetarSenhaDTO)
        {
            try
            {
                bool result = await _usuarioRepository.ResetPasswordAsync(usuarioResetarSenhaDTO);
                if (!result)
                    return BadRequest("Não foi possível alterar a senha.");

                return Ok("Senha alterada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError.GetHashCode(), ex.Message);
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<UsuarioReadDTO> Put(int id, [FromBody] UsuarioUpdateDTO usuarioUpdateDTO)
        {   

            if (await _usuarioRepository.ExistsAsync(id))
            {
                await _usuarioRepository.UpdateAsync(usuarioUpdateDTO);
                return NoContent();
            }
            return NotFound();
            // try
            // {
            //     var usuarioModel = _labSchoolContext.Usuarios.Where(w => w.Id == id).FirstOrDefault();

            //     if (usuarioModel == null)
            //     {
            //         return NotFound(new { erro = "Registro não encontrado." });
            //     }

            //     usuarioModel = _mapper.Map(usuarioUpdateDTO, usuarioModel);

            //     _labSchoolContext.Usuarios.Update(usuarioModel);
            //     _labSchoolContext.SaveChanges();

            //     var usuarioReadDTO = _mapper.Map<UsuarioReadDTO>(usuarioModel);

            //     return Ok(usuarioReadDTO);
            // }
            // catch (Exception ex)
            // {
            //     return StatusCode(500, ex);
            // }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            if (await _usuarioRepository.ExistsAsync(id))
            {
                await _usuarioRepository.DeleteAsync(id);
                return NoContent();
            }
            return NotFound();
            // try
            // {
            //     var usuarioModel = _labSchoolContext.Usuarios.Where(w => w.Id == id).FirstOrDefault();

            //     if (usuarioModel == null)
            //     {
            //         return NotFound(new { erro = "Registro não encontrado." });
            //     }

            //     _labSchoolContext.Usuarios.Remove(usuarioModel);
            //     _labSchoolContext.SaveChanges();

            //     return StatusCode(204);

            // }
            // catch (Exception ex)
            // {
            //     return StatusCode(500, ex);
            // }
        }
    }
}