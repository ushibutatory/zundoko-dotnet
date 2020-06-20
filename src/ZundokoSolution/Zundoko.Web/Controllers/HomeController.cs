using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Zundoko.Core.Models.Abstracts;
using Zundoko.Web.Models;

namespace Zundoko.Web.Controllers
{
    [Controller]
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlbum _album;

        public HomeController(ILoggerFactory loggerFactory, IAlbum album)
        {
            _logger = loggerFactory.CreateLogger<HomeController>();
            _album = album;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // 歌一覧取得
            var songs = _album.Songs;

            return View(new IndexViewModel
            {
                Songs = songs,
            });
        }

        [HttpGet("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            });
        }
    }
}
