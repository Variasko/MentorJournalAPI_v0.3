using MentorJournalAPI_v0._3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentorJournalAPI_v0._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private MentorJournalV02Context _context;

        public AdminController(MentorJournalV02Context context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllAdmins()
        {
            return Ok(_context.Admins.ToList());
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetAdminById(int id)
        {
            try
            {
                return Ok(_context.Admins.Find(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("new")]
        public IActionResult AddNewAdmin(Admin admin)
        {
            try
            {
                _context.Admins.Add(admin);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateAdmin(int id, Admin updatedAdmin)
        {
            Admin? existingAdmin = _context.Admins.Find(id);
            if (existingAdmin == null)
                return NotFound();
            try
            {
                _context.Entry(existingAdmin).CurrentValues.SetValues(updatedAdmin);
                _context.SaveChanges();
                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            Admin? existingAdmin = _context.Admins.Find(id);
            if (existingAdmin == null)
                return NotFound();
            try
            {
                _context.Admins.Remove(existingAdmin);
                _context.SaveChanges();
                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
