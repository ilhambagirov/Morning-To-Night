using AutoMapper;
using M2N.Application.DSOs;
using M2N.Persistence.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace M2N.Application.Modules.TaskModule
{
    public class TaskGetAllQuery : IRequest<List<TaskDso>>
    {
        public int TaskCategoryId { get; set; }
    }

    public class TaskGetAllQueryHandler : IRequestHandler<TaskGetAllQuery, List<TaskDso>>
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public TaskGetAllQueryHandler(AppDbContext db,
            IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<List<TaskDso>> Handle(TaskGetAllQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<TaskDso>>(await db.Tasks
               .Include(x => x.TaskCategory)
               .Include(x => x.Stage)
               .Where(x=>x.DeletedDate == null && x.TaskCategoryId == request.TaskCategoryId)
               .ToListAsync());
        }
    }
}

