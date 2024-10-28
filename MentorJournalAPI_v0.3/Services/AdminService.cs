using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Services
{
public class AdminService : IAdminService
    {
        private readonly MentorJournalV02Context _context;

        public AdminService(MentorJournalV02Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdminDto>> GetAllAsync()
        {
            var admins = await _context.Admins
                .ToListAsync();

            var adminDtos = admins.Select(a => new AdminDto
            {
                PersonId = a.PersonId,
                Login = a.Login,
                Password = a.Password
            }).ToList();

            return adminDtos;
        }
        public async Task<AdminDto> GetByIdAsync(int id)
        {
            var admin = await _context.Admins
                .FindAsync(id);
            if (admin == null)
            {
                throw new InvalidOperationException("Error geting Admin. Admin by id not found.");
            }
            var adminDto = new AdminDto
            {
                PersonId = admin.PersonId,
                Login = admin.Login,
                Password = admin.Password
            };
            return adminDto;
        }
        public async Task<AdminDto> CreateAsync(AdminDto adminDto)
        {
            Admin admin = new Admin
            {
                Login = adminDto.Login,
                Password = adminDto.Password
            };

            try
            {
                await _context.Admins.AddAsync(admin);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating Admin.", ex);
            }

            adminDto.PersonId = admin.PersonId;
            return adminDto;

        }
        public async Task<AdminDto> UpdateAsync(int id, AdminDto adminDto)
        {
            var admin = await _context.Admins
                .FindAsync(id);
            if (admin == null)
            {
                throw new InvalidOperationException("Error geting Admin. Admin by id not found.");
            }

            admin.Login = adminDto.Login;
            admin.Password = adminDto.Password;

            try
            {
                _context.Admins.Update(admin);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Admin.", ex);
            }

            return adminDto;
        }
        public async Task DeleteAsync(int id)
        {
            var admin = await _context.Admins
                .FindAsync(id);
            if (admin == null)
            {
                throw new InvalidOperationException("Error geting Admin. Admin by id not found.");
            }

            try
            {
                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting Admin.", ex);
            }
        }

    }
}
