using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class4007 : Class4005
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "rest-before";

	public override Enum600 PropertyType => Enum600.const_219;

	public override bool IsInheritedProperty => false;

	static Class4007()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("x-weak", Class3700.Class3702.class3689_74);
		class3548_0.method_0("weak", Class3700.Class3702.class3689_75);
		class3548_0.method_0("medium", Class3700.Class3702.class3689_31);
		class3548_0.method_0("strong", Class3700.Class3702.class3689_76);
		class3548_0.method_0("x-strong", Class3700.Class3702.class3689_77);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_4;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
