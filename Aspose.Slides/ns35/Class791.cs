using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns35;

internal class Class791
{
	private Matrix matrix_0;

	private Point point_0;

	private Region region_0;

	internal Matrix Transform
	{
		get
		{
			return matrix_0;
		}
		set
		{
			matrix_0 = value;
		}
	}

	public Point RenderingOrigin
	{
		get
		{
			return point_0;
		}
		set
		{
			point_0 = value;
		}
	}

	public Region Clip
	{
		get
		{
			return region_0;
		}
		set
		{
			if (value == null)
			{
				region_0 = new Region();
			}
			else
			{
				region_0 = value;
			}
		}
	}

	internal Class791()
	{
		matrix_0 = new Matrix();
		point_0 = new Point(0, 0);
		region_0 = new Region();
	}

	internal Class791 Clone()
	{
		Class791 @class = new Class791();
		@class.matrix_0 = matrix_0.Clone();
		@class.point_0 = new Point(point_0.X, point_0.Y);
		if (region_0 != null)
		{
			@class.region_0 = region_0.Clone();
		}
		return @class;
	}

	internal void Reset(Class791 gc)
	{
		matrix_0 = gc.matrix_0.Clone();
		point_0 = new Point(gc.point_0.X, gc.point_0.Y);
		if (gc.region_0 != null)
		{
			region_0 = gc.region_0.Clone();
		}
	}
}
