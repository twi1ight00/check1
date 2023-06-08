using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3922 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "list-style-type";

	public override Enum600 PropertyType => Enum600.const_160;

	public override bool IsInheritedProperty => true;

	static Class3922()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("disc", Class3700.Class3702.class3689_160);
		class3548_0.method_0("circle", Class3700.Class3702.class3689_161);
		class3548_0.method_0("square", Class3700.Class3702.class3689_162);
		class3548_0.method_0("decimal", Class3700.Class3702.class3689_163);
		class3548_0.method_0("decimal-leading-zero", Class3700.Class3702.class3689_164);
		class3548_0.method_0("lower-roman", Class3700.Class3702.class3689_165);
		class3548_0.method_0("upper-roman", Class3700.Class3702.class3689_166);
		class3548_0.method_0("lower-greek", Class3700.Class3702.class3689_167);
		class3548_0.method_0("lower-latin", Class3700.Class3702.class3689_168);
		class3548_0.method_0("upper-latin", Class3700.Class3702.class3689_169);
		class3548_0.method_0("armenian", Class3700.Class3702.class3689_170);
		class3548_0.method_0("georgian", Class3700.Class3702.class3689_171);
		class3548_0.method_0("lower-alpha", Class3700.Class3702.class3689_172);
		class3548_0.method_0("upper-alpha", Class3700.Class3702.class3689_173);
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_160;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
