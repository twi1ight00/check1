using System.Collections;
using Aspose.Cells;

namespace ns8;

internal class Class1479 : IComparer
{
	int IComparer.Compare(object x, object y)
	{
		CellArea area = ((Hyperlink)x).Area;
		CellArea area2 = ((Hyperlink)y).Area;
		if (area.StartRow > area2.StartRow)
		{
			return 1;
		}
		if (area.StartRow < area2.StartRow)
		{
			return -1;
		}
		if (area.StartColumn > area2.StartColumn)
		{
			return 1;
		}
		if (area.StartColumn < area2.StartColumn)
		{
			return -1;
		}
		return 0;
	}
}
