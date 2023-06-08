using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1439
{
	private string string_0;

	private string string_1;

	private static readonly Class1439 class1439_0 = new Class1439("DeviceGray", "G");

	private static readonly Class1439 class1439_1 = new Class1439("DeviceRGB", "RGB");

	private static readonly Class1439 class1439_2 = new Class1439("DeviceCMYK", "CMYK");

	private static readonly Class1439 class1439_3 = new Class1439("Indexed", "I");

	private static readonly Class1439 class1439_4 = new Class1439("Pattern", string.Empty);

	internal static Class1439 Pattern => class1439_4;

	private Class1439()
	{
	}

	protected Class1439(string string_2, string string_3)
	{
		string_0 = string_2;
		string_1 = string_3;
	}

	[SpecialName]
	internal static Class1439 smethod_0()
	{
		return class1439_0;
	}

	[SpecialName]
	internal static Class1439 smethod_1()
	{
		return class1439_1;
	}

	[SpecialName]
	internal static Class1439 smethod_2()
	{
		return class1439_3;
	}

	[SpecialName]
	internal string method_0()
	{
		return string_0;
	}

	[SpecialName]
	internal string method_1()
	{
		return string_1;
	}
}
