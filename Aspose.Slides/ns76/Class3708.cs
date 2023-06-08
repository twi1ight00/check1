using System;
using System.Diagnostics;
using ns73;

namespace ns76;

[DebuggerDisplay("{CSSText}")]
internal class Class3708 : Class3707, Interface59, Interface64
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_2 = string.Empty;

	public override string CSSText
	{
		get
		{
			return $"@charset \"{string_2}\";";
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public string Encoding
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public Class3708(Class3735 styleSheet, Interface59 parentRule)
		: base(styleSheet, parentRule, 2)
	{
	}
}
