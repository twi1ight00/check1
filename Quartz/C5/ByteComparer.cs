using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class ByteComparer : IComparer<byte>
{
	[ComVisible(true)]
	public int Compare(byte item1, byte item2)
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
	public ByteComparer()
	{
	}
}
