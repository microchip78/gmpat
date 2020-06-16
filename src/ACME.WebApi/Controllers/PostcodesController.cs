using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ACME.Service.Interfaces;

namespace ACME.WebApi.Controllers
{
    public class PostcodesController : BaseController
    {
        private readonly IPostcodeService postcodeService;

        public PostcodesController(IPostcodeService postcodeService)
        {
            this.postcodeService = postcodeService;
        }
        public override void Dispose()
        {
            this.postcodeService.Dispose();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var postcodes = await this.postcodeService.GetPostcodesAsync();

            return Ok(postcodes);
        }

        [HttpGet("{state}")]
        public async Task<IActionResult> Get(string state)
        {
            var postcodes = await this.postcodeService.GetPostcodesAsync(state);

            return Ok(postcodes);
        }
    }
}