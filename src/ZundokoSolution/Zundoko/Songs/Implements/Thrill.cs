using System;
using System.Collections.Generic;
using System.Text;

namespace Zundoko.Songs.Implements
{
	/// <summary>
	/// 歌：スリル
	/// </summary>
	public class Thrill : BaseSong
	{
		/// <summary>
		/// 使用フレーズリストを生成します。
		/// </summary>
		/// <returns>使用フレーズリスト</returns>
		protected override List<String> _CreateUsingPhraseList()
		{
			return new List<String>() { "ベビ", "ベイビ", "ベイベー" };
		}

		/// <summary>
		/// 完成フレーズリストを生成します。
		/// </summary>
		/// <returns>完成フレーズリスト</returns>
		protected override IEnumerable<Int32> _CreateCompletePhraseIndexList()
		{
			return new[] { 0, 0, 1, 1, 1, 1, 2 };
		}

		/// <summary>
		/// 掛け声を生成します。
		/// </summary>
		/// <returns>掛け声</returns>
		protected override String _CreateShout()
		{
			var text = new StringBuilder();
			text.AppendLine();
			text.AppendLine("俺のすべては おまえのものさ");
			return  text.ToString();
		}
	}
}
