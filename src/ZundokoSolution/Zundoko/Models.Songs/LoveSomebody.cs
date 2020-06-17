using System.Collections.Generic;

namespace Zundoko.Models.Songs
{
    /// <summary>
    /// 歌：LoveSomebody
    /// </summary>
    public class LoveSomebody : BaseSong
    {
        protected override List<string> _CreateUsingPhraseList()
            => new List<string>() { "ネバ", "ネーバー" };

        protected override IEnumerable<int> _CreateCompletePhraseIndexList()
            => new[] { 0, 0, 0, 0, 0, 0, 1 };

        protected override string _CreateShout()
            => "Let the love go I wanna Love somebody tonight";
    }
}
