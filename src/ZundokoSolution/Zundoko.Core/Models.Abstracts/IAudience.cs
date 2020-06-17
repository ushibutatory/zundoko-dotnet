namespace Zundoko.Core.Models.Abstracts
{
    /// <summary>
    /// 観客インタフェース
    /// </summary>
    public interface IAudience
    {
        /// <summary>
        /// 歌を取得します。
        /// </summary>
        ISong Song { get; }

        /// <summary>
        /// 満足しているかどうかを取得します。
        /// </summary>
        bool IsSatisfied { get; }

        /// <summary>
        /// 歌を聴く準備をします。
        /// </summary>
        /// <param name="song">歌</param>
        void Standby(ISong song);

        /// <summary>
        /// 叫びます。
        /// </summary>
        /// <returns>掛け声</returns>
        string Shout();
    }
}
