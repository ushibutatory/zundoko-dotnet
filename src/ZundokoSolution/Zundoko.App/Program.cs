using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using Zundoko.Core.Extensions;
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

                services.SetupZundokoApplication((services) =>
                {
                    return new MyConsole();
                });

                return services.BuildServiceProvider();
            })();

            // TODO: 歌一覧を取得できるようなオプションを追加する
            var arguments = new Arguments(args);

            var console = provider.GetService<IConsole>();
            if (arguments.HasError)
            {
                // 引数エラー
                var text = new StringBuilder();
                text.AppendLine();
                text.AppendLine();
                text.AppendLine("使用方法: 歌のタイトル [試行回数]");
                text.AppendLine("例）z 100");
                text.AppendLine("Options:");
                text.AppendLine("  歌のタイトル ... 英字で指定してください（前方一致）");
                text.AppendLine("  試行回数 ... 最大の試行回数。未指定時は無制限。");
                console.WriteLine(text.ToString());
            }
            else
            {
                var album = provider.GetService<IAlbum>();

                var song = album.FindSong(arguments.SongTitle);

                var house = provider.GetService<IHouse>();

                house.Play(song, arguments.LimitCount);
            }
        }
    }
}
