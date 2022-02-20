using AutoMapper;
using M2N.Application.DTOs;
using M2N.Persistence.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace M2N.Application.Modules.TaskModule
{
    public class TaskStageEditCommand : IRequest<int>
    {
        public int Id { get; set; }
        public TaskChangeStageDto TaskChangeStageDto { get; set; }
    }
    public class TaskStageEditCommandHandler : IRequestHandler<TaskStageEditCommand, int>
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public TaskStageEditCommandHandler(AppDbContext db,
            IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<int> Handle(TaskStageEditCommand request, CancellationToken cancellationToken)
        {
            var data = await db.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (data == null) return 0;

            mapper.Map(request.TaskChangeStageDto, data);
            await db.SaveChangesAsync();
            return 1;
        }
    }
}
