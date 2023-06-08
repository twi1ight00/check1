using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3907 : Class3899
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "word-wrap";

	public override Enum600 PropertyType => Enum600.const_289;

	public override bool IsInheritedProperty => true;

	static Class3907()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("break-word", Class3700.Class3702.class3689_271);
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
