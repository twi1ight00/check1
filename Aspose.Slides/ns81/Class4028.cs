using ns305;
using ns76;

namespace ns81;

internal class Class4028 : Class4021
{
	private Class4051 class4051_0;

	public override string ConditionText => string.Format(":{0}{1})", "not(", class4051_0.SelectorText);

	public Class4028(Class4051 selector)
		: base("not(")
	{
		class4051_0 = selector;
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		return !class4051_0.imethod_0(e, pseudoElement);
	}

	public override void vmethod_0(Class3707 rule)
	{
		class4051_0.vmethod_0(rule);
		base.vmethod_0(rule);
	}
}
