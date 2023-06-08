using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3917 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "line-break";

	public override Enum600 PropertyType => Enum600.const_151;

	public override bool IsInheritedProperty => true;

	static Class3917()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
		class3548_0.method_0("loose", Class3700.Class3702.class3689_151);
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("strict", Class3700.Class3702.class3689_152);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_3;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
