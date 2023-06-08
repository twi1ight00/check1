using System;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace ns27;

internal class Class603 : Class538
{
	internal Class603(FileFormatType fileFormatType_1, int int_0, int int_1)
	{
		method_2(4119);
		fileFormatType_0 = fileFormatType_1;
		method_0(6);
		byte_0 = new byte[6];
		Array.Copy(BitConverter.GetBytes((short)(-int_0)), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((short)int_1), 0, byte_0, 2, 2);
	}

	internal void method_4(ChartType chartType_0, bool bool_0)
	{
		switch (chartType_0)
		{
		case ChartType.Bar:
		case ChartType.Bar3DClustered:
			byte_0[4] = 1;
			break;
		case ChartType.BarStacked:
		case ChartType.Bar3DStacked:
			byte_0[4] = 3;
			break;
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3D100PercentStacked:
			byte_0[4] = 7;
			break;
		case ChartType.ColumnStacked:
		case ChartType.Column3DStacked:
			byte_0[4] = 2;
			break;
		case ChartType.Column100PercentStacked:
		case ChartType.Column3D100PercentStacked:
			byte_0[4] = 6;
			break;
		case ChartType.ConeStacked:
		case ChartType.PyramidStacked:
			byte_0[4] = 2;
			break;
		case ChartType.Cone100PercentStacked:
		case ChartType.Pyramid100PercentStacked:
			byte_0[4] = 6;
			break;
		case ChartType.ConicalBar:
		case ChartType.PyramidBar:
			byte_0[4] = 1;
			break;
		case ChartType.ConicalBarStacked:
		case ChartType.PyramidBarStacked:
			byte_0[4] = 3;
			break;
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.PyramidBar100PercentStacked:
			byte_0[4] = 7;
			break;
		case ChartType.CylinderStacked:
			byte_0[4] = 2;
			break;
		case ChartType.Cylinder100PercentStacked:
			byte_0[4] = 6;
			break;
		case ChartType.CylindricalBar:
			byte_0[4] = 1;
			break;
		case ChartType.CylindricalBarStacked:
			byte_0[4] = 3;
			break;
		case ChartType.CylindricalBar100PercentStacked:
			byte_0[4] = 7;
			break;
		}
		if (bool_0)
		{
			byte_0[4] |= 8;
		}
	}
}
