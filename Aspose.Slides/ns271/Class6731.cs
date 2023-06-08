using System;
using System.Collections;
using System.Drawing;

namespace ns271;

internal class Class6731
{
	private readonly string string_0;

	private readonly Hashtable hashtable_0;

	internal string FamilyName => string_0;

	internal int Count => hashtable_0.Count;

	internal Class6731(string familyName)
	{
		string_0 = familyName;
		hashtable_0 = new Hashtable();
	}

	internal void Add(Class6730 font)
	{
		hashtable_0[font.Style] = font;
	}

	internal Class6730 method_0(FontStyle style, bool isExactStyle)
	{
		Class6730 @class = (Class6730)hashtable_0[style];
		if (@class != null)
		{
			return @class;
		}
		if (isExactStyle)
		{
			return null;
		}
		FontStyle fontStyle = style & ~FontStyle.Underline;
		@class = (Class6730)hashtable_0[fontStyle];
		if (@class != null)
		{
			return @class;
		}
		fontStyle = style & ~FontStyle.Strikeout;
		@class = (Class6730)hashtable_0[fontStyle];
		if (@class != null)
		{
			return @class;
		}
		fontStyle = style & ~FontStyle.Italic;
		@class = (Class6730)hashtable_0[fontStyle];
		if (@class != null)
		{
			return @class;
		}
		fontStyle = style & ~FontStyle.Bold;
		@class = (Class6730)hashtable_0[fontStyle];
		if (@class != null)
		{
			return @class;
		}
		fontStyle = FontStyle.Regular;
		@class = (Class6730)hashtable_0[FontStyle.Regular];
		if (@class != null)
		{
			return @class;
		}
		IEnumerator enumerator = hashtable_0.Values.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				return (Class6730)current;
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
}
