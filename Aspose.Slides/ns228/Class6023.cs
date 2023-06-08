using System.Text;

namespace ns228;

internal class Class6023
{
	public static int smethod_0(int @fixed)
	{
		return (@fixed >> 16) & 0xFFFF;
	}

	public static int smethod_1(int @fixed)
	{
		return @fixed & 0xFFFF;
	}

	public static int smethod_2(int integral, int fractional)
	{
		return ((integral & 0xFFFF) << 16) | (fractional & 0xFFFF);
	}

	public static string smethod_3(int @fixed)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(smethod_0(@fixed));
		stringBuilder.Append(".");
		stringBuilder.Append(smethod_1(@fixed));
		return stringBuilder.ToString();
	}
}
