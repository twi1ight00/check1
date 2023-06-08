using System.Globalization;

namespace ns22;

internal class Class1022
{
	private Class1022()
	{
	}

	public static char smethod_0(char char_0)
	{
		return char.ToUpper(char_0, CultureInfo.InvariantCulture);
	}

	public static char smethod_1(char char_0)
	{
		return char.ToLower(char_0, CultureInfo.InvariantCulture);
	}
}
