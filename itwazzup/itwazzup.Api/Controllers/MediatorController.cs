using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace itwazzup.Api.Controllers
{
    [ApiController]
    public abstract class MediatorController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator
        {
            get
            {
                return _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
            }
        }
    }
}