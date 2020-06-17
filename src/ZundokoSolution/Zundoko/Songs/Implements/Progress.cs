﻿using System.Collections.Generic;
using System.Text;

namespace Zundoko.Songs.Implements
{
    /// <summary>
    /// 歌？：進捗どうですか
    /// </summary>
    public class Progress : BaseSong
    {
        protected override List<string> _CreateUsingPhraseList()
            => new List<string>() { "進", "捗", "ど", "う", "で", "す", "か" };

        protected override IEnumerable<int> _CreateCompletePhraseIndexList()
            // 進 捗 ど う で す か
            => new[] { 0, 1, 2, 3, 4, 5, 6 };

        protected override string _CreateShout()
        {
            var text = new StringBuilder();
            text.AppendLine();
            text.AppendLine("＿人人人人人人人＿");
            text.AppendLine("＞進捗どうですか＜");
            text.AppendLine("￣∨∨∨∨∨∨∨￣");
            return text.ToString();
        }
    }
}
