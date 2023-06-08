using System;
using Aspose.Slides;
using ns24;
using ns56;

namespace ns18;

internal class Class950
{
	public static void smethod_0(IFontData fontData, Class1956 textFontElementData)
	{
		if (textFontElementData != null)
		{
			((FontData)fontData).FontName = textFontElementData.Typeface;
			smethod_1(fontData, textFontElementData);
		}
	}

	private static void smethod_1(IFontData fontData, Class1956 textFontElementData)
	{
		Class338 pPTXUnsupportedProps = ((FontData)fontData).PPTXUnsupportedProps;
		if (textFontElementData.Panose != null && textFontElementData.Panose != "")
		{
			pPTXUnsupportedProps.Panose = new byte[10];
			for (int i = 0; i < pPTXUnsupportedProps.Panose.Length; i++)
			{
				int num = i * 2;
				byte b = smethod_2(textFontElementData.Panose[num]);
				byte b2 = smethod_2(textFontElementData.Panose[num + 1]);
				pPTXUnsupportedProps.Panose[i] = (byte)((b << 4) + b2);
			}
		}
		pPTXUnsupportedProps.PitchFamily = (byte)textFontElementData.PitchFamily;
		pPTXUnsupportedProps.Charset = (byte)textFontElementData.Charset;
	}

	private static byte smethod_2(char c)
	{
		if (c <= '9')
		{
			if (c >= '0')
			{
				return (byte)(c - 48);
			}
			throw new Exception("Not hex value.");
		}
		if (c <= 'F')
		{
			if (c >= 'A')
			{
				return (byte)(c - 65 + 10);
			}
			throw new Exception("Not hex value.");
		}
		if (c < 'a' || c > 'f')
		{
			throw new Exception("Not hex value.");
		}
		return (byte)(c - 97 + 10);
	}

	public static void smethod_3(IFontData fontData, Class1956.Delegate1735 addFontData)
	{
		if (fontData != null)
		{
			smethod_4(fontData, addFontData());
		}
	}

	public static void smethod_4(IFontData fontData, Class1956 textFontElementData)
	{
		if (fontData == null)
		{
			textFontElementData.Typeface = "";
			return;
		}
		textFontElementData.Typeface = fontData.FontName ?? "";
		smethod_5(fontData, textFontElementData);
	}

	private static void smethod_5(IFontData fontData, Class1956 textFontElementData)
	{
		Class338 pPTXUnsupportedProps = ((FontData)fontData).PPTXUnsupportedProps;
		byte[] panose = pPTXUnsupportedProps.Panose;
		if (panose != null)
		{
			string panose2 = $"{panose[0]:x2}{panose[1]:x2}{panose[2]:x2}{panose[3]:x2}{panose[4]:x2}{panose[5]:x2}{panose[6]:x2}{panose[7]:x2}{panose[8]:x2}{panose[9]:x2}";
			textFontElementData.Panose = panose2;
		}
		textFontElementData.PitchFamily = (sbyte)pPTXUnsupportedProps.PitchFamily;
		textFontElementData.Charset = (sbyte)pPTXUnsupportedProps.Charset;
	}
}
