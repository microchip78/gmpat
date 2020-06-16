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
    public class PostcodeService : BaseService, IPostcodeService
    {
        public PostcodeService(ACMEContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
        }

        public async Task<Postcode> GetPostcodeAsync(string postcode)
        {
            var cacheKey = $"{nameof(Postcode)}:Code:ByName:{postcode}:Object";

            Func<Postcode> hitDatabase = () => {
                return this.context
                    .Postcodes
                    .FirstOrDefaultAsync(x => x.Pcode.Equals(postcode, StringComparison.InvariantCultureIgnoreCase))
                    .Result;
            };

            var result = GetCache(cacheKey, hitDatabase);

            return await Task.FromResult(result);
        }

        public async Task<IList<string>> GetPostcodesAsync()
        {
            var cacheKey = $"{nameof(Postcode)}:Codes:All:List";

            Func<IList<string>> hitDatabase = () => {
                return this.context
                    .Postcodes
                    .Select(x => x.Pcode)
                    .Distinct()
                    .ToListAsync().Result;
            };

            var result = GetCache(cacheKey, hitDatabase);

            return await Task.FromResult(result);
        }

        public async Task<IList<string>> GetPostcodesAsync(string state)
        {
            var cacheKey = $"{nameof(Postcode)}:Codes:All:{state}:List";

            Func<IList<string>> hitDatabase = () => {
                return this.context
                    .Postcodes
                    .Where(x => x.State.Equals(state, StringComparison.InvariantCultureIgnoreCase))
                    .Select(x => x.Pcode)
                    .Distinct()
                    .ToListAsync().Result;
            };

            var result = GetCache(cacheKey, hitDatabase);

            return await Task.FromResult(result);
        }
    }
}