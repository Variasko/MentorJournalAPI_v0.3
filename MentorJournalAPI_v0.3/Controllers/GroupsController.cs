
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetAll()
        {
            try
            {
                var groups = await _groupService.GetAllAsync();
                return Ok(groups);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> GetById(int id)
        {
            try
            {
                var group = await _groupService.GetByIdAsync(id);
                if (group == null)
                {
                    return NotFound();
                }
                return Ok(group);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GroupDto>> Post(GroupDto groupDto)
        {
            try
            {
                var createdGroup = await _groupService.CreateAsync(groupDto);
                return CreatedAtAction(nameof(GetById), new { id = createdGroup.Id }, createdGroup);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GroupDto>> Put(int id, GroupDto groupDto)
        {
            try
            {
                var updatedGroup = await _groupService.UpdateAsync(id, groupDto);
                if (updatedGroup == null)
                {
                    return NotFound();
                }
                return Ok(updatedGroup);
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
                await _groupService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
