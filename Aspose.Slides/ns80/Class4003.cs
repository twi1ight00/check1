using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class4003 : Class4002
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "pitch";

	public override Enum600 PropertyType => Enum600.const_211;

	public override bool IsInheritedProperty => true;

	static Class4003()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("x-low", Class3700.Class3702.class3689_60);
		class3548_0.method_0("low", Class3700.Class3702.class3689_61);
		class3548_0.method_0("medium", Class3700.Class3702.class3689_31);
		class3548_0.method_0("high", Class3700.Class3702.class3689_62);
		class3548_0.method_0("x-high", Class3700.Class3702.class3689_63);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_31;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
