using System.Collections;
using Aspose.Cells.Drawing;

namespace ns16;

internal class Class1580 : IComparer
{
	int IComparer.Compare(object x, object y)
	{
		if (x == null && y == null)
		{
			return 0;
		}
		if (x == null)
		{
			return -1;
		}
		if (y == null)
		{
			return 1;
		}
		Shape shape = (Shape)x;
		Shape shape2 = (Shape)y;
		return shape.ZOrderPosition.CompareTo(shape2.ZOrderPosition);
	}
}
