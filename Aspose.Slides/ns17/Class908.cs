using System;
using Aspose.Slides.Charts;
using ns16;
using ns25;
using ns56;

namespace ns17;

internal class Class908
{
	public static void smethod_0(IChartData chartData, Class2106 plotAreaElementData, Class892 chartPartDeserializationContext)
	{
		if (plotAreaElementData == null)
		{
			return;
		}
		Class1341 deserializationContext = chartPartDeserializationContext.SlideDeserializationContext.DeserializationContext;
		ChartDataWorkbook chartDataWorkbook = (ChartDataWorkbook)chartData.ChartDataWorkbook;
		for (int i = 0; i < plotAreaElementData.ChartList.Length; i++)
		{
			Class2605 @class = plotAreaElementData.ChartList[i];
			Class2021 class2 = (Class2021)@class.Object;
			ChartSeriesGroup chartSeriesGroup = null;
			Class2038[] serList = class2.SerList;
			foreach (Class2038 class3 in serList)
			{
				ChartType chartType = Class912.smethod_7(plotAreaElementData, i);
				ChartType type = Class912.smethod_6(chartType, class3);
				bool plotOnSecondAxis = Class913.smethod_10(class2, chartPartDeserializationContext);
				IChartSeries chartSeries;
				if (chartSeriesGroup == null)
				{
					chartSeries = ((ChartSeriesCollection)chartData.Series).method_3(type, plotOnSecondAxis);
					chartSeriesGroup = (ChartSeriesGroup)chartSeries.ParentSeriesGroup;
				}
				else
				{
					chartSeries = ((ChartSeriesCollection)chartData.Series).method_2(type, chartSeriesGroup, plotOnSecondAxis);
				}
				Class913.smethod_0(chartSeries, class3, chartDataWorkbook, class2, chartPartDeserializationContext);
				if (chartPartDeserializationContext.SeriesXmlIdxToSeries != null)
				{
					if (!chartPartDeserializationContext.SeriesXmlIdxToSeries.ContainsKey(class3.Idx.Val))
					{
						chartPartDeserializationContext.SeriesXmlIdxToSeries.Add(class3.Idx.Val, chartSeries);
					}
					else
					{
						chartPartDeserializationContext.SeriesXmlIdxToSeries = null;
					}
				}
				if (chartSeries.PlotOnSecondAxis)
				{
					if (!chartData.UseSecondaryCategories)
					{
						chartData.UseSecondaryCategories = true;
					}
					if (chartData.SecondaryCategories.Count == 0)
					{
						Class906.smethod_0(chartData.SecondaryCategories, class3.Cat, chartDataWorkbook);
					}
				}
				else if (chartData.Categories.Count == 0)
				{
					Class906.smethod_0(chartData.Categories, class3.Cat, chartDataWorkbook);
				}
			}
			if (chartSeriesGroup == null)
			{
				continue;
			}
			Class318 pPTXUnsupportedProps = chartSeriesGroup.PPTXUnsupportedProps;
			Class909.smethod_0(pPTXUnsupportedProps.DropLinesFormat, class2.DropLines, deserializationContext);
			Class909.smethod_0(pPTXUnsupportedProps.HiLowLinesFormat, class2.HiLowLines, deserializationContext);
			Class909.smethod_0(pPTXUnsupportedProps.SeriesLinesFormat, (class2.SerLinesList == null || class2.SerLinesList.Length <= 0) ? null : class2.SerLinesList[0], deserializationContext);
			chartSeriesGroup.GapWidth = (ushort)((class2.GapWidth == null) ? 150 : class2.GapWidth.Val);
			chartSeriesGroup.GapDepth = (ushort)((class2.GapDepth == null) ? 150 : class2.GapDepth.Val);
			Class928.smethod_0(chartSeriesGroup.UpDownBars, class2.UpDownBars, deserializationContext);
			if (class2.FirstSliceAng != null)
			{
				chartSeriesGroup.FirstSliceAngle = class2.FirstSliceAng.Val;
			}
			if (class2.HoleSize != null)
			{
				pPTXUnsupportedProps.DoughnutHoleSize = class2.HoleSize.Val;
			}
			if (class2.Overlap != null)
			{
				chartSeriesGroup.Overlap = class2.Overlap.Val;
			}
			if (class2.SecondPieSize != null)
			{
				pPTXUnsupportedProps.SecondPieSize = class2.SecondPieSize.Val;
			}
			if (class2.ShowNegBubbles != null)
			{
				pPTXUnsupportedProps.ShowNegativeBubbles = class2.ShowNegBubbles.Val;
			}
			if (class2.SizeRepresents != null)
			{
				pPTXUnsupportedProps.BubbleSizeRepresentation = class2.SizeRepresents.Val;
			}
			if (class2.SplitPos != null)
			{
				pPTXUnsupportedProps.OfPieSplitPosition = class2.SplitPos.Val;
			}
			if (class2.SplitType != null)
			{
				pPTXUnsupportedProps.OfPieSplitType = class2.SplitType.Val;
			}
			if (class2.CustSplit != null)
			{
				Class2135[] secondPiePtList = class2.CustSplit.SecondPiePtList;
				foreach (Class2135 class4 in secondPiePtList)
				{
					pPTXUnsupportedProps.OfPieCustomSplitPoints.Add((int)class4.Val);
				}
			}
			if (class2.VaryColors != null)
			{
				chartSeriesGroup.IsColorVaried = class2.VaryColors.Val;
			}
			if (class2.BubbleScale != null)
			{
				pPTXUnsupportedProps.BubbleSizeScale = (int)class2.BubbleScale.Val;
			}
			pPTXUnsupportedProps.SurfaceBandFormats = class2.BandFmts;
			pPTXUnsupportedProps.ExtensionList = class2.ExtLst;
		}
		smethod_1(chartData);
	}

	private static void smethod_1(IChartData chartData)
	{
		if (!chartData.UseSecondaryCategories)
		{
			return;
		}
		bool flag = true;
		if (chartData.Categories.UseCells && chartData.SecondaryCategories.UseCells && ((ChartCategoryCollection)chartData.Categories).GetCellsAddress() != ((ChartCategoryCollection)chartData.SecondaryCategories).GetCellsAddress())
		{
			flag = false;
		}
		if (chartData.Categories.UseCells != chartData.SecondaryCategories.UseCells || chartData.Categories.Count != chartData.SecondaryCategories.Count)
		{
			flag = false;
		}
		if (flag)
		{
			for (int i = 0; i < chartData.Categories.Count; i++)
			{
				if (chartData.Categories[i].Value != chartData.SecondaryCategories[i].Value)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			chartData.SecondaryCategories.Clear();
			chartData.UseSecondaryCategories = false;
		}
	}

	public static void smethod_2(IChart chart, Class2106 plotAreaElementData, Class882 chartPartSerializationContext)
	{
		IChartData chartData = chart.ChartData;
		IChartDataWorkbook chartDataWorkbook = chartData.ChartDataWorkbook;
		Class1346 serializationContext = chartPartSerializationContext.SlideSerializationContext.SerializationContext;
		if (chartData.SeriesGroups.Count > 0)
		{
			foreach (ChartSeriesGroup seriesGroup in chartData.SeriesGroups)
			{
				Class318 pPTXUnsupportedProps = seriesGroup.PPTXUnsupportedProps;
				Class2021 @class = smethod_3(seriesGroup.Type, seriesGroup.Series[0].Type, plotAreaElementData);
				foreach (IChartSeries item in seriesGroup.Series)
				{
					Class2038 seriesElementData = @class.method_2(item.Type);
					Class913.smethod_11(item, seriesElementData, @class, chartDataWorkbook, chartPartSerializationContext);
				}
				if (pPTXUnsupportedProps.HasDropLines && @class.delegate1889_0 != null)
				{
					Class909.smethod_1(pPTXUnsupportedProps.DropLinesFormat, @class.delegate1889_0(), serializationContext);
				}
				if (pPTXUnsupportedProps.HasHiLowLines && @class.delegate1889_1 != null)
				{
					Class909.smethod_1(pPTXUnsupportedProps.HiLowLinesFormat, @class.delegate1889_1(), serializationContext);
				}
				if (seriesGroup.HasSeriesLines && @class.delegate1889_2 != null)
				{
					Class909.smethod_1(pPTXUnsupportedProps.SeriesLinesFormat, @class.delegate1889_2(), serializationContext);
				}
				if (@class.delegate1943_1 != null)
				{
					@class.delegate1943_1().Val = seriesGroup.GapWidth;
				}
				if (@class.delegate1943_0 != null)
				{
					@class.delegate1943_0().Val = seriesGroup.GapDepth;
				}
				if (@class.delegate2142_0 != null)
				{
					Class928.smethod_1(seriesGroup.UpDownBars, @class.delegate2142_0, serializationContext);
				}
				if (@class.delegate1940_0 != null)
				{
					@class.delegate1940_0().Val = seriesGroup.FirstSliceAngle;
				}
				if (@class.delegate1949_0 != null)
				{
					@class.delegate1949_0().Val = pPTXUnsupportedProps.DoughnutHoleSize;
				}
				if (@class.delegate2028_0 != null)
				{
					@class.delegate2028_0().Val = seriesGroup.Overlap;
				}
				if (@class.delegate2065_0 != null)
				{
					@class.delegate2065_0().Val = pPTXUnsupportedProps.SecondPieSize;
				}
				if (@class.delegate2763_1 != null)
				{
					@class.delegate2763_1().Val = pPTXUnsupportedProps.ShowNegativeBubbles;
				}
				if (@class.delegate2075_0 != null && pPTXUnsupportedProps.BubbleSizeRepresentation != Class2116.enum266_1)
				{
					@class.delegate2075_0().Val = pPTXUnsupportedProps.BubbleSizeRepresentation;
				}
				if (@class.delegate1923_0 != null && pPTXUnsupportedProps.OfPieSplitPosition != 2.0)
				{
					@class.delegate1923_0().Val = pPTXUnsupportedProps.OfPieSplitPosition;
				}
				if (@class.delegate2081_0 != null)
				{
					@class.delegate2081_0().Val = pPTXUnsupportedProps.OfPieSplitType;
				}
				if (pPTXUnsupportedProps.OfPieCustomSplitPoints.Count > 0)
				{
					Class2062 class2 = @class.delegate1898_0();
					foreach (IChartDataPoint ofPieCustomSplitPoint in pPTXUnsupportedProps.OfPieCustomSplitPoints)
					{
						class2.delegate2136_0().Val = (uint)seriesGroup.Series[0].DataPoints[ofPieCustomSplitPoint];
					}
				}
				if (@class.delegate2763_0 != null)
				{
					@class.delegate2763_0().Val = seriesGroup.IsColorVaried;
				}
				if (@class.delegate1875_0 != null)
				{
					@class.delegate1875_0().Val = (uint)pPTXUnsupportedProps.BubbleSizeScale;
				}
				if (@class.delegate304_0 != null)
				{
					@class.delegate304_0(pPTXUnsupportedProps.SurfaceBandFormats);
				}
				if (@class.delegate1535_0 != null)
				{
					@class.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
				}
				if (@class.delegate1920_0 != null)
				{
					Class2069 class3 = @class.delegate1920_0();
					class3.delegate2763_0().Val = false;
					class3.delegate2763_1().Val = false;
					class3.delegate2763_2().Val = false;
					class3.delegate2763_3().Val = false;
					class3.delegate2763_4().Val = false;
					class3.delegate2763_5().Val = false;
					class3.delegate2763_6().Val = false;
				}
				IAxis[] array = smethod_4(seriesGroup.Type, seriesGroup.PlotOnSecondAxis, chart.Axes);
				for (int i = 0; i < array.Length; i++)
				{
					Axis axis = (Axis)array[i];
					if (@class.delegate1201_0 != null)
					{
						@class.delegate1201_0().Val = axis?.PPTXUnsupportedProps.AxisId ?? 0;
					}
					else
					{
						if (@class.AxIdList.Length <= 0)
						{
							throw new Exception();
						}
						@class.AxIdList[i].Val = axis.PPTXUnsupportedProps.AxisId;
					}
				}
			}
			return;
		}
		Class2021 class4 = smethod_3(ChartTypeCharacterizer.smethod_2(chart.Type), chart.Type, plotAreaElementData);
		IAxis[] array2 = smethod_4(ChartTypeCharacterizer.smethod_2(chart.Type), plotOnSecondAxis: false, chart.Axes);
		int num = 0;
		while (true)
		{
			if (num >= array2.Length)
			{
				return;
			}
			Axis axis2 = (Axis)array2[num];
			if (class4.delegate1201_0 != null)
			{
				class4.delegate1201_0().Val = axis2?.PPTXUnsupportedProps.AxisId ?? 0;
			}
			else
			{
				if (class4.AxIdList.Length <= 0)
				{
					break;
				}
				class4.AxIdList[num].Val = axis2.PPTXUnsupportedProps.AxisId;
			}
			num++;
		}
		throw new Exception();
	}

	private static Class2021 smethod_3(CombinableSeriesTypesGroup type, ChartType typeOfFirstGroupSeries, Class2106 plotAreaElementData)
	{
		switch (type)
		{
		default:
			throw new Exception();
		case CombinableSeriesTypesGroup.AreaChart_Area:
			return (Class2023)plotAreaElementData.delegate2773_1("areaChart").Object;
		case CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea:
		{
			Class2023 class23 = (Class2023)plotAreaElementData.delegate2773_1("areaChart").Object;
			class23.delegate1946_0().Val = Enum317.const_1;
			return class23;
		}
		case CombinableSeriesTypesGroup.AreaChart_StackedArea:
		{
			Class2023 class22 = (Class2023)plotAreaElementData.delegate2773_1("areaChart").Object;
			class22.delegate1946_0().Val = Enum317.const_3;
			return class22;
		}
		case CombinableSeriesTypesGroup.AreaChart_Area3D:
			return (Class2022)plotAreaElementData.delegate2773_1("area3DChart").Object;
		case CombinableSeriesTypesGroup.AreaChart_StackedArea3D:
		{
			Class2022 class21 = (Class2022)plotAreaElementData.delegate2773_1("area3DChart").Object;
			class21.delegate1946_0().Val = Enum317.const_3;
			return class21;
		}
		case CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea3D:
		{
			Class2022 class20 = (Class2022)plotAreaElementData.delegate2773_1("area3DChart").Object;
			class20.delegate1946_0().Val = Enum317.const_1;
			return class20;
		}
		case CombinableSeriesTypesGroup.LineChart_Line:
		{
			Class2029 class19 = (Class2029)plotAreaElementData.delegate2773_1("lineChart").Object;
			class19.Grouping.Val = Enum317.const_2;
			return class19;
		}
		case CombinableSeriesTypesGroup.LineChart_StackedLine:
		{
			Class2029 class18 = (Class2029)plotAreaElementData.delegate2773_1("lineChart").Object;
			class18.Grouping.Val = Enum317.const_3;
			return class18;
		}
		case CombinableSeriesTypesGroup.LineChart_PercentsStackedLine:
		{
			Class2029 class17 = (Class2029)plotAreaElementData.delegate2773_1("lineChart").Object;
			class17.Grouping.Val = Enum317.const_1;
			return class17;
		}
		case CombinableSeriesTypesGroup.Line3DChart:
		{
			Class2028 class16 = (Class2028)plotAreaElementData.delegate2773_1("line3DChart").Object;
			class16.Grouping.Val = Enum317.const_2;
			return class16;
		}
		case CombinableSeriesTypesGroup.StockHighLowClose:
		case CombinableSeriesTypesGroup.StockOpenHighLowClose:
		case CombinableSeriesTypesGroup.StockVolumeHighLowClose:
		case CombinableSeriesTypesGroup.StockVolumeOpenHighLowClose:
			return (Class2035)plotAreaElementData.delegate2773_1("stockChart").Object;
		case CombinableSeriesTypesGroup.RadarChart:
		{
			Class2033 class15 = (Class2033)plotAreaElementData.delegate2773_1("radarChart").Object;
			class15.RadarStyle.Val = Enum322.const_1;
			return class15;
		}
		case CombinableSeriesTypesGroup.FilledRadarChart:
		{
			Class2033 class14 = (Class2033)plotAreaElementData.delegate2773_1("radarChart").Object;
			class14.RadarStyle.Val = Enum322.const_3;
			return class14;
		}
		case CombinableSeriesTypesGroup.ScatterStraightMarker:
		{
			Class2034 class13 = (Class2034)plotAreaElementData.delegate2773_1("scatterChart").Object;
			class13.ScatterStyle.Val = Enum323.const_3;
			return class13;
		}
		case CombinableSeriesTypesGroup.ScatterSmoothMarker:
		{
			Class2034 class12 = (Class2034)plotAreaElementData.delegate2773_1("scatterChart").Object;
			class12.ScatterStyle.Val = Enum323.const_6;
			return class12;
		}
		case CombinableSeriesTypesGroup.PieChart:
			return (Class2032)plotAreaElementData.delegate2773_1("pieChart").Object;
		case CombinableSeriesTypesGroup.Pie3DChart:
			return (Class2031)plotAreaElementData.delegate2773_1("pie3DChart").Object;
		case CombinableSeriesTypesGroup.DoughnutChart:
			return (Class2027)plotAreaElementData.delegate2773_1("doughnutChart").Object;
		case CombinableSeriesTypesGroup.BarChart_VertClustered:
		{
			Class2025 class11 = (Class2025)plotAreaElementData.delegate2773_1("barChart").Object;
			class11.BarDir.Val = Enum315.const_2;
			class11.delegate1870_0().Val = Enum316.const_2;
			return class11;
		}
		case CombinableSeriesTypesGroup.BarChart_VertStacked:
		{
			Class2025 class10 = (Class2025)plotAreaElementData.delegate2773_1("barChart").Object;
			class10.BarDir.Val = Enum315.const_2;
			class10.delegate1870_0().Val = Enum316.const_4;
			return class10;
		}
		case CombinableSeriesTypesGroup.BarChart_VertPercentsStacked:
		{
			Class2025 class9 = (Class2025)plotAreaElementData.delegate2773_1("barChart").Object;
			class9.BarDir.Val = Enum315.const_2;
			class9.delegate1870_0().Val = Enum316.const_1;
			return class9;
		}
		case CombinableSeriesTypesGroup.BarChart_HorizClustered:
		{
			Class2025 class8 = (Class2025)plotAreaElementData.delegate2773_1("barChart").Object;
			class8.BarDir.Val = Enum315.const_1;
			class8.delegate1870_0().Val = Enum316.const_2;
			return class8;
		}
		case CombinableSeriesTypesGroup.BarChart_HorizStacked:
		{
			Class2025 class7 = (Class2025)plotAreaElementData.delegate2773_1("barChart").Object;
			class7.BarDir.Val = Enum315.const_1;
			class7.delegate1870_0().Val = Enum316.const_4;
			return class7;
		}
		case CombinableSeriesTypesGroup.BarChart_HorizPercentsStacked:
		{
			Class2025 class6 = (Class2025)plotAreaElementData.delegate2773_1("barChart").Object;
			class6.BarDir.Val = Enum315.const_1;
			class6.delegate1870_0().Val = Enum316.const_1;
			return class6;
		}
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
		{
			Class2024 class5 = (Class2024)plotAreaElementData.delegate2773_1("bar3DChart").Object;
			class5.BarDir.Val = (Enum315)Class912.Bar3DChartTypesTable[typeOfFirstGroupSeries][0];
			class5.delegate1870_0().Val = (Enum316)Class912.Bar3DChartTypesTable[typeOfFirstGroupSeries][1];
			class5.delegate2072_0().Val = (ChartShapeType)Class912.Bar3DChartTypesTable[typeOfFirstGroupSeries][2];
			return class5;
		}
		case CombinableSeriesTypesGroup.BarOfPieChart:
		{
			Class2030 class4 = (Class2030)plotAreaElementData.delegate2773_1("ofPieChart").Object;
			class4.OfPieType.Val = Enum320.const_2;
			return class4;
		}
		case CombinableSeriesTypesGroup.PieOfPieChart:
		{
			Class2030 class3 = (Class2030)plotAreaElementData.delegate2773_1("ofPieChart").Object;
			class3.OfPieType.Val = Enum320.const_1;
			return class3;
		}
		case CombinableSeriesTypesGroup.SurfaceChart_Contour:
			return (Class2037)plotAreaElementData.delegate2773_1("surfaceChart").Object;
		case CombinableSeriesTypesGroup.SurfaceChart_WireframeContour:
		{
			Class2037 class2 = (Class2037)plotAreaElementData.delegate2773_1("surfaceChart").Object;
			class2.delegate2763_2().Val = true;
			return class2;
		}
		case CombinableSeriesTypesGroup.SurfaceChart_Surface3D:
			return (Class2036)plotAreaElementData.delegate2773_1("surface3DChart").Object;
		case CombinableSeriesTypesGroup.SurfaceChart_WireframeSurface3D:
		{
			Class2036 @class = (Class2036)plotAreaElementData.delegate2773_1("surface3DChart").Object;
			@class.delegate2763_2().Val = true;
			return @class;
		}
		case CombinableSeriesTypesGroup.BubbleChart:
			return (Class2026)plotAreaElementData.delegate2773_1("bubbleChart").Object;
		}
	}

	private static IAxis[] smethod_4(CombinableSeriesTypesGroup type, bool plotOnSecondAxis, IAxesManager axes)
	{
		IAxis axis;
		IAxis axis2;
		if (!plotOnSecondAxis)
		{
			axis = axes.HorizontalAxis;
			axis2 = axes.VerticalAxis;
		}
		else
		{
			axis = axes.SecondaryHorizontalAxis;
			axis2 = axes.SecondaryVerticalAxis;
		}
		switch (type)
		{
		default:
			throw new Exception();
		case CombinableSeriesTypesGroup.AreaChart_Area:
		case CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea:
		case CombinableSeriesTypesGroup.AreaChart_StackedArea:
			return new IAxis[2] { axis, axis2 };
		case CombinableSeriesTypesGroup.AreaChart_Area3D:
		case CombinableSeriesTypesGroup.AreaChart_StackedArea3D:
		case CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea3D:
			return new IAxis[3] { axis, axis2, axes.SeriesAxis };
		case CombinableSeriesTypesGroup.LineChart_Line:
		case CombinableSeriesTypesGroup.LineChart_StackedLine:
		case CombinableSeriesTypesGroup.LineChart_PercentsStackedLine:
			return new IAxis[2] { axis, axis2 };
		case CombinableSeriesTypesGroup.Line3DChart:
			return new IAxis[3] { axis, axis2, axes.SeriesAxis };
		case CombinableSeriesTypesGroup.StockHighLowClose:
		case CombinableSeriesTypesGroup.StockOpenHighLowClose:
		case CombinableSeriesTypesGroup.StockVolumeHighLowClose:
		case CombinableSeriesTypesGroup.StockVolumeOpenHighLowClose:
			return new IAxis[2] { axis, axis2 };
		case CombinableSeriesTypesGroup.RadarChart:
		case CombinableSeriesTypesGroup.FilledRadarChart:
			return new IAxis[2] { axis, axis2 };
		case CombinableSeriesTypesGroup.ScatterStraightMarker:
		case CombinableSeriesTypesGroup.ScatterSmoothMarker:
			return new IAxis[2] { axis, axis2 };
		case CombinableSeriesTypesGroup.PieChart:
			return new IAxis[0];
		case CombinableSeriesTypesGroup.Pie3DChart:
			return new IAxis[0];
		case CombinableSeriesTypesGroup.DoughnutChart:
			return new IAxis[0];
		case CombinableSeriesTypesGroup.BarChart_VertClustered:
		case CombinableSeriesTypesGroup.BarChart_VertStacked:
		case CombinableSeriesTypesGroup.BarChart_VertPercentsStacked:
			return new IAxis[2] { axis, axis2 };
		case CombinableSeriesTypesGroup.BarChart_HorizClustered:
		case CombinableSeriesTypesGroup.BarChart_HorizStacked:
		case CombinableSeriesTypesGroup.BarChart_HorizPercentsStacked:
			return new IAxis[2] { axis2, axis };
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
			return new IAxis[3] { axis, axis2, axes.SeriesAxis };
		case CombinableSeriesTypesGroup.Bar3DChart_HorizClustered:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedBar3D:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedCone:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedCylinder:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedPyramid:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedBar3D:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedCone:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedCylinder:
		case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedPyramid:
			return new IAxis[3] { axis2, axis, axes.SeriesAxis };
		case CombinableSeriesTypesGroup.BarOfPieChart:
		case CombinableSeriesTypesGroup.PieOfPieChart:
			return new IAxis[0];
		case CombinableSeriesTypesGroup.SurfaceChart_Contour:
		case CombinableSeriesTypesGroup.SurfaceChart_WireframeContour:
			return new IAxis[3] { axis, axis2, axes.SeriesAxis };
		case CombinableSeriesTypesGroup.SurfaceChart_Surface3D:
		case CombinableSeriesTypesGroup.SurfaceChart_WireframeSurface3D:
			return new IAxis[3] { axis, axis2, axes.SeriesAxis };
		case CombinableSeriesTypesGroup.BubbleChart:
			return new IAxis[2] { axis, axis2 };
		}
	}
}
