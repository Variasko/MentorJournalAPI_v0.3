
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HobbieTypesController : ControllerBase
    {
        private readonly IHobbieTypeService _hobbietypeService;

        public HobbieTypesController(IHobbieTypeService hobbietypeService)
        {
            _hobbietypeService = hobbietypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HobbieTypeDto>>> GetAll()
        {
            try
            {
                var hobbietypes = await _hobbietypeService.GetAllAsync();
                return Ok(hobbietypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HobbieTypeDto>> GetById(int id)
        {
            try
            {
                var hobbietype = await _hobbietypeService.GetByIdAsync(id);
                if (hobbietype == null)
                {
                    return NotFound();
                }
                return Ok(hobbietype);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<HobbieTypeDto>> Post(HobbieTypeDto hobbietypeDto)
        {
            try
            {
                var createdHobbieType = await _hobbietypeService.CreateAsync(hobbietypeDto);
                return CreatedAtAction(nameof(GetById), new { id = createdHobbieType.Id }, createdHobbieType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HobbieTypeDto>> Put(int id, HobbieTypeDto hobbietypeDto)
        {
            try
            {
                var updatedHobbieType = await _hobbietypeService.UpdateAsync(id, hobbietypeDto);
                if (updatedHobbieType == null)
                {
                    return NotFound();
                }
                return Ok(updatedHobbieType);
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
                await _hobbietypeService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
