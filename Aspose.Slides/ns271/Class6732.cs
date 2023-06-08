using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using ns218;
using ns221;
using ns234;

namespace ns271;

internal class Class6732
{
	private Class5950 class5950_0;

	private Class5968 class5968_0;

	private Class6725 class6725_0;

	private Class6637 class6637_0;

	private Class6638 class6638_0;

	private Class6724 class6724_0;

	private Class6726 class6726_0;

	private Class6728 class6728_0;

	private Class6636 class6636_0;

	private Class6639 class6639_0;

	private Class5951 class5951_0;

	private MemoryStream memoryStream_0;

	private MemoryStream memoryStream_1;

	private MemoryStream memoryStream_2;

	private int int_0;

	private readonly IDictionary idictionary_0;

	private uint[] uint_0;

	private static readonly string[] string_0 = new string[9] { "head", "hhea", "maxp", "hmtx", "fpgm", "prep", "cvt ", "loca", "glyf" };

	private static readonly string[] string_1 = new string[4] { "OS/2", "name", "cmap", "post" };

	private static readonly int[] int_1 = new int[21]
	{
		0, 0, 1, 1, 2, 2, 2, 2, 3, 3,
		3, 3, 3, 3, 3, 3, 4, 4, 4, 4,
		4
	};

	public Class6730 Read(Class6654 fontData, string fontName)
	{
		using Stream stream = fontData.vmethod_0();
		Class6730 @class = Read(stream, fontName);
		@class.Data = fontData;
		return @class;
	}

	internal Class6730 Read(string fileName, string fontName)
	{
		return Read(new Class6655(fileName), fontName);
	}

	internal Class6730 Read(byte[] fontData, string fontName)
	{
		return Read(new Class6656(fontData), fontName);
	}

	internal Class6730 Read(Stream stream, string fontName)
	{
		class5950_0 = new Class5950(stream);
		method_6(fontName);
		method_8();
		method_11();
		method_12();
		method_9();
		method_10();
		method_13();
		method_14();
		return method_15();
	}

	internal Class6723[] method_0(string fileName)
	{
		return method_1(new Class6655(fileName));
	}

	internal Class6723[] method_1(Class6654 fontData)
	{
		if (!fontData.vmethod_2())
		{
			return new Class6723[0];
		}
		using Stream stream = fontData.vmethod_0();
		class5950_0 = new Class5950(stream);
		if (method_26())
		{
			Class6723[] array = method_27();
			Class6723[] array2 = array;
			foreach (Class6723 @class in array2)
			{
				@class.Data = fontData;
				@class.IsTtc = true;
			}
			return array;
		}
		if (method_7(0))
		{
			method_11();
			Class6723[] array3 = class6724_0.method_4();
			Class6723[] array4 = array3;
			foreach (Class6723 class2 in array4)
			{
				class2.Data = fontData;
				class2.IsTtc = false;
			}
			return array3;
		}
		return null;
	}

	[Attribute7(true)]
	internal void method_2(Class6730 font, Class5967 charsToNewGlyphIndexes, Class5967 oldToNewGlyphIndexes, Stream dstStream, bool isMakeValidTtf, bool isFullEmbedding)
	{
		if (font == null)
		{
			throw new ArgumentNullException("font");
		}
		if (oldToNewGlyphIndexes == null)
		{
			throw new ArgumentNullException("oldToNewGlyphIndexes");
		}
		if (dstStream == null)
		{
			throw new ArgumentNullException("dstStream");
		}
		using Stream stream = font.Data.vmethod_0();
		class5950_0 = new Class5950(stream);
		method_6(font.FullFontName);
		if (!isFullEmbedding && !font.IsCff)
		{
			method_8();
			method_9();
			method_10();
			method_13();
			if (isMakeValidTtf)
			{
				method_14();
				method_4();
			}
			bool isLocaShort = class6725_0.short_5 == 0;
			Class6727 @class = new Class6727(class5950_0, isLocaShort);
			ushort num = (ushort)@class.method_0(method_17("loca"), method_17("glyf"), class6728_0, oldToNewGlyphIndexes);
			if (num != oldToNewGlyphIndexes.Count)
			{
				throw new InvalidOperationException("Unexpected used glyphs count!");
			}
			memoryStream_0 = @class.NewLoca;
			memoryStream_1 = @class.NewGlyf;
			memoryStream_2 = @class.NewHmtx;
			class6638_0.ushort_0 = num;
			class6637_0.ushort_1 = num;
			if (isMakeValidTtf)
			{
				class6636_0.method_3(charsToNewGlyphIndexes);
				class6639_0.method_1(oldToNewGlyphIndexes);
			}
			method_29(isMakeValidTtf, dstStream);
			return;
		}
		using Stream srcStream = font.Data.vmethod_0();
		Class5964.smethod_9(srcStream, dstStream);
	}

	[Attribute7(true)]
	internal Hashtable method_3(Class6730 font, Class5967 oldToNewGlyphIndexes, int emHeight)
	{
		if (font == null)
		{
			throw new ArgumentNullException("font");
		}
		if (oldToNewGlyphIndexes == null)
		{
			throw new ArgumentNullException("oldToNewGlyphIndexes");
		}
		using Stream stream = font.Data.vmethod_0();
		class5950_0 = new Class5950(stream);
		method_6(font.FullFontName);
		method_8();
		bool isLocaShort = class6725_0.short_5 == 0;
		Class6727 @class = new Class6727(class5950_0, isLocaShort);
		return @class.method_1(method_17("loca"), method_17("glyf"), oldToNewGlyphIndexes, emHeight);
	}

	private void method_4()
	{
		method_16("post");
		class6639_0 = new Class6639(class5950_0);
	}

	[Attribute7(true)]
	private int method_5()
	{
		int num = class5950_0.method_0();
		if (num != 65536 && num != 1330926671)
		{
			return -1;
		}
		int result = class5950_0.method_3();
		class5950_0.method_3();
		class5950_0.method_3();
		class5950_0.method_3();
		return result;
	}

	[Attribute7(true)]
	private void method_6(string fontName)
	{
		if (method_26())
		{
			method_27();
			uint offset = (uint)idictionary_0[fontName];
			if (!method_7((int)offset))
			{
				throw new InvalidOperationException("The TTC font is invalid.");
			}
		}
		else if (!method_7(0))
		{
			throw new InvalidOperationException("The file is not recognized as a TTF or TTC font.");
		}
	}

	private bool method_7(int offset)
	{
		class5950_0.BaseStream.Position = offset;
		int num = method_5();
		if (num <= 0)
		{
			return false;
		}
		class5968_0 = new Class5968();
		for (int i = 0; i < num; i++)
		{
			Class6729 @class = new Class6729(class5950_0);
			class5968_0.Add(@class.string_0, @class);
		}
		return true;
	}

	private void method_8()
	{
		method_16("head");
		class6725_0 = new Class6725(class5950_0);
	}

	private void method_9()
	{
		method_16("hhea");
		class6637_0 = new Class6637(class5950_0);
	}

	private void method_10()
	{
		method_16("maxp");
		class6638_0 = new Class6638(class5950_0);
	}

	[Attribute7(true)]
	private void method_11()
	{
		method_16("name");
		int tableStart = (int)class5950_0.BaseStream.Position;
		method_28(tableStart);
	}

	private void method_12()
	{
		method_16("OS/2");
		class6726_0 = new Class6726(class5950_0);
	}

	[Attribute7(true)]
	private void method_13()
	{
		if (class6637_0 == null)
		{
			throw new InvalidOperationException("Need to read horizontal header first.");
		}
		if (class6638_0 == null)
		{
			throw new InvalidOperationException("Need to read maximum profile first.");
		}
		method_16("hmtx");
		class6728_0 = new Class6728(class5950_0, class6637_0.ushort_1, class6638_0.ushort_0);
	}

	private void method_14()
	{
		method_16("cmap");
		class6636_0 = new Class6636(class5950_0);
	}

	private Class6730 method_15()
	{
		Class6730 @class = new Class6730();
		@class.EmHeight = class6725_0.ushort_1;
		@class.XMin = class6725_0.short_0;
		@class.YMin = class6725_0.short_1;
		@class.XMax = class6725_0.short_2;
		@class.YMax = class6725_0.short_3;
		Class6729 class2 = method_18("CFF ");
		if (class2 != null)
		{
			@class.IsCff = true;
			class5950_0.BaseStream.Position = class2.int_2;
			Class6635 class3 = new Class6635(class5950_0);
			@class.IsCffTopDict = class3.method_1();
		}
		float num = (float)@class.EmHeight / 1.8f;
		float num2 = (float)@class.EmHeight * 1.8f;
		int num3 = class6726_0.short_12 - class6726_0.short_13;
		int num4 = class6726_0.ushort_7 + class6726_0.ushort_8;
		bool flag = (float)num4 < num2 && (float)num4 > num;
		@class.method_5(class6724_0);
		bool flag2 = (class6726_0.short_12 == 0 && class6726_0.short_13 == 0) || !flag;
		@class.Ascent = (flag2 ? ((int)class6637_0.short_0) : ((int)class6726_0.ushort_7));
		@class.Descent = (flag2 ? (-class6637_0.short_1) : class6726_0.ushort_8);
		@class.LineSpacing = ((flag2 || !@class.IsCff) ? (class6637_0.short_0 - class6637_0.short_1 + class6637_0.short_2) : (class6726_0.ushort_7 + class6726_0.ushort_8));
		if (class6726_0.short_13 > 0 && ((float)num3 > num2 || (float)num3 < num) && !flag && (@class.LineSpacing == 0 || (float)@class.LineSpacing > num2 || (float)@class.LineSpacing < num))
		{
			@class.Ascent = class6725_0.short_3;
			@class.Descent = -class6725_0.short_1;
			@class.LineSpacing = @class.Ascent + @class.Descent;
			@class.EmHeight = @class.LineSpacing;
		}
		else if (class6637_0.short_1 > 0)
		{
			@class.Ascent = class6725_0.short_3;
			@class.Descent = -class6725_0.short_1;
			@class.LineSpacing = @class.Ascent + @class.Descent;
		}
		@class.ItalicAngle = (float)((0.0 - Math.Atan2(class6637_0.short_7, class6637_0.short_6)) * 180.0 / Math.PI);
		@class.StrikeoutSize = class6726_0.short_9;
		@class.StrikeoutPosition = class6726_0.short_10;
		@class.SubscriptSize = class6726_0.short_2;
		@class.SubscriptOffset = class6726_0.short_4;
		@class.SuperscriptSize = class6726_0.short_6;
		@class.SuperscriptOffset = class6726_0.short_8;
		@class.Style = ((class6726_0.ushort_4 == 0) ? class6725_0.Style : class6726_0.Style);
		@class.Panose = class6726_0.byte_0;
		@class.FamilyClass = class6726_0.short_11;
		if (Class5964.Contains(@class.SubFamilyName, "Bold", ignoreCase: true))
		{
			@class.Style |= FontStyle.Bold;
		}
		if (Class5964.Contains(@class.SubFamilyName, "Italic", ignoreCase: true))
		{
			@class.Style |= FontStyle.Italic;
		}
		@class.CapHeight = class6726_0.short_16;
		@class.XHeight = class6726_0.short_15;
		@class.Glyphs = class6636_0.method_2(class6728_0);
		@class.Cmap = class6636_0;
		@class.IsPrintPreview = (class6726_0.ushort_3 & 4u) != 0 && (class6726_0.ushort_3 & 8) == 0;
		return @class;
	}

	private void method_16(string tableName)
	{
		Class6729 @class = method_17(tableName);
		class5950_0.BaseStream.Position = @class.int_2;
	}

	[Attribute7(true)]
	internal Class6729 method_17(string tableName)
	{
		Class6729 @class = method_18(tableName);
		if (@class == null)
		{
			throw new InvalidOperationException($"Cannot find table '{tableName}' in the font file.");
		}
		return @class;
	}

	internal Class6729 method_18(string tableName)
	{
		return (Class6729)class5968_0[tableName];
	}

	internal byte[] method_19(string tableName)
	{
		Class6729 @class = method_17(tableName);
		class5950_0.BaseStream.Position = @class.int_2;
		return class5950_0.method_8(@class.int_3);
	}

	private int method_20(bool isWriteAdditionalTables)
	{
		class5951_0.method_0(65536);
		List<Class6729> list = new List<Class6729>();
		method_21(string_0, list);
		if (isWriteAdditionalTables)
		{
			method_21(string_1, list);
		}
		class5951_0.method_3(list.Count);
		int num = int_1[list.Count];
		int num2 = (1 << num) * 16;
		class5951_0.method_3(num2);
		class5951_0.method_3(num);
		int value = list.Count * 16 - num2;
		class5951_0.method_3(value);
		int result = (int)class5951_0.BaseStream.Position + list.Count * 16;
		foreach (Class6729 item in list)
		{
			item.Write(class5951_0);
		}
		return result;
	}

	private void method_21(string[] tableNames, List<Class6729> dirEntries)
	{
		foreach (string tableName in tableNames)
		{
			Class6729 @class = method_18(tableName);
			if (@class != null)
			{
				dirEntries.Add(@class);
			}
		}
	}

	private void method_22(bool isWriteAdditionalTables)
	{
		method_24("head");
		method_23("hhea", class6637_0.method_0());
		method_23("maxp", class6638_0.method_0());
		method_23("hmtx", memoryStream_2);
		method_24("fpgm");
		method_24("prep");
		method_24("cvt ");
		method_23("loca", memoryStream_0);
		method_23("glyf", memoryStream_1);
		if (isWriteAdditionalTables)
		{
			method_24("OS/2");
			method_24("name");
			method_23("cmap", class6636_0.method_0());
			method_23("post", class6639_0.method_0());
		}
	}

	private void method_23(string tableName, MemoryStream data)
	{
		Class6729 @class = method_17(tableName);
		@class.int_2 = (int)class5951_0.BaseStream.Position;
		class5951_0.method_4(data.GetBuffer(), 0, (int)data.Length);
		@class.int_1 = Class6729.smethod_0(data.GetBuffer(), 0, (int)data.Length);
		@class.int_3 = (int)data.Length;
		method_25();
	}

	private void method_24(string tableName)
	{
		Class6729 @class = method_18(tableName);
		if (@class != null)
		{
			class5950_0.BaseStream.Position = @class.int_2;
			byte[] array = class5950_0.method_8(@class.int_3);
			@class.int_2 = (int)class5951_0.BaseStream.Position;
			class5951_0.method_4(array, 0, array.Length);
			method_25();
		}
	}

	private void method_25()
	{
		Class5964.smethod_7(class5951_0.BaseStream, 4);
	}

	public Class6732()
	{
		idictionary_0 = Class6152.smethod_0();
	}

	private bool method_26()
	{
		class5950_0.BaseStream.Position = 0L;
		string text = new string(class5950_0.method_10(4));
		if (text != "ttcf")
		{
			return false;
		}
		int num = class5950_0.method_0();
		if (num != 65536 && num != 131072)
		{
			return false;
		}
		int_0 = class5950_0.method_0();
		uint_0 = new uint[int_0];
		for (int i = 0; i < int_0; i++)
		{
			uint_0[i] = class5950_0.method_1();
		}
		if (131072 == num)
		{
			class5950_0.method_1();
			class5950_0.method_1();
			class5950_0.method_1();
		}
		return true;
	}

	[Attribute7(true)]
	private Class6723[] method_27()
	{
		if (int_0 <= 0)
		{
			throw new InvalidOperationException("Can't read TTC entry.");
		}
		List<Class6723> list = new List<Class6723>();
		for (int i = 0; i < int_0; i++)
		{
			class5950_0.BaseStream.Position = uint_0[i];
			int num = method_5();
			if (num > 0)
			{
				for (int j = 0; j < num; j++)
				{
					Class6729 @class = new Class6729(class5950_0);
					if (@class.string_0 == "name")
					{
						int int_ = @class.int_2;
						class5950_0.BaseStream.Position = int_;
						method_28(int_);
						string[] array = class6724_0.method_3(Enum896.const_4);
						string[] array2 = array;
						foreach (string key in array2)
						{
							idictionary_0[key] = uint_0[i];
						}
						Class6723[] array3 = class6724_0.method_4();
						if (array3 != null)
						{
							list.AddRange(array3);
						}
					}
				}
				continue;
			}
			throw new InvalidOperationException("Can't read TTC entry.");
		}
		return list.ToArray();
	}

	[Attribute7(true)]
	private void method_28(int tableStart)
	{
		if (class5950_0.method_3() != 0)
		{
			throw new InvalidOperationException("Unsupported Name table format.");
		}
		ushort num = class5950_0.method_3();
		ushort num2 = class5950_0.method_3();
		class6724_0 = new Class6724();
		for (int i = 0; i < num; i++)
		{
			int num3 = class5950_0.method_3();
			int num4 = class5950_0.method_3();
			int languageId = class5950_0.method_3();
			int nameId = class5950_0.method_3();
			int count = class5950_0.method_3();
			int num5 = class5950_0.method_3();
			Encoding encoding = null;
			switch (num3)
			{
			case 0:
				encoding = Encoding.BigEndianUnicode;
				break;
			case 1:
				switch (num4)
				{
				case 2:
					encoding = Encoding.GetEncoding("big5");
					break;
				case 0:
				case 1:
				case 3:
				case 25:
					encoding = Encoding.GetEncoding(1252);
					break;
				}
				break;
			case 3:
				switch (num4)
				{
				case 4:
					encoding = Encoding.GetEncoding("big5");
					break;
				default:
					encoding = Encoding.GetEncoding("utf-16be");
					break;
				case 0:
				case 1:
				case 10:
					encoding = Encoding.BigEndianUnicode;
					break;
				}
				break;
			}
			if (encoding == null)
			{
				continue;
			}
			int num6 = (int)class5950_0.BaseStream.Position;
			class5950_0.BaseStream.Position = tableStart + num2 + num5;
			byte[] array = class5950_0.method_8(count);
			string @string;
			if (encoding.BodyName == "big5")
			{
				byte[] array2 = new byte[array.Length];
				int count2 = 0;
				byte[] array3 = array;
				foreach (byte b in array3)
				{
					if (b != 0)
					{
						array2[count2++] = b;
					}
				}
				@string = encoding.GetString(array2, 0, count2);
			}
			else
			{
				@string = encoding.GetString(array);
			}
			if (class6724_0.method_2((Enum896)nameId, languageId) == null)
			{
				class6724_0.Add((Enum896)nameId, languageId, @string);
			}
			class5950_0.BaseStream.Position = num6;
		}
	}

	private void method_29(bool isMakeValidTtf, Stream dstStream)
	{
		class5951_0 = new Class5951(dstStream);
		int num = method_20(isMakeValidTtf);
		class5951_0.BaseStream.Position = num;
		method_22(isMakeValidTtf);
		class5951_0.BaseStream.Position = 0L;
		method_20(isMakeValidTtf);
	}

	internal void method_30(Class6730 font, Stream dstStream)
	{
		if (font == null)
		{
			throw new ArgumentNullException("font");
		}
		if (dstStream == null)
		{
			throw new ArgumentNullException("dstStream");
		}
		if (!font.IsCff)
		{
			throw new InvalidOperationException("OpenType font with CFF table is required.");
		}
		using Stream stream = font.Data.vmethod_0();
		class5950_0 = new Class5950(stream);
		method_6(font.FullFontName);
		Class6729 @class = method_18("CFF ");
		if (@class == null)
		{
			throw new InvalidOperationException("There is no CFF table in font file.");
		}
		class5950_0.BaseStream.Position = @class.int_2;
		byte[] array = new byte[@class.int_3];
		class5950_0.BaseStream.Read(array, 0, array.Length);
		dstStream.Write(array, 0, array.Length);
	}
}
