using ns305;
using ns76;

namespace ns81;

internal class Class4061 : Class4051
{
	private readonly Interface83 interface83_0;

	private readonly Interface81 interface81_0;

	public Interface83 Selector => interface83_0;

	public Interface81 Condition => interface81_0;

	public override int SelectorType => 0;

	public override string SelectorText => Selector.SelectorText + Condition.ConditionText;

	public override int Specificity => Selector.Specificity + Condition.Specificity;

	public Class4061(Interface83 selector, Interface81 condition)
	{
		interface83_0 = selector;
		interface81_0 = condition;
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (interface83_0.imethod_0(e, pseudoElement))
		{
			return interface81_0.imethod_0(e, pseudoElement);
		}
		return false;
	}

	public override void vmethod_0(Class3707 rule)
	{
		((Class4010)interface81_0).vmethod_0(rule);
		((Class4051)interface83_0).vmethod_0(rule);
		base.vmethod_0(rule);
	}
}
