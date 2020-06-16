using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using ACME.Core.Models;
using ACME.DataAccess;
using ACME.Service.Interfaces;

namespace ACME.Service.Implementations
{
    public class SubmitService : BaseService, ISubmitService
    {
        public SubmitService(ACMEContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
        }

        public async Task<int> SaveApplicationAsync(Application application)
        {
            var addedApplication = await context
                .Applications
                .AddAsync(application);

            await context.SaveChangesAsync();

            return addedApplication.Entity.Id;
        }
    }
}