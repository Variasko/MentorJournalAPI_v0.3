using MentorJournalAPI_v0._3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentorJournalAPI_v0._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private MentorJournalV02Context _context;

        public MentorController(MentorJournalV02Context context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllMentors()
        {
            return Ok(_context.Mentors.ToList());
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetMentorById(int id)
        {
            try
            {
                return Ok(_context.Mentors.Find(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("new")]
        public IActionResult AddNewMentor(Mentor mentor)
        {
            try
            {
                _context.Mentors.Add(mentor);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateMentor(int id, Mentor updatedMentor)
        {
            Mentor? existingMentor = _context.Mentors.Find(id);
            if (existingMentor == null)
                return NotFound();
            try
            {
                _context.Entry(existingMentor).CurrentValues.SetValues(updatedMentor);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteMentor(int id)
        {
            Mentor? existingMentor = _context.Mentors.Find(id);
            if (existingMentor == null)
                return NotFound();
            try
            {
                _context.Mentors.Remove(existingMentor);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
