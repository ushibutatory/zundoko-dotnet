using System.Collections.Generic;

namespace Zundoko.Core.Models.Abstracts
{
    /// <summary>
    /// アルバムインタフェース
    /// </summary>
    public interface IAlbum
    {
        /// <summary>
        /// 歌リストを取得します。
        /// </summary>
        IEnumerable<ISong> Songs { get; }

        /// <summary>
        /// 歌を検索します。
        /// </summary>
        /// <param name="playName">実行名（前方一致）</param>
        /// <returns>歌</returns>
        ISong FindSong(string playName);

        /// <summary>
        /// 歌を検索します。
        /// </summary>
        /// <param name="playName">実行名（前方一致）</param>
        /// <param name="song">歌</param>
        /// <returns>歌が見つかれば true を、見つからなければ false を返します。</returns>
        bool TryFindSong(string playName, out ISong song);
    }
}
