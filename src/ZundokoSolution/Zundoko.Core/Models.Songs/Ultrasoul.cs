using System.Collections.Generic;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models.Songs
{
    public class Ultrasoul : BaseSong
    {
        public override string Title
            => "ウルトラソウル";

        protected override IEnumerable<string> _GetAllPhrases()
            => new[] { "ウ", "ル", "ト", "ラ", "ソ" };

        protected override IEnumerable<int> _GetCompletePhraseIndexList()
            => new[] { 0, 1, 2, 3, 4, 0, 1 };

        protected override string _GetLastPhrase()
            => "！ ＼ハァイ！／";
    }
}
