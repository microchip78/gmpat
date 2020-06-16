using System;
using System.Threading.Tasks;

namespace ACME.WebApi.ModelConverters
{
    public interface IModelConverter<TIn, TOut> : IDisposable
    {
        Task<TOut> Convert(TIn input);
    }
}