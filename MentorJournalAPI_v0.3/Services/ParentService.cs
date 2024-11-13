using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using System.Reflection.Metadata.Ecma335;

namespace MentorJournalAPI_v0._3.Services
{
public class ParentService : IParentService
    {

        private MentorJournalV02Context _context;

        public ParentService(MentorJournalV02Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParentDto>> GetAllAsync()
        {
            var parrents = await _context.Parents
                .ToListAsync();

            var parentDtos = parrents.Select(p => new ParentDto
            {
                Id = p.Id,
                Surname = p.Surname,
                Name = p.Name,
                Patronymic = p.Patronymic,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                StudentId = p.StudentId,
                DegreeOfKinshipId = p.DegreeOfKinshipId
            }).ToList();

            return parentDtos;
        }
        public async Task<ParentDto> GetByIdAsync(int id)
        {
            var parent = await _context.Parents
                .FindAsync(id);

            if (parent == null)
            {
                throw new InvalidOperationException("Error geting Parent. Parent by id not found.");
            }

            var parentDto = new ParentDto
            {
                Id = parent.Id,
                Surname = parent.Surname,
                Name = parent.Name,
                Patronymic = parent.Patronymic,
                PhoneNumber = parent.PhoneNumber,
                Email = parent.Email,
                StudentId = parent.StudentId,
                DegreeOfKinshipId = parent.DegreeOfKinshipId
            };

            return parentDto;
        }
        public async Task<ParentDto> CreateAsync(ParentDto parentDto)
        {
            Parent parent = new Parent
            {
                Surname = parentDto.Surname,
                Name = parentDto.Name,
                Patronymic = parentDto.Patronymic,
                PhoneNumber = parentDto.PhoneNumber,
                Email = parentDto.Email,
                StudentId = parentDto.StudentId,
                DegreeOfKinshipId = parentDto.DegreeOfKinshipId
            };

            try
            {
                await _context.Parents.AddAsync(parent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating Parent.", ex);
            }

            parentDto.Id = parent.Id;
            return parentDto;
        }
        public async Task<ParentDto> UpdateAsync(int id, ParentDto parentDto)
        {
            Parent? existingParent = await _context.Parents
                .FindAsync(id);
            if (existingParent == null)
            {
                throw new InvalidOperationException("Error geting Parent. Parent by id not found.");
            }
            existingParent.Surname = parentDto.Surname;
            existingParent.Name = parentDto.Name;
            existingParent.Patronymic = parentDto.Patronymic;
            existingParent.PhoneNumber = parentDto.PhoneNumber;
            existingParent.Email = parentDto.Email;
            existingParent.StudentId = parentDto.StudentId;
            existingParent.DegreeOfKinshipId = parentDto.DegreeOfKinshipId;

            try
            {
                _context.Parents.Update(existingParent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Parent.", ex);
            }

            parentDto.Id = existingParent.Id;
            return parentDto;
        }
        public async Task DeleteAsync(int id)
        {
            Parent? parent = await _context.Parents
                .FindAsync(id);
            if (parent == null)
            {
                throw new InvalidOperationException("Error geting Parent. Parent by id not found.");
            }
            try
            {
                _context.Parents.Remove(parent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting Parent.", ex);
            }
        }
    }
}
