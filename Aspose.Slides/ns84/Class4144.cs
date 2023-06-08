using System.Collections.Generic;
using ns73;
using ns74;
using ns76;
using ns87;

namespace ns84;

internal class Class4144 : Interface97
{
	private string string_0;

	private IList<Class4145> ilist_0;

	private Enum625 enum625_0;

	private Class4226 class4226_0;

	public string FontFamily
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public IList<Class4145> Src
	{
		get
		{
			return ilist_0;
		}
		set
		{
			ilist_0 = value;
		}
	}

	public Enum625 Style => enum625_0;

	public Class4226 FontWeight => class4226_0;

	public static Class4144 smethod_0(Interface60 rule)
	{
		Class3716 @class = (Class3716)rule.Style;
		Class4144 class2 = new Class4144();
		Class3679 class3 = @class.method_0(Enum600.const_113);
		if (class3 != null)
		{
			class2.string_0 = class3.CSSText;
		}
		class3 = @class.method_0(Enum600.const_126);
		class3 = smethod_1(class3);
		if (class3 != null)
		{
			class2.class4226_0 = new Class4226(class3);
		}
		else
		{
			class2.class4226_0 = new Class4226(Class3700.Class3702.class3685_12);
		}
		class3 = @class.method_0(Enum600.const_118);
		if (class3 != null)
		{
			class2.enum625_0 = Class4342.smethod_0<Enum625>().imethod_3(class3.CSSText);
		}
		else
		{
			class2.enum625_0 = Enum625.const_0;
		}
		class2.ilist_0 = new List<Class4145>();
		class3 = @class.method_0(Enum600.const_297);
		if (class3 != null)
		{
			Class3691 class4 = (Class3691)class3;
			foreach (Class3679 item in class4)
			{
				if (item is Class3690)
				{
					Class4145 class5 = new Class4145();
					class5.URI = ((Class3690)item).vmethod_3();
					class2.ilist_0.Add(class5);
				}
			}
		}
		return class2;
	}

	private static Class3679 smethod_1(Class3679 value)
	{
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
			return Class3700.Class3702.class3685_12;
		}
		if (value == Class3700.Class3702.class3689_193)
		{
			return Class3700.Class3702.class3685_12;
		}
		return value;
	}
}
