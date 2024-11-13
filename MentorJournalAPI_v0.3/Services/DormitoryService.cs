
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class DormitoryService : IDormitoryService
    {
        public MentorJournalV02Context _context;

        public DormitoryService(MentorJournalV02Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DormitoryDto>> GetAllAsync()
        {
            var dormitories = await _context.Dormitories
                .ToListAsync();
            var dormitoriesDto = dormitories.Select(d => new DormitoryDto
            {
                Id = d.Id,
                StudentId = d.StudentId,
                RoomNumber = d.RoomNumber
            }).ToList();
            return dormitoriesDto;
        }
        public async Task<DormitoryDto> GetByIdAsync(int id)
        {
            var dormitory = await _context.Dormitories
                .FindAsync(id);
            if (dormitory == null)
            {
                throw new InvalidOperationException("Error geting Dormitory. Dormitory by id not found.");
            }
            var dormitoryDto = new DormitoryDto
            {
                Id = dormitory.Id,
                StudentId = dormitory.StudentId,
                RoomNumber = dormitory.RoomNumber
            };
            return dormitoryDto;
        }
        public async Task<DormitoryDto> CreateAsync(DormitoryDto dormitoryDto)
        {
            Dormitory newDormitory = new Dormitory
            {
                StudentId = dormitoryDto.StudentId,
                RoomNumber = dormitoryDto.RoomNumber
            };
            try
            {
                await _context.Dormitories.AddAsync(newDormitory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating Dormitory.", ex);
            }
            dormitoryDto.Id = newDormitory.Id;
            return dormitoryDto;
        }
        public async Task<DormitoryDto> UpdateAsync(int id, DormitoryDto dormitoryDto)
        {
            Dormitory? existingDormitory = await _context.Dormitories
                .FindAsync(id);
            if (existingDormitory == null)
            {
                throw new InvalidOperationException("Error geting Dormitory. Dormitory by id not found.");
            }
            existingDormitory.RoomNumber = dormitoryDto.RoomNumber;
            existingDormitory.StudentId = dormitoryDto.StudentId;
            try
            {
                _context.Dormitories.Update(existingDormitory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Dormitory.", ex);
            }
            dormitoryDto.Id = existingDormitory.Id;
            return dormitoryDto;
        }
        public async Task DeleteAsync(int id)
        {
            Dormitory? dormitory = await _context.Dormitories
                .FindAsync(id);
            if (dormitory == null)
            {
                throw new InvalidOperationException("Error geting Dormitory. Dormitory by id not found.");
            }
            try
            {
                _context.Dormitories.Remove(dormitory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting Dormitory.", ex);
            }
        }
    }
}
