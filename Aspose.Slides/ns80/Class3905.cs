using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3905 : Class3899
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "target-name";

	public override Enum600 PropertyType => Enum600.const_295;

	public override bool IsInheritedProperty => true;

	static Class3905()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("current", Class3700.Class3702.class3689_80);
		class3548_0.method_0("root", Class3700.Class3702.class3689_81);
		class3548_0.method_0("parent", Class3700.Class3702.class3689_82);
		class3548_0.method_0("new", Class3700.Class3702.class3689_83);
		class3548_0.method_0("modal", Class3700.Class3702.class3689_84);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_80;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
