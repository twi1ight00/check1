using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4185 : Class4154
{
	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private Class4337 class4337_0;

	private Class4337 class4337_1;

	private Class4337 class4337_2;

	private Class4337 class4337_3;

	public Class4337 Top => class4337_0;

	public Class4337 Right => class4337_1;

	public Class4337 Bottom => class4337_2;

	public Class4337 Left => class4337_3;

	public bool IsInsetRect => bool_2;

	public bool IsRec => bool_1;

	public bool IsAuto => bool_0;

	internal Class4185(Class3679 cssValue)
		: base(cssValue)
	{
		if (cssValue == Class3700.Class3702.class3689_3)
		{
			bool_0 = true;
			class4337_0 = Class4338.smethod_0();
			class4337_1 = Class4338.smethod_0();
			class4337_2 = Class4338.smethod_0();
			class4337_3 = Class4338.smethod_0();
		}
		else if (((Class3680)cssValue).PrimitiveType == 24)
		{
			if (cssValue is Class3687)
			{
				bool_2 = true;
			}
			else
			{
				bool_1 = true;
			}
			Class4257 @class = ((Class3686)cssValue).vmethod_5();
			class4337_0 = Class4338.smethod_4(@class.Top);
			class4337_1 = Class4338.smethod_4(@class.Right);
			class4337_2 = Class4338.smethod_4(@class.Bottom);
			class4337_3 = Class4338.smethod_4(@class.Left);
		}
	}
}
