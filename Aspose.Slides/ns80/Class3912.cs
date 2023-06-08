using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3912 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "font-variant-east-asian";

	public override Enum600 PropertyType => Enum600.const_121;

	public override bool IsInheritedProperty => true;

	static Class3912()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("jis78", Class3700.Class3702.class3689_200);
		class3548_0.method_0("jis83", Class3700.Class3702.class3689_201);
		class3548_0.method_0("jis90", Class3700.Class3702.class3689_202);
		class3548_0.method_0("jis04", Class3700.Class3702.class3689_203);
		class3548_0.method_0("simplified", Class3700.Class3702.class3689_204);
		class3548_0.method_0("traditional", Class3700.Class3702.class3689_205);
		class3548_0.method_0("full-width", Class3700.Class3702.class3689_206);
		class3548_0.method_0("proportional-width", Class3700.Class3702.class3689_207);
		class3548_0.method_0("ruby", Class3700.Class3702.class3689_208);
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
