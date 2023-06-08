using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal sealed class KeyValuePairEqualityComparer<K, V> : IEqualityComparer<KeyValuePair<K, V>>
{
	private IEqualityComparer<K> keyequalityComparer;

	[ComVisible(true)]
	public KeyValuePairEqualityComparer()
	{
		keyequalityComparer = EqualityComparer<K>.Default;
	}

	[ComVisible(true)]
	public KeyValuePairEqualityComparer(IEqualityComparer<K> keyequalityComparer)
	{
		if (keyequalityComparer == null)
		{
			throw new NullReferenceException("Key equality comparer cannot be null");
		}
		this.keyequalityComparer = keyequalityComparer;
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(KeyValuePair<K, V> entry)
	{
		return keyequalityComparer.GetHashCode(entry.Key);
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(KeyValuePair<K, V> entry1, KeyValuePair<K, V> entry2)
	{
		return keyequalityComparer.Equals(entry1.Key, entry2.Key);
	}
}
