
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IParentService
    {
        Task<IEnumerable<ParentDto>> GetAllAsync();
        Task<ParentDto> GetByIdAsync(int id);
        Task<ParentDto> CreateAsync(ParentDto parentDto);
        Task<ParentDto> UpdateAsync(int id, ParentDto parentDto);
        Task DeleteAsync(int id);
    }
}
