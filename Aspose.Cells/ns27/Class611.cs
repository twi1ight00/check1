using System;
using Aspose.Cells.Charts;

namespace ns27;

internal class Class611 : Class538
{
	internal Class611()
	{
		method_2(4154);
		method_0(14);
		byte_0 = new byte[14];
		byte_0[0] = 20;
		byte_0[2] = 15;
		byte_0[4] = 30;
		byte_0[6] = 100;
		byte_0[8] = 100;
		byte_0[10] = 150;
	}

	internal void method_4(int int_0)
	{
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 0, 2);
	}

	internal void method_5(int int_0)
	{
		Array.Copy(BitConverter.GetBytes((short)int_0), 0, byte_0, 2, 2);
	}

	internal void method_6(int int_0)
	{
		Array.Copy(BitConverter.GetBytes((short)int_0), 0, byte_0, 4, 2);
	}

	internal void method_7(int int_0)
	{
		Array.Copy(BitConverter.GetBytes((short)int_0), 0, byte_0, 6, 2);
	}

	internal void method_8(int int_0)
	{
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 8, 2);
	}

	internal void method_9(int int_0)
	{
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 10, 2);
	}

	internal void method_10(Chart chart_0)
	{
		method_4(chart_0.RotationAngle);
		method_5(chart_0.Elevation);
		method_6(chart_0.Perspective);
		method_7(chart_0.HeightPercent);
		method_8(chart_0.DepthPercent);
		method_9(chart_0.GapDepth);
		byte b = 20;
		b = 20;
		if (!chart_0.AutoScaling)
		{
			b = (byte)(b & 0xFBu);
		}
		if (!chart_0.RightAngleAxes)
		{
			b = (byte)(b | 1u);
		}
		switch (chart_0.Type)
		{
		case ChartType.Bar3DClustered:
		case ChartType.Column3DClustered:
		case ChartType.Cone:
		case ChartType.ConicalBar:
		case ChartType.Cylinder:
		case ChartType.CylindricalBar:
		case ChartType.Pyramid:
		case ChartType.PyramidBar:
			b = (byte)(b | 2u);
			break;
		}
		if (chart_0.WallsAndGridlines2D)
		{
			b = (byte)(b | 0x20u);
		}
		byte_0[12] = b;
	}
}
