
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassHoursController : ControllerBase
    {
        private readonly IClassHourService _classhourService;

        public ClassHoursController(IClassHourService classhourService)
        {
            _classhourService = classhourService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassHourDto>>> GetAll()
        {
            try
            {
                var classhours = await _classhourService.GetAllAsync();
                return Ok(classhours);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassHourDto>> GetById(int id)
        {
            try
            {
                var classhour = await _classhourService.GetByIdAsync(id);
                if (classhour == null)
                {
                    return NotFound();
                }
                return Ok(classhour);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClassHourDto>> Post(ClassHourDto classhourDto)
        {
            try
            {
                var createdClassHour = await _classhourService.CreateAsync(classhourDto);
                return CreatedAtAction(nameof(GetById), new { id = createdClassHour.Id }, createdClassHour);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClassHourDto>> Put(int id, ClassHourDto classhourDto)
        {
            try
            {
                var updatedClassHour = await _classhourService.UpdateAsync(id, classhourDto);
                if (updatedClassHour == null)
                {
                    return NotFound();
                }
                return Ok(updatedClassHour);
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
                await _classhourService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
