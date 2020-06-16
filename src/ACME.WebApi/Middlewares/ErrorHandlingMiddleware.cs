using System;
using System.Net;
using System.Threading.Tasks;
using ACME.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ACME.WebApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            /*
            if (ex is ExDataNotFoundException)     
                code = HttpStatusCode.NotFound;
            else if (ex is ExDataUnauthorizedException) 
                code = HttpStatusCode.Unauthorized;
            else if (ex is ExDataException)             
                code = HttpStatusCode.BadRequest;
            */

            var result = JsonConvert.SerializeObject(new { error = ex.GetAllMessages() });
            context.Response.ContentType = Constants.ContentTypeJson;
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}