
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class ParentConferenceService : IParentConferenceService
    {
        public MentorJournalV02Context _context;

        public ParentConferenceService(MentorJournalV02Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParentConferenceDto>> GetAllAsync()
        {
            var parentconferences = await _context.ParentConferences
                .ToListAsync();

            var parentconferenceDtos = parentconferences
                .Select(p => new ParentConferenceDto
                {
                    Id = p.Id,
                    Date = p.Date,
                    AmountPresent = p.AmountPresent,
                    AmountMiss = p.AmountMiss,
                    Title = p.Title,
                    Result = p.Result,
                    GroupId = p.GroupId,
                }).ToList();

            return parentconferenceDtos;
        }
        public async Task<ParentConferenceDto> GetByIdAsync(int id)
        {
            var parentconference = await _context.ParentConferences
                .FindAsync(id);
            if (parentconference == null)
            {
                throw new InvalidOperationException("Error geting ParentConference. ParentConference by id not found.");
            }
            var parentconferenceDto = new ParentConferenceDto
            {
                Id = parentconference.Id,
                Date = parentconference.Date,
                AmountPresent = parentconference.AmountPresent,
                AmountMiss = parentconference.AmountMiss,
                Title = parentconference.Title,
                Result = parentconference.Result,
                GroupId = parentconference.GroupId,
            };
            return parentconferenceDto;
        }
        public async Task<ParentConferenceDto> CreateAsync(ParentConferenceDto parentconferenceDto)
        {
            ParentConference parentconference = new ParentConference
            {
                Date = parentconferenceDto.Date,
                AmountPresent = parentconferenceDto.AmountPresent,
                AmountMiss = parentconferenceDto.AmountMiss,
                Title = parentconferenceDto.Title,
                Result = parentconferenceDto.Result,
                GroupId = parentconferenceDto.GroupId,
            };
            try
            {
                await _context.ParentConferences.AddAsync(parentconference);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating ParentConference.", ex);
            }
            parentconferenceDto.Id = parentconference.Id;
            return parentconferenceDto;
        }
        public async Task<ParentConferenceDto> UpdateAsync(int id, ParentConferenceDto parentconferenceDto)
        {
            ParentConference? parentconference = await _context.ParentConferences
                .FindAsync(id);
            if (parentconference == null)
            {
                throw new InvalidOperationException("Error geting ParentConference. ParentConference by id not found.");
            }
            try
            {
                _context.ParentConferences.Update(parentconference);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating ParentConference.", ex);
            }
        }
        public async Task DeleteAsync(int id)
        {
            ParentConference? parentconference = await _context.ParentConferences
                .FindAsync(id);
            if (parentconference == null)
            {
                throw new InvalidOperationException("Error geting ParentConference. ParentConference by id not found.");
            }
            try
            {
                _context.ParentConferences.Remove(parentconference);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting ParentConference.", ex);
            }
        }
    }
}
