using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;

namespace MentorJournalAPI_v0._3.Services
{
public class SocialStatusService : ISocialStatusService
    {

        private MentorJournalV02Context _context;

        public SocialStatusService(MentorJournalV02Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SocialStatusDto>> GetAllAsync()
        {
            var socialStatuses = await _context.SocialStatuses
                .ToListAsync();

            var socialStatusDtos = socialStatuses.Select(s => new SocialStatusDto
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

            return socialStatusDtos;

        }
        public async Task<SocialStatusDto> GetByIdAsync(int id)
        {
            var socialstatus = await _context.SocialStatuses
                .FindAsync(id);
            if (socialstatus == null)
            {
                throw new InvalidOperationException("Error geting SocialStatus. SocialStatus by id not found.");
            }
            var socialstatusDto = new SocialStatusDto
            {
                Id = socialstatus.Id,
                Name = socialstatus.Name
            };
            return socialstatusDto;
        }
        public async Task<SocialStatusDto> CreateAsync(SocialStatusDto socialstatusDto)
        {
            SocialStatus newSocialStatus = new SocialStatus
            {
                Name = socialstatusDto.Name
            };
            try
            {
                await _context.SocialStatuses.AddAsync(newSocialStatus);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating SocialStatus.", ex);
            }
            socialstatusDto.Id = newSocialStatus.Id;
            return socialstatusDto;
        }
        public async Task<SocialStatusDto> UpdateAsync(int id, SocialStatusDto socialstatusDto)
        {
            SocialStatus? existingSocialStatus = await _context.SocialStatuses
                .FindAsync(id);
            if (existingSocialStatus == null)
            {
                throw new InvalidOperationException("Error geting SocialStatus. SocialStatus by id not found.");
            }
            existingSocialStatus.Name = socialstatusDto.Name;
            try
            {
                _context.SocialStatuses.Update(existingSocialStatus);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating SocialStatus.", ex);
            }
            socialstatusDto.Id = existingSocialStatus.Id;
            return socialstatusDto;
        }
        public async Task DeleteAsync(int id)
        {
            SocialStatus? socialstatus = await _context.SocialStatuses
                .FindAsync(id);
            if (socialstatus == null)
            {
                throw new InvalidOperationException("Error geting SocialStatus. SocialStatus by id not found.");
            }
            try
            {
                _context.SocialStatuses.Remove(socialstatus);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting SocialStatus.", ex);
            }
        }
    }
}
