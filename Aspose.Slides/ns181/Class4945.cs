using ns173;

namespace ns181;

internal class Class4945 : Class4944
{
	private Class5434 class5434_0;

	public override void vmethod_3(Class4942 parentArea)
	{
		base.vmethod_3(parentArea);
		method_41(method_42() + int_17);
		foreach (Class4943 item in arrayList_1)
		{
			item.method_41(item.method_42() - int_17);
		}
		method_13(vmethod_7());
	}

	public void method_53(Class5434 resolveR)
	{
		class5434_0 = resolveR;
	}

	public Class5434 method_54()
	{
		return class5434_0;
	}
}
