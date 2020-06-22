using Microsoft.Extensions.DependencyInjection;
using Zundoko.Core.Models;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Tests
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection MockupZundokoApplication(this IServiceCollection services)
        {
            services
                .AddTransient<IHouse, House>()
                .AddTransient<IAlbum, Album>()
                .AddTransient<ISinger, Singer>()
                .AddTransient<IAudience, Audience>();

            return services;
        }
    }
}
