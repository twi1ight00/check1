using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class DecimalComparer : IComparer<decimal>
{
	[Tested]
	[ComVisible(true)]
	public int Compare(decimal item1, decimal item2)
	{
		if (!(item1 > item2))
		{
			if (!(item1 < item2))
			{
				return 0;
			}
			return -1;
		}
		return 1;
	}

	[ComVisible(true)]
	public DecimalComparer()
	{
	}
}
