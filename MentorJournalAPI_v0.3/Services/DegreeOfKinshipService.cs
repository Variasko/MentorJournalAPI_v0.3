
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class DegreeOfKinshipService : IDegreeOfKinshipService
    {
        public MentorJournalV02Context _context;

        public DegreeOfKinshipService(MentorJournalV02Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DegreeOfKinshipDto>> GetAllAsync()
        {
            var degreeofkinships = await _context.DegreeOfKinships
                .ToListAsync();
            var degreeofkinshipDtos = degreeofkinships.Select(d => new DegreeOfKinshipDto
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();
            return degreeofkinshipDtos;
        }
        public async Task<DegreeOfKinshipDto> GetByIdAsync(int id)
        {
            var degreeofkinship = await _context.DegreeOfKinships
                .FindAsync(id);
            if (degreeofkinship == null)
            {
                throw new InvalidOperationException("Error geting DegreeOfKinship. DegreeOfKinship by id not found.");
            }
            var degreeofkinshipDto = new DegreeOfKinshipDto
            {
                Id = degreeofkinship.Id,
                Name = degreeofkinship.Name
            };
            return degreeofkinshipDto;
        }
        public async Task<DegreeOfKinshipDto> CreateAsync(DegreeOfKinshipDto degreeofkinshipDto)
        {
            DegreeOfKinship newDegreeOfKinship = new DegreeOfKinship
            {
                Name = degreeofkinshipDto.Name
            };
            try
            {
                await _context.DegreeOfKinships.AddAsync(newDegreeOfKinship);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating DegreeOfKinship.", ex);
            }
            degreeofkinshipDto.Id = newDegreeOfKinship.Id;
            return degreeofkinshipDto;
        }
        public async Task<DegreeOfKinshipDto> UpdateAsync(int id, DegreeOfKinshipDto degreeofkinshipDto)
        {
            DegreeOfKinship? existingDegreeOfKinship = await _context.DegreeOfKinships
                .FindAsync(id);
            if (existingDegreeOfKinship == null)
            {
                throw new InvalidOperationException("Error geting DegreeOfKinship. DegreeOfKinship by id not found.");
            }
            existingDegreeOfKinship.Name = degreeofkinshipDto.Name;
            try
            {
                _context.DegreeOfKinships.Update(existingDegreeOfKinship);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating DegreeOfKinship.", ex);
            }
            degreeofkinshipDto.Id = existingDegreeOfKinship.Id;
            return degreeofkinshipDto;
        }
        public async Task DeleteAsync(int id)
        {
            DegreeOfKinship? degreeofkinship = await _context.DegreeOfKinships
                .FindAsync(id);
            if (degreeofkinship == null)
            {
                throw new InvalidOperationException("Error geting DegreeOfKinship. DegreeOfKinship by id not found.");
            }
            try
            {
                _context.DegreeOfKinships.Remove(degreeofkinship);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting DegreeOfKinship.", ex);
            }
        }

    }
}
