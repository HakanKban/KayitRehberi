using KayitRehberi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = KayitRehberi.Domain.Entities;

namespace KayitRehberi.Application.Features.Queries.CommercialActivity.GetByIdCommercialActivity
{
    public class GetByIdCommercialActivityHandler : IRequestHandler<GetByIdCommercialActivityRequest, GetByIdCommercialActivityResponse>
    {
        readonly ICommercialActivityReadRepository _commercialActivityReadRepository;

        public GetByIdCommercialActivityHandler(ICommercialActivityReadRepository commercialActivityReadRepository)
        {
            _commercialActivityReadRepository = commercialActivityReadRepository;
        }

        public async Task<GetByIdCommercialActivityResponse> Handle(GetByIdCommercialActivityRequest request, CancellationToken cancellationToken)
        {
            C.CommercialActivity commercialActivity = await _commercialActivityReadRepository.GetByIdAsync(request.Id,false);
            return new GetByIdCommercialActivityResponse()
            {
                ServiceCharge = commercialActivity.ServiceCharge,
                ServiceName = commercialActivity.ServiceName
            };

        }
    }
}
