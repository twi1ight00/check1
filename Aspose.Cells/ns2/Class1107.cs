using System.Collections;

namespace ns2;

internal class Class1107 : IComparer
{
	private bool bool_0;

	private bool bool_1;

	internal Class1107(bool bool_2, bool bool_3)
	{
		bool_0 = bool_2;
		bool_1 = bool_3;
	}

	public int Compare(object x, object y)
	{
		if (bool_1)
		{
			if (!bool_0)
			{
				return ((double)y).CompareTo((double)x);
			}
			return ((double)x).CompareTo((double)y);
		}
		if (!bool_0)
		{
			return ((string)y).CompareTo((string)x);
		}
		return ((string)x).CompareTo((string)y);
	}
}
