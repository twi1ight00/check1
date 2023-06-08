using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class IntEqualityComparer : IEqualityComparer<int>
{
	private static IntEqualityComparer cached;

	[Tested]
	[ComVisible(true)]
	public static IntEqualityComparer Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new IntEqualityComparer());
		}
	}

	private IntEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(int item)
	{
		return item;
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(int item1, int item2)
	{
		return item1 == item2;
	}
}
