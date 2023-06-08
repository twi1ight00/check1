using ns73;
using ns84;

namespace ns87;

internal class Class4219 : Class4154
{
	private readonly Class4337 class4337_0;

	private readonly Class4337 class4337_1;

	public Class4337 Horizontal => class4337_0;

	public Class4337 Vertical => class4337_1;

	internal Class4219(Class3679 cssValue)
		: base(cssValue)
	{
		Class3691 @class = cssValue as Class3691;
		class4337_0 = Class4338.smethod_4(@class[0]);
		class4337_1 = Class4338.smethod_4(@class[1]);
	}
}
