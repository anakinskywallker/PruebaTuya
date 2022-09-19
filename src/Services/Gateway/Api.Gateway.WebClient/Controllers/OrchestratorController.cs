using Api.Gateway.Models.seeker.Commands;
using Api.Gateway.Models.seeker.DTOs;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Controllers
{
   
    [ApiController]
    [Route("Orchestrator")]
    public class OrchestratorController : ControllerBase
    {
        private readonly IOrchestratorProxy _OrchestratorProxy;

        public OrchestratorController(
            IOrchestratorProxy orchestratorProxy
        )
        {
            _OrchestratorProxy = orchestratorProxy;
        }

       

        [HttpPost("Shoping")]
        public async Task<FacturaCommand> Shoping(DataRequest command)
        {
            return await _OrchestratorProxy.ShopingLogic(command);
        }
    }
}
