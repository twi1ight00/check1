using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class UShortEqualityComparer : IEqualityComparer<ushort>
{
	private static UShortEqualityComparer cached;

	[Tested]
	[ComVisible(true)]
	public static UShortEqualityComparer Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new UShortEqualityComparer());
		}
	}

	private UShortEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(ushort item)
	{
		return item.GetHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(ushort item1, ushort item2)
	{
		return item1 == item2;
	}
}
