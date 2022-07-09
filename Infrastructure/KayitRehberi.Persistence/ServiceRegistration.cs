using KayitRehberi.Application.Repositories;
using KayitRehberi.Domain.Entities.Identity;
using KayitRehberi.Persistence.Configurations;
using KayitRehberi.Persistence.Context;
using KayitRehberi.Persistence.Repositories.CommercialActivityRepository;
using KayitRehberi.Persistence.Repositories.CustomerRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Persistence
{
    public static class ServiceRegistration
    {
        /// <summary>
        /// IOC Container yapılandırması ve Json verisi olarak sunduğumuz Connection String adresini tanımladığımız extension metod
        /// </summary>
        /// <param name="services"></param>
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<KayiRehberiDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>(opt=>
            {
                //test aşaması için belirli şartlar kapatıldı şifreleme işlemi için.
                opt.Password.RequiredLength = 3;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<KayiRehberiDbContext>();


            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<ICommercialActivityReadRepository, CommercialActivityReadRepository>();
            services.AddScoped<ICommercialActivityWriteRepository, CommercialActivityWriteRepository>();
        }
    }
}
