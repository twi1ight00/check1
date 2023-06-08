using System.Drawing;
using ns19;
using ns4;

namespace ns5;

internal class Class42 : Class18
{
	private static readonly Point[] point_0 = new Point[3]
	{
		new Point(0, 0),
		new Point(21600, 0),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_0 = new ushort[2] { 2, 32768 };

	private static readonly Point[] point_1 = new Point[0];

	internal Class42(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		int num = (int)class898_0.X;
		int num2 = (int)class898_0.Y;
		int num3 = (int)class898_0.Width;
		int num4 = (int)class898_0.Height;
		RectangleF rectangleF_ = new RectangleF(num, num2, num3, num4);
		Class15 class15_ = new Class15(point_0, ushort_0, null, null, null, 21600, 21600, int.MinValue, int.MinValue, point_1);
		Class14 @class = new Class14(Enum6.const_138, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.method_14(class898_0.method_20());
		@class.method_13(class898_0.method_18());
		@class.Draw(interface42_0, class898_0, rectangleF_);
	}
}
