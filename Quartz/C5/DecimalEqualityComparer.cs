using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class DecimalEqualityComparer : IEqualityComparer<decimal>
{
	private static DecimalEqualityComparer cached;

	[Tested]
	[ComVisible(true)]
	public static DecimalEqualityComparer Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new DecimalEqualityComparer());
		}
	}

	private DecimalEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(decimal item)
	{
		return item.GetHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(decimal item1, decimal item2)
	{
		return item1 == item2;
	}
}
