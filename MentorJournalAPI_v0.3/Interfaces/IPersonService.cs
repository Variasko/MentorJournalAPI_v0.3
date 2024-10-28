
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetAllAsync();
        Task<PersonDto> GetByIdAsync(int id);
        Task<PersonDto> CreateAsync(PersonDto personDto);
        Task<PersonDto> UpdateAsync(int id, PersonDto personDto);
        Task DeleteAsync(int id);
    }
}
