
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IDormitoryService
    {
        Task<IEnumerable<DormitoryDto>> GetAllAsync();
        Task<DormitoryDto> GetByIdAsync(int id);
        Task<DormitoryDto> CreateAsync(DormitoryDto dormitoryDto);
        Task<DormitoryDto> UpdateAsync(int id, DormitoryDto dormitoryDto);
        Task DeleteAsync(int id);
    }
}
