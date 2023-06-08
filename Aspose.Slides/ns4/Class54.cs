using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns224;
using ns271;
using ns33;
using ns49;
using ns6;

namespace ns4;

internal class Class54 : IDisposable
{
	private Class61 class61_0;

	private readonly LoadOptions loadOptions_0;

	private static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	public Class61 EmbeddedFonts => class61_0;

	public Class54(LoadOptions loadOptions)
	{
		loadOptions_0 = loadOptions;
	}

	public void method_0(Class61 embeddedFonts)
	{
		if (embeddedFonts == null)
		{
			throw new ArgumentNullException("embeddedFonts", "Embedded fonts collection can not be null");
		}
		if (embeddedFonts.Count != 0)
		{
			class61_0 = embeddedFonts;
		}
	}

	public Class6730 method_1(string familyName, FontStyle style)
	{
		Class6730 @class = Class6652.Instance.vmethod_0(familyName, style);
		if (class61_0 != null && (@class == null || @class.FamilyName.ToLower() != familyName.ToLower() || @class.Style != style))
		{
			Class6730 class2 = class61_0.method_0(familyName, style);
			if (class2 != null)
			{
				@class = class2;
			}
		}
		return @class;
	}

	public Class5999 method_2(string familyName, float sizePoints, FontStyle style, Class151 textParam)
	{
		Enum748 fontCapitals = ((textParam == null || textParam.TextCapType != TextCapType.Small) ? Enum748.const_0 : Enum748.const_1);
		Class5999 @class = Class6652.Instance.method_2(familyName, sizePoints, style, fontCapitals);
		if (class61_0 != null && (@class == null || @class.FamilyName.ToLower() != familyName.ToLower() || @class.Style != style))
		{
			Class5999 class2 = class61_0.method_2(familyName, sizePoints, style, textParam);
			if (class2 != null)
			{
				@class = class2;
			}
		}
		return @class;
	}

	public Font method_3(string familyName, float size, FontStyle style)
	{
		Font font = FontsLoader.smethod_3(familyName, size, style);
		if (class61_0 != null && (font == null || font.FontFamily.Name.ToLower() != familyName.ToLower() || font.Style != style))
		{
			Font font2 = class61_0.method_3(familyName, size, style);
			if (font2 != null)
			{
				font = font2;
			}
		}
		if (familyName != font.Name)
		{
			smethod_1(familyName, font.Name);
			smethod_0(loadOptions_0, new FontData(familyName), new FontData[1]
			{
				new FontData(font.Name)
			});
		}
		return font;
	}

	public string[] method_4(char symbol, Enum1 charSet, int pitchFamily, byte[] panose)
	{
		string[] array = Class731.smethod_0(charSet, pitchFamily, panose);
		string[] array2 = Class734.smethod_0(symbol);
		string text = ((class61_0 != null) ? class61_0.method_1(pitchFamily) : null);
		if (array2 != null || text != null)
		{
			ArrayList arrayList = new ArrayList(array.Length + 2);
			if (text != null)
			{
				arrayList.Add(text);
			}
			string[] array3 = array;
			foreach (string value in array3)
			{
				arrayList.Add(value);
			}
			if (array2 != null)
			{
				string[] array4 = array2;
				foreach (string value2 in array4)
				{
					arrayList.Add(value2);
				}
			}
			array = (string[])arrayList.ToArray(typeof(string));
		}
		return array;
	}

	public void Dispose()
	{
		if (class61_0 != null)
		{
			class61_0.Dispose();
		}
	}

	internal static void smethod_0(LoadOptions loadOptions, FontData originalFont, FontData[] substitutions)
	{
		if (loadOptions != null && loadOptions.WarningCallback != null)
		{
			if (substitutions == null || substitutions.Length == 0)
			{
				throw new ArgumentException("substitutions");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			foreach (FontData fontData in substitutions)
			{
				stringBuilder.Append(fontData.FontName);
			}
			stringBuilder.Append("}");
			Class1176 @class = new Class1176($"Font will be substituted from {originalFont.FontName} to {stringBuilder.ToString()}", WarningType.DataLoss);
			@class.SendWarning(loadOptions.WarningCallback);
		}
	}

	internal static void smethod_1(string source, string dest)
	{
		if (!(source == dest) && (!dictionary_0.ContainsKey(source) || !(dictionary_0[source] != dest)) && !dictionary_0.ContainsKey(source))
		{
			dictionary_0.Add(source, dest);
		}
	}

	internal static bool smethod_2(string fontName)
	{
		return dictionary_0.ContainsKey(fontName);
	}
}
