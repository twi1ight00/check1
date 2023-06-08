using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class SortedArrayDictionary<K, V> : SortedDictionaryBase<K, V>, ISortedDictionary<K, V>, IDictionary<K, V>, ICollectionValue<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, IShowable, IFormattable, ICloneable
{
	[ComVisible(true)]
	public SortedArrayDictionary()
		: this(Comparer<K>.Default, EqualityComparer<K>.Default)
	{
	}

	[ComVisible(true)]
	public SortedArrayDictionary(IComparer<K> comparer)
		: this(comparer, (IEqualityComparer<K>)new ComparerZeroHashCodeEqualityComparer<K>(comparer))
	{
	}

	[ComVisible(true)]
	public SortedArrayDictionary(IComparer<K> comparer, IEqualityComparer<K> equalityComparer)
		: base(comparer, equalityComparer)
	{
		pairs = (sortedpairs = new SortedArray<KeyValuePair<K, V>>(new KeyValuePairComparer<K, V>(comparer)));
	}

	[ComVisible(true)]
	public SortedArrayDictionary(int capacity, IComparer<K> comparer, IEqualityComparer<K> equalityComparer)
		: base(comparer, equalityComparer)
	{
		pairs = (sortedpairs = new SortedArray<KeyValuePair<K, V>>(capacity, new KeyValuePairComparer<K, V>(comparer)));
	}

	[ComVisible(true)]
	public override object Clone()
	{
		SortedArrayDictionary<K, V> sortedArrayDictionary = new SortedArrayDictionary<K, V>(base.Comparer, EqualityComparer);
		sortedArrayDictionary.sortedpairs.AddSorted(sortedpairs);
		return sortedArrayDictionary;
	}
}
