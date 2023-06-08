using System.Text;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x28925c9b27b37a46;

internal class xce449f9cbc44a7e6
{
	private static readonly string[] x758ef02850ebe523 = new string[19]
	{
		"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
		"eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
	};

	private static readonly string[] x5b3dbb19753b2448 = new string[8] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

	private static readonly string[] x2b71ef2f89ad0e9f = new string[19]
	{
		"first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth", "tenth",
		"eleventh", "twelfth", "thirteenth", "fourteenth", "fifteenth", "sixteenth", "seventeenth", "eighteenth", "nineteenth"
	};

	private static readonly string[] x18c19eec98280754 = new string[8] { "twentieth", "thirtieth", "fortieth", "fiftieth", "sixtieth", "seventieth", "eightieth", "ninetieth" };

	private static readonly string[] x7c8787b4f4330877 = new string[3] { "thousand", "million", "billion" };

	private xce449f9cbc44a7e6()
	{
	}

	internal static string x8b56c53f652e7cf9(int xbcea506a33cf9111, bool x2e4d65ae902c9125, bool x3b747bc7816d8768)
	{
		if (xbcea506a33cf9111 == 0)
		{
			if (!x3b747bc7816d8768)
			{
				return "zero";
			}
			return "Zero";
		}
		StringBuilder stringBuilder = x43fc7c7fd5b3ec0b(xbcea506a33cf9111, x2e4d65ae902c9125);
		if (x3b747bc7816d8768)
		{
			stringBuilder[1] = char.ToUpper(stringBuilder[1]);
		}
		return stringBuilder.ToString(1, stringBuilder.Length - 1);
	}

	internal static string x9d3c32d8c874fcd5(double xbcea506a33cf9111)
	{
		int num = (int)xbcea506a33cf9111;
		StringBuilder stringBuilder = ((xbcea506a33cf9111 > 0.0) ? x43fc7c7fd5b3ec0b(num, x2e4d65ae902c9125: true) : new StringBuilder(" zero"));
		stringBuilder.Append(" and ");
		int x37cf7043760b312e = x15e971129fd80714.x43fcc3f62534530b((xbcea506a33cf9111 - (double)num) * 100.0);
		stringBuilder.Append(xca004f56614e2431.xeb27807b6e1b03b6(x37cf7043760b312e));
		stringBuilder.Append("/100");
		return stringBuilder.ToString(1, stringBuilder.Length - 1);
	}

	private static StringBuilder x43fc7c7fd5b3ec0b(int xbcea506a33cf9111, bool x2e4d65ae902c9125)
	{
		StringBuilder stringBuilder = new StringBuilder();
		xd8cce4761dc846ee xd8cce4761dc846ee = xc7e4e5f194aa67cf.xb31c9ef12c64cea9(xbcea506a33cf9111, 3);
		for (int num = xd8cce4761dc846ee.xd44988f225497f3a - 1; num > 0; num--)
		{
			int num2 = xd8cce4761dc846ee.get_xe6d4b1b411ed94b5(num);
			if (num2 != 0)
			{
				x71f776e70081cbc2(stringBuilder, num2, x2e4d65ae902c9125: true);
				xa19f6df7b81556b7(stringBuilder, x7c8787b4f4330877[num - 1]);
			}
		}
		if (xd8cce4761dc846ee.get_xe6d4b1b411ed94b5(0) == 0)
		{
			if (!x2e4d65ae902c9125)
			{
				stringBuilder.Append("th");
			}
		}
		else
		{
			x71f776e70081cbc2(stringBuilder, xd8cce4761dc846ee.get_xe6d4b1b411ed94b5(0), x2e4d65ae902c9125);
		}
		return stringBuilder;
	}

	private static void x71f776e70081cbc2(StringBuilder xd07ce4b74c5774a7, int xbcea506a33cf9111, bool x2e4d65ae902c9125)
	{
		int num = xbcea506a33cf9111 / 100;
		xbcea506a33cf9111 -= 100 * num;
		if (num > 0)
		{
			xa19f6df7b81556b7(xd07ce4b74c5774a7, xf4e11df940cd8458(num, x2e4d65ae902c9125: true));
			xa19f6df7b81556b7(xd07ce4b74c5774a7, (x2e4d65ae902c9125 || xbcea506a33cf9111 != 0) ? "hundred" : "hundredth");
		}
		if (xbcea506a33cf9111 < 20)
		{
			if (xbcea506a33cf9111 > 0)
			{
				xa19f6df7b81556b7(xd07ce4b74c5774a7, xf4e11df940cd8458(xbcea506a33cf9111, x2e4d65ae902c9125));
			}
			return;
		}
		int num2 = xbcea506a33cf9111 / 10;
		xbcea506a33cf9111 -= 10 * num2;
		if (xbcea506a33cf9111 == 0)
		{
			xa19f6df7b81556b7(xd07ce4b74c5774a7, x7d6e06def683f597(num2, x2e4d65ae902c9125));
		}
		else
		{
			xa19f6df7b81556b7(xd07ce4b74c5774a7, x7d6e06def683f597(num2, x2e4d65ae902c9125: true) + "-" + xf4e11df940cd8458(xbcea506a33cf9111, x2e4d65ae902c9125));
		}
	}

	private static void xa19f6df7b81556b7(StringBuilder xd07ce4b74c5774a7, string x661c16f099a6f546)
	{
		xd07ce4b74c5774a7.Append(" ");
		xd07ce4b74c5774a7.Append(x661c16f099a6f546);
	}

	private static string xf4e11df940cd8458(int x57e9faf3ffdc07cc, bool x2e4d65ae902c9125)
	{
		int num = x57e9faf3ffdc07cc - 1;
		if (!x2e4d65ae902c9125)
		{
			return x2b71ef2f89ad0e9f[num];
		}
		return x758ef02850ebe523[num];
	}

	private static string x7d6e06def683f597(int x8a93c650bcb79e00, bool x2e4d65ae902c9125)
	{
		int num = x8a93c650bcb79e00 - 2;
		if (!x2e4d65ae902c9125)
		{
			return x18c19eec98280754[num];
		}
		return x5b3dbb19753b2448[num];
	}
}
