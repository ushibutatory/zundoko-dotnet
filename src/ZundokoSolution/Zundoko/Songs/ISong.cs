using System.Collections.Generic;

namespace Zundoko.Songs
{
    /// <summary>
    /// 歌インタフェース
    /// </summary>
    public interface ISong
    {
        /// <summary>
        /// 完成フレーズ数を取得します。
        /// </summary>
        int CompletePhraseCount { get; }

        /// <summary>
        /// 使用するフレーズリストを取得します。
        /// </summary>
        IList<string> UsingPhraseList { get; }

        /// <summary>
        /// 掛け声を取得します。
        /// </summary>
        string ShoutPhrase { get; }

        /// <summary>
        /// フレーズが完成しているかどうかを取得します。
        /// </summary>
        /// <param name="phraseList">フレーズリスト</param>
        /// <returns>完成しているかどうか</returns>
        bool IsCompleted(IEnumerable<string> phraseList);
    }
}
