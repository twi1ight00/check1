using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3902 : Class3899
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "hanging-punctuation";

	public override Enum600 PropertyType => Enum600.const_140;

	public override bool IsInheritedProperty => true;

	static Class3902()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("first", Class3700.Class3702.class3689_268);
		class3548_0.method_0("last", Class3700.Class3702.class3689_89);
		class3548_0.method_0("allow-end", Class3700.Class3702.class3689_269);
		class3548_0.method_0("force-end", Class3700.Class3702.class3689_270);
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
