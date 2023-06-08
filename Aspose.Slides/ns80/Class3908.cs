using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3908 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "font-stretch";

	public override Enum600 PropertyType => Enum600.const_117;

	public override bool IsInheritedProperty => true;

	static Class3908()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("ultra-condensed", Class3700.Class3702.class3689_227);
		class3548_0.method_0("extra-condensed", Class3700.Class3702.class3689_228);
		class3548_0.method_0("condensed", Class3700.Class3702.class3689_229);
		class3548_0.method_0("semi-condensed", Class3700.Class3702.class3689_230);
		class3548_0.method_0("semi-expanded", Class3700.Class3702.class3689_231);
		class3548_0.method_0("expanded", Class3700.Class3702.class3689_232);
		class3548_0.method_0("extra-expanded", Class3700.Class3702.class3689_233);
		class3548_0.method_0("ultra-expanded", Class3700.Class3702.class3689_234);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_5;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
