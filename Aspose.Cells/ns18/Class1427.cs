using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1427 : Class1425
{
	private readonly Class1415 class1415_0;

	internal Class1427(Class1416 class1416_1)
		: base(class1416_1)
	{
		class1415_0 = new Class1415(class1416_1);
	}

	internal override void vmethod_0(PointF pointF_0, string string_0)
	{
		method_5(pointF_0, string_0);
	}

	internal override void vmethod_1(PointF pointF_0, string string_0)
	{
		method_5(pointF_0, string_0);
	}

	internal override void vmethod_2(PointF pointF_0, Color color_0)
	{
		class1415_0.method_0(pointF_0, method_8());
	}

	internal override void vmethod_3(PointF pointF_0)
	{
		float float_ = method_8();
		class1415_0.method_1(new PointF[2]
		{
			method_2(),
			pointF_0
		}, float_);
	}

	internal override void vmethod_4(RectangleF rectangleF_0)
	{
		method_6(rectangleF_0);
	}

	internal override void vmethod_5(RectangleF rectangleF_0)
	{
		method_6(rectangleF_0);
	}

	internal override void vmethod_6(PointF[] pointF_0)
	{
		class1415_0.method_1(pointF_0, method_8());
	}

	internal override void vmethod_7(PointF[] pointF_0)
	{
		class1415_0.method_1(pointF_0, method_8());
	}

	internal override void vmethod_8(PointF[][] pointF_0)
	{
		class1415_0.method_2(pointF_0, method_8());
	}

	internal override void vmethod_9(PointF[] pointF_0)
	{
		class1415_0.method_1(pointF_0, method_8());
	}

	internal override void vmethod_10(PointF[][] pointF_0)
	{
		class1415_0.method_2(pointF_0, method_8());
	}

	internal override void vmethod_11(RectangleF rectangleF_0, PointF pointF_0, PointF pointF_1)
	{
		method_7(rectangleF_0, pointF_0, pointF_1);
	}

	internal override void vmethod_12(RectangleF rectangleF_0)
	{
		method_6(rectangleF_0);
	}

	internal override void vmethod_13(RectangleF rectangleF_0, PointF pointF_0, PointF pointF_1)
	{
		method_7(rectangleF_0, pointF_0, pointF_1);
	}

	internal override void vmethod_14(RectangleF rectangleF_0, PointF pointF_0, PointF pointF_1)
	{
		method_7(rectangleF_0, pointF_0, pointF_1);
	}

	internal override void vmethod_15(RectangleF rectangleF_0, SizeF sizeF_0)
	{
		method_6(rectangleF_0);
	}

	internal override void vmethod_16(RectangleF rectangleF_0, RectangleF rectangleF_1, byte[] byte_0)
	{
		method_6(rectangleF_1);
	}

	internal override void vmethod_17(RectangleF rectangleF_0)
	{
	}

	private void method_5(PointF pointF_0, string string_0)
	{
		RectangleF rectangleF = new RectangleF(pointF_0, Class1396.smethod_0(string_0, method_0().method_11()));
		rectangleF.Width += method_0().method_22() * string_0.Length;
		Matrix matrix = method_0().method_6(ref pointF_0, rectangleF.Size, method_0().method_11());
		rectangleF.Location = pointF_0;
		PointF[] array = new PointF[4]
		{
			new PointF(rectangleF.X, rectangleF.Y),
			new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y),
			new PointF(rectangleF.X, rectangleF.Y + rectangleF.Height),
			new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + rectangleF.Height)
		};
		matrix.TransformPoints(array);
		class1415_0.method_3(array, 0f);
	}

	private void method_6(RectangleF rectangleF_0)
	{
		float float_ = method_8();
		class1415_0.method_1(new PointF[2]
		{
			new PointF(rectangleF_0.X, rectangleF_0.Y),
			new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height)
		}, float_);
	}

	private void method_7(RectangleF rectangleF_0, PointF pointF_0, PointF pointF_1)
	{
		float float_ = method_8();
		class1415_0.method_1(new PointF[2] { pointF_0, pointF_1 }, float_);
		PointF pointF = new PointF(rectangleF_0.X, rectangleF_0.Y);
		PointF pointF2 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height);
		PointF pointF3 = new PointF((pointF.X + pointF2.X) / 2f, (pointF.Y + pointF2.Y) / 2f);
		pointF_0.X -= pointF3.X;
		pointF_0.Y -= pointF3.Y;
		pointF_1.X -= pointF3.X;
		pointF_1.Y -= pointF3.Y;
		int num = smethod_0(pointF_0);
		int num2 = smethod_0(pointF_1);
		switch (num)
		{
		default:
			throw new InvalidOperationException("Unknown quarter.");
		case 1:
			switch (num2)
			{
			default:
				throw new InvalidOperationException("Unknown quarter.");
			case 1:
				if (!(pointF_1.X < pointF_0.X) || !(pointF_1.Y < pointF_0.Y))
				{
					class1415_0.method_0(new PointF(pointF2.X, pointF3.Y), float_);
					class1415_0.method_0(new PointF(pointF3.X, pointF2.Y), float_);
					class1415_0.method_0(new PointF(pointF.X, pointF3.Y), float_);
					class1415_0.method_0(new PointF(pointF3.X, pointF.Y), float_);
				}
				break;
			case 2:
				class1415_0.method_0(new PointF(pointF3.X, pointF.Y), float_);
				break;
			case 3:
				class1415_0.method_0(new PointF(pointF.X, pointF3.Y), float_);
				class1415_0.method_0(new PointF(pointF3.X, pointF.Y), float_);
				break;
			case 4:
				class1415_0.method_0(new PointF(pointF3.X, pointF2.Y), float_);
				class1415_0.method_0(new PointF(pointF.X, pointF3.Y), float_);
				class1415_0.method_0(new PointF(pointF3.X, pointF.Y), float_);
				break;
			}
			break;
		case 2:
			switch (num2)
			{
			default:
				throw new InvalidOperationException("Unknown quarter.");
			case 1:
				class1415_0.method_0(new PointF(pointF2.X, pointF3.Y), float_);
				class1415_0.method_0(new PointF(pointF3.X, pointF2.Y), float_);
				class1415_0.method_0(new PointF(pointF.X, pointF3.Y), float_);
				break;
			case 2:
				if (!(pointF_1.X < pointF_0.X) || !(pointF_1.Y > pointF_0.Y))
				{
					class1415_0.method_0(new PointF(pointF3.X, pointF.Y), float_);
					class1415_0.method_0(new PointF(pointF2.X, pointF3.Y), float_);
					class1415_0.method_0(new PointF(pointF3.X, pointF2.Y), float_);
					class1415_0.method_0(new PointF(pointF.X, pointF3.Y), float_);
				}
				break;
			case 3:
				class1415_0.method_0(new PointF(pointF.X, pointF3.Y), float_);
				break;
			case 4:
				class1415_0.method_0(new PointF(pointF3.X, pointF2.Y), float_);
				class1415_0.method_0(new PointF(pointF.X, pointF3.Y), float_);
				break;
			}
			break;
		case 3:
			switch (num2)
			{
			default:
				throw new InvalidOperationException("Unknown quarter.");
			case 1:
				class1415_0.method_0(new PointF(pointF2.X, pointF3.Y), float_);
				class1415_0.method_0(new PointF(pointF3.X, pointF2.Y), float_);
				break;
			case 2:
				class1415_0.method_0(new PointF(pointF3.X, pointF.Y), float_);
				class1415_0.method_0(new PointF(pointF2.X, pointF3.Y), float_);
				class1415_0.method_0(new PointF(pointF3.X, pointF2.Y), float_);
				break;
			case 3:
				if (!(pointF_1.X > pointF_0.X) || !(pointF_1.Y > pointF_0.Y))
				{
					class1415_0.method_0(new PointF(pointF.X, pointF3.Y), float_);
					class1415_0.method_0(new PointF(pointF3.X, pointF.Y), float_);
					class1415_0.method_0(new PointF(pointF2.X, pointF3.Y), float_);
					class1415_0.method_0(new PointF(pointF3.X, pointF2.Y), float_);
				}
				break;
			case 4:
				class1415_0.method_0(new PointF(pointF3.X, pointF2.Y), float_);
				break;
			}
			break;
		case 4:
			switch (num2)
			{
			default:
				throw new InvalidOperationException("Unknown quarter.");
			case 1:
				class1415_0.method_0(new PointF(pointF2.X, pointF3.Y), float_);
				break;
			case 2:
				class1415_0.method_0(new PointF(pointF3.X, pointF.Y), float_);
				class1415_0.method_0(new PointF(pointF2.X, pointF3.Y), float_);
				break;
			case 3:
				class1415_0.method_0(new PointF(pointF.X, pointF3.Y), float_);
				class1415_0.method_0(new PointF(pointF3.X, pointF.Y), float_);
				class1415_0.method_0(new PointF(pointF2.X, pointF3.Y), float_);
				break;
			case 4:
				if (!(pointF_1.X > pointF_0.X) || !(pointF_1.Y < pointF_0.Y))
				{
					class1415_0.method_0(new PointF(pointF3.X, pointF2.Y), float_);
					class1415_0.method_0(new PointF(pointF.X, pointF3.Y), float_);
					class1415_0.method_0(new PointF(pointF3.X, pointF.Y), float_);
					class1415_0.method_0(new PointF(pointF2.X, pointF3.Y), float_);
				}
				break;
			}
			break;
		}
	}

	private static int smethod_0(PointF pointF_0)
	{
		if (pointF_0.X > 0f && pointF_0.Y >= 0f)
		{
			return 1;
		}
		if (pointF_0.X <= 0f && pointF_0.Y > 0f)
		{
			return 2;
		}
		if (pointF_0.X < 0f && pointF_0.Y <= 0f)
		{
			return 3;
		}
		return 4;
	}

	private float method_8()
	{
		if (method_0().method_9() == null)
		{
			return 0f;
		}
		return method_0().method_9().Width / 2f;
	}

	[SpecialName]
	internal Class1415 method_9()
	{
		return class1415_0;
	}
}
