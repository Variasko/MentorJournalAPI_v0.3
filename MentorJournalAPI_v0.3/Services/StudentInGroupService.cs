
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class StudentInGroupService : IStudentInGroupService
    {

        private MentorJournalV02Context _context;

        public StudentInGroupService(MentorJournalV02Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentInGroupDto>> GetAllAsync()
        {
            var studentingroups = await _context.StudentInGroups
                .ToListAsync();

            var studentingroupDtos = studentingroups
                .Select(s => new StudentInGroupDto
                {
                    Id = s.Id,
                    StudentId = s.StudentId,
                    GroupId = s.GroupId,
                    Date = s.Date
                }).ToList();

            return studentingroupDtos;
        }
        public async Task<StudentInGroupDto> GetByIdAsync(int id)
        {
            var studentingroup = await _context.StudentInGroups
                .FindAsync(id);

            if (studentingroup == null)
            {
                throw new InvalidOperationException("Error geting StudentInGroup. StudentInGroup by id not found.");
            }

            var studentingroupDto = new StudentInGroupDto
            {
                Id = studentingroup.Id,
                StudentId = studentingroup.StudentId,
                GroupId = studentingroup.GroupId,
                Date = studentingroup.Date
            };

            return studentingroupDto;
        }
        public async Task<StudentInGroupDto> CreateAsync(StudentInGroupDto studentingroupDto)
        {
            StudentInGroup studentingroup = new StudentInGroup
            {
                GroupId = studentingroupDto.GroupId,
                Date = studentingroupDto.Date
            };

            try
            {
                await _context.StudentInGroups.AddAsync(studentingroup);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating StudentInGroup.", ex);
            }

            studentingroupDto.Id = studentingroup.Id;
            return studentingroupDto;
        }
        public async Task<StudentInGroupDto> UpdateAsync(int id, StudentInGroupDto studentingroupDto)
        {
            StudentInGroup? studentingroup = await _context.StudentInGroups
                .FindAsync(id);

            if (studentingroup == null)
            {
                throw new InvalidOperationException("Error geting StudentInGroup. StudentInGroup by id not found.");
            }

            studentingroup.StudentId = studentingroupDto.StudentId;
            studentingroup.GroupId = studentingroupDto.GroupId;
            studentingroup.Date = studentingroupDto.Date;

            try
            {
                _context.StudentInGroups.Update(studentingroup);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating StudentInGroup.", ex);
            }

            return studentingroupDto;
        }
        public async Task DeleteAsync(int id)
        {
            StudentInGroup? studentingroup = await _context.StudentInGroups
                .FindAsync(id);

            if (studentingroup == null)
            {
                throw new InvalidOperationException("Error geting StudentInGroup. StudentInGroup by id not found.");
            }

            try
            {
                _context.StudentInGroups.Remove(studentingroup);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting StudentInGroup.", ex);
            }
        }
    }
}
