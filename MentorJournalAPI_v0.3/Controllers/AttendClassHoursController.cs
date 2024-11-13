
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendClassHoursController : ControllerBase
    {
        private readonly IAttendClassHourService _attendclasshourService;

        public AttendClassHoursController(IAttendClassHourService attendclasshourService)
        {
            _attendclasshourService = attendclasshourService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendClassHourDto>>> GetAll()
        {
            try
            {
                var attendclasshours = await _attendclasshourService.GetAllAsync();
                return Ok(attendclasshours);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendClassHourDto>> GetById(int id)
        {
            try
            {
                var attendclasshour = await _attendclasshourService.GetByIdAsync(id);
                if (attendclasshour == null)
                {
                    return NotFound();
                }
                return Ok(attendclasshour);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<AttendClassHourDto>> Post(AttendClassHourDto attendclasshourDto)
        {
            try
            {
                var createdAttendClassHour = await _attendclasshourService.CreateAsync(attendclasshourDto);
                return CreatedAtAction(nameof(GetById), new { id = createdAttendClassHour.Id }, createdAttendClassHour);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AttendClassHourDto>> Put(int id, AttendClassHourDto attendclasshourDto)
        {
            try
            {
                var updatedAttendClassHour = await _attendclasshourService.UpdateAsync(id, attendclasshourDto);
                if (updatedAttendClassHour == null)
                {
                    return NotFound();
                }
                return Ok(updatedAttendClassHour);
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
                await _attendclasshourService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
