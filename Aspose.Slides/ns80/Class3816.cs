using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3816 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "speech-rate";

	public override Enum600 PropertyType => Enum600.const_234;

	public override bool IsInheritedProperty => false;

	static Class3816()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("x-slow", Class3700.Class3702.class3689_68);
		class3548_0.method_0("slow", Class3700.Class3702.class3689_69);
		class3548_0.method_0("medium", Class3700.Class3702.class3689_31);
		class3548_0.method_0("fast", Class3700.Class3702.class3689_70);
		class3548_0.method_0("x-fast", Class3700.Class3702.class3689_71);
		class3548_0.method_0("faster", Class3700.Class3702.class3689_72);
		class3548_0.method_0("slower", Class3700.Class3702.class3689_73);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_31;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3679 @class = base.vmethod_0(lu, engine);
		if (@class is Class3685 && ((Class3680)@class).PrimitiveType != 1)
		{
			throw Class4246.smethod_11(lu.LexicalUnitType);
		}
		return @class;
	}
}
