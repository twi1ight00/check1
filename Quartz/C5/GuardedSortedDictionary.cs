using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class GuardedSortedDictionary<K, V> : GuardedDictionary<K, V>, ISortedDictionary<K, V>, IDictionary<K, V>, ICollectionValue<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, IShowable, IFormattable, ICloneable
{
	private ISortedDictionary<K, V> sorteddict;

	[ComVisible(true)]
	public IComparer<K> Comparer
	{
		[ComVisible(true)]
		get
		{
			return sorteddict.Comparer;
		}
	}

	[ComVisible(true)]
	public new ISorted<K> Keys
	{
		[ComVisible(true)]
		get
		{
			return null;
		}
	}

	[ComVisible(true)]
	public GuardedSortedDictionary(ISortedDictionary<K, V> sorteddict)
		: base((IDictionary<K, V>)sorteddict)
	{
		this.sorteddict = sorteddict;
	}

	[ComVisible(true)]
	public bool TryPredecessor(K key, out KeyValuePair<K, V> res)
	{
		return sorteddict.TryPredecessor(key, out res);
	}

	[ComVisible(true)]
	public bool TrySuccessor(K key, out KeyValuePair<K, V> res)
	{
		return sorteddict.TrySuccessor(key, out res);
	}

	[ComVisible(true)]
	public bool TryWeakPredecessor(K key, out KeyValuePair<K, V> res)
	{
		return sorteddict.TryWeakPredecessor(key, out res);
	}

	[ComVisible(true)]
	public bool TryWeakSuccessor(K key, out KeyValuePair<K, V> res)
	{
		return sorteddict.TryWeakSuccessor(key, out res);
	}

	[ComVisible(true)]
	public KeyValuePair<K, V> Predecessor(K key)
	{
		return sorteddict.Predecessor(key);
	}

	[ComVisible(true)]
	public KeyValuePair<K, V> Successor(K key)
	{
		return sorteddict.Successor(key);
	}

	[ComVisible(true)]
	public KeyValuePair<K, V> WeakPredecessor(K key)
	{
		return sorteddict.WeakPredecessor(key);
	}

	[ComVisible(true)]
	public KeyValuePair<K, V> WeakSuccessor(K key)
	{
		return sorteddict.WeakSuccessor(key);
	}

	[ComVisible(true)]
	public KeyValuePair<K, V> FindMin()
	{
		return sorteddict.FindMin();
	}

	[ComVisible(true)]
	public KeyValuePair<K, V> DeleteMin()
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public KeyValuePair<K, V> FindMax()
	{
		return sorteddict.FindMax();
	}

	[ComVisible(true)]
	public KeyValuePair<K, V> DeleteMax()
	{
		throw new ReadOnlyCollectionException();
	}

	[ComVisible(true)]
	public bool Cut(IComparable<K> c, out KeyValuePair<K, V> lowEntry, out bool lowIsValid, out KeyValuePair<K, V> highEntry, out bool highIsValid)
	{
		return sorteddict.Cut(c, out lowEntry, out lowIsValid, out highEntry, out highIsValid);
	}

	[ComVisible(true)]
	public IDirectedEnumerable<KeyValuePair<K, V>> RangeFrom(K bot)
	{
		return new GuardedDirectedEnumerable<KeyValuePair<K, V>>(sorteddict.RangeFrom(bot));
	}

	[ComVisible(true)]
	public IDirectedEnumerable<KeyValuePair<K, V>> RangeFromTo(K bot, K top)
	{
		return new GuardedDirectedEnumerable<KeyValuePair<K, V>>(sorteddict.RangeFromTo(bot, top));
	}

	[ComVisible(true)]
	public IDirectedEnumerable<KeyValuePair<K, V>> RangeTo(K top)
	{
		return new GuardedDirectedEnumerable<KeyValuePair<K, V>>(sorteddict.RangeTo(top));
	}

	[ComVisible(true)]
	public IDirectedCollectionValue<KeyValuePair<K, V>> RangeAll()
	{
		return new GuardedDirectedCollectionValue<KeyValuePair<K, V>>(sorteddict.RangeAll());
	}

	[ComVisible(true)]
	public void AddSorted(IEnumerable<KeyValuePair<K, V>> items)
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
}
