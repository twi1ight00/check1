using System;
using System.Drawing;

namespace ns18;

internal class Class1421
{
	internal static Class458 smethod_0(PointF[] pointF_0, bool bool_0)
	{
		Class458 @class = new Class458();
		Class459 class452_ = Class459.smethod_0(pointF_0, bool_0);
		@class.Add(class452_);
		return @class;
	}

	internal static Class458 smethod_1(PointF[][] pointF_0, bool bool_0)
	{
		Class458 @class = new Class458();
		for (int i = 0; i < pointF_0.GetLength(0); i++)
		{
			Class459 class452_ = Class459.smethod_0(pointF_0[i], bool_0);
			@class.Add(class452_);
		}
		return @class;
	}

	internal static Class458 smethod_2(PointF[] pointF_0)
	{
		Class458 @class = new Class458();
		Class459 class452_ = Class459.smethod_1(pointF_0);
		@class.Add(class452_);
		return @class;
	}

	internal static Class458 smethod_3(RectangleF rectangleF_0, PointF pointF_0, PointF pointF_1)
	{
		Class458 @class = new Class458();
		Class459 class2 = new Class459();
		@class.Add(class2);
		Class462 class3 = smethod_8(rectangleF_0, pointF_0, pointF_1);
		class2.method_3(class3.method_1());
		class2.Add(class3);
		return @class;
	}

	internal static Class458 smethod_4(RectangleF rectangleF_0)
	{
		Class458 @class = new Class458();
		Class459 class2 = new Class459();
		@class.Add(class2);
		Class462 class3 = smethod_8(rectangleF_0, PointF.Empty, PointF.Empty);
		class2.method_3(class3.method_1());
		class2.Add(class3);
		return @class;
	}

	internal static Class458 smethod_5(RectangleF rectangleF_0, PointF pointF_0, PointF pointF_1)
	{
		Class458 @class = new Class458();
		Class459 class2 = new Class459();
		@class.Add(class2);
		Class462 class3 = smethod_8(rectangleF_0, pointF_0, pointF_1);
		class2.method_3(class3.method_1());
		class2.Add(class3);
		Class467 class4 = new Class467();
		class4.Points.Add(class3.method_14());
		class4.Points.Add(class2.method_2());
		class2.Add(class4);
		class2.method_5(bool_1: true);
		return @class;
	}

	internal static Class458 smethod_6(RectangleF rectangleF_0, PointF pointF_0, PointF pointF_1)
	{
		Class458 @class = new Class458();
		Class459 class2 = new Class459();
		@class.Add(class2);
		Class462 class3 = smethod_8(rectangleF_0, pointF_0, pointF_1);
		class2.method_3(class3.method_1());
		class2.Add(class3);
		Class467 class4 = new Class467();
		class4.Points.Add(class2.method_2());
		class2.Add(class4);
		return @class;
	}

	internal static Class458 smethod_7(RectangleF rectangleF_0, SizeF sizeF_0)
	{
		Class458 @class = new Class458();
		Class459 class2 = new Class459();
		@class.Add(class2);
		SizeF sizeF = new SizeF(sizeF_0.Width / 2f, sizeF_0.Height / 2f);
		class2.method_3(new PointF(rectangleF_0.Left + sizeF.Width, rectangleF_0.Top));
		Class467 class3 = new Class467();
		class3.Points.Add(new PointF(rectangleF_0.Right - sizeF.Width, rectangleF_0.Top));
		class2.Add(class3);
		Class462 class452_ = smethod_8(new RectangleF(rectangleF_0.Right - sizeF_0.Width, rectangleF_0.Top, sizeF_0.Width, sizeF_0.Height), new PointF(rectangleF_0.Right - sizeF.Width, rectangleF_0.Top), new PointF(rectangleF_0.Right, rectangleF_0.Top + sizeF.Height));
		class2.Add(class452_);
		Class467 class4 = new Class467();
		class4.Points.Add(new PointF(rectangleF_0.Right, rectangleF_0.Bottom - sizeF.Height));
		class2.Add(class4);
		Class462 class452_2 = smethod_8(new RectangleF(rectangleF_0.Right - sizeF_0.Width, rectangleF_0.Bottom - sizeF_0.Height, sizeF_0.Width, sizeF_0.Height), new PointF(rectangleF_0.Right, rectangleF_0.Bottom - sizeF.Height), new PointF(rectangleF_0.Right - sizeF.Width, rectangleF_0.Bottom));
		class2.Add(class452_2);
		Class467 class5 = new Class467();
		class5.Points.Add(new PointF(rectangleF_0.Left + sizeF.Width, rectangleF_0.Bottom));
		class2.Add(class5);
		Class462 class452_3 = smethod_8(new RectangleF(rectangleF_0.Left, rectangleF_0.Bottom - sizeF_0.Height, sizeF_0.Width, sizeF_0.Height), new PointF(rectangleF_0.Left + sizeF.Width, rectangleF_0.Bottom), new PointF(rectangleF_0.Left, rectangleF_0.Bottom - sizeF.Height));
		class2.Add(class452_3);
		Class467 class6 = new Class467();
		class6.Points.Add(new PointF(rectangleF_0.Left, rectangleF_0.Top + sizeF.Height));
		class2.Add(class6);
		Class462 class452_4 = smethod_8(new RectangleF(rectangleF_0.Left, rectangleF_0.Top, sizeF_0.Width, sizeF_0.Height), new PointF(rectangleF_0.Left, rectangleF_0.Top + sizeF.Height), new PointF(rectangleF_0.Left + sizeF.Width, rectangleF_0.Top));
		class2.Add(class452_4);
		return @class;
	}

	private static Class462 smethod_8(RectangleF rectangleF_0, PointF pointF_0, PointF pointF_1)
	{
		SizeF sizeF = new SizeF(rectangleF_0.Width / 2f, rectangleF_0.Height / 2f);
		PointF pointF = new PointF(rectangleF_0.X + sizeF.Width, rectangleF_0.Y + sizeF.Height);
		float num = (float)Math.Atan2(pointF.Y - pointF_0.Y, pointF_0.X - pointF.X);
		float num2 = (float)Math.Atan2(pointF.Y - pointF_1.Y, pointF_1.X - pointF.X);
		Class462 @class = new Class462();
		@class.method_8(rectangleF_0.Location);
		@class.Size = rectangleF_0.Size;
		@class.method_10((float)Class1397.smethod_1(num));
		if (num2 < num)
		{
			num2 += (float)Math.PI * 2f;
		}
		float num3 = num2 - num;
		if (num3 == 0f)
		{
			@class.method_12(360f);
		}
		else
		{
			@class.method_12((float)Class1397.smethod_1(num3));
		}
		return @class;
	}
}
