using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3956 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "text-transform";

	public override Enum600 PropertyType => Enum600.const_259;

	public override bool IsInheritedProperty => true;

	static Class3956()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("capitalize", Class3700.Class3702.class3689_237);
		class3548_0.method_0("uppercase", Class3700.Class3702.class3689_238);
		class3548_0.method_0("lowercase", Class3700.Class3702.class3689_239);
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("full-width", Class3700.Class3702.class3689_206);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_4;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
