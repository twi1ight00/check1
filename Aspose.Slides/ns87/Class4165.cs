using ns73;
using ns84;

namespace ns87;

internal class Class4165 : Class4154
{
	private readonly Enum517 enum517_0;

	private readonly Enum517 enum517_1;

	public Enum517 Horizontal => enum517_0;

	public Enum517 Vertical => enum517_1;

	internal Class4165(Class3679 cssValue)
		: base(cssValue)
	{
		Interface55<Enum517> @interface = Class4342.smethod_0<Enum517>();
		if (cssValue.CSSValueType == 2)
		{
			Class3691 @class = (Class3691)cssValue;
			if (@class.Length == 1)
			{
				enum517_0 = (enum517_1 = @interface.imethod_3(((Class3680)@class[0]).vmethod_3()));
				return;
			}
			enum517_0 = @interface.imethod_3(((Class3680)@class[0]).vmethod_3());
			enum517_1 = @interface.imethod_3(((Class3680)@class[1]).vmethod_3());
		}
		else
		{
			enum517_1 = (enum517_0 = @interface.imethod_3(((Class3680)cssValue).vmethod_3()));
		}
	}
}
