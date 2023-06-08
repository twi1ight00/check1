using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3796 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "font-size-adjust";

	public override Enum600 PropertyType => Enum600.const_116;

	public override bool IsInheritedProperty => true;

	static Class3796()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("auto", Class3700.Class3702.class3689_4);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_4;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3679 @class = base.vmethod_0(lu, engine);
		if (@class.CSSValueType == 1 && ((Class3680)@class).PrimitiveType != 21 && @class is Class3685 class2 && class2.PrimitiveType != 1)
		{
			throw Class4246.smethod_13(class2.CSSText);
		}
		return @class;
	}
}
