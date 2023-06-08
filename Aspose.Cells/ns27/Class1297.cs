using System.Collections;
using Aspose.Cells;

namespace ns27;

internal class Class1297 : IComparer
{
	public int Compare(object x, object y)
	{
		VerticalPageBreak verticalPageBreak = (VerticalPageBreak)x;
		VerticalPageBreak verticalPageBreak2 = (VerticalPageBreak)y;
		if (verticalPageBreak.Column > verticalPageBreak2.Column)
		{
			return 1;
		}
		if (verticalPageBreak.Column == verticalPageBreak2.Column)
		{
			if (verticalPageBreak.StartRow > verticalPageBreak2.StartRow)
			{
				return 1;
			}
			return -1;
		}
		return -1;
	}
}
