using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class CharComparer : IComparer<char>
{
	[ComVisible(true)]
	public int Compare(char item1, char item2)
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
	public CharComparer()
	{
	}
}
