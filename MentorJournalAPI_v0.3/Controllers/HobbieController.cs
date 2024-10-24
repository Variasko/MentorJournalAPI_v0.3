using MentorJournalAPI_v0._3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MentorJournalAPI_v0._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbieController : ControllerBase
    {
        private MentorJournalV02Context _context;
        
        public HobbieController(MentorJournalV02Context context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllHobbies()
        {
            return Ok(_context.Hobbies.ToList());
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetHobbieById(int id)
        {
            try
            {
                return Ok(_context.Hobbies.Find(id));
            } catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPost("new")]
        public IActionResult AddNewHobbie(Hobbie hobbie)
        {
            try
            {
                _context.Hobbies.Add(hobbie);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateHobbie(int id, Hobbie updatedHobbie)
        {
            Hobbie? existingHobbie = _context.Hobbies.Find(id);
            if (existingHobbie == null)
                return NotFound();
            existingHobbie.StudentId = updatedHobbie.StudentId;
            existingHobbie.HobbieTypeId = updatedHobbie.HobbieTypeId;
            _context.Hobbies.Update(existingHobbie);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteHobbie(int id)
        {
            Hobbie? existingHobbie = _context.Hobbies.Find(id);
            if (existingHobbie == null)
                return NotFound();
            try
            {
                _context.Hobbies.Remove(existingHobbie);
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
