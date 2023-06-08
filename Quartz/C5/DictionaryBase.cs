using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace C5;

[Serializable]
internal abstract class DictionaryBase<K, V> : CollectionValueBase<KeyValuePair<K, V>>, IDictionary<K, V>, ICollectionValue<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, IShowable, IFormattable, ICloneable
{
	[Serializable]
	private class LiftedEnumerable<H> : IEnumerable<KeyValuePair<K, V>>, IEnumerable where H : K
	{
		private IEnumerable<H> keys;

		[ComVisible(true)]
		public LiftedEnumerable(IEnumerable<H> keys)
		{
			this.keys = keys;
		}

		[ComVisible(true)]
		public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
		{
			foreach (H key in keys)
			{
				yield return new KeyValuePair<K, V>((K)(object)key);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	[Serializable]
	internal class ValuesCollection : CollectionValueBase<V>, ICollectionValue<V>, IEnumerable<V>, IEnumerable, IShowable, IFormattable
	{
		private ICollection<KeyValuePair<K, V>> pairs;

		[ComVisible(true)]
		public override bool IsEmpty
		{
			[ComVisible(true)]
			get
			{
				return pairs.IsEmpty;
			}
		}

		[Tested]
		[ComVisible(true)]
		public override int Count
		{
			[Tested]
			[ComVisible(true)]
			get
			{
				return pairs.Count;
			}
		}

		[ComVisible(true)]
		public override Speed CountSpeed
		{
			[ComVisible(true)]
			get
			{
				return Speed.Constant;
			}
		}

		internal ValuesCollection(ICollection<KeyValuePair<K, V>> pairs)
		{
			this.pairs = pairs;
		}

		[ComVisible(true)]
		public override V Choose()
		{
			return pairs.Choose().Value;
		}

		[Tested]
		[ComVisible(true)]
		public override IEnumerator<V> GetEnumerator()
		{
			foreach (KeyValuePair<K, V> pair in pairs)
			{
				yield return pair.Value;
			}
		}
	}

	[Serializable]
	internal class KeysCollection : CollectionValueBase<K>, ICollectionValue<K>, IEnumerable<K>, IEnumerable, IShowable, IFormattable
	{
		private ICollection<KeyValuePair<K, V>> pairs;

		[ComVisible(true)]
		public override bool IsEmpty
		{
			[ComVisible(true)]
			get
			{
				return pairs.IsEmpty;
			}
		}

		[Tested]
		[ComVisible(true)]
		public override int Count
		{
			[Tested]
			[ComVisible(true)]
			get
			{
				return pairs.Count;
			}
		}

		[ComVisible(true)]
		public override Speed CountSpeed
		{
			[ComVisible(true)]
			get
			{
				return pairs.CountSpeed;
			}
		}

		internal KeysCollection(ICollection<KeyValuePair<K, V>> pairs)
		{
			this.pairs = pairs;
		}

		[ComVisible(true)]
		public override K Choose()
		{
			return pairs.Choose().Key;
		}

		[Tested]
		[ComVisible(true)]
		public override IEnumerator<K> GetEnumerator()
		{
			foreach (KeyValuePair<K, V> pair in pairs)
			{
				yield return pair.Key;
			}
		}
	}

	protected ICollection<KeyValuePair<K, V>> pairs;

	private IEqualityComparer<K> keyequalityComparer;

	private ProxyEventBlock<KeyValuePair<K, V>> eventBlock;

	[ComVisible(true)]
	public override EventTypeEnum ListenableEvents
	{
		[ComVisible(true)]
		get
		{
			return EventTypeEnum.Basic;
		}
	}

	[ComVisible(true)]
	public override EventTypeEnum ActiveEvents
	{
		[ComVisible(true)]
		get
		{
			return pairs.ActiveEvents;
		}
	}

	[ComVisible(true)]
	public virtual IEqualityComparer<K> EqualityComparer
	{
		[ComVisible(true)]
		get
		{
			return keyequalityComparer;
		}
	}

	[ComVisible(true)]
	public virtual Speed ContainsSpeed
	{
		[ComVisible(true)]
		get
		{
			return pairs.ContainsSpeed;
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual ICollectionValue<K> Keys
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return new KeysCollection(pairs);
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual ICollectionValue<V> Values
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return new ValuesCollection(pairs);
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

	[Tested]
	[ComVisible(true)]
	public virtual V this[K key]
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			KeyValuePair<K, V> item = new KeyValuePair<K, V>(key);
			if (pairs.Find(ref item))
			{
				return item.Value;
			}
			throw new NoSuchItemException("Key '" + key.ToString() + "' not present in Dictionary");
		}
		[Tested]
		[ComVisible(true)]
		set
		{
			pairs.UpdateOrAdd(new KeyValuePair<K, V>(key, value));
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool IsReadOnly
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return pairs.IsReadOnly;
		}
	}

	[ComVisible(true)]
	public override bool IsEmpty
	{
		[ComVisible(true)]
		get
		{
			return pairs.IsEmpty;
		}
	}

	[Tested]
	[ComVisible(true)]
	public override int Count
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return pairs.Count;
		}
	}

	[Tested]
	[ComVisible(true)]
	public override Speed CountSpeed
	{
		[Tested]
		[ComVisible(true)]
		get
		{
			return pairs.CountSpeed;
		}
	}

	[ComVisible(true)]
	public override event CollectionChangedHandler<KeyValuePair<K, V>> CollectionChanged
	{
		[ComVisible(true)]
		add
		{
			(eventBlock ?? (eventBlock = new ProxyEventBlock<KeyValuePair<K, V>>(this, pairs))).CollectionChanged += value;
		}
		[ComVisible(true)]
		remove
		{
			if (eventBlock != null)
			{
				eventBlock.CollectionChanged -= value;
			}
		}
	}

	[ComVisible(true)]
	public override event CollectionClearedHandler<KeyValuePair<K, V>> CollectionCleared
	{
		[ComVisible(true)]
		add
		{
			(eventBlock ?? (eventBlock = new ProxyEventBlock<KeyValuePair<K, V>>(this, pairs))).CollectionCleared += value;
		}
		[ComVisible(true)]
		remove
		{
			if (eventBlock != null)
			{
				eventBlock.CollectionCleared -= value;
			}
		}
	}

	[ComVisible(true)]
	public override event ItemsAddedHandler<KeyValuePair<K, V>> ItemsAdded
	{
		[ComVisible(true)]
		add
		{
			(eventBlock ?? (eventBlock = new ProxyEventBlock<KeyValuePair<K, V>>(this, pairs))).ItemsAdded += value;
		}
		[ComVisible(true)]
		remove
		{
			if (eventBlock != null)
			{
				eventBlock.ItemsAdded -= value;
			}
		}
	}

	[ComVisible(true)]
	public override event ItemsRemovedHandler<KeyValuePair<K, V>> ItemsRemoved
	{
		[ComVisible(true)]
		add
		{
			(eventBlock ?? (eventBlock = new ProxyEventBlock<KeyValuePair<K, V>>(this, pairs))).ItemsRemoved += value;
		}
		[ComVisible(true)]
		remove
		{
			if (eventBlock != null)
			{
				eventBlock.ItemsRemoved -= value;
			}
		}
	}

	protected DictionaryBase(IEqualityComparer<K> keyequalityComparer)
	{
		if (keyequalityComparer == null)
		{
			throw new NullReferenceException("Key equality comparer cannot be null");
		}
		this.keyequalityComparer = keyequalityComparer;
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Add(K key, V value)
	{
		KeyValuePair<K, V> item = new KeyValuePair<K, V>(key, value);
		if (!pairs.Add(item))
		{
			throw new DuplicateNotAllowedException(string.Concat("Key being added: '", key, "'"));
		}
	}

	[ComVisible(true)]
	public virtual void AddAll<L, W>(IEnumerable<KeyValuePair<L, W>> entries) where L : K where W : V
	{
		foreach (KeyValuePair<L, W> entry in entries)
		{
			KeyValuePair<K, V> item = new KeyValuePair<K, V>((K)(object)entry.Key, (V)(object)entry.Value);
			if (!pairs.Add(item))
			{
				throw new DuplicateNotAllowedException(string.Concat("Key being added: '", entry.Key, "'"));
			}
		}
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Remove(K key)
	{
		KeyValuePair<K, V> item = new KeyValuePair<K, V>(key);
		return pairs.Remove(item);
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Remove(K key, out V value)
	{
		KeyValuePair<K, V> removeditem = new KeyValuePair<K, V>(key);
		if (pairs.Remove(removeditem, out removeditem))
		{
			value = removeditem.Value;
			return true;
		}
		value = default(V);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual void Clear()
	{
		pairs.Clear();
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Contains(K key)
	{
		KeyValuePair<K, V> item = new KeyValuePair<K, V>(key);
		return pairs.Contains(item);
	}

	[ComVisible(true)]
	public virtual bool ContainsAll<H>(IEnumerable<H> keys) where H : K
	{
		return pairs.ContainsAll(new LiftedEnumerable<H>(keys));
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Find(K key, out V value)
	{
		return Find(ref key, out value);
	}

	[ComVisible(true)]
	public virtual bool Find(ref K key, out V value)
	{
		KeyValuePair<K, V> item = new KeyValuePair<K, V>(key);
		if (pairs.Find(ref item))
		{
			key = item.Key;
			value = item.Value;
			return true;
		}
		value = default(V);
		return false;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Update(K key, V value)
	{
		KeyValuePair<K, V> item = new KeyValuePair<K, V>(key, value);
		return pairs.Update(item);
	}

	[ComVisible(true)]
	public virtual bool Update(K key, V value, out V oldvalue)
	{
		KeyValuePair<K, V> olditem = new KeyValuePair<K, V>(key, value);
		bool result = pairs.Update(olditem, out olditem);
		oldvalue = olditem.Value;
		return result;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool FindOrAdd(K key, ref V value)
	{
		KeyValuePair<K, V> item = new KeyValuePair<K, V>(key, value);
		if (!pairs.FindOrAdd(ref item))
		{
			return false;
		}
		value = item.Value;
		return true;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool UpdateOrAdd(K key, V value)
	{
		return pairs.UpdateOrAdd(new KeyValuePair<K, V>(key, value));
	}

	[ComVisible(true)]
	public virtual bool UpdateOrAdd(K key, V value, out V oldvalue)
	{
		KeyValuePair<K, V> olditem = new KeyValuePair<K, V>(key, value);
		bool result = pairs.UpdateOrAdd(olditem, out olditem);
		oldvalue = olditem.Value;
		return result;
	}

	[Tested]
	[ComVisible(true)]
	public virtual bool Check()
	{
		return pairs.Check();
	}

	[ComVisible(true)]
	public override KeyValuePair<K, V> Choose()
	{
		return pairs.Choose();
	}

	[Tested]
	[ComVisible(true)]
	public override IEnumerator<KeyValuePair<K, V>> GetEnumerator()
	{
		return pairs.GetEnumerator();
	}

	[ComVisible(true)]
	public override bool Show(StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
	{
		return Showing.ShowDictionary(this, stringbuilder, ref rest, formatProvider);
	}

	[ComVisible(true)]
	public abstract object Clone();
}
