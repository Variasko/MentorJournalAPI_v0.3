
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto> GetByIdAsync(int id);
        Task<StudentDto> CreateAsync(StudentDto studentDto);
        Task<StudentDto> UpdateAsync(int id, StudentDto studentDto);
        Task DeleteAsync(int id);
    }
}
