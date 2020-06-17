using System.Collections.Generic;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models.Songs
{
    /// <summary>
    /// 歌：ウルトラソウル
    /// </summary>
    public class Ultrasoul : BaseSong
    {
        protected override IEnumerable<string> _GetAllPhrases()
            => new[] { "ウ", "ル", "ト", "ラ", "ソ" };

        protected override IEnumerable<int> _GetCompletePhraseIndexList()
            => new[] { 0, 1, 2, 3, 4, 0, 1 };

        protected override string _GetLastPhrase()
            => "！ ＼ハァイ！／";
    }
}
