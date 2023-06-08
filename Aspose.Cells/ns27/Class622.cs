using System;
using Aspose.Cells.Charts;
using ns22;

namespace ns27;

internal class Class622 : Class538
{
	internal Class622()
	{
		method_2(4102);
		method_0(8);
		byte_0 = new byte[8];
	}

	internal void method_4(int int_0, int int_1)
	{
		byte_0[0] = byte.MaxValue;
		byte_0[1] = byte.MaxValue;
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, byte_0, 4, 2);
	}

	internal void method_5(int int_0)
	{
		byte_0[0] = byte.MaxValue;
		byte_0[1] = byte.MaxValue;
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 2, 2);
		byte_0[4] = 1;
	}

	[Attribute0(true)]
	internal void method_6(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		case ChartType.Area:
		case ChartType.AreaStacked:
		case ChartType.Area100PercentStacked:
		case ChartType.Area3D:
		case ChartType.Area3DStacked:
		case ChartType.Area3D100PercentStacked:
		case ChartType.Bar:
		case ChartType.BarStacked:
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3DClustered:
		case ChartType.Bar3DStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.Column:
		case ChartType.ColumnStacked:
		case ChartType.Column100PercentStacked:
		case ChartType.Column3D:
		case ChartType.Column3DClustered:
		case ChartType.Column3DStacked:
		case ChartType.Column3D100PercentStacked:
		case ChartType.Surface3D:
		case ChartType.SurfaceWireframe3D:
		case ChartType.SurfaceContour:
		case ChartType.SurfaceContourWireframe:
			throw new Exception("Invalid chart type.");
		}
		byte_0[4] = 253;
		byte_0[5] = byte.MaxValue;
	}
}
