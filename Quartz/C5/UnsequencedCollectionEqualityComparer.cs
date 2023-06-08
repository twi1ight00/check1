using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class UnsequencedCollectionEqualityComparer<T, W> : IEqualityComparer<T> where T : ICollection<W>
{
	private static UnsequencedCollectionEqualityComparer<T, W> cached;

	[ComVisible(true)]
	public static UnsequencedCollectionEqualityComparer<T, W> Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new UnsequencedCollectionEqualityComparer<T, W>());
		}
	}

	private UnsequencedCollectionEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(T collection)
	{
		return collection.GetUnsequencedHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(T collection1, T collection2)
	{
		return collection1?.UnsequencedEquals(collection2) ?? (collection2 == null);
	}
}
