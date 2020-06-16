using System;
using System.Threading.Tasks;
using ACME.Core.Models;
using ACME.Service.Interfaces;
using ACME.WebApi.Models;

namespace ACME.WebApi.ModelConverters.Converters
{
    public class ApplicationRequestToApplicationConverter : IModelConverter<ApplicationRequest, Application>
    {
        private readonly ICountryService countryService;
        private readonly IPostcodeService postcodeService;

        public ApplicationRequestToApplicationConverter(ISubmitService submitService, ICountryService countryService, IPostcodeService postcodeService)
        {
            this.countryService = countryService;
            this.postcodeService = postcodeService;
        }

        public void Dispose()
        {
            this.countryService.Dispose();
            this.postcodeService.Dispose();
        }

        public async Task<Application> Convert(ApplicationRequest input)
        {
            var country = await this.countryService.GetCountryAsync(input.CountryName);
            if (country == null)
            {
                throw new ArgumentOutOfRangeException($"Provided country '{input.CountryName}' does not exists.");
            }

            var postcode = await this.postcodeService.GetPostcodeAsync(input.Postcode);
            
            return new Application
            {
                CountryId = country.CountryId,
                FullName = input.FullName,
                PostcodeId = postcode?.ID
            };
        }
    }
}