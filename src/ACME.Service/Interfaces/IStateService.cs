using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACME.Service.Interfaces
{
    public interface IStateService : IBaseService
    {
        Task<IList<string>> GetStatesAsync();
    }
}