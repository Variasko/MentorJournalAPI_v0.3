
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DegreeOfKinshipsController : ControllerBase
    {
        private readonly IDegreeOfKinshipService _degreeofkinshipService;

        public DegreeOfKinshipsController(IDegreeOfKinshipService degreeofkinshipService)
        {
            _degreeofkinshipService = degreeofkinshipService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DegreeOfKinshipDto>>> GetAll()
        {
            try
            {
                var degreeofkinships = await _degreeofkinshipService.GetAllAsync();
                return Ok(degreeofkinships);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DegreeOfKinshipDto>> GetById(int id)
        {
            try
            {
                var degreeofkinship = await _degreeofkinshipService.GetByIdAsync(id);
                if (degreeofkinship == null)
                {
                    return NotFound();
                }
                return Ok(degreeofkinship);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DegreeOfKinshipDto>> Post(DegreeOfKinshipDto degreeofkinshipDto)
        {
            try
            {
                var createdDegreeOfKinship = await _degreeofkinshipService.CreateAsync(degreeofkinshipDto);
                return CreatedAtAction(nameof(GetById), new { id = createdDegreeOfKinship.Id }, createdDegreeOfKinship);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DegreeOfKinshipDto>> Put(int id, DegreeOfKinshipDto degreeofkinshipDto)
        {
            try
            {
                var updatedDegreeOfKinship = await _degreeofkinshipService.UpdateAsync(id, degreeofkinshipDto);
                if (updatedDegreeOfKinship == null)
                {
                    return NotFound();
                }
                return Ok(updatedDegreeOfKinship);
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
                await _degreeofkinshipService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
