using MentorJournalAPI_v0._3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace MentorJournalAPI_v0._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private MentorJournalV02Context _context;

        public PersonController(MentorJournalV02Context context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllPerson()
        {
            return Ok(_context.People.ToList());
        }
        
        [HttpGet("byId/{id}")]
        public IActionResult GetPersonById(int id)
        {
            try
            {
                return Ok(_context.People.Find(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("new")]
        public IActionResult AddNewPerson(Person person)
        {
            try
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }


        [HttpPut("update/{id}")]
        public IActionResult UpdatePerson(int id, Person updatedPerson)
        {
            Person? existingPerson = _context.People.Find(id);
            if (existingPerson == null)
                return NotFound();
            

            try
            {
                _context.Entry(existingPerson).CurrentValues.SetValues(updatedPerson);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeletePerson(int id)
        {
            
            Person? existingPerson = _context.People.Find(id);
            if (existingPerson == null)
                return NotFound();
            try
            {
                _context.People.Remove(existingPerson);
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
