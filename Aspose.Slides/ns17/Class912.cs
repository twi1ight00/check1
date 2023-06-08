using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns18;
using ns25;
using ns53;
using ns55;
using ns56;

namespace ns17;

internal class Class912
{
	private static Dictionary<ChartType, object[]> dictionary_0;

	internal static Dictionary<ChartType, object[]> Bar3DChartTypesTable
	{
		get
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<ChartType, object[]>();
				dictionary_0.Add(ChartType.ClusteredColumn3D, new object[3]
				{
					Enum315.const_2,
					Enum316.const_2,
					ChartShapeType.Box
				});
				dictionary_0.Add(ChartType.StackedColumn3D, new object[3]
				{
					Enum315.const_2,
					Enum316.const_4,
					ChartShapeType.Box
				});
				dictionary_0.Add(ChartType.PercentsStackedColumn3D, new object[3]
				{
					Enum315.const_2,
					Enum316.const_1,
					ChartShapeType.Box
				});
				dictionary_0.Add(ChartType.Column3D, new object[3]
				{
					Enum315.const_2,
					Enum316.const_3,
					ChartShapeType.Box
				});
				dictionary_0.Add(ChartType.ClusteredCylinder, new object[3]
				{
					Enum315.const_2,
					Enum316.const_2,
					ChartShapeType.Cylinder
				});
				dictionary_0.Add(ChartType.StackedCylinder, new object[3]
				{
					Enum315.const_2,
					Enum316.const_4,
					ChartShapeType.Cylinder
				});
				dictionary_0.Add(ChartType.PercentsStackedCylinder, new object[3]
				{
					Enum315.const_2,
					Enum316.const_1,
					ChartShapeType.Cylinder
				});
				dictionary_0.Add(ChartType.Cylinder3D, new object[3]
				{
					Enum315.const_2,
					Enum316.const_3,
					ChartShapeType.Cylinder
				});
				dictionary_0.Add(ChartType.ClusteredCone, new object[3]
				{
					Enum315.const_2,
					Enum316.const_2,
					ChartShapeType.Cone
				});
				dictionary_0.Add(ChartType.StackedCone, new object[3]
				{
					Enum315.const_2,
					Enum316.const_4,
					ChartShapeType.Cone
				});
				dictionary_0.Add(ChartType.PercentsStackedCone, new object[3]
				{
					Enum315.const_2,
					Enum316.const_1,
					ChartShapeType.Cone
				});
				dictionary_0.Add(ChartType.Cone3D, new object[3]
				{
					Enum315.const_2,
					Enum316.const_3,
					ChartShapeType.Cone
				});
				dictionary_0.Add(ChartType.ClusteredPyramid, new object[3]
				{
					Enum315.const_2,
					Enum316.const_2,
					ChartShapeType.Pyramid
				});
				dictionary_0.Add(ChartType.StackedPyramid, new object[3]
				{
					Enum315.const_2,
					Enum316.const_4,
					ChartShapeType.Pyramid
				});
				dictionary_0.Add(ChartType.PercentsStackedPyramid, new object[3]
				{
					Enum315.const_2,
					Enum316.const_1,
					ChartShapeType.Pyramid
				});
				dictionary_0.Add(ChartType.Pyramid3D, new object[3]
				{
					Enum315.const_2,
					Enum316.const_3,
					ChartShapeType.Pyramid
				});
				dictionary_0.Add(ChartType.ClusteredBar3D, new object[3]
				{
					Enum315.const_1,
					Enum316.const_2,
					ChartShapeType.Box
				});
				dictionary_0.Add(ChartType.StackedBar3D, new object[3]
				{
					Enum315.const_1,
					Enum316.const_4,
					ChartShapeType.Box
				});
				dictionary_0.Add(ChartType.PercentsStackedBar3D, new object[3]
				{
					Enum315.const_1,
					Enum316.const_1,
					ChartShapeType.Box
				});
				dictionary_0.Add(ChartType.ClusteredHorizontalCylinder, new object[3]
				{
					Enum315.const_1,
					Enum316.const_2,
					ChartShapeType.Cylinder
				});
				dictionary_0.Add(ChartType.StackedHorizontalCylinder, new object[3]
				{
					Enum315.const_1,
					Enum316.const_4,
					ChartShapeType.Cylinder
				});
				dictionary_0.Add(ChartType.PercentsStackedHorizontalCylinder, new object[3]
				{
					Enum315.const_1,
					Enum316.const_1,
					ChartShapeType.Cylinder
				});
				dictionary_0.Add(ChartType.ClusteredHorizontalCone, new object[3]
				{
					Enum315.const_1,
					Enum316.const_2,
					ChartShapeType.Cone
				});
				dictionary_0.Add(ChartType.StackedHorizontalCone, new object[3]
				{
					Enum315.const_1,
					Enum316.const_4,
					ChartShapeType.Cone
				});
				dictionary_0.Add(ChartType.ClusteredHorizontalPyramid, new object[3]
				{
					Enum315.const_1,
					Enum316.const_2,
					ChartShapeType.Pyramid
				});
				dictionary_0.Add(ChartType.StackedHorizontalPyramid, new object[3]
				{
					Enum315.const_1,
					Enum316.const_4,
					ChartShapeType.Pyramid
				});
				dictionary_0.Add(ChartType.PercentsStackedHorizontalPyramid, new object[3]
				{
					Enum315.const_1,
					Enum316.const_1,
					ChartShapeType.Pyramid
				});
				dictionary_0.Add(ChartType.PercentsStackedHorizontalCone, new object[3]
				{
					Enum315.const_1,
					Enum316.const_1,
					ChartShapeType.Cone
				});
			}
			return dictionary_0;
		}
	}

	public static void smethod_0(IChart chart, Class1991 graphicFrameElementData, Class2020 chartSpaceElementData, Class892 chartPartDeserializationContext)
	{
		if (chartSpaceElementData != null)
		{
			smethod_5(chart, chartSpaceElementData);
			smethod_1(chart, graphicFrameElementData, chartPartDeserializationContext.SlideDeserializationContext);
			smethod_2(chart, chartSpaceElementData, chartPartDeserializationContext.SlideDeserializationContext);
			smethod_3(chart, chartSpaceElementData.Chart.PlotArea, chartPartDeserializationContext);
			smethod_4(chart, chartSpaceElementData.Chart, chartPartDeserializationContext.SlideDeserializationContext.DeserializationContext);
		}
	}

	private static void smethod_1(IChart chart, Class1991 graphicFrameElementData, Class1030 slideDeserializationContext)
	{
		Class1341 deserializationContext = slideDeserializationContext.DeserializationContext;
		Class1348 relationshipsOfCurrentPartEntry = deserializationContext.RelationshipsOfCurrentPartEntry;
		deserializationContext.RelationshipsOfCurrentPartEntry = slideDeserializationContext.RelationshipsOfSlidePart;
		Class959.smethod_0(chart, graphicFrameElementData, slideDeserializationContext);
		deserializationContext.RelationshipsOfCurrentPartEntry = relationshipsOfCurrentPartEntry;
	}

	private static void smethod_2(IChart chart, Class2020 chartSpaceElementData, Class1030 slideDeserializationContext)
	{
		Class1341 deserializationContext = slideDeserializationContext.DeserializationContext;
		Class235.smethod_0(chart, chartSpaceElementData.Style);
		Class983.smethod_0(chart, chartSpaceElementData.SpPr, deserializationContext);
		Class916.smethod_0(chart.TextFormat, chartSpaceElementData.TxPr, deserializationContext);
		Class900.smethod_0(chart.ThemeManager, deserializationContext);
		if (chartSpaceElementData.UserShapes != null)
		{
			slideDeserializationContext.IsChartUserShapesProcessed = true;
			Class1210 @class = new Class1210(deserializationContext.RelationshipsOfCurrentPartEntry[chartSpaceElementData.UserShapes.R_Id].TargetPart, deserializationContext);
			@class.method_5(chart, slideDeserializationContext);
			slideDeserializationContext.IsChartUserShapesProcessed = false;
		}
	}

	private static void smethod_3(IChart chart, Class2106 plotAreaElementData, Class892 chartPartDeserializationContext)
	{
		Class1341 deserializationContext = chartPartDeserializationContext.SlideDeserializationContext.DeserializationContext;
		Class919.smethod_0(chart, plotAreaElementData.DTable, deserializationContext);
		Class910.smethod_0(chart.PlotArea, plotAreaElementData, deserializationContext);
		Class929.smethod_0(chart, plotAreaElementData, deserializationContext);
		Class908.smethod_0(chart.ChartData, plotAreaElementData, chartPartDeserializationContext);
		Class903.smethod_0(chart.Axes, plotAreaElementData, chartPartDeserializationContext);
	}

	private static void smethod_4(IChart chart, Class2058 chartElementData, Class1341 deserializationContext)
	{
		Class914.smethod_0(chart.ChartTitle, chartElementData.Title, deserializationContext);
		chart.HasTitle = chartElementData.Title != null && (chartElementData.AutoTitleDeleted == null || !chartElementData.AutoTitleDeleted.Val);
		Class915.smethod_0(chart.Floor, chartElementData.Floor, deserializationContext);
		Class915.smethod_0(chart.BackWall, chartElementData.BackWall, deserializationContext);
		Class915.smethod_0(chart.SideWall, chartElementData.SideWall, deserializationContext);
		Class923.smethod_0(chart, chartElementData.Legend, deserializationContext);
		if (chartElementData.PlotVisOnly != null)
		{
			chart.PlotVisibleCellsOnly = chartElementData.PlotVisOnly.Val;
		}
		if (chartElementData.DispBlanksAs != null)
		{
			chart.DisplayBlanksAs = chartElementData.DispBlanksAs.Val;
		}
	}

	private static void smethod_5(IChart chart, Class2020 chartSpaceElementData)
	{
		Class288 pPTXUnsupportedProps = ((Chart)chart).PPTXUnsupportedProps;
		pPTXUnsupportedProps.Use1904DateSystem = chartSpaceElementData.Date1904 != null && chartSpaceElementData.Date1904.Val;
		pPTXUnsupportedProps.EditingLanguage = ((chartSpaceElementData.Lang == null) ? null : chartSpaceElementData.Lang.Val);
		pPTXUnsupportedProps.RoundedCorners = chartSpaceElementData.RoundedCorners != null && chartSpaceElementData.RoundedCorners.Val;
		pPTXUnsupportedProps.PivotSource = chartSpaceElementData.PivotSource;
		pPTXUnsupportedProps.Protection = chartSpaceElementData.Protection;
		pPTXUnsupportedProps.PrintSettings = chartSpaceElementData.PrintSettings;
		Class2058 chart2 = chartSpaceElementData.Chart;
		pPTXUnsupportedProps.PivotFormats = chart2.PivotFmts;
		pPTXUnsupportedProps.ExtensionListOfChartSpace = chartSpaceElementData.ExtLst;
		pPTXUnsupportedProps.ExtensionListOfChart = chart2.ExtLst;
		if (chart2.ShowDLblsOverMax != null)
		{
			pPTXUnsupportedProps.ShowDataLabelsOverMaximum = chart2.ShowDLblsOverMax.Val;
		}
		Class931.smethod_0(pPTXUnsupportedProps, chartSpaceElementData.ClrMapOvr);
		Class926.smethod_0(chart, chart2.View3D);
		pPTXUnsupportedProps.ExternalData = chartSpaceElementData.ExternalData;
	}

	internal static ChartType smethod_6(ChartType chartType, Class2038 seriesElementData)
	{
		switch (chartType)
		{
		default:
			throw new Exception();
		case ChartType.ClusteredColumn3D:
		case ChartType.ClusteredCylinder:
		case ChartType.ClusteredCone:
		case ChartType.ClusteredPyramid:
			return ChartType.ClusteredColumn3D;
		case ChartType.StackedColumn3D:
		case ChartType.StackedCylinder:
		case ChartType.StackedCone:
		case ChartType.StackedPyramid:
			return ChartType.StackedColumn3D;
		case ChartType.PercentsStackedColumn3D:
		case ChartType.PercentsStackedCylinder:
		case ChartType.PercentsStackedCone:
		case ChartType.PercentsStackedPyramid:
			return ChartType.PercentsStackedColumn3D;
		case ChartType.Column3D:
		case ChartType.Cylinder3D:
		case ChartType.Cone3D:
		case ChartType.Pyramid3D:
			return ChartType.Column3D;
		case ChartType.PercentsStackedLineWithMarkers:
			if (chartType == ChartType.PercentsStackedLineWithMarkers)
			{
				goto case ChartType.PercentsStackedLine;
			}
			throw new Exception();
		case ChartType.PercentsStackedLine:
			return ChartType.PercentsStackedLine;
		case ChartType.StackedLine:
		case ChartType.StackedLineWithMarkers:
			return ChartType.StackedLine;
		case ChartType.Line:
		case ChartType.LineWithMarkers:
			return ChartType.Line;
		case ChartType.Line3D:
			return chartType;
		case ChartType.Pie:
		case ChartType.ExplodedPie:
			return ChartType.Pie;
		case ChartType.Pie3D:
		case ChartType.ExplodedPie3D:
			return ChartType.Pie3D;
		case ChartType.PieOfPie:
		case ChartType.BarOfPie:
			return chartType;
		case ChartType.ClusteredColumn:
		case ChartType.StackedColumn:
		case ChartType.PercentsStackedColumn:
		case ChartType.PercentsStackedBar:
		case ChartType.ClusteredBar:
		case ChartType.StackedBar:
			return chartType;
		case ChartType.ClusteredBar3D:
		case ChartType.ClusteredHorizontalCylinder:
		case ChartType.ClusteredHorizontalCone:
		case ChartType.ClusteredHorizontalPyramid:
			return ChartType.ClusteredBar3D;
		case ChartType.StackedBar3D:
		case ChartType.StackedHorizontalCylinder:
		case ChartType.StackedHorizontalCone:
		case ChartType.StackedHorizontalPyramid:
			return ChartType.StackedBar3D;
		case ChartType.PercentsStackedBar3D:
		case ChartType.PercentsStackedHorizontalCylinder:
		case ChartType.PercentsStackedHorizontalCone:
		case ChartType.PercentsStackedHorizontalPyramid:
			return ChartType.PercentsStackedBar3D;
		case ChartType.Area:
		case ChartType.StackedArea:
		case ChartType.PercentsStackedArea:
			return chartType;
		case ChartType.Area3D:
		case ChartType.StackedArea3D:
		case ChartType.PercentsStackedArea3D:
			return chartType;
		case ChartType.ScatterWithMarkers:
		case ChartType.ScatterWithSmoothLinesAndMarkers:
		case ChartType.ScatterWithSmoothLines:
		case ChartType.ScatterWithStraightLinesAndMarkers:
		case ChartType.ScatterWithStraightLines:
			return ChartType.ScatterWithStraightLines;
		case ChartType.HighLowClose:
		case ChartType.OpenHighLowClose:
		case ChartType.VolumeHighLowClose:
		case ChartType.VolumeOpenHighLowClose:
			return chartType;
		case ChartType.Surface3D:
		case ChartType.WireframeSurface3D:
			return chartType;
		case ChartType.Contour:
		case ChartType.WireframeContour:
			return chartType;
		case ChartType.Doughnut:
		case ChartType.ExplodedDoughnut:
			return ChartType.Doughnut;
		case ChartType.Bubble:
		case ChartType.BubbleWith3D:
			if (seriesElementData.Bubble3D != null)
			{
				if (seriesElementData.Bubble3D.Val)
				{
					return ChartType.BubbleWith3D;
				}
				return ChartType.Bubble;
			}
			return chartType;
		case ChartType.FilledRadar:
			return chartType;
		case ChartType.Radar:
		case ChartType.RadarWithMarkers:
			return ChartType.Radar;
		}
	}

	internal static ChartType smethod_7(Class2106 plotAreaElementData, int chartListIndex)
	{
		Class2605 @class = plotAreaElementData.ChartList[chartListIndex];
		ChartType result;
		switch (@class.Name)
		{
		case "areaChart":
		{
			Class2023 class4 = (Class2023)@class.Object;
			result = ((class4.Grouping != null && class4.Grouping.Val == Enum317.const_3) ? ChartType.StackedArea : ((class4.Grouping == null || class4.Grouping.Val != Enum317.const_1) ? ChartType.Area : ChartType.PercentsStackedArea));
			break;
		}
		case "area3DChart":
		{
			Class2022 class8 = (Class2022)@class.Object;
			result = ((class8.Grouping != null && class8.Grouping.Val == Enum317.const_3) ? ChartType.StackedArea3D : ((class8.Grouping == null || class8.Grouping.Val != Enum317.const_1) ? ChartType.Area3D : ChartType.PercentsStackedArea3D));
			break;
		}
		case "lineChart":
		{
			Class2029 class13 = (Class2029)@class.Object;
			bool flag = false;
			Class2038[] serList = class13.SerList;
			for (int i = 0; i < serList.Length; i++)
			{
				Class2042 class14 = (Class2042)serList[i];
				if (class14.Marker != null)
				{
					if (class14.Marker != null && class14.Marker.Symbol != null && class14.Marker.Symbol.Val != MarkerStyleType.None)
					{
						flag = true;
						break;
					}
					continue;
				}
				flag = true;
				break;
			}
			result = ((class13.Grouping.Val != Enum317.const_2) ? ((class13.Grouping.Val != Enum317.const_3) ? ((class13.Grouping.Val != Enum317.const_1) ? ChartType.Line : ((!flag) ? ChartType.PercentsStackedLine : ChartType.PercentsStackedLineWithMarkers)) : ((!flag) ? ChartType.StackedLine : ChartType.StackedLineWithMarkers)) : ((flag || (class13.Marker != null && class13.Marker.Val)) ? ChartType.LineWithMarkers : ChartType.Line));
			break;
		}
		case "line3DChart":
		{
			Class2028 class12 = (Class2028)@class.Object;
			if (class12.Grouping.Val != Enum317.const_2)
			{
				throw new NotImplementedException();
			}
			result = ChartType.Line3D;
			break;
		}
		case "stockChart":
			result = ChartType.HighLowClose;
			break;
		case "radarChart":
		{
			Class2033 class9 = (Class2033)@class.Object;
			result = ((class9.RadarStyle.Val != Enum322.const_3) ? ((class9.RadarStyle.Val != Enum322.const_2) ? ChartType.Radar : ChartType.RadarWithMarkers) : ChartType.FilledRadar);
			break;
		}
		case "scatterChart":
		{
			Class2034 class3 = (Class2034)@class.Object;
			result = ((class3.ScatterStyle.Val != Enum323.const_3 && class3.ScatterStyle.Val != Enum323.const_2 && class3.ScatterStyle.Val != Enum323.const_4) ? ((class3.SerList.Length <= 0 || class3.SerList[0].Marker == null || class3.SerList[0].Marker.Symbol == null || class3.SerList[0].Marker.Symbol.Val != MarkerStyleType.None) ? ChartType.ScatterWithSmoothLinesAndMarkers : ChartType.ScatterWithSmoothLines) : ((class3.SerList.Length > 0 && class3.SerList[0].Marker != null && class3.SerList[0].Marker.Symbol != null && class3.SerList[0].Marker.Symbol.Val == MarkerStyleType.None) ? ChartType.ScatterWithStraightLines : ((class3.SerList.Length <= 0 || class3.SerList[0].SpPr == null || class3.SerList[0].SpPr.Ln == null || class3.SerList[0].SpPr.Ln.LineFillProperties == null || !(class3.SerList[0].SpPr.Ln.LineFillProperties.Name == "noFill")) ? ChartType.ScatterWithStraightLinesAndMarkers : ChartType.ScatterWithMarkers)));
			break;
		}
		case "pieChart":
		{
			Class2032 class16 = (Class2032)@class.Object;
			result = ChartType.Pie;
			Class2038[] serList2 = class16.SerList;
			for (int j = 0; j < serList2.Length; j++)
			{
				Class2043 class17 = (Class2043)serList2[j];
				if (class17.Explosion != null)
				{
					result = ChartType.ExplodedPie;
					break;
				}
			}
			break;
		}
		case "pie3DChart":
		{
			Class2031 class18 = (Class2031)@class.Object;
			result = ChartType.Pie3D;
			Class2038[] serList3 = class18.SerList;
			for (int k = 0; k < serList3.Length; k++)
			{
				Class2043 class19 = (Class2043)serList3[k];
				if (class19.Explosion != null)
				{
					result = ChartType.ExplodedPie3D;
					break;
				}
			}
			break;
		}
		case "doughnutChart":
		{
			Class2027 class7 = (Class2027)@class.Object;
			result = ((class7.SerList.Length <= 0 || class7.SerList[0].Explosion == null) ? ChartType.Doughnut : ChartType.ExplodedDoughnut);
			break;
		}
		case "barChart":
		{
			Class2025 class11 = (Class2025)@class.Object;
			result = ChartType.ClusteredBar;
			if (class11.BarDir.Val == Enum315.const_1)
			{
				if (class11.Grouping != null && class11.Grouping.Val == Enum316.const_2)
				{
					result = ChartType.ClusteredBar;
				}
				else if (class11.Grouping != null && class11.Grouping.Val == Enum316.const_4)
				{
					result = ChartType.StackedBar;
				}
				else if (class11.Grouping != null && class11.Grouping.Val == Enum316.const_1)
				{
					result = ChartType.PercentsStackedBar;
				}
			}
			if (class11.BarDir.Val == Enum315.const_2)
			{
				if (class11.Grouping != null && class11.Grouping.Val == Enum316.const_2)
				{
					result = ChartType.ClusteredColumn;
				}
				else if (class11.Grouping != null && class11.Grouping.Val == Enum316.const_4)
				{
					result = ChartType.StackedColumn;
				}
				else if (class11.Grouping != null && class11.Grouping.Val == Enum316.const_1)
				{
					result = ChartType.PercentsStackedColumn;
				}
			}
			break;
		}
		case "bar3DChart":
		{
			Class2024 class6 = (Class2024)@class.Object;
			result = ChartType.ClusteredColumn3D;
			Enum316 @enum = ((class6.Grouping == null) ? Enum316.const_3 : class6.Grouping.Val);
			foreach (KeyValuePair<ChartType, object[]> item in Bar3DChartTypesTable)
			{
				ChartShapeType chartShapeType = ((class6.Shape != null) ? class6.Shape.Val : Class2115.chartShapeType_1);
				if (class6.BarDir.Val == (Enum315)item.Value[0] && @enum == (Enum316)item.Value[1] && chartShapeType == (ChartShapeType)item.Value[2])
				{
					result = item.Key;
					break;
				}
			}
			break;
		}
		case "ofPieChart":
		{
			Class2030 class5 = (Class2030)@class.Object;
			result = ((class5.OfPieType.Val == Enum320.const_1) ? ChartType.PieOfPie : ChartType.BarOfPie);
			break;
		}
		case "surfaceChart":
		{
			Class2037 class15 = (Class2037)@class.Object;
			result = ((class15.Wireframe == null || !class15.Wireframe.Val) ? ChartType.Contour : ChartType.WireframeContour);
			break;
		}
		case "surface3DChart":
		{
			Class2036 class10 = (Class2036)@class.Object;
			result = ((class10.Wireframe == null || !class10.Wireframe.Val) ? ChartType.Surface3D : ChartType.WireframeSurface3D);
			break;
		}
		case "bubbleChart":
		{
			Class2026 class2 = (Class2026)@class.Object;
			result = ((class2.Bubble3D == null) ? ((class2.SerList.Length <= 0 || class2.SerList[0].Bubble3D == null || !class2.SerList[0].Bubble3D.Val) ? ChartType.Bubble : ChartType.BubbleWith3D) : ((!class2.Bubble3D.Val) ? ChartType.Bubble : ChartType.BubbleWith3D));
			break;
		}
		default:
			throw new Exception("Unknown element \"" + @class.Name + "\"");
		}
		return result;
	}

	public static void smethod_8(IChart chart, Class2020 chartSpaceElementData, Class1991 graphicFrameElementData, Class882 chartPartSerializationContext)
	{
		smethod_9(chart, graphicFrameElementData, chartPartSerializationContext.SlideSerializationContext);
		smethod_10(chart, chartSpaceElementData, chartPartSerializationContext);
		smethod_12(chart, chartSpaceElementData.Chart.PlotArea, chartPartSerializationContext);
		smethod_11(chart, chartSpaceElementData.Chart, chartPartSerializationContext.SlideSerializationContext.SerializationContext);
		smethod_13(chart, chartSpaceElementData, chartPartSerializationContext.SlideSerializationContext.SerializationContext);
	}

	private static void smethod_9(IChart chart, Class1991 graphicFrameElementData, Class1031 slideSerializationContext)
	{
		Class1346 serializationContext = slideSerializationContext.SerializationContext;
		Class1348 relationshipsOfCurrentPartEntry = serializationContext.RelationshipsOfCurrentPartEntry;
		serializationContext.RelationshipsOfCurrentPartEntry = slideSerializationContext.RelationshipsOfSlidePart;
		Class959.smethod_2(chart, graphicFrameElementData, slideSerializationContext.SerializationContext);
		serializationContext.RelationshipsOfCurrentPartEntry = relationshipsOfCurrentPartEntry;
	}

	private static void smethod_10(IChart chart, Class2020 chartSpaceElementData, Class882 chartPartSerializationContext)
	{
		Class1346 serializationContext = chartPartSerializationContext.SlideSerializationContext.SerializationContext;
		Class235.smethod_1(chart, chartSpaceElementData.delegate1210_0());
		if (chart.FillFormat.FillType != FillType.NotDefined || !chart.LineFormat.IsFormatNotDefined || !chart.EffectFormat.IsNoEffects || Class1007.smethod_2(chart.ThreeDFormat, shape3d: true))
		{
			Class1921 @class = chartSpaceElementData.delegate1630_0();
			Class949.smethod_1(chart.FillFormat, @class.delegate2773_1, serializationContext);
			Class968.smethod_2(chart.LineFormat, @class.delegate1504_0);
			Class939.smethod_1(chart.EffectFormat, @class.delegate2773_0, serializationContext);
			Class1007.smethod_1(chart.ThreeDFormat, @class.delegate1615_0, @class.delegate1624_0, null);
		}
		Class916.smethod_5(chart.TextFormat, chartSpaceElementData.delegate1705_0, serializationContext);
		Class900.smethod_1(chart.ThemeManager, serializationContext.RelationshipsOfCurrentPartEntry, serializationContext);
		if (chart.UserShapes != null && chart.UserShapes.Shapes.Count > 0)
		{
			Class1342 class2 = serializationContext.Package.method_4("/ppt/drawings/drawing{0}.xml", serializationContext.method_22, new Class1227());
			Class1210 class3 = new Class1210(class2, serializationContext);
			class3.method_6(chart, chartPartSerializationContext);
			chartSpaceElementData.delegate2048_0().R_Id = serializationContext.RelationshipsOfCurrentPartEntry.method_4(class2).Id;
		}
	}

	private static void smethod_11(IChart chart, Class2058 chartElementData, Class1346 serializationContext)
	{
		if (chart.HasTitle)
		{
			Class914.smethod_1(chart.ChartTitle, chartElementData.delegate2115_0, serializationContext);
			chartElementData.delegate2763_0().Val = false;
		}
		Class915.smethod_1(chart.Floor, chartElementData.delegate2099_0, serializationContext);
		Class915.smethod_1(chart.BackWall, chartElementData.delegate2099_2, serializationContext);
		Class915.smethod_1(chart.SideWall, chartElementData.delegate2099_1, serializationContext);
		Class923.smethod_2(chart, chartElementData.delegate1970_0, serializationContext);
		chartElementData.delegate2763_1().Val = chart.PlotVisibleCellsOnly;
		chartElementData.delegate1905_0().Val = chart.DisplayBlanksAs;
	}

	private static void smethod_12(IChart chart, Class2106 plotAreaElementData, Class882 chartPartSerializationContext)
	{
		Class1346 serializationContext = chartPartSerializationContext.SlideSerializationContext.SerializationContext;
		Class919.smethod_1(chart, plotAreaElementData.delegate1930_0, serializationContext);
		Class910.smethod_1(chart.PlotArea, plotAreaElementData, serializationContext);
		Class929.smethod_14(chart, plotAreaElementData, serializationContext);
		Class903.smethod_4(chart, plotAreaElementData, serializationContext);
		Class908.smethod_2(chart, plotAreaElementData, chartPartSerializationContext);
		((Chart)chart).method_27();
	}

	private static void smethod_13(IChart chart, Class2020 chartSpaceElementData, Class1346 serializationContext)
	{
		Class288 pPTXUnsupportedProps = ((Chart)chart).PPTXUnsupportedProps;
		chartSpaceElementData.delegate2763_0().Val = pPTXUnsupportedProps.Use1904DateSystem;
		if (pPTXUnsupportedProps.EditingLanguage != null)
		{
			chartSpaceElementData.delegate2103_0().Val = pPTXUnsupportedProps.EditingLanguage;
		}
		chartSpaceElementData.delegate2763_1().Val = pPTXUnsupportedProps.RoundedCorners;
		chartSpaceElementData.delegate304_0(pPTXUnsupportedProps.PivotSource);
		chartSpaceElementData.delegate304_1(pPTXUnsupportedProps.Protection);
		chartSpaceElementData.delegate304_2(pPTXUnsupportedProps.PrintSettings);
		Class2058 chart2 = chartSpaceElementData.Chart;
		chart2.delegate304_0(pPTXUnsupportedProps.PivotFormats);
		chartSpaceElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfChartSpace);
		chart2.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfChart);
		chart2.delegate2763_2().Val = pPTXUnsupportedProps.ShowDataLabelsOverMaximum;
		Class931.smethod_8(pPTXUnsupportedProps, chartSpaceElementData.delegate1324_0);
		Class926.smethod_2(chart.Rotation3D, chart2.delegate2146_0);
		Class1342 @class = serializationContext.Package.method_4("/ppt/embeddings/Microsoft_Excel_Worksheet" + serializationContext.method_12() + ".xlsx", null, new Class1328());
		@class.Data = chart.ChartData.ReadWorkbookStream().ToArray();
		chartSpaceElementData.delegate1939_0(pPTXUnsupportedProps.ExternalData);
		if (chartSpaceElementData.ExternalData == null)
		{
			chartSpaceElementData.delegate1937_0();
		}
		chartSpaceElementData.ExternalData.R_Id = serializationContext.RelationshipsOfCurrentPartEntry.method_4(@class).Id;
	}
}
