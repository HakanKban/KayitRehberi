using KayitRehberi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Persistence.Context
{
    public class KayiRehberiDbContext : DbContext
    {
        public KayiRehberiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CommercialActivity> CommercialActivities { get; set; }
    }
}
