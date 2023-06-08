using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3937 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "ruby-overhang";

	public override Enum600 PropertyType => Enum600.const_225;

	public override bool IsInheritedProperty => true;

	static Class3937()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
		class3548_0.method_0("start", Class3700.Class3702.class3689_280);
		class3548_0.method_0("end", Class3700.Class3702.class3689_281);
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
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
