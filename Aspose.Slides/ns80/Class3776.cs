using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3776 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "baseline-shift";

	public override Enum600 PropertyType => Enum600.const_25;

	public override bool IsInheritedProperty => false;

	static Class3776()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("baseline", Class3700.Class3702.class3689_20);
		class3548_0.method_0("sub", Class3700.Class3702.class3689_21);
		class3548_0.method_0("super", Class3700.Class3702.class3689_22);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_20;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
