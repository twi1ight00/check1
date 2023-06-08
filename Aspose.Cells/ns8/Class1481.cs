using System.Collections;

namespace ns8;

internal class Class1481 : IComparer
{
	int IComparer.Compare(object x, object y)
	{
		Class315 @class = (Class315)x;
		Class315 class2 = (Class315)y;
		if (@class.method_0() > class2.method_0())
		{
			return 1;
		}
		if (@class.method_0() < class2.method_0())
		{
			return -1;
		}
		if (@class.method_1() > class2.method_1())
		{
			return 1;
		}
		if (@class.method_1() < class2.method_1())
		{
			return -1;
		}
		return 0;
	}
}
