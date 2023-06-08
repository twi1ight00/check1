using System;
using ns73;
using ns77;

namespace ns78;

internal class Class3764 : Class3739
{
	private Enum510 enum510_0;

	public Class3764(string feature, Class3679 argument)
		: base(feature, argument)
	{
		try
		{
			enum510_0 = Class4342.smethod_0<Enum510>().imethod_3(argument.CSSText);
		}
		catch (Exception)
		{
			enum510_0 = Enum510.const_1;
		}
	}

	public override bool imethod_0(Class3677 device)
	{
		return enum510_0 == device.Orientation;
	}
}
