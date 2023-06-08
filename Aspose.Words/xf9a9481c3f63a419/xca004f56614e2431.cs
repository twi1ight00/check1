using System;
using System.Globalization;
using System.Text;
using Aspose;
using x6c95d9cf46ff5f25;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
internal class xca004f56614e2431
{
	private const string x7a91b972a49cc2b5 = "ddd, d MMM yyyy HH':'mm':'ss zzzz";

	private xca004f56614e2431()
	{
	}

	public static string x6efbf9d15154c80d(DateTime xbcea506a33cf9111)
	{
		return xbcea506a33cf9111.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
	}

	public static string x4fd2cbfd96b1abdc(DateTime xbcea506a33cf9111)
	{
		return xbcea506a33cf9111.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
	}

	public static string x94736217485981d7(DateTime xbcea506a33cf9111)
	{
		return xbcea506a33cf9111.ToString("yyyyMMddHHmmssZ", CultureInfo.InvariantCulture);
	}

	public static DateTime x70982613fd6240f9(string xbcea506a33cf9111)
	{
		return xb9667d90536fe642(xbcea506a33cf9111, CultureInfo.InvariantCulture);
	}

	public static string x5fb241430a53ba3b(DateTime xbcea506a33cf9111)
	{
		string text = xbcea506a33cf9111.ToString("ddd, d MMM yyyy HH':'mm':'ss zzzz", DateTimeFormatInfo.InvariantInfo);
		return text.Remove(text.LastIndexOf(':'), 1);
	}

	public static DateTime xafb27d747b9daf48(string xbcea506a33cf9111)
	{
		return DateTime.ParseExact(xbcea506a33cf9111, "ddd, d MMM yyyy HH':'mm':'ss zzzz", DateTimeFormatInfo.InvariantInfo);
	}

	public static string x754c3a5f03a2ce84(int xbcea506a33cf9111)
	{
		return xc8ba948e0d631490(xbcea506a33cf9111);
	}

	public static string x1d99ce1556ea7f1f(uint x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString(CultureInfo.InvariantCulture);
	}

	public static int x59884ab46dd0d856(string x37cf7043760b312e)
	{
		return x0d299f323d241756.xa6ad07b252a1909e(xec25d08a2af152f0(x37cf7043760b312e));
	}

	public static double xec25d08a2af152f0(string x37cf7043760b312e)
	{
		double num = xf5ece46c5d72e3b9(x37cf7043760b312e);
		if (!double.IsNaN(num))
		{
			return num;
		}
		return 0.0;
	}

	public static double x4d108926f0365bbb(string x37cf7043760b312e)
	{
		return xec25d08a2af152f0(x37cf7043760b312e);
	}

	public static double xf5ece46c5d72e3b9(string xe4115acdf4fbfccc)
	{
		if (!double.TryParse(xe4115acdf4fbfccc, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
		{
			return double.NaN;
		}
		return result;
	}

	public static double x9af476c0811d07cd(string xe4115acdf4fbfccc)
	{
		if (!double.TryParse(xe4115acdf4fbfccc, NumberStyles.Float, CultureInfo.CurrentCulture, out var result))
		{
			return double.NaN;
		}
		return result;
	}

	public static bool x44084f078ff0e99c(string xbcea506a33cf9111)
	{
		double result;
		return double.TryParse(xbcea506a33cf9111, NumberStyles.None, CultureInfo.InvariantCulture, out result);
	}

	public static int x912616ee70b2d94d(string xe4115acdf4fbfccc)
	{
		if (!double.TryParse(xe4115acdf4fbfccc, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return int.MinValue;
		}
		return x0d299f323d241756.xa6ad07b252a1909e(result);
	}

	public static int x83da27b1750f1f84(string xe4115acdf4fbfccc)
	{
		int num = int.MinValue;
		while (xe4115acdf4fbfccc.Length > 0)
		{
			num = x912616ee70b2d94d(xe4115acdf4fbfccc);
			if (num != int.MinValue)
			{
				break;
			}
			xe4115acdf4fbfccc = xe4115acdf4fbfccc.Substring(0, xe4115acdf4fbfccc.Length - 1);
		}
		return num;
	}

	public static double xc510d8f3e12c9223(string xe4115acdf4fbfccc)
	{
		if (!double.TryParse(xe4115acdf4fbfccc, NumberStyles.Currency, CultureInfo.CurrentCulture, out var result))
		{
			return double.NaN;
		}
		return result;
	}

	public static DateTime x5fa9002eedbc901d(string xe4115acdf4fbfccc)
	{
		return xb9667d90536fe642(xe4115acdf4fbfccc, x20872371f4286008());
	}

	private static DateTime xb9667d90536fe642(string xe4115acdf4fbfccc, IFormatProvider x83d0c26038874b92)
	{
		if (!DateTime.TryParse(xe4115acdf4fbfccc, x83d0c26038874b92, DateTimeStyles.AdjustToUniversal, out var result))
		{
			return DateTime.MinValue;
		}
		return result;
	}

	public static int xa93402510be8434e(string x37cf7043760b312e)
	{
		return int.Parse(x37cf7043760b312e, NumberStyles.Integer, CultureInfo.InvariantCulture);
	}

	public static long x71505bb121b63b5e(string x37cf7043760b312e)
	{
		return long.Parse(x37cf7043760b312e, NumberStyles.Integer, CultureInfo.InvariantCulture);
	}

	public static int xadcf75bfc0bf31e3(string x37cf7043760b312e)
	{
		return int.Parse(x37cf7043760b312e, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
	}

	public static int x4bbd62ec225a0240(string xe4115acdf4fbfccc)
	{
		if (!int.TryParse(xe4115acdf4fbfccc, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
		{
			return int.MinValue;
		}
		return result;
	}

	public static bool xa0946eaa4f07cba1(string x37cf7043760b312e)
	{
		return bool.Parse(x37cf7043760b312e);
	}

	public static string x957baa621044fc39(bool x37cf7043760b312e)
	{
		if (!x37cf7043760b312e)
		{
			return "false";
		}
		return "true";
	}

	public static string xc8ba948e0d631490(int x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString(CultureInfo.InvariantCulture);
	}

	public static string xc8ba948e0d631490(long x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString(CultureInfo.InvariantCulture);
	}

	public static string xeb27807b6e1b03b6(int x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("D2", CultureInfo.InvariantCulture);
	}

	public static string x1da955c8970871e3(int x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("D3", CultureInfo.InvariantCulture);
	}

	public static string xd2bd6588f73f7402(int x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("D4", CultureInfo.InvariantCulture);
	}

	public static string xc2db0f7f91c78fc3(int x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("D10", CultureInfo.InvariantCulture);
	}

	public static string x697bc660ab38a504(int x37cf7043760b312e)
	{
		if (x37cf7043760b312e != 0)
		{
			return xc8ba948e0d631490(x37cf7043760b312e);
		}
		return "";
	}

	public static string x3f49ddc503802c37(int x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("X", CultureInfo.InvariantCulture);
	}

	public static string xad97b43ecf64e377(int x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("x", CultureInfo.InvariantCulture);
	}

	public static string x928e44a7dd7cdb8b(int x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("X2", CultureInfo.InvariantCulture);
	}

	public static string x06423d8cf62a0672(int x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("x2", CultureInfo.InvariantCulture);
	}

	public static string x7c1a0f9da8274fe8(int x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("X4", CultureInfo.InvariantCulture);
	}

	public static string x6c89d5642f47f66d(int x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("X6", CultureInfo.InvariantCulture);
	}

	public static string xaa4e6020773f88bc(int x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("X8", CultureInfo.InvariantCulture);
	}

	public static string xcaaeec2e96b2cecc(double xbcea506a33cf9111)
	{
		return xbcea506a33cf9111.ToString(CultureInfo.InvariantCulture);
	}

	public static string x97cefc6d2c90b1bc(double x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("###########e0", CultureInfo.InvariantCulture);
	}

	public static string xdbca7a004e2d3753(double x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("0.##", CultureInfo.InvariantCulture);
	}

	public static string xcadee4aea45827c2(double x37cf7043760b312e)
	{
		return x37cf7043760b312e.ToString("0.#########", CultureInfo.InvariantCulture);
	}

	public static string x05bb6454cb109fa9(float x37cf7043760b312e)
	{
		return ((double)x37cf7043760b312e).ToString("0.########", CultureInfo.InvariantCulture);
	}

	public static string x37804260a70f74eb(float x37cf7043760b312e)
	{
		return ((double)x37cf7043760b312e).ToString("0.#########", CultureInfo.InvariantCulture);
	}

	public static string xbce25c860880d237(double xbcea506a33cf9111, bool x241f4ee33d2fc582, bool xd4368cf517e080f0)
	{
		string text = (x241f4ee33d2fc582 ? "c" : ((!xd4368cf517e080f0) ? "0.#######" : "#,##0.#######"));
		return xbcea506a33cf9111.ToString(text, CultureInfo.CurrentCulture);
	}

	public static string x3fefcbaee4514358(double xbcea506a33cf9111, string xf092285ef2b9e762, bool x5c4c72022ea54b2c)
	{
		string text = xe2f8ce961f9e9069(xf092285ef2b9e762);
		if (text.IndexOf("%") >= 0 && text.IndexOf("'%'") < 0 && !x5c4c72022ea54b2c)
		{
			text = text.Replace("%", "'%'");
		}
		return xbcea506a33cf9111.ToString(x3fecd0d820a855fa(text), CultureInfo.CurrentCulture);
	}

	private static string x3fecd0d820a855fa(string x5786461d089b10a0)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x5786461d089b10a0) && x5786461d089b10a0[0] == ',')
		{
			return "N";
		}
		return x5786461d089b10a0;
	}

	private static string xe2f8ce961f9e9069(string x5786461d089b10a0)
	{
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		while (num < x5786461d089b10a0.Length)
		{
			if (x8040a68980ac6fd5(x5786461d089b10a0, num, currentInfo.NumberDecimalSeparator))
			{
				stringBuilder.Append('.');
				num += currentInfo.NumberDecimalSeparator.Length;
			}
			else if (x8040a68980ac6fd5(x5786461d089b10a0, num, currentInfo.NumberGroupSeparator))
			{
				stringBuilder.Append(',');
				num += currentInfo.NumberGroupSeparator.Length;
			}
			else if (x8040a68980ac6fd5(x5786461d089b10a0, num, currentInfo.PercentSymbol))
			{
				stringBuilder.Append('%');
				num += currentInfo.PercentSymbol.Length;
			}
			else if (x8040a68980ac6fd5(x5786461d089b10a0, num, currentInfo.PerMilleSymbol))
			{
				stringBuilder.Append('‰');
				num += currentInfo.PerMilleSymbol.Length;
			}
			else
			{
				stringBuilder.Append(x5786461d089b10a0[num]);
				num++;
			}
		}
		return stringBuilder.ToString();
	}

	private static bool x8040a68980ac6fd5(string x19218ffab70283ef, int x2f915c3c02d05e42, string xe7ebe10fa44d8d49)
	{
		return x27cd5f9641d9eb15.Equals(x19218ffab70283ef, x2f915c3c02d05e42, xe7ebe10fa44d8d49, 0, xe7ebe10fa44d8d49.Length);
	}

	public static string xe848f98d8289ef42()
	{
		return x20872371f4286008().ShortDatePattern;
	}

	public static string x2e6816855ae2f90b()
	{
		string shortTimePattern = x20872371f4286008().ShortTimePattern;
		return shortTimePattern.Replace("tt", "am/pm");
	}

	public static string xd129e99dbb2969b2()
	{
		return x20872371f4286008().ShortDatePattern;
	}

	public static string xf6abea96d1b740f9()
	{
		return x20872371f4286008().LongTimePattern;
	}

	public static string x68f6e7391790c83e()
	{
		return x20872371f4286008().TimeSeparator;
	}

	private static DateTimeFormatInfo x20872371f4286008()
	{
		return DateTimeFormatInfo.CurrentInfo;
	}

	public static char xaccdf4f36d70782c()
	{
		string numberDecimalSeparator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
		if (!x0d299f323d241756.x5959bccb67bbf051(numberDecimalSeparator))
		{
			return '.';
		}
		return numberDecimalSeparator[0];
	}

	public static char x34467b042ad8c56e()
	{
		string numberGroupSeparator = NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
		if (!x0d299f323d241756.x5959bccb67bbf051(numberGroupSeparator))
		{
			return ',';
		}
		return numberGroupSeparator[0];
	}

	public static string x1b50446eaf1c4798()
	{
		return NumberFormatInfo.CurrentInfo.CurrencySymbol;
	}
}
