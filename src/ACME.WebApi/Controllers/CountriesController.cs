using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ACME.Service.Interfaces;
using ACME.Core.Models;

namespace ACME.WebApi.Controllers
{
    public class CountriesController : BaseController
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        public override void Dispose()
        {
            this.countryService.Dispose();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var countries = await this.countryService.GetCountriesAsync();

            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var country = await this.countryService.GetCountryAsync(id);

            return Ok(country);
        }


        [HttpGet("names")]
        public async Task<IActionResult> GetNames()
        {
            var countryNames = await this.countryService.GetCountryNamesAsync();

            return Ok(countryNames);
        }
    }
}