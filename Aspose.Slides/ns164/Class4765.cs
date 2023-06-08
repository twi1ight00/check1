using ns165;
using ns235;

namespace ns164;

internal class Class4765 : Class4755
{
	private string string_0;

	private Class4767 class4767_1;

	private Class6270 class6270_0;

	internal string Text => string_0;

	internal Class4765(string text, Class4767 properties, Class6270 hyperlink)
		: base(properties)
	{
		string_0 = text;
		class4767_1 = properties;
		class6270_0 = hyperlink;
	}

	internal override void vmethod_0(Interface145 builder)
	{
		if (class6270_0 != null)
		{
			builder.imethod_16(class6270_0);
		}
		builder.imethod_21(string_0, class4767_1);
		if (class6270_0 != null)
		{
			builder.imethod_17();
		}
	}
}
