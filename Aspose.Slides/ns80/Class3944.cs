using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3944 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "target-new";

	public override Enum600 PropertyType => Enum600.const_294;

	public override bool IsInheritedProperty => false;

	static Class3944()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("window", Class3700.Class3702.class3689_333);
		class3548_0.method_0("tab", Class3700.Class3702.class3689_334);
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_333;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
