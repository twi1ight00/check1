using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class DoubleComparer : IComparer<double>
{
	[ComVisible(true)]
	public int Compare(double item1, double item2)
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
	public DoubleComparer()
	{
	}
}
