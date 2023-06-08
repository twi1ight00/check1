using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns19;

internal class Class881
{
	internal long[] long_0;

	internal Enum91[] enum91_0;

	internal long long_1;

	internal long long_2;

	internal Enum92 enum92_0 = Enum92.const_1;

	internal bool bool_0 = true;

	internal bool bool_1 = true;

	internal long Width
	{
		get
		{
			if (long_1 <= 0)
			{
				return 1L;
			}
			return long_1;
		}
	}

	internal long Height
	{
		get
		{
			if (long_2 <= 0)
			{
				return 1L;
			}
			return long_2;
		}
	}

	internal Class881(Enum91[] enum91_1, long[] long_3, long long_4, long long_5, Enum92 enum92_1, bool bool_2, bool bool_3)
	{
		long_1 = long_4;
		long_2 = long_5;
		enum91_0 = enum91_1;
		long_0 = long_3;
		enum92_0 = enum92_1;
		bool_0 = bool_2;
		bool_1 = bool_3;
	}

	public GraphicsPath method_0(Class878 geometry, double[] guideValues, Enum90[] guideValueFlags, float tx, float ty, float width, float height, out bool hasClosedFigures)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = 0;
		float num2 = 0f;
		float num3 = 0f;
		long width2 = Width;
		long height2 = Height;
		float num4 = 1f;
		float num5 = 1f;
		if (long_1 > 0)
		{
			num4 = width / (float)width2;
		}
		if (long_2 > 0)
		{
			num5 = height / (float)height2;
		}
		hasClosedFigures = false;
		Enum91[] array = enum91_0;
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i])
			{
			case Enum91.const_0:
				graphicsPath.CloseFigure();
				hasClosedFigures = true;
				break;
			case Enum91.const_1:
				graphicsPath.StartFigure();
				num2 = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num4 + tx;
				num3 = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num5 + ty;
				break;
			case Enum91.const_2:
			{
				float x = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num4 + tx;
				float y = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num5 + ty;
				graphicsPath.AddLine(num2, num3, x, y);
				num2 = x;
				num3 = y;
				break;
			}
			case Enum91.const_3:
			{
				float num8 = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num4;
				float num9 = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num5;
				float num10 = geometry.method_5(guideValues, guideValueFlags, long_0[num++]);
				float num11 = geometry.method_5(guideValues, guideValueFlags, long_0[num++]);
				if (!((double)(Math.Abs(num8) + Math.Abs(num9)) < 0.005))
				{
					double num12 = (double)(num10 / 180f) * Math.PI;
					if ((double)(num4 / num5) < 0.9999 || (double)(num4 / num5) > 1.0001)
					{
						double num13 = (double)((num10 + num11) / 180f) * Math.PI;
						double x3 = Math.Cos(num12) * (double)num4;
						double y3 = Math.Sin(num12) * (double)num5;
						num12 = Math.Atan2(y3, x3);
						num10 = (float)(num12 * 180.0 / Math.PI);
						x3 = Math.Cos(num13) * (double)num4;
						y3 = Math.Sin(num13) * (double)num5;
						num13 = Math.Atan2(y3, x3);
						float num14 = (float)(num13 * 180.0 / Math.PI) - num10;
						num11 = ((num11 < 0f && num14 > 0f) ? (num14 - 360f) : ((!(num11 > 0f) || !(num14 < 0f)) ? num14 : (num14 + 360f)));
					}
					double num15 = Math.Cos(num12);
					double num16 = Math.Sin(num12);
					double num17 = Math.Sqrt(1.0 / (num15 * num15 / (double)num8 / (double)num8 + num16 * num16 / (double)num9 / (double)num9));
					float x = (float)((double)num2 - num15 * num17);
					float y = (float)((double)num3 - num16 * num17);
					graphicsPath.AddArc(x - num8, y - num9, num8 * 2f, num9 * 2f, num10, num11);
					if (graphicsPath.PointCount < 2)
					{
						num2 = (num3 = 0f);
						break;
					}
					PointF pointF = graphicsPath.PathPoints[graphicsPath.PointCount - 1];
					num2 = pointF.X;
					num3 = pointF.Y;
				}
				break;
			}
			case Enum91.const_4:
			{
				float x = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num4 + tx;
				float y = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num5 + ty;
				float x2 = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num4 + tx;
				float y2 = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num5 + ty;
				graphicsPath.AddBezier(num2, num3, num2 + (x - num2) * 2f / 3f, num3 + (y - num3) * 2f / 3f, x2 + (x - x2) * 2f / 3f, y2 + (y - y2) * 2f / 3f, x2, y2);
				num2 = x2;
				num3 = y2;
				break;
			}
			case Enum91.const_5:
			{
				float x = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num4 + tx;
				float y = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num5 + ty;
				float x2 = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num4 + tx;
				float y2 = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num5 + ty;
				float num6 = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num4 + tx;
				float num7 = geometry.method_2(guideValues, guideValueFlags, long_0[num++]) * num5 + ty;
				graphicsPath.AddBezier(num2, num3, x, y, x2, y2, num6, num7);
				num2 = num6;
				num3 = num7;
				break;
			}
			}
		}
		return graphicsPath;
	}
}
