using System.Collections;

namespace ns5;

internal class Class156 : IComparer
{
	public int Compare(object x, object y)
	{
		Class157 @class = (Class157)x;
		Class157 class2 = (Class157)y;
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
