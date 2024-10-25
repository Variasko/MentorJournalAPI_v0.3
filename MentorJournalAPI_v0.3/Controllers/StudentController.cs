using MentorJournalAPI_v0._3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentorJournalAPI_v0._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private MentorJournalV02Context _context;

        public StudentController(MentorJournalV02Context context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllStudents()
        {
            return Ok(_context.Students.ToList());
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                return Ok(_context.Students.Find(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("new")]
        public IActionResult AddNewStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateStudent(int id, Student updatedStudent)
        {
            Student? existingStudent = _context.Students.Find(id);
            if (existingStudent == null)
                return NotFound();

            try
            {
                _context.Entry(existingStudent).CurrentValues.SetValues(updatedStudent);
                _context.SaveChanges();
                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            Student? existingStudent = _context.Students.Find(id);
            if (existingStudent == null)
                return NotFound();
            try
            {
                _context.Students.Remove(existingStudent);
                _context.SaveChanges();
                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
