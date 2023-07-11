using System.Reflection;
using MediatR;
using MicroRabbit.Banking.Aplication.Interfaces;
using MicroRabbit.Banking.Aplication.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Aplication.Interfaces;
using MicroRabbit.Transfer.Aplication.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IRequestHandler<CreateTransferCommand,bool>,TransferCommandHandler>();

            //MediatR
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IMediator, Mediator>();

            //Domain Bus 
            services.AddSingleton<IEventBus, RabbitMqBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = sp.GetService<IOptions<RabbitMQSettings>> ();
                return new RabbitMqBus(sp.GetService<IMediator>(), scopeFactory,optionsFactory);
            });

            //Application Services
            //services.AddTransient<IAccountService,AccountService>();
            //services.AddTransient<ITransferService, TransferService>();

            //Data
            //services.AddTransient<IAccountRepository, AccountRepository>();
            //services.AddTransient<ITransferRepository, TransferRepository>();
            //services.AddTransient<BankingDbContext>();
            //services.AddTransient<TransferDbContext>();

            return services;
        }
    }
}
