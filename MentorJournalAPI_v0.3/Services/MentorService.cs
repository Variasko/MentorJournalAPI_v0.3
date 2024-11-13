
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class MentorService : IMentorService
    {
        public MentorJournalV02Context _context;

        public MentorService(MentorJournalV02Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MentorDto>> GetAllAsync()
        {
            var mentors = await _context.Mentors
                .ToListAsync();

            var mentorDtos = mentors.Select(m => new MentorDto
            {
                PersonId = m.PersonId,
                CategoryId = m.CategoryId,
                Login = m.Login,
                Password = m.Password
            }).ToList();

            return mentorDtos;
        }
        public async Task<MentorDto> GetByIdAsync(int id)
        {
            var mentor = await _context.Mentors
                .FindAsync(id);

            if (mentor == null)
            {
                throw new InvalidOperationException("Error geting Mentor. Mentor by id not found.");
            }

            var mentorDto = new MentorDto
            {
                PersonId = mentor.PersonId,
                CategoryId = mentor.CategoryId,
                Login = mentor.Login,
                Password = mentor.Password
            };

            return mentorDto;
        }
        public async Task<MentorDto> CreateAsync(MentorDto mentorDto)
        {
            Mentor mentor = new Mentor
            {
                CategoryId = mentorDto.CategoryId,
                Login = mentorDto.Login,
                Password = mentorDto.Password
            };

            try
            {
                await _context.Mentors.AddAsync(mentor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating Mentor.", ex);
            }

            mentorDto.PersonId = mentor.PersonId;
            return mentorDto;
        }
        public async Task<MentorDto> UpdateAsync(int id, MentorDto mentorDto)
        {
            Mentor? mentor = await _context.Mentors
                .FindAsync(id);
            if (mentor == null)
            {
                throw new InvalidOperationException("Error geting Mentor. Mentor by id not found.");
            }
            try
            {
                _context.Mentors.Update(mentor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Mentor.", ex);
            }

            mentorDto.PersonId = mentor.PersonId;
            return mentorDto;
        }
        public async Task DeleteAsync(int id)
        {
            Mentor? mentor = await _context.Mentors
                .FindAsync(id);
            if (mentor == null)
            {
                throw new InvalidOperationException("Error geting Mentor. Mentor by id not found.");
            }
            try
            {
                _context.Mentors.Remove(mentor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting Mentor.", ex);
            }
        }
    }
}
