using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LabSchoolAPI.DTOs;
using LabSchoolAPI.Services.Interfaces;

namespace LabSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        // GET: api/Avaliacao
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AvaliacaoReadDTO>>> GetAll()
        {
            return Ok(await _avaliacaoRepository.GetAllAsync());
        }

        // GET: api/Avaliacao/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AvaliacaoReadDTO>> GetById(int id)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdAsync(id);

            if (avaliacao == null)
            {
                return BadRequest();
            }

            return Ok(avaliacao);
        }

        // POST: api/Avaliacao
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AvaliacaoReadDTO>> Create(AvaliacaoCreateDTO avaliacaoCreateDTO)
        {

            var avaliacao = await _avaliacaoRepository.CreateAsync(avaliacaoCreateDTO);
            return CreatedAtAction(nameof(GetById), new { id = avaliacao.Id }, avaliacao);
        }

        // PUT: api/Avaliacao/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, AvaliacaoUpdateDTO avaliacaoUpdateDTO)
        {
            if (id != avaliacaoUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!await _avaliacaoRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _avaliacaoRepository.UpdateAsync(avaliacaoUpdateDTO);

            return NoContent();
        }

        // DELETE: api/Avaliacao/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _avaliacaoRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _avaliacaoRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}

