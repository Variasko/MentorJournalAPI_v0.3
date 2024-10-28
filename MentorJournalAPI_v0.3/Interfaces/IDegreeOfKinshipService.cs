
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IDegreeOfKinshipService
    {
        Task<IEnumerable<DegreeOfKinshipDto>> GetAllAsync();
        Task<DegreeOfKinshipDto> GetByIdAsync(int id);
        Task<DegreeOfKinshipDto> CreateAsync(DegreeOfKinshipDto degreeofkinshipDto);
        Task<DegreeOfKinshipDto> UpdateAsync(int id, DegreeOfKinshipDto degreeofkinshipDto);
        Task DeleteAsync(int id);
    }
}
