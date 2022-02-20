using M2N.Persistence.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace M2N.Application.Modules.TaskModule
{
    public class TaskDeleteCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class TaskDeleteCommandHandler : IRequestHandler<TaskDeleteCommand, int>
    {
        private readonly AppDbContext db;

        public TaskDeleteCommandHandler(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<int> Handle(TaskDeleteCommand request, CancellationToken cancellationToken)
        {
            var data = await db.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (data == null) return 0;

            data.DeletedDate = System.DateTime.Now;
            await db.SaveChangesAsync();
            return 1;
        }
    }
}
