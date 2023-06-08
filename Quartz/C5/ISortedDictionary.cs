using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal interface ISortedDictionary<K, V> : IDictionary<K, V>, ICollectionValue<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, IShowable, IFormattable, ICloneable
{
	[ComVisible(true)]
	new ISorted<K> Keys
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	IComparer<K> Comparer
	{
		[ComVisible(true)]
		get;
	}

	[ComVisible(true)]
	KeyValuePair<K, V> FindMin();

	[ComVisible(true)]
	KeyValuePair<K, V> DeleteMin();

	[ComVisible(true)]
	KeyValuePair<K, V> FindMax();

	[ComVisible(true)]
	KeyValuePair<K, V> DeleteMax();

	[ComVisible(true)]
	bool TryPredecessor(K key, out KeyValuePair<K, V> res);

	[ComVisible(true)]
	bool TrySuccessor(K key, out KeyValuePair<K, V> res);

	[ComVisible(true)]
	bool TryWeakPredecessor(K key, out KeyValuePair<K, V> res);

	[ComVisible(true)]
	bool TryWeakSuccessor(K key, out KeyValuePair<K, V> res);

	[ComVisible(true)]
	KeyValuePair<K, V> Predecessor(K key);

	[ComVisible(true)]
	KeyValuePair<K, V> Successor(K key);

	[ComVisible(true)]
	KeyValuePair<K, V> WeakPredecessor(K key);

	[ComVisible(true)]
	KeyValuePair<K, V> WeakSuccessor(K key);

	[ComVisible(true)]
	bool Cut(IComparable<K> cutFunction, out KeyValuePair<K, V> lowEntry, out bool lowIsValid, out KeyValuePair<K, V> highEntry, out bool highIsValid);

	[ComVisible(true)]
	IDirectedEnumerable<KeyValuePair<K, V>> RangeFrom(K bot);

	[ComVisible(true)]
	IDirectedEnumerable<KeyValuePair<K, V>> RangeFromTo(K lowerBound, K upperBound);

	[ComVisible(true)]
	IDirectedEnumerable<KeyValuePair<K, V>> RangeTo(K top);

	[ComVisible(true)]
	IDirectedCollectionValue<KeyValuePair<K, V>> RangeAll();

	[ComVisible(true)]
	void AddSorted(IEnumerable<KeyValuePair<K, V>> items);

	[ComVisible(true)]
	void RemoveRangeFrom(K low);

	[ComVisible(true)]
	void RemoveRangeFromTo(K low, K hi);

	[ComVisible(true)]
	void RemoveRangeTo(K hi);
}
