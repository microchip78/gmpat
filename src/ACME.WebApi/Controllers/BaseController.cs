using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ACME.Service.Interfaces;
using ACME.Core.Models;

namespace ACME.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase, IDisposable
    {
        public virtual void Dispose()
        {
            // Used in controllers...
        }
    }
}