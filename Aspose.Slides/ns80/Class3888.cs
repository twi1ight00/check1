using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3888 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "clear";

	public override Enum600 PropertyType => Enum600.const_69;

	public override bool IsInheritedProperty => true;

	static Class3888()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("left", Class3700.Class3702.class3689_8);
		class3548_0.method_0("right", Class3700.Class3702.class3689_12);
		class3548_0.method_0("both", Class3700.Class3702.class3689_147);
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
