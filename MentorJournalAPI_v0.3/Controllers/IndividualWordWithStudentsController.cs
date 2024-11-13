
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndividualWordWithStudentsController : ControllerBase
    {
        private readonly IIndividualWordWithStudentService _individualwordwithstudentService;

        public IndividualWordWithStudentsController(IIndividualWordWithStudentService individualwordwithstudentService)
        {
            _individualwordwithstudentService = individualwordwithstudentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndividualWordWithStudentDto>>> GetAll()
        {
            try
            {
                var individualwordwithstudents = await _individualwordwithstudentService.GetAllAsync();
                return Ok(individualwordwithstudents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IndividualWordWithStudentDto>> GetById(int id)
        {
            try
            {
                var individualwordwithstudent = await _individualwordwithstudentService.GetByIdAsync(id);
                if (individualwordwithstudent == null)
                {
                    return NotFound();
                }
                return Ok(individualwordwithstudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<IndividualWordWithStudentDto>> Post(IndividualWordWithStudentDto individualwordwithstudentDto)
        {
            try
            {
                var createdIndividualWordWithStudent = await _individualwordwithstudentService.CreateAsync(individualwordwithstudentDto);
                return CreatedAtAction(nameof(GetById), new { id = createdIndividualWordWithStudent.Id }, createdIndividualWordWithStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IndividualWordWithStudentDto>> Put(int id, IndividualWordWithStudentDto individualwordwithstudentDto)
        {
            try
            {
                var updatedIndividualWordWithStudent = await _individualwordwithstudentService.UpdateAsync(id, individualwordwithstudentDto);
                if (updatedIndividualWordWithStudent == null)
                {
                    return NotFound();
                }
                return Ok(updatedIndividualWordWithStudent);
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
                await _individualwordwithstudentService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
