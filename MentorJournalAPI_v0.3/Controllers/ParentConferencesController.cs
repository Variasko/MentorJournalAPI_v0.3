
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentConferencesController : ControllerBase
    {
        private readonly IParentConferenceService _parentconferenceService;

        public ParentConferencesController(IParentConferenceService parentconferenceService)
        {
            _parentconferenceService = parentconferenceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParentConferenceDto>>> GetAll()
        {
            try
            {
                var parentconferences = await _parentconferenceService.GetAllAsync();
                return Ok(parentconferences);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParentConferenceDto>> GetById(int id)
        {
            try
            {
                var parentconference = await _parentconferenceService.GetByIdAsync(id);
                if (parentconference == null)
                {
                    return NotFound();
                }
                return Ok(parentconference);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ParentConferenceDto>> Post(ParentConferenceDto parentconferenceDto)
        {
            try
            {
                var createdParentConference = await _parentconferenceService.CreateAsync(parentconferenceDto);
                return CreatedAtAction(nameof(GetById), new { id = createdParentConference.Id }, createdParentConference);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParentConferenceDto>> Put(int id, ParentConferenceDto parentconferenceDto)
        {
            try
            {
                var updatedParentConference = await _parentconferenceService.UpdateAsync(id, parentconferenceDto);
                if (updatedParentConference == null)
                {
                    return NotFound();
                }
                return Ok(updatedParentConference);
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
                await _parentconferenceService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
