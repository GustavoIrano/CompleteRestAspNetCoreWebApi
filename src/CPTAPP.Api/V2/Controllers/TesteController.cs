using CPTAPP.Api.Controllers;
using CPTAPP.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CPTAPP.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController : MainController
    {
        private readonly ILogger _logger;

        public TesteController(INotificador notificador, IUser appUser, ILogger<TesteController> logger) : base(notificador, appUser) 
        {
            _logger = logger;
        }

        [HttpGet]
        public string Valor()
        {
            throw new Exception("error");

            _logger.LogTrace("Log de trace");
            _logger.LogDebug("Log de Debug");
            _logger.LogInformation("Log de informação");
            _logger.LogWarning("Log de aviso");
            _logger.LogError("Log de erro");
            _logger.LogCritical("Log de problema critico");

            return "Sou a V2";
        }
    }
}
