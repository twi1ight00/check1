using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3891 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "column-span";

	public override Enum600 PropertyType => Enum600.const_80;

	public override bool IsInheritedProperty => false;

	static Class3891()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("all", Class3700.Class3702.class3689_85);
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
