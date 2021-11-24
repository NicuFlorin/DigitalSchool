using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ISchoolRepository
    {
         Task<int> AddSchool(SchoolDto schoolDto);
         Task<School> GetSchool(int id);
         void DeleteSchool(int id);
         void Update(SchoolDto schoolDto);
         Task<bool> SaveAllAsync();
        Task<bool> Exists();
    }
}