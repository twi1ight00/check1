using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3935 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "position";

	public override Enum600 PropertyType => Enum600.const_214;

	public override bool IsInheritedProperty => false;

	static Class3935()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("static", Class3700.Class3702.class3689_113);
		class3548_0.method_0("relative", Class3700.Class3702.class3689_114);
		class3548_0.method_0("absolute", Class3700.Class3702.class3689_115);
		class3548_0.method_0("fixed", Class3700.Class3702.class3689_2);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_113;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
