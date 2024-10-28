
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialPassportsController : ControllerBase
    {
        private readonly ISocialPassportService _socialpassportService;

        public SocialPassportsController(ISocialPassportService socialpassportService)
        {
            _socialpassportService = socialpassportService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocialPassportDto>>> GetAll()
        {
            try
            {
                var socialpassports = await _socialpassportService.GetAllAsync();
                return Ok(socialpassports);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SocialPassportDto>> GetById(int id)
        {
            try
            {
                var socialpassport = await _socialpassportService.GetByIdAsync(id);
                if (socialpassport == null)
                {
                    return NotFound();
                }
                return Ok(socialpassport);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SocialPassportDto>> Post(SocialPassportDto socialpassportDto)
        {
            try
            {
                var createdSocialPassport = await _socialpassportService.CreateAsync(socialpassportDto);
                return CreatedAtAction(nameof(GetById), new { id = createdSocialPassport.Id }, createdSocialPassport);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SocialPassportDto>> Put(int id, SocialPassportDto socialpassportDto)
        {
            try
            {
                var updatedSocialPassport = await _socialpassportService.UpdateAsync(id, socialpassportDto);
                if (updatedSocialPassport == null)
                {
                    return NotFound();
                }
                return Ok(updatedSocialPassport);
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
                await _socialpassportService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
