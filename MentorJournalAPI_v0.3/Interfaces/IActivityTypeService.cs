
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface IActivityTypeService
    {
        Task<IEnumerable<ActivityTypeDto>> GetAllAsync();
        Task<ActivityTypeDto> GetByIdAsync(int id);
        Task<ActivityTypeDto> CreateAsync(ActivityTypeDto activitytypeDto);
        Task<ActivityTypeDto> UpdateAsync(int id, ActivityTypeDto activitytypeDto);
        Task DeleteAsync(int id);
    }
}
