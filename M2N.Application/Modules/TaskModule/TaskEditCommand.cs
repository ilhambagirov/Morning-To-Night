using AutoMapper;
using M2N.Application.DTOs;
using M2N.Persistence.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace M2N.Application.Modules.TaskModule
{
    public class TaskEditCommand : IRequest<int>
    {
        public int Id { get; set; }
        public TaskEditDto TaskEditDto { get; set; }
    }
    public class TaskEditCommandHandler : IRequestHandler<TaskEditCommand, int>
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public TaskEditCommandHandler(AppDbContext db,
            IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<int> Handle(TaskEditCommand request, CancellationToken cancellationToken)
        {
            var data = await db.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (data == null) return 0;

            var mappedTask = mapper.Map(request.TaskEditDto, data);
            data.UpdatedDate = System.DateTime.Now;
            await db.SaveChangesAsync();
            return 1;
        }
    }
}

