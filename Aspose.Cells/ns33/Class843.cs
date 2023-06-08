using System.Collections;

namespace ns33;

internal class Class843 : IComparer
{
	public int Compare(object x, object y)
	{
		Class844 @class = (Class844)x;
		Class844 class2 = (Class844)y;
		if (@class.vmethod_3() > class2.vmethod_3())
		{
			return 1;
		}
		if (@class.vmethod_3() == class2.vmethod_3())
		{
			if (@class.Index < class2.Index)
			{
				return -1;
			}
			if (@class.Index > class2.Index)
			{
				return 1;
			}
			return 0;
		}
		return -1;
	}
}
