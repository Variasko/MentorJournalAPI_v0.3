
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IIndividualWorkWithParentService
    {
        Task<IEnumerable<IndividualWorkWithParentDto>> GetAllAsync();
        Task<IndividualWorkWithParentDto> GetByIdAsync(int id);
        Task<IndividualWorkWithParentDto> CreateAsync(IndividualWorkWithParentDto individualworkwithparentDto);
        Task<IndividualWorkWithParentDto> UpdateAsync(int id, IndividualWorkWithParentDto individualworkwithparentDto);
        Task DeleteAsync(int id);
    }
}
