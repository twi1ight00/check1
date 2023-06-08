using System.Collections;

namespace ns17;

internal class Class1095 : IComparer
{
	public int Compare(object x, object y)
	{
		Struct80 @struct = (Struct80)x;
		Struct80 struct2 = (Struct80)y;
		if (@struct.int_0 > struct2.int_0)
		{
			return 1;
		}
		if (@struct.int_0 == struct2.int_0)
		{
			if (@struct.int_1 > struct2.int_1)
			{
				return 1;
			}
			if (@struct.int_1 == struct2.int_1)
			{
				return 0;
			}
			return -1;
		}
		return -1;
	}
}
