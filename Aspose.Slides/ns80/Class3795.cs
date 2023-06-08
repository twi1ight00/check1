using System.Collections.Generic;
using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3795 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "fit-position";

	public override Enum600 PropertyType => Enum600.const_102;

	public override bool IsInheritedProperty => false;

	static Class3795()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("left", Class3700.Class3702.class3689_8);
		class3548_0.method_0("center", Class3700.Class3702.class3689_10);
		class3548_0.method_0("right", Class3700.Class3702.class3689_12);
		class3548_0.method_0("top", Class3700.Class3702.class3689_23);
		class3548_0.method_0("bottom", Class3700.Class3702.class3689_24);
	}

	public override Class3679 vmethod_1()
	{
		Class3691 @class = new Class3691();
		@class.Add(Class3700.Class3702.class3685_18);
		@class.Add(Class3700.Class3702.class3685_18);
		return @class;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3691 @class = new Class3691();
		do
		{
			@class.Add(base.vmethod_0(lu, engine));
			lu = lu.NextLexicalUnit;
		}
		while (lu != null);
		return @class;
	}

	public override Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		List<Class3679> list = new List<Class3679>((Class3691)value);
		if (list.Count == 1)
		{
			list.Add(Class3700.Class3702.class3689_10);
		}
		if (method_5(list[0]) && method_5(list[1]))
		{
			if (list[0] != Class3700.Class3702.class3689_8 && list[0] != Class3700.Class3702.class3689_12 && list[1] != Class3700.Class3702.class3689_23 && list[1] != Class3700.Class3702.class3689_24)
			{
				if (list[0] != Class3700.Class3702.class3689_23 && list[0] != Class3700.Class3702.class3689_24 && list[1] != Class3700.Class3702.class3689_8 && list[1] != Class3700.Class3702.class3689_12)
				{
					list[0] = method_7(list[0]);
					list[1] = method_8(list[1]);
				}
				else
				{
					Class3679 value2 = method_7(list[1]);
					Class3679 value3 = method_8(list[0]);
					list[0] = value2;
					list[1] = value3;
				}
			}
			else
			{
				list[0] = method_7(list[0]);
				list[1] = method_8(list[1]);
			}
		}
		else
		{
			list[0] = method_7(list[0]);
			list[1] = method_8(list[1]);
		}
		return new Class3691(list);
	}

	private Class3679 method_7(Class3679 value)
	{
		if (method_5(value))
		{
			if (value == Class3700.Class3702.class3689_8)
			{
				return Class3700.Class3702.class3685_18;
			}
			if (value == Class3700.Class3702.class3689_10)
			{
				return Class3700.Class3702.class3685_19;
			}
			if (value == Class3700.Class3702.class3689_12)
			{
				return Class3700.Class3702.class3685_20;
			}
			throw Class4246.smethod_7(value.CSSText);
		}
		return value;
	}

	private Class3679 method_8(Class3679 value)
	{
		if (method_5(value))
		{
			if (value == Class3700.Class3702.class3689_23)
			{
				return Class3700.Class3702.class3685_18;
			}
			if (value == Class3700.Class3702.class3689_10)
			{
				return Class3700.Class3702.class3685_19;
			}
			if (value == Class3700.Class3702.class3689_24)
			{
				return Class3700.Class3702.class3685_20;
			}
			throw Class4246.smethod_7(value.CSSText);
		}
		return value;
	}
}
