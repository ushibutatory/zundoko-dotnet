using System;
using System.Collections.Generic;

namespace Zundoko.Songs
{
	/// <summary>
	/// 歌インタフェース
	/// </summary>
	public interface ISong
	{
		/// <summary>
		/// 完成フレーズ数を取得します。
		/// </summary>
		Int32 CompletePhraseCount { get; }

		/// <summary>
		/// 使用するフレーズリストを取得します。
		/// </summary>
		List<String> UsingPhraseList { get; }

		/// <summary>
		/// 掛け声を取得します。
		/// </summary>
		String Shout { get; }

		/// <summary>
		/// フレーズが完成しているかどうかを取得します。
		/// </summary>
		/// <param name="phraseList">フレーズリスト</param>
		/// <returns>完成しているかどうか</returns>
		Boolean IsCompleted(IList<String> phraseList);
	}
}
