using Aspose.Cells.Drawing;

namespace ns26;

internal class Class1493
{
	internal Shape shape_0;

	internal double double_0;

	internal double double_1;

	internal double double_2;

	internal double double_3;

	internal int int_0;

	internal int int_1;

	internal Class1493(Shape shape_1)
	{
		shape_0 = shape_1;
		PlacementType placement = shape_1.Placement;
		shape_1.Placement = PlacementType.Move;
		int_0 = shape_1.UpperLeftRow;
		int_1 = shape_1.UpperLeftColumn;
		double_0 = shape_1.Left;
		double_1 = shape_1.Top;
		double_3 = shape_1.Width;
		double_2 = shape_1.Height;
		shape_1.Placement = placement;
	}
}
