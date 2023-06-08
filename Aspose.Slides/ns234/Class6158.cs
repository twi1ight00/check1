using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using ns218;
using ns224;
using ns271;

namespace ns234;

internal static class Class6158
{
	private static readonly Hashtable hashtable_0;

	public static Font smethod_0(Class5999 font, Class6163 privateFontCache)
	{
		if (!smethod_6(font))
		{
			try
			{
				FontFamily fontFamily = privateFontCache.method_0(font);
				if (fontFamily != null)
				{
					return new Font(fontFamily, font.SizePoints, smethod_3(fontFamily, font.Style), GraphicsUnit.Point);
				}
			}
			catch (Exception)
			{
			}
		}
		return smethod_1(font.FamilyName, font.SizePoints, font.Style);
	}

	public static Font smethod_1(string requestedName, float sizeInPoints, FontStyle requestedStyle)
	{
		try
		{
			return new Font(requestedName, sizeInPoints, requestedStyle, GraphicsUnit.Point);
		}
		catch (Exception)
		{
			FontFamily fontFamily = smethod_2(requestedName);
			FontStyle style = smethod_3(fontFamily, requestedStyle);
			return new Font(fontFamily.Name, sizeInPoints, style, GraphicsUnit.Point);
		}
	}

	private static FontFamily smethod_2(string name)
	{
		FontFamily fontFamily = smethod_4(name);
		if (fontFamily == null)
		{
			fontFamily = smethod_4("Times New Roman");
		}
		if (fontFamily == null)
		{
			fontFamily = smethod_5();
		}
		if (fontFamily == null)
		{
			throw new InvalidOperationException("No fonts are installed on the system.");
		}
		return fontFamily;
	}

	private static FontStyle smethod_3(FontFamily family, FontStyle style)
	{
		if (family.IsStyleAvailable(style))
		{
			return style;
		}
		switch (style)
		{
		case FontStyle.Bold:
		case FontStyle.Italic:
			if (family.IsStyleAvailable(FontStyle.Bold | FontStyle.Italic))
			{
				return FontStyle.Bold | FontStyle.Italic;
			}
			break;
		case FontStyle.Bold | FontStyle.Italic:
			if (family.IsStyleAvailable(FontStyle.Italic))
			{
				return FontStyle.Italic;
			}
			if (family.IsStyleAvailable(FontStyle.Bold))
			{
				return FontStyle.Bold;
			}
			break;
		}
		if (family.IsStyleAvailable(FontStyle.Regular))
		{
			return FontStyle.Regular;
		}
		if (family.IsStyleAvailable(FontStyle.Bold))
		{
			return FontStyle.Bold;
		}
		if (family.IsStyleAvailable(FontStyle.Italic))
		{
			return FontStyle.Italic;
		}
		if (!family.IsStyleAvailable(FontStyle.Bold | FontStyle.Italic))
		{
			throw new InvalidOperationException("No fonts of this family are available.");
		}
		return FontStyle.Bold | FontStyle.Italic;
	}

	private static FontFamily smethod_4(string fontName)
	{
		return (FontFamily)hashtable_0[fontName];
	}

	private static FontFamily smethod_5()
	{
		IEnumerator enumerator = hashtable_0.Values.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				return (FontFamily)enumerator.Current;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	private static bool smethod_6(Class5999 font)
	{
		if (font.TrueTypeFont.Data is Class6655)
		{
			string fileName = ((Class6655)font.TrueTypeFont.Data).FileName;
			string text = (Class5964.smethod_20(fileName) ? Path.GetDirectoryName(fileName) : null);
			if (Class5964.smethod_20(text))
			{
				string[] array = Class6652.smethod_0();
				foreach (string b in array)
				{
					if (Class5964.smethod_42(text, b))
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	static Class6158()
	{
		hashtable_0 = new Hashtable();
		FontFamily[] families = new InstalledFontCollection().Families;
		FontFamily[] array = families;
		foreach (FontFamily fontFamily in array)
		{
			hashtable_0[fontFamily.Name] = fontFamily;
		}
	}
}
