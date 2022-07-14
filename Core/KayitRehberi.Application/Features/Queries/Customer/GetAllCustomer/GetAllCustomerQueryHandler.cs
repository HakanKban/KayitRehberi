using KayitRehberi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = KayitRehberi.Domain.Entities;

namespace KayitRehberi.Application.Features.Queries.Customer.GetAllCustomer
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQueryRequest, GetAllCustomerQueryResponse>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public GetAllCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }



        public async Task<GetAllCustomerQueryResponse> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
        {

            var customers = _customerReadRepository.GetAll(false).Select(p => new
            {
            
                p.Id,
                p.Name,
                p.SurName,
                p.PhoneNumber,
                p.City,
                p.UpdatedDate
               
            }).ToList();
            return new GetAllCustomerQueryResponse()
            {
                Customers = customers
            };

        }
    }
}
