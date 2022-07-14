using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Application.Features.Queries.CommercialActivity.GetByIdCommercialActivity
{
    public class GetByIdCommercialActivityRequest : IRequest<GetByIdCommercialActivityResponse>
    {
        public int Id { get; set; }
    }
}
