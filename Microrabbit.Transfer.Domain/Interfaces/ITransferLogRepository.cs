using Microrabbit.Transfer.Domain.Models;
using System.Collections.Generic;

namespace MicroRabbit.Banking.Domain.Interfaces
{
    public interface ITransferLogRepository
    {
        IEnumerable<TransferLog> Get();
        TransferLog Post(TransferLog transfer);
    }
}
