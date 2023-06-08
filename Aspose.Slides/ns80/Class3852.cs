using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3852 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "background-attachment";

	public override Enum600 PropertyType => Enum600.const_17;

	public override bool IsInheritedProperty => false;

	static Class3852()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("fixed", Class3700.Class3702.class3689_2);
		class3548_0.method_0("scroll", Class3700.Class3702.class3689_1);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_1;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
