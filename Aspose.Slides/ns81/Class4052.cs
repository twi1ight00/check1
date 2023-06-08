using ns76;

namespace ns81;

internal abstract class Class4052 : Class4051
{
	private Interface83 interface83_0;

	private Interface83 interface83_1;

	protected Interface83 AncestorSelector => interface83_0;

	protected Interface83 SimpleSelector => interface83_1;

	public override int SelectorType => 10;

	public override int Specificity => AncestorSelector.Specificity + SimpleSelector.Specificity;

	protected Class4052(Interface83 ancestor, Interface83 simple)
	{
		interface83_0 = ancestor;
		interface83_1 = simple;
	}

	public override void vmethod_0(Class3707 rule)
	{
		((Class4051)AncestorSelector).vmethod_0(rule);
		if (SimpleSelector != null)
		{
			((Class4051)SimpleSelector).vmethod_0(rule);
		}
		base.vmethod_0(rule);
	}

	public override bool vmethod_1()
	{
		return ((Class4051)AncestorSelector).vmethod_1() | ((Class4051)SimpleSelector).vmethod_1();
	}
}
