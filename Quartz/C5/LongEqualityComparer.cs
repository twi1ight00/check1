using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class LongEqualityComparer : IEqualityComparer<long>
{
	private static LongEqualityComparer cached;

	[Tested]
	[ComVisible(true)]
	public static LongEqualityComparer Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new LongEqualityComparer());
		}
	}

	private LongEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(long item)
	{
		return item.GetHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(long item1, long item2)
	{
		return item1 == item2;
	}
}
