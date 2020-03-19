using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ATMController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly ILogger<ATMController> _logger;

        public ATMController(ILogger<ATMController> logger, IBankAccountService bankAccountService)
        {
            _logger = logger;
            _bankAccountService = bankAccountService;
        }

        [HttpGet]
        public bool Register(string cpf)
        {
            return _bankAccountService.Register(cpf);
        }
    }
}
