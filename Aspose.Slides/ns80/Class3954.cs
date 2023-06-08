using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3954 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "text-orientation";

	public override Enum600 PropertyType => Enum600.const_255;

	public override bool IsInheritedProperty => true;

	static Class3954()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("mixed", Class3700.Class3702.class3689_274);
		class3548_0.method_0("upright", Class3700.Class3702.class3689_275);
		class3548_0.method_0("sideways-right", Class3700.Class3702.class3689_276);
		class3548_0.method_0("sideways-left", Class3700.Class3702.class3689_277);
		class3548_0.method_0("sideways", Class3700.Class3702.class3689_278);
		class3548_0.method_0("use-glyph-orientation", Class3700.Class3702.class3689_279);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_274;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
