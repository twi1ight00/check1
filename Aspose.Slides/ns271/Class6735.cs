using System;
using System.Collections;
using ns218;

namespace ns271;

internal class Class6735
{
	private readonly Hashtable hashtable_0 = new Hashtable();

	private Class6734 class6734_0;

	private bool bool_0;

	public Class6734 this[char charCode]
	{
		get
		{
			Class6734 @class = (Class6734)hashtable_0[charCode];
			if (@class != null)
			{
				return @class;
			}
			if (bool_0)
			{
				if (Class5958.smethod_4(charCode))
				{
					return (Class6734)hashtable_0[Class5958.smethod_2(charCode)];
				}
				return (Class6734)hashtable_0[Class5958.smethod_5(charCode)];
			}
			return null;
		}
		set
		{
			hashtable_0[charCode] = value;
		}
	}

	public int Count => hashtable_0.Count;

	public Class6734 MissingGlyph
	{
		get
		{
			return class6734_0;
		}
		set
		{
			class6734_0 = value;
		}
	}

	public Class6735(bool isSymbolicFont)
	{
		bool_0 = isSymbolicFont;
	}

	public void Add(Class6734 glyph)
	{
		hashtable_0[glyph.CharCode] = glyph;
	}

	public Class6734 method_0(char charCode)
	{
		Class6734 @class = this[charCode];
		if (@class != null)
		{
			return @class;
		}
		return method_2();
	}

	public Class6734 method_1(int glyphIndex)
	{
		foreach (Class6734 value in hashtable_0.Values)
		{
			if (value.OldGlyphIndex == glyphIndex)
			{
				return value;
			}
		}
		return method_2();
	}

	private Class6734 method_2()
	{
		Class6734 @class = class6734_0;
		if (@class != null)
		{
			return @class;
		}
		@class = this[' '];
		if (@class == null)
		{
			throw new InvalidOperationException("Cannot find a glyph for this character code.");
		}
		return @class;
	}
}
