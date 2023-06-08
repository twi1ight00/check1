using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3967 : Class3965
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "elevation";

	public override Enum600 PropertyType => Enum600.const_99;

	public override bool IsInheritedProperty => true;

	static Class3967()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("below", Class3700.Class3702.class3689_46);
		class3548_0.method_0("level", Class3700.Class3702.class3689_47);
		class3548_0.method_0("above", Class3700.Class3702.class3689_48);
		class3548_0.method_0("higher", Class3700.Class3702.class3689_49);
		class3548_0.method_0("lower", Class3700.Class3702.class3689_50);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_47;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
