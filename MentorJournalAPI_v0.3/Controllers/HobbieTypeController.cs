using MentorJournalAPI_v0._3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentorJournalAPI_v0._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbieTypeController : ControllerBase
    {
        private MentorJournalV02Context _context;

        public HobbieTypeController(MentorJournalV02Context context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllHobbieTypes()
        {
            return Ok(_context.HobbieTypes.ToList());
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetHobbieTypeById(int id)
        {
            try
            {
                return Ok(_context.HobbieTypes.Find(id));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost("new")]
        public IActionResult AddNewHobbieType(HobbieType hobbieType)
        {
            try
            {
                _context.HobbieTypes.Add(hobbieType);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateHobbieType(int id, HobbieType updatedHobbieType)
        {
            HobbieType? existingHobbieType = _context.HobbieTypes.Find(id);
            if (existingHobbieType == null)
                return NotFound();

            existingHobbieType.Name = updatedHobbieType.Name;
            try
            {
                _context.HobbieTypes.Update(existingHobbieType);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteHobbieType(int id)
        {
            HobbieType? existingHobbieType = _context.HobbieTypes.Find(id);
            if (existingHobbieType == null)
                return NotFound();
            try
            {
                _context.HobbieTypes.Remove(existingHobbieType);
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
