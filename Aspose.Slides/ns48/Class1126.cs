using System;
using System.Collections;
using System.Collections.Generic;

namespace ns48;

internal class Class1126<TKey, TValue> : IEnumerable, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>
{
	private readonly IDictionary<TKey, TValue> idictionary_0;

	public ICollection<TKey> Keys => idictionary_0.Keys;

	public ICollection<TValue> Values => idictionary_0.Values;

	public TValue this[TKey key]
	{
		get
		{
			return idictionary_0[key];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public int Count => idictionary_0.Count;

	public bool IsReadOnly => true;

	public Class1126(IDictionary<TKey, TValue> sourceDictionary)
	{
		if (sourceDictionary == null)
		{
			throw new ArgumentNullException();
		}
		idictionary_0 = sourceDictionary;
	}

	void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
	{
		throw new NotSupportedException();
	}

	public bool ContainsKey(TKey key)
	{
		return idictionary_0.ContainsKey(key);
	}

	bool IDictionary<TKey, TValue>.Remove(TKey key)
	{
		throw new NotSupportedException();
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		return idictionary_0.TryGetValue(key, out value);
	}

	void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
	{
		throw new NotSupportedException();
	}

	void ICollection<KeyValuePair<TKey, TValue>>.Clear()
	{
		throw new NotSupportedException();
	}

	public bool Contains(KeyValuePair<TKey, TValue> item)
	{
		return idictionary_0.Contains(item);
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		idictionary_0.CopyTo(array, arrayIndex);
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
	{
		throw new NotSupportedException();
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return idictionary_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)idictionary_0).GetEnumerator();
	}
}
