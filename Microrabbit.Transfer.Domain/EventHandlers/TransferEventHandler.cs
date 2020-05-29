using Microrabbit.Domain.Core.Bus;
using Microrabbit.Transfer.Domain.Models;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Events;
using System.Threading.Tasks;

namespace Microrabbit.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        readonly ITransferLogRepository _transferLogRepository;
        public TransferEventHandler(ITransferLogRepository transferLogRepository)
        {
            _transferLogRepository = transferLogRepository;
        }
        public Task Handle(TransferCreatedEvent @event)
        {
            _transferLogRepository.Post(new TransferLog
            {
                From = @event.From,
                To = @event.To,
                Amount = @event.Amount
            }) ;
            return Task.CompletedTask;
        }
    }
}
