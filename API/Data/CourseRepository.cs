using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;

namespace API.Data
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public CourseRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<bool> AddCategory(Context Category)
        {
            this.context.Context.Add(Category);
            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddCourse(CourseDto courseDto)
        {
            this.context.Course.Add(this.mapper.Map<Course>(courseDto));
            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<Context> GetCategory(int id)
        {
            return await this.context.Context.FindAsync(id);
        }
    }
}