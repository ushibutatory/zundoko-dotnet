using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models
{
    /// <summary>
    /// 会場
    /// </summary>
    public class House : IHouse
    {
        private readonly ILogger<House> _logger;
        private readonly IConsole _console;

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
        public House(ILoggerFactory loggerFactory, IConsole console, ISinger singer, IAudience audience)
        {
            _logger = loggerFactory.CreateLogger<House>();
            _console = console;

            Singer = singer;
            Audience = audience;
        }

        /// <summary>
        /// 歌を演奏します。
        /// </summary>
        /// <param name="song">歌</param>
        /// <param name="limitCount">試行回数</param>
        public void Play(ISong song, int limitCount = 100)
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

            var phraseList = new List<string>();
            var count = 0;
            while (!Audience.IsSatisfied)
            {
                // 歌手からフレーズを取得
                var phrase = Singer.Sing();

                // フレーズ表示
                _console.Write(phrase);

                // リスト追加
                phraseList.Add(phrase);
                count++;

                if (song.IsCompleted(phraseList))
                {
                    // フレーズが完成したら、観客から掛け声を取得
                    var shout = Audience.Shout();

                    // 掛け声表示
                    _console.WriteLine(shout);

                    // 回数表示
                    _console.WriteLine($"{count:#,##0}回で完成しました。");
                }
                else
                {
                    if (limitCount > 0 && count >= limitCount)
                    {
                        // 試行回数を超えた場合
                        _console.WriteLine();
                        _console.WriteLine("残念・・・。");
                        break;
                    }
                    else
                    {
                        // 試行回数以内の場合
                        if (phraseList.Count > song.CompletePhraseCount)
                        {
                            // 完成フレーズ以上のフレーズは先頭から削除
                            phraseList.RemoveAt(0);
                        }
                    }
                }
            }
        }
    }
}
