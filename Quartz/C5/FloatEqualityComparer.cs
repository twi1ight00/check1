using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class FloatEqualityComparer : IEqualityComparer<float>
{
	private static FloatEqualityComparer cached;

	[Tested]
	[ComVisible(true)]
	public static FloatEqualityComparer Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new FloatEqualityComparer());
		}
	}

	private FloatEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(float item)
	{
		return item.GetHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(float item1, float item2)
	{
		return item1 == item2;
	}
}
