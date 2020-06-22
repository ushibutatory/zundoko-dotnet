using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Tests.Models
{
    public class AlbumTest : BaseTest<AlbumTest>
    {
        public AlbumTest(ITestOutputHelper outputHelper)
            : base(outputHelper, (services) => { })
        {
        }

        [Fact]
        public void Songs()
        {
            var album = _provider.GetService<IAlbum>();

            var songs = album.Songs;

            Assert.Equal(9, songs.Count());
            _logger.LogDebug(JsonConvert.SerializeObject(songs));
        }

        [Theory]
        [InlineData("a")]
        [InlineData("k")]
        [InlineData("l")]
        [InlineData("n")]
        [InlineData("p")]
        [InlineData("s")]
        [InlineData("t")]
        [InlineData("u")]
        [InlineData("z")]
        public void FindSongs(string playName)
        {
            var album = _provider.GetService<IAlbum>();

            var song = album.FindSong(playName);

            Assert.NotNull(song);
            _logger.LogDebug(JsonConvert.SerializeObject(song));
        }
    }
}
