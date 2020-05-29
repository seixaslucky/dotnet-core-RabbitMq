using Microrabbit.Transfer.Domain.Models;
using MicroRabbit.Transfer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Microrabbit.Transfer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transfertService)
        {
            _transferService = transfertService;
        }

        [HttpGet]
        [Route("", Name = "Banking.Get")]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_transferService.Get());
        }

    }
}