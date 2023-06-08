using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3961 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "white-space";

	public override Enum600 PropertyType => Enum600.const_282;

	public override bool IsInheritedProperty => true;

	static Class3961()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("pre", Class3700.Class3702.class3689_175);
		class3548_0.method_0("nowrap", Class3700.Class3702.class3689_176);
		class3548_0.method_0("pre-wrap", Class3700.Class3702.class3689_177);
		class3548_0.method_0("pre-line", Class3700.Class3702.class3689_178);
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
