using System;
using System.Collections.Generic;

namespace ns33;

internal class Class1151
{
	private int int_0;

	internal string[] string_0;

	private Dictionary<string, int> dictionary_0;

	public int this[string name] => dictionary_0[name];

	public string this[int index] => string_0[index - int_0];

	public int LowerBound => int_0;

	public int UpperBound => int_0 + string_0.Length - 1;

	public Class1151(params string[] names)
		: this(0, names)
	{
	}

	public Class1151(int baseIndex, params string[] names)
		: this(baseIndex, caseInsensitive: false, names)
	{
	}

	public Class1151(int baseIndex, bool caseInsensitive, params string[] names)
	{
		int_0 = baseIndex;
		string_0 = names;
		dictionary_0 = (caseInsensitive ? new Dictionary<string, int>(names.Length, StringComparer.InvariantCultureIgnoreCase) : new Dictionary<string, int>(names.Length));
		for (int i = 0; i < names.Length; i++)
		{
			dictionary_0.Add(names[i], i + baseIndex);
		}
	}

	public bool Contains(string name)
	{
		return dictionary_0.ContainsKey(name);
	}
}
