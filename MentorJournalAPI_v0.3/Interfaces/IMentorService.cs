
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IMentorService
    {
        Task<IEnumerable<MentorDto>> GetAllAsync();
        Task<MentorDto> GetByIdAsync(int id);
        Task<MentorDto> CreateAsync(MentorDto mentorDto);
        Task<MentorDto> UpdateAsync(int id, MentorDto mentorDto);
        Task DeleteAsync(int id);
    }
}
