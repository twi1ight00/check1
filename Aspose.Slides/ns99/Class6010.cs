using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using ns218;

namespace ns99;

internal static class Class6010
{
	private static readonly Hashtable hashtable_0;

	public static bool smethod_0(string fontName)
	{
		if (Class5964.smethod_20(fontName))
		{
			return hashtable_0.Contains(fontName);
		}
		return false;
	}

	public static FontFamily smethod_1(string fontName)
	{
		return (FontFamily)hashtable_0[fontName];
	}

	public static FontFamily smethod_2()
	{
		IDictionaryEnumerator dictionaryEnumerator = hashtable_0.GetEnumerator();
		try
		{
			if (dictionaryEnumerator.MoveNext())
			{
				return (FontFamily)((DictionaryEntry)dictionaryEnumerator.Current).Value;
			}
		}
		finally
		{
			IDisposable disposable = dictionaryEnumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	static Class6010()
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
