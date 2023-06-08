using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3938 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "ruby-position";

	public override Enum600 PropertyType => Enum600.const_226;

	public override bool IsInheritedProperty => true;

	static Class3938()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("before", Class3700.Class3702.class3689_290);
		class3548_0.method_0("after", Class3700.Class3702.class3689_291);
		class3548_0.method_0("inter-character", Class3700.Class3702.class3689_292);
		class3548_0.method_0("inline", Class3700.Class3702.class3689_132);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_290;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
