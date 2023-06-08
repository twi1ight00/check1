using ns218;
using ns234;
using ns256;

namespace ns259;

internal class Class6402
{
	private readonly string string_0;

	internal string String => string_0;

	internal Class6402(double value)
	{
		string_0 = Class6159.smethod_41(value);
	}

	internal Class6402(string value)
	{
		if (!Class5964.smethod_20(value))
		{
			string_0 = "0";
		}
		else
		{
			string_0 = value;
		}
	}

	internal double method_0(Interface288 guideValueProvider)
	{
		return Class6369.smethod_0(string_0, guideValueProvider);
	}

	internal double method_1(Interface288 guideValueProvider)
	{
		return Class5955.smethod_68(method_0(guideValueProvider));
	}
}
