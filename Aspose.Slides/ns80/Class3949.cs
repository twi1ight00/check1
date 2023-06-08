using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3949 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "text-decoration-skip";

	public override Enum600 PropertyType => Enum600.const_246;

	public override bool IsInheritedProperty => true;

	static Class3949()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("objects", Class3700.Class3702.class3689_255);
		class3548_0.method_0("spaces", Class3700.Class3702.class3689_256);
		class3548_0.method_0("ink", Class3700.Class3702.class3689_257);
		class3548_0.method_0("edges", Class3700.Class3702.class3689_258);
		class3548_0.method_0("box-decoration", Class3700.Class3702.class3689_259);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_255;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
