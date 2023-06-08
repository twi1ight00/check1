using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4167 : Class4154
{
	private readonly Class4337 class4337_0;

	public Class4337 Value => class4337_0;

	internal Class4167(Class3679 cssValue)
		: base(cssValue)
	{
		if (cssValue != Class3700.Class3702.class3689_23 && cssValue != Class3700.Class3702.class3689_8)
		{
			if (cssValue == Class3700.Class3702.class3689_10)
			{
				class4337_0 = new Class4337(50f, Enum634.const_1);
			}
			else if (cssValue != Class3700.Class3702.class3689_12 && cssValue != Class3700.Class3702.class3689_24)
			{
				class4337_0 = Class4338.smethod_3((Class3681)cssValue);
			}
			else
			{
				class4337_0 = new Class4337(100f, Enum634.const_1);
			}
		}
		else
		{
			class4337_0 = new Class4337(0f, Enum634.const_1);
		}
	}
}
