using Microrabbit.Domain.Core.Bus;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountrepository, IEventBus bus)
        {
            _accountRepository = accountrepository;
            _bus = bus;
        }

        public IEnumerable<Account> Get()
        {
            return _accountRepository.Get();
        }

        public Account Post(Account account)
        {
            return _accountRepository.Post(account);
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(accountTransfer.From, accountTransfer.To, accountTransfer.Amount);
            _bus.SendCommand(createTransferCommand);
        }
    }
}
