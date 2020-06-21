using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zundoko.Core.Models.Abstracts;
using Zundoko.Web.Controllers.Abstracts;
using Zundoko.Web.Models;

namespace Zundoko.Web.Controllers
{
    [Controller]
    [Route("/Play")]
    public class PlayController : BaseController
    {
        private readonly ILogger<PlayController> _logger;
        private readonly IAlbum _album;
        private readonly IHouse _house;

        public PlayController(ILoggerFactory loggerFactory, IAlbum album, IHouse house)
        {
            _logger = loggerFactory.CreateLogger<PlayController>();
            _album = album;
            _house = house;
        }

        [HttpGet("{songName}")]
        public IActionResult Play(string songName)
        {
            // 歌検索
            var song = _album.FindSong(songName);
            if (song == null) return new NotFoundResult();

            const int count = 256;
            var playResult = _house.Play(song, count);

            return View("~/Views/Home/Play.cshtml", new PlayViewModel
            {
                Title = song.Title,
                Song = song,
                PlayResult = playResult,
            });
        }
    }
}
