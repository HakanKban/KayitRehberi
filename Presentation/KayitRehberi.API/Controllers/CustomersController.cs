using KayitRehberi.Application.Features.Commands.Customer.CreateCustomer;
using KayitRehberi.Application.Features.Commands.Customer.RemoveCustomer;
using KayitRehberi.Application.Features.Commands.Customer.UpdateCustomer;
using KayitRehberi.Application.Features.Queries.Customer.GetAllCustomer;
using KayitRehberi.Application.Features.Queries.Customer.GetByIdCustomer;
using KayitRehberi.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KayitRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="admin,editor")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer([FromRoute] GetAllCustomerQueryRequest getAllCustomerQueryRequest)
        {
            return Ok(await _mediator.Send(getAllCustomerQueryRequest));
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CreateCustomerCommandRequest createCustomerCommandRequest)
        {
            return Ok(await _mediator.Send(createCustomerCommandRequest));
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdCustomerQueryRequest getByIdCustomerQueryRequest)
        {
            return Ok(await _mediator.Send(getByIdCustomerQueryRequest));
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCustomerCommandRequest updateCustomerCommandRequest)
        {
            return Ok(await _mediator.Send(updateCustomerCommandRequest));
        }

        [Authorize(Roles = "admin")]

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCustomerCommandRequest removeCustomerCommandRequest)
        {
            return Ok(await _mediator.Send(removeCustomerCommandRequest));  
        }


    }
}
