using ns73;
using ns84;

namespace ns87;

internal class Class4204 : Class4154
{
	private Enum583 enum583_0;

	private Enum583 enum583_1;

	public Enum583 Horizontal => enum583_0;

	public Enum583 Vertical => enum583_1;

	internal Class4204(Class3679 cssValue)
		: base(cssValue)
	{
		if (cssValue.CSSValueType == 1)
		{
			enum583_0 = (enum583_1 = Class4342.smethod_0<Enum583>().imethod_3(method_0()));
			return;
		}
		Class3691 @class = cssValue as Class3691;
		enum583_0 = Class4342.smethod_0<Enum583>().imethod_3(((Class3680)@class[0]).vmethod_3());
		enum583_1 = Class4342.smethod_0<Enum583>().imethod_3(((Class3680)@class[1]).vmethod_3());
	}
}
