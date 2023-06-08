using ns171;
using ns176;

namespace ns190;

internal abstract class Class5136 : Class5135
{
	private Interface182 interface182_0;

	protected Class5136(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		interface182_0 = pList.method_6(Enum679.const_180).vmethod_0();
	}

	public Interface182 method_58()
	{
		return interface182_0;
	}
}
