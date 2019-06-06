using System;
using Zundoko.Songs;

namespace Zundoko
{
	/// <summary>
	/// 観客クラス
	/// </summary>
	public class Audience
	{
		#region コンストラクタ
		/// <summary>
		/// 新しいインスタンスを生成します。
		/// </summary>
		public Audience()
		{
			this.IsSatisfied = false;
		}
		#endregion

		#region プロパティ
		/// <summary>
		/// 歌を取得します。
		/// </summary>
		public ISong Song { get; private set; }

		/// <summary>
		/// 満足しているかどうかを取得します。
		/// </summary>
		public Boolean IsSatisfied { get; private set; }
		#endregion

		#region Publicメソッド
		/// <summary>
		/// 歌を設定します。
		/// </summary>
		/// <param name="song">歌オブジェクト</param>
		public void SetSong(ISong song)
		{
			this.Song = song;

			// 歌が変わったら満足度を戻す
			this.IsSatisfied = false;
		}

		/// <summary>
		/// 叫びます。
		/// </summary>
		/// <returns>魂の掛け声</returns>
		public String Shout()
		{
			if (this.Song == null)
			{
				throw new InvalidOperationException("Songプロパティが未設定です。");
			}
			else
			{
				// 満足
				this.IsSatisfied = true;

				// 掛け声を返す
				return this.Song.Shout;
			}
		}
		#endregion
	}
}
