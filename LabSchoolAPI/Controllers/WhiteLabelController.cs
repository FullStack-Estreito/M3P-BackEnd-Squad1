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
    public class WhiteLabelController : ControllerBase
    {
        private readonly IWhiteLabelRepository _whiteLabelRepository;

        public WhiteLabelController(IWhiteLabelRepository whiteLabelRepository)
        {
            _whiteLabelRepository = whiteLabelRepository;
        }

        [HttpPost]
        public async Task<ActionResult<WhiteLabelReadDTO>> CreateWhiteLabel(WhiteLabelCreateDTO whiteLabelCreateDTO)
        {
            var whiteLabel = await _whiteLabelRepository.CreateAsync(whiteLabelCreateDTO);
            return CreatedAtAction(nameof(GetWhiteLabelById), new { id = whiteLabel.Id }, whiteLabel);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WhiteLabelReadDTO>>> GetAllWhiteLabels()
        {
            return Ok(await _whiteLabelRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WhiteLabelReadDTO>> GetWhiteLabelById(int id)
        {
            var whiteLabel = await _whiteLabelRepository.GetByIdAsync(id);
            if (whiteLabel == null)
            {
                return NotFound();
            }
            return Ok(whiteLabel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWhiteLabel(int id, WhiteLabelUpdateDTO whiteLabelUpdateDTO)
        {
            if (!await _whiteLabelRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _whiteLabelRepository.UpdateAsync(whiteLabelUpdateDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhiteLabel(int id)
        {
            if (!await _whiteLabelRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _whiteLabelRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
