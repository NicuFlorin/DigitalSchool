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
    public class ContextRepository : IContextRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public ContextRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<IEnumerable<ContextDto>> GetContexts()
        {
            var query = this.context.Context.AsQueryable();
            var contexts = await this.context.Context
                    .Where(context => context.ParentId == null)
                    .ProjectTo<ContextDto>(this.mapper.ConfigurationProvider).ToListAsync();

            foreach (ContextDto context in contexts)
            {
                context.SubCategory = await GetChilds(context);
            }
            return contexts;
        }

        private async Task<List<ContextDto>> GetChilds(ContextDto contextDto)
        {
            if (contextDto == null)
            {
                return null;
            }
            var query = this.context.Context.AsQueryable();
            var contexts = await this.context.Context
                    .Where(context => context.ParentId == contextDto.Id)
                    .ProjectTo<ContextDto>(this.mapper.ConfigurationProvider).ToListAsync();
            foreach (ContextDto context in contexts)
            {
                context.SubCategory = new List<ContextDto>();
                context.Name = contextDto.Name + "/" + context.Name;
                context.SubCategory.AddRange(await GetChilds(context));
            }
            return contexts;
        }
    }
}