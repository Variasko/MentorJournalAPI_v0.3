
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HobbiesController : ControllerBase
    {
        private readonly IHobbieService _hobbieService;

        public HobbiesController(IHobbieService hobbieService)
        {
            _hobbieService = hobbieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HobbieDto>>> GetAll()
        {
            try
            {
                var hobbies = await _hobbieService.GetAllAsync();
                return Ok(hobbies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HobbieDto>> GetById(int id)
        {
            try
            {
                var hobbie = await _hobbieService.GetByIdAsync(id);
                if (hobbie == null)
                {
                    return NotFound();
                }
                return Ok(hobbie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<HobbieDto>> Post(HobbieDto hobbieDto)
        {
            try
            {
                var createdHobbie = await _hobbieService.CreateAsync(hobbieDto);
                return CreatedAtAction(nameof(GetById), new { id = createdHobbie.Id }, createdHobbie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HobbieDto>> Put(int id, HobbieDto hobbieDto)
        {
            try
            {
                var updatedHobbie = await _hobbieService.UpdateAsync(id, hobbieDto);
                if (updatedHobbie == null)
                {
                    return NotFound();
                }
                return Ok(updatedHobbie);
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
                await _hobbieService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
