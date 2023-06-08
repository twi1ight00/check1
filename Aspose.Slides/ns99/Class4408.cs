using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using ns101;
using ns103;
using ns119;
using ns135;

namespace ns99;

internal abstract class Class4408 : Interface113
{
	private static Interface127 interface127_0;

	private Class4606 class4606_0;

	private static Regex regex_0;

	public abstract Enum639 FontType { get; }

	public abstract string Style { get; set; }

	public abstract Enum640 FontStyle { get; }

	public abstract string FontFamily { get; set; }

	public abstract string FontName { get; set; }

	public abstract Class4519 FontNames { get; set; }

	public abstract Class4519 PostscriptNames { get; set; }

	public abstract int NumGlyphs { get; }

	public abstract Interface118 Metrics { get; }

	public abstract Interface114 Encoding { get; }

	public abstract Enum643 GlyphIDType { get; }

	public abstract Class4490 FontDefinition { get; }

	internal Class4606 RenderingContext => class4606_0;

	internal Class4408()
	{
		class4606_0 = new Class4606();
	}

	static Class4408()
	{
		regex_0 = new Regex("(?<subsetTag>[A-Z]{6})\\+(?<fontName>.*)");
		interface127_0 = Class4516.Instance.ErrorHandlerFactory.imethod_0();
	}

	public static Class4408 smethod_0(Class4490 fontDefinition)
	{
		try
		{
			Class4417 @class = Class4417.smethod_0(fontDefinition.FontType);
			return @class.vmethod_0(fontDefinition);
		}
		catch (Exception ex)
		{
			interface127_0.imethod_1($"Could not create font. \r\nFont definition: \r\n{Class4502.smethod_0(fontDefinition)}", ex);
			throw;
		}
	}

	public static Class4408 smethod_1(Interface125 fontSource, Interface124 fontSearchSpec)
	{
		try
		{
			Class4490 @class = fontSearchSpec.imethod_0(fontSource);
			if (@class != null)
			{
				return smethod_0(@class);
			}
		}
		catch (Exception ex)
		{
			interface127_0.imethod_0($"Could not find font. The IFontSearcher throwed exception {ex.ToString()}");
		}
		return null;
	}

	public static Class4408 smethod_2(Enum639 fontType, Class4487 fontStreamSource)
	{
		Class4492 fileDefinition = new Class4492(fontStreamSource);
		Class4490 fontDefinition = new Class4490(fontType, fileDefinition);
		return smethod_0(fontDefinition);
	}

	public static Class4408 smethod_3(Enum639 fontType, string fileName)
	{
		Class4492 fileDefinition = new Class4492(new FileInfo(fileName));
		Class4490 fontDefinition = new Class4490(fontType, fileDefinition);
		return smethod_0(fontDefinition);
	}

	public static Class4408 smethod_4(Enum639 fontType, byte[] fontData)
	{
		Class4490 fontDefinition = new Class4490(fontType, new Class4488(fontData));
		return smethod_0(fontDefinition);
	}

	public static Class4408 smethod_5(Enum639 fontType)
	{
		if (fontType != 0)
		{
			throw new Exception35();
		}
		return Class4411.smethod_8();
	}

	public static Class4408 smethod_6(Enum639 fontType, Class4408 baseFont, Class4486 fontAdoptionOptions)
	{
		if (fontType != 0)
		{
			throw new Exception35();
		}
		return Class4411.smethod_9(baseFont, fontAdoptionOptions);
	}

	public virtual void Save(Stream stream)
	{
		Class4474 @class = Class4474.smethod_0(this, stream);
		@class.Save();
	}

	public virtual void Save(string fileName)
	{
		using Stream stream = File.Create(fileName);
		Class4474 @class = Class4474.smethod_0(this, stream);
		@class.Save();
	}

	public virtual Class4408 imethod_4(Enum639 fontType)
	{
		if (fontType == Enum639.const_0)
		{
			Class4411 @class = new Class4411();
			Class4411 class2 = (Class4411)this;
			@class.FontName = class2.FontName;
			@class.Style = class2.Style;
			Hashtable hashtable = new Hashtable();
			for (int i = 1; i < class2.TTFTables.MaxpTable.NumGlyphs; i++)
			{
				Class4508 class3 = new Class4508(i);
				Class4480 glyph = class2.imethod_0(class3);
				char charCode = class2.Encoding.imethod_0(class3);
				ushort num = @class.method_1(glyph);
				@class.Encoding.imethod_1(num, charCode);
				hashtable.Add(num, i);
			}
			return @class;
		}
		throw new Exception35();
	}

	public abstract Interface119 imethod_3();

	public static void smethod_7(string subsetFontName, out string fontName, out string subsetTag)
	{
		fontName = subsetFontName;
		subsetTag = string.Empty;
		Match match = regex_0.Match(fontName);
		if (match.Success)
		{
			fontName = match.Groups["fontName"].Value;
			subsetTag = match.Groups["subsetTag"].Value;
		}
	}

	public abstract Class4480 imethod_0(Class4506 id);

	public abstract Class4506[] imethod_1();

	public abstract double imethod_2(string unicode, double fontSize);
}
