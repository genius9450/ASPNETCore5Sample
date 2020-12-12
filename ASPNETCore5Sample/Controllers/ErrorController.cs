using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ASPNETCore5Sample.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public ErrorController(IWebHostEnvironment env)
        {
            _env = env;
        }

        /// <summary>
        /// 預設 RFC7807 錯誤訊息格式
        /// </summary>
        /// <returns></returns>
        [HttpGet("RFC7Error")]
        public ActionResult RFC7Error()
        {
            return Problem();
        }

        /// <summary>
        /// 自定義錯誤訊息格式
        /// </summary>
        /// <returns></returns>
        [HttpGet("Error")]
        public ActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;
            var isDev = _env.IsDevelopment();
            var problemDetails = new
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = isDev ? $"{ex.GetType().Name}: {ex.Message}" : "An error occurred.",
                Detail = isDev ? ex.StackTrace : null
            };

            return StatusCode(problemDetails.StatusCode, problemDetails);
        }

    }
}
