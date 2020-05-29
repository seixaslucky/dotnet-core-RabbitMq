using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MicroRabbit.Banking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("", Name = "Banking.Get")]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.Get());
        }

        [HttpPost]
        [Route("/transfer", Name = "Banking.Transfer")]
        public ActionResult<bool> Post(AccountTransfer accountTransfer)
        {
            _accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }

        [HttpPost]
        [Route("", Name = "Banking.Post")]
        public ActionResult<Account> Post(Account account)
        {
            return Ok(_accountService.Post(account));
        }
    }
}