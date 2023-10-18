using Microsoft.AspNetCore.Mvc;
using LabSchoolAPI.DTOs;
using LabSchoolAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioRepository _exercicioRepository;

        public ExercicioController(IExercicioRepository exercicioRepository)
        {
            _exercicioRepository = exercicioRepository;
        }

        // GET: api/Exercicio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExercicioReadDTO>>> GetAll()
        {
            return Ok(await _exercicioRepository.GetAllAsync());
        }

        // GET: api/Exercicio/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ExercicioReadDTO>> GetById(int id)
        {
            var exercicio = await _exercicioRepository.GetByIdAsync(id);
            
            if (exercicio == null)
                return NotFound();

            return Ok(exercicio);
        }

        // POST: api/Exercicio
        [HttpPost]
        public async Task<ActionResult<ExercicioReadDTO>> Create(ExercicioCreateDTO exercicioCreateDTO)
        {
            var result = await _exercicioRepository.CreateAsync(exercicioCreateDTO);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/Exercicio/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ExercicioUpdateDTO exercicioUpdateDTO)
        {
            if (!await _exercicioRepository.ExistsAsync(id))
                return NotFound();

            await _exercicioRepository.UpdateAsync(exercicioUpdateDTO);
            return NoContent();
        }

        // DELETE: api/Exercicio/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _exercicioRepository.ExistsAsync(id))
                return NotFound();

            await _exercicioRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
