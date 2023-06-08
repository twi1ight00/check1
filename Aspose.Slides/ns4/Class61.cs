using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns224;
using ns24;
using ns271;
using ns99;

namespace ns4;

internal sealed class Class61 : IDisposable
{
	private class Class62
	{
		private int int_0;

		private int int_1;

		private string string_0;

		private Dictionary<FontStyle, Class6730> dictionary_0;

		public int Charset => int_0;

		public int Family
		{
			get
			{
				int num = int_1 >> 4;
				if (num > 5)
				{
					num = 0;
				}
				return num;
			}
		}

		public int Pitch
		{
			get
			{
				int num = int_1 & 0xF;
				if (num > 2)
				{
					num = ((num == 8) ? 1 : 0);
				}
				return num;
			}
		}

		public string Typeface => string_0;

		public Class62(string typeFace, int charset, int pitchFamily)
		{
			string_0 = typeFace;
			int_0 = charset;
			int_1 = pitchFamily;
			dictionary_0 = new Dictionary<FontStyle, Class6730>();
		}

		public void method_0(FontStyle style, Class6730 trueTypeFont)
		{
			dictionary_0.Add(style, trueTypeFont);
		}

		public Class6730 method_1(FontStyle style)
		{
			if (dictionary_0.ContainsKey(style))
			{
				return dictionary_0[style];
			}
			if (!dictionary_0.ContainsKey(FontStyle.Regular))
			{
				throw new KeyNotFoundException();
			}
			return dictionary_0[FontStyle.Regular];
		}
	}

	private Dictionary<string, Class62> dictionary_0;

	private Dictionary<string, FontFamily> dictionary_1;

	private PrivateFontCollection privateFontCollection_0;

	private List<Class4408> list_0;

	private Class335 class335_0;

	public int Count => dictionary_0.Count;

	public Class335 PPTXUnsupportedProps => class335_0;

	public Class61()
	{
		dictionary_0 = new Dictionary<string, Class62>();
		dictionary_1 = new Dictionary<string, FontFamily>();
		privateFontCollection_0 = new PrivateFontCollection();
		class335_0 = new Class335();
		list_0 = new List<Class4408>();
	}

	~Class61()
	{
		Dispose();
	}

	public Class6730 method_0(string familyName, FontStyle style)
	{
		if (!dictionary_0.ContainsKey(familyName))
		{
			return null;
		}
		return dictionary_0[familyName].method_1(style);
	}

	public string method_1(int pitchFamily)
	{
		foreach (Class62 value in dictionary_0.Values)
		{
			int num = pitchFamily >> 4;
			if (num > 5)
			{
				num = 0;
			}
			if (value.Family == num)
			{
				return value.Typeface;
			}
		}
		return null;
	}

	public Class5999 method_2(string familyName, float sizePoints, FontStyle style, Class151 textParam)
	{
		Class6730 @class = method_0(familyName, style);
		if (@class == null)
		{
			return null;
		}
		Enum748 capitals = ((textParam == null || textParam.TextCapType != TextCapType.Small) ? Enum748.const_0 : Enum748.const_1);
		return new Class5999(sizePoints, style, @class, capitals);
	}

	public Font method_3(string familyName, float size, FontStyle style)
	{
		Class6730 @class = method_0(familyName, style);
		if (@class == null)
		{
			return null;
		}
		FontFamily fontFamily = (dictionary_1.ContainsKey(@class.FamilyName) ? dictionary_1[@class.FamilyName] : null);
		if (fontFamily != null && fontFamily.IsStyleAvailable(style))
		{
			return new Font(fontFamily, size, style);
		}
		return null;
	}

	public void Dispose()
	{
		try
		{
			privateFontCollection_0.Dispose();
		}
		catch
		{
		}
		foreach (FontFamily value in dictionary_1.Values)
		{
			try
			{
				value.Dispose();
			}
			catch
			{
			}
		}
		dictionary_1.Clear();
		dictionary_0.Clear();
		list_0.Clear();
	}

	public List<Class4408> method_4()
	{
		return new List<Class4408>(list_0);
	}

	internal void method_5(string typeface, int charset, int pitchFamily, FontStyle style, Class4408 font, LoadOptions loadOptions)
	{
		Class62 @class;
		if (dictionary_0.ContainsKey(typeface))
		{
			@class = dictionary_0[typeface];
		}
		else
		{
			@class = new Class62(typeface, charset, pitchFamily);
			dictionary_0.Add(typeface, @class);
		}
		byte[] array;
		using (Stream stream = font.FontDefinition.FileDefinitions[0].StreamSource.vmethod_0())
		{
			array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			stream.Close();
		}
		Class6732 class2 = new Class6732();
		@class.method_0(style, class2.Read(new Class6656(array), font.FontName));
		GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
		try
		{
			privateFontCollection_0.AddMemoryFont(gCHandle.AddrOfPinnedObject(), array.Length);
		}
		catch (FileNotFoundException)
		{
			loadOptions?.method_1($"Font {typeface} could not be loaded", WarningType.DataLoss);
		}
		finally
		{
			gCHandle.Free();
		}
		list_0.Add(font);
	}

	internal void method_6()
	{
		dictionary_1.Clear();
		FontFamily[] families = privateFontCollection_0.Families;
		FontFamily[] array = families;
		foreach (FontFamily fontFamily in array)
		{
			for (int j = 0; j < 255; j++)
			{
				string name = fontFamily.GetName(j);
				if (!dictionary_1.ContainsKey(name))
				{
					dictionary_1.Add(fontFamily.GetName(j), fontFamily);
				}
			}
		}
	}
}
