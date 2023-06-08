namespace ns18;

internal class Class1405
{
	internal static bool smethod_0(Interface5 interface5_0)
	{
		if (!smethod_2(interface5_0) && !smethod_3(interface5_0) && !interface5_0.imethod_2())
		{
			return smethod_1(interface5_0);
		}
		return true;
	}

	internal static bool smethod_1(Interface5 interface5_0)
	{
		if (interface5_0 is Class458 && ((Class458)interface5_0).method_2() != null)
		{
			return true;
		}
		return false;
	}

	internal static bool smethod_2(Interface5 interface5_0)
	{
		if (interface5_0.imethod_0() != null)
		{
			return !interface5_0.imethod_0().IsIdentity;
		}
		return false;
	}

	internal static bool smethod_3(Interface5 interface5_0)
	{
		return interface5_0.imethod_1() != null;
	}
}
