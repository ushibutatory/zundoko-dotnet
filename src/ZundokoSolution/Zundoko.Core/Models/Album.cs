﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models
{
    /// <summary>
    /// アルバム
    /// </summary>
    public class Album : IAlbum
    {
        private readonly ILogger<Album> _logger;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public Album(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Album>();

            // 歌リストを生成
            Songs = Assembly.GetExecutingAssembly().GetTypes()
                        .Where(type => !type.IsAbstract && type.GetInterfaces().Contains(typeof(ISong)))
                        .Select(type => (ISong)Activator.CreateInstance(type));
        }

        /// <summary>
        /// 歌リストを取得します。
        /// </summary>
        public IEnumerable<ISong> Songs { get; }

        /// <summary>
        /// 歌を検索します。
        /// </summary>
        /// <param name="playName">実行名（前方一致）</param>
        /// <returns>歌オブジェクト</returns>
        public ISong FindSong(string playName)
            => Songs.ToList().Find((song) => song.PlayName.ToUpper().StartsWith(playName.ToUpper()));
    }
}
