using System.Collections.Generic;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models.Songs
{
    /// <summary>
    /// 歌：ソーラン節
    /// </summary>
    public class SoranBushi : BaseSong
    {
        protected override IEnumerable<string> _GetAllPhrases()
            => new[] { "ヤーレン", "ソーラン" };

        protected override IEnumerable<int> _GetCompletePhraseIndexList()
            => new[] { 0, 1, 1, 0, 1, 1 };

        protected override string _GetLastPhrase()
            => "（ハイ！　ハイ！）";
    }
}
