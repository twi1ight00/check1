using System.Collections.Generic;

namespace ns37;

internal class Class758 : IComparer<Class759>
{
	public int Compare(Class759 x, Class759 y)
	{
		if (x.DisplayOrder > y.DisplayOrder)
		{
			return 1;
		}
		if (x.DisplayOrder == y.DisplayOrder)
		{
			if (x.Index < y.Index)
			{
				return -1;
			}
			if (x.Index > y.Index)
			{
				return 1;
			}
			return 0;
		}
		return -1;
	}
}
