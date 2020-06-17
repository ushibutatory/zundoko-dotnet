using System.Collections.Generic;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models.Songs
{
    /// <summary>
    /// 歌：嵐
    /// </summary>
    public class Arashi : BaseSong
    {
        protected override IEnumerable<string> _GetAllPhrases()
            => new[] { "A", "RA", "SHI", " " };

        protected override IEnumerable<int> _GetCompletePhraseIndexList()
            // ARASHI ARASHI
            => new[] { 0, 1, 2, 3, 0, 1, 2 };

        protected override string _GetLastPhrase()
            => " for dream...";
    }
}
