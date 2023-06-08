using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class UShortComparer : IComparer<ushort>
{
	[Tested]
	[ComVisible(true)]
	public int Compare(ushort item1, ushort item2)
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
	public UShortComparer()
	{
	}
}
