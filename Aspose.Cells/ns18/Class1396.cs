using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns47;

namespace ns18;

internal class Class1396
{
	internal float float_0;

	private FontStyle fontStyle_0;

	private Font font_0;

	private Class1460 class1460_0;

	private readonly float float_1;

	private readonly float float_2;

	private readonly float float_3;

	private static readonly StringFormat stringFormat_0;

	private static readonly Hashtable hashtable_0;

	private string string_0 = "";

	private static Hashtable hashtable_1;

	public string Name => string_0;

	public float Size => float_0;

	public FontStyle Style => fontStyle_0;

	public bool IsBold => (Style & FontStyle.Bold) != 0;

	public bool IsItalic => (Style & FontStyle.Italic) != 0;

	public bool IsStrikeout => (Style & FontStyle.Strikeout) != 0;

	public Class1396(string string_1, float float_4, FontStyle fontStyle_1)
	{
		fontStyle_0 = fontStyle_1;
		float_0 = float_4;
		class1460_0 = Class1462.smethod_3(string_1, fontStyle_1, bool_0: false);
		string_0 = string_1;
		float num = class1460_0.method_46(class1460_0.method_67(), float_4);
		if (num < float.Epsilon)
		{
			float_1 = class1460_0.method_17(float_4);
			float_2 = float_1 * 0.618f;
			float_3 = float_1 * 0.382f;
		}
		else
		{
			float_1 = class1460_0.method_17(float_4);
			float_2 = class1460_0.method_46(class1460_0.method_11(), float_4);
			float_3 = class1460_0.method_46(class1460_0.method_13(), float_4);
		}
	}

	[SpecialName]
	public float method_0()
	{
		return float_1;
	}

	[SpecialName]
	public float method_1()
	{
		return float_2;
	}

	[SpecialName]
	public float method_2()
	{
		return float_3;
	}

	[SpecialName]
	public Class1460 method_3()
	{
		return class1460_0;
	}

	[SpecialName]
	public Font method_4()
	{
		if (font_0 == null)
		{
			try
			{
				font_0 = new Font(Name, float_0, Style & (FontStyle.Bold | FontStyle.Italic | FontStyle.Strikeout));
			}
			catch
			{
			}
		}
		if (font_0 == null)
		{
			try
			{
				font_0 = new Font(Name, float_0, FontStyle.Regular);
			}
			catch
			{
			}
		}
		if (font_0 == null)
		{
			try
			{
				font_0 = new Font(Name, float_0, FontStyle.Bold);
			}
			catch
			{
			}
		}
		if (font_0 == null)
		{
			try
			{
				font_0 = new Font(Name, float_0, FontStyle.Italic);
			}
			catch
			{
				font_0 = new Font("Arial", float_0, Style);
			}
		}
		return font_0;
	}

	public static SizeF smethod_0(string string_1, Class1396 class1396_0)
	{
		float height = class1396_0.method_3().method_46(class1396_0.method_3().method_67(), class1396_0.float_0);
		float width = class1396_0.method_3().method_45(string_1, class1396_0.float_0);
		return new SizeF(width, height);
	}

	public static Class1396 smethod_1(string string_1, float float_4, FontStyle fontStyle_1)
	{
		lock (hashtable_1)
		{
			string text = (string)hashtable_1[string_1 + fontStyle_1];
			if (text != null && text.Length != 0)
			{
				string_1 = text;
			}
			else
			{
				Class1460 @class = Class1462.smethod_3(string_1, fontStyle_1, bool_0: false);
				hashtable_1[string_1 + fontStyle_1] = @class.method_0();
				string_1 = @class.method_0();
			}
		}
		int num = smethod_2(string_1, float_4, fontStyle_1);
		Class1396 class2;
		lock (hashtable_0)
		{
			class2 = (Class1396)hashtable_0[num];
			if (class2 == null)
			{
				class2 = new Class1396(string_1, float_4, fontStyle_1);
				hashtable_0[num] = class2;
			}
		}
		return class2;
	}

	private static int smethod_2(string string_1, float float_4, FontStyle fontStyle_1)
	{
		return string_1.GetHashCode() ^ float_4.GetHashCode() ^ (int)fontStyle_1;
	}

	[SpecialName]
	public static StringFormat smethod_3()
	{
		return stringFormat_0;
	}

	static Class1396()
	{
		hashtable_0 = new Hashtable();
		hashtable_1 = Hashtable.Synchronized(new Hashtable());
		stringFormat_0 = StringFormat.GenericTypographic;
		stringFormat_0.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
	}
}
