using Microrabbit.Domain.Core.Bus;
using Microrabbit.Transfer.Domain.Models;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Transfer.Application.Interfaces;
using System.Collections.Generic;

namespace MicroRabbit.Banking.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferLogRepository _transferRepository;
        private readonly IEventBus _bus;

        public TransferService(ITransferLogRepository transferRepository, IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }

        public IEnumerable<TransferLog> Get()
        {
            return _transferRepository.Get();
        }
    }
}
