using AutoMapper;
using M2N.Application.DTOs;
using M2N.Domain.Models;
using M2N.Persistence.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace M2N.Application.Modules.TaskCategoryModule
{
    public class TaskCategoryCreateCommand : IRequest<Unit>
    {
        public TaskCategoryDto TaskCategoryDto { get; set; }
    }
    public class TaskCategoryCreateCommandHandler : IRequestHandler<TaskCategoryCreateCommand, Unit>
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public TaskCategoryCreateCommandHandler(AppDbContext db,
            IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(TaskCategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var mappedTaskCategory = mapper.Map<TaskCategory>(request.TaskCategoryDto);
            await db.TaskCategories.AddAsync(mappedTaskCategory);
            await db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
