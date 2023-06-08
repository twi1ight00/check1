using ns73;
using ns84;

namespace ns87;

internal class Class4225 : Class4154
{
	private readonly Class4337 class4337_0;

	private readonly bool bool_0;

	public Class4337 Size => class4337_0;

	public bool IsNormal => bool_0;

	internal Class4225(Class3679 cssValue)
		: base(cssValue)
	{
		if (Class3700.Class3702.class3689_5 == cssValue)
		{
			bool_0 = true;
		}
		else
		{
			class4337_0 = Class4338.smethod_4(cssValue);
		}
	}
}
