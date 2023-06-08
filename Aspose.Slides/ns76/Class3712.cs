using System;
using System.Diagnostics;
using ns73;

namespace ns76;

[DebuggerDisplay("{CSSText}")]
internal class Class3712 : Class3707, Interface59, Interface71
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class3732 class3732_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class3736 class3736_0;

	public override string CSSText
	{
		get
		{
			return $"@media {Media.MediaText} {{ {CSSRules} }}";
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	Interface79 Interface71.Media => class3736_0;

	public Class3736 Media => class3736_0;

	public Interface73 CSSRules => class3732_0;

	public Class3712(Class3735 styleSheet, Interface59 parentRule)
		: base(styleSheet, parentRule, 4)
	{
		class3732_0 = new Class3732(styleSheet);
		class3736_0 = new Class3736();
	}

	public long imethod_0(string rule, long index)
	{
		throw new NotImplementedException();
	}

	public void imethod_1(long index)
	{
		throw new NotImplementedException();
	}
}
