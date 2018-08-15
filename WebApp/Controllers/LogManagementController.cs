using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class LogManagementController : BaseApiController
    {
        public class ComplexType
        {
            public string Param1 { get; set; }
            public string Param2 { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Log(string Param1, string Param2)
        {
            return Ok();
        }
    }
}