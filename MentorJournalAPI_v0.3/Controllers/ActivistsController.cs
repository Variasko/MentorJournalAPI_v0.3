
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivistsController : ControllerBase
    {
        private readonly IActivistService _activistService;

        public ActivistsController(IActivistService activistService)
        {
            _activistService = activistService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivistDto>>> GetAll()
        {
            try
            {
                var activists = await _activistService.GetAllAsync();
                return Ok(activists);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivistDto>> GetById(int id)
        {
            try
            {
                var activist = await _activistService.GetByIdAsync(id);
                if (activist == null)
                {
                    return NotFound();
                }
                return Ok(activist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ActivistDto>> Post(ActivistDto activistDto)
        {
            try
            {
                var createdActivist = await _activistService.CreateAsync(activistDto);
                return CreatedAtAction(nameof(GetById), new { id = createdActivist.Id }, createdActivist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActivistDto>> Put(int id, ActivistDto activistDto)
        {
            try
            {
                var updatedActivist = await _activistService.UpdateAsync(id, activistDto);
                if (updatedActivist == null)
                {
                    return NotFound();
                }
                return Ok(updatedActivist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _activistService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
