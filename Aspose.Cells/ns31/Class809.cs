using System.Collections;

namespace ns31;

internal class Class809 : IComparer
{
	public int Compare(object x, object y)
	{
		Class810 @class = (Class810)x;
		Class810 class2 = (Class810)y;
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
