using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns19;

internal class Class1035
{
	private Matrix matrix_0;

	private Point point_0;

	private Region region_0;

	internal Class1035()
	{
		matrix_0 = new Matrix();
		point_0 = new Point(0, 0);
		region_0 = new Region();
	}

	internal Class1035 Clone()
	{
		Class1035 @class = new Class1035();
		@class.matrix_0 = matrix_0.Clone();
		@class.point_0 = new Point(point_0.X, point_0.Y);
		if (region_0 != null)
		{
			@class.region_0 = region_0.Clone();
		}
		return @class;
	}

	internal void Reset(Class1035 class1035_0)
	{
		matrix_0 = class1035_0.matrix_0.Clone();
		point_0 = new Point(class1035_0.point_0.X, class1035_0.point_0.Y);
		if (class1035_0.region_0 != null)
		{
			region_0 = class1035_0.region_0.Clone();
		}
	}

	[SpecialName]
	internal Matrix method_0()
	{
		return matrix_0;
	}

	[SpecialName]
	internal void method_1(Matrix matrix_1)
	{
		matrix_0 = matrix_1;
	}

	[SpecialName]
	public Region method_2()
	{
		return region_0;
	}
}
