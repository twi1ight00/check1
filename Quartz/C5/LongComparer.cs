using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class LongComparer : IComparer<long>
{
	[Tested]
	[ComVisible(true)]
	public int Compare(long item1, long item2)
	{
		if (item1 <= item2)
		{
			if (item1 >= item2)
			{
				return 0;
			}
			return -1;
		}
		return 1;
	}

	[ComVisible(true)]
	public LongComparer()
	{
	}
}
