
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IHobbieTypeService
    {
        Task<IEnumerable<HobbieTypeDto>> GetAllAsync();
        Task<HobbieTypeDto> GetByIdAsync(int id);
        Task<HobbieTypeDto> CreateAsync(HobbieTypeDto hobbietypeDto);
        Task<HobbieTypeDto> UpdateAsync(int id, HobbieTypeDto hobbietypeDto);
        Task DeleteAsync(int id);
    }
}
