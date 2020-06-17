using System.Collections.Generic;

namespace Zundoko.Songs.Implements
{
    /// <summary>
    /// 歌：嵐
    /// </summary>
    public class Arashi : BaseSong
    {
        protected override List<string> _CreateUsingPhraseList()
            => new List<string>() { "A", "RA", "SHI", " " };

        protected override IEnumerable<int> _CreateCompletePhraseIndexList()
            // ARASHI ARASHI
            => new[] { 0, 1, 2, 3, 0, 1, 2 };

        protected override string _CreateShout()
            => " for dream...";
    }
}
