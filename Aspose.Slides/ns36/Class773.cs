using System.Collections.Generic;

namespace ns36;

internal class Class773 : IComparer<Interface28>
{
	public int Compare(Interface28 x, Interface28 y)
	{
		Class774 @class = (Class774)x;
		Class774 class2 = (Class774)y;
		if (@class.Position < class2.Position)
		{
			return -1;
		}
		if (@class.Position > class2.Position)
		{
			return 1;
		}
		return 0;
	}
}
