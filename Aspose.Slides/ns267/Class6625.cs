using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;
using ns235;
using ns268;

namespace ns267;

internal abstract class Class6625
{
	private static Hashtable hashtable_0;

	public static Enum smethod_0(Type enumType, string value)
	{
		return smethod_2(enumType).vmethod_0(value);
	}

	public static string smethod_1(Enum value)
	{
		return smethod_2(value.GetType()).vmethod_1(value);
	}

	protected abstract Enum vmethod_0(string value);

	protected abstract string vmethod_1(Enum value);

	private static Class6625 smethod_2(Type enumType)
	{
		if (hashtable_0 == null)
		{
			hashtable_0 = new Hashtable();
			hashtable_0.Add(typeof(FontStyle), new Class6628<FontStyle>());
			hashtable_0.Add(typeof(FillMode), new Class6628<FillMode>());
			hashtable_0.Add(typeof(WrapMode), new Class6628<WrapMode>());
			hashtable_0.Add(typeof(DashCap), new Class6628<DashCap>());
			hashtable_0.Add(typeof(DashStyle), new Class6628<DashStyle>());
			hashtable_0.Add(typeof(LineCap), new Class6628<LineCap>());
			hashtable_0.Add(typeof(LineJoin), new Class6628<LineJoin>());
			hashtable_0.Add(typeof(HatchStyle), new Class6628<HatchStyle>());
			hashtable_0.Add(typeof(Enum803), new Class6626());
			hashtable_0.Add(typeof(Enum747), new Class6627());
		}
		if (!hashtable_0.ContainsKey(enumType))
		{
			throw new ArgumentException($"Enum helper for type '{enumType}' is not found.");
		}
		return (Class6625)hashtable_0[enumType];
	}
}
