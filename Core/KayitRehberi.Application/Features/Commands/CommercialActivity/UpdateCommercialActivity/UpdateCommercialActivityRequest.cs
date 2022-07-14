using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Application.Features.Commands.CommercialActivity.UpdateCommercialActivity
{
    public class UpdateCommercialActivityRequest: IRequest<UpdateCommercialActivityResponse>
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public float ServiceCharge { get; set; }
        public DateTime ServiceDate { get; set; }
        public int CustomerId { get; set; }
    }
}
