using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface IDictionary<K, V> : ICollectionValue<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, IShowable, IFormattable, ICloneable
{
	[ComVisible(true)]
	IEqualityComparer<K> EqualityComparer
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	V this[K key]
	{
		[ComVisible(true)]
		get;
		[ComVisible(true)]
		set;
	}

	[ComVisible(true)]
	bool IsReadOnly
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	ICollectionValue<K> Keys
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	ICollectionValue<V> Values
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	Fun<K, V> Fun
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	Speed ContainsSpeed
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	void Add(K key, V val);

	[ComVisible(true)]
	void AddAll<U, W>(IEnumerable<KeyValuePair<U, W>> entries) where U : K where W : V;

	[ComVisible(true)]
	bool ContainsAll<H>(IEnumerable<H> items) where H : K;

	[ComVisible(true)]
	bool Remove(K key);

	[ComVisible(true)]
	bool Remove(K key, out V val);

	[ComVisible(true)]
	void Clear();

	[ComVisible(true)]
	bool Contains(K key);

	[ComVisible(true)]
	bool Find(K key, out V val);

	[ComVisible(true)]
	bool Find(ref K key, out V val);

	[ComVisible(true)]
	bool Update(K key, V val);

	[ComVisible(true)]
	bool Update(K key, V val, out V oldval);

	[ComVisible(true)]
	bool FindOrAdd(K key, ref V val);

	[ComVisible(true)]
	bool UpdateOrAdd(K key, V val);

	[ComVisible(true)]
	bool UpdateOrAdd(K key, V val, out V oldval);

	[ComVisible(true)]
	bool Check();
}
