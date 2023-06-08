using System;
using System.IO;
using ns103;
using ns105;
using ns119;
using ns130;
using ns146;
using ns147;
using ns149;
using ns99;

namespace ns101;

internal class Class4419 : Class4417
{
	private enum Enum664
	{
		const_0,
		const_1,
		const_2,
		const_3
	}

	private Class4490 class4490_0;

	private Class4411 class4411_0;

	private Class4651 class4651_0;

	private Class4681 class4681_0 = Class4681.smethod_0();

	private Enum664 enum664_0;

	public override Class4408 vmethod_0(Class4490 fontDefinition)
	{
		try
		{
			class4490_0 = fontDefinition;
			method_0();
			switch (enum664_0)
			{
			case Enum664.const_0:
			case Enum664.const_1:
				method_3();
				break;
			case Enum664.const_2:
				method_3();
				method_1();
				break;
			case Enum664.const_3:
				method_2();
				break;
			}
		}
		catch (EndOfStreamException innerException)
		{
			if (Class4510.Current.Strictness != Class4510.Enum644.const_1)
			{
				throw new Exception44("Unexpected font parsing exception", innerException);
			}
		}
		catch (Exception29)
		{
			throw;
		}
		catch (Exception innerException2)
		{
			throw new Exception44("Unexpected font parsing exception", innerException2);
		}
		return class4411_0;
	}

	private void method_0()
	{
		if (class4490_0 == null)
		{
			throw new Exception37("Font creation error. Could not find the font.");
		}
		enum664_0 = Enum664.const_0;
		if (class4490_0 is Class4491)
		{
			if (((Class4491)class4490_0).GlobalFontDefinition is Class4491.Class4636)
			{
				class4411_0 = new Class4411(class4490_0, class4681_0);
				class4651_0 = new Class4652((Class4491)class4490_0, class4411_0, class4681_0);
				enum664_0 = Enum664.const_2;
			}
			else
			{
				class4411_0 = new Class4411();
				enum664_0 = Enum664.const_3;
			}
			return;
		}
		string text = null;
		Class4492 @class = null;
		Class4492 class2 = null;
		if (class4490_0.FileDefinitions.Length == 1 && class4490_0.FileDefinitions[0].FileExtension == null)
		{
			if (class4490_0.FileDefinitions[0].StreamSource is Class4489 class3)
			{
				text = Path.GetExtension(class3.FileName).ToLower().TrimStart('.');
			}
			@class = class4490_0.FileDefinitions[0];
		}
		else
		{
			for (int num = class4490_0.FileDefinitions.Length - 1; num >= 0; num--)
			{
				if (class4490_0.FileDefinitions[num].FileExtension == Class4682.TTFExtension || class4490_0.FileDefinitions[num].FileExtension == Class4682.TTCExtension || class4490_0.FileDefinitions[num].FileExtension == Class4682.OTFExtension || class4490_0.FileDefinitions[num].FileExtension == Class4682.EOTExtension || class4490_0.FileDefinitions[num].FileExtension == Class4682.FntdataExtension)
				{
					text = class4490_0.FileDefinitions[num].FileExtension;
					@class = class4490_0.FileDefinitions[num];
				}
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			text = "ttf";
		}
		if (@class != null)
		{
			if (!(text == Class4682.TTFExtension) && !(text == Class4682.TTCExtension) && !(text == Class4682.OTFExtension))
			{
				if (text == Class4682.EOTExtension || text == Class4682.FntdataExtension)
				{
					enum664_0 = Enum664.const_1;
					using Stream input = @class.StreamSource.vmethod_0();
					using MemoryStream memoryStream = new MemoryStream();
					Class4594 class4 = new Class4594(input);
					class4.method_0(memoryStream);
					memoryStream.Close();
					class4490_0 = new Class4490(Enum639.const_0, "ttf", new Class4488(memoryStream.ToArray()));
					class2 = class4490_0.FileDefinitions[0];
				}
			}
			else
			{
				class2 = @class;
			}
		}
		if (class2 == null)
		{
			throw new Exception39("could not load font");
		}
		class4411_0 = new Class4411(class4490_0, class4681_0);
		class4651_0 = new Class4651(class2, class4411_0, class4681_0);
	}

	private void method_1()
	{
		if (!(class4490_0 is Class4491 @class))
		{
			return;
		}
		class4411_0.FontName = @class.GlobalFontDefinition.FontName;
		class4411_0.FontNames = new Class4519(@class.FontName);
		class4411_0.FontFamily = @class.GlobalFontDefinition.FontName;
		class4411_0.TTFTables.GlyfTable = new Class4660(class4651_0, 0u, 0u, 0u);
		Class4411 class2 = (Class4411)Class4408.smethod_6(Enum639.const_0, class4411_0, new Class4486(adoptHinting: false));
		class2.FontName = @class.GlobalFontDefinition.FontName;
		class2.FontNames = new Class4519(@class.GlobalFontDefinition.FontName);
		int num = 0;
		foreach (int key in @class.GlyphIdToGlyphData.Keys)
		{
			num++;
			Class4491.Class4639 class3 = (Class4491.Class4639)@class.GlyphIdToGlyphData[key];
			Class4480 class4 = class4411_0.method_3(key);
			if (class4 is Class4481)
			{
				class4 = ((Class4481)class4).method_3();
			}
			if (class4411_0.TTFTables.HmtxTable == null)
			{
				class4.WidthVectorX = class3.AdvanceWidth;
			}
			ushort gid = class2.method_1(class4);
			class2.Encoding.imethod_1(gid, (char)class3.CharCode);
		}
		byte[] fileContent;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			Class4474 class5 = Class4474.smethod_0(class2, memoryStream);
			class5.Save();
			memoryStream.Close();
			fileContent = memoryStream.ToArray();
		}
		class4411_0 = (Class4411)Class4408.smethod_2(Enum639.const_0, new Class4488(fileContent));
	}

	private void method_2()
	{
		if (!(class4490_0 is Class4491 @class))
		{
			return;
		}
		class4411_0.FontName = @class.GlobalFontDefinition.FontName;
		class4411_0.FontNames = new Class4519(@class.FontName);
		class4411_0.FontFamily = @class.GlobalFontDefinition.FontName;
		class4411_0.Style = "Regular";
		Class4491.Class4637 class2 = (Class4491.Class4637)@class.GlobalFontDefinition;
		int xResolution = class2.XResolution;
		double num = (double)class4411_0.Metrics.UnitsPerEM / ((double)((float)xResolution * @class.GlobalFontDefinition.FontSize) / 72.0);
		foreach (int key in @class.CharCodeToGlyphData.Keys)
		{
			Class4491.Class4640 class3 = (Class4491.Class4640)@class.CharCodeToGlyphData[key];
			Class4480 class4 = new Class4480();
			Class4495 class5 = new Class4495(class4, num);
			class5.method_0(class3);
			class4.WidthVectorX = (double)class3.DeltaX / 4.0 * num;
			ushort gid = class4411_0.method_1(class4);
			class4411_0.Encoding.imethod_1(gid, (char)class3.CharCode);
		}
		byte[] fileContent;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			Class4474 class6 = Class4474.smethod_0(class4411_0, memoryStream);
			class6.Save();
			memoryStream.Close();
			fileContent = memoryStream.ToArray();
		}
		class4411_0 = (Class4411)Class4408.smethod_2(Enum639.const_0, new Class4488(fileContent));
	}

	private void method_3()
	{
		using Class4689 @class = new Class4689(class4651_0.vmethod_0());
		@class.Seek(class4651_0.vmethod_0().Offset);
		class4681_0.OffsetSubtable = new Class4680(@class.method_19(), @class.method_18(), @class.method_18(), @class.method_18(), @class.method_18());
		for (int i = 0; i < class4681_0.OffsetSubtable.NumTables; i++)
		{
			string tableName = @class.method_3(4);
			uint checkSum = @class.method_19();
			uint offset = @class.method_19();
			uint length = @class.method_19();
			class4411_0.AddTable(tableName, class4651_0, checkSum, offset, length);
		}
		method_4("head", class4681_0.HeadTable, @class);
		smethod_1("name", class4681_0.NameTable, @class, isRequired: false);
		method_4("maxp", class4681_0.MaxpTable, @class);
		smethod_1("loca", class4681_0.LocaTable, @class, isRequired: false);
		smethod_1("cmap", class4681_0.CMapTable, @class, isRequired: false);
		smethod_1("hhea", class4681_0.HheaTable, @class, isRequired: false);
		smethod_1("hmtx", class4681_0.HmtxTable, @class, isRequired: false);
		smethod_1("post", class4681_0.PostTable, @class, isRequired: false);
		smethod_1("glyf", class4681_0.GlyfTable, @class, isRequired: false);
		smethod_1("kern", class4681_0.KernTable, @class, isRequired: false);
		smethod_1("cff", class4681_0.CFFTable, @class, isRequired: false);
		smethod_1("cvt", class4681_0.CvtTable, @class, isRequired: false);
		smethod_1("fpgm", class4681_0.FpgmTable, @class, isRequired: false);
		smethod_1("prep", class4681_0.PrepTable, @class, isRequired: false);
		smethod_1("OS/2", class4681_0.OS2Table, @class, isRequired: false);
		if (class4411_0.TTFTables.NameTable != null)
		{
			class4411_0.FontName = class4411_0.TTFTables.NameTable.method_8(Class4669.Enum660.const_4);
			class4411_0.FontNames = class4411_0.TTFTables.NameTable.method_6(Class4669.Enum660.const_4);
			class4411_0.PostscriptNames = class4411_0.TTFTables.NameTable.method_6(Class4669.Enum660.const_6);
			class4411_0.FontFamily = class4411_0.TTFTables.NameTable.method_8(Class4669.Enum660.const_1);
			class4411_0.Style = class4411_0.TTFTables.NameTable.method_8(Class4669.Enum660.const_2);
		}
	}

	private void method_4(string tableTag, Class4655 table, Class4689 ttfReader)
	{
		smethod_1(tableTag, table, ttfReader, isRequired: true);
	}

	private static void smethod_1(string tableTag, Class4655 table, Class4689 ttfReader, bool isRequired)
	{
		if (table != null && table.Offset < ttfReader.StreamLength)
		{
			try
			{
				long position = ttfReader.Position;
				table.vmethod_2(ttfReader);
				ttfReader.Seek(position);
				return;
			}
			catch (EndOfStreamException innerException)
			{
				if (Class4510.Current.Strictness != Class4510.Enum644.const_1)
				{
					throw new Exception44("Unexpected font parsing exception", innerException);
				}
				return;
			}
			catch (Exception innerException2)
			{
				throw new Exception42($"Parsing of table '{tableTag}' has failed.", innerException2);
			}
		}
		if (isRequired)
		{
			if (table == null)
			{
				throw new Exception42($"The required table '{tableTag}' was not found.");
			}
			throw new Exception42($"The required table '{tableTag}' is out of file. The font file is broken.");
		}
	}
}
