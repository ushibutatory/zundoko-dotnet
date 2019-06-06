using System;
using System.Collections.Generic;

namespace Zundoko.Songs.Implements
{
	/// <summary>
	/// 歌：ウルトラソウル
	/// </summary>
	public class Ultrasoul : BaseSong
	{
		/// <summary>
		/// 使用フレーズリストを生成します。
		/// </summary>
		/// <returns>使用フレーズリスト</returns>
		protected override List<String> _CreateUsingPhraseList()
		{
			return new List<String>() { "ウ", "ル", "ト", "ラ", "ソ" };
		}

		/// <summary>
		/// 完成フレーズリストを生成します。
		/// </summary>
		/// <returns>完成フレーズリスト</returns>
		protected override IEnumerable<Int32> _CreateCompletePhraseIndexList()
		{
			return new[] { 0, 1, 2, 3, 4, 0, 1 };
		}

		/// <summary>
		/// 掛け声を生成します。
		/// </summary>
		/// <returns>掛け声</returns>
		protected override String _CreateShout()
		{
			return  "！ ＼ハァイ！／";
		}
	}
}
