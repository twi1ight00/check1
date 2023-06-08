namespace ns173;

internal class Class4960 : Class4957
{
	private Class4962 class4962_0;

	private int int_17;

	public void method_42(Class4962 sep)
	{
		class4962_0 = sep;
	}

	public Class4962 method_43()
	{
		return class4962_0;
	}

	public void method_44(int toP)
	{
		int_17 = toP;
	}

	public int method_45()
	{
		return int_17;
	}

	public override void vmethod_5(Class4962 child)
	{
		vmethod_2(child);
		method_13(vmethod_1() + child.vmethod_1());
	}
}
