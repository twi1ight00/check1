using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class ULongEqualityComparer : IEqualityComparer<ulong>
{
	private static ULongEqualityComparer cached;

	[Tested]
	[ComVisible(true)]
	public static ULongEqualityComparer Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new ULongEqualityComparer());
		}
	}

	private ULongEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(ulong item)
	{
		return item.GetHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(ulong item1, ulong item2)
	{
		return item1 == item2;
	}
}
