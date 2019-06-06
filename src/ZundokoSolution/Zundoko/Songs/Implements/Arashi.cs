using System;
using System.Collections.Generic;
using System.Text;

namespace Zundoko.Songs.Implements
{
	/// <summary>
	/// 歌：嵐
	/// </summary>
	public class Arashi : BaseSong
	{
		/// <summary>
		/// 使用フレーズリストを生成します。
		/// </summary>
		/// <returns>使用フレーズリスト</returns>
		protected override List<String> _CreateUsingPhraseList()
		{
			return new List<String>() { "A", "RA", "SHI", " " };
		}

		/// <summary>
		/// 完成フレーズリストを生成します。
		/// </summary>
		/// <returns>完成フレーズリスト</returns>
		protected override IEnumerable<Int32> _CreateCompletePhraseIndexList()
		{
			// ARASHI ARASHI
			return new[] { 0, 1, 2, 3, 0, 1, 2 };
		}

		/// <summary>
		/// 掛け声を生成します。
		/// </summary>
		/// <returns>掛け声</returns>
		protected override String _CreateShout()
		{
			return " for dream...";
		}
	}
}
