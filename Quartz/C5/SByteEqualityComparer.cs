using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class SByteEqualityComparer : IEqualityComparer<sbyte>
{
	private static SByteEqualityComparer cached;

	[Tested]
	[ComVisible(true)]
	public static SByteEqualityComparer Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new SByteEqualityComparer());
		}
	}

	private SByteEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(sbyte item)
	{
		return item.GetHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(sbyte item1, sbyte item2)
	{
		return item1 == item2;
	}
}
