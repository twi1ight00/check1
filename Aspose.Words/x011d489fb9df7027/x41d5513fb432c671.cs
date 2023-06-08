using System.Collections;
using Aspose.Words.Drawing;

namespace x011d489fb9df7027;

internal class x41d5513fb432c671 : IComparer
{
	public int Compare(object x, object y)
	{
		ShapeBase shapeBase = (ShapeBase)x;
		ShapeBase shapeBase2 = (ShapeBase)y;
		int num = shapeBase.ZOrder.CompareTo(shapeBase2.ZOrder);
		if (num == 0)
		{
			num = shapeBase.xea1e81378298fa81.CompareTo(shapeBase2.xea1e81378298fa81);
		}
		return num;
	}
}
