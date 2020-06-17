using System.Collections.Generic;

namespace Zundoko.Models.Songs
{
    /// <summary>
    /// 歌：ズンドコ節
    /// </summary>
    public class ZundokoBushi : BaseSong
    {
        protected override List<string> _CreateUsingPhraseList()
            => new List<string>() { "ズン", "ドコ" };

        protected override IEnumerable<int> _CreateCompletePhraseIndexList()
            // ズン ズン ズン ズン ドコ
            => new[] { 0, 0, 0, 0, 1 };

        protected override string _CreateShout()
            => "＼キ・ヨ・シ！／";
    }
}
