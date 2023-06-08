using ns76;

namespace ns81;

internal abstract class Class4062 : Class4051
{
	private Interface83 interface83_0;

	private Interface83 interface83_1;

	protected Interface83 SiblingSelector => interface83_0;

	protected Interface83 SimpleSelector => interface83_1;

	public override int Specificity => SiblingSelector.Specificity + SimpleSelector.Specificity;

	protected Class4062(Interface83 sibling, Interface83 simple)
	{
		interface83_0 = sibling;
		interface83_1 = simple;
	}

	public override void vmethod_0(Class3707 rule)
	{
		base.vmethod_0(rule);
		((Class4051)SiblingSelector).vmethod_0(rule);
		((Class4051)SimpleSelector).vmethod_0(rule);
	}
}
