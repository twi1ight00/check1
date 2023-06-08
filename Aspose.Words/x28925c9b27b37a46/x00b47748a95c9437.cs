using System.Text;
using Aspose.Words;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x28925c9b27b37a46;

internal class x00b47748a95c9437
{
	private const char x94bff8f206a26eed = 'm';

	private const int x69a75dab820ebf0f = 26;

	private const int x66731aa13ba5b43b = 7;

	private const int x9c0e21e11f0e2fde = -1;

	private static readonly string[,] x4ec673743b3a1542 = new string[3, 10]
	{
		{ "", "i", "ii", "iii", "iv", "v", "vi", "vii", "viii", "ix" },
		{ "", "x", "xx", "xxx", "xl", "l", "lx", "lxx", "lxxx", "xc" },
		{ "", "c", "cc", "ccc", "cd", "d", "dc", "dcc", "dccc", "cm" }
	};

	private static readonly string[] x91ceca93c35413b1 = new string[21]
	{
		"0", "①", "②", "③", "④", "⑤", "⑥", "⑦", "⑧", "⑨",
		"⑩", "⑪", "⑫", "⑬", "⑭", "⑮", "⑯", "⑰", "⑱", "⑲",
		"⑳"
	};

	private static readonly char[][] x1e876be868362346 = new char[3][]
	{
		new char[9] { 'א', 'ב', 'ג', 'ד', 'ה', 'ו', 'ז', 'ח', 'ט' },
		new char[9] { 'י', 'כ', 'ל', 'מ', 'נ', 'ס', 'ע', 'פ', 'צ' },
		new char[3] { 'ק', 'ר', 'ש' }
	};

	private x00b47748a95c9437()
	{
	}

	internal static string x19fa8583862b446b(int xbcea506a33cf9111, NumberStyle x3f5f7cef69e188c0, bool x3b747bc7816d8768)
	{
		return x3f5f7cef69e188c0 switch
		{
			NumberStyle.Aiueo => xfa0b2c38531e459a.x5678095b61a04d77(xbcea506a33cf9111), 
			NumberStyle.Arabic => x4951f3b0fa8ff414(xbcea506a33cf9111), 
			NumberStyle.ArabicFullWidth => x27ab01a93ec90e53(xbcea506a33cf9111), 
			NumberStyle.Bullet => "", 
			NumberStyle.Hebrew1 => x560df454e1c6c383(xbcea506a33cf9111), 
			NumberStyle.Hex => x568dbad6f95bbd5a(xbcea506a33cf9111), 
			NumberStyle.Iroha => xfa0b2c38531e459a.x2da9ca81b55b8a50(xbcea506a33cf9111), 
			NumberStyle.Kanji => xfa0b2c38531e459a.x7562d16b881cb8b6(xbcea506a33cf9111, 0), 
			NumberStyle.KanjiDigit => xfa0b2c38531e459a.xb488023801725051(xbcea506a33cf9111), 
			NumberStyle.LeadingZero => x6432e02c36e715bb(xbcea506a33cf9111), 
			NumberStyle.LowercaseLetter => x57fed9bbbd745fd0(xbcea506a33cf9111), 
			NumberStyle.LowercaseRoman => x5d74074a78cd8d4d(xbcea506a33cf9111), 
			NumberStyle.LowercaseRussian => x83c21010271dcc66(xbcea506a33cf9111), 
			NumberStyle.Number => xce449f9cbc44a7e6.x8b56c53f652e7cf9(xbcea506a33cf9111, x2e4d65ae902c9125: true, x3b747bc7816d8768), 
			NumberStyle.NumberInCircle => x5b0b58896d685170(xbcea506a33cf9111), 
			NumberStyle.NumberInDash => x3ed3445cd950c5a7(xbcea506a33cf9111), 
			NumberStyle.Ordinal => xc2d254f380ba6f69(xbcea506a33cf9111), 
			NumberStyle.OrdinalText => xce449f9cbc44a7e6.x8b56c53f652e7cf9(xbcea506a33cf9111, x2e4d65ae902c9125: false, x3b747bc7816d8768), 
			NumberStyle.UppercaseLetter => x6c273a820361ca8c(xbcea506a33cf9111), 
			NumberStyle.UppercaseRoman => x6e5ce6c29c99a16a(xbcea506a33cf9111), 
			NumberStyle.UppercaseRussian => x00f1a589d102c1de(xbcea506a33cf9111), 
			NumberStyle.ChicagoManual => x573410bbe9969465(xbcea506a33cf9111), 
			NumberStyle.None => "", 
			_ => x4951f3b0fa8ff414(xbcea506a33cf9111), 
		};
	}

	internal static int xcd4c71cf08e97198(string xb41faee6912a2313)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313) || xb41faee6912a2313.Length > 7)
		{
			return -1;
		}
		long num = 0L;
		for (int i = 0; i < xb41faee6912a2313.Length - 1; i++)
		{
			num += x0d299f323d241756.x69b84707f222de4b(xb41faee6912a2313[i]) + 1;
			num *= 26;
		}
		num += x0d299f323d241756.x69b84707f222de4b(xb41faee6912a2313[xb41faee6912a2313.Length - 1]);
		if (num > int.MaxValue)
		{
			return -1;
		}
		return (int)num;
	}

	internal static string x6a1f74b85bf16c63(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 < 0)
		{
			return null;
		}
		int num = 7;
		StringBuilder stringBuilder = new StringBuilder("FXSHRXX");
		while (xbcea506a33cf9111 >= 0)
		{
			stringBuilder[--num] = (char)(xbcea506a33cf9111 % 26 + 65);
			xbcea506a33cf9111 = xbcea506a33cf9111 / 26 - 1;
		}
		return stringBuilder.ToString(num, 7 - num);
	}

	private static string x3ed3445cd950c5a7(int xbcea506a33cf9111)
	{
		return $"- {xbcea506a33cf9111} -";
	}

	private static string x4951f3b0fa8ff414(int xbcea506a33cf9111)
	{
		return xbcea506a33cf9111.ToString();
	}

	private static string x568dbad6f95bbd5a(int xbcea506a33cf9111)
	{
		return xca004f56614e2431.x3f49ddc503802c37(xbcea506a33cf9111);
	}

	private static string x57fed9bbbd745fd0(int xbcea506a33cf9111)
	{
		return x916600dd1fbb0a1a(xbcea506a33cf9111, "abcdefghijklmnopqrstuvwxyz");
	}

	private static string x6c273a820361ca8c(int xbcea506a33cf9111)
	{
		return x916600dd1fbb0a1a(xbcea506a33cf9111, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
	}

	private static string x83c21010271dcc66(int xbcea506a33cf9111)
	{
		return x916600dd1fbb0a1a(xbcea506a33cf9111, "абвгдежзиклмнопрстуфхцчшщыэюя");
	}

	private static string x00f1a589d102c1de(int xbcea506a33cf9111)
	{
		return x916600dd1fbb0a1a(xbcea506a33cf9111, "АБВГДЕЖЗИКЛМНОПРСТУФХЦЧШЩЫЭЮЯ");
	}

	private static string x573410bbe9969465(int xbcea506a33cf9111)
	{
		return x916600dd1fbb0a1a(xbcea506a33cf9111, "*†‡§");
	}

	private static string x5d74074a78cd8d4d(int xbcea506a33cf9111)
	{
		xd8cce4761dc846ee xd8cce4761dc846ee = xc7e4e5f194aa67cf.xb31c9ef12c64cea9(xbcea506a33cf9111, 3);
		StringBuilder stringBuilder = new StringBuilder();
		if (xd8cce4761dc846ee.xd44988f225497f3a > 1)
		{
			for (int i = 0; i < xd8cce4761dc846ee.get_xe6d4b1b411ed94b5(1); i++)
			{
				stringBuilder.Append('m');
			}
		}
		xd8cce4761dc846ee xd8cce4761dc846ee2 = xc7e4e5f194aa67cf.xb31c9ef12c64cea9(xd8cce4761dc846ee.get_xe6d4b1b411ed94b5(0), 1);
		for (int num = xd8cce4761dc846ee2.xd44988f225497f3a - 1; num >= 0; num--)
		{
			stringBuilder.Append(x4ec673743b3a1542[num, xd8cce4761dc846ee2.get_xe6d4b1b411ed94b5(num)]);
		}
		return stringBuilder.ToString();
	}

	private static string x6e5ce6c29c99a16a(int xbcea506a33cf9111)
	{
		return x5d74074a78cd8d4d(xbcea506a33cf9111).ToUpper();
	}

	private static string xc2d254f380ba6f69(int xbcea506a33cf9111)
	{
		return $"{xbcea506a33cf9111}{x25b7b66490382eae(xbcea506a33cf9111)}";
	}

	private static string x27ab01a93ec90e53(int xbcea506a33cf9111)
	{
		xd8cce4761dc846ee xd8cce4761dc846ee = xc7e4e5f194aa67cf.xb31c9ef12c64cea9(xbcea506a33cf9111, 1);
		StringBuilder stringBuilder = new StringBuilder();
		for (int num = xd8cce4761dc846ee.xd44988f225497f3a - 1; num >= 0; num--)
		{
			stringBuilder.Append((char)(65296 + xd8cce4761dc846ee.get_xe6d4b1b411ed94b5(num)));
		}
		return stringBuilder.ToString();
	}

	private static string x6432e02c36e715bb(int xbcea506a33cf9111)
	{
		return xca004f56614e2431.xeb27807b6e1b03b6(xbcea506a33cf9111);
	}

	private static string x5b0b58896d685170(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 > 20)
		{
			return x4951f3b0fa8ff414(xbcea506a33cf9111);
		}
		return x91ceca93c35413b1[xbcea506a33cf9111];
	}

	private static string x560df454e1c6c383(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == 0)
		{
			return "";
		}
		xbcea506a33cf9111 = (xbcea506a33cf9111 - 1) % 392 + 1;
		xd8cce4761dc846ee xd8cce4761dc846ee = xc7e4e5f194aa67cf.xb31c9ef12c64cea9(xbcea506a33cf9111, 1);
		StringBuilder stringBuilder = new StringBuilder();
		for (int num = xd8cce4761dc846ee.xd44988f225497f3a - 1; num >= 0; num--)
		{
			int num2 = xd8cce4761dc846ee.get_xe6d4b1b411ed94b5(num);
			if (num2 != 0)
			{
				stringBuilder.Append(x1e876be868362346[num][num2 - 1]);
			}
		}
		return stringBuilder.ToString();
	}

	private static string x25b7b66490382eae(int xbcea506a33cf9111)
	{
		int num = xbcea506a33cf9111 % 100;
		if (num < 4 || num > 20)
		{
			switch (num % 10)
			{
			case 1:
				return "st";
			case 2:
				return "nd";
			case 3:
				return "rd";
			}
		}
		return "th";
	}

	private static string x916600dd1fbb0a1a(int xbcea506a33cf9111, string x709ea2d71b29dcd0)
	{
		if (xbcea506a33cf9111 < 1)
		{
			return string.Empty;
		}
		xbcea506a33cf9111--;
		int num = xbcea506a33cf9111 / x709ea2d71b29dcd0.Length;
		int index = xbcea506a33cf9111 - num * x709ea2d71b29dcd0.Length;
		return new string(x709ea2d71b29dcd0[index], num + 1);
	}
}
