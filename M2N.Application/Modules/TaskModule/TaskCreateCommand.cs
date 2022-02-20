using AutoMapper;
using M2N.Application.DTOs;
using M2N.Domain.Models;
using M2N.Persistence.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace M2N.Application.Modules.TaskModule
{
    public class TaskCreateCommand : IRequest<Unit>
    {
        public TaskDto Task { get; set; }
    }

    public class TaskCreateCommandHandler : IRequestHandler<TaskCreateCommand, Unit>
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public TaskCreateCommandHandler(AppDbContext db,
            IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(TaskCreateCommand request, CancellationToken cancellationToken)
        {
            var mappedTask = mapper.Map<AppTask>(request.Task);
            await db.Tasks.AddAsync(mappedTask);
            await db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
