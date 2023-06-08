using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3792 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "drop-initial-before-adjust";

	public override Enum600 PropertyType => Enum600.const_95;

	public override bool IsInheritedProperty => false;

	static Class3792()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("before-edge", Class3700.Class3702.class3689_41);
		class3548_0.method_0("text-before-edge", Class3700.Class3702.class3689_42);
		class3548_0.method_0("central", Class3700.Class3702.class3689_33);
		class3548_0.method_0("middle", Class3700.Class3702.class3689_34);
		class3548_0.method_0("hanging", Class3700.Class3702.class3689_43);
		class3548_0.method_0("mathematical", Class3700.Class3702.class3689_39);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_42;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
