using System;

namespace Zundoko.Models
{
    /// <summary>
    /// 歌手
    /// </summary>
    public class Singer
    {
        /// <summary>
        /// 乱数オブジェクト
        /// </summary>
        private readonly Random _random;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public Singer()
        {
            // 乱数初期化
            _random = new Random();
        }

        /// <summary>
        /// 歌を取得します。
        /// </summary>
        public ISong Song { get; private set; }

        /// <summary>
        /// 歌を設定します。
        /// </summary>
        /// <param name="song">歌オブジェクト</param>
        public void SetSong(ISong song)
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

            // ランダムにインデックスを生成
            var index = _random.Next(0, Song.UsingPhraseList.Count);

            // フレーズを返す
            return Song.UsingPhraseList[index];
        }
    }
}
