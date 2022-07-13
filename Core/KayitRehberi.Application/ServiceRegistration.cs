using KayitRehberi.Application.Services;
using KayitRehberi.Application.Services.BackgroundServices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection
            )
        {
            serviceCollection.AddMediatR(typeof(ServiceRegistration));
            serviceCollection.AddSingleton(sp => new ConnectionFactory()
            {
                Uri = new Uri("amqps://mmbvcyci:iPr-zhpZZm6O-ftek_qP3fdg622jzg8c@moose.rmq.cloudamqp.com/mmbvcyci"), DispatchConsumersAsync=true
            });
            serviceCollection.AddSingleton<RabbitMQClientService>();
            serviceCollection.AddSingleton<RabbitMQPublisher>();
            serviceCollection.AddHostedService<ImageWatermartProcessBackgroundService>();
        }

    }
}
