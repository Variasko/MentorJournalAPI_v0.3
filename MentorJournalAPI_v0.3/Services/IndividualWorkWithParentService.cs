
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class IndividualWorkWithParentService : IIndividualWorkWithParentService
    {
        public MentorJournalV02Context _context;

        public IndividualWorkWithParentService(MentorJournalV02Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<IndividualWorkWithParentDto>> GetAllAsync()
        {
            var individualworkwithparents = await _context.IndividualWorkWithParents
                .ToListAsync();
            var individualworkwithparentDtos = individualworkwithparents.Select(i => new IndividualWorkWithParentDto
            {
                Id = i.Id,
                Title = i.Title,
                Result = i.Result,
                Date  = i.Date,
                ParentId = i.ParentId
            }).ToList();
            return individualworkwithparentDtos;
        }
        public async Task<IndividualWorkWithParentDto> GetByIdAsync(int id)
        {
            var individualworkwithparent = await _context.IndividualWorkWithParents
                .FindAsync(id);
            if (individualworkwithparent == null)
            {
                throw new InvalidOperationException("Error geting IndividualWorkWithParent. IndividualWorkWithParent by id not found.");
            }
            var individualworkwithparentDto = new IndividualWorkWithParentDto
            {
                Id = individualworkwithparent.Id,
                Title = individualworkwithparent.Title,
                Result = individualworkwithparent.Result,
                Date = individualworkwithparent.Date,
                ParentId = individualworkwithparent.ParentId
            };
            return individualworkwithparentDto;
        }
        public async Task<IndividualWorkWithParentDto> CreateAsync(IndividualWorkWithParentDto individualworkwithparentDto)
        {
            IndividualWorkWithParent newIndividualWorkWithParent = new IndividualWorkWithParent
            {
                Title = individualworkwithparentDto.Title,
                Result = individualworkwithparentDto.Result,
                Date = individualworkwithparentDto.Date,
                ParentId = individualworkwithparentDto.ParentId
            };
            try
            {
                await _context.IndividualWorkWithParents.AddAsync(newIndividualWorkWithParent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating IndividualWorkWithParent.", ex);
            }
            individualworkwithparentDto.Id = newIndividualWorkWithParent.Id;
            return individualworkwithparentDto;
        }
        public async Task<IndividualWorkWithParentDto> UpdateAsync(int id, IndividualWorkWithParentDto individualworkwithparentDto)
        {
            IndividualWorkWithParent? individualworkwithparent = await _context.IndividualWorkWithParents
                .FindAsync(id);
            if (individualworkwithparent == null)
            {
                throw new InvalidOperationException("Error geting IndividualWorkWithParent. IndividualWorkWithParent by id not found.");
            }
            individualworkwithparent.Title = individualworkwithparentDto.Title;
            individualworkwithparent.Result = individualworkwithparentDto.Result;
            individualworkwithparent.Date = individualworkwithparentDto.Date;
            individualworkwithparent.ParentId = individualworkwithparentDto.ParentId;
            try
            {
                _context.IndividualWorkWithParents.Update(individualworkwithparent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating IndividualWorkWithParent.", ex);
            }
            individualworkwithparentDto.Id = individualworkwithparent.Id;
            return individualworkwithparentDto;
        }
        public async Task DeleteAsync(int id)
        {
            IndividualWorkWithParent? individualworkwithparent = await _context.IndividualWorkWithParents
                .FindAsync(id);
            if (individualworkwithparent == null)
            {
                throw new InvalidOperationException("Error geting IndividualWorkWithParent. IndividualWorkWithParent by id not found.");
            }
            try
            {
                _context.IndividualWorkWithParents.Remove(individualworkwithparent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting IndividualWorkWithParent.", ex);
            }
        }
    }
}
