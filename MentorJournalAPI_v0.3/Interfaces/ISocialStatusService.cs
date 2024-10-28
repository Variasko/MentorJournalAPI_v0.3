
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface ISocialStatusService
    {
        Task<IEnumerable<SocialStatusDto>> GetAllAsync();
        Task<SocialStatusDto> GetByIdAsync(int id);
        Task<SocialStatusDto> CreateAsync(SocialStatusDto socialstatusDto);
        Task<SocialStatusDto> UpdateAsync(int id, SocialStatusDto socialstatusDto);
        Task DeleteAsync(int id);
    }
}
