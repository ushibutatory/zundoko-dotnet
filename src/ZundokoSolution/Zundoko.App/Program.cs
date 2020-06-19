using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Zundoko.Core;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.App
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var provider = new Func<IServiceProvider>(() =>
            {
                var services = new ServiceCollection()
                    .AddLogging(logging =>
                    {
                        logging.SetMinimumLevel(LogLevel.Debug);
                        // TODO: add provider
                    });

                services.SetupZundokoApplication(() => new MyConsole());

                return services.BuildServiceProvider();
            })();

            var console = provider.GetService<IConsole>();

            var app = new CommandLineApplication(throwOnUnexpectedArg: false)
            {
                Name = "Zundoko.App",
                Description = "Zundoko Application for .NET Core.",
            };
            var helpOption = "-?|-h|--help";
            app.HelpOption(helpOption);

            app.Command("list", command =>
            {
                command.Description = "歌一覧を表示します。";
                command.HelpOption(helpOption);

                command.OnExecute(() =>
                {
                    var album = provider.GetService<IAlbum>();

                    var songTitles = album.Songs.Select(song => song.GetType().Name);

                    console.WriteLine(string.Join(Environment.NewLine, songTitles));

                    return 0;
                });
            });

            app.Command("play", command =>
            {
                command.Description = "歌います。";
                command.HelpOption(helpOption);

                const int defaultCount = 100;

                var title = command.Argument("title", "曲名をアルファベットで指定します（前方一致）。");
                var count = command.Argument("count", $"試行回数。指定しない場合は{defaultCount}回試行します。");

                command.OnExecute(() =>
                {
                    if (title == null || string.IsNullOrEmpty(title.Value))
                    {
                        return command.Execute("-h");
                    }
                    var album = provider.GetService<IAlbum>();

                    var song = album.FindSong(title.Value);

                    if (song == null)
                    {
                        console.WriteLine("歌が見つかりませんでした。");
                        return -1;
                    }

                    var house = provider.GetService<IHouse>();

                    house.Play(song, int.TryParse(count?.Value, out var i) ? i : defaultCount);

                    return 0;
                });
            });

            // 引数なしで実行された場合はヘルプ表示
            if (args?.Length == 0) args = new[] { "-h" };

            app.Execute(args);
        }
    }
}
