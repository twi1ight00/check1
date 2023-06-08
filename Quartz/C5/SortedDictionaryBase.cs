using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace C5;

[Serializable]
internal abstract class SortedDictionaryBase<K, V> : DictionaryBase<K, V>, ISortedDictionary<K, V>, IDictionary<K, V>, ICollectionValue<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, IShowable, IFormattable, ICloneable
{
	[Serializable]
	private class KeyValuePairComparable : IComparable<KeyValuePair<K, V>>
	{
		private IComparable<K> cutter;

		internal KeyValuePairComparable(IComparable<K> cutter)
		{
			this.cutter = cutter;
		}

		[ComVisible(true)]
		public int CompareTo(KeyValuePair<K, V> other)
		{
			return cutter.CompareTo(other.Key);
		}

		[ComVisible(true)]
		public bool Equals(KeyValuePair<K, V> other)
		{
			return cutter.Equals(other.Key);
		}
	}

	[Serializable]
	private class ProjectedDirectedEnumerable : MappedDirectedEnumerable<KeyValuePair<K, V>, K>
	{
		[ComVisible(true)]
		public ProjectedDirectedEnumerable(IDirectedEnumerable<KeyValuePair<K, V>> directedpairs)
			: base(directedpairs)
		{
		}

		[ComVisible(true)]
		public override K Map(KeyValuePair<K, V> pair)
		{
			return pair.Key;
		}
	}

	[Serializable]
	private class ProjectedDirectedCollectionValue : MappedDirectedCollectionValue<KeyValuePair<K, V>, K>
	{
		[ComVisible(true)]
		public ProjectedDirectedCollectionValue(IDirectedCollectionValue<KeyValuePair<K, V>> directedpairs)
			: base(directedpairs)
		{
		}

		[ComVisible(true)]
		public override K Map(KeyValuePair<K, V> pair)
		{
			return pair.Key;
		}
	}

	[Serializable]
	private class SortedKeysCollection : SequencedBase<K>, ISorted<K>, ISequenced<K>, ICollection<K>, IExtensible<K>, ICloneable, System.Collections.Generic.ICollection<K>, IDirectedCollectionValue<K>, ICollectionValue<K>, IShowable, IFormattable, IDirectedEnumerable<K>, IEnumerable<K>, IEnumerable
	{
		private ISortedDictionary<K, V> sorteddict;

		private ISorted<KeyValuePair<K, V>> sortedpairs;

		private IComparer<K> comparer;

		[ComVisible(true)]
		public override bool IsEmpty
		{
			[ComVisible(true)]
			get
			{
				return sorteddict.IsEmpty;
			}
		}

		[ComVisible(true)]
		public override int Count
		{
			[Tested]
			[ComVisible(true)]
			get
			{
				return sorteddict.Count;
			}
		}

		[ComVisible(true)]
		public override Speed CountSpeed
		{
			[ComVisible(true)]
			get
			{
				return sorteddict.CountSpeed;
			}
		}

		[ComVisible(true)]
		public IComparer<K> Comparer
		{
			[ComVisible(true)]
			get
			{
				return comparer;
			}
		}

		[ComVisible(true)]
		public Speed ContainsSpeed
		{
			[ComVisible(true)]
			get
			{
				return sorteddict.ContainsSpeed;
			}
		}

		[ComVisible(true)]
		public override bool IsReadOnly
		{
			[ComVisible(true)]
			get
			{
				return true;
			}
		}

		[ComVisible(true)]
		public bool AllowsDuplicates
		{
			[ComVisible(true)]
			get
			{
				return false;
			}
		}

		[ComVisible(true)]
		public bool DuplicatesByCounting
		{
			[ComVisible(true)]
			get
			{
				return true;
			}
		}

		internal SortedKeysCollection(ISortedDictionary<K, V> sorteddict, ISorted<KeyValuePair<K, V>> sortedpairs, IComparer<K> comparer, IEqualityComparer<K> itemequalityComparer)
			: base(itemequalityComparer)
		{
			this.sorteddict = sorteddict;
			this.sortedpairs = sortedpairs;
			this.comparer = comparer;
		}

		[ComVisible(true)]
		public override K Choose()
		{
			return sorteddict.Choose().Key;
		}

		[ComVisible(true)]
		public override IEnumerator<K> GetEnumerator()
		{
			foreach (KeyValuePair<K, V> item in sorteddict)
			{
				yield return item.Key;
			}
		}

		[ComVisible(true)]
		public K FindMin()
		{
			return sorteddict.FindMin().Key;
		}

		[ComVisible(true)]
		public K DeleteMin()
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public K FindMax()
		{
			return sorteddict.FindMax().Key;
		}

		[ComVisible(true)]
		public K DeleteMax()
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public bool TryPredecessor(K item, out K res)
		{
			KeyValuePair<K, V> res2;
			bool result = sorteddict.TryPredecessor(item, out res2);
			res = res2.Key;
			return result;
		}

		[ComVisible(true)]
		public bool TrySuccessor(K item, out K res)
		{
			KeyValuePair<K, V> res2;
			bool result = sorteddict.TrySuccessor(item, out res2);
			res = res2.Key;
			return result;
		}

		[ComVisible(true)]
		public bool TryWeakPredecessor(K item, out K res)
		{
			KeyValuePair<K, V> res2;
			bool result = sorteddict.TryWeakPredecessor(item, out res2);
			res = res2.Key;
			return result;
		}

		[ComVisible(true)]
		public bool TryWeakSuccessor(K item, out K res)
		{
			KeyValuePair<K, V> res2;
			bool result = sorteddict.TryWeakSuccessor(item, out res2);
			res = res2.Key;
			return result;
		}

		[ComVisible(true)]
		public K Predecessor(K item)
		{
			return sorteddict.Predecessor(item).Key;
		}

		[ComVisible(true)]
		public K Successor(K item)
		{
			return sorteddict.Successor(item).Key;
		}

		[ComVisible(true)]
		public K WeakPredecessor(K item)
		{
			return sorteddict.WeakPredecessor(item).Key;
		}

		[ComVisible(true)]
		public K WeakSuccessor(K item)
		{
			return sorteddict.WeakSuccessor(item).Key;
		}

		[ComVisible(true)]
		public bool Cut(IComparable<K> c, out K low, out bool lowIsValid, out K high, out bool highIsValid)
		{
			KeyValuePair<K, V> lowEntry;
			KeyValuePair<K, V> highEntry;
			bool result = sorteddict.Cut(c, out lowEntry, out lowIsValid, out highEntry, out highIsValid);
			low = lowEntry.Key;
			high = highEntry.Key;
			return result;
		}

		[ComVisible(true)]
		public IDirectedEnumerable<K> RangeFrom(K bot)
		{
			return new ProjectedDirectedEnumerable(sorteddict.RangeFrom(bot));
		}

		[ComVisible(true)]
		public IDirectedEnumerable<K> RangeFromTo(K bot, K top)
		{
			return new ProjectedDirectedEnumerable(sorteddict.RangeFromTo(bot, top));
		}

		[ComVisible(true)]
		public IDirectedEnumerable<K> RangeTo(K top)
		{
			return new ProjectedDirectedEnumerable(sorteddict.RangeTo(top));
		}

		[ComVisible(true)]
		public IDirectedCollectionValue<K> RangeAll()
		{
			return new ProjectedDirectedCollectionValue(sorteddict.RangeAll());
		}

		[ComVisible(true)]
		public void AddSorted<U>(IEnumerable<U> items) where U : K
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public void RemoveRangeFrom(K low)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public void RemoveRangeFromTo(K low, K hi)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public void RemoveRangeTo(K hi)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public bool Contains(K key)
		{
			return sorteddict.Contains(key);
		}

		[ComVisible(true)]
		public int ContainsCount(K item)
		{
			if (!sorteddict.Contains(item))
			{
				return 0;
			}
			return 1;
		}

		[ComVisible(true)]
		public virtual ICollectionValue<K> UniqueItems()
		{
			return this;
		}

		[ComVisible(true)]
		public virtual ICollectionValue<KeyValuePair<K, int>> ItemMultiplicities()
		{
			return new MultiplicityOne<K>(this);
		}

		[ComVisible(true)]
		public bool ContainsAll<U>(IEnumerable<U> items) where U : K
		{
			foreach (U item in items)
			{
				K key = (K)(object)item;
				if (!sorteddict.Contains(key))
				{
					return false;
				}
			}
			return true;
		}

		[ComVisible(true)]
		public bool Find(ref K item)
		{
			KeyValuePair<K, V> item2 = new KeyValuePair<K, V>(item);
			bool result = sortedpairs.Find(ref item2);
			item = item2.Key;
			return result;
		}

		[ComVisible(true)]
		public bool FindOrAdd(ref K item)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public bool Update(K item)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public bool Update(K item, out K olditem)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public bool UpdateOrAdd(K item)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public bool UpdateOrAdd(K item, out K olditem)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public bool Remove(K item)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public bool Remove(K item, out K removeditem)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public void RemoveAllCopies(K item)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public void RemoveAll<U>(IEnumerable<U> items) where U : K
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public void Clear()
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public void RetainAll<U>(IEnumerable<U> items) where U : K
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public bool Add(K item)
		{
			throw new ReadOnlyCollectionException();
		}

		void System.Collections.Generic.ICollection<K>.Add(K item)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public void AddAll(IEnumerable<K> items)
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public void AddAll<U>(IEnumerable<U> items) where U : K
		{
			throw new ReadOnlyCollectionException();
		}

		[ComVisible(true)]
		public bool Check()
		{
			return sorteddict.Check();
		}

		[ComVisible(true)]
		public override IDirectedCollectionValue<K> Backwards()
		{
			return RangeAll().Backwards();
		}

		IDirectedEnumerable<K> IDirectedEnumerable<K>.Backwards()
		{
			return Backwards();
		}

		[ComVisible(true)]
		public virtual object Clone()
		{
			SortedArrayDictionary<K, V> sortedArrayDictionary = new SortedArrayDictionary<K, V>(sortedpairs.Count, comparer, EqualityComparer);
			SortedArray<KeyValuePair<K, V>> sortedArray = (SortedArray<KeyValuePair<K, V>>)sortedArrayDictionary.sortedpairs;
			foreach (K key in sorteddict.Keys)
			{
				sortedArray.Add(new KeyValuePair<K, V>(key, default(V)));
			}
			return new SortedKeysCollection(sortedArrayDictionary, sortedArray, comparer, EqualityComparer);
		}
	}

	protected ISorted<KeyValuePair<K, V>> sortedpairs;

	private IComparer<K> keycomparer;

	[ComVisible(true)]
	public IComparer<K> Comparer
	{
		[ComVisible(true)]
		get
		{
			return keycomparer;
		}
	}

	[ComVisible(true)]
	public new ISorted<K> Keys
	{
		[ComVisible(true)]
		get
		{
			return new SortedKeysCollection(this, sortedpairs, keycomparer, EqualityComparer);
		}
	}

	protected SortedDictionaryBase(IComparer<K> keycomparer, IEqualityComparer<K> keyequalityComparer)
		: base(keyequalityComparer)
	{
		this.keycomparer = keycomparer;
	}

	[Tested]
	[ComVisible(true)]
	public bool TryPredecessor(K key, out KeyValuePair<K, V> res)
	{
		return sortedpairs.TryPredecessor(new KeyValuePair<K, V>(key), out res);
	}

	[Tested]
	[ComVisible(true)]
	public bool TrySuccessor(K key, out KeyValuePair<K, V> res)
	{
		return sortedpairs.TrySuccessor(new KeyValuePair<K, V>(key), out res);
	}

	[Tested]
	[ComVisible(true)]
	public bool TryWeakPredecessor(K key, out KeyValuePair<K, V> res)
	{
		return sortedpairs.TryWeakPredecessor(new KeyValuePair<K, V>(key), out res);
	}

	[Tested]
	[ComVisible(true)]
	public bool TryWeakSuccessor(K key, out KeyValuePair<K, V> res)
	{
		return sortedpairs.TryWeakSuccessor(new KeyValuePair<K, V>(key), out res);
	}

	[Tested]
	[ComVisible(true)]
	public KeyValuePair<K, V> Predecessor(K key)
	{
		return sortedpairs.Predecessor(new KeyValuePair<K, V>(key));
	}

	[Tested]
	[ComVisible(true)]
	public KeyValuePair<K, V> Successor(K key)
	{
		return sortedpairs.Successor(new KeyValuePair<K, V>(key));
	}

	[Tested]
	[ComVisible(true)]
	public KeyValuePair<K, V> WeakPredecessor(K key)
	{
		return sortedpairs.WeakPredecessor(new KeyValuePair<K, V>(key));
	}

	[Tested]
	[ComVisible(true)]
	public KeyValuePair<K, V> WeakSuccessor(K key)
	{
		return sortedpairs.WeakSuccessor(new KeyValuePair<K, V>(key));
	}

	[ComVisible(true)]
	public KeyValuePair<K, V> FindMin()
	{
		return sortedpairs.FindMin();
	}

	[ComVisible(true)]
	public KeyValuePair<K, V> DeleteMin()
	{
		return sortedpairs.DeleteMin();
	}

	[ComVisible(true)]
	public KeyValuePair<K, V> FindMax()
	{
		return sortedpairs.FindMax();
	}

	[ComVisible(true)]
	public KeyValuePair<K, V> DeleteMax()
	{
		return sortedpairs.DeleteMax();
	}

	[ComVisible(true)]
	public bool Cut(IComparable<K> cutter, out KeyValuePair<K, V> lowEntry, out bool lowIsValid, out KeyValuePair<K, V> highEntry, out bool highIsValid)
	{
		return sortedpairs.Cut(new KeyValuePairComparable(cutter), out lowEntry, out lowIsValid, out highEntry, out highIsValid);
	}

	[ComVisible(true)]
	public IDirectedEnumerable<KeyValuePair<K, V>> RangeFrom(K bot)
	{
		return sortedpairs.RangeFrom(new KeyValuePair<K, V>(bot));
	}

	[ComVisible(true)]
	public IDirectedEnumerable<KeyValuePair<K, V>> RangeFromTo(K bot, K top)
	{
		return sortedpairs.RangeFromTo(new KeyValuePair<K, V>(bot), new KeyValuePair<K, V>(top));
	}

	[ComVisible(true)]
	public IDirectedEnumerable<KeyValuePair<K, V>> RangeTo(K top)
	{
		return sortedpairs.RangeTo(new KeyValuePair<K, V>(top));
	}

	[ComVisible(true)]
	public IDirectedCollectionValue<KeyValuePair<K, V>> RangeAll()
	{
		return sortedpairs.RangeAll();
	}

	[ComVisible(true)]
	public void AddSorted(IEnumerable<KeyValuePair<K, V>> items)
	{
		sortedpairs.AddSorted(items);
	}

	[ComVisible(true)]
	public void RemoveRangeFrom(K lowKey)
	{
		sortedpairs.RemoveRangeFrom(new KeyValuePair<K, V>(lowKey));
	}

	[ComVisible(true)]
	public void RemoveRangeFromTo(K lowKey, K highKey)
	{
		sortedpairs.RemoveRangeFromTo(new KeyValuePair<K, V>(lowKey), new KeyValuePair<K, V>(highKey));
	}

	[ComVisible(true)]
	public void RemoveRangeTo(K highKey)
	{
		sortedpairs.RemoveRangeTo(new KeyValuePair<K, V>(highKey));
	}

	[ComVisible(true)]
	public override bool Show(StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
	{
		return Showing.ShowDictionary(this, stringbuilder, ref rest, formatProvider);
	}
}
