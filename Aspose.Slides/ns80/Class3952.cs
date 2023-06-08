using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3952 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "text-height";

	public override Enum600 PropertyType => Enum600.const_252;

	public override bool IsInheritedProperty => false;

	static Class3952()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
		class3548_0.method_0("font-size", Class3700.Class3702.class3689_321);
		class3548_0.method_0("text-size", Class3700.Class3702.class3689_322);
		class3548_0.method_0("max-size", Class3700.Class3702.class3689_323);
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
