using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3847 : Class3771
{
	public override string PropertyName => "stress";

	public override Enum600 PropertyType => Enum600.const_235;

	public override bool IsInheritedProperty => false;

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3685_4;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3679 @class = base.vmethod_0(lu, engine);
		if (@class.CSSValueType == 1)
		{
			Class3681 class2 = (Class3681)@class;
			if (class2.PrimitiveType != 1)
			{
				throw Class4246.smethod_13(class2.CSSText);
			}
		}
		return @class;
	}
}
