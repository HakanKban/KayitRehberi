using KayitRehberi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Application.Features.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        readonly ICustomerWriteRepository _customerWriteRepository;

        public CreateCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            await _customerWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                SurName = request.SurName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,

            });
            await _customerWriteRepository.SaveAsync();
            return new CreateCustomerCommandResponse();
        }
    }
}
