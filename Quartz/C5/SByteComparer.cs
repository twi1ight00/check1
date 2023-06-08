using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class SByteComparer : IComparer<sbyte>
{
	[Tested]
	[ComVisible(true)]
	public int Compare(sbyte item1, sbyte item2)
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
	public SByteComparer()
	{
	}
}
