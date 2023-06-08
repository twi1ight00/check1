using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace ns47;

internal class Class1464 : Hashtable
{
	private Class1463 class1463_0;

	public Class1463 this[char char_0]
	{
		get
		{
			return (Class1463)base[char_0];
		}
		set
		{
			base[char_0] = value;
		}
	}

	[SpecialName]
	public void method_0(Class1463 class1463_1)
	{
		class1463_0 = class1463_1;
	}

	public void Add(Class1463 class1463_1)
	{
		base[class1463_1.method_0()] = class1463_1;
	}

	public Class1463 method_1(char char_0)
	{
		Class1463 @class = this[char_0];
		if (@class == null)
		{
			@class = class1463_0;
		}
		if (@class == null)
		{
			throw new InvalidOperationException("Cannot find a glyph for this character code.");
		}
		return @class;
	}
}
