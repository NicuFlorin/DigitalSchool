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
        Task<CourseDto> GetCourseById(int id);
        Task<IEnumerable<CourseDto>> GetAllForAdmin();
        Task<IEnumerable<CourseDto>> GetAllForTeacher(int id_teacher);
        Task<IEnumerable<CourseDto>> GetAllForStudent(int id_student);
    
    }
}