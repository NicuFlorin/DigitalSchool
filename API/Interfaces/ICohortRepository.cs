using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Pagination;

namespace API.Interfaces
{
    public interface ICohortRepository
    {
        Task<bool> AddCohort(Cohort cohort);
        Task<IEnumerable<CohortDto>> GetCohorts();
    }
}