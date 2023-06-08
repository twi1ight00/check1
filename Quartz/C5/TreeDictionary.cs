using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class TreeDictionary<K, V> : SortedDictionaryBase<K, V>, ISortedDictionary<K, V>, IDictionary<K, V>, ICollectionValue<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, IShowable, IFormattable, ICloneable
{
	[ComVisible(true)]
	public TreeDictionary()
		: this(Comparer<K>.Default, EqualityComparer<K>.Default)
	{
	}

	[ComVisible(true)]
	public TreeDictionary(IComparer<K> comparer)
		: this(comparer, (IEqualityComparer<K>)new ComparerZeroHashCodeEqualityComparer<K>(comparer))
	{
	}

	private TreeDictionary(IComparer<K> comparer, IEqualityComparer<K> equalityComparer)
		: base(comparer, equalityComparer)
	{
		pairs = (sortedpairs = new TreeSet<KeyValuePair<K, V>>(new KeyValuePairComparer<K, V>(comparer)));
	}

	[Tested]
	[ComVisible(true)]
	public IEnumerable<KeyValuePair<K, V>> Snapshot()
	{
		TreeDictionary<K, V> treeDictionary = (TreeDictionary<K, V>)MemberwiseClone();
		treeDictionary.pairs = (TreeSet<KeyValuePair<K, V>>)((TreeSet<KeyValuePair<K, V>>)sortedpairs).Snapshot();
		return treeDictionary;
	}

	[ComVisible(true)]
	public override object Clone()
	{
		TreeDictionary<K, V> treeDictionary = new TreeDictionary<K, V>(base.Comparer, EqualityComparer);
		treeDictionary.sortedpairs.AddSorted(sortedpairs);
		return treeDictionary;
	}
}
