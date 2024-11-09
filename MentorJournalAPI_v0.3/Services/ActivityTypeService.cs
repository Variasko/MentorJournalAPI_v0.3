
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class ActivityTypeService : IActivityTypeService
    {

        private readonly MentorJournalV02Context _context;

        public ActivityTypeService(MentorJournalV02Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ActivityTypeDto>> GetAllAsync()
        {
            var activityTypes = await _context.ActivityTypes
                .ToListAsync();

            var activityTypesDto = activityTypes.Select(a => new ActivityTypeDto
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();

            return activityTypesDto;

        }
        public async Task<ActivityTypeDto> GetByIdAsync(int id)
        {
            ActivityType? activityType = await _context.ActivityTypes
                .FindAsync(id);

            if (activityType == null)
                throw new InvalidOperationException("Error geting ActivityType. ActivityType by id not found.");

            var activityTypeDto = new ActivityTypeDto
            {
                Id = activityType.Id,
                Name = activityType.Name
            };

            return activityTypeDto;

        }
        public async Task<ActivityTypeDto> CreateAsync(ActivityTypeDto activitytypeDto)
        {
            ActivityType newActivist = new ActivityType
            {
                Name = activitytypeDto.Name
            };

            try
            {
                await _context.ActivityTypes.AddAsync(newActivist);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating ActivityType.", ex);
            }

            activitytypeDto.Id = newActivist.Id;
            return activitytypeDto;
        }
        public async Task<ActivityTypeDto> UpdateAsync(int id, ActivityTypeDto activitytypeDto)
        {
            ActivityType existingActivityType = await _context.ActivityTypes
                .FindAsync(id);

            if (existingActivityType == null)
                throw new InvalidOperationException("Error updating ActivityType.");

            existingActivityType.Name = activitytypeDto.Name;

            try
            {
                _context.ActivityTypes.Update(existingActivityType);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating ActivityType.", ex);
            }

            return activitytypeDto;
        }
        public async Task DeleteAsync(int id)
        {
            ActivityType existingActivityType = await _context.ActivityTypes
                .FindAsync(id);

            if (existingActivityType == null)
                throw new InvalidOperationException("Error updating ActivityType.");

            try
            {
                _context.ActivityTypes.Remove(existingActivityType);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting ActivityType.", ex);
            }
        }
    }
}
