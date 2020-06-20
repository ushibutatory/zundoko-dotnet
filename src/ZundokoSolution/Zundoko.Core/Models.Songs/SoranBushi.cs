using System.Collections.Generic;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models.Songs
{
    public class SoranBushi : BaseSong
    {
        public override string Title
            => "ソーラン節";

        protected override IEnumerable<string> _GetAllPhrases()
            => new[] { "ヤーレン", "ソーラン" };

        protected override IEnumerable<int> _GetCompletePhraseIndexList()
            => new[] { 0, 1, 1, 0, 1, 1 };

        protected override string _GetLastPhrase()
            => "（ハイ！　ハイ！）";
    }
}
