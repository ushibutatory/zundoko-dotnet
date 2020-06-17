using System.Collections.Generic;

namespace Zundoko.Models.Songs
{
    /// <summary>
    /// 歌：ウルトラソウル
    /// </summary>
    public class Ultrasoul : BaseSong
    {
        protected override List<string> _CreateUsingPhraseList()
            => new List<string>() { "ウ", "ル", "ト", "ラ", "ソ" };

        protected override IEnumerable<int> _CreateCompletePhraseIndexList()
            => new[] { 0, 1, 2, 3, 4, 0, 1 };

        protected override string _CreateShout()
            => "！ ＼ハァイ！／";
    }
}
