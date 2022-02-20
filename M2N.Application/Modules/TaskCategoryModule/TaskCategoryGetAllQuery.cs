using AutoMapper;
using M2N.Application.DSOs;
using M2N.Application.DTOs;
using M2N.Persistence.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace M2N.Application.Modules.TaskCategoryModule
{
    public class TaskCategoryGetAllQuery : IRequest<List<TaskCategoryDso>>
    {
    }

    public class TaskCategoryGetAllQueryHandler : IRequestHandler<TaskCategoryGetAllQuery, List<TaskCategoryDso>>
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public TaskCategoryGetAllQueryHandler(AppDbContext db,
            IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<List<TaskCategoryDso>> Handle(TaskCategoryGetAllQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<TaskCategoryDso>>(await db.TaskCategories
               .Where(x => x.DeletedDate == null)
               .ToListAsync());
        }
    }
}
