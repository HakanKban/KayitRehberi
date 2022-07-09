using KayitRehberi.Application.Features.Commands.AppRole.RoleAssignments;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KayitRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
       readonly IMediator mediator;

        public RolesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CreateRole([FromRoute] RoleAssignmentsCommandRequest roleAssignmentsCommandRequest)
        {
           
            return Ok(await mediator.Send(roleAssignmentsCommandRequest));
        }
    }
}
