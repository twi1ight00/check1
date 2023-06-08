using System.Collections;
using ns103;
using ns108;
using ns116;
using ns119;
using ns126;
using ns99;

namespace ns100;

internal class Class4409 : Class4408
{
	private string string_0;

	private string string_1;

	private string string_2;

	private Class4444 class4444_0;

	private Class4444[] class4444_1;

	private Enum640 enum640_0;

	private Class4466 class4466_0;

	private Class4443 class4443_0;

	private Class4421 class4421_0;

	private Class4490 class4490_0;

	private Class4519 class4519_0;

	private Class4519 class4519_1;

	private ArrayList arrayList_0;

	private object object_0 = new object();

	private object object_1 = new object();

	internal Class4443 Internals => class4443_0;

	internal Class4444[] SubFonts
	{
		get
		{
			return class4444_1;
		}
		set
		{
			class4444_1 = value;
		}
	}

	internal Class4444 TopmostFont
	{
		get
		{
			return class4444_0;
		}
		set
		{
			class4444_0 = value;
		}
	}

	internal ArrayList SeacSequence => arrayList_0;

	public override Enum639 FontType => Enum639.const_2;

	public override string FontFamily
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public override string FontName
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

	public override Class4519 FontNames
	{
		get
		{
			if (class4519_0 == null)
			{
				lock (object_0)
				{
					if (class4519_0 == null)
					{
						class4519_0 = new Class4519((FontName != null) ? FontName : string.Empty);
					}
				}
			}
			return class4519_0;
		}
		set
		{
			class4519_0 = value;
		}
	}

	public override Class4519 PostscriptNames
	{
		get
		{
			if (class4519_1 == null)
			{
				lock (object_1)
				{
					if (class4519_1 == null)
					{
						class4519_1 = new Class4519((FontName != null) ? FontName : string.Empty);
					}
				}
			}
			return class4519_1;
		}
		set
		{
			class4519_1 = value;
		}
	}

	public override string Style
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
			enum640_0 = smethod_8(string_2);
		}
	}

	public override Enum640 FontStyle => enum640_0;

	public bool IsCIDKeyedFont => TopmostFont.FontDictionary.bool_0;

	public override int NumGlyphs => Internals.CharstringsIndex.ObjectsCount;

	public override Interface118 Metrics => class4466_0;

	public override Interface114 Encoding => class4421_0;

	public override Enum643 GlyphIDType => Enum643.const_1;

	public override Class4490 FontDefinition => class4490_0;

	internal Class4409(Class4490 fontDefinition)
	{
		class4466_0 = new Class4466(this);
		class4443_0 = new Class4443();
		class4421_0 = new Class4421(this);
		class4490_0 = fontDefinition;
		enum640_0 = (Enum640)0;
		arrayList_0 = new ArrayList();
	}

	public override Interface119 imethod_3()
	{
		return new Class4410(this);
	}

	public override Class4480 imethod_0(Class4506 id)
	{
		Class4508 @class;
		if ((@class = id as Class4508) != null)
		{
			return method_2(@class.Value);
		}
		Class4507 class2;
		if (!((class2 = id as Class4507) != null))
		{
			throw new Exception36("string name Glyph ID is not supported for this font type.");
		}
		return method_0(class2.Value);
	}

	public Class4480 method_0(string glyphName)
	{
		int num = method_1(glyphName);
		if (num != -1)
		{
			return method_2(num);
		}
		return null;
	}

	internal int method_1(string glyphName)
	{
		if (Encoding is Class4421 @class)
		{
			Class4485 class2 = @class.method_1();
			if (class2.ContainsKey(glyphName))
			{
				Class4508 class3 = (Class4508)Encoding.imethod_3((char)class2[glyphName]);
				return class3.Value;
			}
		}
		return -1;
	}

	public Class4480 method_2(int id)
	{
		double num = 0.0;
		Class4444 @class = TopmostFont;
		if (class4444_1 != null && class4444_1.Length != 0)
		{
			byte b = Internals.FdSelect.method_0(id);
			if (b < class4444_1.Length)
			{
				@class = class4444_1[b];
			}
		}
		num = @class.PrivateFontDictionary.double_0;
		class4443_0.CharstringsIndex.method_0(id, out var offset, out var length);
		Class4471 class2 = new Class4471(TopmostFont.FontDictionary.int_1);
		Class4480 class3 = new Class4480();
		Class4462 class5 = (Class4462)(class2.CommandProcessor = new Class4462(class2, this, @class, class3));
		class5.Glyph.WidthVectorX = num;
		class2.imethod_0(new Class4552(class4443_0.CharstringsIndex.IndexData, offset, length));
		return class3;
	}

	public override Class4506[] imethod_1()
	{
		Class4506[] array = new Class4506[class4443_0.CharstringsIndex.ObjectsCount];
		int num = 0;
		for (int i = 0; i < class4443_0.CharstringsIndex.ObjectsCount; i++)
		{
			array[num] = new Class4508(i);
			num++;
		}
		return array;
	}

	public override double imethod_2(string unicode, double fontSize)
	{
		double num = 0.0;
		Class4485 @class = ((Class4421)Encoding).imethod_5();
		for (int i = 0; i < unicode.Length; i++)
		{
			int num2 = Class4479.Instance.imethod_0(unicode[i]);
			for (int j = 0; j < num2; j++)
			{
				string name = Class4479.Instance.imethod_1(unicode[i], j);
				if (@class.ContainsKey(name))
				{
					int value = @class[name];
					Class4480 class2 = imethod_0(new Class4508(value));
					if (class2 != null)
					{
						num += class2.WidthVectorX;
						break;
					}
				}
			}
		}
		return num * fontSize / 1000.0;
	}

	private static Enum640 smethod_8(string fontStyle)
	{
		Enum640 @enum = (Enum640)0;
		if (fontStyle != null)
		{
			string text = fontStyle.ToLower();
			if (text.IndexOf("italic") != -1)
			{
				@enum |= Enum640.flag_2;
			}
			if (text.IndexOf("bold") != -1)
			{
				@enum |= Enum640.flag_1;
			}
		}
		if (@enum == (Enum640)0)
		{
			@enum = Enum640.flag_0;
		}
		return @enum;
	}
}
