using KayitRehberi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Application.Features.Commands.Customer.RemoveCustomer
{
    public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommandRequest, RemoveCustomerCommandResponse>
    {
        readonly ICustomerWriteRepository _customerWriteRepository;

        public RemoveCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<RemoveCustomerCommandResponse> Handle(RemoveCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            await _customerWriteRepository.RemoveAsync(request.Id);
            await _customerWriteRepository.SaveAsync();
            return new ();
        }
    }
}
