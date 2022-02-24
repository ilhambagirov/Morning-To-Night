using M2N.Application.Infrastructor.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace M2N.Application.Services
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor httpAccessor;

        public UserAccessor(IHttpContextAccessor httpAccessor)
        {
            this.httpAccessor = httpAccessor;
        }
        public string getEmail()
        {
            return httpAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
        }
    }
}
