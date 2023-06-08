using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class ShortEqualityComparer : IEqualityComparer<short>
{
	private static ShortEqualityComparer cached;

	[Tested]
	[ComVisible(true)]
	public static ShortEqualityComparer Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new ShortEqualityComparer());
		}
	}

	private ShortEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(short item)
	{
		return item.GetHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(short item1, short item2)
	{
		return item1 == item2;
	}
}
