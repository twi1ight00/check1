using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4189 : Class4154
{
	private Class4337 class4337_0;

	private Class4337 class4337_1;

	public Class4337 Vertical => class4337_1;

	public Class4337 Horizontal => class4337_0;

	internal Class4189(Class3679 cssValue)
		: base(cssValue)
	{
		if (cssValue.CSSValueType == 2)
		{
			Class3691 @class = (Class3691)cssValue;
			if (@class.Length == 1)
			{
				class4337_0 = (class4337_1 = Class4338.smethod_3((Class3681)@class[0]));
				return;
			}
			class4337_0 = Class4338.smethod_3((Class3681)@class[0]);
			class4337_1 = Class4338.smethod_3((Class3681)@class[1]);
		}
		else
		{
			class4337_0 = (class4337_1 = Class4338.smethod_3((Class3681)cssValue));
		}
	}
}
