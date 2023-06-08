using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3773 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "alignment-adjust";

	public override Enum600 PropertyType => Enum600.const_2;

	public override bool IsInheritedProperty => false;

	static Class3773()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
		class3548_0.method_0("baseline", Class3700.Class3702.class3689_20);
		class3548_0.method_0("before-edge", Class3700.Class3702.class3689_41);
		class3548_0.method_0("text-before-edge", Class3700.Class3702.class3689_42);
		class3548_0.method_0("middle", Class3700.Class3702.class3689_34);
		class3548_0.method_0("central", Class3700.Class3702.class3689_33);
		class3548_0.method_0("after-edge", Class3700.Class3702.class3689_35);
		class3548_0.method_0("text-after-edge", Class3700.Class3702.class3689_36);
		class3548_0.method_0("ideographic", Class3700.Class3702.class3689_37);
		class3548_0.method_0("alphabetic", Class3700.Class3702.class3689_38);
		class3548_0.method_0("hanging", Class3700.Class3702.class3689_43);
		class3548_0.method_0("mathematical", Class3700.Class3702.class3689_39);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_3;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
