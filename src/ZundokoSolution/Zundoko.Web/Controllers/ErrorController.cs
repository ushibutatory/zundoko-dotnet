using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Zundoko.Web.Controllers.Abstracts;
using Zundoko.Web.Models;

namespace Zundoko.Web.Controllers
{
    [Controller]
    [Route("/Error")]
    public class ErrorController : BaseController
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ErrorController>();
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml", new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            });
        }
    }
}
