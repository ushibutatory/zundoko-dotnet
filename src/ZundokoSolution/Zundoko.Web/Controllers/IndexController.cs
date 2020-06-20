using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zundoko.Core.Models.Abstracts;
using Zundoko.Web.Controllers.Abstracts;
using Zundoko.Web.Models;

namespace Zundoko.Web.Controllers
{
    [Controller]
    [Route("/")]
    public class IndexController : BaseController
    {
        private readonly ILogger<IndexController> _logger;
        private readonly IAlbum _album;

        public IndexController(ILoggerFactory loggerFactory, IAlbum album)
        {
            _logger = loggerFactory.CreateLogger<IndexController>();
            _album = album;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // 歌一覧取得
            var songs = _album.Songs;

            return View("~/Views/Home/Index.cshtml", new IndexViewModel
            {
                Songs = songs,
            });
        }
    }
}
