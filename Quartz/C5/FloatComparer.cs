using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class FloatComparer : IComparer<float>
{
	[ComVisible(true)]
	public int Compare(float item1, float item2)
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
	public FloatComparer()
	{
	}
}
