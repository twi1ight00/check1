using System;
using ns173;

namespace ns181;

internal class Class4950 : Class4943
{
	protected Class4962 class4962_0;

	public override void vmethod_2(Class4942 childArea)
	{
		if (class4962_0 != null)
		{
			throw new InvalidOperationException("InlineBlockParent may have only one child area.");
		}
		if (!(childArea is Class4962))
		{
			throw new InvalidOperationException("The child of an InlineBlockParent must be a Block area");
		}
		class4962_0 = (Class4962)childArea;
		method_11(childArea.method_14());
		method_13(childArea.method_15());
	}

	public Class4962 method_51()
	{
		return class4962_0;
	}
}
