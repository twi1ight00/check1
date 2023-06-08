using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3820 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "voice-balance";

	public override Enum600 PropertyType => Enum600.const_273;

	public override bool IsInheritedProperty => true;

	static Class3820()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("left", Class3700.Class3702.class3689_8);
		class3548_0.method_0("center", Class3700.Class3702.class3689_10);
		class3548_0.method_0("right", Class3700.Class3702.class3689_12);
		class3548_0.method_0("leftwards", Class3700.Class3702.class3689_16);
		class3548_0.method_0("rightwards", Class3700.Class3702.class3689_17);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_10;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
