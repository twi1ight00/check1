using System;
using ns305;

namespace ns81;

internal class Class4027 : Class4021
{
	public Class4027()
		: base("checked")
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!e.method_34("checked"))
		{
			return false;
		}
		return "checked".Equals(e.method_20("checked"), StringComparison.OrdinalIgnoreCase);
	}
}
