using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ACME.Service.Interfaces;
using ACME.Core.Models;
using ACME.WebApi.ModelConverters;
using ACME.WebApi.Models;

namespace ACME.WebApi.Controllers
{
    public class SubmitController : BaseController
    {
        private readonly ISubmitService submitService;
        private readonly IModelConverter<ApplicationRequest, Application> converter;

        public SubmitController(IModelConverter<ApplicationRequest, Application> converter, ISubmitService submitService)
        {
            this.submitService = submitService;
            this.converter = converter;
        }

        public override void Dispose()
        {
            this.converter.Dispose();
            this.submitService.Dispose();
        }

        [HttpPost("application")]
        public async Task<IActionResult> PostApplication([FromBody] ApplicationRequest application)
        {
            var model = await this.converter.Convert(application);

            var result = await this.submitService.SaveApplicationAsync(model);

            return Ok(result);
        }
    }
}