using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class HashDictionary<K, V> : DictionaryBase<K, V>, IDictionary<K, V>, ICollectionValue<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, IShowable, IFormattable, ICloneable
{
	[ComVisible(true)]
	public HashDictionary()
		: this(EqualityComparer<K>.Default)
	{
	}

	[ComVisible(true)]
	public HashDictionary(IEqualityComparer<K> keyequalityComparer)
		: base(keyequalityComparer)
	{
		pairs = new HashSet<KeyValuePair<K, V>>(new KeyValuePairEqualityComparer<K, V>(keyequalityComparer));
	}

	[ComVisible(true)]
	public HashDictionary(int capacity, double fill, IEqualityComparer<K> keyequalityComparer)
		: base(keyequalityComparer)
	{
		pairs = new HashSet<KeyValuePair<K, V>>(capacity, fill, new KeyValuePairEqualityComparer<K, V>(keyequalityComparer));
	}

	[ComVisible(true)]
	public override object Clone()
	{
		HashDictionary<K, V> hashDictionary = new HashDictionary<K, V>(EqualityComparer);
		hashDictionary.pairs.AddAll(pairs);
		return hashDictionary;
	}
}
