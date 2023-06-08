using System.Collections;
using Aspose.Cells;

namespace ns8;

internal class Class1476 : IComparer
{
	int IComparer.Compare(object x, object y)
	{
		CellArea cellArea = (CellArea)x;
		CellArea cellArea2 = (CellArea)y;
		if (cellArea.StartRow > cellArea2.StartRow)
		{
			return 1;
		}
		if (cellArea.StartRow < cellArea2.StartRow)
		{
			return -1;
		}
		if (cellArea.StartColumn > cellArea2.StartColumn)
		{
			return 1;
		}
		if (cellArea.StartColumn < cellArea2.StartColumn)
		{
			return -1;
		}
		return 0;
	}
}
