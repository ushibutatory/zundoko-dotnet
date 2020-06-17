using System;
using System.Collections.Generic;

namespace Zundoko.Songs.Implements
{
    /// <summary>
    /// 歌：スリル
    /// </summary>
    public class Thrill : BaseSong
    {
        protected override List<string> _CreateUsingPhraseList()
            => new List<string>() { "ベビ", "ベイビ", "ベイベー" };

        protected override IEnumerable<int> _CreateCompletePhraseIndexList()
            => new[] { 0, 0, 1, 1, 1, 1, 2 };

        protected override string _CreateShout()
            => Environment.NewLine + "俺のすべては おまえのものさ";
    }
}
