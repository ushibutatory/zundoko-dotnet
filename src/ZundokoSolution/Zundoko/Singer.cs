using System;
using Zundoko.Songs;

namespace Zundoko
{
	/// <summary>
	/// 歌手クラス
	/// </summary>
	public class Singer
	{
		#region Private変数
		/// <summary>
		/// 乱数オブジェクト
		/// </summary>
		private readonly Random _random;
		#endregion

		#region コンストラクタ
		/// <summary>
		/// 新しいインスタンスを生成します。
		/// </summary>
		public Singer()
		{
			// 乱数初期化
			this._random = new Random();
		}
		#endregion

		#region プロパティ
		/// <summary>
		/// 歌を取得します。
		/// </summary>
		public ISong Song { get; private set; }
		#endregion

		#region Publicメソッド
		/// <summary>
		/// 歌を設定します。
		/// </summary>
		/// <param name="song">歌オブジェクト</param>
		public void SetSong(ISong song)
		{
			this.Song = song;
		}

		/// <summary>
		/// 1フレーズ取得します。
		/// </summary>
		/// <returns>フレーズ</returns>
		public String Sing()
		{
			if (this.Song == null)
			{
				throw new InvalidOperationException("Songプロパティが未設定です。");
			}
			else
			{
				// ランダムにインデックスを生成
				var index = this._random.Next(0, this.Song.UsingPhraseList.Count);

				// フレーズを返す
				return this.Song.UsingPhraseList[index];
			}
		}
		#endregion
	}
}
