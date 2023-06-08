using System.Collections;

namespace ns49;

internal class Class1103 : IComparer
{
	public int Compare(object x, object y)
	{
		Struct81 @struct = (Struct81)x;
		Struct81 struct2 = (Struct81)y;
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
