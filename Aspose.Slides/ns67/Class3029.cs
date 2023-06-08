using System;
using System.Collections.Generic;
using System.Drawing;

namespace ns67;

internal class Class3029
{
	private double double_0 = Math.PI / 36.0;

	private double double_1 = Math.PI * 11.0 / 12.0;

	private double double_2 = 0.1;

	private double double_3 = 1E-30;

	private bool bool_0 = true;

	private ulong ulong_0 = 32uL;

	private double double_4 = Math.Pow(4762.0, 2.0);

	public bool CutCurveTrailers
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public double DistanceToleranceSquare
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public void method_0(PointF p1, PointF p2, PointF p3, PointF p4, ref List<PointF> points)
	{
		List<PointF> points2 = new List<PointF>();
		points2.Add(new PointF(p1.X, p1.Y));
		method_3(p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y, p4.X, p4.Y, 0uL, ref points2);
		points2.Add(new PointF(p4.X, p4.Y));
		if (bool_0)
		{
			double num = Math.Sqrt(Math.Pow(p1.X - p2.X, 2.0) + Math.Pow(p1.Y - p2.Y, 2.0));
			double num2 = Math.Sqrt(Math.Pow(p4.X - p3.X, 2.0) + Math.Pow(p4.Y - p3.Y, 2.0));
			double num3 = num / num2;
			double num4 = num2 / num;
			double num5 = 54400.0;
			method_1(ref points2, (float)(num5 * num3), side: false);
			method_1(ref points2, (float)(num5 * num4), side: true);
		}
		points.AddRange(points2);
	}

	private void method_1(ref List<PointF> points, float delta, bool side)
	{
		int count = points.Count;
		if (count < 2 || delta <= 0f)
		{
			return;
		}
		double num = delta * delta;
		if (side)
		{
			int num2 = count - 1;
			PointF cp = points[num2];
			while (num2 > 0)
			{
				num2--;
				PointF lp = points[num2];
				double num3 = Math.Pow(lp.X - cp.X, 2.0) + Math.Pow(lp.Y - cp.Y, 2.0);
				if (num3 <= num)
				{
					if (!(Math.Abs(Math.Abs(num3) - Math.Abs(num)) >= 1E-10))
					{
						if (num2 + 2 < points.Count)
						{
							points.RemoveRange(num2 + 1, points.Count - 2 - num2);
						}
						return;
					}
					continue;
				}
				PointF item = method_2(lp, points[num2 + 1], cp, delta);
				if (num2 + 2 < points.Count)
				{
					points.RemoveRange(num2 + 1, points.Count - 2 - num2);
				}
				points.Insert(points.Count - 1, item);
				return;
			}
		}
		else
		{
			int num2 = 0;
			PointF cp = points[0];
			while (num2 < count - 1)
			{
				num2++;
				PointF lp = points[num2];
				double num3 = Math.Pow(lp.X - cp.X, 2.0) + Math.Pow(lp.Y - cp.Y, 2.0);
				if (num3 <= num)
				{
					if (!(Math.Abs(Math.Abs(num3) - Math.Abs(num)) >= 1E-10))
					{
						if (num2 > 1)
						{
							points.RemoveRange(1, num2 - 1);
						}
						return;
					}
					continue;
				}
				PointF item = method_2(lp, points[num2 - 1], cp, delta);
				if (num2 > 1)
				{
					points.RemoveRange(1, num2 - 1);
				}
				points.Insert(1, item);
				return;
			}
		}
		points.RemoveRange(1, points.Count - 2);
	}

	private PointF method_2(PointF lp1, PointF lp2, PointF cp, float r)
	{
		PointF[] array = new PointF[2];
		if ((double)Math.Abs(lp1.X - lp2.X) < 1E-10)
		{
			if (Math.Abs(lp1.X - cp.X) > r)
			{
				return cp;
			}
			double num = Math.Sqrt(r * r - (lp1.X - cp.X) * (lp1.X - cp.X));
			ref PointF reference = ref array[0];
			reference = new PointF(lp1.X, (float)((double)cp.Y - num));
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(lp1.X, (float)((double)cp.Y + num));
		}
		else
		{
			double num2 = (lp1.Y - lp2.Y) / (lp1.X - lp2.X);
			double num3 = (double)lp1.Y - num2 * (double)lp1.X;
			double num4 = Math.Pow(2.0 * num2 * num3 - (double)(2f * cp.X) - (double)(2f * cp.Y) * num2, 2.0) - (4.0 + 4.0 * num2 * num2) * (num3 * num3 - (double)(r * r) + (double)(cp.X * cp.X) + (double)(cp.Y * cp.Y) - (double)(2f * cp.Y) * num3);
			if (num4 < 0.0)
			{
				return cp;
			}
			num4 = Math.Sqrt(num4);
			double num5 = (0.0 - (2.0 * num2 * num3 - (double)(2f * cp.X) - (double)(2f * cp.Y) * num2) + num4) / (2.0 + 2.0 * num2 * num2);
			double num = num2 * num5 + num3;
			if (Math.Abs(num4) < 1E-10)
			{
				return new PointF((float)num5, (float)num);
			}
			ref PointF reference3 = ref array[0];
			reference3 = new PointF((float)num5, (float)num);
			num5 = (0.0 - (2.0 * num2 * num3 - (double)(2f * cp.X) - (double)(2f * cp.Y) * num2) - num4) / (2.0 + 2.0 * num2 * num2);
			num = num2 * num5 + num3;
			ref PointF reference4 = ref array[1];
			reference4 = new PointF((float)num5, (float)num);
		}
		double num6 = Math.Pow(array[0].X - lp1.X, 2.0) + Math.Pow(array[0].Y - lp1.Y, 2.0) + Math.Pow(array[0].X - lp2.X, 2.0) + Math.Pow(array[0].Y - lp2.Y, 2.0);
		double num7 = Math.Pow(array[1].X - lp1.X, 2.0) + Math.Pow(array[1].Y - lp1.Y, 2.0) + Math.Pow(array[1].X - lp2.X, 2.0) + Math.Pow(array[1].Y - lp2.Y, 2.0);
		if (num6 < num7)
		{
			return array[0];
		}
		return array[1];
	}

	private void method_3(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, ulong level, ref List<PointF> points)
	{
		if (level > ulong_0)
		{
			return;
		}
		double num = (x1 + x2) / 2.0;
		double num2 = (y1 + y2) / 2.0;
		double num3 = (x2 + x3) / 2.0;
		double num4 = (y2 + y3) / 2.0;
		double num5 = (x3 + x4) / 2.0;
		double num6 = (y3 + y4) / 2.0;
		double num7 = (num + num3) / 2.0;
		double num8 = (num2 + num4) / 2.0;
		double num9 = (num3 + num5) / 2.0;
		double num10 = (num4 + num6) / 2.0;
		double num11 = (num7 + num9) / 2.0;
		double num12 = (num8 + num10) / 2.0;
		if (level > 0L)
		{
			double num13 = x4 - x1;
			double num14 = y4 - y1;
			double num15 = Math.Abs((x2 - x4) * num14 - (y2 - y4) * num13);
			double num16 = Math.Abs((x3 - x4) * num14 - (y3 - y4) * num13);
			if (num15 > double_3 && num16 > double_3)
			{
				if ((num15 + num16) * (num15 + num16) <= double_4 * (num13 * num13 + num14 * num14))
				{
					if (double_0 < double_2)
					{
						points.Add(new PointF((float)num11, (float)num12));
						return;
					}
					double num17 = Math.Atan2(y3 - y2, x3 - x2);
					double num18 = Math.Abs(num17 - Math.Atan2(y2 - y1, x2 - x1));
					double num19 = Math.Abs(Math.Atan2(y4 - y3, x4 - x3) - num17);
					if (num18 >= Math.PI)
					{
						num18 = Math.PI * 2.0 - num18;
					}
					if (num19 >= Math.PI)
					{
						num19 = Math.PI * 2.0 - num19;
					}
					if (num18 + num19 < double_0)
					{
						points.Add(new PointF((float)num11, (float)num12));
						return;
					}
					if (Math.Abs(double_1) > 1E-10)
					{
						if (num18 > double_1)
						{
							points.Add(new PointF((float)x2, (float)y2));
							return;
						}
						if (num19 > double_1)
						{
							points.Add(new PointF((float)x3, (float)y3));
							return;
						}
					}
				}
			}
			else if (num15 > double_3)
			{
				if (num15 * num15 <= double_4 * (num13 * num13 + num14 * num14))
				{
					if (double_0 < double_2)
					{
						points.Add(new PointF((float)num11, (float)num12));
						return;
					}
					double num18 = Math.Abs(Math.Atan2(y3 - y2, x3 - x2) - Math.Atan2(y2 - y1, x2 - x1));
					if (num18 >= Math.PI)
					{
						num18 = Math.PI * 2.0 - num18;
					}
					if (num18 < double_0)
					{
						points.Add(new PointF((float)x2, (float)y2));
						points.Add(new PointF((float)x3, (float)y3));
						return;
					}
					if (Math.Abs(double_1) > 1E-10 && num18 > double_1)
					{
						points.Add(new PointF((float)x2, (float)y2));
						return;
					}
				}
			}
			else if (num16 > double_3)
			{
				if (num16 * num16 <= double_4 * (num13 * num13 + num14 * num14))
				{
					if (double_0 < double_2)
					{
						points.Add(new PointF((float)num11, (float)num12));
						return;
					}
					double num18 = Math.Abs(Math.Atan2(y4 - y3, x4 - x3) - Math.Atan2(y3 - y2, x3 - x2));
					if (num18 >= Math.PI)
					{
						num18 = Math.PI * 2.0 - num18;
					}
					if (num18 < double_0)
					{
						points.Add(new PointF((float)x2, (float)y2));
						points.Add(new PointF((float)x3, (float)y3));
						return;
					}
					if (Math.Abs(double_1) > 1E-10 && num18 > double_1)
					{
						points.Add(new PointF((float)x3, (float)y3));
						return;
					}
				}
			}
			else
			{
				num13 = num11 - (x1 + x4) / 2.0;
				num14 = num12 - (y1 + y4) / 2.0;
				if (num13 * num13 + num14 * num14 <= double_4)
				{
					points.Add(new PointF((float)num11, (float)num12));
					return;
				}
			}
		}
		method_3(x1, y1, num, num2, num7, num8, num11, num12, level + 1L, ref points);
		method_3(num11, num12, num9, num10, num5, num6, x4, y4, level + 1L, ref points);
	}
}
