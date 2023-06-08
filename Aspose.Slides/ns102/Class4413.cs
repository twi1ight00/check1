using System.Collections;
using ns103;
using ns117;
using ns119;
using ns126;
using ns154;
using ns156;
using ns99;

namespace ns102;

internal class Class4413 : Class4408
{
	private Class4718 class4718_0;

	private Class4738 class4738_0;

	private Class4468 class4468_0;

	private Class4490 class4490_0;

	private Class4552 class4552_0;

	private ArrayList arrayList_0;

	private Class4519 class4519_0;

	private Class4519 class4519_1;

	private object object_0 = new object();

	private object object_1 = new object();

	private object object_2 = new object();

	private object object_3 = new object();

	internal virtual Class4718 Type1FontDictionary
	{
		get
		{
			return class4718_0;
		}
		set
		{
			class4718_0 = value;
		}
	}

	internal ArrayList SeacSequence => arrayList_0;

	public override Enum639 FontType => Enum639.const_1;

	public override string FontFamily
	{
		get
		{
			return Type1FontDictionary.FontInfo.FamilyName;
		}
		set
		{
			Type1FontDictionary.FontInfo.FamilyName = value;
		}
	}

	public override string FontName
	{
		get
		{
			return Type1FontDictionary.FontName;
		}
		set
		{
			Type1FontDictionary.FontName = value;
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
						class4519_0 = new Class4519(FontName);
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
						class4519_1 = new Class4519(FontName);
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
			return Type1FontDictionary.FontInfo.Weight;
		}
		set
		{
			Type1FontDictionary.FontInfo.Weight = value;
		}
	}

	public override Enum640 FontStyle => method_1();

	public override int NumGlyphs => Type1FontDictionary.CharStrings.class4724_0.Length;

	public override Interface118 Metrics
	{
		get
		{
			if (class4468_0 == null)
			{
				lock (object_3)
				{
					if (class4468_0 == null)
					{
						class4468_0 = new Class4468(this);
					}
				}
			}
			return class4468_0;
		}
	}

	public override Interface114 Encoding
	{
		get
		{
			if (class4738_0 == null)
			{
				lock (object_2)
				{
					if (class4738_0 == null)
					{
						class4738_0 = new Class4738(this);
					}
				}
			}
			return class4738_0;
		}
	}

	public override Enum643 GlyphIDType => Enum643.const_0;

	public override Class4490 FontDefinition => class4490_0;

	internal Class4413(Class4490 fontDefinition)
	{
		class4718_0 = new Class4718();
		class4552_0 = new Class4552();
		class4490_0 = fontDefinition;
		arrayList_0 = new ArrayList();
	}

	public virtual Class4480 vmethod_0(string id)
	{
		Class4480 result = null;
		if (Type1FontDictionary.CharStrings.hashtable_0.ContainsKey(id))
		{
			result = method_0((int)Type1FontDictionary.CharStrings.hashtable_0[id]);
		}
		return result;
	}

	public Class4480 method_0(int id)
	{
		Class4724 @class = Type1FontDictionary.CharStrings.class4724_0[id];
		Class4480 class2 = new Class4480();
		Class4473 class3 = new Class4473(Type1FontDictionary.Private.Subrs);
		Class4464 commandProcessor = new Class4464(class3, this, class2);
		class3.CommandProcessor = commandProcessor;
		try
		{
			class4552_0.method_0(@class.PsProgram);
			class3.imethod_0(class4552_0);
			return class2;
		}
		finally
		{
			class4552_0.method_2();
		}
	}

	public override Class4480 imethod_0(Class4506 id)
	{
		Class4507 @class = id as Class4507;
		if (@class != null)
		{
			return vmethod_0(@class.Value);
		}
		Class4508 class2 = id as Class4508;
		if (!(class2 != null))
		{
			throw new Exception36("Integer Glyph ID is not supported for this font type.");
		}
		return method_0(class2.Value);
	}

	public override Class4506[] imethod_1()
	{
		Class4506[] array = null;
		if (Type1FontDictionary.CharStrings != null && Type1FontDictionary.CharStrings.class4724_0 != null)
		{
			array = new Class4506[Type1FontDictionary.CharStrings.class4724_0.Length];
			int num = 0;
			Class4724[] class4724_ = Type1FontDictionary.CharStrings.class4724_0;
			foreach (Class4724 @class in class4724_)
			{
				array[num] = new Class4507(@class.Name);
				num++;
			}
		}
		return array;
	}

	public override double imethod_2(string unicode, double fontSize)
	{
		double num = 0.0;
		Class4485 @class = ((Class4738)Encoding).imethod_5();
		for (int i = 0; i < unicode.Length; i++)
		{
			int num2 = Class4479.Instance.imethod_0(unicode[i]);
			for (int j = 0; j < num2; j++)
			{
				string text = Class4479.Instance.imethod_1(unicode[i], j);
				if (this is Class4414)
				{
					double num3 = ((Class4468)Metrics).imethod_1(new Class4507(text));
					if (num3 != 0.0)
					{
						num += num3;
						break;
					}
				}
				else if (@class.ContainsKey(text))
				{
					int value = @class[text];
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

	public override Interface119 imethod_3()
	{
		if (this is Class4414)
		{
			throw new Exception35("Requested font type subsetting is not supported.");
		}
		return new Class4415(this);
	}

	private Enum640 method_1()
	{
		Enum640 @enum = (Enum640)0;
		string weight = Type1FontDictionary.FontInfo.Weight;
		double italicAngle = Type1FontDictionary.FontInfo.ItalicAngle;
		if (weight != null)
		{
			string text = weight.ToLower();
			if (text.IndexOf("bold") != -1)
			{
				@enum |= Enum640.flag_1;
			}
			if (italicAngle != 0.0 || text.IndexOf("italic") != -1 || text.IndexOf("oblique") != -1)
			{
				@enum |= Enum640.flag_2;
			}
		}
		if (@enum == (Enum640)0)
		{
			@enum = Enum640.flag_0;
		}
		return @enum;
	}
}
