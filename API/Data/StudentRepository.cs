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
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public StudentRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        public async Task<bool> AssignStudents(List<StudentEnrollment> students)
        {


            this.context.StudentEnrollment.AddRange(students);
            return await this.context.SaveChangesAsync() > 0;

        }

        public async Task<IEnumerable<MemberDto>> GetPotentialUsers(int id_cohort)
        {
            var query = this.context.Users
                .Include(s => s.StudentEnrolements).Where(u => u.StudentEnrolements.All(s => s.CohortId != id_cohort));


            var users = await query.ProjectTo<MemberDto>(this.mapper.ConfigurationProvider).ToListAsync();
            return users;
        }

        public async Task<ICollection<StudentDto>> GetStudentEnrollmentsById(int id)
        {
            var query = this.context.StudentEnrollment.AsQueryable();
            var studEnrollments = await query.Where(stud => stud.AppUserId == id)
                        .ProjectTo<StudentDto>(this.mapper.ConfigurationProvider)
                        .ToListAsync();
            return studEnrollments;
        }

        public async Task<IEnumerable<StudentDto>> GetStudents(int id_cohort)
        {
            var query = this.context.StudentEnrollment.AsQueryable().Include(user => user.AppUser)
                .Where(s => s.CohortId == id_cohort);
            var students = await query.ProjectTo<StudentDto>(this.mapper.ConfigurationProvider).ToListAsync();

            return students;

        }

        public async Task<bool> RemoveStudents(List<StudentEnrollment> students)
        {
            this.context.StudentEnrollment.RemoveRange(students);
            return await this.context.SaveChangesAsync() > 0;

        }
        public async Task<StudentDto> IsAuthorizedToOpenQuiz(int id_user, int id_quiz)
        {
            var quiz = await this.context.Quiz.SingleOrDefaultAsync(q => q.Id == id_quiz);
            if (quiz == null) return null;
            var user_enrollment = await this.context.StudentEnrollment
                                    .SingleOrDefaultAsync(s => s.AppUserId == id_user && s.CohortId == quiz.Course.CohortId);

            if (user_enrollment == null)
            {
                return null;
            }
            return this.mapper.Map<StudentDto>(user_enrollment);
        }
    }
}