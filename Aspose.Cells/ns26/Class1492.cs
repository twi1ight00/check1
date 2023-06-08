using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns26;

internal class Class1492
{
	internal int int_0;

	internal int int_1;

	internal Cell cell_0;

	internal ArrayList arrayList_0;

	internal Class1505 class1505_0;

	internal Class1492[] class1492_0;

	internal Hyperlink hyperlink_0;

	internal Comment comment_0;

	internal int int_2 = 1;

	internal int int_3 = -1;

	internal int EndColumn
	{
		get
		{
			if (class1505_0 != null)
			{
				return class1505_0.int_3;
			}
			return int_1 + int_2 - 1;
		}
	}

	[SpecialName]
	internal bool method_0()
	{
		if (class1505_0 != null)
		{
			if (class1505_0.int_0 == int_0)
			{
				return class1505_0.int_2 != int_1;
			}
			return true;
		}
		return false;
	}

	[SpecialName]
	internal bool method_1()
	{
		if (cell_0 != null && !cell_0.IsBlank)
		{
			return false;
		}
		if (class1505_0 != null)
		{
			return false;
		}
		if (hyperlink_0 != null)
		{
			return false;
		}
		if (arrayList_0 != null && arrayList_0.Count > 0)
		{
			return false;
		}
		if (comment_0 != null)
		{
			return false;
		}
		if (class1492_0 != null)
		{
			return false;
		}
		return true;
	}
}
