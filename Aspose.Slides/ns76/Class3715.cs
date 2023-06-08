using System.Diagnostics;
using ns73;

namespace ns76;

[DebuggerDisplay("{CSSText}")]
internal class Class3715 : Class3707, Interface59, Interface77
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_2;

	public override string CSSText
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

	public Class3715(Class3735 styleSheet, Interface59 parentRule)
		: base(styleSheet, parentRule, 2)
	{
	}
}
