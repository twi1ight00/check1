using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3966 : Class3965
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "azimuth";

	public override Enum600 PropertyType => Enum600.const_14;

	public override bool IsInheritedProperty => true;

	static Class3966()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("left-side", Class3700.Class3702.class3689_6);
		class3548_0.method_0("far-left", Class3700.Class3702.class3689_7);
		class3548_0.method_0("left", Class3700.Class3702.class3689_8);
		class3548_0.method_0("center-left", Class3700.Class3702.class3689_9);
		class3548_0.method_0("center", Class3700.Class3702.class3689_10);
		class3548_0.method_0("center-right", Class3700.Class3702.class3689_11);
		class3548_0.method_0("right", Class3700.Class3702.class3689_12);
		class3548_0.method_0("far-right", Class3700.Class3702.class3689_13);
		class3548_0.method_0("right-side", Class3700.Class3702.class3689_14);
		class3548_0.method_0("behind", Class3700.Class3702.class3689_15);
		class3548_0.method_0("leftwards", Class3700.Class3702.class3689_16);
		class3548_0.method_0("rightwards", Class3700.Class3702.class3689_17);
	}

	public override Class3679 vmethod_1()
	{
		Class3691 @class = new Class3691();
		@class.Add(Class3700.Class3702.class3689_10);
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
		if (map.method_6(propertyIndex))
		{
			return value;
		}
		Class3691 @class = (Class3691)value;
		bool flag = false;
		Class3679 class2 = null;
		foreach (Class3679 item in @class)
		{
			if (Class3700.Class3702.class3689_15 == item)
			{
				flag = true;
				continue;
			}
			if (((Class3680)item).PrimitiveType == 21)
			{
				if (Class3700.Class3702.class3689_16 != item && Class3700.Class3702.class3689_17 != item)
				{
					class2 = item;
					continue;
				}
				return item;
			}
			return item;
		}
		if (class2 != null)
		{
			if (Class3700.Class3702.class3689_6 == class2)
			{
				if (flag)
				{
					return new Class3685(270f, 11);
				}
				return new Class3685(270f, 11);
			}
			if (Class3700.Class3702.class3689_7 == class2)
			{
				if (flag)
				{
					return new Class3685(240f, 11);
				}
				return new Class3685(300f, 11);
			}
			if (Class3700.Class3702.class3689_8 == class2)
			{
				if (flag)
				{
					return new Class3685(220f, 11);
				}
				return new Class3685(320f, 11);
			}
			if (Class3700.Class3702.class3689_9 == class2)
			{
				if (flag)
				{
					return new Class3685(200f, 11);
				}
				return new Class3685(340f, 11);
			}
			if (Class3700.Class3702.class3689_10 == class2)
			{
				if (flag)
				{
					return new Class3685(180f, 11);
				}
				return new Class3685(0f, 11);
			}
			if (Class3700.Class3702.class3689_11 == class2)
			{
				if (flag)
				{
					return new Class3685(160f, 11);
				}
				return new Class3685(20f, 11);
			}
			if (Class3700.Class3702.class3689_12 == class2)
			{
				if (flag)
				{
					return new Class3685(140f, 11);
				}
				return new Class3685(40f, 11);
			}
			if (Class3700.Class3702.class3689_13 == class2)
			{
				if (flag)
				{
					return new Class3685(120f, 11);
				}
				return new Class3685(60f, 11);
			}
			if (Class3700.Class3702.class3689_14 == class2)
			{
				if (flag)
				{
					return new Class3685(90f, 11);
				}
				return new Class3685(90f, 11);
			}
		}
		return value;
	}
}
