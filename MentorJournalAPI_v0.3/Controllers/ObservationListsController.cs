
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObservationListsController : ControllerBase
    {
        private readonly IObservationListService _observationlistService;

        public ObservationListsController(IObservationListService observationlistService)
        {
            _observationlistService = observationlistService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObservationListDto>>> GetAll()
        {
            try
            {
                var observationlists = await _observationlistService.GetAllAsync();
                return Ok(observationlists);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObservationListDto>> GetById(int id)
        {
            try
            {
                var observationlist = await _observationlistService.GetByIdAsync(id);
                if (observationlist == null)
                {
                    return NotFound();
                }
                return Ok(observationlist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ObservationListDto>> Post(ObservationListDto observationlistDto)
        {
            try
            {
                var createdObservationList = await _observationlistService.CreateAsync(observationlistDto);
                return CreatedAtAction(nameof(GetById), new { id = createdObservationList.Id }, createdObservationList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ObservationListDto>> Put(int id, ObservationListDto observationlistDto)
        {
            try
            {
                var updatedObservationList = await _observationlistService.UpdateAsync(id, observationlistDto);
                if (updatedObservationList == null)
                {
                    return NotFound();
                }
                return Ok(updatedObservationList);
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
                await _observationlistService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
