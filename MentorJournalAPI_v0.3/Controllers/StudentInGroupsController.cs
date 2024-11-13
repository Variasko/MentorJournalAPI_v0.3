
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentInGroupsController : ControllerBase
    {
        private readonly IStudentInGroupService _studentingroupService;

        public StudentInGroupsController(IStudentInGroupService studentingroupService)
        {
            _studentingroupService = studentingroupService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentInGroupDto>>> GetAll()
        {
            try
            {
                var studentingroups = await _studentingroupService.GetAllAsync();
                return Ok(studentingroups);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentInGroupDto>> GetById(int id)
        {
            try
            {
                var studentingroup = await _studentingroupService.GetByIdAsync(id);
                if (studentingroup == null)
                {
                    return NotFound();
                }
                return Ok(studentingroup);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentInGroupDto>> Post(StudentInGroupDto studentingroupDto)
        {
            try
            {
                var createdStudentInGroup = await _studentingroupService.CreateAsync(studentingroupDto);
                return CreatedAtAction(nameof(GetById), new { id = createdStudentInGroup.Id }, createdStudentInGroup);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentInGroupDto>> Put(int id, StudentInGroupDto studentingroupDto)
        {
            try
            {
                var updatedStudentInGroup = await _studentingroupService.UpdateAsync(id, studentingroupDto);
                if (updatedStudentInGroup == null)
                {
                    return NotFound();
                }
                return Ok(updatedStudentInGroup);
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
                await _studentingroupService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
