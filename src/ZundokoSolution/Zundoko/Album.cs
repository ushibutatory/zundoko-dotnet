using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Zundoko.Songs;

namespace Zundoko
{
	/// <summary>
	/// アルバムクラス
	/// </summary>
	public class Album
	{
		#region Private変数
		/// <summary>
		/// アルバムオブジェクト
		/// </summary>
		/// <remarks>
		/// singleton
		/// </remarks>
		private static Album _album;
		#endregion

		#region コンストラクタ
		/// <summary>
		/// 新しいインスタンスを生成します。
		/// </summary>
		/// <remarks>非公開</remarks>
		private Album()
		{

		}
		#endregion

		#region プロパティ
		/// <summary>
		/// 歌リストを取得します。
		/// </summary>
		public List<ISong> SongList { get; private set; }
		#endregion

		#region Publicメソッド
		/// <summary>
		/// インスタンスを取得します。
		/// </summary>
		/// <returns></returns>
		public static Album GetInstance()
		{
			if (_album == null)
			{
				// 歌リストを生成
				var songList = new List<ISong>();
				foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
				{
					if (!type.IsAbstract && type.GetInterfaces().Contains(typeof(ISong)))
					{
						// 状態インタフェースを実装している具象クラスをインスタンス化して格納
						songList.Add((ISong)Activator.CreateInstance(type));
					}
				}

				// アルバム生成
				_album = new Album() { SongList = songList };
			}
			return _album;
		}

		/// <summary>
		/// 歌を検索します。
		/// </summary>
		/// <param name="title">タイトル（前方一致）</param>
		/// <returns>歌オブジェクト</returns>
		public ISong FindSong(String title)
		{
			// クラス名が指定文字列で始まる歌オブジェクトを返す
			return this.SongList.Find((song) => song.GetType().Name.ToUpper().StartsWith(title.ToUpper()));
		}
		#endregion
	}
}
