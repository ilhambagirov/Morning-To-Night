using M2N.Persistence.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace M2N.Application.Modules.TaskCategoryModule
{
    public class TaskCategoryDeleteCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class TaskCategoryDeleteCommandHandler : IRequestHandler<TaskCategoryDeleteCommand, int>
    {
        private readonly AppDbContext db;

        public TaskCategoryDeleteCommandHandler(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<int> Handle(TaskCategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var data = await db.TaskCategories.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (data == null) return 0;

            data.DeletedDate = System.DateTime.Now;
            await db.SaveChangesAsync();
            return 1;
        }
    }
}
