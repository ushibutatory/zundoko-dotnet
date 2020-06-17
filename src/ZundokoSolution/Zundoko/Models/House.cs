using System;
using System.Collections.Generic;

namespace Zundoko.Models
{
    /// <summary>
    /// 会場
    /// </summary>
    public class House
    {
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
        public int LimitCount { get; set; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="singer">歌手オブジェクト</param>
        /// <param name="audience">観客オブジェクト</param>
        public House(Singer singer, Audience audience)
        {
            Singer = singer;
            Audience = audience;
            LimitCount = 0;
        }

        /// <summary>
        /// 歌を演奏します。
        /// </summary>
        /// <param name="song">歌オブジェクト</param>
        public void Play(ISong song)
        {
            if (song == null)
                throw new InvalidOperationException("引数[song]がnullです。");
            if (Singer == null)
                throw new Exception("Singerプロパティが未設定です。");
            if (Audience == null)
                throw new Exception("Audienceプロパティが未設定です。");

            // 歌を設定
            Singer.SetSong(song);
            Audience.SetSong(song);

            var phraseList = new List<string>();
            var count = 0;
            while (!Audience.IsSatisfied)
            {
                // 歌手からフレーズを取得
                var phrase = Singer.Sing();

                // フレーズ表示
                // TODO: 直接Consoleを呼び出さないようにする
                Console.Write(phrase);

                // リスト追加
                phraseList.Add(phrase);
                count++;

                if (song.IsCompleted(phraseList))
                {
                    // フレーズが完成したら、観客から掛け声を取得
                    var shout = Audience.Shout();

                    // 掛け声表示
                    Console.WriteLine(shout);

                    // 回数表示
                    Console.WriteLine($"{count:#,##0}回で完成しました。");
                }
                else
                {
                    if (LimitCount > 0 && count >= LimitCount)
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
}
