using System;
using System.Collections.Generic;
using System.Linq;

namespace Zundoko.Songs
{
	/// <summary>
	/// 歌基底クラス
	/// </summary>
	public abstract class BaseSong : ISong
	{
		#region Private変数
		/// <summary>
		/// 使用するフレーズリスト
		/// </summary>
		private List<String> _usingPhraseList;

		/// <summary>
		/// 完成フレーズリスト
		/// </summary>
		private List<String> _completePhraseList;

		/// <summary>
		/// 完成時の掛け声
		/// </summary>
		private String _shout;
		#endregion

		#region プロパティ
		/// <summary>
		/// 使用フレーズリストを取得します。
		/// </summary>
		public List<String> UsingPhraseList
		{
			get
			{
				if (this._usingPhraseList == null)
				{
					// 初回取得
					this._usingPhraseList = this._CreateUsingPhraseList();
				}
				return this._usingPhraseList;
			}
		}

		/// <summary>
		/// 完成フレーズリストを取得します。
		/// </summary>
		public List<String> CompletePhraseList
		{
			get
			{
				if (this._completePhraseList == null)
				{
					// 初回取得
					var list = this._CreateCompletePhraseIndexList();

					this._completePhraseList = list.Select((i) => this.UsingPhraseList[i]).ToList();
				}
				return this._completePhraseList;
			}
		}

		/// <summary>
		/// 完成フレーズ数を取得します。
		/// </summary>
		public Int32 CompletePhraseCount
		{
			get
			{
				return this.CompletePhraseList.Count;
			}
		}

		/// <summary>
		/// 掛け声を取得します。
		/// </summary>
		public String Shout
		{
			get
			{
				if (String.IsNullOrEmpty(this._shout))
				{
					// 初回取得
					this._shout = this._CreateShout();
				}
				return this._shout;
			}
		}
		#endregion

		#region Publicメソッド
		/// <summary>
		/// フレーズが完成しているかどうかを取得します。
		/// </summary>
		/// <param name="phraseList">フレーズリスト</param>
		/// <returns>完成しているかどうか</returns>
		public Boolean IsCompleted(IList<String> phraseList)
		{
			// 判定用の区切り文字（フレーズの前後を混合しないように）
			var separator = Environment.NewLine;

			// 直近のフレーズを結合
			var input = String.Join(separator, phraseList.Skip(phraseList.Count - this.CompletePhraseCount));

			// 完成フレーズを結合
			var answer = String.Join(separator, this._completePhraseList);

			return input == answer;
		}
		#endregion

		#region Protectedメソッド
		/// <summary>
		/// 使用フレーズリストを生成します。
		/// </summary>
		/// <returns>使用フレーズリスト</returns>
		protected abstract List<String> _CreateUsingPhraseList();

		/// <summary>
		/// 完成フレーズのインデックスリストを生成します。
		/// </summary>
		/// <returns>完成フレーズのインデックスリスト</returns>
		protected abstract IEnumerable<Int32> _CreateCompletePhraseIndexList();

		/// <summary>
		/// 掛け声を生成します。
		/// </summary>
		/// <returns>掛け声</returns>
		protected abstract String _CreateShout();
		#endregion
	}
}
