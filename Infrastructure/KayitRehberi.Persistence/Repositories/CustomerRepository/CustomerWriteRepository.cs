using KayitRehberi.Application.Repositories;
using KayitRehberi.Domain.Entities;
using KayitRehberi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Persistence.Repositories.CustomerRepository
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(KayiRehberiDbContext context) : base(context)
        {
        }
    }
}
