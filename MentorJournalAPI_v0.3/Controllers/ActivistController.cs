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
                return Ok(_context.Activists.Find(id));
            }
        }
    }
}
