using KayitRehberi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = KayitRehberi.Domain.Entities;

namespace KayitRehberi.Application.Features.Commands.CommercialActivity.UpdateCommercialActivity
{
    public class UpdateCommercialActivityHandler : IRequestHandler<UpdateCommercialActivityRequest, UpdateCommercialActivityResponse>
    {

        readonly ICommercialActivityReadRepository _commercialActivityReadRepository;
        readonly ICommercialActivityWriteRepository _commercialActivityWriteRepository;

        public UpdateCommercialActivityHandler(ICommercialActivityReadRepository commercialActivityReadRepository, ICommercialActivityWriteRepository commercialActivityWriteRepository)
        {
            _commercialActivityReadRepository = commercialActivityReadRepository;
            _commercialActivityWriteRepository = commercialActivityWriteRepository;
        }

        public async Task<UpdateCommercialActivityResponse> Handle(UpdateCommercialActivityRequest request, CancellationToken cancellationToken)
        {
            C.CommercialActivity commercialActivity = await _commercialActivityReadRepository.GetByIdAsync(request.Id);
            commercialActivity.ServiceCharge = request.ServiceCharge;
            commercialActivity.ServiceDate = request.ServiceDate;
            commercialActivity.ServiceName = request.ServiceName;
            commercialActivity.CustomerId = request.CustomerId;
            await _commercialActivityWriteRepository.SaveAsync();
            return new();
        }
    }
}
