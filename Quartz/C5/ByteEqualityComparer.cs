using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class ByteEqualityComparer : IEqualityComparer<byte>
{
	private static ByteEqualityComparer cached = new ByteEqualityComparer();

	[ComVisible(true)]
	public static ByteEqualityComparer Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new ByteEqualityComparer());
		}
	}

	private ByteEqualityComparer()
	{
	}

	[ComVisible(true)]
	public int GetHashCode(byte item)
	{
		return item.GetHashCode();
	}

	[ComVisible(true)]
	public bool Equals(byte item1, byte item2)
	{
		return item1 == item2;
	}
}
