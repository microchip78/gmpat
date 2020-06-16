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
    public class CountryService : BaseService, ICountryService
    {
        public CountryService(ACMEContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
        }

        public async Task<Country> GetCountryAsync(string name)
        {
            var cacheKey = $"{nameof(Country)}:Full:ByName:{name}:Object";

            Func<Country> hitDatabase = () => {
                return this.context
                    .Countries
                    .FirstOrDefaultAsync(x => x.CountryName.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Result;
            };

            var result = GetCache(cacheKey, hitDatabase);

            return await Task.FromResult(result);
        }

        public async Task<Country> GetCountryAsync(int id)
        {
            var cacheKey = $"{nameof(Country)}:Full:ById:{id}:Object";

            Func<Country> hitDatabase = () => {
                return this.context
                    .Countries
                    .FirstOrDefaultAsync(x => x.CountryId == id).Result;
            };

            var result = GetCache(cacheKey, hitDatabase);

            return await Task.FromResult(result);
        }

        public async Task<IList<Country>> GetCountriesAsync()
        {
            var cacheKey = $"{nameof(Country)}:Full:All:List";

            Func<IList<Country>> hitDatabase = () => {
                return this.context
                    .Countries
                    .Select(x => x)
                    .ToListAsync().Result;
            };

            var result = GetCache(cacheKey, hitDatabase);

            return await Task.FromResult(result);
        }

        public async Task<IList<string>> GetCountryNamesAsync()
        {
            var cacheKey = $"{nameof(Country)}:Names:All:List";

            Func<IList<string>> hitDatabase = () => {
                return this.context
                    .Countries
                    .Select(x => x.CountryName)
                    .ToListAsync().Result;
                };

            var result = GetCache(cacheKey, hitDatabase);

            return await Task.FromResult(result);
        }
    }
}