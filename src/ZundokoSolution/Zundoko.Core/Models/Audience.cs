using Microsoft.Extensions.Logging;
using System;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models
{
    /// <summary>
    /// 観客
    /// </summary>
    public class Audience : IAudience
    {
        private readonly ILogger<Audience> _logger;

        public Audience(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Audience>();

            IsSatisfied = false;
        }

        /// <summary>
        /// 歌を取得します。
        /// </summary>
        public ISong Song { get; private set; }

        /// <summary>
        /// 満足しているかどうかを取得します。
        /// </summary>
        public bool IsSatisfied { get; private set; }

        /// <summary>
        /// 歌を聴く準備をします。
        /// </summary>
        /// <param name="song">歌</param>
        public void Standby(ISong song)
        {
            Song = song;

            // 歌が変わったら満足度を戻す
            IsSatisfied = false;
        }

        /// <summary>
        /// 叫びます。
        /// </summary>
        /// <returns>掛け声</returns>
        public string Shout()
        {
            if (Song == null)
                throw new InvalidOperationException("Songプロパティが未設定です。");

            // 満足
            IsSatisfied = true;

            // 掛け声を返す
            return Song.LastPhrase;
        }
    }
}
