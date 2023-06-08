using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3897 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "empty-cells";

	public override Enum600 PropertyType => Enum600.const_100;

	public override bool IsInheritedProperty => true;

	static Class3897()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("show", Class3700.Class3702.class3689_155);
		class3548_0.method_0("hide", Class3700.Class3702.class3689_156);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_155;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
