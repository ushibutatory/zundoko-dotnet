using System.Collections.Generic;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models.Songs
{
    /// <summary>
    /// 歌：欽ちゃん
    /// </summary>
    public class Kinchan : BaseSong
    {
        protected override IEnumerable<string> _GetAllPhrases()
            => new[] { "８", "時", "だ", "ョ", "！", };

        protected override IEnumerable<int> _GetCompletePhraseIndexList()
            // ８ 時 だ ョ ！
            => new[] { 0, 1, 2, 3, 4 };

        protected override string _GetLastPhrase()
            => "＼全員集合／";
    }
}
