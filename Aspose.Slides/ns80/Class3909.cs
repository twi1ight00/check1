using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3909 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "font-style";

	public override Enum600 PropertyType => Enum600.const_118;

	public override bool IsInheritedProperty => true;

	static Class3909()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("italic", Class3700.Class3702.class3689_225);
		class3548_0.method_0("oblique", Class3700.Class3702.class3689_226);
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
