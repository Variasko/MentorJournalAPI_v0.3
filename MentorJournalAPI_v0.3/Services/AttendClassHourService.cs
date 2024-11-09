
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class AttendClassHourService : IAttendClassHourService
    {
        public MentorJournalV02Context _context;

        public AttendClassHourService(MentorJournalV02Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AttendClassHourDto>> GetAllAsync()
        {
            var attendclasshours = await _context.AttendClassHours
                .ToListAsync();
            var attendclasshourDtos = attendclasshours.Select(a => new AttendClassHourDto
            {
                Id = a.Id,
                StudentId = a.StudentId,
                ClassHourId = a.ClassHourId,
                IsVisited = a.IsVisited

            }).ToList();
            return attendclasshourDtos;
        }
        public async Task<AttendClassHourDto> GetByIdAsync(int id)
        {
            var attendclasshour = await _context.AttendClassHours
                .FindAsync(id);
            if (attendclasshour == null)
            {
                throw new InvalidOperationException("Error geting AttendClassHour. AttendClassHour by id not found.");
            }
            var attendclasshourDto = new AttendClassHourDto
            {
                Id = attendclasshour.Id,
                StudentId = attendclasshour.StudentId,
                ClassHourId = attendclasshour.ClassHourId,
                IsVisited = attendclasshour.IsVisited
            };
            return attendclasshourDto;
        }
        public async Task<AttendClassHourDto> CreateAsync(AttendClassHourDto attendclasshourDto)
        {
            AttendClassHour newAttendClassHour = new AttendClassHour
            {
                StudentId = attendclasshourDto.StudentId,
                ClassHourId = attendclasshourDto.ClassHourId,
                IsVisited = attendclasshourDto.IsVisited
            };
            try
            {
                await _context.AttendClassHours.AddAsync(newAttendClassHour);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating AttendClassHour.", ex);
            }
            attendclasshourDto.Id = newAttendClassHour.Id;
            return attendclasshourDto;
        }
        public async Task<AttendClassHourDto> UpdateAsync(int id, AttendClassHourDto attendclasshourDto)
        {
            AttendClassHour? attendclasshour = await _context.AttendClassHours
                .FindAsync(id);
            if (attendclasshour == null)
            {
                throw new InvalidOperationException("Error geting AttendClassHour. AttendClassHour by id not found.");
            }
            attendclasshour.StudentId = attendclasshourDto.StudentId;
            attendclasshour.ClassHourId = attendclasshourDto.ClassHourId;
            attendclasshour.IsVisited = attendclasshourDto.IsVisited;
            try
            {
                _context.AttendClassHours.Update(attendclasshour);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating AttendClassHour.", ex);
            }
            return attendclasshourDto;
        }
        public async Task DeleteAsync(int id)
        {
            AttendClassHour? attendclasshour = await _context.AttendClassHours
                .FindAsync(id);
            if (attendclasshour == null)
            {
                throw new InvalidOperationException("Error geting AttendClassHour. AttendClassHour by id not found.");
            }
            try
            {
                _context.AttendClassHours.Remove(attendclasshour);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting AttendClassHour.", ex);
            }
        }
    }
}
