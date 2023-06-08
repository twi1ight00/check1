using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class IntComparer : IComparer<int>
{
	[Tested]
	[ComVisible(true)]
	public int Compare(int item1, int item2)
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
	public IntComparer()
	{
	}
}
