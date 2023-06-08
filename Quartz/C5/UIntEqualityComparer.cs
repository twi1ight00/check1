using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class UIntEqualityComparer : IEqualityComparer<uint>
{
	private static UIntEqualityComparer cached;

	[Tested]
	[ComVisible(true)]
	public static UIntEqualityComparer Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new UIntEqualityComparer());
		}
	}

	private UIntEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(uint item)
	{
		return item.GetHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(uint item1, uint item2)
	{
		return item1 == item2;
	}
}
