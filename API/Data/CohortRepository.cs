using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Pagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CohortRepository : ICohortRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public CohortRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }


        public async Task<bool> AddCohort(Cohort cohort)
        {
            this.context.Cohort.Add(cohort);
            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CohortDto>> GetCohorts()
        {

            var query = this.context.Cohort.AsQueryable();
            var cohorts = await query
                .Include(c => c.Context).ProjectTo<CohortDto>(this.mapper.ConfigurationProvider).ToListAsync();


            return cohorts;


        }
    }
}