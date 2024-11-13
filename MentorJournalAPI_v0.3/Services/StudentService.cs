using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class StudentService : IStudentService
    {

        private MentorJournalV02Context _context;

        public StudentService(MentorJournalV02Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _context.Students
                .ToListAsync();

            var studentDtos = students
                .Select(s => new StudentDto
                {
                    PersonId = s.PersonId,
                    IsRemoved = s.IsRemoved,
                    RemovingDate = s.RemovingDate
                }).ToList();

            return studentDtos;
        }
        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var student = await _context.Students
                .FindAsync(id);

            if (student == null)
            {
                throw new InvalidOperationException("Error geting Student. Student by id not found.");
            }

            var studentDto = new StudentDto
            {
                PersonId = student.PersonId,
                IsRemoved = student.IsRemoved,
                RemovingDate = student.RemovingDate
            };

            return studentDto;
        }
        public async Task<StudentDto> CreateAsync(StudentDto studentDto)
        {
            Student student = new Student
            {
                IsRemoved = studentDto.IsRemoved,
                RemovingDate = studentDto.RemovingDate
            };

            try
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating Student.", ex);
            }

            return studentDto;
        }
        public async Task<StudentDto> UpdateAsync(int id, StudentDto studentDto)
        {
            Student? student = await _context.Students
                .FindAsync(id);

            if (student == null)
            {
                throw new InvalidOperationException("Error geting Student. Student by id not found.");
            }

            student.IsRemoved = studentDto.IsRemoved;
            student.RemovingDate = studentDto.RemovingDate;

            try
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Student.", ex);
            }
            studentDto.PersonId = student.PersonId;
            return studentDto;

        }
        public async Task DeleteAsync(int id)
        {
            Student? student = await _context.Students
                .FindAsync(id);

            if (student == null)
            {
                throw new InvalidOperationException("Error geting Student. Student by id not found.");
            }

            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting Student.", ex);
            }
        }
    }
}
