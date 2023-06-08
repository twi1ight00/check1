using ns171;

namespace ns189;

internal class Class5115 : Class5094
{
	private int int_1;

	private static bool bool_1;

	public Class5115(Class5088 parent)
		: base(parent)
	{
		if (!bool_1)
		{
			method_5().imethod_13(this, method_17(), method_17(), method_1());
			bool_1 = true;
		}
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		int_1 = pList.method_5(234).imethod_0();
	}

	public int method_48()
	{
		return int_1;
	}

	public override string vmethod_21()
	{
		return "multi-case";
	}

	public override int vmethod_24()
	{
		return 45;
	}
}
