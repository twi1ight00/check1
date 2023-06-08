using System.Globalization;

namespace ns234;

internal static class Class6550
{
	public static char smethod_0(char c)
	{
		return char.ToUpper(c, CultureInfo.InvariantCulture);
	}

	public static char smethod_1(char c)
	{
		return char.ToLower(c, CultureInfo.InvariantCulture);
	}

	public static bool smethod_2(char c)
	{
		return char.GetUnicodeCategory(c) == UnicodeCategory.PrivateUse;
	}
}
