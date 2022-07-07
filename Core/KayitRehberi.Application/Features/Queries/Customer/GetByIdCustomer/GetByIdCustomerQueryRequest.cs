using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Application.Features.Queries.Customer.GetByIdCustomer
{
    public class GetByIdCustomerQueryRequest : IRequest<GetByIdCustomerQueryResponse>
    {
        public int Id { get; set; }
    }
}
