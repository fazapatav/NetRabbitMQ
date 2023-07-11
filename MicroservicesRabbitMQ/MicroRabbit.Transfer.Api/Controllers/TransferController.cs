﻿using MicroRabbit.Transfer.Aplication.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Transfer.Api.Controllers
{
    [Route("api/[controller]")]
    public class TransferController:ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService itransferService)
        {
            _transferService = itransferService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
