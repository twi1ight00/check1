using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

[Serializable]
internal class UIntComparer : IComparer<uint>
{
	[Tested]
	[ComVisible(true)]
	public int Compare(uint item1, uint item2)
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
	public UIntComparer()
	{
	}
}
