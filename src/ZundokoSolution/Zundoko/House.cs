using System;
using System.Collections.Generic;
using Zundoko.Songs;

namespace Zundoko
{
	/// <summary>
	/// 会場クラス
	/// </summary>
	public class House
	{
		#region プロパティ
		/// <summary>
		/// 歌手を取得します。
		/// </summary>
		public Singer Singer { get; private set; }

		/// <summary>
		/// 観客を取得します。
		/// </summary>
		public Audience Audience { get; private set; }

		/// <summary>
		/// 試行回数を取得または設定します。
		/// </summary>
		public Int32 LimitCount { get; set; }
		#endregion

		#region コンストラクタ
		/// <summary>
		/// 新しいインスタンスを生成します。
		/// </summary>
		/// <param name="singer">歌手オブジェクト</param>
		/// <param name="audience">観客オブジェクト</param>
		public House(Singer singer, Audience audience)
		{
			this.Singer = singer;
			this.Audience = audience;
			this.LimitCount = 0;
		}
		#endregion

		#region Publicメソッド
		/// <summary>
		/// 歌を演奏します。
		/// </summary>
		/// <param name="song">歌オブジェクト</param>
		public void Play(ISong song)
		{
			if (song == null)
			{
				throw new InvalidOperationException("引数[song]がnullです。");
			}
			else if (this.Singer == null)
			{
				throw new Exception("Singerプロパティが未設定です。");
			}
			else if (this.Audience == null)
			{
				throw new Exception("Audienceプロパティが未設定です。");
			}
			else
			{
				// 歌を設定
				this.Singer.SetSong(song);
				this.Audience.SetSong(song);

				var phraseList = new List<String>();
				var count = 0;
				while (!this.Audience.IsSatisfied)
				{
					// 歌手からフレーズを取得
					var phrase = this.Singer.Sing();

					// フレーズ表示
					Console.Write(phrase);

					// リスト追加
					phraseList.Add(phrase);
					count++;

					if (song.IsCompleted(phraseList))
					{
						// フレーズが完成したら、観客から掛け声を取得
						var shout = this.Audience.Shout();

						// 掛け声表示
						Console.WriteLine(shout);

						// 回数表示
						Console.WriteLine(String.Format("{0:#,##0}回で完成しました。", count));
					}
					else
					{
						if (this.LimitCount > 0 && count >= LimitCount)
						{
							// 試行回数を超えた場合
							Console.WriteLine();
							Console.WriteLine("完成しませんでした……。");
							break;
						}
						else
						{
							// 試行回数以内の場合
							if (phraseList.Count > song.CompletePhraseCount)
							{
								// 完成フレーズ以上のフレーズは先頭から削除
								phraseList.RemoveAt(0);
							}
						}
					}
				}
			}
		}
		#endregion
	}
}
