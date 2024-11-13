
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class HobbieTypeService : IHobbieTypeService
    {
        public MentorJournalV02Context _context;

        public HobbieTypeService(MentorJournalV02Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HobbieTypeDto>> GetAllAsync()
        {
            var hobbietypes = await _context.HobbieTypes
                .ToListAsync();
            var hobbietypeDtos = hobbietypes.Select(h => new HobbieTypeDto
            {
                Id = h.Id,
                Name = h.Name
            }).ToList();
            return hobbietypeDtos;
        }
        public async Task<HobbieTypeDto> GetByIdAsync(int id)
        {
            var hobbietype = await _context.HobbieTypes
                .FindAsync(id);
            if (hobbietype == null)
            {
                throw new InvalidOperationException("Error geting HobbieType. HobbieType by id not found.");
            }
            var hobbietypeDto = new HobbieTypeDto
            {
                Id = hobbietype.Id,
                Name = hobbietype.Name
            };
            return hobbietypeDto;
        }
        public async Task<HobbieTypeDto> CreateAsync(HobbieTypeDto hobbietypeDto)
        {
            HobbieType newHobbieType = new HobbieType
            {
                Name = hobbietypeDto.Name
            };
            try
            {
                await _context.HobbieTypes.AddAsync(newHobbieType);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating HobbieType.", ex);
            }
            hobbietypeDto.Id = newHobbieType.Id;
            return hobbietypeDto;
        }
        public async Task<HobbieTypeDto> UpdateAsync(int id, HobbieTypeDto hobbietypeDto)
        {
            HobbieType? existingHobbieType = await _context.HobbieTypes
                .FindAsync(id);
            if (existingHobbieType == null)
            {
                throw new InvalidOperationException("Error geting HobbieType. HobbieType by id not found.");
            }
            existingHobbieType.Name = hobbietypeDto.Name;
            try
            {
                _context.HobbieTypes.Update(existingHobbieType);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating HobbieType.", ex);
            }
            hobbietypeDto.Id = existingHobbieType.Id;
            return hobbietypeDto;
        }
        public async Task DeleteAsync(int id)
        {
            HobbieType? hobbietype = await _context.HobbieTypes
                .FindAsync(id);
            if (hobbietype == null)
            {
                throw new InvalidOperationException("Error geting HobbieType. HobbieType by id not found.");
            }
            try
            {
                _context.HobbieTypes.Remove(hobbietype);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting HobbieType.", ex);
            }
        }
    }
}
