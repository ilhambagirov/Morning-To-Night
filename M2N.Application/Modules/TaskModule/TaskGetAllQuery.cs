using AutoMapper;
using M2N.Application.DSOs;
using M2N.Application.Extensions;
using M2N.Application.Infrastructor.Interfaces;
using M2N.Domain.Models;
using M2N.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
        private readonly IUserAccessor userAccessor;
        private readonly UserManager<AppUser> userManager;
        private readonly IActionContextAccessor ctx;

        public TaskGetAllQueryHandler(AppDbContext db,
            IMapper mapper,
            IUserAccessor userAccessor,
            UserManager<AppUser> userManager,
            IActionContextAccessor ctx)
        {
            this.db = db;
            this.mapper = mapper;
            this.userAccessor = userAccessor;
            this.userManager = userManager;
            this.ctx = ctx;
        }
        public async Task<List<TaskDso>> Handle(TaskGetAllQuery request, CancellationToken cancellationToken)
        {
            var userId = userManager.FindByEmailAsync(userAccessor.getEmail()).Result.Id;
            var taskCategoriesByUserId = await db.TaskCategories.Where(x => x.CreatedByUserId == userId && x.Id == request.TaskCategoryId).ToListAsync();
            if (taskCategoriesByUserId.Count == 0)
            {
                ctx.IsModelState().AddModelError("TaskCategory","No Such a task category found");
                return null;
            }
            return mapper.Map<List<TaskDso>>(await db.Tasks
               .Include(x => x.TaskCategory)
               .Include(x => x.Stage)
               .Where(x => x.DeletedDate == null &&
               x.TaskCategoryId == request.TaskCategoryId &&
               x.CreatedByUserId == userId)
               .ToListAsync());
        }
    }
}

