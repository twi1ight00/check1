using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class GuardedDictionary<K, V> : GuardedCollectionValue<KeyValuePair<K, V>>, IDictionary<K, V>, ICollectionValue<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, IShowable, IFormattable, ICloneable
{
	private IDictionary<K, V> dict;

	[ComVisible(true)]
	public IEqualityComparer<K> EqualityComparer
	{
		[ComVisible(true)]
		get
		{
			return dict.EqualityComparer;
		}
	}

	[ComVisible(true)]
	public V this[K key]
	{
		[ComVisible(true)]
		get
		{
			return dict[key];
		}
		[ComVisible(true)]
		set
		{
			throw new ReadOnlyCollectionException();
		}
	}

	[ComVisible(true)]
	public bool IsReadOnly
	{
		[ComVisible(true)]
		get
		{
			return true;
		}
	}

	[ComVisible(true)]
	public ICollectionValue<K> Keys
	{
		[ComVisible(true)]
		get
		{
			return dict.Keys;
		}
	}

	[ComVisible(true)]
	public ICollectionValue<V> Values
	{
		[ComVisible(true)]
		get
		{
			return dict.Values;
		}
	}

	[ComVisible(true)]
	public virtual Fun<K, V> Fun
	{
		[ComVisible(true)]
		get
		{
			return (K k) => this[k];
		}
	}

	[ComVisible(true)]
	public Speed ContainsSpeed
	{
		[ComVisible(true)]
		get
		{
			return dict.ContainsSpeed;
		}
	}

	[ComVisible(true)]
	public GuardedDictionary(IDictionary<K, V> dict)
		: base((ICollectionValue<KeyValuePair<K, V>>)dict)
	{
		this.dict = dict;
	}

	[ComVisible(true)]
	public void Add(K key, V val)
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public void AddAll<L, W>(IEnumerable<KeyValuePair<L, W>> items) where L : K where W : V
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public bool Remove(K key)
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public bool Remove(K key, out V val)
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public void Clear()
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public bool Contains(K key)
	{
		return dict.Contains(key);
	}

	[ComVisible(true)]
	public bool ContainsAll<H>(IEnumerable<H> keys) where H : K
	{
		return dict.ContainsAll(keys);
	}

	[ComVisible(true)]
	public bool Find(K key, out V val)
	{
		return dict.Find(key, out val);
	}

	[ComVisible(true)]
	public bool Find(ref K key, out V val)
	{
		return dict.Find(ref key, out val);
	}

	[ComVisible(true)]
	public bool Update(K key, V val)
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public bool Update(K key, V val, out V oldval)
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public bool FindOrAdd(K key, ref V val)
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public bool UpdateOrAdd(K key, V val)
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public bool UpdateOrAdd(K key, V val, out V oldval)
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public bool Check()
	{
		return dict.Check();
	}

	[ComVisible(true)]
	public virtual object Clone()
	{
		return new GuardedDictionary<K, V>((IDictionary<K, V>)dict.Clone());
	}
}
