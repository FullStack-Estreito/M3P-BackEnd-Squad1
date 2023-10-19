using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.DTOs;
using LabSchoolAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        
    public class AtendimentosController : ControllerBase
    {
         private readonly IAtendimentoRepository _atendimentoRepository;
         private readonly IConfiguration _configuration;
        private readonly ILogger<AtendimentosController> _logger; // Para log de erros

        public AtendimentosController(IAtendimentoRepository atendimentoRepository , IConfiguration configuration, ILogger<AtendimentosController> logger )
        {
            _atendimentoRepository = atendimentoRepository;
            _configuration = configuration;
            _logger = logger;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AtendimentoReadDTO>>> GetAllAtendimentos()
        {
            return Ok(await _atendimentoRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AtendimentoReadDTO>> GetAtendimentoById(int id)
        {
            var atendimento = await _atendimentoRepository.GetByIdAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            return Ok(atendimento);
        }

         [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AtendimentoReadDTO>> CreateAtendimento(AtendimentoCreateDTO atendimentoCreateDTO)
        {
            var atendimento = await _atendimentoRepository.CreateAsync(atendimentoCreateDTO);
            return CreatedAtAction(nameof(GetAtendimentoById), new { id = atendimento.Id }, atendimento);

        }

         [HttpPut("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAtendimento(int id, AtendimentoUpdateDTO atendimentoUpdateDTO)
        {
            if (!await _atendimentoRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _atendimentoRepository.UpdateAsync(atendimentoUpdateDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteAtendimento(int id)
        {
            if (!await _atendimentoRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _atendimentoRepository.DeleteAsync(id);
            return NoContent();
        }
        
    }
}