namespace Zundoko.Core.Models.Abstracts
{
    /// <summary>
    /// 歌手インタフェース
    /// </summary>
    public interface ISinger
    {
        /// <summary>
        /// 歌を取得します。
        /// </summary>
        ISong Song { get; }

        /// <summary>
        /// 歌う準備をします。
        /// </summary>
        /// <param name="song">歌</param>
        void Standby(ISong song);

        /// <summary>
        /// 1フレーズ取得します。
        /// </summary>
        /// <returns>フレーズ</returns>
        string Sing();
    }
}
