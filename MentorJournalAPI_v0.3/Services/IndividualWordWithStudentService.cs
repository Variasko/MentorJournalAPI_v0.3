
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class IndividualWordWithStudentService : IIndividualWordWithStudentService
    {
        public MentorJournalV02Context _context;

        public IndividualWordWithStudentService(MentorJournalV02Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<IndividualWordWithStudentDto>> GetAllAsync()
        {
            var individualwordwithstudents = await _context.IndividualWordWithStudents
                .ToListAsync();
            var individualwordwithstudentDtos = individualwordwithstudents.Select(i => new IndividualWordWithStudentDto
            {
                Id = i.Id,
                Title = i.Title,
                Result = i.Result,
                Date = i.Date,
                StudentId = i.StudentId
            }).ToList();
            return individualwordwithstudentDtos;
        }
        public async Task<IndividualWordWithStudentDto> GetByIdAsync(int id)
        {
            var individualwordwithstudent = await _context.IndividualWordWithStudents
                .FindAsync(id);
            if (individualwordwithstudent == null)
            {
                throw new InvalidOperationException("Error geting IndividualWordWithStudent. IndividualWordWithStudent by id not found.");
            }
            var individualwordwithstudentDto = new IndividualWordWithStudentDto
            {
                Id = individualwordwithstudent.Id,
                Title = individualwordwithstudent.Title,
                Result = individualwordwithstudent.Result,
                Date = individualwordwithstudent.Date,
                StudentId = individualwordwithstudent.StudentId
            };
            return individualwordwithstudentDto;
        }
        public async Task<IndividualWordWithStudentDto> CreateAsync(IndividualWordWithStudentDto individualwordwithstudentDto)
        {
            IndividualWordWithStudent newIndividualWordWithStudent = new IndividualWordWithStudent
            {
                Title = individualwordwithstudentDto.Title,
                Result = individualwordwithstudentDto.Result,
                Date = individualwordwithstudentDto.Date,
                StudentId = individualwordwithstudentDto.StudentId
            };
            try
            {
                await _context.IndividualWordWithStudents.AddAsync(newIndividualWordWithStudent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating IndividualWordWithStudent.", ex);
            }
            individualwordwithstudentDto.Id = newIndividualWordWithStudent.Id;
            return individualwordwithstudentDto;
        }
        public async Task<IndividualWordWithStudentDto> UpdateAsync(int id, IndividualWordWithStudentDto individualwordwithstudentDto)
        {
            IndividualWordWithStudent? individualwordwithstudent = await _context.IndividualWordWithStudents
                .FindAsync(id);
            if (individualwordwithstudent == null)
            {
                throw new InvalidOperationException("Error geting IndividualWordWithStudent. IndividualWordWithStudent by id not found.");
            }
            individualwordwithstudent.Title = individualwordwithstudentDto.Title;
            individualwordwithstudent.Result = individualwordwithstudentDto.Result;
            individualwordwithstudent.Date = individualwordwithstudentDto.Date;
            individualwordwithstudent.StudentId = individualwordwithstudentDto.StudentId;
            try
            {
                _context.IndividualWordWithStudents.Update(individualwordwithstudent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating IndividualWordWithStudent.", ex);
            }
            individualwordwithstudentDto.Id = individualwordwithstudent.Id;
            return individualwordwithstudentDto;
        }
        public async Task DeleteAsync(int id)
        {
            IndividualWordWithStudent? individualwordwithstudent = await _context.IndividualWordWithStudents
                .FindAsync(id);
            if (individualwordwithstudent == null)
            {
                throw new InvalidOperationException("Error geting IndividualWordWithStudent. IndividualWordWithStudent by id not found.");
            }
            try
            {
                _context.IndividualWordWithStudents.Remove(individualwordwithstudent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting IndividualWordWithStudent.", ex);
            }
        }
    }
}
