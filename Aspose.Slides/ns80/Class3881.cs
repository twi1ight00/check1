using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;

namespace ns80;

internal class Class3881 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "border-left-style";

	public override Enum600 PropertyType => Enum600.const_48;

	public override bool IsInheritedProperty => false;

	static Class3881()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("hidden", Class3700.Class3702.class3689_102);
		class3548_0.method_0("dotted", Class3700.Class3702.class3689_103);
		class3548_0.method_0("dashed", Class3700.Class3702.class3689_104);
		class3548_0.method_0("solid", Class3700.Class3702.class3689_105);
		class3548_0.method_0("double", Class3700.Class3702.class3689_106);
		class3548_0.method_0("groove", Class3700.Class3702.class3689_107);
		class3548_0.method_0("ridge", Class3700.Class3702.class3689_108);
		class3548_0.method_0("inset", Class3700.Class3702.class3689_109);
		class3548_0.method_0("outset", Class3700.Class3702.class3689_110);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_4;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		if (value == Class3700.Class3702.class3689_45)
		{
			return Class3700.Class3702.class3689_4;
		}
		return base.vmethod_2(element, engine, pseudoElement, map, value, propertyIndex);
	}
}
