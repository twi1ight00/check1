using System;
using ns100;
using ns119;
using ns146;
using ns147;
using ns99;

namespace ns101;

internal class Class4411 : Class4408
{
	private Class4691 class4691_0;

	private Class4467 class4467_0;

	private Class4681 class4681_0;

	private Class4490 class4490_0;

	private Class4408 class4408_0;

	private object object_0 = new object();

	private bool bool_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private Enum640 enum640_0;

	private Class4519 class4519_0;

	private Class4519 class4519_1;

	private object object_1 = new object();

	private object object_2 = new object();

	internal bool RequiresBytecodeHinting
	{
		get
		{
			if (FontFamily.IndexOf("MingLi") <= -1 && FontFamily.IndexOf("DFKai") <= -1)
			{
				if (FontFamily.IndexOf("+___") > -1 && TTFTables.OS2Table.AchVendId[0] == 68 && TTFTables.OS2Table.AchVendId[1] == 89 && TTFTables.OS2Table.AchVendId[2] == 78)
				{
					return TTFTables.OS2Table.AchVendId[3] == 65;
				}
				return false;
			}
			return true;
		}
	}

	internal Class4651 AdoptedHintingFrom
	{
		get
		{
			return TTFTables.GlyfTable.Context.AdoptedHintingFrom;
		}
		set
		{
			TTFTables.GlyfTable.Context.AdoptedHintingFrom = value;
		}
	}

	public virtual Class4681 TTFTables
	{
		get
		{
			return class4681_0;
		}
		set
		{
			class4681_0 = value;
		}
	}

	public virtual Class4408 CFFFont
	{
		get
		{
			method_6();
			return class4408_0;
		}
	}

	public override Enum639 FontType => Enum639.const_0;

	public override string FontFamily
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			if (TTFTables.NameTable != null)
			{
				TTFTables.NameTable.method_7(Class4669.Enum660.const_1, string_1);
			}
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
			enum640_0 = smethod_11(string_2);
			if (TTFTables.NameTable != null)
			{
				TTFTables.NameTable.method_7(Class4669.Enum660.const_2, string_2);
			}
		}
	}

	public override Enum640 FontStyle => enum640_0;

	public override string FontName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			if (TTFTables.NameTable != null && string_0 != null)
			{
				TTFTables.NameTable.method_7(Class4669.Enum660.const_4, string_0);
			}
		}
	}

	public override Class4519 FontNames
	{
		get
		{
			if (class4519_0 == null)
			{
				lock (object_1)
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
				lock (object_2)
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

	public override int NumGlyphs
	{
		get
		{
			if (TTFTables.MaxpTable == null)
			{
				return 0;
			}
			return TTFTables.MaxpTable.NumGlyphs;
		}
	}

	public bool IsSymolic => TTFTables.CMapTable.method_3(3, 0).Length > 0;

	public override Interface118 Metrics
	{
		get
		{
			if (class4467_0 == null)
			{
				class4467_0 = new Class4467(TTFTables);
			}
			return class4467_0;
		}
	}

	public override Interface114 Encoding => class4691_0;

	public override Enum643 GlyphIDType => Enum643.const_1;

	public override Class4490 FontDefinition => class4490_0;

	internal Class4411(Class4411 baseFont)
	{
	}

	internal Class4411()
	{
		class4691_0 = new Class4691(this);
		class4681_0 = Class4681.smethod_0();
		class4681_0.HeadTable = new Class4662(class4681_0, this);
		class4681_0.HeadTable.IndexToLocFormat = 1;
		class4681_0.HheaTable = new Class4663(class4681_0, this);
		class4681_0.HmtxTable = new Class4664(class4681_0, this);
		class4681_0.MaxpTable = new Class4668(class4681_0, this);
		class4681_0.OS2Table = new Class4670(class4681_0, this);
		class4681_0.NameTable = new Class4669(class4681_0, this);
		class4681_0.NameTable.NameChanged += method_0;
		class4681_0.PostTable = new Class4671(class4681_0, this);
		class4681_0.CMapTable = new Class4657(class4681_0, this);
		class4681_0.LocaTable = new Class4666(class4681_0, this);
		class4681_0.GlyfTable = new Class4660(class4681_0, this);
		method_1(new Class4480
		{
			WidthVectorX = 600.0
		});
		class4681_0.CMapTable.method_5(ushort.MaxValue, 0);
	}

	private void method_0(object sender, EventArgs e)
	{
		Class4669.EventArgs4 eventArgs = (Class4669.EventArgs4)e;
		switch (eventArgs.enum660_0)
		{
		case Class4669.Enum660.const_1:
			string_1 = TTFTables.NameTable.method_8(Class4669.Enum660.const_1);
			break;
		case Class4669.Enum660.const_2:
			string_2 = TTFTables.NameTable.method_8(Class4669.Enum660.const_2);
			enum640_0 = smethod_11(string_2);
			break;
		case Class4669.Enum660.const_4:
			string_0 = TTFTables.NameTable.method_8(Class4669.Enum660.const_4);
			class4519_0 = TTFTables.NameTable.method_6(Class4669.Enum660.const_4);
			break;
		case Class4669.Enum660.const_3:
		case Class4669.Enum660.const_5:
			break;
		case Class4669.Enum660.const_6:
			class4519_1 = TTFTables.NameTable.method_6(Class4669.Enum660.const_6);
			break;
		}
	}

	internal Class4411(Class4490 fontDefinition, Class4681 ttfTables)
	{
		class4691_0 = new Class4691(this);
		class4681_0 = ttfTables;
		class4490_0 = fontDefinition;
		enum640_0 = (Enum640)0;
	}

	public static Class4408 smethod_8()
	{
		return new Class4411();
	}

	public static Class4408 smethod_9(Class4408 baseFont, Class4486 fontAdoptionOptions)
	{
		Class4411 @class = new Class4411();
		if (baseFont is Class4411 class2)
		{
			if (fontAdoptionOptions.AdoptHinting)
			{
				@class.AdoptedHintingFrom = class2.TTFTables.HeadTable.Context;
				byte[] tableBytes;
				uint length;
				uint checksum;
				if (class2.TTFTables.CvtTable != null)
				{
					@class.TTFTables.CvtTable = new Class4658(@class.TTFTables, @class);
					class2.TTFTables.CvtTable.Save(out tableBytes, out length, out checksum);
					@class.TTFTables.CvtTable.byte_0 = tableBytes;
				}
				if (class2.TTFTables.PrepTable != null)
				{
					@class.TTFTables.PrepTable = new Class4672(@class.TTFTables, @class);
					class2.TTFTables.PrepTable.Save(out tableBytes, out length, out checksum);
					@class.TTFTables.PrepTable.byte_0 = tableBytes;
				}
				if (class2.TTFTables.FpgmTable != null)
				{
					@class.TTFTables.FpgmTable = new Class4659(@class.TTFTables, @class);
					class2.TTFTables.FpgmTable.Save(out tableBytes, out length, out checksum);
					@class.TTFTables.FpgmTable.byte_0 = tableBytes;
				}
			}
			if (class2.TTFTables.MaxpTable != null)
			{
				@class.TTFTables.MaxpTable.MaxFunctionDefs = class2.TTFTables.MaxpTable.MaxFunctionDefs;
				@class.TTFTables.MaxpTable.MaxInstructionDefs = class2.TTFTables.MaxpTable.MaxInstructionDefs;
				@class.TTFTables.MaxpTable.MaxSizeOfInstructions = class2.TTFTables.MaxpTable.MaxSizeOfInstructions;
				@class.TTFTables.MaxpTable.MaxTwilightPoints = class2.TTFTables.MaxpTable.MaxTwilightPoints;
				@class.TTFTables.MaxpTable.MaxStackElements = class2.TTFTables.MaxpTable.MaxStackElements;
				@class.TTFTables.MaxpTable.MaxStorage = class2.TTFTables.MaxpTable.MaxStorage;
			}
			if (class2.TTFTables.HeadTable != null)
			{
				@class.TTFTables.HeadTable.Flags = class2.TTFTables.HeadTable.Flags;
				@class.TTFTables.HeadTable.MacStyle = class2.TTFTables.HeadTable.MacStyle;
				@class.TTFTables.HeadTable.XMin = class2.TTFTables.HeadTable.XMin;
				@class.TTFTables.HeadTable.YMin = class2.TTFTables.HeadTable.YMin;
				@class.TTFTables.HeadTable.XMax = class2.TTFTables.HeadTable.XMax;
				@class.TTFTables.HeadTable.YMax = class2.TTFTables.HeadTable.YMax;
				@class.TTFTables.HeadTable.FontDirectionHint = class2.TTFTables.HeadTable.FontDirectionHint;
			}
			if (class2.TTFTables.OS2Table != null)
			{
				@class.TTFTables.OS2Table.CopyFrom(class2.TTFTables.OS2Table);
				@class.TTFTables.OS2Table.FsType = 8;
			}
			if (class2.TTFTables.NameTable != null)
			{
				smethod_10(@class, class2, Class4669.Enum660.const_1);
				smethod_10(@class, class2, Class4669.Enum660.const_2);
				smethod_10(@class, class2, Class4669.Enum660.const_3);
				smethod_10(@class, class2, Class4669.Enum660.const_4);
				smethod_10(@class, class2, Class4669.Enum660.const_5);
				smethod_10(@class, class2, Class4669.Enum660.const_6);
			}
		}
		return @class;
	}

	private static void smethod_10(Class4411 font, Class4411 otherFont, Class4669.Enum660 nameId)
	{
		string text = otherFont.TTFTables.NameTable.method_8(nameId);
		if (text != null)
		{
			font.TTFTables.NameTable.method_7(nameId, text);
		}
	}

	public override Interface119 imethod_3()
	{
		return new Class4412(this);
	}

	public ushort method_1(Class4480 glyph)
	{
		if (glyph is Class4481)
		{
			Class4481 @class = (Class4481)glyph;
			foreach (Class4483 component in @class.Components)
			{
				method_1(component.Glyph);
			}
		}
		if (!TTFTables.GlyfTable.method_6(glyph))
		{
			if (TTFTables.GlyfTable != null)
			{
				ushort numGlyphs = TTFTables.MaxpTable.NumGlyphs;
				TTFTables.GlyfTable.method_9(glyph, out var glyphBytes, out var isNewGlyph);
				if (TTFTables.LocaTable.Offsets.Count == 0)
				{
					TTFTables.LocaTable.Offsets.Add(0);
				}
				if (isNewGlyph)
				{
					uint num = TTFTables.LocaTable.Offsets[TTFTables.LocaTable.Offsets.Count - 1];
					TTFTables.LocaTable.Offsets.Add((uint)(num + glyphBytes.Length));
					TTFTables.HheaTable.NumOfLongHorMetrics++;
					TTFTables.HmtxTable.Hmetrics.Add(new Class4664.Struct182((ushort)glyph.WidthVectorX, (short)glyph.LeftSidebearingX));
					TTFTables.MaxpTable.NumGlyphs++;
				}
				return numGlyphs;
			}
			return 0;
		}
		return TTFTables.GlyfTable.method_7(glyph);
	}

	public override Class4480 imethod_0(Class4506 id)
	{
		Class4480 result = null;
		Class4508 @class;
		Class4507 class2;
		if ((@class = id as Class4508) != null)
		{
			result = method_3(@class.Value);
		}
		else if ((class2 = id as Class4507) != null)
		{
			result = method_2(class2.Value);
		}
		return result;
	}

	public Class4480 method_2(string glyphName)
	{
		Class4480 result = null;
		if (CFFFont != null)
		{
			result = ((Class4409)CFFFont).method_0(glyphName);
		}
		else if (TTFTables.PostTable != null)
		{
			int id = TTFTables.PostTable.method_3(glyphName);
			result = method_3(id);
		}
		return result;
	}

	public Class4480 method_3(int id)
	{
		Class4480 @class = null;
		if (CFFFont != null)
		{
			return ((Class4409)CFFFont).method_2(id);
		}
		return TTFTables.GlyfTable.vmethod_5(id);
	}

	public override Class4506[] imethod_1()
	{
		Class4506[] array = new Class4506[NumGlyphs];
		int num = 0;
		for (int i = 0; i < NumGlyphs; i++)
		{
			array[num] = new Class4508(i);
			num++;
		}
		return array;
	}

	public virtual void vmethod_0(Class4506 id, Class4505 componentsToPopulate)
	{
		Class4508 @class = id as Class4508;
		if (@class != null)
		{
			method_5(@class.Value, componentsToPopulate);
			return;
		}
		Class4507 class2 = id as Class4507;
		if (class2 != null)
		{
			method_4(class2.Value, componentsToPopulate);
		}
	}

	public void method_4(string glyphName, Class4505 componentsToPopulate)
	{
		if (CFFFont != null)
		{
			throw new NotImplementedException("TTF fonts support with CFF inside is not implemented");
		}
		if (TTFTables.PostTable != null)
		{
			int id = TTFTables.PostTable.method_3(glyphName);
			method_5(id, componentsToPopulate);
		}
	}

	public void method_5(int id, Class4505 componentsToPopulate)
	{
		if (CFFFont != null)
		{
			throw new NotImplementedException("TTF fonts support with CFF inside is not implemented");
		}
		TTFTables.GlyfTable.method_2(id, componentsToPopulate);
	}

	public override double imethod_2(string unicode, double fontSize)
	{
		double num = 0.0;
		if (TTFTables.CMapTable != null)
		{
			for (int i = 0; i < unicode.Length; i++)
			{
				Class4506 @class = Encoding.imethod_3(unicode[i]);
				if (@class != null)
				{
					num += Metrics.imethod_1(@class) / (double)Metrics.UnitsPerEM * 1000.0;
				}
			}
		}
		return num * fontSize / 1000.0;
	}

	private void method_6()
	{
		if (bool_0)
		{
			return;
		}
		lock (object_0)
		{
			if (!bool_0)
			{
				if (TTFTables.CFFTable != null && TTFTables.CFFTable.CFFSource != null)
				{
					class4408_0 = Class4408.smethod_2(Enum639.const_2, TTFTables.CFFTable.CFFSource);
				}
				bool_0 = true;
			}
		}
	}

	private static Enum640 smethod_11(string fontStyle)
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

	internal int method_7(Class4506 id)
	{
		Class4508 @class;
		if ((@class = id as Class4508) != null)
		{
			return @class.Value;
		}
		Class4507 class2;
		if (TTFTables.PostTable != null && (class2 = id as Class4507) != null)
		{
			return TTFTables.PostTable.method_3(class2.Value);
		}
		return 0;
	}

	internal void AddTable(string tableName, Class4651 context, uint checkSum, uint offset, uint length)
	{
		switch (tableName.ToLower().Trim())
		{
		case "name":
			class4681_0.NameTable = new Class4669(context, checkSum, offset, length);
			class4681_0.NameTable.NameChanged += method_0;
			break;
		case "maxp":
			class4681_0.MaxpTable = new Class4668(context, checkSum, offset, length);
			break;
		case "head":
			class4681_0.HeadTable = new Class4662(context, checkSum, offset, length);
			break;
		case "glyf":
			class4681_0.GlyfTable = new Class4660(context, checkSum, offset, length);
			break;
		case "loca":
			class4681_0.LocaTable = new Class4666(context, checkSum, offset, length);
			break;
		case "cmap":
			class4681_0.CMapTable = new Class4657(context, checkSum, offset, length);
			break;
		case "hhea":
			class4681_0.HheaTable = new Class4663(context, checkSum, offset, length);
			break;
		case "hmtx":
			class4681_0.HmtxTable = new Class4664(context, checkSum, offset, length);
			break;
		case "post":
			class4681_0.PostTable = new Class4671(context, checkSum, offset, length);
			break;
		case "kern":
			class4681_0.KernTable = new Class4665(context, checkSum, offset, length);
			break;
		case "cff":
			class4681_0.CFFTable = new Class4656(context, checkSum, offset, length);
			break;
		case "cvt":
			class4681_0.CvtTable = new Class4658(context, checkSum, offset, length);
			break;
		case "fpgm":
			class4681_0.FpgmTable = new Class4659(context, checkSum, offset, length);
			break;
		case "prep":
			class4681_0.PrepTable = new Class4672(context, checkSum, offset, length);
			break;
		case "os/2":
			class4681_0.OS2Table = new Class4670(context, checkSum, offset, length);
			break;
		}
	}
}
