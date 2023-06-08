using ns73;
using ns74;

namespace ns87;

internal class Class4222 : Class4154
{
	private Class4338 class4338_0;

	private Class4338 class4338_1;

	private Class4338 class4338_2;

	private Class4338 class4338_3;

	public Class4338 Top => class4338_0;

	public Class4338 Right => class4338_1;

	public Class4338 Bottom => class4338_2;

	public Class4338 Left => class4338_3;

	internal Class4222(Class3679 cssValue)
		: base(cssValue)
	{
		if (cssValue == Class3700.Class3702.class3689_3)
		{
			class4338_0 = Class4338.smethod_0();
			class4338_1 = Class4338.smethod_0();
			class4338_2 = Class4338.smethod_0();
			class4338_3 = Class4338.smethod_0();
		}
		else
		{
			Class4257 @class = ((Class3686)cssValue).vmethod_5();
			class4338_0 = Class4338.smethod_4(@class.Top);
			class4338_1 = Class4338.smethod_4(@class.Right);
			class4338_2 = Class4338.smethod_4(@class.Bottom);
			class4338_3 = Class4338.smethod_4(@class.Left);
		}
	}
}
