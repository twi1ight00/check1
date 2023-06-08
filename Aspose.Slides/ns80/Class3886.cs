using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3886 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "break-inside";

	public override Enum600 PropertyType => Enum600.const_292;

	public override bool IsInheritedProperty => false;

	static Class3886()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
		class3548_0.method_0("avoid", Class3700.Class3702.class3689_191);
		class3548_0.method_0("always", Class3700.Class3702.class3689_190);
		class3548_0.method_0("page", Class3700.Class3702.class3689_305);
		class3548_0.method_0("left", Class3700.Class3702.class3689_8);
		class3548_0.method_0("right", Class3700.Class3702.class3689_12);
		class3548_0.method_0("recto", Class3700.Class3702.class3689_306);
		class3548_0.method_0("verso", Class3700.Class3702.class3689_307);
		class3548_0.method_0("column", Class3700.Class3702.class3689_308);
		class3548_0.method_0("region", Class3700.Class3702.class3689_309);
		class3548_0.method_0("avoid-page", Class3700.Class3702.class3689_310);
		class3548_0.method_0("avoid-column", Class3700.Class3702.class3689_311);
		class3548_0.method_0("avoid-region", Class3700.Class3702.class3689_312);
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
