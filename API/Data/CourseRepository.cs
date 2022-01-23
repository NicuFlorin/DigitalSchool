using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly IStorageService storageService;
        public CourseRepository(DataContext context, IMapper mapper, IStorageService storageService)
        {
            this.storageService = storageService;
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

            var course = this.context.Course.Add(this.mapper.Map<Course>(courseDto));
            course.Entity.Sections = new List<Section>();

            if (!courseDto.isWeekFormat)
            {
                for (int i = 0; i < courseDto.NoOfSections; i++)
                {
                    course.Entity.Sections.Add(new Section { Title = "Topic " + courseDto.NoOfSections + 1 });
                }
            }
            else
            {
                AddWeeks(course.Entity.Sections, courseDto.NoOfSections, courseDto.DateStart, courseDto.DateFinal);
            }



            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<Context> GetCategory(int id)
        {
            return await this.context.Context.FindAsync(id);
        }

        private static void AddWeeks(ICollection<Section> sections, int nr_sections, DateTime start_date, DateTime final_date)
        {


            int daysAfterMonday = (int)start_date.DayOfWeek - (int)DayOfWeek.Monday;
            DateTime monday = start_date.AddDays(-daysAfterMonday);
            DateTime sunday = monday.AddDays(6);


            for (int i = 0; i < nr_sections; i++)
            {
                sections.Add(new Section
                {
                    Title = monday.ToShortDateString() + " - " + sunday.ToShortDateString(),
                    WeekStart = monday,
                    WeekEnd = sunday
                });
                monday = monday.AddDays(7);
                sunday = sunday.AddDays(7);
            }



        }

        public async Task<CourseDto> GetCourseById(int id)
        {
            

            return await this.context.Course
                .Include(r => r.Uploads)
                .Include(s => s.Sections)
                .ThenInclude(s=>s.Uploads)

                .ProjectTo<CourseDto>(this.mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(c => c.Id == id);

        }

        public async Task<IEnumerable<CourseDto>> GetAllForAdmin()
        {
            var query = this.context.Course.AsQueryable();
            var courses = await query.ProjectTo<CourseDto>(this.mapper.ConfigurationProvider)
                        .ToListAsync();

            return courses;
        }

        public async Task<IEnumerable<CourseDto>> GetAllForTeacher(int id_teacher)
        {
            var query = this.context.Course.AsQueryable();
            var courses = await query.Where(c => c.TeacherId == id_teacher)
                                .ProjectTo<CourseDto>(this.mapper.ConfigurationProvider)
                                .ToListAsync();

            return courses;
        }

        public async Task<IEnumerable<CourseDto>> GetAllForStudent(int id_student)
        {
            var query = this.context.Course.AsQueryable();
            var courses = await query.Where(c => c.Cohort.Students.Any(s => s.AppUserId == id_student))
                                     .ProjectTo<CourseDto>(this.mapper.ConfigurationProvider)
                                     .ToListAsync();
            return courses;

        }
    }
}