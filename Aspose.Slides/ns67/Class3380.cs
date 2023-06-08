using System;
using System.Collections.Generic;
using System.Drawing;

namespace ns67;

internal class Class3380 : Class3378
{
	private double double_0;

	private PointF[] pointF_0;

	private double[] double_1;

	public override double Length => double_0;

	public override Class3378 vmethod_0()
	{
		return new Class3380(double_0, pointF_0, double_1);
	}

	public override Class3378 vmethod_1(double distance)
	{
		PointF[] array = new PointF[pointF_0.Length];
		double[] array2 = new double[pointF_0.Length];
		PointF pointF = pointF_0[0];
		for (int i = 0; i < pointF_0.Length; i++)
		{
			PointF pointF2 = pointF_0[i];
			PointF pointF3 = ((i == 0) ? pointF_0[i + 1] : pointF2);
			Struct158 @struct = new Struct158(pointF.X - pointF3.X, pointF.Y - pointF3.Y).method_1();
			ref PointF reference = ref array[i];
			reference = new PointF((float)((double)pointF2.X - @struct.Dy * distance), (float)((double)pointF2.Y + @struct.Dx * distance));
			pointF = ((i == 0) ? pointF : pointF3);
		}
		double num = 0.0;
		for (int j = 1; j < pointF_0.Length; j++)
		{
			array2[j] = method_2(array[j - 1], array[j]);
			num += array2[j];
		}
		return new Class3380(num, array, array2);
	}

	public override Struct159 vmethod_2(double percent)
	{
		method_0(percent, out var start, out var end, out var offset);
		return new Struct159((double)start.X + (double)(end.X - start.X) * offset, (double)start.Y + (double)(end.Y - start.Y) * offset);
	}

	public override Struct158 vmethod_3(double percent, double length, bool isOutside)
	{
		method_0(percent, out var start, out var end, out var _);
		Struct158 @struct = Struct159.smethod_0(new Struct159(start.X, start.Y), new Struct159(end.X, end.Y)).method_1();
		if (!isOutside)
		{
			return new Struct158(@struct.Dy * length, (0.0 - @struct.Dx) * length);
		}
		return new Struct158((0.0 - @struct.Dy) * length, @struct.Dx * length);
	}

	public Class3380(Struct159 start, Struct159 p1, Struct159 p2, Struct159 end)
	{
		double_0 = method_1(start, p1, p2, end);
	}

	private Class3380(double totalLength, PointF[] points, double[] segmentsLength)
	{
		double_0 = totalLength;
		pointF_0 = points;
		double_1 = segmentsLength;
	}

	private void method_0(double percent, out PointF start, out PointF end, out double offset)
	{
		double num = 0.0;
		double num2 = percent * double_0;
		start = pointF_0[0];
		int num3 = 1;
		double num4;
		while (true)
		{
			if (num3 < pointF_0.Length)
			{
				end = pointF_0[num3];
				num4 = double_1[num3];
				num += num4;
				if (!(num2 > num))
				{
					break;
				}
				start = end;
				num3++;
				continue;
			}
			int num5 = pointF_0.Length - 1;
			num4 = double_1[num5];
			start = pointF_0[num5 - 1];
			end = pointF_0[num5];
			num = double_0 - num4;
			offset = ((num4 != 0.0) ? ((num4 - (num - num2)) / num4) : 0.0);
			return;
		}
		offset = ((num4 != 0.0) ? ((num4 - (num - num2)) / num4) : 0.0);
	}

	private double method_1(Struct159 start, Struct159 p1, Struct159 p2, Struct159 end)
	{
		List<PointF> points = new List<PointF>();
		Class3029 @class = new Class3029();
		@class.method_0(start.method_1(), p1.method_1(), p2.method_1(), end.method_1(), ref points);
		pointF_0 = points.ToArray();
		double_1 = new double[points.Count];
		double num = 0.0;
		for (int i = 1; i < pointF_0.Length; i++)
		{
			double_1[i] = method_2(pointF_0[i - 1], pointF_0[i]);
			num += double_1[i];
		}
		return num;
	}

	private double method_2(PointF start, PointF end)
	{
		float num = start.X - end.X;
		float num2 = start.Y - end.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}
}
