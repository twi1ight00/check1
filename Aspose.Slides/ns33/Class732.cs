using System.Collections;
using System.Drawing;

namespace ns33;

internal sealed class Class732
{
	private FontStyle fontStyle_0;

	private FontStyle fontStyle_1;

	private static readonly Hashtable hashtable_0;

	internal static FontStyle smethod_0(string fontName, FontStyle fontStyle)
	{
		if (fontName == null)
		{
			return fontStyle;
		}
		Class732 @class = (Class732)hashtable_0[fontName];
		if (@class == null)
		{
			return fontStyle;
		}
		return (fontStyle & @class.fontStyle_0) | @class.fontStyle_1;
	}

	private Class732(FontStyle clearStyle, FontStyle setMask)
	{
		fontStyle_0 = ~clearStyle;
		fontStyle_1 = setMask;
	}

	static Class732()
	{
		hashtable_0 = new Hashtable(CaseInsensitiveHashCodeProvider.DefaultInvariant, CaseInsensitiveComparer.DefaultInvariant);
		hashtable_0.Add("arial black", new Class732(FontStyle.Bold, FontStyle.Regular));
		hashtable_0.Add("arial narrow bold", new Class732(FontStyle.Regular, FontStyle.Bold));
		hashtable_0.Add("franklin gothic medium", new Class732(FontStyle.Bold, FontStyle.Regular));
		hashtable_0.Add("aharoni", new Class732(FontStyle.Regular, FontStyle.Bold));
		hashtable_0.Add("Berlin Sans FB Demi", new Class732(FontStyle.Regular, FontStyle.Bold));
		hashtable_0.Add("Harlow Solid Italic", new Class732(FontStyle.Regular, FontStyle.Italic));
	}
}
