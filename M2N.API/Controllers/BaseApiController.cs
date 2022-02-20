using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace M2N.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator Mediator;
        protected IMediator mediatr => Mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
