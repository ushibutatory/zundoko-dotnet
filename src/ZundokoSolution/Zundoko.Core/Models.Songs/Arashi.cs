using System.Collections.Generic;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models.Songs
{
    public class Arashi : BaseSong
    {
        public override string Title
            => "A・RA・SHI";

        protected override IEnumerable<string> _GetAllPhrases()
            => new[] { "A", "RA", "SHI", " " };

        protected override IEnumerable<int> _GetCompletePhraseIndexList()
            // ARASHI ARASHI
            => new[] { 0, 1, 2, 3, 0, 1, 2 };

        protected override string _GetLastPhrase()
            => " for dream...";
    }
}
