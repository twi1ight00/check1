using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal sealed class NaturalEqualityComparer<T> : IEqualityComparer<T>
{
	private static NaturalEqualityComparer<T> cached;

	[ComVisible(true)]
	public static NaturalEqualityComparer<T> Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new NaturalEqualityComparer<T>());
		}
	}

	private NaturalEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(T item)
	{
		return item?.GetHashCode() ?? 0;
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(T item1, T item2)
	{
		return item1?.Equals(item2) ?? (item2 == null);
	}
}
