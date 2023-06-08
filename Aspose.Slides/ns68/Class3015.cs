using System;
using System.Drawing;

namespace ns68;

internal sealed class Class3015
{
	private Class3019 class3019_0;

	public Class3015(Class3019 normalizedBackBuffer)
	{
		class3019_0 = normalizedBackBuffer;
	}

	public void method_0(short i)
	{
		Class2998 structuralEdges = class3019_0.StructuralEdges;
		Struct156[,] pixels = class3019_0.Pixels;
		Class2989 normalizedBackBufferCoordinateSystem = class3019_0.NormalizedBackBufferCoordinateSystem;
		int num = (int)Math.Round(normalizedBackBufferCoordinateSystem.method_3(structuralEdges[i].A.X));
		int num2 = (int)Math.Round(normalizedBackBufferCoordinateSystem.method_4(structuralEdges[i].A.Y));
		int num3 = (int)Math.Round(normalizedBackBufferCoordinateSystem.method_3(structuralEdges[i].B.X));
		int num4 = (int)Math.Round(normalizedBackBufferCoordinateSystem.method_4(structuralEdges[i].B.Y));
		double num5 = normalizedBackBufferCoordinateSystem.method_3(structuralEdges[i].A.X);
		double num6 = normalizedBackBufferCoordinateSystem.method_4(structuralEdges[i].A.Y);
		double x = structuralEdges[i].InnerNormal.X;
		double y = structuralEdges[i].InnerNormal.Y;
		int num7 = Math.Abs(num3 - num);
		int num8 = Math.Abs(num4 - num2);
		int num9 = ((num < num3) ? 1 : (-1));
		int num10 = ((num2 < num4) ? 1 : (-1));
		int num11 = num7 - num8;
		int num12 = 0;
		int num13 = Math.Max(num7, num8) / 2;
		while (true)
		{
			pixels[num, num2].short_0 = i;
			pixels[num, num2].double_0 = ((double)num - num5) * x + ((double)num2 - num6) * y;
			pixels[num, num2].bool_2 = true;
			if (num12 == num13)
			{
				structuralEdges[i].Step1BuilderCache.StartFillPoint = new Point(num + Math.Sign(structuralEdges[i].InnerNormal.X), num2 + Math.Sign(structuralEdges[i].InnerNormal.Y));
			}
			num12++;
			if (num == num3 && num2 == num4)
			{
				break;
			}
			int num14 = num11 * 2;
			if (num14 > -num8)
			{
				num11 -= num8;
				num += num9;
			}
			if (num14 < num7)
			{
				num11 += num7;
				num2 += num10;
			}
		}
	}

	public void method_1(short i, double xShift, double yShift)
	{
		Class2998 structuralEdges = class3019_0.StructuralEdges;
		Struct156[,] pixels = class3019_0.Pixels;
		Class2989 normalizedBackBufferCoordinateSystem = class3019_0.NormalizedBackBufferCoordinateSystem;
		int num = (int)Math.Round(normalizedBackBufferCoordinateSystem.method_3(structuralEdges[i].A.X));
		int num2 = (int)Math.Round(normalizedBackBufferCoordinateSystem.method_4(structuralEdges[i].A.Y));
		int num3 = (int)Math.Round(normalizedBackBufferCoordinateSystem.method_3(structuralEdges[i].B.X));
		int num4 = (int)Math.Round(normalizedBackBufferCoordinateSystem.method_4(structuralEdges[i].B.Y));
		double num5 = normalizedBackBufferCoordinateSystem.method_3(structuralEdges[i].A.X);
		double num6 = normalizedBackBufferCoordinateSystem.method_4(structuralEdges[i].A.Y);
		double x = structuralEdges[i].InnerNormal.X;
		double y = structuralEdges[i].InnerNormal.Y;
		int num7 = Math.Abs(num3 - num);
		int num8 = Math.Abs(num4 - num2);
		int num9 = ((num < num3) ? 1 : (-1));
		int num10 = ((num2 < num4) ? 1 : (-1));
		int num11 = num7 - num8;
		while (true)
		{
			if (!(Math.Abs(xShift) < Math.Abs(yShift)))
			{
				xShift = Math.Sign(xShift);
				yShift = 0.0;
			}
			else
			{
				xShift = 0.0;
				yShift = Math.Sign(yShift);
			}
			int num12 = num + (int)xShift;
			int num13 = num2 + (int)yShift;
			if (num12 >= 0 && num12 < class3019_0.Width && num13 >= 0 && num13 < class3019_0.Height && !pixels[num12, num13].bool_2)
			{
				pixels[num12, num13].short_0 = i;
				pixels[num12, num13].double_0 = ((double)num - num5) * x + ((double)num2 - num6) * y;
			}
			if (num == num3 && num2 == num4)
			{
				break;
			}
			int num14 = num11 * 2;
			if (num14 > -num8)
			{
				num11 -= num8;
				num += num9;
			}
			if (num14 < num7)
			{
				num11 += num7;
				num2 += num10;
			}
		}
	}
}
