using ns305;
using ns76;

namespace ns81;

internal class Class4065 : Class4051
{
	private Class4051 class4051_0;

	private Class4051 class4051_1;

	public override int SelectorType => 0;

	public override string SelectorText => class4051_0.SelectorText + class4051_1.SelectorText;

	public override int Specificity => class4051_0.Specificity + class4051_1.Specificity;

	public Class4065(Class4051 left, Class4051 right)
	{
		class4051_0 = left;
		class4051_1 = right;
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (class4051_0.imethod_0(e, pseudoElement))
		{
			return class4051_1.imethod_0(e, pseudoElement);
		}
		return false;
	}

	public override bool vmethod_1()
	{
		return class4051_1.vmethod_1();
	}

	public override void vmethod_0(Class3707 rule)
	{
		class4051_0.vmethod_0(rule);
		class4051_1.vmethod_0(rule);
	}
}
