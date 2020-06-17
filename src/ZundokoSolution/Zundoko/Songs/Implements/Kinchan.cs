using System.Collections.Generic;

namespace Zundoko.Songs.Implements
{
    /// <summary>
    /// 歌：欽ちゃん
    /// </summary>
    public class Kinchan : BaseSong
    {
        protected override List<string> _CreateUsingPhraseList()
            => new List<string>() { "８", "時", "だ", "ョ", "！", };

        protected override IEnumerable<int> _CreateCompletePhraseIndexList()
            // ８ 時 だ ョ ！
            => new[] { 0, 1, 2, 3, 4 };

        protected override string _CreateShout()
            => "＼全員集合／";
    }
}
