using ns73;
using ns84;

namespace ns87;

internal class Class4230 : Class4154
{
	private readonly Class4338 class4338_0;

	public bool IsAuto => class4338_0.Auto;

	public Class4337 Value => class4338_0;

	internal Class4230(Class3679 cssValue)
		: base(cssValue)
	{
		class4338_0 = Class4338.smethod_4(cssValue);
	}
}
