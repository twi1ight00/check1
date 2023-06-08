using ns224;
using ns261;

namespace ns250;

internal class Class6291 : Class6284
{
	private string string_0;

	private string string_1;

	public string Value
	{
		get
		{
			if (string_1 == null)
			{
				string_1 = string.Empty;
			}
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string LastColor
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

	protected override Class5998 vmethod_0(Interface297 themeProvider)
	{
		if (LastColor.Length == 0)
		{
			return Class5998.class5998_141;
		}
		return Class6285.smethod_0(LastColor);
	}

	public override Interface274 Clone()
	{
		Class6291 @class = new Class6291();
		@class.Value = Value;
		@class.LastColor = LastColor;
		method_1(@class);
		return @class;
	}
}
