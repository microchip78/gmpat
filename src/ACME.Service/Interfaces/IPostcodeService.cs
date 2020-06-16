using System.Collections.Generic;
using System.Threading.Tasks;
using ACME.Core.Models;

namespace ACME.Service.Interfaces
{
    public interface IPostcodeService : IBaseService
    {
        Task<IList<string>> GetPostcodesAsync();

        Task<IList<string>> GetPostcodesAsync(string state);

        Task<Postcode> GetPostcodeAsync(string postcode);
    }
}