
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminDto>> GetAllAsync();
        Task<AdminDto> GetByIdAsync(int id);
        Task<AdminDto> CreateAsync(AdminDto adminDto);
        Task<AdminDto> UpdateAsync(int id, AdminDto adminDto);
        Task DeleteAsync(int id);
    }
}
