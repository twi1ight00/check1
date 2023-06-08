using System.Collections.Generic;
using System.Drawing;
using ns235;

namespace ns264;

internal class Class6484
{
	internal static Class6217 smethod_0(PointF[] points, bool closed)
	{
		Class6217 @class = new Class6217();
		Class6218 node = Class6218.smethod_0(points, closed);
		@class.Add(node);
		return @class;
	}

	internal static Class6217 smethod_1(PointF[][] pointsPoints, bool closed)
	{
		Class6217 @class = new Class6217();
		foreach (PointF[] points in pointsPoints)
		{
			Class6218 node = Class6218.smethod_0(points, closed);
			@class.Add(node);
		}
		return @class;
	}

	internal static Class6217 smethod_2(PointF[] points)
	{
		Class6217 @class = new Class6217();
		Class6218 node = Class6218.smethod_3(points);
		@class.Add(node);
		return @class;
	}

	internal static Class6217 smethod_3(RectangleF bounds, PointF start, PointF end)
	{
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		@class.Add(class2);
		Class6173 arc = new Class6174().method_0(bounds, start, end);
		class2.method_5(arc);
		return @class;
	}

	internal static Class6217 smethod_4(RectangleF bounds, float startAngle, float sweepAngle)
	{
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		@class.Add(class2);
		Class6173 arc = new Class6173(bounds, startAngle, sweepAngle);
		class2.method_5(arc);
		return @class;
	}

	internal static Class6217 smethod_5(RectangleF bounds)
	{
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		@class.Add(class2);
		Class6173 arc = new Class6173(bounds);
		class2.method_5(arc);
		return @class;
	}

	internal static Class6217 smethod_6(RectangleF bounds, PointF start, PointF end)
	{
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		@class.Add(class2);
		Class6173 class3 = new Class6174().method_1(bounds, start, end, Enum795.const_1);
		class2.method_5(class3);
		Class6223 class4 = new Class6223();
		class4.Points.Add(class3.Center);
		class4.Points.Add(class3.method_0());
		class2.Add(class4);
		return @class;
	}

	internal static Class6217 smethod_7(RectangleF bounds, float startAngle, float sweepAngle)
	{
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		@class.Add(class2);
		Class6173 class3 = new Class6173(bounds, startAngle, sweepAngle);
		class2.method_5(class3);
		Class6223 class4 = new Class6223();
		class4.Points.Add(class3.Center);
		class4.Points.Add(class3.method_0());
		class2.Add(class4);
		return @class;
	}

	internal static Class6217 smethod_8(RectangleF bounds, PointF start, PointF end)
	{
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		@class.Add(class2);
		Class6173 class3 = new Class6174().method_1(bounds, start, end, Enum795.const_1);
		class2.method_5(class3);
		Class6223 class4 = new Class6223();
		class4.Points.Add(class3.method_0());
		class2.Add(class4);
		return @class;
	}

	internal static Class6217 smethod_9(RectangleF rect, SizeF ellipse)
	{
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		@class.Add(class2);
		SizeF sizeF = new SizeF(ellipse.Width / 2f, ellipse.Height / 2f);
		Class6223 class3 = new Class6223();
		class3.Points.Add(new PointF(rect.Left + sizeF.Width, rect.Top));
		class3.Points.Add(new PointF(rect.Right - sizeF.Width, rect.Top));
		class2.Add(class3);
		Class6174 class4 = new Class6174();
		Class6173 arc = class4.method_0(new RectangleF(rect.Right - ellipse.Width, rect.Top, ellipse.Width, ellipse.Height), new PointF(rect.Right - sizeF.Width, rect.Top), new PointF(rect.Right, rect.Top + sizeF.Height));
		class2.method_5(arc);
		Class6223 class5 = new Class6223();
		class5.Points.Add(new PointF(rect.Right, rect.Bottom - sizeF.Height));
		class2.Add(class5);
		Class6173 arc2 = class4.method_0(new RectangleF(rect.Right - ellipse.Width, rect.Bottom - ellipse.Height, ellipse.Width, ellipse.Height), new PointF(rect.Right, rect.Bottom - sizeF.Height), new PointF(rect.Right - sizeF.Width, rect.Bottom));
		class2.method_5(arc2);
		Class6223 class6 = new Class6223();
		class6.Points.Add(new PointF(rect.Left + sizeF.Width, rect.Bottom));
		class2.Add(class6);
		Class6173 arc3 = class4.method_0(new RectangleF(rect.Left, rect.Bottom - ellipse.Height, ellipse.Width, ellipse.Height), new PointF(rect.Left + sizeF.Width, rect.Bottom), new PointF(rect.Left, rect.Bottom - sizeF.Height));
		class2.method_5(arc3);
		Class6223 class7 = new Class6223();
		class7.Points.Add(new PointF(rect.Left, rect.Top + sizeF.Height));
		class2.Add(class7);
		Class6173 arc4 = class4.method_0(new RectangleF(rect.Left, rect.Top, ellipse.Width, ellipse.Height), new PointF(rect.Left, rect.Top + sizeF.Height), new PointF(rect.Left + sizeF.Width, rect.Top));
		class2.method_5(arc4);
		return @class;
	}

	private static PointF[] smethod_10(PointF[] points, int startPointIndex, float tension)
	{
		PointF[] array = new PointF[4];
		int num = startPointIndex - 1;
		if (num < 0)
		{
			num = 0;
		}
		int num2 = startPointIndex + 1;
		int num3 = startPointIndex + 2;
		if (num3 > points.Length - 1)
		{
			num3 = num2;
		}
		PointF pointF = points[startPointIndex];
		PointF pointF2 = points[num2];
		PointF pointF3 = new PointF(tension * (points[num2].X - points[num].X), tension * (points[num2].Y - points[num].Y));
		PointF pointF4 = new PointF(tension * (points[num3].X - points[startPointIndex].X), tension * (points[num3].Y - points[startPointIndex].Y));
		PointF pointF5 = new PointF((pointF3.X + 3f * pointF.X) / 3f, (pointF3.Y + 3f * pointF.Y) / 3f);
		PointF pointF6 = new PointF((3f * pointF2.X - pointF4.X) / 3f, (3f * pointF2.Y - pointF4.Y) / 3f);
		array[0] = pointF;
		array[1] = pointF5;
		array[2] = pointF6;
		array[3] = pointF2;
		return array;
	}

	internal static PointF[] smethod_11(PointF[] points, bool closed, float tension)
	{
		int num = points.Length - 1;
		if (closed)
		{
			num++;
		}
		PointF[] array = new PointF[num * 3 + 1];
		PointF[] array2;
		if (closed)
		{
			array2 = new PointF[points.Length + 3];
			points.CopyTo(array2, 1);
			ref PointF reference = ref array2[0];
			reference = points[points.Length - 1];
			ref PointF reference2 = ref array2[points.Length + 1];
			reference2 = array2[1];
			ref PointF reference3 = ref array2[points.Length + 2];
			reference3 = array2[2];
		}
		else
		{
			array2 = points;
		}
		for (int i = 0; i < num; i++)
		{
			int startPointIndex = (closed ? (i + 1) : i);
			PointF[] array3 = smethod_10(array2, startPointIndex, tension);
			ref PointF reference4 = ref array[i * 3];
			reference4 = array3[0];
			ref PointF reference5 = ref array[i * 3 + 1];
			reference5 = array3[1];
			ref PointF reference6 = ref array[i * 3 + 2];
			reference6 = array3[2];
			ref PointF reference7 = ref array[i * 3 + 3];
			reference7 = array3[3];
		}
		return array;
	}

	internal static Class6217 smethod_12(PointF[] points, Enum856[] pointTypes, bool closed)
	{
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		@class.Add(class2);
		class2.IsClosed = closed;
		List<PointF> list = null;
		Enum856 @enum = Enum856.flag_0;
		for (int i = 0; i < points.Length; i++)
		{
			if (pointTypes[i] == Enum856.flag_0)
			{
				list = new List<PointF>();
			}
			if (@enum != 0 && @enum != pointTypes[i])
			{
				smethod_13(class2, list, @enum);
				list = new List<PointF>();
				if (i > 0)
				{
					list.Add(points[i - 1]);
				}
			}
			list?.Add(points[i]);
			@enum = pointTypes[i];
			if (i == points.Length - 1)
			{
				smethod_13(class2, list, @enum);
			}
		}
		return @class;
	}

	private static void smethod_13(Class6218 figure, List<PointF> pt, Enum856 pointType)
	{
		if (pt != null)
		{
			switch (pointType)
			{
			case Enum856.flag_1:
				figure.method_1(pt.ToArray());
				break;
			case Enum856.flag_2:
				figure.method_4(pt.ToArray());
				break;
			case (Enum856)2:
				break;
			}
		}
	}
}
