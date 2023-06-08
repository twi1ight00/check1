using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3920 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "line-stacking-strategy";

	public override Enum600 PropertyType => Enum600.const_156;

	public override bool IsInheritedProperty => false;

	static Class3920()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("inline-line-height", Class3700.Class3702.class3689_328);
		class3548_0.method_0("block-line-height", Class3700.Class3702.class3689_329);
		class3548_0.method_0("max-height", Class3700.Class3702.class3689_330);
		class3548_0.method_0("grid-height", Class3700.Class3702.class3689_331);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_328;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
