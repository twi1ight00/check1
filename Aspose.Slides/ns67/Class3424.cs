using System;

namespace ns67;

internal class Class3424 : Class3423
{
	private string string_0;

	public string TextString
	{
		get
		{
			return string_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			string_0 = value;
		}
	}

	public Class3424(string textString)
	{
		TextString = textString;
	}

	public override Class3423 vmethod_0()
	{
		return new Class3424(this);
	}

	protected Class3424(Class3424 src)
		: base(src)
	{
		TextString = src.string_0;
	}
}
