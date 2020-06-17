using System.Collections.Generic;
using System.Linq;

namespace Zundoko.App
{
    /// <summary>
    /// 実行時引数
    /// </summary>
    public class Arguments
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
        public Arguments(string[] args)
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

            Errors = errorList;
        }

        /// <summary>
        /// 元の引数を取得します。
        /// </summary>
        public string[] Args { get; private set; }

        /// <summary>
        /// エラーリストを取得します。
        /// </summary>
        public IEnumerable<ErrorType> Errors { get; private set; }

        /// <summary>
        /// エラー有無を取得します。
        /// </summary>
        public bool HasError => Errors.Count() > 0;

        /// <summary>
        /// 歌のタイトルを取得します。
        /// </summary>
        public string SongTitle { get; private set; }

        /// <summary>
        /// 試行回数を取得します。
        /// </summary>
        public int LimitCount { get; private set; }
    }
}
