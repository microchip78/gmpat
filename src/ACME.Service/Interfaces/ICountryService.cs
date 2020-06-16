using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ACME.Core.Models;

namespace ACME.Service.Interfaces
{
    public interface ICountryService : IBaseService
    {
        Task<Country> GetCountryAsync(int id);

        Task<Country> GetCountryAsync(string name);

        Task<IList<Country>> GetCountriesAsync();

        Task<IList<string>> GetCountryNamesAsync();
    }
}