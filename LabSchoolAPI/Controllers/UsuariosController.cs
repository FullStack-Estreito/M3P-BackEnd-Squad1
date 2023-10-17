using System.Net;
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

       public UsuariosController(LabSchoolContext labSchoolContext, IUsuarioRepository usuarioRepository, IMapper mapper) 
       {
            _labSchoolContext = labSchoolContext;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
       } 

       [HttpGet]
       [ProducesResponseType(StatusCodes.Status200OK)]
       [ProducesResponseType(StatusCodes.Status500InternalServerError)]
       [ProducesResponseType(StatusCodes.Status404NotFound)]
       [ProducesResponseType(StatusCodes.Status400BadRequest)]
       public ActionResult<IEnumerable<UsuarioReadDTO>> Get([FromQuery] string? tipoUsuario, string? nome, string? telefone, string? cpf)
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
                    if (!telefone.IsNullOrEmpty())
                    {
                        usuarioModels = _labSchoolContext.Usuarios
                                                            .Where(w => w.Telefone == telefone)
                                                            .ToList();
                        
                        if (usuarioModels.Count == 0)
                        {
                            return NotFound(new { erro = "Telefone não encontrado." });
                        }
                    }
                    if (!cpf.IsNullOrEmpty())
                    {
                        usuarioModels = _labSchoolContext.Usuarios
                                                            .Where(w => w.Cpf == cpf)
                                                            .ToList();
                        
                        if (usuarioModels.Count == 0)
                        {
                            return NotFound(new { erro = "Cpf não encontrado." });
                        }
                    }
                    if (!tipoUsuario.IsNullOrEmpty() && (tipoUsuario != "Administrador" && tipoUsuario != "Pedagogo" && tipoUsuario != "Professor" && tipoUsuario != "Aluno"))
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

                var usuarioReadDTO = _mapper.Map<List<UsuarioReadDTO>>(usuarioModels);
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
       public ActionResult<UsuarioReadDTO> Get(int id)
       {
            try
            {
                var usuarioModel = _labSchoolContext.Usuarios.Find(id);

                if (usuarioModel == null)
                {
                    return NotFound(new { erro = "Usuário não encontrado." });
                }

                var usuarioReadDTO = _mapper.Map<UsuarioReadDTO>(usuarioModel);
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
        public ActionResult<UsuarioReadDTO> Post([FromBody] UsuarioCreateDTO usuarioCreateDTO)
        {
            try
            {
                var usuarioModel = _mapper.Map<UsuarioModel>(usuarioCreateDTO);

                _labSchoolContext.Usuarios.Add(usuarioModel);
                _labSchoolContext.SaveChanges();


                var usuarioReadDTO = _mapper.Map<UsuarioReadDTO>(usuarioModel);

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
        public ActionResult<UsuarioReadDTO> Post([FromBody] UsuarioLoginDTO usuarioLoginDTO)
        {
            try
            {
                var usuarioModel = _mapper.Map<UsuarioModel>(usuarioLoginDTO);

                // IMPLEMENTAR LÓGICA DE GERAÇÃO DE TOKEN DE ACESSO NO RESPONSE //

                var usuarioReadDTO = _mapper.Map<UsuarioReadDTO>(usuarioModel);

                return Ok(usuarioReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError.GetHashCode(), ex.Message);
            }

        }

        [HttpPatch("resetar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UsuarioReadDTO> Patch([FromBody] UsuarioResetarSenhaDTO usuarioResetarSenhaDTO)
        {
            try
            {
                var usuarioModel = _mapper.Map<UsuarioModel>(usuarioResetarSenhaDTO);


                // IMPLEMENTAR LÓGICA DE RESET DE ACESSO //

                _labSchoolContext.Usuarios.Add(usuarioModel);
                _labSchoolContext.SaveChanges();


                var usuarioReadDTO = _mapper.Map<UsuarioReadDTO>(usuarioModel);

                return Ok(usuarioReadDTO);
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
        public ActionResult<UsuarioReadDTO> Put(int id, [FromBody] UsuarioUpdateDTO usuarioUpdateDTO)
        {
            try
            {
                var usuarioModel = _labSchoolContext.Usuarios.Where(w => w.Id == id).FirstOrDefault();

                if (usuarioModel == null)
                {
                    return NotFound(new { erro = "Registro não encontrado." });
                }

                usuarioModel = _mapper.Map(usuarioUpdateDTO, usuarioModel);

                _labSchoolContext.Usuarios.Update(usuarioModel);
                _labSchoolContext.SaveChanges();

                var usuarioReadDTO = _mapper.Map<UsuarioReadDTO>(usuarioModel);

                return Ok(usuarioReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            try
            {
                var usuarioModel = _labSchoolContext.Usuarios.Where(w => w.Id == id).FirstOrDefault();

                if (usuarioModel == null)
                {
                    return NotFound(new { erro = "Registro não encontrado." });
                }

                _labSchoolContext.Usuarios.Remove(usuarioModel);
                _labSchoolContext.SaveChanges();

                return StatusCode(204);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}