using ns305;
using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;

namespace ns80;

internal class Class3947 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "text-align";

	public override Enum600 PropertyType => Enum600.const_239;

	public override bool IsInheritedProperty => true;

	static Class3947()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("left", Class3700.Class3702.class3689_8);
		class3548_0.method_0("right", Class3700.Class3702.class3689_12);
		class3548_0.method_0("center", Class3700.Class3702.class3689_10);
		class3548_0.method_0("justify", Class3700.Class3702.class3689_179);
	}

	public override Class3679 vmethod_1()
	{
		return new Class3692(Class3700.Class3702.class3689_8);
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		if (map.method_6(propertyIndex))
		{
			Interface91 @interface = Class3726.smethod_0((Class6981)element);
			if (@interface != null)
			{
				Class4074 @class = @interface.imethod_0(null);
				if (@class != null)
				{
					Class3679 class2 = @class.method_0(engine.method_1(Enum600.const_91));
					if (class2 != null && class2 == Class3700.Class3702.class3689_145)
					{
						Class3679 class3 = @class.method_0(engine.method_1(Enum600.const_239));
						if (class3 != null && class3 == Class3700.Class3702.class3689_10)
						{
							int i = engine.method_1(Enum600.const_163);
							int i2 = engine.method_1(Enum600.const_164);
							if (map.method_0(i) == null && map.method_0(i2) == null)
							{
								value = Class3700.Class3702.class3689_8;
								map.method_1(i, Class3700.Class3702.class3689_3);
								map.method_1(i2, Class3700.Class3702.class3689_3);
							}
						}
					}
				}
			}
		}
		if (value == null || value is Class3692 || map.method_6(propertyIndex))
		{
			int propertyIndex2 = engine.method_1(Enum600.const_90);
			Class3679 class4 = engine.method_9(element, pseudoElement, propertyIndex2);
			if (class4 != Class3700.Class3702.class3689_150)
			{
				if (map.method_6(propertyIndex) && value != null)
				{
					return value;
				}
				return Class3700.Class3702.class3689_8;
			}
			if (value == Class3700.Class3702.class3689_8)
			{
				return Class3700.Class3702.class3689_12;
			}
			if (value == Class3700.Class3702.class3689_12)
			{
				return Class3700.Class3702.class3689_8;
			}
		}
		return value;
	}
}
