using ns226;

namespace ns229;

internal abstract class Class6056 : Class6026.Class6055
{
	private Class6025 class6025_0;

	protected Class6056(Class6110 header, Class6017 data)
		: base(header, data)
	{
	}

	protected Class6056(Class6110 header, Class6016 data)
		: base(header, data)
	{
	}

	protected Class6056(Class6110 header)
		: base(header)
	{
	}

	protected Class6025 method_17()
	{
		if (class6025_0 == null)
		{
			class6025_0 = vmethod_6(method_6());
		}
		return class6025_0;
	}

	protected override void vmethod_5()
	{
		class6025_0 = null;
	}

	internal override int vmethod_4()
	{
		return 0;
	}

	internal override bool vmethod_3()
	{
		return true;
	}

	internal override int vmethod_2(Class6017 newData)
	{
		return 0;
	}

	public override Class6025 vmethod_0()
	{
		if (!vmethod_3())
		{
			return null;
		}
		Class6025 @class = method_17();
		vmethod_1(@class);
		return @class;
	}
}
