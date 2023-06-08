using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3927 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "object-fit";

	public override Enum600 PropertyType => Enum600.const_182;

	public override bool IsInheritedProperty => false;

	static Class3927()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("fill", Class3700.Class3702.class3689_29);
		class3548_0.method_0("contain", Class3700.Class3702.class3689_19);
		class3548_0.method_0("cover", Class3700.Class3702.class3689_18);
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("scale-down", Class3700.Class3702.class3689_332);
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
