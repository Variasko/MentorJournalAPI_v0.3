
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IHobbieService
    {
        Task<IEnumerable<HobbieDto>> GetAllAsync();
        Task<HobbieDto> GetByIdAsync(int id);
        Task<HobbieDto> CreateAsync(HobbieDto hobbieDto);
        Task<HobbieDto> UpdateAsync(int id, HobbieDto hobbieDto);
        Task DeleteAsync(int id);
    }
}
