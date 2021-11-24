using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public SchoolRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<int> AddSchool(SchoolDto schoolDto)
        {
            var school = new School
            {
                Name = schoolDto.Name
            };
            await this.context.School.AddAsync(school);
            try
            {
                await this.context.SaveChangesAsync();
                return school.Id;
            }
            catch (Exception e)
            {
                return -1;
            }

        }

        public async void DeleteSchool(int id)
        {
            this.context.School.Remove(this.context.School.FirstOrDefault(school => school.Id == id));
            await this.context.SaveChangesAsync();
        }

        public Task<bool> Exists()
        {
            return this.context.School.AnyAsync();
        }

        public async Task<School> GetSchool(int id)
        {
            return await this.context.School.FindAsync(id);
            
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(SchoolDto schoolDto)
        {
            throw new NotImplementedException();
        }
    }
}