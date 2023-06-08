using System;
using System.Diagnostics;
using ns73;

namespace ns76;

internal class Class3713 : Class3707, Interface59, Interface72
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class3733 class3733_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class3720 class3720_0;

	public override string CSSText
	{
		get
		{
			return $"{SelectorText} {{{Style}}}";
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public string SelectorText
	{
		get
		{
			if (class3733_0.Length == 0)
			{
				return "@page";
			}
			return string.Format("{0} {1}", "@page", SelectorList);
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public Interface58 Style => class3720_0;

	public Class3733 SelectorList => class3733_0;

	public Class3713(Class3735 styleSheet, Interface59 parentRule)
		: base(styleSheet, parentRule, 6)
	{
		class3733_0 = new Class3733(this);
		class3720_0 = new Class3720(this);
	}
}
