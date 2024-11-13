
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IClassHourService
    {
        Task<IEnumerable<ClassHourDto>> GetAllAsync();
        Task<ClassHourDto> GetByIdAsync(int id);
        Task<ClassHourDto> CreateAsync(ClassHourDto classhourDto);
        Task<ClassHourDto> UpdateAsync(int id, ClassHourDto classhourDto);
        Task DeleteAsync(int id);
    }
}
