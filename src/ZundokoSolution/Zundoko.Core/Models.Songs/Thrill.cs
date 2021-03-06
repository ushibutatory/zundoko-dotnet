﻿using System.Collections.Generic;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models.Songs
{
    public class Thrill : BaseSong
    {
        public override string Title
            => "スリル";

        protected override IEnumerable<string> _GetAllPhrases()
            => new[] { "ベビ", "ベイビ", "ベイベー" };

        protected override IEnumerable<int> _GetCompletePhraseIndexList()
            => new[] { 0, 0, 1, 1, 1, 1, 2 };

        protected override string _GetLastPhrase()
            => "俺のすべては おまえのものさ";
    }
}
