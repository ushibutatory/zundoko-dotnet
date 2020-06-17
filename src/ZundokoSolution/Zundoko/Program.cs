using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zundoko
{
    /// <summary>
    /// ズンドコキヨシ
    /// </summary>
    public class Program
    {
        /// <summary>
        /// エントリポイント
        /// </summary>
        /// <param name="args">パラメータ</param>
        public static void Main(string[] args)
        {
            try
            {
                // パラメータを変換
                var argsConverter = new ArgsConverter(args);

                if (argsConverter.ErrorList.Count() > 0)
                {
                    // 引数エラー
                    var text = new StringBuilder();
                    text.AppendLine();
                    text.AppendLine();
                    text.AppendLine("使用方法: zundoko 歌のタイトル [試行回数]");
                    text.AppendLine("例）nabeatsu z 100");
                    text.AppendLine("Options:");
                    text.AppendLine("  歌のタイトル ... 英字で指定してください（前方一致）");
                    text.AppendLine("  試行回数 ... 最大の試行回数。未指定時は無制限。");
                    Console.WriteLine(text.ToString());
                }
                else
                {
                    // アルバムから歌を検索
                    var song = Album.GetInstance().FindSong(argsConverter.SongTitle);

                    if (song == null)
                        throw new Exception($"歌が見つかりませんでした。[Title:{argsConverter.SongTitle}]");

                    // 歌手を生成
                    var singer = new Singer();

                    // 観客を生成
                    var audience = new Audience();

                    // 会場を生成
                    var house = new House(singer, audience);

                    if (argsConverter.LimitCount.HasValue)
                    {
                        // 試行回数
                        house.LimitCount = argsConverter.LimitCount.Value;
                    }

                    // 演奏
                    house.Play(song);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 引数変換クラス
        /// </summary>
        private class ArgsConverter
        {
            /// <summary>
            /// エラー種別
            /// </summary>
            public enum ErrorType
            {
                /// <summary>
                /// 歌のタイトルが未入力
                /// </summary>
                SongTitle_Required,
                /// <summary>
                /// 試行回数が不正
                /// </summary>
                LimitCount_Invalid
            }

            /// <summary>
            /// 新しいインスタンスを生成します。
            /// </summary>
            /// <param name="args">元の引数</param>
            public ArgsConverter(string[] args)
            {
                // 元の引数
                Args = args;

                var errorList = new List<ErrorType>();

                // 歌タイトル
                if (args.Length < 1)
                {
                    errorList.Add(ErrorType.SongTitle_Required);
                }
                else
                {
                    SongTitle = args[0];
                }

                // 試行回数
                if (args.Length >= 2)
                {
                    if (!int.TryParse(args[1], out int count))
                    {
                        errorList.Add(ErrorType.LimitCount_Invalid);
                    }
                    else
                    {
                        LimitCount = count;
                    }
                }

                ErrorList = errorList;
            }

            /// <summary>
            /// 元の引数を取得します。
            /// </summary>
            public string[] Args { get; private set; }

            /// <summary>
            /// エラーリストを取得します。
            /// </summary>
            public IEnumerable<ErrorType> ErrorList { get; private set; }

            /// <summary>
            /// 歌のタイトルを取得します。
            /// </summary>
            public string SongTitle { get; private set; }

            /// <summary>
            /// 試行回数を取得します。
            /// </summary>
            public int? LimitCount { get; private set; }
        }
    }
}
