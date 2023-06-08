using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class ULongComparer : IComparer<ulong>
{
	[Tested]
	[ComVisible(true)]
	public int Compare(ulong item1, ulong item2)
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
	public ULongComparer()
	{
	}
}
