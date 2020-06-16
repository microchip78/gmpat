using System;
using System.Net.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;
using ACME.Service.Implementations;
using ACME.Service.Interfaces;
using ACME.WebApi.ModelConverters;
using ACME.WebApi.ModelConverters.Converters;
using ACME.WebApi.Models;
using ACME.Core.Models;

namespace ACME.WebApi
{
    public static class Registrations
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Mapping Singleton Instances With DI
            services.AddSingleton<IOptions<MemoryCacheOptions>, MemoryCacheOptions>();
            services.AddSingleton<IMemoryCache, MemoryCache>();

            // Mapping Scoped Instances With DI

            // Constructing Timeout Policy For The HTTPClient
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(45);

            // Constructing Circuit Breaker Policy For The HTTPClient
            var circuitBreakerPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));

            // Constructing Retry Mechanism For The HTTPClient
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .Or<TimeoutRejectedException>()
                .WaitAndRetryAsync(3, retryCount => TimeSpan.FromSeconds(Math.Pow(2, retryCount)),
                    onRetry: (response, delay, retryCount, context) =>
                    {
                        Console.WriteLine("HTTP Retry {0}, Delay {1}", retryCount, delay);
                    }
                );

            // --------------------------------------------------------------------
            // Demonstration purpose only: When calling external services...  
            // --------------------------------------------------------------------
            //services.AddHttpClient<IExternalService, ExternalService>(client =>
            //{
            //    client.BaseAddress = new Uri(Constants.ResourcesServiceBaseUrl);
            //}
            //)
            //.AddPolicyHandler(circuitBreakerPolicy)
            //.AddPolicyHandler(retryPolicy)
            //.AddPolicyHandler(timeoutPolicy);
            // --------------------------------------------------------------------

            return services.RegisterApplicationSpecificServices();
        }

        private static IServiceCollection RegisterApplicationSpecificServices(this IServiceCollection services)
        {
            // Data Services
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IPostcodeService, PostcodeService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ISubmitService, SubmitService>();

            // Converters
            services.AddScoped<IModelConverter<ApplicationRequest, Application>, ApplicationRequestToApplicationConverter>();

            return services;
        }
    }
}