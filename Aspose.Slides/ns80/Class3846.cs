using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3846 : Class3771
{
	public override string PropertyName => "richness";

	public override Enum600 PropertyType => Enum600.const_220;

	public override bool IsInheritedProperty => false;

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3685_4;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3681 @class = base.vmethod_0(lu, engine) as Class3681;
		if (@class != null)
		{
			if (@class.PrimitiveType != 1)
			{
				throw Class4246.smethod_13(@class.CSSText);
			}
			float num = @class.vmethod_1(1);
			if (num < 0f || num > 100f)
			{
				throw Class4246.smethod_13(@class.CSSText);
			}
		}
		return @class;
	}
}
