
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class SpecificationService : ISpecificationService
    {
        private MentorJournalV02Context _context;

        public SpecificationService(MentorJournalV02Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpecificationDto>> GetAllAsync()
        {
            var spesifications = await _context.Specifications
                .ToListAsync();

            var specificationsDtos = spesifications
                .Select(s => new SpecificationDto
                {
                    Id = s.Id,
                    Direction = s.Direction,
                    Specialization = s.Specialization,
                    ReductionDirection = s.ReductionDirection,
                    ReductionSpecialization = s.ReductionSpecialization

                }).ToList();

            return specificationsDtos;
        }
        public async Task<SpecificationDto> GetByIdAsync(int id)
        {
            var specification = await _context.Specifications
                .FindAsync(id);

            if (specification == null)
            {
                throw new InvalidOperationException("Error geting Specification. Specification by id not found.");
            }

            var specificationDto = new SpecificationDto
            {
                Id = specification.Id,
                Direction = specification.Direction,
                Specialization = specification.Specialization,
                ReductionDirection = specification.ReductionDirection,
                ReductionSpecialization = specification.ReductionSpecialization
            };

            return specificationDto;
        }
        public async Task<SpecificationDto> CreateAsync(SpecificationDto specificationDto)
        {
            Specification specification = new Specification
            {
                Direction = specificationDto.Direction,
                Specialization = specificationDto.Specialization,
                ReductionDirection = specificationDto.ReductionDirection,
                ReductionSpecialization = specificationDto.ReductionSpecialization
            };
            try
            {
                _context.Specifications.Add(specification);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating Specification.", ex);
            }
            specificationDto.Id = specification.Id;
            return specificationDto;
        }
        public async Task<SpecificationDto> UpdateAsync(int id, SpecificationDto specificationDto)
        {
            Specification? specification = await _context.Specifications
                .FindAsync(id);
            if (specification == null)
            {
                throw new InvalidOperationException("Error geting Specification. Specification by id not found.");
            }
            try
            {
                _context.Specifications.Update(specification);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Specification.", ex);
            }
            specificationDto.Id = specification.Id;
            return specificationDto;
        }
        public async Task DeleteAsync(int id)
        {
            Specification? specification = await _context.Specifications
                .FindAsync(id);
            if (specification == null)
            {
                throw new InvalidOperationException("Error geting Specification. Specification by id not found.");
            }
            try
            {
                _context.Specifications.Remove(specification);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting Specification.", ex);
            }
        }
    }
}
