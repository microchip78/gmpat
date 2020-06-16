using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using ACME.Service.Interfaces;
using ACME.DataAccess;
using ACME.Core.Models;

namespace ACME.Service.Implementations
{
    public class StateService : BaseService, IStateService
    {
        public StateService(ACMEContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
        }

        public async Task<IList<string>> GetStatesAsync()
        {
            var cacheKey = $"{nameof(Postcode)}:States:All:List";

            Func<IList<string>> hitDatabase = () => {
                return this.context
                    .Postcodes
                    .Select(x => x.State)
                    .Distinct()
                    .ToListAsync().Result;
            };

            var result = GetCache(cacheKey, hitDatabase);

            return await Task.FromResult(result);
        }
    }
}