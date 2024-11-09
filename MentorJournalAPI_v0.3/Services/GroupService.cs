
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class GroupService : IGroupService
    {
        public MentorJournalV02Context _context;

        public GroupService(MentorJournalV02Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GroupDto>> GetAllAsync()
        {
            var groups = await _context.Groups
                .ToListAsync();
            var groupsDto = groups.Select(g => new GroupDto
            {
                Id = g.Id,
                MentorId = g.MentorId,
                SpecificationId = g.SpecificationId,
                IsBuget = g.IsBuget,
                RecruitmentDate = g.RecruitmentDate
            }).ToList();
            return groupsDto;
        }
        public async Task<GroupDto> GetByIdAsync(int id)
        {
            var group = await _context.Groups
                .FindAsync(id);
            if (group == null)
            {
                throw new InvalidOperationException("Error geting Group. Group by id not found.");
            }
            var groupDto = new GroupDto
            {
                Id = group.Id,
                MentorId = group.MentorId,
                SpecificationId = group.SpecificationId,
                IsBuget = group.IsBuget,
                RecruitmentDate = group.RecruitmentDate
            };
            return groupDto;
        }
        public async Task<GroupDto> CreateAsync(GroupDto groupDto)
        {
            Group newGroup = new Group
            {
                MentorId = groupDto.MentorId,
                SpecificationId = groupDto.SpecificationId,
                IsBuget = groupDto.IsBuget,
                RecruitmentDate = groupDto.RecruitmentDate
            };
            try
            {
                await _context.Groups.AddAsync(newGroup);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating Group.", ex);
            }
            groupDto.Id = newGroup.Id;
            return groupDto;
        }
        public async Task<GroupDto> UpdateAsync(int id, GroupDto groupDto)
        {
            Group? group = await _context.Groups
                .FindAsync(id);
            if (group == null)
            {
                throw new InvalidOperationException("Error geting Group. Group by id not found.");
            }
            group.MentorId = groupDto.MentorId;
            group.SpecificationId = groupDto.SpecificationId;
            group.IsBuget = groupDto.IsBuget;
            group.RecruitmentDate = groupDto.RecruitmentDate;
            try
            {
                _context.Groups.Update(group);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Group.", ex);
            }
            groupDto.Id = group.Id;
            return groupDto;
        }
        public async Task DeleteAsync(int id)
        {
            Group? group = await _context.Groups
                .FindAsync(id);
            if (group == null)
            {
                throw new InvalidOperationException("Error geting Group. Group by id not found.");
            }
            try
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting Group.", ex);
            }
        }
    }
}
