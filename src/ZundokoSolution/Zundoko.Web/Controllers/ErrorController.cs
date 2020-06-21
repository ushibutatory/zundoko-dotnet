using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Zundoko.Web.Controllers.Abstracts;
using Zundoko.Web.Models;

namespace Zundoko.Web.Controllers
{
    [Controller]
    [Route("/Error")]
    public class ErrorController : BaseController
    {
        public ErrorController(ILogger<ErrorController> logger, IOptions<AppSettings> appSettings)
            : base(logger, appSettings)
        {
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml", new ErrorViewModel
            {
                AppSettings = _appSettings,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            });
        }
    }
}
