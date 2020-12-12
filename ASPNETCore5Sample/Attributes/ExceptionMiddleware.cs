using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ASPNETCore5Sample.Attributes
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var isDev = _env.IsDevelopment();
                var problemDetails = new
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Instance = context.Request.Path,
                    Title = isDev ? $"{ex.GetType().Name}: {ex.Message}" : "An error occurred.",
                    Detail = isDev ? ex.StackTrace : null
                };

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
            }
        }

    }
}
