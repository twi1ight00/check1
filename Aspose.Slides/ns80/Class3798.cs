using ns305;
using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3798 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "font-weight";

	public override Enum600 PropertyType => Enum600.const_126;

	public override bool IsInheritedProperty => true;

	static Class3798()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("bold", Class3700.Class3702.class3689_79);
		class3548_0.method_0("bolder", Class3700.Class3702.class3689_192);
		class3548_0.method_0("lighter", Class3700.Class3702.class3689_193);
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_5;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		switch (lu.LexicalUnitType)
		{
		case 35:
		{
			Class3679 @class = vmethod_3().method_1(lu.imethod_5().ToLowerInvariant());
			if (@class == null)
			{
				throw method_0(lu.imethod_5());
			}
			return @class;
		}
		case 12:
			return Class3700.Class3702.class3695_0;
		case 13:
			switch (lu.imethod_0())
			{
			case 200:
				return Class3700.Class3702.class3685_10;
			case 100:
				return Class3700.Class3702.class3685_7;
			case 400:
				return Class3700.Class3702.class3685_12;
			case 300:
				return Class3700.Class3702.class3685_11;
			case 600:
				return Class3700.Class3702.class3685_14;
			case 500:
				return Class3700.Class3702.class3685_13;
			case 900:
				return Class3700.Class3702.class3685_17;
			case 800:
				return Class3700.Class3702.class3685_16;
			case 700:
				return Class3700.Class3702.class3685_15;
			}
			break;
		}
		throw Class4246.smethod_11(lu.LexicalUnitType);
	}

	public override Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		value = base.vmethod_2(element, engine, pseudoElement, map, value, propertyIndex);
		if (value == Class3700.Class3702.class3689_5)
		{
			return Class3700.Class3702.class3685_12;
		}
		if (value == Class3700.Class3702.class3689_79)
		{
			return Class3700.Class3702.class3685_15;
		}
		if (value == Class3700.Class3702.class3689_192)
		{
			Interface91 @interface = Class3726.smethod_0((Class6981)element);
			int num = 400;
			if (@interface != null)
			{
				num = (int)((Class3685)engine.method_9(@interface, pseudoElement, propertyIndex)).vmethod_1(1);
			}
			switch (num)
			{
			case 100:
			case 200:
			case 300:
				return Class3700.Class3702.class3685_12;
			case 400:
			case 500:
				return Class3700.Class3702.class3685_15;
			default:
				return Class3700.Class3702.class3685_17;
			case 600:
			case 700:
			case 800:
			case 900:
				return Class3700.Class3702.class3685_17;
			}
		}
		if (value == Class3700.Class3702.class3689_193)
		{
			Interface91 interface2 = Class3726.smethod_0((Class6981)element);
			int num2 = 400;
			if (interface2 != null)
			{
				num2 = (int)((Class3685)engine.method_9(interface2, pseudoElement, propertyIndex)).vmethod_1(1);
			}
			switch (num2)
			{
			case 100:
			case 200:
			case 300:
			case 400:
			case 500:
				return Class3700.Class3702.class3685_7;
			default:
				return Class3700.Class3702.class3685_7;
			case 800:
			case 900:
				return Class3700.Class3702.class3685_15;
			case 600:
			case 700:
				return Class3700.Class3702.class3685_12;
			}
		}
		return value;
	}
}
