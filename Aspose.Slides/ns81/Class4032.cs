using System;
using ns305;

namespace ns81;

internal class Class4032 : Class4029
{
	public Class4032()
		: base("enabled")
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!Class4067.Class4068.smethod_0(e.TagName))
		{
			return false;
		}
		if (!e.method_34("disabled"))
		{
			return true;
		}
		return !"disabled".Equals(e.method_20("disabled"), StringComparison.OrdinalIgnoreCase);
	}
}
