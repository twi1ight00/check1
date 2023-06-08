using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3911 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "font-variant-caps";

	public override Enum600 PropertyType => Enum600.const_120;

	public override bool IsInheritedProperty => true;

	static Class3911()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("small-caps", Class3700.Class3702.class3689_194);
		class3548_0.method_0("all-small-caps", Class3700.Class3702.class3689_195);
		class3548_0.method_0("petite-caps", Class3700.Class3702.class3689_196);
		class3548_0.method_0("all-petite-caps", Class3700.Class3702.class3689_197);
		class3548_0.method_0("unicase", Class3700.Class3702.class3689_198);
		class3548_0.method_0("titling-caps", Class3700.Class3702.class3689_199);
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
