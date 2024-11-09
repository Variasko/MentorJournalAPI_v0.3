
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDto>>> GetAll()
        {
            try
            {
                var admins = await _adminService.GetAllAsync();
                return Ok(admins);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDto>> GetById(int id)
        {
            try
            {
                var admin = await _adminService.GetByIdAsync(id);
                if (admin == null)
                {
                    return NotFound();
                }
                return Ok(admin);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<AdminDto>> Post(AdminDto adminDto)
        {
            try
            {
                var createdAdmin = await _adminService.CreateAsync(adminDto);
                return CreatedAtAction(nameof(GetById), new { id = createdAdmin.PersonId }, createdAdmin);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AdminDto>> Put(int id, AdminDto adminDto)
        {
            try
            {
                var updatedAdmin = await _adminService.UpdateAsync(id, adminDto);
                if (updatedAdmin == null)
                {
                    return NotFound();
                }
                return Ok(updatedAdmin);
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
                await _adminService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
