
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndividualWorkWithParentsController : ControllerBase
    {
        private readonly IIndividualWorkWithParentService _individualworkwithparentService;

        public IndividualWorkWithParentsController(IIndividualWorkWithParentService individualworkwithparentService)
        {
            _individualworkwithparentService = individualworkwithparentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndividualWorkWithParentDto>>> GetAll()
        {
            try
            {
                var individualworkwithparents = await _individualworkwithparentService.GetAllAsync();
                return Ok(individualworkwithparents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IndividualWorkWithParentDto>> GetById(int id)
        {
            try
            {
                var individualworkwithparent = await _individualworkwithparentService.GetByIdAsync(id);
                if (individualworkwithparent == null)
                {
                    return NotFound();
                }
                return Ok(individualworkwithparent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<IndividualWorkWithParentDto>> Post(IndividualWorkWithParentDto individualworkwithparentDto)
        {
            try
            {
                var createdIndividualWorkWithParent = await _individualworkwithparentService.CreateAsync(individualworkwithparentDto);
                return CreatedAtAction(nameof(GetById), new { id = createdIndividualWorkWithParent.Id }, createdIndividualWorkWithParent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IndividualWorkWithParentDto>> Put(int id, IndividualWorkWithParentDto individualworkwithparentDto)
        {
            try
            {
                var updatedIndividualWorkWithParent = await _individualworkwithparentService.UpdateAsync(id, individualworkwithparentDto);
                if (updatedIndividualWorkWithParent == null)
                {
                    return NotFound();
                }
                return Ok(updatedIndividualWorkWithParent);
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
                await _individualworkwithparentService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
