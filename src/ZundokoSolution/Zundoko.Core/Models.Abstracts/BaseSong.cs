using System;
using System.Collections.Generic;
using System.Linq;

namespace Zundoko.Core.Models.Abstracts
{
    /// <summary>
    /// 歌基底クラス
    /// </summary>
    public abstract class BaseSong : ISong
    {
        /// <summary>
        /// 使用するフレーズリスト
        /// </summary>
        private IEnumerable<string> _phrases;

        /// <summary>
        /// 完成フレーズリスト
        /// </summary>
        private IEnumerable<string> _completePhrases;

        /// <summary>
        /// 完成時の掛け声
        /// </summary>
        private string _lastPhrase;

        /// <summary>
        /// 実行名を取得します。
        /// </summary>
        public string PlayName => GetType().Name;

        /// <summary>
        /// 曲名を取得します。
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// 使用フレーズリストを取得します。
        /// </summary>
        public IEnumerable<string> Phrases
        {
            get
            {
                if (_phrases == null)
                {
                    // 初回取得
                    _phrases = _GetAllPhrases();
                }
                return _phrases;
            }
        }

        /// <summary>
        /// 完成フレーズリストを取得します。
        /// </summary>
        public IEnumerable<string> CompletePhrases
        {
            get
            {
                if (_completePhrases == null)
                {
                    // 初回取得
                    var list = _GetCompletePhraseIndexList();

                    _completePhrases = list.Select((i) => Phrases.ElementAt(i)).ToList();
                }
                return _completePhrases;
            }
        }

        /// <summary>
        /// 完成フレーズ数を取得します。
        /// </summary>
        public int CompletePhraseCount => CompletePhrases.Count();

        /// <summary>
        /// 掛け声を取得します。
        /// </summary>
        public string LastPhrase
        {
            get
            {
                if (string.IsNullOrEmpty(_lastPhrase))
                {
                    // 初回取得
                    _lastPhrase = _GetLastPhrase();
                }
                return _lastPhrase;
            }
        }

        /// <summary>
        /// フレーズが完成しているかどうかを取得します。
        /// </summary>
        /// <param name="phraseList">フレーズリスト</param>
        /// <returns>完成しているかどうか</returns>
        public bool IsCompleted(IEnumerable<string> phraseList)
        {
            // 判定用の区切り文字（フレーズの前後を混合しないように）
            var separator = Environment.NewLine;

            // 直近のフレーズを結合
            var input = string.Join(separator, phraseList.Skip(phraseList.Count() - CompletePhraseCount));

            // 完成フレーズを結合
            var answer = string.Join(separator, _completePhrases);

            return input == answer;
        }

        /// <summary>
        /// 使用フレーズリストを生成します。
        /// </summary>
        /// <returns>使用フレーズリスト</returns>
        protected abstract IEnumerable<string> _GetAllPhrases();

        /// <summary>
        /// 完成フレーズのインデックスリストを生成します。
        /// </summary>
        /// <returns>完成フレーズのインデックスリスト</returns>
        protected abstract IEnumerable<int> _GetCompletePhraseIndexList();

        /// <summary>
        /// 掛け声を生成します。
        /// </summary>
        /// <returns>掛け声</returns>
        protected abstract string _GetLastPhrase();
    }
}
