using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3863 : Class3862
{
	private static Class3548<Class3679> class3548_2;

	public override string PropertyName => "outline-color";

	public override Enum600 PropertyType => Enum600.const_188;

	public override bool IsInheritedProperty => true;

	static Class3863()
	{
		class3548_2 = new Class3548<Class3679>();
		class3548_2.method_0("invert", Class3700.Class3702.class3689_157);
	}

	protected override Class3548<Class3679> vmethod_4()
	{
		return class3548_2;
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_157;
	}
}
