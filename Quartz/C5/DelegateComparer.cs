using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class DelegateComparer<T> : IComparer<T>
{
	private readonly Comparison<T> cmp;

	[ComVisible(true)]
	public DelegateComparer(Comparison<T> comparison)
	{
		if (comparison == null)
		{
			throw new NullReferenceException("Comparison cannot be null");
		}
		cmp = comparison;
	}

	[ComVisible(true)]
	public int Compare(T item1, T item2)
	{
		return cmp(item1, item2);
	}
}
