
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MentorsController : ControllerBase
    {
        private readonly IMentorService _mentorService;

        public MentorsController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentorDto>>> GetAll()
        {
            try
            {
                var mentors = await _mentorService.GetAllAsync();
                return Ok(mentors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MentorDto>> GetById(int id)
        {
            try
            {
                var mentor = await _mentorService.GetByIdAsync(id);
                if (mentor == null)
                {
                    return NotFound();
                }
                return Ok(mentor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<MentorDto>> Post(MentorDto mentorDto)
        {
            try
            {
                var createdMentor = await _mentorService.CreateAsync(mentorDto);
                return CreatedAtAction(nameof(GetById), new { id = createdMentor.Id }, createdMentor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MentorDto>> Put(int id, MentorDto mentorDto)
        {
            try
            {
                var updatedMentor = await _mentorService.UpdateAsync(id, mentorDto);
                if (updatedMentor == null)
                {
                    return NotFound();
                }
                return Ok(updatedMentor);
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
                await _mentorService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
