
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityTypesController : ControllerBase
    {
        private readonly IActivityTypeService _activitytypeService;

        public ActivityTypesController(IActivityTypeService activitytypeService)
        {
            _activitytypeService = activitytypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityTypeDto>>> GetAll()
        {
            try
            {
                var activitytypes = await _activitytypeService.GetAllAsync();
                return Ok(activitytypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityTypeDto>> GetById(int id)
        {
            try
            {
                var activitytype = await _activitytypeService.GetByIdAsync(id);
                if (activitytype == null)
                {
                    return NotFound();
                }
                return Ok(activitytype);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ActivityTypeDto>> Post(ActivityTypeDto activitytypeDto)
        {
            try
            {
                var createdActivityType = await _activitytypeService.CreateAsync(activitytypeDto);
                return CreatedAtAction(nameof(GetById), new { id = createdActivityType.Id }, createdActivityType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActivityTypeDto>> Put(int id, ActivityTypeDto activitytypeDto)
        {
            try
            {
                var updatedActivityType = await _activitytypeService.UpdateAsync(id, activitytypeDto);
                if (updatedActivityType == null)
                {
                    return NotFound();
                }
                return Ok(updatedActivityType);
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
                await _activitytypeService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
