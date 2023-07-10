﻿using System.Reflection;
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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRequestHandler<CreateTransferCommand,bool>,TransferCommandHandler>();

            //MediatR
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IMediator, Mediator>();

            //Domain Bus
            services.AddTransient<IEventBus, RabbitMqBus>();

            //Application Services
            services.AddTransient<IAccountService,AccountService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>(); 

            return services;
        }
    }
}
