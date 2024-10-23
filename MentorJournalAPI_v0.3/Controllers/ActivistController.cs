using MentorJournalAPI_v0._3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentorJournalAPI_v0._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivistController : ControllerBase
    {
        [HttpGet("all")]
        public IActionResult GetAllActivists()
        {
            using (var _context = new MentorJournalV02Context())
            {
                return Ok(_context.Activists.ToList());
            }
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetActivistById(int id)
        {
            using (var _context = new MentorJournalV02Context())
            {
                try
                {
                    return Ok(_context.Activists.Find(id));
                } catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
        }
        [HttpPost("new")]
        public IActionResult AddNewActivist(Activist activist)
        {
            using (var _context = new MentorJournalV02Context())
            {
                try
                {
                    _context.Activists.Add(activist);
                    _context.SaveChanges();
                    return Ok();
                } catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateActivist(int id, Activist updatedActivist)
        {
            using (var _context = new MentorJournalV02Context())
            {
                Activist? existingActivist = _context.Activists.Find(id);
                if (existingActivist == null)
                    return NotFound();
                existingActivist.StudentId = updatedActivist.StudentId;
                existingActivist.ActivityTypeId = updatedActivist.ActivityTypeId;
                try
                {
                    _context.Activists.Update(existingActivist);
                    _context.SaveChanges();
                    return Ok();
                } catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteActivist(int id)
        {
            if (id == 0)
                return BadRequest();
            using (var _context = new MentorJournalV02Context())
            {
                Activist? existingActivist = _context.Activists.Find(id);
                if (existingActivist == null)
                    return NotFound();
                try
                {
                    _context.Activists.Remove(existingActivist);
                    _context.SaveChanges();
                    return Ok();
                } catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
        }
    }
}
