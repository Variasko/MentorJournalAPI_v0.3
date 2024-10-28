
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IActivistService
    {
        Task<IEnumerable<ActivistDto>> GetAllAsync();
        Task<ActivistDto> GetByIdAsync(int id);
        Task<ActivistDto> CreateAsync(ActivistDto activistDto);
        Task<ActivistDto> UpdateAsync(int id, ActivistDto activistDto);
        Task DeleteAsync(int id);
    }
}
