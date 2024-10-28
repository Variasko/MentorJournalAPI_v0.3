
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DormitorysController : ControllerBase
    {
        private readonly IDormitoryService _dormitoryService;

        public DormitorysController(IDormitoryService dormitoryService)
        {
            _dormitoryService = dormitoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DormitoryDto>>> GetAll()
        {
            try
            {
                var dormitorys = await _dormitoryService.GetAllAsync();
                return Ok(dormitorys);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DormitoryDto>> GetById(int id)
        {
            try
            {
                var dormitory = await _dormitoryService.GetByIdAsync(id);
                if (dormitory == null)
                {
                    return NotFound();
                }
                return Ok(dormitory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DormitoryDto>> Post(DormitoryDto dormitoryDto)
        {
            try
            {
                var createdDormitory = await _dormitoryService.CreateAsync(dormitoryDto);
                return CreatedAtAction(nameof(GetById), new { id = createdDormitory.Id }, createdDormitory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DormitoryDto>> Put(int id, DormitoryDto dormitoryDto)
        {
            try
            {
                var updatedDormitory = await _dormitoryService.UpdateAsync(id, dormitoryDto);
                if (updatedDormitory == null)
                {
                    return NotFound();
                }
                return Ok(updatedDormitory);
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
                await _dormitoryService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
