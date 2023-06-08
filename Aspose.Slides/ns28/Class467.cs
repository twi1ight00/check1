using System.Collections.Generic;

namespace ns28;

internal class Class467
{
	private int int_0;

	internal string[] string_0;

	private Dictionary<string, int> dictionary_0;

	public int this[string name] => dictionary_0[name];

	public string this[int index] => string_0[index - int_0];

	public int LowerBound => int_0;

	public int UpperBound => int_0 + string_0.Length - 1;

	public Class467(params string[] names)
		: this(0, names)
	{
	}

	public Class467(int baseIndex, params string[] names)
	{
		int_0 = baseIndex;
		string_0 = names;
		dictionary_0 = new Dictionary<string, int>(names.Length);
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
