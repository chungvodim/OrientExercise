using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ErrorController : BaseApiController
    {
        private readonly IAppLogger<ErrorController> _logger;
        public ErrorController(IAppLogger<ErrorController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            // Get the details of the exception that occurred
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                // Get which route the exception occurred at
                string routeWhereExceptionOccurred = exceptionFeature.Path;

                // Get the exception that occurred
                Exception exceptionThatOccurred = exceptionFeature.Error;

                // TODO: Do something with the exception
                // Log it with Serilog?
                // Send an e-mail, text, fax, or carrier pidgeon?  Maybe all of the above?
                // Whatever you do, be careful to catch any exceptions, otherwise you'll end up with a blank page and throwing a 500
                _logger.LogError(exceptionThatOccurred.Message, exceptionThatOccurred);
            }

            return BadRequest("Something went wrong");
        }
    }
}