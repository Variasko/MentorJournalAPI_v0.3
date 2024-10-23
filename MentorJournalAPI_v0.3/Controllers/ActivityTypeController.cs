using MentorJournalAPI_v0._3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentorJournalAPI_v0._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypeController : ControllerBase
    {

        private MentorJournalV02Context _context;

        public ActivityTypeController(MentorJournalV02Context context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllActivityTypes()
        {
            
            return Ok(_context.ActivityTypes.ToList());
            
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetActivityTypeById(int id)
        {
            
            try
            {
                return Ok(_context.ActivityTypes.Find(id));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
        [HttpPost("new")]
        public IActionResult AddNewActivityType(ActivityType activityType)
        {
            
            try
            {
                _context.ActivityTypes.Add(activityType);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateActivityType(int id, ActivityType updatedActivityType)
        {
            
            try
            {
                ActivityType? existingActivityType = _context.ActivityTypes.Find(id);
                if (existingActivityType == null)
                    return NotFound();
                existingActivityType.Name = updatedActivityType.Name;
                _context.ActivityTypes.Update(existingActivityType);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteActivityType(int id)
        {
            
            ActivityType? existingActivityType = _context.ActivityTypes.Find(id);
            if (existingActivityType == null)
                return NotFound();
            try
            {
                _context.ActivityTypes.Remove(existingActivityType);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
    }
}
