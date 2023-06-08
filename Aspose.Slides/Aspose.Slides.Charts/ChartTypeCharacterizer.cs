using System;
using ns2;

namespace Aspose.Slides.Charts;

public static class ChartTypeCharacterizer
{
	internal static Enum169 smethod_0(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			throw new IndexOutOfRangeException();
		case ChartType.PercentsStackedBar:
		case ChartType.ClusteredBar3D:
		case ChartType.ClusteredBar:
		case ChartType.StackedBar:
		case ChartType.StackedBar3D:
		case ChartType.PercentsStackedBar3D:
		case ChartType.ClusteredHorizontalCylinder:
		case ChartType.StackedHorizontalCylinder:
		case ChartType.PercentsStackedHorizontalCylinder:
		case ChartType.ClusteredHorizontalCone:
		case ChartType.StackedHorizontalCone:
		case ChartType.PercentsStackedHorizontalCone:
		case ChartType.ClusteredHorizontalPyramid:
		case ChartType.StackedHorizontalPyramid:
		case ChartType.PercentsStackedHorizontalPyramid:
			return Enum169.const_3;
		case ChartType.ClusteredColumn:
		case ChartType.StackedColumn:
		case ChartType.PercentsStackedColumn:
		case ChartType.ClusteredColumn3D:
		case ChartType.StackedColumn3D:
		case ChartType.PercentsStackedColumn3D:
		case ChartType.ClusteredCylinder:
		case ChartType.StackedCylinder:
		case ChartType.PercentsStackedCylinder:
		case ChartType.ClusteredCone:
		case ChartType.StackedCone:
		case ChartType.PercentsStackedCone:
		case ChartType.ClusteredPyramid:
		case ChartType.StackedPyramid:
		case ChartType.PercentsStackedPyramid:
		case ChartType.Line:
		case ChartType.StackedLine:
		case ChartType.PercentsStackedLine:
		case ChartType.LineWithMarkers:
		case ChartType.StackedLineWithMarkers:
		case ChartType.PercentsStackedLineWithMarkers:
		case ChartType.Area:
		case ChartType.StackedArea:
		case ChartType.PercentsStackedArea:
		case ChartType.StackedArea3D:
		case ChartType.PercentsStackedArea3D:
		case ChartType.HighLowClose:
		case ChartType.OpenHighLowClose:
		case ChartType.VolumeHighLowClose:
		case ChartType.VolumeOpenHighLowClose:
			return Enum169.const_1;
		case ChartType.Column3D:
		case ChartType.Cylinder3D:
		case ChartType.Cone3D:
		case ChartType.Pyramid3D:
		case ChartType.Line3D:
		case ChartType.Area3D:
		case ChartType.Surface3D:
		case ChartType.WireframeSurface3D:
		case ChartType.Contour:
		case ChartType.WireframeContour:
			return Enum169.const_5;
		case ChartType.Pie:
		case ChartType.Pie3D:
		case ChartType.PieOfPie:
		case ChartType.ExplodedPie:
		case ChartType.ExplodedPie3D:
		case ChartType.BarOfPie:
		case ChartType.Doughnut:
		case ChartType.ExplodedDoughnut:
			return Enum169.const_0;
		case ChartType.ScatterWithMarkers:
		case ChartType.ScatterWithSmoothLinesAndMarkers:
		case ChartType.ScatterWithSmoothLines:
		case ChartType.ScatterWithStraightLinesAndMarkers:
		case ChartType.ScatterWithStraightLines:
		case ChartType.Bubble:
		case ChartType.BubbleWith3D:
			return Enum169.const_4;
		case ChartType.Radar:
		case ChartType.RadarWithMarkers:
		case ChartType.FilledRadar:
			return Enum169.const_2;
		}
	}

	internal static string smethod_1(Enum169 compositionType)
	{
		return compositionType switch
		{
			Enum169.const_0 => "both Horizontal and Vertical axes are not needed (Series axis also not needed)", 
			Enum169.const_1 => "Horizontal axis - Category, Vertical axis - Value, Series axis - not needed", 
			Enum169.const_2 => "Horizontal axis - Radar Category, Vertical axis - Radar Value, Series axis - not needed", 
			Enum169.const_3 => "Horizontal axis - Value, Vertical axis - Category, Series axis - not needed", 
			Enum169.const_4 => "Horizontal axis - Value or Category, Vertical axis - Value or Category, Series axis - not needed", 
			Enum169.const_5 => "Horizontal axis - Value, Vertical axis - Category, Series axis - is needed", 
			_ => throw new ArgumentOutOfRangeException("compositionType"), 
		};
	}

	public static bool IsBar3DChart(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.ClusteredColumn3D:
		case ChartType.StackedColumn3D:
		case ChartType.PercentsStackedColumn3D:
		case ChartType.Column3D:
		case ChartType.ClusteredCylinder:
		case ChartType.StackedCylinder:
		case ChartType.PercentsStackedCylinder:
		case ChartType.Cylinder3D:
		case ChartType.ClusteredCone:
		case ChartType.StackedCone:
		case ChartType.PercentsStackedCone:
		case ChartType.Cone3D:
		case ChartType.ClusteredPyramid:
		case ChartType.StackedPyramid:
		case ChartType.PercentsStackedPyramid:
		case ChartType.Pyramid3D:
		case ChartType.ClusteredBar3D:
		case ChartType.StackedBar3D:
		case ChartType.PercentsStackedBar3D:
		case ChartType.ClusteredHorizontalCylinder:
		case ChartType.StackedHorizontalCylinder:
		case ChartType.PercentsStackedHorizontalCylinder:
		case ChartType.ClusteredHorizontalCone:
		case ChartType.StackedHorizontalCone:
		case ChartType.PercentsStackedHorizontalCone:
		case ChartType.ClusteredHorizontalPyramid:
		case ChartType.StackedHorizontalPyramid:
		case ChartType.PercentsStackedHorizontalPyramid:
			return true;
		}
	}

	public static bool Is2DChart(ChartType chartType)
	{
		switch (smethod_2(chartType))
		{
		default:
			return false;
		case CombinableSeriesTypesGroup.AreaChart_Area:
		case CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea:
		case CombinableSeriesTypesGroup.AreaChart_StackedArea:
		case CombinableSeriesTypesGroup.LineChart_Line:
		case CombinableSeriesTypesGroup.LineChart_StackedLine:
		case CombinableSeriesTypesGroup.LineChart_PercentsStackedLine:
		case CombinableSeriesTypesGroup.StockHighLowClose:
		case CombinableSeriesTypesGroup.StockOpenHighLowClose:
		case CombinableSeriesTypesGroup.StockVolumeHighLowClose:
		case CombinableSeriesTypesGroup.StockVolumeOpenHighLowClose:
		case CombinableSeriesTypesGroup.RadarChart:
		case CombinableSeriesTypesGroup.FilledRadarChart:
		case CombinableSeriesTypesGroup.ScatterStraightMarker:
		case CombinableSeriesTypesGroup.ScatterSmoothMarker:
		case CombinableSeriesTypesGroup.PieChart:
		case CombinableSeriesTypesGroup.DoughnutChart:
		case CombinableSeriesTypesGroup.BarChart_VertClustered:
		case CombinableSeriesTypesGroup.BarChart_VertStacked:
		case CombinableSeriesTypesGroup.BarChart_VertPercentsStacked:
		case CombinableSeriesTypesGroup.BarChart_HorizClustered:
		case CombinableSeriesTypesGroup.BarChart_HorizStacked:
		case CombinableSeriesTypesGroup.BarChart_HorizPercentsStacked:
		case CombinableSeriesTypesGroup.BarOfPieChart:
		case CombinableSeriesTypesGroup.PieOfPieChart:
		case CombinableSeriesTypesGroup.BubbleChart:
			return true;
		}
	}

	public static bool Is3DChart(ChartType chartType)
	{
		switch (smethod_2(chartType))
		{
		default:
			return false;
		case CombinableSeriesTypesGroup.AreaChart_Area3D:
		case CombinableSeriesTypesGroup.AreaChart_StackedArea3D:
		case CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea3D:
		case CombinableSeriesTypesGroup.Line3DChart:
		case CombinableSeriesTypesGroup.Pie3DChart:
		case CombinableSeriesTypesGroup.Bar3DChart_Vert:
		case CombinableSeriesTypesGroup.Bar3DChart_VertClustered:
		case CombinableSeriesTypesGroup.Bar3DChart_VertPercentsStackedColumn3D:
		case CombinableSeriesTypesGroup.Bar3DChart_VertPercentsStackedCone:
		case CombinableSeriesTypesGroup.Bar3DChart_VertPercentsStackedCylinder:
		case CombinableSeriesTypesGroup.Bar3DChart_VertPercentsStackedPyramid:
		case CombinableSeriesTypesGroup.Bar3DChart_VertStackedColumn3D:
		case CombinableSeriesTypesGroup.Bar3DChart_VertStackedCone:
		case CombinableSeriesTypesGroup.Bar3DChart_VertStackedCylinder:
		case CombinableSeriesTypesGroup.Bar3DChart_VertStackedPyramid:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizClustered:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedBar3D:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedCone:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedCylinder:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedPyramid:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedBar3D:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedCone:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedCylinder:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedPyramid:
		case CombinableSeriesTypesGroup.SurfaceChart_Contour:
		case CombinableSeriesTypesGroup.SurfaceChart_WireframeContour:
		case CombinableSeriesTypesGroup.SurfaceChart_Surface3D:
		case CombinableSeriesTypesGroup.SurfaceChart_WireframeSurface3D:
			return true;
		}
	}

	public static bool IsChartTypeColumn(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.ClusteredColumn:
		case ChartType.StackedColumn:
		case ChartType.PercentsStackedColumn:
		case ChartType.ClusteredColumn3D:
		case ChartType.StackedColumn3D:
		case ChartType.PercentsStackedColumn3D:
		case ChartType.Column3D:
		case ChartType.ClusteredCylinder:
		case ChartType.StackedCylinder:
		case ChartType.PercentsStackedCylinder:
		case ChartType.Cylinder3D:
		case ChartType.ClusteredCone:
		case ChartType.StackedCone:
		case ChartType.PercentsStackedCone:
		case ChartType.Cone3D:
		case ChartType.ClusteredPyramid:
		case ChartType.StackedPyramid:
		case ChartType.PercentsStackedPyramid:
		case ChartType.Pyramid3D:
			return true;
		}
	}

	public static bool IsChartTypeLine(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.Line:
		case ChartType.StackedLine:
		case ChartType.PercentsStackedLine:
		case ChartType.LineWithMarkers:
		case ChartType.StackedLineWithMarkers:
		case ChartType.PercentsStackedLineWithMarkers:
		case ChartType.Line3D:
			return true;
		}
	}

	public static bool IsChartTypePie(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.Pie:
		case ChartType.Pie3D:
		case ChartType.PieOfPie:
		case ChartType.ExplodedPie:
		case ChartType.ExplodedPie3D:
		case ChartType.BarOfPie:
			return true;
		}
	}

	public static bool IsChartTypeBar(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.PercentsStackedBar:
		case ChartType.ClusteredBar3D:
		case ChartType.ClusteredBar:
		case ChartType.StackedBar:
		case ChartType.StackedBar3D:
		case ChartType.PercentsStackedBar3D:
		case ChartType.ClusteredHorizontalCylinder:
		case ChartType.StackedHorizontalCylinder:
		case ChartType.PercentsStackedHorizontalCylinder:
		case ChartType.ClusteredHorizontalCone:
		case ChartType.StackedHorizontalCone:
		case ChartType.PercentsStackedHorizontalCone:
		case ChartType.ClusteredHorizontalPyramid:
		case ChartType.StackedHorizontalPyramid:
		case ChartType.PercentsStackedHorizontalPyramid:
			return true;
		}
	}

	public static bool IsChartTypeArea(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.Area:
		case ChartType.StackedArea:
		case ChartType.PercentsStackedArea:
		case ChartType.Area3D:
		case ChartType.StackedArea3D:
		case ChartType.PercentsStackedArea3D:
			return true;
		}
	}

	public static bool IsChartTypeScatter(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.ScatterWithMarkers:
		case ChartType.ScatterWithSmoothLinesAndMarkers:
		case ChartType.ScatterWithSmoothLines:
		case ChartType.ScatterWithStraightLinesAndMarkers:
		case ChartType.ScatterWithStraightLines:
			return true;
		}
	}

	public static bool IsChartTypeStock(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.HighLowClose:
		case ChartType.OpenHighLowClose:
		case ChartType.VolumeHighLowClose:
		case ChartType.VolumeOpenHighLowClose:
			return true;
		}
	}

	public static bool IsChartTypeSurface(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.Surface3D:
		case ChartType.WireframeSurface3D:
		case ChartType.Contour:
		case ChartType.WireframeContour:
			return true;
		}
	}

	public static bool IsChartTypeDoughnut(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.Doughnut:
		case ChartType.ExplodedDoughnut:
			return true;
		}
	}

	public static bool IsChartTypeBubble(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.Bubble:
		case ChartType.BubbleWith3D:
			return true;
		}
	}

	public static bool IsChartTypeRadar(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.Radar:
		case ChartType.RadarWithMarkers:
		case ChartType.FilledRadar:
			return true;
		}
	}

	internal static CombinableSeriesTypesGroup smethod_2(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			throw new IndexOutOfRangeException();
		case ChartType.ClusteredColumn:
			return CombinableSeriesTypesGroup.BarChart_VertClustered;
		case ChartType.StackedColumn:
			return CombinableSeriesTypesGroup.BarChart_VertStacked;
		case ChartType.PercentsStackedColumn:
			return CombinableSeriesTypesGroup.BarChart_VertPercentsStacked;
		case ChartType.StackedColumn3D:
			return CombinableSeriesTypesGroup.Bar3DChart_VertStackedColumn3D;
		case ChartType.PercentsStackedColumn3D:
			return CombinableSeriesTypesGroup.Bar3DChart_VertPercentsStackedColumn3D;
		case ChartType.StackedCylinder:
			return CombinableSeriesTypesGroup.Bar3DChart_VertStackedCylinder;
		case ChartType.PercentsStackedCylinder:
			return CombinableSeriesTypesGroup.Bar3DChart_VertPercentsStackedCylinder;
		case ChartType.StackedCone:
			return CombinableSeriesTypesGroup.Bar3DChart_VertStackedCone;
		case ChartType.PercentsStackedCone:
			return CombinableSeriesTypesGroup.Bar3DChart_VertPercentsStackedCone;
		case ChartType.ClusteredColumn3D:
		case ChartType.ClusteredCylinder:
		case ChartType.ClusteredCone:
		case ChartType.ClusteredPyramid:
			return CombinableSeriesTypesGroup.Bar3DChart_VertClustered;
		case ChartType.StackedPyramid:
			return CombinableSeriesTypesGroup.Bar3DChart_VertStackedPyramid;
		case ChartType.PercentsStackedPyramid:
			return CombinableSeriesTypesGroup.Bar3DChart_VertPercentsStackedPyramid;
		case ChartType.Column3D:
		case ChartType.Cylinder3D:
		case ChartType.Cone3D:
		case ChartType.Pyramid3D:
			return CombinableSeriesTypesGroup.Bar3DChart_Vert;
		case ChartType.Line:
		case ChartType.LineWithMarkers:
			return CombinableSeriesTypesGroup.LineChart_Line;
		case ChartType.StackedLine:
		case ChartType.StackedLineWithMarkers:
			return CombinableSeriesTypesGroup.LineChart_StackedLine;
		case ChartType.PercentsStackedLine:
		case ChartType.PercentsStackedLineWithMarkers:
			return CombinableSeriesTypesGroup.LineChart_PercentsStackedLine;
		case ChartType.Line3D:
			return CombinableSeriesTypesGroup.Line3DChart;
		case ChartType.PieOfPie:
			return CombinableSeriesTypesGroup.PieOfPieChart;
		case ChartType.Pie:
		case ChartType.ExplodedPie:
			return CombinableSeriesTypesGroup.PieChart;
		case ChartType.Pie3D:
		case ChartType.ExplodedPie3D:
			return CombinableSeriesTypesGroup.Pie3DChart;
		case ChartType.BarOfPie:
			return CombinableSeriesTypesGroup.BarOfPieChart;
		case ChartType.PercentsStackedBar:
			return CombinableSeriesTypesGroup.BarChart_HorizPercentsStacked;
		case ChartType.ClusteredBar:
			return CombinableSeriesTypesGroup.BarChart_HorizClustered;
		case ChartType.StackedBar:
			return CombinableSeriesTypesGroup.BarChart_HorizStacked;
		case ChartType.StackedBar3D:
			return CombinableSeriesTypesGroup.Bar3DChart_HorizStackedBar3D;
		case ChartType.PercentsStackedBar3D:
			return CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedBar3D;
		case ChartType.StackedHorizontalCylinder:
			return CombinableSeriesTypesGroup.Bar3DChart_HorizStackedCylinder;
		case ChartType.PercentsStackedHorizontalCylinder:
			return CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedCylinder;
		case ChartType.StackedHorizontalCone:
			return CombinableSeriesTypesGroup.Bar3DChart_HorizStackedCone;
		case ChartType.PercentsStackedHorizontalCone:
			return CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedCone;
		case ChartType.ClusteredBar3D:
		case ChartType.ClusteredHorizontalCylinder:
		case ChartType.ClusteredHorizontalCone:
		case ChartType.ClusteredHorizontalPyramid:
			return CombinableSeriesTypesGroup.Bar3DChart_HorizClustered;
		case ChartType.StackedHorizontalPyramid:
			return CombinableSeriesTypesGroup.Bar3DChart_HorizStackedPyramid;
		case ChartType.PercentsStackedHorizontalPyramid:
			return CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedPyramid;
		case ChartType.Area:
			return CombinableSeriesTypesGroup.AreaChart_Area;
		case ChartType.StackedArea:
			return CombinableSeriesTypesGroup.AreaChart_StackedArea;
		case ChartType.PercentsStackedArea:
			return CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea;
		case ChartType.Area3D:
			return CombinableSeriesTypesGroup.AreaChart_Area3D;
		case ChartType.StackedArea3D:
			return CombinableSeriesTypesGroup.AreaChart_StackedArea3D;
		case ChartType.PercentsStackedArea3D:
			return CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea3D;
		case ChartType.ScatterWithSmoothLinesAndMarkers:
		case ChartType.ScatterWithSmoothLines:
			return CombinableSeriesTypesGroup.ScatterSmoothMarker;
		case ChartType.ScatterWithMarkers:
		case ChartType.ScatterWithStraightLinesAndMarkers:
		case ChartType.ScatterWithStraightLines:
			return CombinableSeriesTypesGroup.ScatterStraightMarker;
		case ChartType.HighLowClose:
			return CombinableSeriesTypesGroup.StockHighLowClose;
		case ChartType.OpenHighLowClose:
			return CombinableSeriesTypesGroup.StockOpenHighLowClose;
		case ChartType.VolumeHighLowClose:
			return CombinableSeriesTypesGroup.StockVolumeHighLowClose;
		case ChartType.VolumeOpenHighLowClose:
			return CombinableSeriesTypesGroup.StockVolumeOpenHighLowClose;
		case ChartType.Surface3D:
			return CombinableSeriesTypesGroup.SurfaceChart_Surface3D;
		case ChartType.WireframeSurface3D:
			return CombinableSeriesTypesGroup.SurfaceChart_WireframeSurface3D;
		case ChartType.Contour:
			return CombinableSeriesTypesGroup.SurfaceChart_Contour;
		case ChartType.WireframeContour:
			return CombinableSeriesTypesGroup.SurfaceChart_WireframeContour;
		case ChartType.Doughnut:
		case ChartType.ExplodedDoughnut:
			return CombinableSeriesTypesGroup.DoughnutChart;
		case ChartType.Bubble:
		case ChartType.BubbleWith3D:
			return CombinableSeriesTypesGroup.BubbleChart;
		case ChartType.Radar:
		case ChartType.RadarWithMarkers:
			return CombinableSeriesTypesGroup.RadarChart;
		case ChartType.FilledRadar:
			return CombinableSeriesTypesGroup.FilledRadarChart;
		}
	}

	internal static bool smethod_3(IChartSeries series, IChartSeriesGroup seriesGroup)
	{
		CombinableSeriesTypesGroup combinableSeriesTypesGroup = smethod_2(series.Type);
		CombinableSeriesTypesGroup type = seriesGroup.Type;
		if (combinableSeriesTypesGroup == type)
		{
			return series.PlotOnSecondAxis == seriesGroup.PlotOnSecondAxis;
		}
		return false;
	}

	public static bool IsSeriesUsesXValueCoordinate(ChartType seriesType)
	{
		switch (smethod_2(seriesType))
		{
		default:
			return false;
		case CombinableSeriesTypesGroup.ScatterStraightMarker:
		case CombinableSeriesTypesGroup.ScatterSmoothMarker:
		case CombinableSeriesTypesGroup.BubbleChart:
			return true;
		}
	}

	public static bool IsSeriesUsesYValueCoordinate(ChartType seriesType)
	{
		switch (smethod_2(seriesType))
		{
		default:
			return false;
		case CombinableSeriesTypesGroup.ScatterStraightMarker:
		case CombinableSeriesTypesGroup.ScatterSmoothMarker:
		case CombinableSeriesTypesGroup.BubbleChart:
			return true;
		}
	}

	public static bool IsSeriesUsesValueCoordinate(ChartType seriesType)
	{
		switch (smethod_2(seriesType))
		{
		default:
			return false;
		case CombinableSeriesTypesGroup.AreaChart_Area:
		case CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea:
		case CombinableSeriesTypesGroup.AreaChart_StackedArea:
		case CombinableSeriesTypesGroup.AreaChart_Area3D:
		case CombinableSeriesTypesGroup.AreaChart_StackedArea3D:
		case CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea3D:
		case CombinableSeriesTypesGroup.LineChart_Line:
		case CombinableSeriesTypesGroup.LineChart_StackedLine:
		case CombinableSeriesTypesGroup.LineChart_PercentsStackedLine:
		case CombinableSeriesTypesGroup.Line3DChart:
		case CombinableSeriesTypesGroup.StockHighLowClose:
		case CombinableSeriesTypesGroup.StockOpenHighLowClose:
		case CombinableSeriesTypesGroup.StockVolumeHighLowClose:
		case CombinableSeriesTypesGroup.StockVolumeOpenHighLowClose:
		case CombinableSeriesTypesGroup.RadarChart:
		case CombinableSeriesTypesGroup.FilledRadarChart:
		case CombinableSeriesTypesGroup.PieChart:
		case CombinableSeriesTypesGroup.Pie3DChart:
		case CombinableSeriesTypesGroup.DoughnutChart:
		case CombinableSeriesTypesGroup.BarChart_VertClustered:
		case CombinableSeriesTypesGroup.BarChart_VertStacked:
		case CombinableSeriesTypesGroup.BarChart_VertPercentsStacked:
		case CombinableSeriesTypesGroup.BarChart_HorizClustered:
		case CombinableSeriesTypesGroup.BarChart_HorizStacked:
		case CombinableSeriesTypesGroup.BarChart_HorizPercentsStacked:
		case CombinableSeriesTypesGroup.Bar3DChart_Vert:
		case CombinableSeriesTypesGroup.Bar3DChart_VertClustered:
		case CombinableSeriesTypesGroup.Bar3DChart_VertPercentsStackedColumn3D:
		case CombinableSeriesTypesGroup.Bar3DChart_VertPercentsStackedCone:
		case CombinableSeriesTypesGroup.Bar3DChart_VertPercentsStackedCylinder:
		case CombinableSeriesTypesGroup.Bar3DChart_VertPercentsStackedPyramid:
		case CombinableSeriesTypesGroup.Bar3DChart_VertStackedColumn3D:
		case CombinableSeriesTypesGroup.Bar3DChart_VertStackedCone:
		case CombinableSeriesTypesGroup.Bar3DChart_VertStackedCylinder:
		case CombinableSeriesTypesGroup.Bar3DChart_VertStackedPyramid:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizClustered:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedBar3D:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedCone:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedCylinder:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedPyramid:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedBar3D:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedCone:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedCylinder:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedPyramid:
		case CombinableSeriesTypesGroup.BarOfPieChart:
		case CombinableSeriesTypesGroup.PieOfPieChart:
		case CombinableSeriesTypesGroup.SurfaceChart_Contour:
		case CombinableSeriesTypesGroup.SurfaceChart_WireframeContour:
		case CombinableSeriesTypesGroup.SurfaceChart_Surface3D:
		case CombinableSeriesTypesGroup.SurfaceChart_WireframeSurface3D:
			return true;
		}
	}

	public static bool IsSeriesUsesBubbleSizeCoordinate(ChartType seriesType)
	{
		CombinableSeriesTypesGroup combinableSeriesTypesGroup = smethod_2(seriesType);
		if (combinableSeriesTypesGroup == CombinableSeriesTypesGroup.BubbleChart)
		{
			return true;
		}
		return false;
	}

	public static bool HasSeriesTrendLines(ChartType seriesType)
	{
		switch (seriesType)
		{
		default:
			return false;
		case ChartType.ClusteredColumn:
		case ChartType.Line:
		case ChartType.LineWithMarkers:
		case ChartType.ClusteredBar:
		case ChartType.Area:
		case ChartType.ScatterWithMarkers:
		case ChartType.ScatterWithSmoothLinesAndMarkers:
		case ChartType.ScatterWithSmoothLines:
		case ChartType.ScatterWithStraightLinesAndMarkers:
		case ChartType.ScatterWithStraightLines:
		case ChartType.HighLowClose:
		case ChartType.OpenHighLowClose:
		case ChartType.VolumeHighLowClose:
		case ChartType.VolumeOpenHighLowClose:
		case ChartType.Bubble:
		case ChartType.BubbleWith3D:
			return true;
		}
	}

	public static bool IsErrorBarsXAllowed(ChartType seriesType)
	{
		switch (smethod_2(seriesType))
		{
		default:
			return false;
		case CombinableSeriesTypesGroup.AreaChart_Area:
		case CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea:
		case CombinableSeriesTypesGroup.AreaChart_StackedArea:
		case CombinableSeriesTypesGroup.ScatterStraightMarker:
		case CombinableSeriesTypesGroup.ScatterSmoothMarker:
		case CombinableSeriesTypesGroup.BarChart_HorizClustered:
		case CombinableSeriesTypesGroup.BarChart_HorizStacked:
		case CombinableSeriesTypesGroup.BarChart_HorizPercentsStacked:
		case CombinableSeriesTypesGroup.BubbleChart:
			return true;
		}
	}

	public static bool IsErrorBarsYAllowed(ChartType seriesType)
	{
		switch (smethod_2(seriesType))
		{
		default:
			return false;
		case CombinableSeriesTypesGroup.AreaChart_Area:
		case CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea:
		case CombinableSeriesTypesGroup.AreaChart_StackedArea:
		case CombinableSeriesTypesGroup.LineChart_Line:
		case CombinableSeriesTypesGroup.LineChart_StackedLine:
		case CombinableSeriesTypesGroup.LineChart_PercentsStackedLine:
		case CombinableSeriesTypesGroup.ScatterStraightMarker:
		case CombinableSeriesTypesGroup.ScatterSmoothMarker:
		case CombinableSeriesTypesGroup.BarChart_VertClustered:
		case CombinableSeriesTypesGroup.BarChart_VertStacked:
		case CombinableSeriesTypesGroup.BarChart_VertPercentsStacked:
		case CombinableSeriesTypesGroup.BubbleChart:
			return true;
		}
	}
}
