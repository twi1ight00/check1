using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3930 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "overflow-y";

	public override Enum600 PropertyType => Enum600.const_196;

	public override bool IsInheritedProperty => false;

	static Class3930()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("visible", Class3700.Class3702.class3689_148);
		class3548_0.method_0("hidden", Class3700.Class3702.class3689_102);
		class3548_0.method_0("scroll", Class3700.Class3702.class3689_1);
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_148;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
