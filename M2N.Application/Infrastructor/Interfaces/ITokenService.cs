using M2N.Domain.Models;

namespace M2N.Application.Infrastructor.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user);
    }
}
