using Microrabbit.Transfer.Domain.Models;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Transfer.Data.Context;
using System.Collections.Generic;

namespace MicroRabbit.Banking.Data.Repository
{
    public class TransferLogRepository : ITransferLogRepository
    {
        private TransferDbContext _context;

        public TransferLogRepository(TransferDbContext context)
        {
            _context = context;
        }
        public IEnumerable<TransferLog> Get()
        {
            return _context.TransferLogs;
        }

        public TransferLog Post(TransferLog transfer)
        {
            _context.Add(transfer);
            _context.SaveChanges();
            return transfer;
        }
    }
}
