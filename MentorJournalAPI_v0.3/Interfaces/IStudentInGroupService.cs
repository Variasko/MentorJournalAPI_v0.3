
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IStudentInGroupService
    {
        Task<IEnumerable<StudentInGroupDto>> GetAllAsync();
        Task<StudentInGroupDto> GetByIdAsync(int id);
        Task<StudentInGroupDto> CreateAsync(StudentInGroupDto studentingroupDto);
        Task<StudentInGroupDto> UpdateAsync(int id, StudentInGroupDto studentingroupDto);
        Task DeleteAsync(int id);
    }
}
