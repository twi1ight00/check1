using System;
using ns233;

namespace ns237;

internal class Class6670
{
	private readonly string string_0;

	private readonly string string_1;

	private readonly int int_0;

	private static readonly Class6670 class6670_0 = new Class6670("DeviceGray", "G", 1);

	private static readonly Class6670 class6670_1 = new Class6670("DeviceRGB", "RGB", 3);

	private static readonly Class6670 class6670_2 = new Class6670("DeviceCMYK", "CMYK", 4);

	private static readonly Class6670 class6670_3 = new Class6670("Indexed", "I", 1);

	private static readonly Class6670 class6670_4 = new Class6670("Pattern", string.Empty, 0);

	internal static Class6670 DeviceGray => class6670_0;

	internal static Class6670 DeviceRgb => class6670_1;

	internal static Class6670 DeviceCmyk => class6670_2;

	internal static Class6670 Indexed => class6670_3;

	internal static Class6670 Pattern => class6670_4;

	internal string FullName => string_0;

	internal string ShortName => string_1;

	internal int Components => int_0;

	private Class6670(string fullName, string shortName, int components)
	{
		string_0 = fullName;
		string_1 = shortName;
		int_0 = components;
	}

	internal static Class6670 smethod_0(Enum786 colorModel)
	{
		return colorModel switch
		{
			Enum786.const_0 => DeviceRgb, 
			Enum786.const_1 => Indexed, 
			Enum786.const_2 => DeviceGray, 
			_ => throw new InvalidOperationException("Unknown bitmap color space."), 
		};
	}
}
