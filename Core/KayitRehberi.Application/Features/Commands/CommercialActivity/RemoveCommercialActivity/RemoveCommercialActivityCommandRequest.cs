using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Application.Features.Commands.CommercialActivity.RemoveCommercialActivity
{
    public class RemoveCommercialActivityCommandRequest : IRequest<RemoveCommercialActivityCommandResponse>
    {
        public int Id { get; set; }
    }
}
