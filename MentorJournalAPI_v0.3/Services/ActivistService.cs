using System.Linq;
using Microsoft.EntityFrameworkCore;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MentorJournalAPI_v0._3.Services
{
public class ActivistService : IActivistService
    {

        private readonly MentorJournalV02Context _context;

        public ActivistService(MentorJournalV02Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ActivistDto>> GetAllAsync()
        {
            var activists = await _context.Activists
                .ToListAsync();

            var activistDtos = activists.Select(a => new ActivistDto
            {
                Id = a.Id,
                StudentId = a.StudentId,
                ActivityTypeId = a.ActivityTypeId
            }).ToList();

            return activistDtos;
        }

        public async Task<ActivistDto?> GetByIdAsync(int id)
        {
            var activist = await _context.Activists.FindAsync(id);
            if (activist == null)
            {
                throw new InvalidOperationException("Error geting Activist. Activist by id not found.");
            }

            var activistDto = new ActivistDto
            {
                Id = activist.Id,
                StudentId = activist.StudentId,
                ActivityTypeId = activist.ActivityTypeId
            };

            return activistDto;

        }
        public async Task<ActivistDto?> CreateAsync(ActivistDto activistDto)
        {
            Activist newActivist = new Activist
            {
                StudentId = activistDto.StudentId,
                ActivityTypeId = activistDto.ActivityTypeId
            };

            try
            {
                await _context.Activists.AddAsync(newActivist);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating Activist.", ex);
            }

            activistDto.Id = newActivist.Id;
            return activistDto;
        }
        public async Task<ActivistDto> UpdateAsync(int id, ActivistDto activistDto)
        {
            Activist existingActivist = await _context.Activists.FindAsync(id);

            if (existingActivist == null)
            {
                throw new InvalidOperationException("Error geting Activist. Activist by id not found.");
            }

            existingActivist.StudentId = activistDto.StudentId;
            existingActivist.ActivityTypeId = activistDto.ActivityTypeId;

            try
            {
                _context.Activists.Update(existingActivist);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Activist.", ex);
            }

            return activistDto;
        }
        public async Task DeleteAsync(int id)
        {
            Activist existingActivist = await _context.Activists.FindAsync(id);

            if (existingActivist == null)
            {
                throw new InvalidOperationException("Error geting Activist. Activist by id not found.");
            }

            try
            {
                _context.Activists.Remove(existingActivist);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting Activist.", ex);
            }

        }
    }
}
