using System;
using System.Collections.Generic;
using ns119;
using ns99;

namespace ns67;

internal class Class3388
{
	private readonly Dictionary<string, Class4490> dictionary_0;

	public Class3388(Interface125 source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		dictionary_0 = new Dictionary<string, Class4490>();
		Class4490[] array = source.imethod_0();
		Class4490[] array2 = array;
		foreach (Class4490 @class in array2)
		{
			if (!dictionary_0.ContainsKey(@class.FontName))
			{
				dictionary_0.Add(@class.FontName, @class);
			}
		}
	}

	internal Interface113 method_0(string fontName)
	{
		if (dictionary_0.ContainsKey(fontName))
		{
			return Class4408.smethod_0(dictionary_0[fontName]);
		}
		return null;
	}
}
