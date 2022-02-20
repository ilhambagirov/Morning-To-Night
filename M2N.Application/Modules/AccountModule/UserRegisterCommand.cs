using M2N.Application.DTOs;
using M2N.Application.Extensions;
using M2N.Application.Infrastructor.Helpers;
using M2N.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace M2N.Application.Modules.AccountModule
{
    public class UserRegisterCommand : IRequest<UserDto>
    {
        public RegisterDto RegisterDtoProperty { get; set; }
    }
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, UserDto>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IActionContextAccessor ctx;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserRegisterCommandHandler(UserManager<AppUser> userManager,
             IActionContextAccessor ctx,
              IHttpContextAccessor httpContextAccessor
            )
        {
            this.userManager = userManager;
            this.ctx = ctx;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<UserDto> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            if (userManager.FindByEmailAsync(request.RegisterDtoProperty.Email).Result != null)
            {
                ctx.IsModelState().AddModelError("Email", "Email Taken!");
                return null;
            }

            if (userManager.FindByNameAsync(request.RegisterDtoProperty.Username).Result != null)
            {
                ctx.IsModelState().AddModelError("Username", "Username Taken!");
                return null;
            }
            if (request.RegisterDtoProperty.Password != request.RegisterDtoProperty.PasswordConfirm)
            {
                ctx.IsModelState().AddModelError("Password", "Passwords are not same!");
                return null;
            }

            var user = new AppUser
            {
                UserName = request.RegisterDtoProperty.Username,
                Email = request.RegisterDtoProperty.Email
            };

            var result = await userManager.CreateAsync(user, request.RegisterDtoProperty.Password);

            if (!result.Succeeded)
            {
                ctx.IsModelState().AddModelError("Register", "Problem while registering. Please, try later!");
                return null;
            }

            return user.CreateUserObjectModel(httpContextAccessor.HttpContext);
        }
    }
}
