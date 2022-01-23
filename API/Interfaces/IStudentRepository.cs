using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDto>> GetStudents(int id_cohort);
        Task<ICollection<StudentDto>> GetStudentEnrollmentsById(int id);
        Task<IEnumerable<MemberDto>> GetPotentialUsers(int id_cohort);
        Task<bool> AssignStudents(List<StudentEnrollment> students);

        Task<bool> RemoveStudents(List<StudentEnrollment> students);
        Task<StudentDto> IsAuthorizedToOpenQuiz(int id_user, int id_quiz);
    }
}