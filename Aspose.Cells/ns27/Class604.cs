using Aspose.Cells.Charts;

namespace ns27;

internal class Class604 : Class538
{
	internal Class604()
	{
		method_2(4191);
		method_0(2);
		byte_0 = new byte[2];
	}

	internal void method_4(Bar3DShapeType bar3DShapeType_0)
	{
		switch (bar3DShapeType_0)
		{
		case Bar3DShapeType.PyramidToPoint:
			byte_0[1] = 1;
			break;
		case Bar3DShapeType.PyramidToMax:
			byte_0[1] = 2;
			break;
		case Bar3DShapeType.Box:
			break;
		case Bar3DShapeType.Cylinder:
			byte_0[0] = 1;
			break;
		case Bar3DShapeType.ConeToPoint:
			byte_0[0] = 1;
			byte_0[1] = 1;
			break;
		case Bar3DShapeType.ConeToMax:
			byte_0[0] = 1;
			byte_0[1] = 2;
			break;
		}
	}

	internal void method_5(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		case ChartType.Cone:
		case ChartType.ConeStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBar:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.ConicalColumn3D:
			byte_0[0] = 1;
			byte_0[1] = 1;
			break;
		case ChartType.Cylinder:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.CylindricalColumn3D:
			byte_0[0] = 1;
			break;
		case ChartType.Pyramid:
		case ChartType.PyramidStacked:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBar:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
		case ChartType.PyramidColumn3D:
			byte_0[1] = 1;
			break;
		case ChartType.Doughnut:
		case ChartType.DoughnutExploded:
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.LineWithDataMarkers:
		case ChartType.LineStackedWithDataMarkers:
		case ChartType.Line100PercentStackedWithDataMarkers:
		case ChartType.Line3D:
		case ChartType.Pie:
		case ChartType.Pie3D:
		case ChartType.PiePie:
		case ChartType.PieExploded:
		case ChartType.Pie3DExploded:
		case ChartType.PieBar:
			break;
		}
	}
}
