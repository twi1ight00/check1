using System.Drawing;
using System.IO;
using ns218;
using ns221;
using ns224;
using ns234;

namespace ns220;

internal class Class5947 : Class5946
{
	public Class5947(Stream stream, bool isPrettyFormat)
		: base(stream, isPrettyFormat)
	{
	}

	[Attribute7(true)]
	public void method_19(string name, double value)
	{
		method_14(name, Class6159.smethod_41(value));
	}

	[Attribute7(true)]
	public void method_20(string name, float value)
	{
		method_14(name, Class6159.smethod_43(value));
	}

	[Attribute7(true)]
	public void method_21(string name, Class5998 value)
	{
		method_14(name, $"#{Class6159.smethod_37(value.method_1())}");
	}

	[Attribute7(true)]
	public void method_22(string name, float x, float y)
	{
		string value = $"{Class6159.smethod_43(x)},{Class6159.smethod_43(y)}";
		method_14(name, value);
	}

	[Attribute7(true)]
	public void method_23(string name, RectangleF value)
	{
		string value2 = $"{Class6159.smethod_43(value.X)},{Class6159.smethod_43(value.Y)},{Class6159.smethod_43(value.Width)},{Class6159.smethod_43(value.Height)}";
		method_14(name, value2);
	}

	[Attribute7(true)]
	public void method_24(string name, Class6002 value)
	{
		string value2 = $"{Class6159.smethod_43(value.M11)},{Class6159.smethod_43(value.M12)},{Class6159.smethod_43(value.M21)},{Class6159.smethod_43(value.M22)},{Class6159.smethod_43(value.M31)},{Class6159.smethod_43(value.M32)}";
		method_14(name, value2);
	}
}
