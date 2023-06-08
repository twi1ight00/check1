using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3913 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "font-variant-ligatures";

	public override Enum600 PropertyType => Enum600.const_122;

	public override bool IsInheritedProperty => true;

	static Class3913()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("common-ligatures", Class3700.Class3702.class3689_209);
		class3548_0.method_0("no-common-ligatures", Class3700.Class3702.class3689_210);
		class3548_0.method_0("discretionary-ligatures", Class3700.Class3702.class3689_211);
		class3548_0.method_0("no-discretionary-ligatures", Class3700.Class3702.class3689_212);
		class3548_0.method_0("historical-ligatures", Class3700.Class3702.class3689_213);
		class3548_0.method_0("no-historical-ligatures", Class3700.Class3702.class3689_214);
		class3548_0.method_0("contextual", Class3700.Class3702.class3689_215);
		class3548_0.method_0("no-contextual", Class3700.Class3702.class3689_216);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_5;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
