using System;
using System.Collections;
using System.Drawing;

namespace ns47;

internal class Class1461
{
	private readonly string string_0;

	private readonly Hashtable hashtable_0;

	internal Class1461(string string_1)
	{
		string_0 = string_1;
		hashtable_0 = new Hashtable();
	}

	internal void Add(Class1460 class1460_0)
	{
		if (class1460_0 == null)
		{
			throw new NullReferenceException("font");
		}
		_ = class1460_0.method_0() != string_0;
		hashtable_0[class1460_0.Style] = class1460_0;
	}

	internal Class1460 method_0(FontStyle fontStyle_0, bool bool_0)
	{
		Class1460 @class = (Class1460)hashtable_0[fontStyle_0];
		if (@class != null)
		{
			return @class;
		}
		if (bool_0)
		{
			return null;
		}
		FontStyle fontStyle = fontStyle_0 & ~FontStyle.Underline;
		@class = (Class1460)hashtable_0[fontStyle];
		if (@class != null)
		{
			return @class;
		}
		fontStyle = fontStyle_0 & ~FontStyle.Strikeout;
		@class = (Class1460)hashtable_0[fontStyle];
		if (@class != null)
		{
			return @class;
		}
		fontStyle = fontStyle_0 & ~FontStyle.Italic;
		@class = (Class1460)hashtable_0[fontStyle];
		if (@class != null)
		{
			return @class;
		}
		fontStyle = fontStyle_0 & ~FontStyle.Bold;
		@class = (Class1460)hashtable_0[fontStyle];
		if (@class != null)
		{
			return @class;
		}
		fontStyle = FontStyle.Bold;
		@class = (Class1460)hashtable_0[FontStyle.Bold];
		if (@class != null)
		{
			return @class;
		}
		fontStyle = FontStyle.Italic;
		@class = (Class1460)hashtable_0[FontStyle.Italic];
		if (@class != null)
		{
			return @class;
		}
		return (Class1460)hashtable_0[FontStyle.Regular];
	}
}
