using M2N.Application.DTOs;
using M2N.Application.Infrastructor.Helpers;
using M2N.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace M2N.Application.Modules.AccountModule
{
    public class UserLoginCommand : IRequest<UserDto>
    {
        public LoginDto LoginDto { get; set; }
    }
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserDto>
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IActionContextAccessor ctx;

        public UserLoginCommandHandler(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
           IHttpContextAccessor httpContextAccessor,
           IActionContextAccessor ctx)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.ctx = ctx;
        }
        public async Task<UserDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.Users
                .FirstOrDefaultAsync(x => x.Email == request.LoginDto.Email);

            if (user == null) return null;

            var result = await signInManager.CheckPasswordSignInAsync(user, request.LoginDto.Password, false);

            if (result.Succeeded)
            {
                return user.CreateUserObjectModel(httpContextAccessor.HttpContext);
            }

            return null;
        }
    }
}
