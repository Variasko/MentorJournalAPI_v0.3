
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Services
{
public class SocialStatusService : ISocialStatusService
    {
        public async Task<IEnumerable<SocialStatusDto>> GetAllAsync();
        public async Task<SocialStatusDto> GetByIdAsync(int id);
        public async Task<SocialStatusDto> CreateAsync(SocialStatusDto socialstatusDto);
        public async Task<SocialStatusDto> UpdateAsync(int id, SocialStatusDto socialstatusDto);
        public async Task DeleteAsync(int id);
    }
}
