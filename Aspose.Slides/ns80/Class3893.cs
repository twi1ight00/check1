using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3893 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "direction";

	public override Enum600 PropertyType => Enum600.const_90;

	public override bool IsInheritedProperty => true;

	static Class3893()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("ltr", Class3700.Class3702.class3689_149);
		class3548_0.method_0("rtl", Class3700.Class3702.class3689_150);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_149;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
