using Gozolop.Core.Xunit.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace Zundoko.Core.Tests
{
    public abstract class BaseTest<T>
    {
        protected readonly ILogger<T> _logger;
        protected readonly IServiceProvider _provider;

        public BaseTest(ITestOutputHelper outputHelper, Action<IServiceCollection> configureServices)
        {
            _provider = new Func<IServiceProvider>(() =>
            {
                var services = new ServiceCollection()
                    .AddLogging(logging =>
                    {
                        logging.AddXunit(outputHelper);
                    })
                    .MockupZundokoApplication();

                configureServices(services);

                return services.BuildServiceProvider();
            })();

            _logger = _provider.GetService<ILogger<T>>();
        }
    }
}
