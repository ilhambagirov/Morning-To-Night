using AutoMapper;
using M2N.Application.DSOs;
using M2N.Application.DTOs;
using M2N.Application.Infrastructor.Interfaces;
using M2N.Domain.Models;
using M2N.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace M2N.Application.Modules.TaskCategoryModule
{
    public class TaskCategoryGetAllQuery : IRequest<List<TaskCategoryDso>>
    {
    }

    public class TaskCategoryGetAllQueryHandler : IRequestHandler<TaskCategoryGetAllQuery, List<TaskCategoryDso>>
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;
        private readonly IUserAccessor userAccessor;
        private readonly UserManager<AppUser> userManager;

        public TaskCategoryGetAllQueryHandler(AppDbContext db,
            IMapper mapper,
            IUserAccessor userAccessor,
            UserManager<AppUser> userManager)
        {
            this.db = db;
            this.mapper = mapper;
            this.userAccessor = userAccessor;
            this.userManager = userManager;
        }
        public async Task<List<TaskCategoryDso>> Handle(TaskCategoryGetAllQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<TaskCategoryDso>>(await db.TaskCategories
               .Where(x => x.DeletedDate == null && x.CreatedByUserId == userManager
               .FindByEmailAsync(userAccessor.getEmail()).Result.Id)
               .ToListAsync());
        }
    }
}
