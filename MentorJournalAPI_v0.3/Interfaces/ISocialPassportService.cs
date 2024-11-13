
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface ISocialPassportService
    {
        Task<IEnumerable<SocialPassportDto>> GetAllAsync();
        Task<SocialPassportDto> GetByIdAsync(int id);
        Task<SocialPassportDto> CreateAsync(SocialPassportDto socialpassportDto);
        Task<SocialPassportDto> UpdateAsync(int id, SocialPassportDto socialpassportDto);
        Task DeleteAsync(int id);
    }
}
