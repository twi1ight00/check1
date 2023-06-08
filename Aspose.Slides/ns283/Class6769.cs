using System;
using System.Collections;
using System.Collections.Generic;
using ns287;
using ns305;
using ns73;
using ns76;

namespace ns283;

internal class Class6769 : IEnumerable, IEnumerable<Interface75>, Interface95
{
	private List<Interface75> list_0;

	private static readonly string[] string_0 = new string[2] { "STYLE", "LINK" };

	public long Length => list_0.Count;

	public Interface76 this[int index]
	{
		get
		{
			return (Interface76)list_0[index];
		}
		set
		{
			if (value == null)
			{
				throw new NullReferenceException("StyleSheet cannot be null.");
			}
			list_0[index] = value;
		}
	}

	public Class6769(Class7046 document)
	{
		Interface69 engine = ((Interface89)document).Engine;
		Class7075 @class = document.method_32(string_0);
		list_0 = new List<Interface75>();
		IEnumerator<Class6976> enumerator = @class.GetEnumerator();
		while (enumerator.MoveNext())
		{
			switch (((Class6981)enumerator.Current).TagName)
			{
			case "LINK":
			{
				Class7022 class2 = (Class7022)enumerator.Current;
				if (class2.Rel == null || !class2.Rel.Equals("stylesheet", StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				string href = class2.Href;
				if (!string.IsNullOrEmpty(href))
				{
					Interface76 interface2 = engine.imethod_5(href, class2);
					if (interface2 != null)
					{
						list_0.Add(interface2);
					}
				}
				break;
			}
			case "STYLE":
			{
				Interface92 @interface = (Interface92)enumerator.Current;
				if (@interface.CSSStyleSheet != null)
				{
					list_0.Add(@interface.CSSStyleSheet);
				}
				break;
			}
			}
		}
	}

	public IEnumerator<Interface75> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(Interface76 styleSheet)
	{
		if (styleSheet == null)
		{
			throw new NullReferenceException("StyleSheet cannot be null.");
		}
		list_0.Add(styleSheet);
	}
}
