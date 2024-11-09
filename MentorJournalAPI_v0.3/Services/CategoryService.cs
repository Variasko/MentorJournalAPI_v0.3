
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class CategoryService : ICategoryService
    {
        public MentorJournalV02Context _context;

        public CategoryService(MentorJournalV02Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories
                .ToListAsync();
            var categoriesDto = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return categoriesDto;
        }
        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _context.Categories
                .FindAsync(id);
            if (category == null)
            {
                throw new InvalidOperationException("Error geting Category. Category by id not found.");
            }
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
            return categoryDto;
        }
        public async Task<CategoryDto> CreateAsync(CategoryDto categoryDto)
        {
            Category newCategory = new Category
            {
                Name = categoryDto.Name
            };
            try
            {
                await _context.Categories.AddAsync(newCategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating Category.", ex);
            }
            categoryDto.Id = newCategory.Id;
            return categoryDto;
        }
        public async Task<CategoryDto> UpdateAsync(int id, CategoryDto categoryDto)
        {
            Category? category = await _context.Categories
                .FindAsync(id);
            if (category == null)
            {
                throw new InvalidOperationException("Error geting Category. Category by id not found.");
            }
            category.Name = categoryDto.Name;
            try
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Category.", ex);
            }
            categoryDto.Id = category.Id;
            return categoryDto;
        }
        public async Task DeleteAsync(int id)
        {
            Category? category = await _context.Categories
                .FindAsync(id);
            if (category == null)
            {
                throw new InvalidOperationException("Error geting Category. Category by id not found.");
            }
            try
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting Category.", ex);
            }
        }
    }
}
