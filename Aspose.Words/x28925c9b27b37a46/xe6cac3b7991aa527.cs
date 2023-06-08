using System;
using x6c95d9cf46ff5f25;

namespace x28925c9b27b37a46;

internal class xe6cac3b7991aa527 : x21d82b8f3e4c4642
{
	private static readonly DateTime[] xee771880291271d7 = new DateTime[4]
	{
		new DateTime(1868, 1, 1),
		new DateTime(1912, 7, 30),
		new DateTime(1926, 12, 25),
		new DateTime(1989, 1, 8)
	};

	private static DateTime xf64c9e7ae1bb90bc => xee771880291271d7[0];

	internal xe6cac3b7991aa527(DateTime dateTime)
		: base(dateTime)
	{
	}

	internal static string x64f3b8d8dd08a817(DateTime xccf8b068badcb542)
	{
		string[] x0788cd5a9865fc = new string[4] { "明治", "大正", "昭和", "平成" };
		int xc0c4c459c6ccbd = xce4a217b7733bc31(xccf8b068badcb542);
		return xc6cdd0fe3f26c6c0(x0788cd5a9865fc, xc0c4c459c6ccbd);
	}

	internal static string x1dbb6d9f890b84f7(DateTime xccf8b068badcb542)
	{
		string text = x64f3b8d8dd08a817(xccf8b068badcb542);
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return text;
		}
		return text.Substring(0, 1);
	}

	internal static string x8cc4a9adc960104d(DateTime xccf8b068badcb542)
	{
		string[] x0788cd5a9865fc = new string[4] { "M", "T", "S", "H" };
		int xc0c4c459c6ccbd = xce4a217b7733bc31(xccf8b068badcb542);
		return xc6cdd0fe3f26c6c0(x0788cd5a9865fc, xc0c4c459c6ccbd);
	}

	internal static string x9ac679ce2ce92891(int x815c94ed903c247c, DateTime xccf8b068badcb542)
	{
		string text = string.Empty;
		if (xf64c9e7ae1bb90bc <= xccf8b068badcb542)
		{
			int num = x25b3e3053e0a9a17(xccf8b068badcb542);
			text = num.ToString();
			if (x815c94ed903c247c > 1 && num < 10)
			{
				text = "0" + text;
			}
		}
		return text;
	}

	protected override string GetYearInArabicDigits(int pictureElementLength)
	{
		return x9ac679ce2ce92891(pictureElementLength, x1cb5f4ea853f51ee);
	}

	protected override string GetYearInEastAsianDigits(int pictureElementLength)
	{
		if (pictureElementLength > 1)
		{
			return base.GetYearInEastAsianDigits(pictureElementLength);
		}
		if (xf64c9e7ae1bb90bc <= x1cb5f4ea853f51ee)
		{
			int xbcea506a33cf = x25b3e3053e0a9a17(x1cb5f4ea853f51ee);
			return xfa0b2c38531e459a.xb488023801725051(xbcea506a33cf);
		}
		return string.Empty;
	}

	protected override string GetEastAsianDayName()
	{
		return x07588b134816ed8e(x1cb5f4ea853f51ee);
	}

	protected override string GetEastAsianDayNameOrNumber()
	{
		return x07588b134816ed8e(x1cb5f4ea853f51ee);
	}

	protected override string GetEastAsianDayNameAaa(int pictureElementLength)
	{
		if (3 != pictureElementLength)
		{
			return base.GetEastAsianDayNameAaa(pictureElementLength);
		}
		return GetEastAsianDayName();
	}

	protected override string GetEastAsianAmpmDesignator()
	{
		if (x1cb5f4ea853f51ee.Hour >= 12)
		{
			return "午後";
		}
		return "午前";
	}

	private static string xc6cdd0fe3f26c6c0(string[] x0788cd5a9865fc16, int xc0c4c459c6ccbd00)
	{
		if (0 > xc0c4c459c6ccbd00 || xc0c4c459c6ccbd00 >= x0788cd5a9865fc16.Length)
		{
			return string.Empty;
		}
		return x0788cd5a9865fc16[xc0c4c459c6ccbd00];
	}

	private static int xce4a217b7733bc31(DateTime xccf8b068badcb542)
	{
		int num = -1;
		_ = DateTime.MinValue;
		DateTime[] array = xee771880291271d7;
		foreach (DateTime dateTime in array)
		{
			if (!(xccf8b068badcb542 >= dateTime))
			{
				break;
			}
			num++;
		}
		return num;
	}

	private static int x25b3e3053e0a9a17(DateTime xccf8b068badcb542)
	{
		int num = xce4a217b7733bc31(xccf8b068badcb542);
		if (0 <= num && num < xee771880291271d7.Length)
		{
			DateTime dateTime = xee771880291271d7[num];
			return xccf8b068badcb542.Year - dateTime.Year + 1;
		}
		throw new ArgumentOutOfRangeException("date", xccf8b068badcb542, "Japanese Era is not defined for the given date.");
	}

	private static string x07588b134816ed8e(DateTime xccf8b068badcb542)
	{
		return xccf8b068badcb542.DayOfWeek switch
		{
			DayOfWeek.Sunday => "日", 
			DayOfWeek.Monday => "月", 
			DayOfWeek.Tuesday => "火", 
			DayOfWeek.Wednesday => "水", 
			DayOfWeek.Thursday => "木", 
			DayOfWeek.Friday => "金", 
			DayOfWeek.Saturday => "土", 
			_ => string.Empty, 
		};
	}
}
