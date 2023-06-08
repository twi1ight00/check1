using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class NaturalComparerO<T> : IComparer<T> where T : IComparable
{
	[Tested]
	[ComVisible(true)]
	public int Compare(T item1, T item2)
	{
		if (item1 == null)
		{
			if (item2 == null)
			{
				return 0;
			}
			return -1;
		}
		return item1.CompareTo(item2);
	}

	[ComVisible(true)]
	public NaturalComparerO()
	{
	}
}
