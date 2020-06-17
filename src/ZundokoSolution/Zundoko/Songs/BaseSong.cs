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
        /// <summary>
        /// 使用するフレーズリスト
        /// </summary>
        private IList<string> _usingPhraseList;

        /// <summary>
        /// 完成フレーズリスト
        /// </summary>
        private IEnumerable<string> _completePhraseList;

        /// <summary>
        /// 完成時の掛け声
        /// </summary>
        private string _shout;

        /// <summary>
        /// 使用フレーズリストを取得します。
        /// </summary>
        public IList<string> UsingPhraseList
        {
            get
            {
                if (_usingPhraseList == null)
                {
                    // 初回取得
                    _usingPhraseList = _CreateUsingPhraseList();
                }
                return _usingPhraseList;
            }
        }

        /// <summary>
        /// 完成フレーズリストを取得します。
        /// </summary>
        public IEnumerable<string> CompletePhraseList
        {
            get
            {
                if (_completePhraseList == null)
                {
                    // 初回取得
                    var list = _CreateCompletePhraseIndexList();

                    _completePhraseList = list.Select((i) => UsingPhraseList[i]).ToList();
                }
                return _completePhraseList;
            }
        }

        /// <summary>
        /// 完成フレーズ数を取得します。
        /// </summary>
        public int CompletePhraseCount => CompletePhraseList.Count();

        /// <summary>
        /// 掛け声を取得します。
        /// </summary>
        public string ShoutPhrase
        {
            get
            {
                if (string.IsNullOrEmpty(_shout))
                {
                    // 初回取得
                    _shout = _CreateShout();
                }
                return _shout;
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
            var answer = string.Join(separator, _completePhraseList);

            return input == answer;
        }

        /// <summary>
        /// 使用フレーズリストを生成します。
        /// </summary>
        /// <returns>使用フレーズリスト</returns>
        protected abstract List<string> _CreateUsingPhraseList();

        /// <summary>
        /// 完成フレーズのインデックスリストを生成します。
        /// </summary>
        /// <returns>完成フレーズのインデックスリスト</returns>
        protected abstract IEnumerable<int> _CreateCompletePhraseIndexList();

        /// <summary>
        /// 掛け声を生成します。
        /// </summary>
        /// <returns>掛け声</returns>
        protected abstract string _CreateShout();
    }
}
