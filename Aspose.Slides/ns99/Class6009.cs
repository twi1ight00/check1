using System;
using System.Drawing;

namespace ns99;

internal static class Class6009
{
	public static Font smethod_0(string requestedName, float sizeInPoints, FontStyle requestedStyle)
	{
		try
		{
			return new Font(requestedName, sizeInPoints, requestedStyle, GraphicsUnit.Point);
		}
		catch (Exception)
		{
			FontFamily fontFamily = smethod_1(requestedName);
			FontStyle style = smethod_2(fontFamily, requestedStyle);
			return new Font(fontFamily.Name, sizeInPoints, style, GraphicsUnit.Point);
		}
	}

	private static FontFamily smethod_1(string name)
	{
		FontFamily fontFamily = Class6010.smethod_1(name);
		if (fontFamily == null)
		{
			fontFamily = Class6010.smethod_1("Times New Roman");
		}
		if (fontFamily == null)
		{
			fontFamily = Class6010.smethod_2();
		}
		if (fontFamily == null)
		{
			throw new InvalidOperationException("No fonts are installed on the system.");
		}
		return fontFamily;
	}

	private static FontStyle smethod_2(FontFamily family, FontStyle style)
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
}
