using AutoMapper;
using M2N.Application.DTOs;
using M2N.Application.Infrastructor.Interfaces;
using M2N.Domain.Models;
using M2N.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly IUserAccessor userAccessor;
        private readonly UserManager<AppUser> userManager;

        public TaskCategoryCreateCommandHandler(AppDbContext db,
            IMapper mapper,
            IUserAccessor userAccessor,
            UserManager<AppUser> userManager)
        {
            this.db = db;
            this.mapper = mapper;
            this.userAccessor = userAccessor;
            this.userManager = userManager;
        }
        public async Task<Unit> Handle(TaskCategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var mappedTaskCategory = mapper.Map<TaskCategory>(request.TaskCategoryDto);
            mappedTaskCategory.CreatedByUserId = userManager.FindByEmailAsync(userAccessor.getEmail()).Result.Id;
            await db.TaskCategories.AddAsync(mappedTaskCategory);
            await db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
