using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Zundoko.Songs;

namespace Zundoko
{
    /// <summary>
    /// アルバム
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Singletonインスタンス
        /// </summary>
        private static Album _singleton;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        private Album()
        {
            // do nothing
        }

        /// <summary>
        /// 歌リストを取得します。
        /// </summary>
        public IEnumerable<ISong> Songs { get; private set; }

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        /// <returns></returns>
        public static Album GetInstance()
        {
            if (_singleton == null)
            {
                // 歌リストを生成
                var songs = new List<ISong>();
                foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (!type.IsAbstract && type.GetInterfaces().Contains(typeof(ISong)))
                    {
                        // 状態インタフェースを実装している具象クラスをインスタンス化して格納
                        songs.Add((ISong)Activator.CreateInstance(type));
                    }
                }

                // アルバム生成
                _singleton = new Album() { Songs = songs };
            }
            return _singleton;
        }

        /// <summary>
        /// 歌を検索します。
        /// </summary>
        /// <param name="title">タイトル（前方一致）</param>
        /// <returns>歌オブジェクト</returns>
        public ISong FindSong(string title) =>
            // クラス名が指定文字列で始まる歌オブジェクトを返す
            Songs.ToList().Find((song) => song.GetType().Name.ToUpper().StartsWith(title.ToUpper()));
    }
}
