using KayitRehberi.Persistence.Configurations;
using KayitRehberi.Persistence.Context;
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
        /// IOC yapılandırmasını yaparak Json verisi olarak sunduğumuz Connection String adresini tanımladığımız extension metod
        /// </summary>
        /// <param name="services"></param>
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<KayiRehberiDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
        }
    }
}
