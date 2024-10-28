
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IAttendClassHourService
    {
        Task<IEnumerable<AttendClassHourDto>> GetAllAsync();
        Task<AttendClassHourDto> GetByIdAsync(int id);
        Task<AttendClassHourDto> CreateAsync(AttendClassHourDto attendclasshourDto);
        Task<AttendClassHourDto> UpdateAsync(int id, AttendClassHourDto attendclasshourDto);
        Task DeleteAsync(int id);
    }
}
