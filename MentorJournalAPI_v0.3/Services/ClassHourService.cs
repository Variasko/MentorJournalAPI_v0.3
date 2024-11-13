
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class ClassHourService : IClassHourService
    {
        public MentorJournalV02Context _context;

        public ClassHourService(MentorJournalV02Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ClassHourDto>> GetAllAsync()
        {
            var classhours = await _context.ClassHours
                .ToListAsync();
            var classhourDtos = classhours.Select(c => new ClassHourDto
            {
                Id = c.Id,
                Date = c.Date
            }).ToList();
            return classhourDtos;
        }
        public async Task<ClassHourDto> GetByIdAsync(int id)
        {
            var classhour = await _context.ClassHours
                .FindAsync(id);
            if (classhour == null)
            {
                throw new InvalidOperationException("Error geting ClassHour. ClassHour by id not found.");
            }
            var classhourDto = new ClassHourDto
            {
                Id = classhour.Id,
                Date = classhour.Date
            };
            return classhourDto;
        }
        public async Task<ClassHourDto> CreateAsync(ClassHourDto classhourDto)
        {
            ClassHour newClassHour = new ClassHour
            {
                Date = classhourDto.Date
            };
            try
            {
                await _context.ClassHours.AddAsync(newClassHour);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating ClassHour.", ex);
            }
            classhourDto.Id = newClassHour.Id;
            return classhourDto;
        }
        public async Task<ClassHourDto> UpdateAsync(int id, ClassHourDto classhourDto)
        {
            ClassHour? classhour = await _context.ClassHours
                .FindAsync(id);
            if (classhour == null)
            {
                throw new InvalidOperationException("Error geting ClassHour. ClassHour by id not found.");
            }
            classhour.Date = classhourDto.Date;
            try
            {
                _context.ClassHours.Update(classhour);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating ClassHour.", ex);
            }
            classhourDto.Id = classhour.Id;
            return classhourDto;
        }
        public async Task DeleteAsync(int id)
        {
            ClassHour? classhour = await _context.ClassHours
                .FindAsync(id);
            if (classhour == null)
            {
                throw new InvalidOperationException("Error geting ClassHour. ClassHour by id not found.");
            }
            try
            {
                _context.ClassHours.Remove(classhour);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting ClassHour.", ex);
            }
        }
    }
}
