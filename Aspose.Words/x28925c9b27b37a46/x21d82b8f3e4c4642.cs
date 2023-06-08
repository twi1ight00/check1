using System;
using System.Text;

namespace x28925c9b27b37a46;

internal class x21d82b8f3e4c4642
{
	protected readonly DateTime x1cb5f4ea853f51ee;

	private readonly StringBuilder xbc37de5165016f95 = new StringBuilder();

	private bool x03ff27d5445dffd5;

	protected x21d82b8f3e4c4642(DateTime dateTime)
	{
		x1cb5f4ea853f51ee = dateTime;
	}

	internal static string x6bf3310acbc2c04f(string xed371561cb6e6130, DateTime x73f821c71fe1e676, int xb0a546d42545a9ea)
	{
		x21d82b8f3e4c4642 x21d82b8f3e4c4643 = ((xb0a546d42545a9ea != 1041) ? new x21d82b8f3e4c4642(x73f821c71fe1e676) : new xe6cac3b7991aa527(x73f821c71fe1e676));
		return x21d82b8f3e4c4643.x501f2733ff70d4af(xed371561cb6e6130);
	}

	protected virtual string GetYearInArabicDigits(int pictureElementLength)
	{
		int year = x1cb5f4ea853f51ee.Year;
		string text = year.ToString();
		if (pictureElementLength <= 1 || year >= 10)
		{
			return text;
		}
		return "0" + text;
	}

	protected virtual string GetYearInEastAsianDigits(int pictureElementLength)
	{
		return x6a997d69ab5ac45e(x1cb5f4ea853f51ee);
	}

	private static string x6a997d69ab5ac45e(DateTime xccf8b068badcb542)
	{
		return xfa0b2c38531e459a.x7562d16b881cb8b6(xccf8b068badcb542.Year, 4);
	}

	protected virtual string GetEastAsianDayName()
	{
		return "w";
	}

	protected virtual string GetEastAsianDayNameOrNumber()
	{
		int dayOfWeek = (int)x1cb5f4ea853f51ee.DayOfWeek;
		if (x1cb5f4ea853f51ee.DayOfWeek != 0)
		{
			return xfa0b2c38531e459a.xb488023801725051(dayOfWeek);
		}
		return "日";
	}

	protected virtual string GetEastAsianDayNameAaa(int pictureElementLength)
	{
		return new string('a', pictureElementLength);
	}

	protected virtual string GetEastAsianAmpmDesignator()
	{
		return x0cbe154f97f0c312(x1cb5f4ea853f51ee);
	}

	private string x501f2733ff70d4af(string xed371561cb6e6130)
	{
		x03ff27d5445dffd5 = false;
		bool flag = false;
		xbc37de5165016f95.Length = 0;
		int num;
		for (int i = 0; i < xed371561cb6e6130.Length; i += num)
		{
			char c = xed371561cb6e6130[i];
			num = 1;
			if (c == '\'')
			{
				flag = !flag;
				continue;
			}
			if (flag)
			{
				xbc37de5165016f95.Append(c);
				continue;
			}
			num = x11f4958ff5d93dad(xed371561cb6e6130, i);
			if (num <= 0)
			{
				num = x3d6d722fecee56b6(xed371561cb6e6130, i);
			}
		}
		return xbc37de5165016f95.ToString();
	}

	private string x64f3b8d8dd08a817(int x815c94ed903c247c)
	{
		return x815c94ed903c247c switch
		{
			1 => xe6cac3b7991aa527.x8cc4a9adc960104d(x1cb5f4ea853f51ee), 
			2 => xe6cac3b7991aa527.x1dbb6d9f890b84f7(x1cb5f4ea853f51ee), 
			3 => xe6cac3b7991aa527.x64f3b8d8dd08a817(x1cb5f4ea853f51ee), 
			_ => string.Empty, 
		};
	}

	private string x27a8ba7ef8305f63(int x815c94ed903c247c)
	{
		int x815c94ed903c247c2 = x815c94ed903c247c + 1;
		return x64f3b8d8dd08a817(x815c94ed903c247c2);
	}

	private int xd84b2184c6ffc0e0(string xa6808e34c16e6d04, int x9e73a6ea2207fbb3, int x2339abd7e02e9b2c)
	{
		int num = x8ed58ce627190558(xa6808e34c16e6d04, x9e73a6ea2207fbb3, x2339abd7e02e9b2c);
		string value = xf3788034c220bc8d(xa6808e34c16e6d04[x9e73a6ea2207fbb3], num);
		xbc37de5165016f95.Append(value);
		return num;
	}

	private string xf3788034c220bc8d(char xb16d20f3651abedc, int xe2e3a1c014744aea)
	{
		if (xb16d20f3651abedc == 'Y' || xb16d20f3651abedc == 'D' || xb16d20f3651abedc == 'S')
		{
			xb16d20f3651abedc = char.ToLower(xb16d20f3651abedc);
		}
		x03ff27d5445dffd5 = x03ff27d5445dffd5 || xb16d20f3651abedc == 'd';
		StringBuilder stringBuilder = new StringBuilder(xe2e3a1c014744aea + 1);
		if (xe2e3a1c014744aea == 1)
		{
			stringBuilder.Append('%');
		}
		stringBuilder.Append(xb16d20f3651abedc, xe2e3a1c014744aea);
		bool flag = x03ff27d5445dffd5 && xb16d20f3651abedc == 'M';
		if (flag)
		{
			stringBuilder.Append("dd");
		}
		string text = x1cb5f4ea853f51ee.ToString(stringBuilder.ToString());
		if (!flag)
		{
			return text;
		}
		return text.Substring(0, text.Length - "dd".Length);
	}

	private int x11f4958ff5d93dad(string xed371561cb6e6130, int x0f8e703e2bee7a11)
	{
		string x0c89637219d2881f = xed371561cb6e6130.Substring(x0f8e703e2bee7a11).ToUpper();
		string[] xaf1bd66f9797a = new string[5] { "AM/PM", "PM/AM", "A/P", "P/A", "TT" };
		int num = xb8f225217eba5ced(x0c89637219d2881f, xaf1bd66f9797a, x0dbfa798bc69ea2b: false);
		if (num <= 0)
		{
			string[] xaf1bd66f9797a2 = new string[4] { "JAM/JPM", "JPM/JAM", "AMPM", "PMAM" };
			num = xb8f225217eba5ced(x0c89637219d2881f, xaf1bd66f9797a2, x0dbfa798bc69ea2b: true);
		}
		return num;
	}

	private int xb8f225217eba5ced(string x0c89637219d2881f, string[] xaf1bd66f9797a896, bool x0dbfa798bc69ea2b)
	{
		int num = x4e576a37fa676ee5(x0c89637219d2881f, xaf1bd66f9797a896);
		if (num > 0)
		{
			string value = (x0dbfa798bc69ea2b ? GetEastAsianAmpmDesignator() : x1cb5f4ea853f51ee.ToString("tt"));
			xbc37de5165016f95.Append(value);
		}
		return num;
	}

	private static int x4e576a37fa676ee5(string xf81366c4c7a23320, string[] x2ead2b4a3e34d391)
	{
		foreach (string text in x2ead2b4a3e34d391)
		{
			if (xf81366c4c7a23320.StartsWith(text))
			{
				return text.Length;
			}
		}
		return 0;
	}

	private int x3d6d722fecee56b6(string xed371561cb6e6130, int x0f8e703e2bee7a11)
	{
		int num = 1;
		char c = xed371561cb6e6130[x0f8e703e2bee7a11];
		switch (c)
		{
		case 'D':
		case 'M':
		case 'Y':
		case 'd':
		case 'y':
		{
			int xc1ceb4673e42cfd = 4;
			num = xd84b2184c6ffc0e0(xed371561cb6e6130, x0f8e703e2bee7a11, xc1ceb4673e42cfd);
			break;
		}
		case 'H':
		case 'S':
		case 'h':
		case 'm':
		case 's':
		{
			int xc1ceb4673e42cfd = 2;
			num = xd84b2184c6ffc0e0(xed371561cb6e6130, x0f8e703e2bee7a11, xc1ceb4673e42cfd);
			break;
		}
		case 'g':
		{
			int xc1ceb4673e42cfd = 3;
			num = x8ed58ce627190558(xed371561cb6e6130, x0f8e703e2bee7a11, xc1ceb4673e42cfd);
			string eastAsianDayNameAaa = x64f3b8d8dd08a817(num);
			xbc37de5165016f95.Append(eastAsianDayNameAaa);
			break;
		}
		case 'G':
		{
			int xc1ceb4673e42cfd = 2;
			num = x8ed58ce627190558(xed371561cb6e6130, x0f8e703e2bee7a11, xc1ceb4673e42cfd);
			string eastAsianDayNameAaa = x27a8ba7ef8305f63(num);
			xbc37de5165016f95.Append(eastAsianDayNameAaa);
			break;
		}
		case 'n':
		{
			int xc1ceb4673e42cfd = 2;
			num = x8ed58ce627190558(xed371561cb6e6130, x0f8e703e2bee7a11, xc1ceb4673e42cfd);
			string eastAsianDayNameAaa = xe6cac3b7991aa527.x9ac679ce2ce92891(num, x1cb5f4ea853f51ee);
			xbc37de5165016f95.Append(eastAsianDayNameAaa);
			break;
		}
		case 'e':
		{
			int xc1ceb4673e42cfd = 2;
			num = x8ed58ce627190558(xed371561cb6e6130, x0f8e703e2bee7a11, xc1ceb4673e42cfd);
			string eastAsianDayNameAaa = GetYearInArabicDigits(num);
			xbc37de5165016f95.Append(eastAsianDayNameAaa);
			break;
		}
		case 'E':
		{
			int xc1ceb4673e42cfd = 2;
			num = x8ed58ce627190558(xed371561cb6e6130, x0f8e703e2bee7a11, xc1ceb4673e42cfd);
			string eastAsianDayNameAaa = GetYearInEastAsianDigits(num);
			xbc37de5165016f95.Append(eastAsianDayNameAaa);
			break;
		}
		case 'w':
		{
			string eastAsianDayNameAaa = GetEastAsianDayName();
			xbc37de5165016f95.Append(eastAsianDayNameAaa);
			break;
		}
		case 'W':
		{
			string eastAsianDayNameAaa = GetEastAsianDayNameOrNumber();
			xbc37de5165016f95.Append(eastAsianDayNameAaa);
			break;
		}
		case 'a':
		{
			int xc1ceb4673e42cfd = 3;
			num = x8ed58ce627190558(xed371561cb6e6130, x0f8e703e2bee7a11, xc1ceb4673e42cfd);
			string eastAsianDayNameAaa = GetEastAsianDayNameAaa(num);
			xbc37de5165016f95.Append(eastAsianDayNameAaa);
			break;
		}
		case 'O':
			xbf9ec247c6f7888f(x1cb5f4ea853f51ee.Month);
			break;
		case 'A':
			xbf9ec247c6f7888f(x1cb5f4ea853f51ee.Day);
			break;
		case 'r':
		{
			int xc1ceb4673e42cfd = 2;
			num = x8ed58ce627190558(xed371561cb6e6130, x0f8e703e2bee7a11, xc1ceb4673e42cfd);
			xb758428a0f2f96b9(num);
			x5f9b7d96da240721();
			break;
		}
		case 'R':
		{
			int xc1ceb4673e42cfd = 2;
			num = x8ed58ce627190558(xed371561cb6e6130, x0f8e703e2bee7a11, xc1ceb4673e42cfd);
			xb758428a0f2f96b9(num);
			xe70abbcbc9e6ba2b(num);
			break;
		}
		case 'I':
			xbf9ec247c6f7888f(x1cb5f4ea853f51ee.Minute);
			break;
		case 'C':
			xbf9ec247c6f7888f(x1cb5f4ea853f51ee.Second);
			break;
		default:
			xbc37de5165016f95.Append(c);
			break;
		}
		return num;
	}

	private static int x8ed58ce627190558(string xcdaeea7afaf570ff, int x572f24abeb0300ea, int xc1ceb4673e42cfd6)
	{
		char c = xcdaeea7afaf570ff[x572f24abeb0300ea];
		int num = 1;
		int num2 = x572f24abeb0300ea + 1;
		while (num < xc1ceb4673e42cfd6 && num2 < xcdaeea7afaf570ff.Length && xcdaeea7afaf570ff[num2] == c)
		{
			num++;
			num2++;
		}
		return num;
	}

	private void xbf9ec247c6f7888f(int x78b0a0bc28459535)
	{
		xbc37de5165016f95.Append(xfa0b2c38531e459a.xb488023801725051(x78b0a0bc28459535));
	}

	private void x5f9b7d96da240721()
	{
		int x78b0a0bc = x91d47afe94d7a6dc(x1cb5f4ea853f51ee.Hour);
		xbf9ec247c6f7888f(x78b0a0bc);
	}

	private static int x91d47afe94d7a6dc(int xcfc679ab08ae9d4f)
	{
		int num = xcfc679ab08ae9d4f % 12;
		if (num == 0)
		{
			return 12;
		}
		return num;
	}

	private void xe70abbcbc9e6ba2b(int x815c94ed903c247c)
	{
		int hour = x1cb5f4ea853f51ee.Hour;
		string value = ((x815c94ed903c247c != 1) ? x91d47afe94d7a6dc(hour).ToString() : xfa0b2c38531e459a.xb488023801725051(hour));
		xbc37de5165016f95.Append(value);
	}

	private void xb758428a0f2f96b9(int x815c94ed903c247c)
	{
		if (x815c94ed903c247c > 1)
		{
			xbc37de5165016f95.Append(x0cbe154f97f0c312(x1cb5f4ea853f51ee));
		}
	}

	private static string x0cbe154f97f0c312(DateTime xccf8b068badcb542)
	{
		if (xccf8b068badcb542.Hour >= 12)
		{
			return "下午";
		}
		return "上午";
	}
}
