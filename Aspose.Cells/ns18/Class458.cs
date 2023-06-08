using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class458 : Class453, Interface5
{
	public Class770 class770_0;

	private Brush brush_0;

	private Matrix matrix_0;

	private Class458 class458_0;

	private FillMode fillMode_0;

	public Class458()
	{
	}

	public Class458(RectangleF rectangleF_0)
	{
		Class459 @class = new Class459(rectangleF_0.Location);
		@class.method_5(bool_1: true);
		Add(@class);
		Class467 class452_ = new Class467(new float[6] { rectangleF_0.Right, rectangleF_0.Top, rectangleF_0.Right, rectangleF_0.Bottom, rectangleF_0.Left, rectangleF_0.Bottom });
		@class.Add(class452_);
	}

	[SpecialName]
	public Brush method_2()
	{
		return brush_0;
	}

	[SpecialName]
	public void method_3(Brush brush_1)
	{
		brush_0 = brush_1;
	}

	[SpecialName]
	public Matrix imethod_0()
	{
		return matrix_0;
	}

	[SpecialName]
	public void vmethod_1(Matrix matrix_1)
	{
		matrix_0 = matrix_1;
	}

	[SpecialName]
	public Class458 imethod_1()
	{
		return class458_0;
	}

	[SpecialName]
	public bool imethod_2()
	{
		return class770_0 != null;
	}

	[SpecialName]
	public FillMode method_4()
	{
		return fillMode_0;
	}

	[SpecialName]
	public void method_5(FillMode fillMode_1)
	{
		fillMode_0 = fillMode_1;
	}

	public override void vmethod_0(Class468 class468_0)
	{
		class468_0.vmethod_6(this);
		base.vmethod_0(class468_0);
		class468_0.vmethod_7(this);
	}

	public static Class458 smethod_0(PointF pointF_0, PointF pointF_1, PointF pointF_2)
	{
		Class458 @class = new Class458();
		Class459 class2 = new Class459(pointF_0);
		class2.method_5(bool_1: true);
		@class.Add(class2);
		Class467 class452_ = new Class467(new float[6] { pointF_1.X, pointF_1.Y, pointF_2.X, pointF_2.Y, pointF_0.X, pointF_0.Y });
		class2.Add(class452_);
		return @class;
	}

	public static Class458 smethod_1(RectangleF rectangleF_0)
	{
		float num = 0.2761424f;
		Class458 @class = new Class458();
		Class459 class2 = new Class459(rectangleF_0.Location);
		class2.method_5(bool_1: true);
		@class.Add(class2);
		PointF pointF = new PointF(rectangleF_0.Width * num, rectangleF_0.Height * num);
		PointF pointF2 = new PointF(rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Top + rectangleF_0.Height / 2f);
		PointF[] array = new PointF[13];
		array[0].X = rectangleF_0.Left;
		array[1].X = rectangleF_0.Left;
		array[11].X = rectangleF_0.Left;
		array[12].X = rectangleF_0.Left;
		array[5].X = rectangleF_0.Right;
		array[6].X = rectangleF_0.Right;
		array[7].X = rectangleF_0.Right;
		array[2].X = pointF2.X - pointF.X;
		array[10].X = pointF2.X - pointF.X;
		array[4].X = pointF2.X + pointF.X;
		array[8].X = pointF2.X + pointF.X;
		array[3].X = pointF2.X;
		array[9].X = pointF2.X;
		array[2].Y = rectangleF_0.Top;
		array[3].Y = rectangleF_0.Top;
		array[4].Y = rectangleF_0.Top;
		array[8].Y = rectangleF_0.Bottom;
		array[9].Y = rectangleF_0.Bottom;
		array[10].Y = rectangleF_0.Bottom;
		array[7].Y = pointF2.Y + pointF.Y;
		array[11].Y = pointF2.Y + pointF.Y;
		array[1].Y = pointF2.Y - pointF.Y;
		array[5].Y = pointF2.Y - pointF.Y;
		array[0].Y = pointF2.Y;
		array[12].Y = pointF2.Y;
		array[6].Y = pointF2.Y;
		Class466 class3 = new Class466();
		for (int i = 0; i < 12; i += 3)
		{
			Struct89 struct89_ = default(Struct89);
			struct89_.method_1(array[i]);
			struct89_.method_3(array[i + 1]);
			struct89_.method_5(array[i + 2]);
			struct89_.method_7(array[i + 3]);
			class3.method_1(struct89_);
		}
		class2.Add(class3);
		class2.method_3(array[0]);
		return @class;
	}

	public static Class458 smethod_2(RectangleF rectangleF_0)
	{
		Class458 @class = new Class458();
		Class459 class2 = new Class459(rectangleF_0.Location);
		class2.method_5(bool_1: true);
		@class.Add(class2);
		Class467 class452_ = new Class467(new float[6] { rectangleF_0.Right, rectangleF_0.Top, rectangleF_0.Right, rectangleF_0.Bottom, rectangleF_0.Left, rectangleF_0.Bottom });
		class2.Add(class452_);
		return @class;
	}

	public static Class458 smethod_3(PointF pointF_0, PointF pointF_1)
	{
		Class458 @class = new Class458();
		Class459 class2 = new Class459(pointF_0);
		@class.Add(class2);
		Class467 class452_ = new Class467(new float[2] { pointF_1.X, pointF_1.Y });
		class2.Add(class452_);
		return @class;
	}
}
