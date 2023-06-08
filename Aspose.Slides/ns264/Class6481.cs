using System;
using System.Drawing;
using ns224;

namespace ns264;

internal class Class6481 : Class6479
{
	private Class6485 class6485_0;

	private float float_0 = float.MaxValue;

	private float float_1 = float.MaxValue;

	private float float_2 = float.MinValue;

	private float float_3 = float.MinValue;

	internal RectangleF Bounds => RectangleF.FromLTRB(float_0, float_1, float_2, float_3);

	internal Class6481(Class6485 player)
	{
		class6485_0 = player;
	}

	internal override void vmethod_23(PointF origin, string text)
	{
		method_0(origin, text);
	}

	internal override void vmethod_9(PointF origin, string text)
	{
		method_0(origin, text);
	}

	internal override void vmethod_21(PointF position, Class5998 color)
	{
		method_4(position, method_3());
	}

	internal override void vmethod_12(PointF endPoint)
	{
		float scope = method_3();
		method_5(new PointF[2] { class6485_0.CurrentPosition, endPoint }, scope);
	}

	internal override void vmethod_19(RectangleF bounds)
	{
		method_1(bounds);
	}

	internal override void vmethod_10(RectangleF bounds)
	{
		method_1(bounds);
	}

	internal override void vmethod_24(RectangleF bounds)
	{
		method_1(bounds);
	}

	internal override void vmethod_11(Class6499 region, Class6003 pen, Class5990 brush)
	{
		method_1(region.Bounds);
	}

	internal override void vmethod_16(PointF[] points)
	{
		method_5(points, method_3());
	}

	internal override void vmethod_14(PointF[] points)
	{
		method_5(points, method_3());
	}

	internal override void vmethod_18(PointF[][] pointsPoints)
	{
		method_6(pointsPoints, method_3());
	}

	internal override void vmethod_15(PointF[] points)
	{
		method_5(points, method_3());
	}

	internal override void vmethod_17(PointF[][] points)
	{
		method_6(points, method_3());
	}

	internal override void vmethod_6(RectangleF bounds, PointF start, PointF end)
	{
		method_2(bounds, start, end);
	}

	internal override void vmethod_8(RectangleF bounds)
	{
		method_1(bounds);
	}

	internal override void vmethod_13(RectangleF bounds, PointF start, PointF end)
	{
		method_2(bounds, start, end);
	}

	internal override void vmethod_7(RectangleF bounds, PointF start, PointF end)
	{
		method_2(bounds, start, end);
	}

	internal override void vmethod_20(RectangleF bounds, SizeF ellipse)
	{
		method_1(bounds);
	}

	internal override void vmethod_22(RectangleF srcBounds, RectangleF dstBounds, byte[] imageBytes)
	{
		method_1(dstBounds);
	}

	internal override void vmethod_25(RectangleF srcRectangle, RectangleF destRectangle, Class6002 matrix, Class5998 color, Enum862 rop, byte[] bytes)
	{
		smethod_0();
	}

	internal override void vmethod_26()
	{
		smethod_0();
	}

	internal override void vmethod_27()
	{
		smethod_0();
	}

	internal override void vmethod_28()
	{
		smethod_0();
	}

	internal override void vmethod_29()
	{
		smethod_0();
	}

	internal override void vmethod_30()
	{
		smethod_0();
	}

	internal override void vmethod_31()
	{
		smethod_0();
	}

	internal override void vmethod_32()
	{
		smethod_0();
	}

	internal override void vmethod_33(Enum864 mode)
	{
		smethod_0();
	}

	internal override void vmethod_34(Enum844 mode)
	{
		smethod_0();
	}

	public override void vmethod_35(bool closed)
	{
	}

	private static void smethod_0()
	{
		throw new InvalidOperationException("Metafile size scanning is expected to be used for WMF only.");
	}

	private void method_0(PointF origin, string text)
	{
		Class6490 dC = class6485_0.DC;
		SizeF sizeF = dC.method_0(text);
		sizeF = new SizeF(sizeF.Width + (float)(dC.CharacterExtra * text.Length), sizeF.Height);
		PointF[] array = new PointF[1] { origin };
		Class6002 @class = dC.method_7(array, sizeF, dC.Font);
		origin = array[0];
		PointF[] points = new PointF[4]
		{
			new PointF(origin.X, origin.Y),
			new PointF(origin.X + sizeF.Width, origin.Y),
			new PointF(origin.X, origin.Y + sizeF.Height),
			new PointF(origin.X + sizeF.Width, origin.Y + sizeF.Height)
		};
		@class.method_3(points);
		method_7(points, 0f);
	}

	private void method_1(RectangleF bounds)
	{
		float scope = method_3();
		method_5(new PointF[2]
		{
			new PointF(bounds.X, bounds.Y),
			new PointF(bounds.X + bounds.Width, bounds.Y + bounds.Height)
		}, scope);
	}

	private void method_2(RectangleF bounds, PointF start, PointF end)
	{
		float scope = method_3();
		method_5(new PointF[2] { start, end }, scope);
		PointF pointF = new PointF(bounds.X, bounds.Y);
		PointF pointF2 = new PointF(bounds.X + bounds.Width, bounds.Y + bounds.Height);
		PointF pointF3 = new PointF((pointF.X + pointF2.X) / 2f, (pointF.Y + pointF2.Y) / 2f);
		start = new PointF(start.X - pointF3.X, start.Y - pointF3.Y);
		end = new PointF(end.X - pointF3.X, end.Y - pointF3.Y);
		int num = smethod_1(start);
		int num2 = smethod_1(end);
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
				if (!(end.X < start.X) || !(end.Y < start.Y))
				{
					method_4(new PointF(pointF2.X, pointF3.Y), scope);
					method_4(new PointF(pointF3.X, pointF2.Y), scope);
					method_4(new PointF(pointF.X, pointF3.Y), scope);
					method_4(new PointF(pointF3.X, pointF.Y), scope);
				}
				break;
			case 2:
				method_4(new PointF(pointF3.X, pointF.Y), scope);
				break;
			case 3:
				method_4(new PointF(pointF.X, pointF3.Y), scope);
				method_4(new PointF(pointF3.X, pointF.Y), scope);
				break;
			case 4:
				method_4(new PointF(pointF3.X, pointF2.Y), scope);
				method_4(new PointF(pointF.X, pointF3.Y), scope);
				method_4(new PointF(pointF3.X, pointF.Y), scope);
				break;
			}
			break;
		case 2:
			switch (num2)
			{
			default:
				throw new InvalidOperationException("Unknown quarter.");
			case 1:
				method_4(new PointF(pointF2.X, pointF3.Y), scope);
				method_4(new PointF(pointF3.X, pointF2.Y), scope);
				method_4(new PointF(pointF.X, pointF3.Y), scope);
				break;
			case 2:
				if (!(end.X < start.X) || !(end.Y > start.Y))
				{
					method_4(new PointF(pointF3.X, pointF.Y), scope);
					method_4(new PointF(pointF2.X, pointF3.Y), scope);
					method_4(new PointF(pointF3.X, pointF2.Y), scope);
					method_4(new PointF(pointF.X, pointF3.Y), scope);
				}
				break;
			case 3:
				method_4(new PointF(pointF.X, pointF3.Y), scope);
				break;
			case 4:
				method_4(new PointF(pointF3.X, pointF2.Y), scope);
				method_4(new PointF(pointF.X, pointF3.Y), scope);
				break;
			}
			break;
		case 3:
			switch (num2)
			{
			default:
				throw new InvalidOperationException("Unknown quarter.");
			case 1:
				method_4(new PointF(pointF2.X, pointF3.Y), scope);
				method_4(new PointF(pointF3.X, pointF2.Y), scope);
				break;
			case 2:
				method_4(new PointF(pointF3.X, pointF.Y), scope);
				method_4(new PointF(pointF2.X, pointF3.Y), scope);
				method_4(new PointF(pointF3.X, pointF2.Y), scope);
				break;
			case 3:
				if (!(end.X > start.X) || !(end.Y > start.Y))
				{
					method_4(new PointF(pointF.X, pointF3.Y), scope);
					method_4(new PointF(pointF3.X, pointF.Y), scope);
					method_4(new PointF(pointF2.X, pointF3.Y), scope);
					method_4(new PointF(pointF3.X, pointF2.Y), scope);
				}
				break;
			case 4:
				method_4(new PointF(pointF3.X, pointF2.Y), scope);
				break;
			}
			break;
		case 4:
			switch (num2)
			{
			default:
				throw new InvalidOperationException("Unknown quarter.");
			case 1:
				method_4(new PointF(pointF2.X, pointF3.Y), scope);
				break;
			case 2:
				method_4(new PointF(pointF3.X, pointF.Y), scope);
				method_4(new PointF(pointF2.X, pointF3.Y), scope);
				break;
			case 3:
				method_4(new PointF(pointF.X, pointF3.Y), scope);
				method_4(new PointF(pointF3.X, pointF.Y), scope);
				method_4(new PointF(pointF2.X, pointF3.Y), scope);
				break;
			case 4:
				if (!(end.X > start.X) || !(end.Y < start.Y))
				{
					method_4(new PointF(pointF3.X, pointF2.Y), scope);
					method_4(new PointF(pointF.X, pointF3.Y), scope);
					method_4(new PointF(pointF3.X, pointF.Y), scope);
					method_4(new PointF(pointF2.X, pointF3.Y), scope);
				}
				break;
			}
			break;
		}
	}

	private static int smethod_1(PointF point)
	{
		if (point.X > 0f && point.Y >= 0f)
		{
			return 1;
		}
		if (point.X <= 0f && point.Y > 0f)
		{
			return 2;
		}
		if (point.X < 0f && point.Y <= 0f)
		{
			return 3;
		}
		return 4;
	}

	private float method_3()
	{
		Class6003 pen = class6485_0.DC.Pen;
		if (pen == null)
		{
			return 0f;
		}
		return pen.Width / 2f;
	}

	internal void method_4(PointF point, float scope)
	{
		PointF[] array = new PointF[1] { point };
		class6485_0.DC.Transform.method_3(array);
		point = array[0];
		method_8(point, scope);
	}

	internal void method_5(PointF[] points, float scope)
	{
		class6485_0.DC.Transform.method_3(points);
		for (int i = 0; i < points.Length; i++)
		{
			method_8(points[i], scope);
		}
	}

	internal void method_6(PointF[][] points, float scope)
	{
		for (int i = 0; i < points.Length; i++)
		{
			method_5(points[i], scope);
		}
	}

	internal void method_7(PointF[] points, float scope)
	{
		for (int i = 0; i < points.Length; i++)
		{
			method_8(points[i], scope);
		}
	}

	private void method_8(PointF point, float scope)
	{
		float_0 = Math.Min(float_0, point.X - scope);
		float_1 = Math.Min(float_1, point.Y - scope);
		float_2 = Math.Max(float_2, point.X + scope);
		float_3 = Math.Max(float_3, point.Y + scope);
	}
}
