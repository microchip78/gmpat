using System;
using System.Threading.Tasks;
using ACME.Core.Models;

namespace ACME.Service.Interfaces
{
    public interface ISubmitService : IBaseService
    {
        Task<int> SaveApplicationAsync(Application application);
    }
}