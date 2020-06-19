using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models
{
    /// <summary>
    /// 会場
    /// </summary>
    public class House : IHouse
    {
        private readonly ILogger<House> _logger;

        /// <summary>
        /// 歌手を取得します。
        /// </summary>
        public ISinger Singer { get; }

        /// <summary>
        /// 観客を取得します。
        /// </summary>
        public IAudience Audience { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="singer">歌手</param>
        /// <param name="audience">観客</param>
        public House(ILoggerFactory loggerFactory, ISinger singer, IAudience audience)
        {
            _logger = loggerFactory.CreateLogger<House>();

            Singer = singer;
            Audience = audience;
        }

        /// <summary>
        /// 歌を演奏します。
        /// </summary>
        /// <param name="song">歌</param>
        /// <param name="limitCount">試行回数</param>
        public async Task<IEnumerable<string>> PlayAsync(ISong song, int limitCount = 100)
        {
            if (song == null)
                throw new InvalidOperationException($"引数[{nameof(song)}]がnullです。");
            if (Singer == null)
                throw new Exception("Singerプロパティが未設定です。");
            if (Audience == null)
                throw new Exception("Audienceプロパティが未設定です。");

            // 準備
            Singer.Standby(song);
            Audience.Standby(song);

            var results = new List<string>();
            var count = 0;
            while (!Audience.IsSatisfied)
            {
                // 歌手からフレーズを取得
                results.Add(Singer.Sing());
                count++;

                if (song.IsCompleted(results.TakeLast(song.CompletePhraseCount)))
                {
                    // フレーズが完成したら、観客から掛け声を取得
                    results.Add(Audience.Shout());

                    // 結果
                    results.Add($"{count:#,##0}回で完成しました。");
                }
                else
                {
                    if (limitCount > 0 && count >= limitCount)
                    {
                        // 試行回数を超えた場合
                        results.Add("残念・・・。");
                        break;
                    }
                }
            }
            return results;
        }
    }
}
