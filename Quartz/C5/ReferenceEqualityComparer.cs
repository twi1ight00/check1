using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class ReferenceEqualityComparer<T> : IEqualityComparer<T> where T : class
{
	private static ReferenceEqualityComparer<T> cached;

	[ComVisible(true)]
	public static ReferenceEqualityComparer<T> Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new ReferenceEqualityComparer<T>());
		}
	}

	private ReferenceEqualityComparer()
	{
	}

	[ComVisible(true)]
	public int GetHashCode(T item)
	{
		return RuntimeHelpers.GetHashCode(item);
	}

	[ComVisible(true)]
	public bool Equals(T i1, T i2)
	{
		return object.ReferenceEquals(i1, i2);
	}
}
