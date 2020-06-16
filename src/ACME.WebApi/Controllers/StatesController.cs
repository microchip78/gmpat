using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ACME.Service.Interfaces;

namespace ACME.WebApi.Controllers
{
    public class StatesController : BaseController
    {
        private readonly IStateService stateService;

        public StatesController(IStateService stateService)
        {
            this.stateService = stateService;
        }

        public override void Dispose()
        {
            this.stateService.Dispose();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var states = await this.stateService.GetStatesAsync();

            return Ok(states);
        }
    }
}