using System.Collections.Generic;
using System.Text;

namespace Zundoko.Songs.Implements
{
    /// <summary>
    /// 歌：熱情の律動
    /// </summary>
    public class NetsujoRhythm : BaseSong
    {
        protected override List<string> _CreateUsingPhraseList()
            => new List<string>() { "ﾃﾞﾝﾃﾞ", "ﾃﾞｯﾃﾞ", "ﾃﾞﾚ" };

        protected override IEnumerable<int> _CreateCompletePhraseIndexList()
            => new[] { 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2 };

        protected override string _CreateShout()
        {
            var text = new StringBuilder();
            text.AppendLine();
            text.AppendLine("　　　　∧＿∧");
            text.AppendLine("　　　（　´Д｀）");
            text.AppendLine("　　γＵ～''ヽヽ");
            text.AppendLine("　　 !　 C≡≡O＝亜 　ﾃﾞﾝﾃﾞﾃﾞｯﾃﾞﾃﾞﾚﾃﾞﾝﾃﾞﾃﾞｯﾃﾞﾃﾞﾚﾃﾞﾝﾃﾞﾃﾞｯﾃﾞﾃﾞﾚﾃﾞﾝﾃﾞﾃﾞｯﾃﾞﾃﾞﾚ");
            text.AppendLine("　　　`（＿）~丿");
            text.AppendLine("　　　　　　∪");
            text.AppendLine("　　　　♪");
            text.AppendLine("　　　　　　♪　　ﾍｴｰｴ ｴｰｴｴｴｰ");
            text.AppendLine("　　　( '∀`)　　　 ｴｰｴｴｰ ｳｰｳｫｰｵｵｵｫｰ");
            text.AppendLine("　（(と 　　 つ　　ﾗﾗﾗﾗ ﾗｧｰｱｰｱｰｱｰ");
            text.AppendLine("（( ⊂,,　 ノﾞ");
            text.AppendLine("　　　（_,/,,");
            text.AppendLine("　　　♪　　　 /");
            text.AppendLine("　　　＿＿＿/　♪");
            text.AppendLine("　　［●|圖|●］　　♪");
            text.AppendLine("　　￣￣￣￣");
            text.AppendLine("　　　　'∧　　∧♪　　♪　　ﾅｧｫｫｫｫ ｵｫｫｫｫ");
            text.AppendLine("　　　　( ；´Д｀）／　　　　ｻｳｪｪｪｱｧｧｧｧ ｱｧｧｧｧ ｱｧｧｧｧ ｱｧｧｧｧ");
            text.AppendLine("　　　　　♪ 　　　　　　　　ｲｪｪｪｪｪｪｪｪｪｩｩｱｧ…");
            text.AppendLine("　　　♪　　　 /");
            text.AppendLine("　　　＿＿＿/　♪");
            text.AppendLine("　　［●|圖|●］　　♪");
            text.AppendLine("　　￣￣￣￣");
            text.AppendLine("　　　 _ 　∩　　ﾍｪｰﾗﾛﾛｫｰﾙﾉｫｰﾉﾅｰｧｵｵｫｰ");
            text.AppendLine("　　(　ﾟ∀ﾟ)彡　ｱﾉﾉｱｲﾉﾉｫｵｵｵｫｰﾔ");
            text.AppendLine("　　(　 ⊂彡 　 ﾗﾛﾗﾛﾗﾛﾘｨﾗﾛﾛｰ");
            text.AppendLine("　 　|　　|　　　ﾗﾛﾗﾛﾗﾛﾘｨﾗﾛ");
            text.AppendLine("　 　し⌒Ｊ　　 ﾋｨｰｨｼﾞﾔﾛﾗﾙﾘｰﾛﾛﾛｰ");
            return text.ToString();
        }
    }
}
