using System.Collections.Generic;

namespace ns72;

internal class Class3546<TKey, T>
{
	private Dictionary<TKey, T> dictionary_0;

	private T gparam_0;

	public int Count => dictionary_0.Count;

	public Class3546()
		: this(default(T))
	{
	}

	public Class3546(T @default)
	{
		dictionary_0 = new Dictionary<TKey, T>();
		gparam_0 = @default;
	}

	public void method_0(TKey key, T value)
	{
		if (dictionary_0.ContainsKey(key))
		{
			dictionary_0[key] = value;
		}
		else
		{
			dictionary_0.Add(key, value);
		}
	}

	public T method_1(TKey key)
	{
		if (dictionary_0.ContainsKey(key))
		{
			return dictionary_0[key];
		}
		return gparam_0;
	}

	public void Remove(TKey key)
	{
		dictionary_0.Remove(key);
	}

	public bool ContainsKey(TKey key)
	{
		return dictionary_0.ContainsKey(key);
	}
}
