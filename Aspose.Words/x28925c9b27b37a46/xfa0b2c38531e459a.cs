using System.Text;
using x6c95d9cf46ff5f25;

namespace x28925c9b27b37a46;

internal class xfa0b2c38531e459a
{
	private static readonly string[] x53e153cf0b5e7199 = new string[46]
	{
		"ン", "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ",
		"コ", "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ",
		"ト", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ",
		"ホ", "マ", "ミ", "ム", "メ", "モ", "ヤ", "ユ", "ヨ", "ラ",
		"リ", "ル", "レ", "ロ", "ワ", "ヲ"
	};

	private static readonly string[] x936a142f1dd5c130 = new string[48]
	{
		"ン", "イ", "ロ", "ハ", "ニ", "ホ", "ヘ", "ト", "チ", "リ",
		"ヌ", "ル", "ヲ", "ワ", "カ", "ヨ", "タ", "レ", "ソ", "ツ",
		"ネ", "ナ", "ラ", "ム", "ウ", "ヰ", "ノ", "オ", "ク", "ヤ",
		"マ", "ケ", "フ", "コ", "エ", "テ", "ア", "サ", "キ", "ユ",
		"メ", "ミ", "シ", "ヱ", "ヒ", "モ", "セ", "ス"
	};

	private static readonly string[] x0d101d285ce14c25 = new string[10] { "〇", "一", "二", "三", "四", "五", "六", "七", "八", "九" };

	private static readonly string[] x49213b5f1ce7e996 = new string[4] { "", "十", "百", "千" };

	private static readonly string[] xaf3b3e9af31b3a4d = new string[3] { "", "万", "億" };

	private xfa0b2c38531e459a()
	{
	}

	internal static string x5678095b61a04d77(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != 0)
		{
			return x53e153cf0b5e7199[xbcea506a33cf9111 % x53e153cf0b5e7199.Length];
		}
		return "0";
	}

	internal static string x2da9ca81b55b8a50(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != 0)
		{
			return x936a142f1dd5c130[xbcea506a33cf9111 % x936a142f1dd5c130.Length];
		}
		return "0";
	}

	internal static string x7562d16b881cb8b6(int xbcea506a33cf9111, int x9f7a75e344e9464a)
	{
		xd8cce4761dc846ee xd8cce4761dc846ee = xc7e4e5f194aa67cf.xb31c9ef12c64cea9(xbcea506a33cf9111, 1);
		StringBuilder stringBuilder = new StringBuilder();
		for (int num = x9f7a75e344e9464a - xd8cce4761dc846ee.xd44988f225497f3a; num > 0; num--)
		{
			stringBuilder.Append(x0d101d285ce14c25[0]);
		}
		for (int num2 = xd8cce4761dc846ee.xd44988f225497f3a - 1; num2 >= 0; num2--)
		{
			stringBuilder.Append(x0d101d285ce14c25[xd8cce4761dc846ee.get_xe6d4b1b411ed94b5(num2)]);
		}
		return stringBuilder.ToString();
	}

	internal static string xb488023801725051(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 < 10)
		{
			return x0d101d285ce14c25[xbcea506a33cf9111];
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = xbcea506a33cf9111 >= 10000;
		xd8cce4761dc846ee xd8cce4761dc846ee = xc7e4e5f194aa67cf.xb31c9ef12c64cea9(xbcea506a33cf9111, 4);
		for (int num = xd8cce4761dc846ee.xd44988f225497f3a - 1; num >= 0; num--)
		{
			xd8cce4761dc846ee xd8cce4761dc846ee2 = xc7e4e5f194aa67cf.xb31c9ef12c64cea9(xd8cce4761dc846ee.get_xe6d4b1b411ed94b5(num), 1);
			for (int num2 = xd8cce4761dc846ee2.xd44988f225497f3a - 1; num2 >= 0; num2--)
			{
				int num3 = xd8cce4761dc846ee2.get_xe6d4b1b411ed94b5(num2);
				if (num3 != 0)
				{
					if (num3 > 1 || num2 == 0 || flag)
					{
						stringBuilder.Append(x0d101d285ce14c25[num3]);
					}
					stringBuilder.Append(x49213b5f1ce7e996[num2]);
					flag = false;
				}
			}
			stringBuilder.Append(xaf3b3e9af31b3a4d[num]);
		}
		return stringBuilder.ToString();
	}
}
