using AutoMapper;
using M2N.Application.DTOs;
using M2N.Application.Infrastructor.Interfaces;
using M2N.Domain.Models;
using M2N.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly IUserAccessor userAccessor;
        private readonly UserManager<AppUser> userManager;

        public TaskCreateCommandHandler(AppDbContext db,
            IMapper mapper,
            IUserAccessor userAccessor,
            UserManager<AppUser> userManager)
        {
            this.db = db;
            this.mapper = mapper;
            this.userAccessor = userAccessor;
            this.userManager = userManager;
        }
        public async Task<Unit> Handle(TaskCreateCommand request, CancellationToken cancellationToken)
        {
            var mappedTask = mapper.Map<AppTask>(request.Task);
            mappedTask.CreatedByUserId = userManager.FindByEmailAsync(userAccessor.getEmail()).Result.Id;
            await db.Tasks.AddAsync(mappedTask);
            await db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
