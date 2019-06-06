using System;
using System.Collections.Generic;
using System.Text;

namespace Zundoko.Songs.Implements
{
	/// <summary>
	/// 歌：熱情の律動
	/// </summary>
	public class NetsujoRhythm : BaseSong
	{
		/// <summary>
		/// 使用フレーズリストを生成します。
		/// </summary>
		/// <returns>使用フレーズリスト</returns>
		protected override List<String> _CreateUsingPhraseList()
		{
			return new List<String>() { "ﾃﾞﾝﾃﾞ","ﾃﾞｯﾃﾞ","ﾃﾞﾚ" };
		}

		/// <summary>
		/// 完成フレーズリストを生成します。
		/// </summary>
		/// <returns>完成フレーズリスト</returns>
		protected override IEnumerable<Int32> _CreateCompletePhraseIndexList()
		{
			return new[] { 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2 };
		}

		/// <summary>
		/// 掛け声を生成します。
		/// </summary>
		/// <returns>掛け声</returns>
		protected override String _CreateShout()
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
