using System;
using ns134;
using ns135;
using ns136;
using ns137;
using ns138;
using ns158;
using ns99;

namespace ns142;

internal class Class4622
{
	private Class4480 class4480_0;

	private int int_0;

	private double double_0;

	public Class4622(Class4480 glyph, int deviceDPI, double fontSizePoints)
	{
		class4480_0 = glyph;
		int_0 = deviceDPI;
		double_0 = fontSizePoints;
	}

	public Class4621 method_0()
	{
		Class4621 @class = new Class4621(int_0, double_0);
		int sourceResolution = class4480_0.SourceResolution;
		double fontSizePixels = @class.FontSizePixels;
		@class.Sbx = (int)(class4480_0.LeftSidebearingX * fontSizePixels) / sourceResolution;
		@class.Sby = (int)(class4480_0.LeftSidebearingY * fontSizePixels) / sourceResolution;
		@class.Width = (int)(class4480_0.WidthVectorX * fontSizePixels) / sourceResolution;
		if (Class4623.Instance.UseHinting && class4480_0.HintCollections.Count > 0)
		{
			foreach (Class4609 hintCollection in class4480_0.HintCollections)
			{
				method_7(hintCollection, @class);
			}
			method_5(class4480_0.Path.Segments);
		}
		if (Class4623.Instance.Filling)
		{
			method_2(class4480_0.Path, @class, sourceResolution, fontSizePixels);
		}
		return @class;
	}

	public double method_1(double unscaledCoordinate)
	{
		double num = double_0 * (double)int_0 / 72.0;
		return (int)(unscaledCoordinate * num / (double)class4480_0.SourceResolution);
	}

	private void method_2(Class4618 path, Class4621 map, int resolution, double pixels)
	{
		double x = 0.0;
		double y = 0.0;
		foreach (Interface143 segment in path.Segments)
		{
			if (segment is Class4614 @class)
			{
				x = @class.X;
				y = @class.Y;
			}
			if (segment is Class4613 class2)
			{
				method_3(map, pixels, resolution, x, y, class2.X, class2.Y);
				x = class2.X;
				y = class2.Y;
			}
			if (segment is Class4611 class3)
			{
				method_3(map, pixels, resolution, x, y, class3.X, class3.Y);
				x = class3.X;
				y = class3.Y;
			}
			if (segment is Class4612 class4)
			{
				method_4(map, pixels, resolution, x, y, class4.X1, class4.Y1, class4.X2, class4.Y2, class4.X3, class4.Y3);
				x = class4.X3;
				y = class4.Y3;
			}
		}
	}

	private void method_3(Class4621 map, double pixels, int resolution, double x1, double y1, double x2, double y2)
	{
		double num = 0.0;
		double num2 = 0.0;
		int num3 = 0;
		if (x1 != x2)
		{
			for (double num4 = x1; (!(x2 > x1)) ? (num4 >= x2) : (num4 <= x2); num4 += ((x2 > x1) ? Class4623.Instance.DrawingPrecision_Lines : (0.0 - Class4623.Instance.DrawingPrecision_Lines)))
			{
				double num5 = (y2 - y1) * ((num4 - x1) / (x2 - x1)) + y1;
				if (num3 > 1)
				{
					smethod_0(map, pixels, resolution, num4, num5, num4 > num, num5 > num2);
				}
				num = num4;
				num2 = num5;
				num3++;
			}
			return;
		}
		for (double num6 = y1; (!(y2 > y1)) ? (num6 >= y2) : (num6 <= y2); num6 += ((y2 > y1) ? Class4623.Instance.DrawingPrecision_Lines : (0.0 - Class4623.Instance.DrawingPrecision_Lines)))
		{
			if (num3 > 1)
			{
				smethod_0(map, pixels, resolution, x1, num6, x1 > num, num6 > num2);
			}
			num = x1;
			num2 = num6;
			num3++;
		}
	}

	public void method_4(Class4621 map, double pixels, int resolution, double X1, double Y1, double X2, double Y2, double X3, double Y3, double X4, double Y4)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 3.0 * (X2 - X1);
		double num4 = 3.0 * (Y2 - Y1);
		double num5 = 3.0 * (X3 - X2) - num3;
		double num6 = 3.0 * (Y3 - Y2) - num4;
		double num7 = X4 - X1 - num3 - num5;
		double num8 = Y4 - Y1 - num4 - num6;
		int num9 = (int)Class4623.Instance.DrawingFlatness_Curves;
		double num10 = 1.0 / ((double)num9 - 1.0);
		for (int i = 0; i < num9; i++)
		{
			double num11 = (double)i * num10;
			double num12 = num7 * Math.Pow(num11, 3.0) + num5 * Math.Pow(num11, 2.0) + num3 * num11 + X1;
			double num13 = num8 * Math.Pow(num11, 3.0) + num6 * Math.Pow(num11, 2.0) + num4 * num11 + Y1;
			if (i > 1)
			{
				smethod_1(map, pixels, resolution, num12, num13, num12 > num, num13 > num2);
			}
			num = num12;
			num2 = num13;
		}
	}

	private static void smethod_0(Class4621 map, double pixels, int resolution, double x, double y, bool increaseX, bool increaseY)
	{
		if (Class4623.Instance.InvertCurvesDirection)
		{
			increaseX = !increaseX;
			increaseY = !increaseY;
		}
		double num = x * pixels / (double)resolution;
		double num2 = y * pixels / (double)resolution;
		double num3 = Math.Abs(num - (double)(int)num);
		double num4 = Math.Abs(num2 - (double)(int)num2);
		if (increaseY && increaseX)
		{
			if (num3 > 0.2 && num4 < 0.5)
			{
				map.method_0((int)num, (int)num2);
			}
		}
		else if (increaseY && !increaseX)
		{
			if (num3 > 0.3 && num4 > 0.5)
			{
				map.method_0((int)num, (int)num2);
			}
		}
		else if (!increaseY && increaseX)
		{
			if (num3 < 0.7 && num4 < 0.5)
			{
				map.method_0((int)num, (int)num2);
			}
		}
		else if (!increaseY && !increaseX && num3 < 0.9 && num4 > 0.5)
		{
			map.method_0((int)num, (int)num2);
		}
	}

	private static void smethod_1(Class4621 map, double pixels, int resolution, double x, double y, bool increaseX, bool increaseY)
	{
		if (Class4623.Instance.InvertCurvesDirection)
		{
			increaseX = !increaseX;
			increaseY = !increaseY;
		}
		double num = x * pixels / (double)resolution;
		double num2 = y * pixels / (double)resolution;
		double num3 = Math.Abs(num - (double)(int)num);
		double num4 = Math.Abs(num2 - (double)(int)num2);
		if (increaseY && increaseX)
		{
			if (num3 > 0.2 && num4 < 0.3)
			{
				map.method_0((int)num, (int)num2);
			}
			else if (num3 > 0.5 && num4 < 0.3)
			{
				map.method_0((int)num, (int)num2 + 1);
			}
		}
		else if (increaseY && !increaseX)
		{
			if (num3 > 0.5 && num4 > 0.5)
			{
				map.method_0((int)num, (int)num2);
			}
		}
		else if (!increaseY && increaseX)
		{
			if (num3 < 0.7 && num4 < 0.5)
			{
				map.method_0((int)num, (int)num2);
			}
		}
		else if (!increaseY && !increaseX && num3 < 0.6 && num4 > 0.5)
		{
			map.method_0((int)num, (int)num2);
		}
	}

	private void method_5(Class4617 segments)
	{
		foreach (Interface143 segment in segments)
		{
			if (segment is Class4614 @class)
			{
				if (@class.Hints != null)
				{
					@class.Y = smethod_3(@class, @class.Hints, @class.Y);
					@class.X = method_6(@class, @class.Hints, @class.X, @class.Y, class4480_0.Path.Segments);
				}
			}
			else if (segment is Class4613 class2)
			{
				if (class2.Hints != null)
				{
					class2.Y = smethod_3(class2, class2.Hints, class2.Y);
					class2.X = method_6(class2, class2.Hints, class2.X, class2.Y, class4480_0.Path.Segments);
				}
			}
			else if (segment is Class4612 class3)
			{
				if (class3.Hints != null)
				{
					class3.Y1 = smethod_3(class3, class3.Hints, class3.Y1);
					class3.X1 = method_6(class3, class3.Hints, class3.X1, class3.Y1, class4480_0.Path.Segments);
					class3.Y2 = smethod_3(class3, class3.Hints, class3.Y2);
					class3.X2 = method_6(class3, class3.Hints, class3.X2, class3.Y2, class4480_0.Path.Segments);
					class3.Y3 = smethod_3(class3, class3.Hints, class3.Y3);
					class3.X3 = method_6(class3, class3.Hints, class3.X3, class3.Y3, class4480_0.Path.Segments);
				}
			}
			else if (segment is Class4611 class4 && class4.Hints != null)
			{
				class4.Y = smethod_3(class4, class4.Hints, class4.Y);
				class4.X = method_6(class4, class4.Hints, class4.X, class4.Y, class4480_0.Path.Segments);
			}
		}
	}

	private double method_6(Interface143 command, Class4609 hints, double x, double y, Class4617 segments)
	{
		foreach (Interface140 hint in hints)
		{
			if (!(hint is Class4735 @class))
			{
				continue;
			}
			if (!@class.imethod_0(x))
			{
				if (!Class4623.Instance.DetectSymmetricBreaks)
				{
					continue;
				}
				smethod_2(@class, x, out var dx, out var atLeft);
				foreach (Interface143 segment in segments)
				{
					if (segment == command)
					{
						continue;
					}
					double dx2;
					bool atLeft2;
					if (segment is Class4614 class2)
					{
						if (Class4608.smethod_0(y, class2.Y, Class4623.Instance.EqualityPrecision))
						{
							smethod_2(@class, class2.X, out dx2, out atLeft2);
							if (atLeft != atLeft2 && Class4608.smethod_0(Math.Abs(dx), Math.Abs(dx2), Class4623.Instance.EqualityPrecision))
							{
								class2.X += @class.DeltaXCorrected;
								return x + @class.DeltaXCorrected;
							}
						}
					}
					else if (segment is Class4613 class3)
					{
						if (Class4608.smethod_0(y, class3.Y, Class4623.Instance.EqualityPrecision))
						{
							smethod_2(@class, class3.X, out dx2, out atLeft2);
							if (atLeft != atLeft2 && Class4608.smethod_0(Math.Abs(dx), Math.Abs(dx2), Class4623.Instance.EqualityPrecision))
							{
								class3.X += @class.DeltaXCorrected;
								return x + @class.DeltaXCorrected;
							}
						}
					}
					else if (segment is Class4611 class4 && Class4608.smethod_0(y, class4.Y, Class4623.Instance.EqualityPrecision))
					{
						smethod_2(@class, class4.X, out dx2, out atLeft2);
						if (atLeft != atLeft2 && Class4608.smethod_0(Math.Abs(dx), Math.Abs(dx2), Class4623.Instance.EqualityPrecision))
						{
							class4.X += @class.DeltaXCorrected;
							return x + @class.DeltaXCorrected;
						}
					}
				}
				continue;
			}
			return @class.imethod_1(x);
		}
		return x;
	}

	private static void smethod_2(Class4735 hint, double x, out double dx, out bool atLeft)
	{
		atLeft = false;
		if (x < hint.X)
		{
			atLeft = true;
			dx = hint.X - x;
		}
		else
		{
			dx = x - (hint.X + hint.DX);
		}
	}

	private static double smethod_3(Interface143 command, Class4609 hints, double y)
	{
		foreach (Interface140 hint in hints)
		{
			if (hint is Class4736 @class && @class.imethod_0(y))
			{
				return @class.imethod_1(y);
			}
		}
		return y;
	}

	private void method_7(Class4609 hints, Class4621 map)
	{
		int sourceResolution = class4480_0.SourceResolution;
		double fontSizePixels = map.FontSizePixels;
		double num = (double)sourceResolution / fontSizePixels;
		foreach (Interface140 hint in hints)
		{
			if (hint is Class4736 @class)
			{
				double num2 = @class.Y * fontSizePixels / (double)sourceResolution;
				double num3 = Math.Round(num2);
				double num4 = (@class.Y + @class.DYcorrected) * fontSizePixels / (double)sourceResolution;
				double num5 = Math.Round(num4);
				double num6 = Class4623.Instance.RasterizationGridPrecision;
				bool flag = false;
				if (Math.Abs(num2 - num3) < Math.Abs(num4 - num5))
				{
					if (@class.DYcorrected < 0.0)
					{
						num6 = 0.0 - num6;
					}
					@class.Ycorrected = (double)sourceResolution * num3 / fontSizePixels + num6;
					@class.DeltaYCorrected = @class.Ycorrected - @class.Y;
					flag = true;
				}
				else
				{
					if (@class.DYcorrected > 0.0)
					{
						num6 = 0.0 - num6;
					}
					@class.Ycorrected = (double)sourceResolution * num5 / fontSizePixels - @class.DYcorrected + num6;
					@class.DeltaYCorrected = @class.Ycorrected - @class.Y;
					flag = false;
				}
				if (!Class4623.Instance.HintWidthOptimization || !(Math.Abs(@class.DY) > num))
				{
					continue;
				}
				int num7 = (int)(@class.DY / num);
				if (num7 > 0 && @class.DY - (double)num7 * num < num / 2.0)
				{
					@class.DYcorrected = (double)num7 * num - Class4623.Instance.EqualityPrecision;
					if (@class.DY < 0.0)
					{
						@class.DYcorrected = 0.0 - @class.DYcorrected;
					}
					if (!flag)
					{
						double num8 = Math.Abs(@class.DY - @class.DYcorrected);
						@class.Ycorrected += ((@class.DY > 0.0) ? num8 : (0.0 - num8));
					}
				}
			}
			else
			{
				if (!(hint is Class4735 class2))
				{
					continue;
				}
				double num9 = class2.X * fontSizePixels / (double)sourceResolution;
				double num10 = Math.Round(num9);
				double num11 = (class2.X + class2.DXcorrected) * fontSizePixels / (double)sourceResolution;
				double num12 = Math.Round(num11);
				double num13 = Class4623.Instance.RasterizationGridPrecision;
				bool flag2 = false;
				if (Math.Abs(num9 - num10) < Math.Abs(num11 - num12))
				{
					if (class2.DXcorrected < 0.0)
					{
						num13 = 0.0 - num13;
					}
					class2.Xcorrected = (double)sourceResolution * num10 / fontSizePixels + num13;
					class2.DeltaXCorrected = class2.Xcorrected - class2.X;
					flag2 = true;
				}
				else
				{
					if (class2.DXcorrected > 0.0)
					{
						num13 = 0.0 - num13;
					}
					class2.Xcorrected = (double)sourceResolution * num12 / fontSizePixels - class2.DXcorrected + num13;
					class2.DeltaXCorrected = class2.Xcorrected - class2.X;
					flag2 = false;
				}
				if (!Class4623.Instance.HintWidthOptimization || !(Math.Abs(class2.DX) > num))
				{
					continue;
				}
				int num14 = (int)(class2.DX / num);
				if (num14 > 0 && class2.DX - (double)num14 * num < num / 2.0)
				{
					class2.DXcorrected = (double)num14 * num - Class4623.Instance.EqualityPrecision;
					if (class2.DX < 0.0)
					{
						class2.DXcorrected = 0.0 - class2.DXcorrected;
					}
					if (!flag2)
					{
						double num15 = Math.Abs(class2.DX - class2.DXcorrected);
						class2.Xcorrected += ((class2.DX > 0.0) ? num15 : (0.0 - num15));
					}
				}
			}
		}
	}
}
