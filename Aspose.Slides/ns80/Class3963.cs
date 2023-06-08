using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3963 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "writing-mode";

	public override Enum600 PropertyType => Enum600.const_287;

	public override bool IsInheritedProperty => true;

	static Class3963()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("horizontal-tb", Class3700.Class3702.class3689_252);
		class3548_0.method_0("vertical-rl", Class3700.Class3702.class3689_253);
		class3548_0.method_0("vertical-lr", Class3700.Class3702.class3689_254);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_252;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
