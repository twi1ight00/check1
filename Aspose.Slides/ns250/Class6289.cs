using ns224;
using ns261;

namespace ns250;

internal class Class6289 : Class6284
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

	public Class6289()
	{
	}

	public Class6289(string value)
	{
		string_0 = value;
	}

	protected override Class5998 vmethod_0(Interface297 themeProvider)
	{
		return Class6001.smethod_0(Value);
	}

	public override Interface274 Clone()
	{
		Class6289 @class = new Class6289();
		@class.Value = Value;
		method_1(@class);
		return @class;
	}
}
