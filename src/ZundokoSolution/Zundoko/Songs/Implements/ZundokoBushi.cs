using System;
using System.Collections.Generic;

namespace Zundoko.Songs.Implements
{
	/// <summary>
	/// 歌：ズンドコ節
	/// </summary>
	public class ZundokoBushi : BaseSong
	{
		/// <summary>
		/// 使用フレーズリストを生成します。
		/// </summary>
		/// <returns>使用フレーズリスト</returns>
		protected override List<String> _CreateUsingPhraseList()
		{
			return new List<String>() { "ズン", "ドコ" };
		}

		/// <summary>
		/// 完成フレーズリストを生成します。
		/// </summary>
		/// <returns>完成フレーズリスト</returns>
		protected override IEnumerable<Int32> _CreateCompletePhraseIndexList()
		{
			// ズン ズン ズン ズン ドコ
			return new[] { 0, 0, 0, 0, 1 };
		}

		/// <summary>
		/// 掛け声を生成します。
		/// </summary>
		/// <returns>掛け声</returns>
		protected override String _CreateShout()
		{
			return "＼キ・ヨ・シ！／";
		}
	}
}
