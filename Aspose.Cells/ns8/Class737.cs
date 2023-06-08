using System.Collections;
using Aspose.Cells;

namespace ns8;

internal class Class737 : IComparer
{
	public int Compare(object x, object y)
	{
		CellArea cellArea = (CellArea)x;
		CellArea cellArea2 = (CellArea)y;
		if (cellArea.StartColumn > cellArea2.StartColumn)
		{
			return 1;
		}
		return 0;
	}
}
