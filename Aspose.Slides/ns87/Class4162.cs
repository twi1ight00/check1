using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4162 : Class4154
{
	private Class4337 class4337_0;

	private bool bool_0;

	public Class4337 Size => class4337_0;

	public bool IsAuto => bool_0;

	internal Class4162(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			bool_0 = true;
		}
		else
		{
			class4337_0 = Class4338.smethod_3((Class3681)cssValue);
		}
	}
}
