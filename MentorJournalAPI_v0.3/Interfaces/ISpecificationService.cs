
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;

namespace MentorJournalAPI_v0._3.Interfaces
{
    public interface ISpecificationService
    {
        Task<IEnumerable<SpecificationDto>> GetAllAsync();
        Task<SpecificationDto> GetByIdAsync(int id);
        Task<SpecificationDto> CreateAsync(SpecificationDto specificationDto);
        Task<SpecificationDto> UpdateAsync(int id, SpecificationDto specificationDto);
        Task DeleteAsync(int id);
    }
}
