namespace ns210;

internal abstract class Class5511 : Class5510, Interface211
{
	protected Class5511(string id, int sequence, int flags, int format, Class5496 mapping)
		: base(id, sequence, flags, format, mapping)
	{
	}

	public override int vmethod_0()
	{
		return Class5563.int_4;
	}

	public override string vmethod_2()
	{
		return Class5564.smethod_3(vmethod_1());
	}

	public override bool vmethod_4()
	{
		return false;
	}

	public bool imethod_0(int gi)
	{
		Interface210 @interface;
		if ((@interface = method_5()) != null && @interface.imethod_1(gi) >= 0)
		{
			return true;
		}
		Interface209 interface2;
		if ((interface2 = method_6()) != null && interface2.imethod_1(gi, 0) >= 0)
		{
			return true;
		}
		return false;
	}
}
