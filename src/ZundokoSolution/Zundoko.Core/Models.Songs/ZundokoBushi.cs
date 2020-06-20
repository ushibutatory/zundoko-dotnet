using System.Collections.Generic;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models.Songs
{
    public class ZundokoBushi : BaseSong
    {
        public override string Title
            => "ズンドコ節";

        protected override IEnumerable<string> _GetAllPhrases()
            => new[] { "ズン", "ドコ" };

        protected override IEnumerable<int> _GetCompletePhraseIndexList()
            // ズン ズン ズン ズン ドコ
            => new[] { 0, 0, 0, 0, 1 };

        protected override string _GetLastPhrase()
            => "＼キ・ヨ・シ！／";
    }
}
