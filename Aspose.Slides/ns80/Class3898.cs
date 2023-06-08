using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3898 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "fit";

	public override Enum600 PropertyType => Enum600.const_101;

	public override bool IsInheritedProperty => false;

	static Class3898()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("fill", Class3700.Class3702.class3689_29);
		class3548_0.method_0("hidden", Class3700.Class3702.class3689_102);
		class3548_0.method_0("meet", Class3700.Class3702.class3689_293);
		class3548_0.method_0("slice", Class3700.Class3702.class3689_294);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_29;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
