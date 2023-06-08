using System.Collections;

namespace ns3;

internal class Class859 : IComparer
{
	public int Compare(object x, object y)
	{
		Class860 @class = (Class860)x;
		Class860 class2 = (Class860)y;
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
