using System;
using Microsoft.AspNetCore.Mvc;

namespace TaxAssistant.Host.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet("/error")]
        public IActionResult HandleError() =>
    Problem();
    }
}

