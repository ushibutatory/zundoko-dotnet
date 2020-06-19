using Microsoft.Extensions.DependencyInjection;
using Zundoko.Core.Models;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection SetupZundokoApplication(this IServiceCollection services)
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
