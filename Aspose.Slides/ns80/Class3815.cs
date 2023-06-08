using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3815 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "speak-as";

	public override Enum600 PropertyType => Enum600.const_230;

	public override bool IsInheritedProperty => true;

	static Class3815()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("spell-out", Class3700.Class3702.class3689_245);
		class3548_0.method_0("digits", Class3700.Class3702.class3689_235);
		class3548_0.method_0("literal-punctuation", Class3700.Class3702.class3689_285);
		class3548_0.method_0("no-punctuation", Class3700.Class3702.class3689_286);
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
