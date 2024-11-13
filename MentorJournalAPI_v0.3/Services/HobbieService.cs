
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class HobbieService : IHobbieService
    {
        public MentorJournalV02Context _context;

        public HobbieService(MentorJournalV02Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HobbieDto>> GetAllAsync()
        {
            var hobbies = await _context.Hobbies
                .ToListAsync();
            var hobbieDtos = hobbies.Select(h => new HobbieDto
            {
                Id = h.Id,
                StudentId = h.StudentId,
                HobbieTypeId = h.HobbieTypeId,
            }).ToList();
            return hobbieDtos;
        }
        public async Task<HobbieDto> GetByIdAsync(int id)
        {
            var hobbie = await _context.Hobbies
                .FindAsync(id);
            if (hobbie == null)
            {
                throw new InvalidOperationException("Error geting Hobbie. Hobbie by id not found.");
            }
            var hobbieDto = new HobbieDto
            {
                Id = hobbie.Id,
                StudentId = hobbie.StudentId,
                HobbieTypeId = hobbie.HobbieTypeId,
            };
            return hobbieDto;
        }
        public async Task<HobbieDto> CreateAsync(HobbieDto hobbieDto)
        {
            Hobbie newHobbie = new Hobbie
            {
                StudentId = hobbieDto.StudentId,
                HobbieTypeId = hobbieDto.HobbieTypeId,
            };
            try
            {
                await _context.Hobbies.AddAsync(newHobbie);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating Hobbie.", ex);
            }
            hobbieDto.Id = newHobbie.Id;
            return hobbieDto;
        }
        public async Task<HobbieDto> UpdateAsync(int id, HobbieDto hobbieDto)
        {
            Hobbie? existingHobbie = await _context.Hobbies
                .FindAsync(id);
            if (existingHobbie == null)
            {
                throw new InvalidOperationException("Error geting Hobbie. Hobbie by id not found.");
            }
            existingHobbie.StudentId = hobbieDto.StudentId;
            existingHobbie.HobbieTypeId = hobbieDto.HobbieTypeId;
            try
            {
                _context.Hobbies.Update(existingHobbie);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Hobbie.", ex);
            }
            hobbieDto.Id = existingHobbie.Id;
            return hobbieDto;
        }
        public async Task DeleteAsync(int id)
        {
            Hobbie? hobbie = await _context.Hobbies
                .FindAsync(id);
            if (hobbie == null)
            {
                throw new InvalidOperationException("Error geting Hobbie. Hobbie by id not found.");
            }
            try
            {
                _context.Hobbies.Remove(hobbie);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting Hobbie.", ex);
            }
        }
    }
}
