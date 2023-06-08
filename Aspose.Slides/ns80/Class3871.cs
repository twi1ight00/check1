using ns72;
using ns73;
using ns79;
using ns84;

namespace ns80;

internal class Class3871 : Class3866
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "cursor";

	public override Enum600 PropertyType => Enum600.const_89;

	public override bool IsInheritedProperty => true;

	static Class3871()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
		class3548_0.method_0("crosshair", Class3700.Class3702.class3689_116);
		class3548_0.method_0("default", Class3700.Class3702.class3689_117);
		class3548_0.method_0("pointer", Class3700.Class3702.class3689_118);
		class3548_0.method_0("move", Class3700.Class3702.class3689_119);
		class3548_0.method_0("e-resize", Class3700.Class3702.class3689_120);
		class3548_0.method_0("ne-resize", Class3700.Class3702.class3689_121);
		class3548_0.method_0("nw-resize", Class3700.Class3702.class3689_122);
		class3548_0.method_0("n-resize", Class3700.Class3702.class3689_123);
		class3548_0.method_0("se-resize", Class3700.Class3702.class3689_124);
		class3548_0.method_0("sw-resize", Class3700.Class3702.class3689_125);
		class3548_0.method_0("s-resize", Class3700.Class3702.class3689_126);
		class3548_0.method_0("w-resize", Class3700.Class3702.class3689_127);
		class3548_0.method_0("text", Class3700.Class3702.class3689_128);
		class3548_0.method_0("wait", Class3700.Class3702.class3689_129);
		class3548_0.method_0("help", Class3700.Class3702.class3689_130);
		class3548_0.method_0("progress", Class3700.Class3702.class3689_131);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_3;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}
}
