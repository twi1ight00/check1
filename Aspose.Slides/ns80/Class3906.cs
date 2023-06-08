using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3906 : Class3899
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "text-emphasis-style";

	public override Enum600 PropertyType => Enum600.const_251;

	public override bool IsInheritedProperty => true;

	static Class3906()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("filled", Class3700.Class3702.class3689_260);
		class3548_0.method_0("open", Class3700.Class3702.class3689_261);
		class3548_0.method_0("dot", Class3700.Class3702.class3689_262);
		class3548_0.method_0("circle", Class3700.Class3702.class3689_161);
		class3548_0.method_0("double-circle", Class3700.Class3702.class3689_263);
		class3548_0.method_0("triangle", Class3700.Class3702.class3689_264);
		class3548_0.method_0("sesame", Class3700.Class3702.class3689_265);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_4;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		switch (lu.LexicalUnitType)
		{
		default:
			throw method_1(lu.LexicalUnitType);
		case 35:
		{
			Class3679 @class = vmethod_3().method_1(lu.imethod_5());
			if (@class == null)
			{
				throw method_0(lu.imethod_5());
			}
			return @class;
		}
		case 36:
			return Class3689.smethod_0(lu.imethod_5());
		case 12:
			return Class3700.Class3702.class3695_0;
		}
	}
}
