using KayitRehberi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Application.Features.Commands.CommercialActivity.RemoveCommercialActivity
{
    public class RemoveCommercialActivityCommandHandler: IRequestHandler<RemoveCommercialActivityCommandRequest,RemoveCommercialActivityCommandResponse>
    {
        ICommercialActivityWriteRepository _commercialActivityWriteRepository;

        public RemoveCommercialActivityCommandHandler(ICommercialActivityWriteRepository commercialActivityWriteRepository)
        {
            _commercialActivityWriteRepository = commercialActivityWriteRepository;
        }

        public async Task<RemoveCommercialActivityCommandResponse> Handle(RemoveCommercialActivityCommandRequest request, CancellationToken cancellationToken)
        {
            await _commercialActivityWriteRepository.RemoveAsync(request.Id);
            await _commercialActivityWriteRepository.SaveAsync();
            return new();
        }
    }
}
