
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialStatussController : ControllerBase
    {
        private readonly ISocialStatusService _socialstatusService;

        public SocialStatussController(ISocialStatusService socialstatusService)
        {
            _socialstatusService = socialstatusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocialStatusDto>>> GetAll()
        {
            try
            {
                var socialstatuss = await _socialstatusService.GetAllAsync();
                return Ok(socialstatuss);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SocialStatusDto>> GetById(int id)
        {
            try
            {
                var socialstatus = await _socialstatusService.GetByIdAsync(id);
                if (socialstatus == null)
                {
                    return NotFound();
                }
                return Ok(socialstatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SocialStatusDto>> Post(SocialStatusDto socialstatusDto)
        {
            try
            {
                var createdSocialStatus = await _socialstatusService.CreateAsync(socialstatusDto);
                return CreatedAtAction(nameof(GetById), new { id = createdSocialStatus.Id }, createdSocialStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SocialStatusDto>> Put(int id, SocialStatusDto socialstatusDto)
        {
            try
            {
                var updatedSocialStatus = await _socialstatusService.UpdateAsync(id, socialstatusDto);
                if (updatedSocialStatus == null)
                {
                    return NotFound();
                }
                return Ok(updatedSocialStatus);
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
                await _socialstatusService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
