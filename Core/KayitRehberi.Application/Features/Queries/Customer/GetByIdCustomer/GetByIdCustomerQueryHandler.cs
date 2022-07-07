using KayitRehberi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = KayitRehberi.Domain.Entities;

namespace KayitRehberi.Application.Features.Queries.Customer.GetByIdCustomer
{
    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public GetByIdCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<GetByIdCustomerQueryResponse> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            C.Customer customer = await _customerReadRepository.GetByIdAsync(request.Id, false);
            return new GetByIdCustomerQueryResponse()
            {
                Name = customer.Name,
                SurName = customer.SurName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Photo = customer.Photo,
                City = customer.City
            };
        }
    }
}
