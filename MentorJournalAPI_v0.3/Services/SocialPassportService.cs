using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;

namespace MentorJournalAPI_v0._3.Services
{
public class SocialPassportService : ISocialPassportService
    {

        private MentorJournalV02Context _context;

        public SocialPassportService(MentorJournalV02Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SocialPassportDto>> GetAllAsync()
        {
            var socialPassports = await _context.SocialPassports
                .ToListAsync();

            var socialPassportDtos = socialPassports
                .Select(s => new SocialPassportDto
                {
                    Id = s.Id,
                    StudentId = s.StudnetId,
                    SocialStatusId = s.SocialStatusId
                }).ToList();
            return socialPassportDtos;
        }
        public async Task<SocialPassportDto> GetByIdAsync(int id)
        {
            SocialPassport? socialPassport = await _context.SocialPassports
                .FindAsync(id);
            if (socialPassport == null)
            {
                throw new InvalidOperationException("Error geting SocialPassport. SocialPassport by id not found.");
            }
            var socialPassportDto = new SocialPassportDto
            {
                Id = socialPassport.Id,
                StudentId = socialPassport.StudnetId,
                SocialStatusId = socialPassport.SocialStatusId
            };
            return socialPassportDto;
        }
        public async Task<SocialPassportDto> CreateAsync(SocialPassportDto socialpassportDto)
        {
            SocialPassport newSocialPassport = new SocialPassport
            {
                StudnetId = socialpassportDto.StudentId,
                SocialStatusId = socialpassportDto.SocialStatusId
            };
            try
            {
                await _context.SocialPassports.AddAsync(newSocialPassport);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating SocialPassport.", ex);
            }
            socialpassportDto.Id = newSocialPassport.Id;
            return socialpassportDto;
        }
        public async Task<SocialPassportDto> UpdateAsync(int id, SocialPassportDto socialpassportDto)
        {
            SocialPassport? existingSocialPassport = await _context.SocialPassports
                .FindAsync(id);
            if (existingSocialPassport == null)
            {
                throw new InvalidOperationException("Error geting SocialPassport. SocialPassport by id not found.");
            }
            existingSocialPassport.StudnetId = socialpassportDto.StudentId;
            existingSocialPassport.SocialStatusId = socialpassportDto.SocialStatusId;
            try
            {
                _context.SocialPassports.Update(existingSocialPassport);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating SocialPassport.", ex);
            }
            socialpassportDto.Id = existingSocialPassport.Id;
            return socialpassportDto;
        }
        public async Task DeleteAsync(int id)
        {
            SocialPassport? socialPassport = await _context.SocialPassports
                .FindAsync(id);
            if (socialPassport == null)
            {
                throw new InvalidOperationException("Error geting SocialPassport. SocialPassport by id not found.");
            }
            try
            {
                _context.SocialPassports.Remove(socialPassport);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting SocialPassport.", ex);
            }
        }
    }
}
