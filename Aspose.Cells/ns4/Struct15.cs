using System.Drawing;

namespace ns4;

internal struct Struct15
{
	public Point point_0;

	public Point point_1;

	public Struct15(Point point_2, Point point_3)
	{
		point_0 = point_2;
		point_1 = point_3;
	}

	public Struct15(int int_0, int int_1, int int_2, int int_3)
	{
		point_0 = new Point(int_0, int_1);
		point_1 = new Point(int_2, int_3);
	}
}
