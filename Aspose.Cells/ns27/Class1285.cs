using System.Collections;
using Aspose.Cells;

namespace ns27;

internal class Class1285 : IComparer
{
	public int Compare(object x, object y)
	{
		HorizontalPageBreak horizontalPageBreak = (HorizontalPageBreak)x;
		HorizontalPageBreak horizontalPageBreak2 = (HorizontalPageBreak)y;
		if (horizontalPageBreak.Row > horizontalPageBreak2.Row)
		{
			return 1;
		}
		if (horizontalPageBreak.Row == horizontalPageBreak2.Row)
		{
			if (horizontalPageBreak.StartColumn > horizontalPageBreak2.StartColumn)
			{
				return 1;
			}
			return -1;
		}
		return -1;
	}
}
