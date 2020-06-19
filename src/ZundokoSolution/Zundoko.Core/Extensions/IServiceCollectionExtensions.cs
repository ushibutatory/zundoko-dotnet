using Microsoft.Extensions.DependencyInjection;
using System;
using Zundoko.Core.Models;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection SetupZundokoApplication(this IServiceCollection services, Func<IConsole> createConsole)
        {
            services
                .AddTransient((provider) => createConsole())
                .AddTransient<IHouse, House>()
                .AddTransient<IAlbum, Album>()
                .AddTransient<ISinger, Singer>()
                .AddTransient<IAudience, Audience>();

            return services;
        }
    }
}
