using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3794 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "drop-initial-value";

	public override Enum600 PropertyType => Enum600.const_98;

	public override bool IsInheritedProperty => false;

	static Class3794()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("initial", Class3700.Class3702.class3689_45);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_45;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3679 @class = base.vmethod_0(lu, engine);
		if (@class.CSSValueType == 1)
		{
			Class3680 class2 = (Class3680)@class;
			if (class2.PrimitiveType == 21)
			{
				return @class;
			}
			if (class2.PrimitiveType != 1)
			{
				throw method_2(lu);
			}
		}
		return @class;
	}
}
