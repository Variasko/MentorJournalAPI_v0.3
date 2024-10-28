
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecificationsController : ControllerBase
    {
        private readonly ISpecificationService _specificationService;

        public SpecificationsController(ISpecificationService specificationService)
        {
            _specificationService = specificationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecificationDto>>> GetAll()
        {
            try
            {
                var specifications = await _specificationService.GetAllAsync();
                return Ok(specifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecificationDto>> GetById(int id)
        {
            try
            {
                var specification = await _specificationService.GetByIdAsync(id);
                if (specification == null)
                {
                    return NotFound();
                }
                return Ok(specification);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SpecificationDto>> Post(SpecificationDto specificationDto)
        {
            try
            {
                var createdSpecification = await _specificationService.CreateAsync(specificationDto);
                return CreatedAtAction(nameof(GetById), new { id = createdSpecification.Id }, createdSpecification);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SpecificationDto>> Put(int id, SpecificationDto specificationDto)
        {
            try
            {
                var updatedSpecification = await _specificationService.UpdateAsync(id, specificationDto);
                if (updatedSpecification == null)
                {
                    return NotFound();
                }
                return Ok(updatedSpecification);
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
                await _specificationService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
