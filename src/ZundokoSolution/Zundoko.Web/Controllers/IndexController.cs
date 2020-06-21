using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Zundoko.Core.Models.Abstracts;
using Zundoko.Web.Controllers.Abstracts;
using Zundoko.Web.Models;

namespace Zundoko.Web.Controllers
{
    [Controller]
    [Route("/")]
    public class IndexController : BaseController
    {
        private readonly IAlbum _album;

        public IndexController(ILogger<IndexController> logger, IOptions<AppSettings> appSettings, IAlbum album)
            : base(logger, appSettings)
        {
            _album = album;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // 歌一覧取得
            var songs = _album.Songs;

            return View("~/Views/Home/Index.cshtml", new IndexViewModel
            {
                AppSettings = _appSettings,
                Songs = songs,
            });
        }
    }
}
