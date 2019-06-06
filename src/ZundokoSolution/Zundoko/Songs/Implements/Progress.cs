using System;
using System.Collections.Generic;
using System.Text;

namespace Zundoko.Songs.Implements
{
	/// <summary>
	/// 歌：進捗どうですか
	/// </summary>
	public class Progress : BaseSong
	{
		/// <summary>
		/// 使用フレーズリストを生成します。
		/// </summary>
		/// <returns>使用フレーズリスト</returns>
		protected override List<String> _CreateUsingPhraseList()
		{
			return new List<String>() { "進", "捗", "ど", "う", "で", "す", "か" };
		}

		/// <summary>
		/// 完成フレーズリストを生成します。
		/// </summary>
		/// <returns>完成フレーズリスト</returns>
		protected override IEnumerable<Int32> _CreateCompletePhraseIndexList()
		{
			// 進 捗 ど う で す か
			return new[] { 0, 1, 2, 3, 4, 5, 6 };
		}

		/// <summary>
		/// 掛け声を生成します。
		/// </summary>
		/// <returns>掛け声</returns>
		protected override String _CreateShout()
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
