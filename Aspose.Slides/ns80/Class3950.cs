using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3950 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "text-decoration-style";

	public override Enum600 PropertyType => Enum600.const_247;

	public override bool IsInheritedProperty => false;

	static Class3950()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("solid", Class3700.Class3702.class3689_105);
		class3548_0.method_0("double", Class3700.Class3702.class3689_106);
		class3548_0.method_0("dotted", Class3700.Class3702.class3689_103);
		class3548_0.method_0("dashed", Class3700.Class3702.class3689_104);
		class3548_0.method_0("wavy", Class3700.Class3702.class3689_184);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_105;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
