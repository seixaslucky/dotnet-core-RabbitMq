using MediatR;
using Microrabbit.Domain.Core.Bus;
using Microrabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.Commandhandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Events;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //domain Bus
            service.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscriptions
            service.AddTransient<TransferEventHandler>();

            //dopmain Events
            service.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //Domain Commands
            service.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //data
            service.AddTransient<IAccountRepository, AccountRepository>();
            service.AddTransient<ITransferLogRepository, TransferLogRepository>();
            service.AddTransient<BankingDbContext>();
            service.AddTransient<TransferDbContext>();

            //aplication
            service.AddTransient<IAccountService, AccountService>();
            service.AddTransient<ITransferService, TransferService>();
        }
    }
}
