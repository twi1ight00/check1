using System;

namespace ns171;

internal class Class5658 : Class5656
{
	private static Class5656 class5656_0;

	public static Class5656 smethod_0()
	{
		if (class5656_0 == null)
		{
			class5656_0 = new Class5658();
		}
		return class5656_0;
	}

	public override bool imethod_0()
	{
		return false;
	}

	public override char vmethod_0()
	{
		throw new Exception("Element was not found");
	}
}
