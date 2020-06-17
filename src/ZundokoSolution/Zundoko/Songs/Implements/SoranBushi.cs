using System.Collections.Generic;

namespace Zundoko.Songs.Implements
{
    /// <summary>
    /// 歌：ソーラン節
    /// </summary>
    public class SoranBushi : BaseSong
    {
        protected override List<string> _CreateUsingPhraseList()
            => new List<string>() { "ヤーレン", "ソーラン" };

        protected override IEnumerable<int> _CreateCompletePhraseIndexList()
            => new[] { 0, 1, 1, 0, 1, 1 };

        protected override string _CreateShout()
            => "（ハイ！　ハイ！）";
    }
}
