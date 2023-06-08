using System.Collections;

namespace ns31;

internal class Class814 : IComparer
{
	public int Compare(object x, object y)
	{
		Class815 @class = (Class815)x;
		Class815 class2 = (Class815)y;
		if (@class.vmethod_0() > class2.vmethod_0())
		{
			return 1;
		}
		if (@class.vmethod_0() == class2.vmethod_0())
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
