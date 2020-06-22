using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <returns>実行結果</returns>
        public PlayResult Play(ISong song, int limitCount = 100)
        {
            // 準備
            _Standby(song);

            var phrases = new List<string>();
            var count = 0;
            while (!Audience.IsSatisfied)
            {
                // 歌手からフレーズを取得
                phrases.Add(Singer.Sing());
                count++;

                if (song.IsCompleted(phrases.TakeLast(song.CompletePhrasesCount)))
                {
                    // フレーズが完成したら、観客から掛け声を取得
                    var shout = Audience.Shout();

                    // 完成
                    return new PlayResult.Builder
                    {
                        Song = song,
                        SingerPhrases = phrases,
                        AudienceShout = shout,
                        Message = $"{count:#,##0}回で完成しました。",
                    }.Build();
                }
                else
                {
                    if (limitCount > 0 && count >= limitCount)
                    {
                        // 試行回数を超えた場合
                        return new PlayResult.Builder
                        {
                            Song = song,
                            SingerPhrases = phrases,
                            Message = $"{count:#,##0}回では完成しませんでした・・・。",
                        }.Build();
                    }
                }
            }
            throw new Exception($"ループが想定通りに終了しませんでした。 [{nameof(song)}:{JsonConvert.SerializeObject(song)}]");
        }

        /// <summary>
        /// チートモードで歌を演奏します。
        /// </summary>
        /// <param name="song">歌</param>
        /// <returns>実行結果</returns>
        public PlayResult Cheat(ISong song)
        {
            // 準備
            _Standby(song);

            return new PlayResult.Builder
            {
                Song = song,
                SingerPhrases = song.CompletePhrases,
                AudienceShout = Audience.Shout(),
                Message = "チートモードで完成しました。",
            }.Build();
        }

        private IHouse _Standby(ISong song)
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

            return this;
        }
    }
}
