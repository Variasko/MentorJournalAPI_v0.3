
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDto>> GetAllAsync();
        Task<GroupDto> GetByIdAsync(int id);
        Task<GroupDto> CreateAsync(GroupDto groupDto);
        Task<GroupDto> UpdateAsync(int id, GroupDto groupDto);
        Task DeleteAsync(int id);
    }
}
