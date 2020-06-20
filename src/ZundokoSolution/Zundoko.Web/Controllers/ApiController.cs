using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Zundoko.Core.Models;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Web.Controllers
{
    // for debug

    [ApiController]
    [Route("api/")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;

        private readonly IHouse _house;
        private readonly IAlbum _album;

        public ApiController(ILoggerFactory loggerFactory, IHouse house, IAlbum album)
        {
            _logger = loggerFactory.CreateLogger<ApiController>();
            _house = house;
            _album = album;
        }

        [HttpGet("list")]
        public IEnumerable<ISong> List()
        {
            return _album.Songs;
        }

        [HttpGet("play/{title}")]
        public PlayResult Play(string title)
        {
            var song = _album.FindSong(title);

            if (song == null)
            {
                return new PlayResult.Builder
                {
                    Song = song,
                    Message = "歌が見つかりませんでした。",
                }.Build();
            }

            return _house.Play(song, 100);
        }
    }
}
