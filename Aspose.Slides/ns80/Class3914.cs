using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3914 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "font-variant-numeric";

	public override Enum600 PropertyType => Enum600.const_123;

	public override bool IsInheritedProperty => true;

	static Class3914()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("lining-nums", Class3700.Class3702.class3689_217);
		class3548_0.method_0("oldstyle-nums", Class3700.Class3702.class3689_218);
		class3548_0.method_0("proportional-nums", Class3700.Class3702.class3689_219);
		class3548_0.method_0("tabular-nums", Class3700.Class3702.class3689_220);
		class3548_0.method_0("diagonal-fractions", Class3700.Class3702.class3689_221);
		class3548_0.method_0("stacked-fractions", Class3700.Class3702.class3689_222);
		class3548_0.method_0("ordinal", Class3700.Class3702.class3689_223);
		class3548_0.method_0("slashed-zero", Class3700.Class3702.class3689_224);
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
