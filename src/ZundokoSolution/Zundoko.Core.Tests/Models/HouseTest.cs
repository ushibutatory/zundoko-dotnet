using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;
using Zundoko.Core.Models.Abstracts;
using Zundoko.Core.Models.Songs;

namespace Zundoko.Core.Tests.Models
{
    public class HouseTest : BaseTest<HouseTest>
    {
        public HouseTest(ITestOutputHelper outputHelper)
            : base(outputHelper, (services) => { })
        {
        }

        private ISong _Song => new ZundokoBushi();

        [Fact]
        public void Play()
        {
            var house = _provider.GetService<IHouse>();
            var result = house.Play(_Song);
            _logger.LogDebug(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void Cheat()
        {
            var house = _provider.GetService<IHouse>();
            var result = house.Cheat(_Song);
            _logger.LogDebug(JsonConvert.SerializeObject(result));
        }

    }
}
