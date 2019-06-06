using System;
using System.Collections.Generic;

namespace Zundoko.Songs.Implements
{
	/// <summary>
	/// 歌：欽ちゃん
	/// </summary>
	public class Kinchan : BaseSong
	{
		/// <summary>
		/// 使用フレーズリストを生成します。
		/// </summary>
		/// <returns>使用フレーズリスト</returns>
		protected override List<string> _CreateUsingPhraseList()
		{
			return new List<String>() { "８", "時", "だ", "ョ", "！", };
		}

		/// <summary>
		/// 完成フレーズリストを生成します。
		/// </summary>
		/// <returns>完成フレーズリスト</returns>
		protected override IEnumerable<Int32> _CreateCompletePhraseIndexList()
		{
			// ８ 時 だ ョ ！
			return new[] { 0, 1, 2, 3, 4 };
		}

		/// <summary>
		/// 掛け声を生成します。
		/// </summary>
		/// <returns>掛け声</returns>
		protected override string _CreateShout()
		{
			return "＼全員集合／";
		}
	}
}
