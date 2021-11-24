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
    }
}