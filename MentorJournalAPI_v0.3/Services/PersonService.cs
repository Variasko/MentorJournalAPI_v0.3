
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MentorJournalAPI_v0._3.Services
{
public class PersonService : IPersonService
    {

        private MentorJournalV02Context _context;

        public PersonService(MentorJournalV02Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync()
        {
            var persons = await _context.People
                .ToListAsync();
            var personDtos = persons
                .Select(p => new PersonDto
                {
                    Id = p.Id,
                    Photo = p.Photo,
                    Surname = p.Surname,
                    Name = p.Name,
                    Patronymic = p.Patronymic,
                    Gender = p.Gender,
                    Bithday = p.Bithday,
                    PassportSeial = p.PassportSeial,
                    PassportNumber = p.PassportNumber,
                    Snils = p.Snils,
                    Inn = p.Inn,
                    PhoneNumber = p.PhoneNumber,
                    RegistrationAddress = p.RegistrationAddress,
                    LivingAddress = p.LivingAddress
                }).ToList();
            return personDtos;
        }
        public async Task<PersonDto> GetByIdAsync(int id)
        {
            var person = await _context.People
                .FindAsync(id);
            if (person == null)
            {
                throw new InvalidOperationException("Error geting Person. Person by id not found.");
            }
            var personDto = new PersonDto
            {
                Id = person.Id,
                Photo = person.Photo,
                Surname = person.Surname,
                Name = person.Name,
                Patronymic = person.Patronymic,
                Gender = person.Gender,
                Bithday = person.Bithday,
                PassportSeial = person.PassportSeial,
                PassportNumber = person.PassportNumber,
                Snils = person.Snils,
                Inn = person.Inn,
                PhoneNumber = person.PhoneNumber,
                RegistrationAddress = person.RegistrationAddress,
                LivingAddress = person.LivingAddress
            };
            return personDto;
        }
        public async Task<PersonDto> CreateAsync(PersonDto personDto)
        {
            Person person = new Person
            {
                Photo = personDto.Photo,
                Surname = personDto.Surname,
                Name = personDto.Name,
                Patronymic = personDto.Patronymic,
                Gender = personDto.Gender,
                Bithday = personDto.Bithday,
                PassportSeial = personDto.PassportSeial,
                PassportNumber = personDto.PassportNumber,
                Snils = personDto.Snils,
                Inn = personDto.Inn,
                PhoneNumber = personDto.PhoneNumber,
                RegistrationAddress = personDto.RegistrationAddress,
                LivingAddress = personDto.LivingAddress
            };
            try
            {
                await _context.People.AddAsync(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating Person.", ex);
            }
            personDto.Id = person.Id;
            return personDto;
        }
        public async Task<PersonDto> UpdateAsync(int id, PersonDto personDto)
        {
            Person? existingPerson = await _context.People
                .FindAsync(id);
            if (existingPerson == null)
            {
                throw new InvalidOperationException("Error geting Person. Person by id not found.");
            }
            existingPerson.Photo = personDto.Photo;
            existingPerson.Surname = personDto.Surname;
            existingPerson.Name = personDto.Name;
            existingPerson.Patronymic = personDto.Patronymic;
            existingPerson.Gender = personDto.Gender;
            existingPerson.Bithday = personDto.Bithday;
            existingPerson.PassportSeial = personDto.PassportSeial;
            existingPerson.PassportNumber = personDto.PassportNumber;
            existingPerson.Snils = personDto.Snils;
            existingPerson.Inn = personDto.Inn;
            existingPerson.PhoneNumber = personDto.PhoneNumber;
            existingPerson.RegistrationAddress = personDto.RegistrationAddress;
            existingPerson.LivingAddress = personDto.LivingAddress;
            try
            {
                _context.People.Update(existingPerson);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating Person.", ex);
            }
            personDto.Id = existingPerson.Id;
            return personDto;
        }
        public async Task DeleteAsync(int id)
        {
            Person? person = await _context.People
                .FindAsync(id);
            if (person == null)
            {
                throw new InvalidOperationException("Error geting Person. Person by id not found.");
            }
            try
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting Person.", ex);
            }
        }
    }
}
