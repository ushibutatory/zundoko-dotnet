using System.Collections.Generic;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models.Songs
{
    public class LoveSomebody : BaseSong
    {
        public override string Title
            => "LoveSomebody";

        protected override IEnumerable<string> _GetAllPhrases()
            => new[] { "ネバ", "ネーバー" };

        protected override IEnumerable<int> _GetCompletePhraseIndexList()
            => new[] { 0, 0, 0, 0, 0, 0, 1 };

        protected override string _GetLastPhrase()
            => "Let the love go I wanna Love somebody tonight";
    }
}
