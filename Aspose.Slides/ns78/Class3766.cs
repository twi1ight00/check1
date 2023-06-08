using System;
using ns73;
using ns77;

namespace ns78;

internal class Class3766 : Class3739
{
	private Enum497 enum497_0;

	public Class3766(string feature, Class3679 argument)
		: base(feature, argument)
	{
		try
		{
			enum497_0 = Class4342.smethod_0<Enum497>().imethod_3(argument.CSSText);
		}
		catch (Exception)
		{
			enum497_0 = Enum497.const_0;
		}
	}

	public override bool imethod_0(Class3677 device)
	{
		return enum497_0 == device.Scan;
	}
}
