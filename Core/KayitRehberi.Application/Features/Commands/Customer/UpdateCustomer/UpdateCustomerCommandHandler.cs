using KayitRehberi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Application.Features.Commands.Customer.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {
        readonly ICustomerReadRepository _customerReadRepository;
        readonly ICustomerWriteRepository _customerWriteRepository;

        public UpdateCustomerCommandHandler(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer customer = await _customerReadRepository.GetByIdAsync(request.Id);
            customer.Name = request.Name;
            customer.Email = request.Email;
            customer.SurName = request.SurName;
            customer.PhoneNumber = request.PhoneNumber;
            await _customerWriteRepository.SaveAsync();
            return new UpdateCustomerCommandResponse();
        }
    }
}
