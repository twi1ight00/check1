using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3887 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "caption-side";

	public override Enum600 PropertyType => Enum600.const_68;

	public override bool IsInheritedProperty => false;

	static Class3887()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("top", Class3700.Class3702.class3689_23);
		class3548_0.method_0("bottom", Class3700.Class3702.class3689_24);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_23;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
