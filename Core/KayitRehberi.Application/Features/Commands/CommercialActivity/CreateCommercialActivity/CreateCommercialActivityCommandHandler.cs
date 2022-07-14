using KayitRehberi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Application.Features.Commands.CommercialActivity.CreateCommercialActivity
{
    public class CreateCommercialActivityCommandHandler : IRequestHandler<CreateCommercialActivityCommandRequest, CreateCommercialActivityCommandResponse>
    {
        readonly ICommercialActivityWriteRepository _commercialActivityWriteRepository;

        public CreateCommercialActivityCommandHandler(ICommercialActivityWriteRepository commercialActivityWriteRepository)
        {
            _commercialActivityWriteRepository = commercialActivityWriteRepository;
        }

        public async Task<CreateCommercialActivityCommandResponse> Handle(CreateCommercialActivityCommandRequest request, CancellationToken cancellationToken)
        {
            await _commercialActivityWriteRepository.AddAsync(new Domain.Entities.CommercialActivity
            {
                CustomerId = request.CustomerId,
                ServiceCharge = request.ServiceCharge,
                ServiceDate = request.ServiceDate,
                ServiceName = request.ServiceName
            });
            await _commercialActivityWriteRepository.SaveAsync();
            return new CreateCommercialActivityCommandResponse();
        }
    }
}
