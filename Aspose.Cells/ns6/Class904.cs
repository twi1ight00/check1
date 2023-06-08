using System.Collections;

namespace ns6;

internal class Class904 : IComparer
{
	public int Compare(object x, object y)
	{
		Class311 @class = (Class311)x;
		Class311 class2 = (Class311)y;
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
