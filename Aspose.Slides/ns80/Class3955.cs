using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3955 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "text-space-collapse";

	public override Enum600 PropertyType => Enum600.const_258;

	public override bool IsInheritedProperty => true;

	static Class3955()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("collapse", Class3700.Class3702.class3689_111);
		class3548_0.method_0("preserve", Class3700.Class3702.class3689_272);
		class3548_0.method_0("preserve-breaks", Class3700.Class3702.class3689_273);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_111;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
