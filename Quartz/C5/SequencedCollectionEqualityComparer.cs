using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class SequencedCollectionEqualityComparer<T, W> : IEqualityComparer<T> where T : ISequenced<W>
{
	private static SequencedCollectionEqualityComparer<T, W> cached;

	[ComVisible(true)]
	public static SequencedCollectionEqualityComparer<T, W> Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new SequencedCollectionEqualityComparer<T, W>());
		}
	}

	private SequencedCollectionEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(T collection)
	{
		return collection.GetSequencedHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(T collection1, T collection2)
	{
		return collection1?.SequencedEquals(collection2) ?? (collection2 == null);
	}
}
