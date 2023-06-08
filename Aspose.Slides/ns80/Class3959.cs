using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3959 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "visibility";

	public override Enum600 PropertyType => Enum600.const_272;

	public override bool IsInheritedProperty => true;

	static Class3959()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("visible", Class3700.Class3702.class3689_148);
		class3548_0.method_0("hidden", Class3700.Class3702.class3689_102);
		class3548_0.method_0("collapse", Class3700.Class3702.class3689_111);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_148;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
