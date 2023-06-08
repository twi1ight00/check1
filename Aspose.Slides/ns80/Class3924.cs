using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3924 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "marquee-speed";

	public override Enum600 PropertyType => Enum600.const_170;

	public override bool IsInheritedProperty => false;

	static Class3924()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("slow", Class3700.Class3702.class3689_69);
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("fast", Class3700.Class3702.class3689_70);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_5;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
