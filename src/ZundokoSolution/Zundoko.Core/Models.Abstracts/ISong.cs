using System.Collections.Generic;

namespace Zundoko.Core.Models.Abstracts
{
    /// <summary>
    /// 歌インタフェース
    /// </summary>
    public interface ISong
    {
        /// <summary>
        /// 実行名を取得します。
        /// </summary>
        string PlayName { get; }

        /// <summary>
        /// 曲名を取得します。
        /// </summary>
        string Title { get; }

        /// <summary>
        /// 歌詞を完成させるフレーズ数を取得します。
        /// </summary>
        int CompletePhrasesCount { get; }

        /// <summary>
        /// 使用するフレーズリストを取得します。
        /// </summary>
        IEnumerable<string> Phrases { get; }

        /// <summary>
        /// 完成フレーズリストを取得します。
        /// </summary>
        IEnumerable<string> CompletePhrases { get; }

        /// <summary>
        /// 最後の掛け声を取得します。
        /// </summary>
        string LastPhrase { get; }

        /// <summary>
        /// 歌詞が完成しているかどうかを取得します。
        /// </summary>
        /// <param name="phrases">フレーズリスト</param>
        /// <returns>完成しているかどうか</returns>
        bool IsCompleted(IEnumerable<string> phrases);
    }
}
