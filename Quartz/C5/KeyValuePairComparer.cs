using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class KeyValuePairComparer<K, V> : IComparer<KeyValuePair<K, V>>
{
	private IComparer<K> comparer;

	[ComVisible(true)]
	public KeyValuePairComparer(IComparer<K> comparer)
	{
		if (comparer == null)
		{
			throw new NullReferenceException();
		}
		this.comparer = comparer;
	}

	[Tested]
	[ComVisible(true)]
	public int Compare(KeyValuePair<K, V> entry1, KeyValuePair<K, V> entry2)
	{
		return comparer.Compare(entry1.Key, entry2.Key);
	}
}
