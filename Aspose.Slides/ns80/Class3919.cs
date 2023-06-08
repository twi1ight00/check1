using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3919 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "line-stacking-shift";

	public override Enum600 PropertyType => Enum600.const_155;

	public override bool IsInheritedProperty => false;

	static Class3919()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("consider-shifts", Class3700.Class3702.class3689_326);
		class3548_0.method_0("disregard-shifts", Class3700.Class3702.class3689_327);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_326;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
