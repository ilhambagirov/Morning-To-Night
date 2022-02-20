using AutoMapper;
using M2N.Application.DTOs;
using M2N.Persistence.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace M2N.Application.Modules.TaskCategoryModule
{
    public class TaskCategoryEditCommand : IRequest<int>
    {
        public int Id { get; set; }
        public TaskCategoryDto TaskCategoryDto { get; set; }
    }

    public class TaskCategoryEditCommandHandler : IRequestHandler<TaskCategoryEditCommand, int>
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public TaskCategoryEditCommandHandler(AppDbContext db,
            IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<int> Handle(TaskCategoryEditCommand request, CancellationToken cancellationToken)
        {
            var data = await db.TaskCategories.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (data == null) return 0;

            var mappedTask = mapper.Map(request.TaskCategoryDto, data);
            data.UpdatedDate = System.DateTime.Now;
            await db.SaveChangesAsync();
            return 1;
        }
    }
}
