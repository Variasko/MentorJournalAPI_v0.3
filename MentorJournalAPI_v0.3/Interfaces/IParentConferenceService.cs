
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IParentConferenceService
    {
        Task<IEnumerable<ParentConferenceDto>> GetAllAsync();
        Task<ParentConferenceDto> GetByIdAsync(int id);
        Task<ParentConferenceDto> CreateAsync(ParentConferenceDto parentconferenceDto);
        Task<ParentConferenceDto> UpdateAsync(int id, ParentConferenceDto parentconferenceDto);
        Task DeleteAsync(int id);
    }
}
