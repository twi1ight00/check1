using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class ComparerZeroHashCodeEqualityComparer<T> : IEqualityComparer<T>
{
	private IComparer<T> comparer;

	[ComVisible(true)]
	public ComparerZeroHashCodeEqualityComparer(IComparer<T> comparer)
	{
		if (comparer == null)
		{
			throw new NullReferenceException("Comparer cannot be null");
		}
		this.comparer = comparer;
	}

	[ComVisible(true)]
	public int GetHashCode(T item)
	{
		return 0;
	}

	[ComVisible(true)]
	public bool Equals(T item1, T item2)
	{
		return comparer.Compare(item1, item2) == 0;
	}
}
