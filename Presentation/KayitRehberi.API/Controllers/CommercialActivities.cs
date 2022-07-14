using KayitRehberi.Application.Features.Commands.CommercialActivity.CreateCommercialActivity;
using KayitRehberi.Application.Features.Commands.CommercialActivity.RemoveCommercialActivity;
using KayitRehberi.Application.Features.Commands.CommercialActivity.UpdateCommercialActivity;
using KayitRehberi.Application.Features.Queries.CommercialActivity.GetByIdCommercialActivity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KayitRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="admin,editor")]
    public class CommercialActivities : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommercialActivities(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CreateCommercialActivityCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdCommercialActivityRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCommercialActivityRequest request )
        {
            return Ok(await _mediator.Send(request));
        }

        [Authorize(Roles = "admin")]

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCommercialActivityCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }



    }
}
