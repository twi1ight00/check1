using System.Collections;
using System.Collections.Generic;

namespace ns84;

internal class Class4301 : IEnumerable, IEnumerable<Class4300>
{
	private Dictionary<string, Class4300> dictionary_0;

	public Class4300 this[string key] => dictionary_0[key];

	internal Class4301()
	{
		dictionary_0 = new Dictionary<string, Class4300>();
	}

	internal void Add(string key)
	{
		Add(key, 0);
	}

	internal void Add(string key, int value)
	{
		dictionary_0.Add(key, new Class4300(key, value));
	}

	public bool Contains(string key)
	{
		return dictionary_0.ContainsKey(key);
	}

	internal Class4300 method_0(string key)
	{
		if (!Contains(key))
		{
			Add(key);
		}
		return this[key];
	}

	internal virtual Class4301 Clone()
	{
		Class4301 @class = new Class4301();
		@class.dictionary_0 = new Dictionary<string, Class4300>();
		foreach (Class4300 value in dictionary_0.Values)
		{
			@class.dictionary_0.Add(value.Identifier, value.Clone());
		}
		return @class;
	}

	public IEnumerator<Class4300> GetEnumerator()
	{
		return dictionary_0.Values.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
