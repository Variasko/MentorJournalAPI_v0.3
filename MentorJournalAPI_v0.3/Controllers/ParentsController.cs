
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentsController : ControllerBase
    {
        private readonly IParentService _parentService;

        public ParentsController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParentDto>>> GetAll()
        {
            try
            {
                var parents = await _parentService.GetAllAsync();
                return Ok(parents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParentDto>> GetById(int id)
        {
            try
            {
                var parent = await _parentService.GetByIdAsync(id);
                if (parent == null)
                {
                    return NotFound();
                }
                return Ok(parent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ParentDto>> Post(ParentDto parentDto)
        {
            try
            {
                var createdParent = await _parentService.CreateAsync(parentDto);
                return CreatedAtAction(nameof(GetById), new { id = createdParent.Id }, createdParent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParentDto>> Put(int id, ParentDto parentDto)
        {
            try
            {
                var updatedParent = await _parentService.UpdateAsync(id, parentDto);
                if (updatedParent == null)
                {
                    return NotFound();
                }
                return Ok(updatedParent);
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
                await _parentService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
