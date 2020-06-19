namespace Zundoko.Core.Models.Abstracts
{
    /// <summary>
    /// 会場インタフェース
    /// </summary>
    public interface IHouse
    {
        /// <summary>
        /// 歌手を取得します。
        /// </summary>
        ISinger Singer { get; }

        /// <summary>
        /// 観客を取得します。
        /// </summary>
        IAudience Audience { get; }

        /// <summary>
        /// 歌を演奏します。
        /// </summary>
        /// <param name="song">歌</param>
        /// <param name="limitCount">試行回数</param>
        public PlayResult Play(ISong song, int limitCount);
    }
}
