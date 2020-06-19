using System.Collections.Generic;
using System.Text;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models.Songs
{
    /// <summary>
    /// 歌？：進捗どうですか
    /// </summary>
    public class Progress : BaseSong
    {
        protected override IEnumerable<string> _GetAllPhrases()
            => new[] { "進", "捗", "ど", "う", "で", "す", "か" };

        protected override IEnumerable<int> _GetCompletePhraseIndexList()
            // 進 捗 ど う で す か
            => new[] { 0, 1, 2, 3, 4, 5, 6 };

        protected override string _GetLastPhrase()
        {
            var text = new StringBuilder();
            text.AppendLine("＿人人人人人人人＿");
            text.AppendLine("＞進捗どうですか＜");
            text.AppendLine("￣∨∨∨∨∨∨∨￣");
            return text.ToString();
        }
    }
}
