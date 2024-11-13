
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IObservationListService
    {
        Task<IEnumerable<ObservationListDto>> GetAllAsync();
        Task<ObservationListDto> GetByIdAsync(int id);
        Task<ObservationListDto> CreateAsync(ObservationListDto observationlistDto);
        Task<ObservationListDto> UpdateAsync(int id, ObservationListDto observationlistDto);
        Task DeleteAsync(int id);
    }
}
