using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3945 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "target-position";

	public override Enum600 PropertyType => Enum600.const_293;

	public override bool IsInheritedProperty => false;

	static Class3945()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("above", Class3700.Class3702.class3689_48);
		class3548_0.method_0("behind", Class3700.Class3702.class3689_15);
		class3548_0.method_0("front", Class3700.Class3702.class3689_335);
		class3548_0.method_0("back", Class3700.Class3702.class3689_336);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_48;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
