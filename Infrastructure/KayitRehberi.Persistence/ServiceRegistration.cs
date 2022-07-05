﻿using KayitRehberi.Application.Repositories;
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
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<ICommercialActivityReadRepository, CommercialActivityReadRepository>();
            services.AddScoped<ICommercialActivityWriteRepository, CommercialActivityWriteRepository>();
        }
    }
}
