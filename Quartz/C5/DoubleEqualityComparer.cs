using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class DoubleEqualityComparer : IEqualityComparer<double>
{
	private static DoubleEqualityComparer cached;

	[Tested]
	[ComVisible(true)]
	public static DoubleEqualityComparer Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new DoubleEqualityComparer());
		}
	}

	private DoubleEqualityComparer()
	{
	}

	[Tested]
	[ComVisible(true)]
	public int GetHashCode(double item)
	{
		return item.GetHashCode();
	}

	[Tested]
	[ComVisible(true)]
	public bool Equals(double item1, double item2)
	{
		return item1 == item2;
	}
}
