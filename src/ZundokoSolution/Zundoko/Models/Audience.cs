using System;

namespace Zundoko.Models
{
    /// <summary>
    /// 観客
    /// </summary>
    public class Audience
    {
        public Audience()
        {
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
        /// 歌を設定します。
        /// </summary>
        /// <param name="song">歌オブジェクト</param>
        public void SetSong(ISong song)
        {
            Song = song;

            // 歌が変わったら満足度を戻す
            IsSatisfied = false;
        }

        /// <summary>
        /// 叫びます。
        /// </summary>
        /// <returns>魂の掛け声</returns>
        public string Shout()
        {
            if (Song == null)
                throw new InvalidOperationException("Songプロパティが未設定です。");

            // 満足
            IsSatisfied = true;

            // 掛け声を返す
            return Song.ShoutPhrase;
        }
    }
}
