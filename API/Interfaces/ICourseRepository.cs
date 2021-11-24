using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICourseRepository
    {
        Task<bool> AddCategory(Context Category);
        Task<bool> AddCourse(CourseDto course);
        Task<Context> GetCategory(int id);
    }
}