using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models
{
    /// <summary>
    /// 歌手
    /// </summary>
    public class Singer : ISinger
    {
        private readonly ILogger<Singer> _logger;

        /// <summary>
        /// 乱数オブジェクト
        /// </summary>
        private readonly Random _random;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public Singer(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Singer>();

            // 乱数初期化
            _random = new Random();
        }

        /// <summary>
        /// 歌を取得します。
        /// </summary>
        public ISong Song { get; private set; }

        /// <summary>
        /// 歌う準備をします。
        /// </summary>
        /// <param name="song">歌</param>
        public void Standby(ISong song)
        {
            Song = song;
        }

        /// <summary>
        /// 1フレーズ取得します。
        /// </summary>
        /// <returns>フレーズ</returns>
        public string Sing()
        {
            if (Song == null)
                throw new InvalidOperationException("Songプロパティが未設定です。");

            // フレーズ候補取得
            var phrases = Song.Phrases.ToList();

            // ランダムにフレーズを返す
            return phrases[_random.Next(0, phrases.Count)];
        }
    }
}
