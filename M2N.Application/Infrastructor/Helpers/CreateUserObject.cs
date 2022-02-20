using M2N.Application.DTOs;
using M2N.Application.Infrastructor.Interfaces;
using M2N.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace M2N.Application.Infrastructor.Helpers
{
    public static class CreateUserObject
    {
        public static UserDto CreateUserObjectModel(this AppUser user, HttpContext context)
        {
            using (var scope = context.RequestServices.CreateScope())
            {
                var ts = scope.ServiceProvider.GetRequiredService<ITokenService>();

                return new UserDto
                {
                    Username = user.UserName,
                    Token = ts.CreateToken(user),
                    Email = user.Email
                };
            }

        }
    }
}
