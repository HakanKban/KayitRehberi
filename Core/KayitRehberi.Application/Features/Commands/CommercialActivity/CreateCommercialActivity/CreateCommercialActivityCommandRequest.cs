using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Application.Features.Commands.CommercialActivity.CreateCommercialActivity
{
    public class CreateCommercialActivityCommandRequest :IRequest<CreateCommercialActivityCommandResponse>
    {
        public string ServiceName { get; set; }
        public float ServiceCharge { get; set; }
        public DateTime ServiceDate { get; set; }
        public int CustomerId { get; set; }
    }
}
