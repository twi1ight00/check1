using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3946 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "text-align-last";

	public override Enum600 PropertyType => Enum600.const_240;

	public override bool IsInheritedProperty => true;

	static Class3946()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
		class3548_0.method_0("start", Class3700.Class3702.class3689_280);
		class3548_0.method_0("end", Class3700.Class3702.class3689_281);
		class3548_0.method_0("left", Class3700.Class3702.class3689_8);
		class3548_0.method_0("right", Class3700.Class3702.class3689_12);
		class3548_0.method_0("center", Class3700.Class3702.class3689_10);
		class3548_0.method_0("justify", Class3700.Class3702.class3689_179);
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
