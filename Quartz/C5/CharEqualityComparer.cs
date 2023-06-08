using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class CharEqualityComparer : IEqualityComparer<char>
{
	private static CharEqualityComparer cached = new CharEqualityComparer();

	[ComVisible(true)]
	public static CharEqualityComparer Default
	{
		[ComVisible(true)]
		get
		{
			return cached ?? (cached = new CharEqualityComparer());
		}
	}

	private CharEqualityComparer()
	{
	}

	[ComVisible(true)]
	public int GetHashCode(char item)
	{
		return item.GetHashCode();
	}

	[ComVisible(true)]
	public bool Equals(char item1, char item2)
	{
		return item1 == item2;
	}
}
