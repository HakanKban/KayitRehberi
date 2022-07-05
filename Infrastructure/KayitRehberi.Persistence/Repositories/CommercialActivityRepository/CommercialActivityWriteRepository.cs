using KayitRehberi.Application.Repositories;
using KayitRehberi.Domain.Entities;
using KayitRehberi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Persistence.Repositories.CommercialActivityRepository
{
    public class CommercialActivityWriteRepository : WriteRepository<CommercialActivity>, ICommercialActivityWriteRepository
    {
        public CommercialActivityWriteRepository(KayiRehberiDbContext context) : base(context)
        {
        }
    }
}
