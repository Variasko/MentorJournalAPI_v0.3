
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;

namespace MentorJournalAPI_v0._3.Services
{
public class ObservationListService : IObservationListService
    {
        public MentorJournalV02Context _context;

        public ObservationListService(MentorJournalV02Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ObservationListDto>> GetAllAsync()
        {
            var observationlists = await _context.ObservationLists
                .ToListAsync();
            var observationlistDtos = observationlists.Select(o => new ObservationListDto
            {
                Id = o.Id,
                StudentId = o.StudentId,
                Characteristic = o.Characteristic,
                Date = o.Date
            }).ToList();

            return observationlistDtos;
        }
        public async Task<ObservationListDto> GetByIdAsync(int id)
        {
            var observationlist = await _context.ObservationLists
                .FindAsync(id);
            if (observationlist == null)
            {
                throw new InvalidOperationException("Error geting ObservationList. ObservationList by id not found.");
            }
            var observationlistDto = new ObservationListDto
            {
                Id = observationlist.Id,
                StudentId = observationlist.StudentId,
                Characteristic = observationlist.Characteristic,
                Date = observationlist.Date
            };
            return observationlistDto;
        }
        public async Task<ObservationListDto> CreateAsync(ObservationListDto observationlistDto)
        {
            ObservationList observationlist = new ObservationList
            {
                StudentId = observationlistDto.StudentId,
                Characteristic = observationlistDto.Characteristic,
                Date = observationlistDto.Date
            };
            try
            {
                await _context.ObservationLists.AddAsync(observationlist);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating ObservationList.", ex);
            }
            observationlistDto.Id = observationlist.Id;
            return observationlistDto;
        }
        public async Task<ObservationListDto> UpdateAsync(int id, ObservationListDto observationlistDto)
        {
            ObservationList? observationlist = await _context.ObservationLists
                .FindAsync(id);
            if (observationlist == null)
            {
                throw new InvalidOperationException("Error geting ObservationList. ObservationList by id not found.");
            }
            try
            {
                _context.ObservationLists.Update(observationlist);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating ObservationList.", ex);
            }
        }
        public async Task DeleteAsync(int id)
        {
            ObservationList? observationlist = await _context.ObservationLists
                .FindAsync(id);
            if (observationlist == null)
            {
                throw new InvalidOperationException("Error geting ObservationList. ObservationList by id not found.");
            }
            try
            {
                _context.ObservationLists.Remove(observationlist);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting ObservationList.", ex);
            }
        }
    }
}
