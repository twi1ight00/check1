using ns224;
using ns234;
using ns261;

namespace ns250;

internal class Class6285 : Class6284
{
	private string string_0;

	public string Value
	{
		get
		{
			if (string_0 == null)
			{
				string_0 = string.Empty;
			}
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class6285()
	{
	}

	public Class6285(string value)
	{
		Value = value;
	}

	protected override Class5998 vmethod_0(Interface297 themeProvider)
	{
		if (Value.Length == 0)
		{
			return Class5998.class5998_141;
		}
		return smethod_0(Value);
	}

	public override Interface274 Clone()
	{
		Class6285 @class = new Class6285();
		@class.Value = Value;
		method_1(@class);
		return @class;
	}

	internal static Class5998 smethod_0(string value)
	{
		int argb = Class6159.smethod_20(value) | -16777216;
		return new Class5998(argb);
	}
}
