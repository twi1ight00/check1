using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3957 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "text-underline-position";

	public override Enum600 PropertyType => Enum600.const_260;

	public override bool IsInheritedProperty => true;

	static Class3957()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
		class3548_0.method_0("alphabetic", Class3700.Class3702.class3689_38);
		class3548_0.method_0("below", Class3700.Class3702.class3689_46);
		class3548_0.method_0("left", Class3700.Class3702.class3689_8);
		class3548_0.method_0("right", Class3700.Class3702.class3689_12);
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
