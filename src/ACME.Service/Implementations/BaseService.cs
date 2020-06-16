using System;
using ACME.DataAccess;
using ACME.Service.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace ACME.Service.Implementations
{
    public abstract class BaseService : IBaseService
    {
        private static readonly object lockDbCall = new object();

        protected readonly IMemoryCache memoryCache;
        protected readonly ACMEContext context;

        /*
        The injected "IMemoryCache memoryCache" is singleton and there will be the cases where more than 1 requests
        are trying to access same "IMemoryCache memoryCache" object as it's singleton. But The default MS-provided MemoryCache 
        is entirely thread safe. Any custom implementation that derives from MemoryCache may not be thread safe. As I'm using 
        the MemoryCache out of the box, it is "FULLY" thread safe. So, there is no need to use 
        sync lock mechanism "lock(obj)" here to access MemoryCache!

        But to protect unnecessary DB calls when the cache is empty or expired and multiple threads are trying to
        access API at the same time, I am only allowing the first call to trigger the DB call to using the synclock
        mechanism "lock (lockDbCall)".
        */

        public BaseService(ACMEContext context, IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            this.context = context;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        protected TOut GetCache<TOut>(string cacheKey, Func<TOut> func)
        {
            var result = default(TOut);

            if (!this.memoryCache.TryGetValue(cacheKey, out result))
            {
                lock (lockDbCall)
                {
                    if (result == null)
                    {
                        result = memoryCache.GetOrCreate<TOut>(cacheKey,
                            entry =>
                            {
                                var value = func();
                                entry.AbsoluteExpiration = DateTimeOffset.UtcNow.AddHours(Core.Constants.DefaultCacheDurationHours);
                                return value;
                            }
                        );
                    }
                }
            }

            return result;
        }
    }
}