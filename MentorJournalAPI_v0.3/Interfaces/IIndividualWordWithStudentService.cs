
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IIndividualWordWithStudentService
    {
        Task<IEnumerable<IndividualWordWithStudentDto>> GetAllAsync();
        Task<IndividualWordWithStudentDto> GetByIdAsync(int id);
        Task<IndividualWordWithStudentDto> CreateAsync(IndividualWordWithStudentDto individualwordwithstudentDto);
        Task<IndividualWordWithStudentDto> UpdateAsync(int id, IndividualWordWithStudentDto individualwordwithstudentDto);
        Task DeleteAsync(int id);
    }
}
