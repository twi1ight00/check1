using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns56;

namespace ns17;

internal class Class903
{
	private static SortedList<int, string> BuiltInNumberFormatsList
	{
		get
		{
			SortedList<int, string> sortedList = new SortedList<int, string>();
			sortedList.Add(0, "General");
			sortedList.Add(1, "0");
			sortedList.Add(2, "0.00");
			sortedList.Add(3, "#,##0");
			sortedList.Add(4, "#,##0.00");
			sortedList.Add(5, "$#,##0;$-#,##0");
			sortedList.Add(6, "$#,##0;[Red]$-#,##0");
			sortedList.Add(7, "$#,##0.00;$-#,##0.00");
			sortedList.Add(8, "$#,##0.00;[Red]$-#,##0.00");
			sortedList.Add(9, "0%");
			sortedList.Add(10, "0.00%");
			sortedList.Add(11, "0.00E+00");
			sortedList.Add(12, "# ?/?");
			sortedList.Add(13, "# /");
			sortedList.Add(14, "m/d/yy");
			sortedList.Add(15, "d-mmm-yy");
			sortedList.Add(16, "d-mmm");
			sortedList.Add(17, "mmm-yy");
			sortedList.Add(18, "h:mm AM/PM");
			sortedList.Add(19, "h:mm:ss AM/PM");
			sortedList.Add(20, "h:mm");
			sortedList.Add(21, "h:mm:ss");
			sortedList.Add(22, "m/d/yy h:mm");
			sortedList.Add(37, "#,##0;-#,##0");
			sortedList.Add(38, "#,##0;[Red]-#,##0");
			sortedList.Add(39, "#,##0.00;-#,##0.00");
			sortedList.Add(40, "#,##0.00;[Red]-#,##0.00");
			sortedList.Add(41, "_ * #,##0_ ;_ * \"_ ;_ @_");
			sortedList.Add(42, "_ $* #,##0_ ;_ $* \"_ ;_ @_");
			sortedList.Add(43, "_ * #,##0.00_ ;_ * \"??_ ;_ @_");
			sortedList.Add(44, "_ $* #,##0.00_ ;_ $* \"??_ ;_ @_");
			sortedList.Add(45, "mm:ss");
			sortedList.Add(46, "h :mm:ss");
			sortedList.Add(47, "mm:ss.0");
			sortedList.Add(48, "##0.0E+00");
			sortedList.Add(49, "@");
			return sortedList;
		}
	}

	public static void smethod_0(IAxesManager axesManager, Class2106 plotAreaElementData, Class892 chartPartDeserializationContext)
	{
		if (plotAreaElementData == null)
		{
			throw new Exception("plotAreaElementData must not be null.");
		}
		if (plotAreaElementData.AxisList.Length == 2)
		{
			Class2053 @class = null;
			Class2053 class2 = null;
			for (int i = 0; i < 2; i++)
			{
				if (smethod_1((Class2053)plotAreaElementData.AxisList[i].Object))
				{
					@class = (Class2053)plotAreaElementData.AxisList[i].Object;
					break;
				}
			}
			for (int j = 0; j < 2; j++)
			{
				if (smethod_2((Class2053)plotAreaElementData.AxisList[j].Object))
				{
					class2 = (Class2053)plotAreaElementData.AxisList[j].Object;
					break;
				}
			}
			if (@class != null && class2 != null)
			{
				Class905.smethod_0(axesManager.HorizontalAxis, @class, chartPartDeserializationContext);
				Class905.smethod_0(axesManager.VerticalAxis, class2, chartPartDeserializationContext);
			}
		}
		else if (plotAreaElementData.AxisList.Length == 3)
		{
			Class2053 class3 = null;
			Class2053 class4 = null;
			Class2053 class5 = null;
			for (int k = 0; k < 3; k++)
			{
				if (smethod_1((Class2053)plotAreaElementData.AxisList[k].Object))
				{
					class3 = (Class2053)plotAreaElementData.AxisList[k].Object;
					break;
				}
			}
			for (int l = 0; l < 3; l++)
			{
				if (smethod_2((Class2053)plotAreaElementData.AxisList[l].Object))
				{
					class4 = (Class2053)plotAreaElementData.AxisList[l].Object;
					break;
				}
			}
			for (int m = 0; m < 3; m++)
			{
				if (plotAreaElementData.AxisList[m].Object is Class2056)
				{
					class5 = (Class2053)plotAreaElementData.AxisList[m].Object;
					break;
				}
			}
			if (class3 != null && class4 != null && class5 != null)
			{
				Class905.smethod_0(axesManager.HorizontalAxis, class3, chartPartDeserializationContext);
				Class905.smethod_0(axesManager.VerticalAxis, class4, chartPartDeserializationContext);
				if (axesManager.SeriesAxis != null)
				{
					Class905.smethod_0(axesManager.SeriesAxis, class5, chartPartDeserializationContext);
				}
				else
				{
					((AxesManager)axesManager).SeriesAxisUnsupported = (Class2056)class5;
				}
			}
		}
		else if (plotAreaElementData.AxisList.Length == 4)
		{
			Class2053 class6 = null;
			Class2053 class7 = null;
			Class2053 class8 = null;
			Class2053 class9 = null;
			for (int n = 0; n < 2; n++)
			{
				if (smethod_1((Class2053)plotAreaElementData.AxisList[n].Object))
				{
					class6 = (Class2053)plotAreaElementData.AxisList[n].Object;
					break;
				}
			}
			for (int num = 0; num < 2; num++)
			{
				if (smethod_2((Class2053)plotAreaElementData.AxisList[num].Object))
				{
					class7 = (Class2053)plotAreaElementData.AxisList[num].Object;
					break;
				}
			}
			for (int num2 = 2; num2 < 4; num2++)
			{
				if (smethod_1((Class2053)plotAreaElementData.AxisList[num2].Object))
				{
					class8 = (Class2053)plotAreaElementData.AxisList[num2].Object;
					break;
				}
			}
			for (int num3 = 2; num3 < 4; num3++)
			{
				if (smethod_2((Class2053)plotAreaElementData.AxisList[num3].Object))
				{
					class9 = (Class2053)plotAreaElementData.AxisList[num3].Object;
					break;
				}
			}
			if (class6 != null && class7 != null && class8 != null && class9 != null)
			{
				Class905.smethod_0(axesManager.HorizontalAxis, class6, chartPartDeserializationContext);
				Class905.smethod_0(axesManager.VerticalAxis, class7, chartPartDeserializationContext);
				Class905.smethod_0(axesManager.SecondaryHorizontalAxis, class8, chartPartDeserializationContext);
				Class905.smethod_0(axesManager.SecondaryVerticalAxis, class9, chartPartDeserializationContext);
			}
		}
		else
		{
			_ = plotAreaElementData.AxisList.Length;
		}
	}

	private static bool smethod_1(Class2053 axis)
	{
		if (axis.AxPos.Val != 0)
		{
			return axis.AxPos.Val == AxisPositionType.Top;
		}
		return true;
	}

	private static bool smethod_2(Class2053 axis)
	{
		if (axis.AxPos.Val != AxisPositionType.Left)
		{
			return axis.AxPos.Val == AxisPositionType.Right;
		}
		return true;
	}

	internal static List<int> smethod_3(Class892 chartPartDeserializationContext)
	{
		List<int> list = new List<int>();
		Class2106 plotAreaElementData = chartPartDeserializationContext.PlotAreaElementData;
		if (plotAreaElementData.AxisList.Length == 3)
		{
			if (plotAreaElementData.AxisList[2].Object is Class2056)
			{
			}
		}
		else if (plotAreaElementData.AxisList.Length == 4)
		{
			Class2053 @class = (Class2053)plotAreaElementData.AxisList[2].Object;
			list.Add(@class.AxId.Val);
			@class = (Class2053)plotAreaElementData.AxisList[3].Object;
			list.Add(@class.AxId.Val);
		}
		else
		{
			_ = plotAreaElementData.AxisList.Length;
		}
		return list;
	}

	public static void smethod_4(IChart chart, Class2106 plotAreaElementData, Class1346 serializationContext)
	{
		IChartData chartData = chart.ChartData;
		IAxesManager axes = chart.Axes;
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		IChartSeries chartSeries = null;
		IChartSeries chartSeries2 = null;
		if (chartData.Series.Count > 0)
		{
			foreach (IChartSeries item in chartData.Series)
			{
				string[] array = smethod_8(item.Type);
				if (!item.PlotOnSecondAxis)
				{
					if (text == null)
					{
						text = array[0];
					}
					else if (text == "xVal" && array[0] == "cat")
					{
						text = array[0];
					}
					else if (!smethod_5(text, array[0]))
					{
						throw new Exception();
					}
					if (text2 == null)
					{
						text2 = array[1];
					}
					else if (!smethod_5(text2, array[1]))
					{
						throw new Exception();
					}
					if (chartSeries == null)
					{
						chartSeries = item;
					}
				}
				else
				{
					if (text3 == null)
					{
						text3 = array[0];
					}
					else if (text3 == "xVal" && array[0] == "cat")
					{
						text3 = array[0];
					}
					else if (!smethod_5(text3, array[0]))
					{
						throw new Exception();
					}
					if (text4 == null)
					{
						text4 = array[1];
					}
					else if (!smethod_5(text4, array[1]))
					{
						throw new Exception();
					}
					if (chartSeries2 == null)
					{
						chartSeries2 = item;
					}
				}
				if (text5 == null)
				{
					text5 = array[2];
				}
				else if (!smethod_5(text5, array[2]))
				{
					throw new Exception();
				}
			}
		}
		else
		{
			string[] array2 = smethod_8(chart.Type);
			text = array2[0];
			text2 = array2[1];
			text5 = array2[2];
		}
		Dictionary<IAxis, string> dictionary = new Dictionary<IAxis, string>();
		if (axes.HorizontalAxis != null)
		{
			dictionary.Add(axes.HorizontalAxis, text);
		}
		if (axes.VerticalAxis != null)
		{
			dictionary.Add(axes.VerticalAxis, text2);
		}
		if (axes.SecondaryHorizontalAxis != null)
		{
			dictionary.Add(axes.SecondaryHorizontalAxis, text3);
		}
		if (axes.SecondaryVerticalAxis != null)
		{
			dictionary.Add(axes.SecondaryVerticalAxis, text4);
		}
		if (axes.SeriesAxis != null)
		{
			dictionary.Add(axes.SeriesAxis, text5);
		}
		Dictionary<IAxis, IChartSeries> dictionary2 = new Dictionary<IAxis, IChartSeries>();
		if (axes.HorizontalAxis != null)
		{
			dictionary2.Add(axes.HorizontalAxis, chartSeries);
		}
		if (axes.VerticalAxis != null)
		{
			dictionary2.Add(axes.VerticalAxis, chartSeries);
		}
		if (axes.SecondaryHorizontalAxis != null)
		{
			dictionary2.Add(axes.SecondaryHorizontalAxis, chartSeries2);
		}
		if (axes.SecondaryVerticalAxis != null)
		{
			dictionary2.Add(axes.SecondaryVerticalAxis, chartSeries2);
		}
		IAxis[] array3 = smethod_9(chartData.SeriesGroups, axes);
		IAxis[] array4 = array3;
		for (int i = 0; i < array4.Length; i++)
		{
			Axis axis = (Axis)array4[i];
			if (axis != null)
			{
				smethod_6(axis, dictionary, dictionary2, chart, plotAreaElementData, serializationContext);
			}
		}
		int num = 0;
		IAxis[] array5 = array3;
		foreach (IAxis axis2 in array5)
		{
			if (axis2 == null)
			{
				continue;
			}
			Class2053 @class = (Class2053)plotAreaElementData.AxisList[num].Object;
			num++;
			for (int k = 0; k < plotAreaElementData.AxisList.Length; k++)
			{
				Class2053 class2 = (Class2053)plotAreaElementData.AxisList[k].Object;
				if (class2.AxId.Val == @class.CrossAx.Val)
				{
					if (axis2.CrossType == CrossesType.Custom)
					{
						Class2070 class3 = ((class2.Crossing == null) ? ((Class2070)class2.delegate2773_0("crossesAt").Object) : ((Class2070)class2.Crossing.Object));
						class3.Val = axis2.CrossAt;
					}
					else
					{
						Class2061 class4 = ((class2.Crossing == null) ? ((Class2061)class2.delegate2773_0("crosses").Object) : ((Class2061)class2.Crossing.Object));
						class4.Val = axis2.CrossType;
					}
				}
			}
		}
	}

	private static bool smethod_5(string coordType, string coordTypeNew)
	{
		if (coordTypeNew != null && !(coordType == coordTypeNew))
		{
			switch (coordType)
			{
			case "xVal":
			case "yVal":
			case "val":
				switch (coordTypeNew)
				{
				case "xVal":
				case "yVal":
				case "val":
					return true;
				}
				break;
			}
			if (coordType == "cat" && coordTypeNew == "xVal")
			{
				return true;
			}
			return false;
		}
		return true;
	}

	private static void smethod_6(Axis axis, Dictionary<IAxis, string> axisToSeriesCoordinateTypeUsed, Dictionary<IAxis, IChartSeries> axisToSampleSeriesThatUsesItAxis, IChart chart, Class2106 plotAreaElementData, Class1346 serializationContext)
	{
		axisToSeriesCoordinateTypeUsed.TryGetValue(axis, out var value);
		axisToSampleSeriesThatUsesItAxis.TryGetValue(axis, out var value2);
		Class2053 axisElementData;
		switch (value)
		{
		case "cat":
			axisElementData = ((axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2) ? ((Class2053)plotAreaElementData.delegate2773_0("catAx").Object) : ((Class2053)plotAreaElementData.delegate2773_0("dateAx").Object));
			if (axis.IsNumberFormatLinkedToSource)
			{
				IChartCategoryCollection chartCategoryCollection = ((value2 == null || !value2.PlotOnSecondAxis || !chart.ChartData.UseSecondaryCategories) ? chart.ChartData.Categories : chart.ChartData.SecondaryCategories);
				IChartDataCell chartDataCell = null;
				if (chartCategoryCollection.Count > 0 && chartCategoryCollection.UseCells)
				{
					chartDataCell = chartCategoryCollection[0].AsCell;
				}
				if (chartDataCell != null)
				{
					axis.NumberFormat = ((chartDataCell.CustomNumberFormat.Trim() != "") ? chartDataCell.CustomNumberFormat : smethod_7(chartDataCell.PresetNumberFormat));
				}
			}
			goto IL_033c;
		case "val":
			axisElementData = (Class2053)plotAreaElementData.delegate2773_0("valAx").Object;
			if (axis.IsNumberFormatLinkedToSource && value2 != null && value2.DataPoints.DataSourceTypeForValues == DataSourceType.Worksheet && value2.DataPoints.Count > 0)
			{
				IChartDataCell asCell2 = value2.DataPoints[0].Value.AsCell;
				axis.NumberFormat = ((asCell2.CustomNumberFormat.Trim() != "") ? asCell2.CustomNumberFormat : smethod_7(asCell2.PresetNumberFormat));
			}
			goto IL_033c;
		case "xVal":
			axisElementData = (Class2053)plotAreaElementData.delegate2773_0("valAx").Object;
			if (axis.IsNumberFormatLinkedToSource && value2 != null && value2.DataPoints.DataSourceTypeForXValues == DataSourceType.Worksheet && value2.DataPoints.Count > 0)
			{
				IChartDataCell asCell3 = value2.DataPoints[0].XValue.AsCell;
				axis.NumberFormat = ((asCell3.CustomNumberFormat.Trim() != "") ? asCell3.CustomNumberFormat : smethod_7(asCell3.PresetNumberFormat));
			}
			goto IL_033c;
		case "yVal":
			axisElementData = (Class2053)plotAreaElementData.delegate2773_0("valAx").Object;
			if (axis.IsNumberFormatLinkedToSource && value2 != null && value2.DataPoints.DataSourceTypeForYValues == DataSourceType.Worksheet && value2.DataPoints.Count > 0)
			{
				IChartDataCell asCell = value2.DataPoints[0].YValue.AsCell;
				axis.NumberFormat = ((asCell.CustomNumberFormat.Trim() != "") ? asCell.CustomNumberFormat : smethod_7(asCell.PresetNumberFormat));
			}
			goto IL_033c;
		case "ser":
			axisElementData = (Class2053)plotAreaElementData.delegate2773_0("serAx").Object;
			goto IL_033c;
		default:
			{
				throw new Exception();
			}
			IL_033c:
			Class905.smethod_2(axis, axisElementData, serializationContext);
			break;
		}
	}

	internal static string smethod_7(int idx)
	{
		if (!BuiltInNumberFormatsList.ContainsKey(idx))
		{
			throw new PptxException("Preset number idx doesn't exist. Preset number must be in [0..22] or [37..49]");
		}
		return BuiltInNumberFormatsList[idx];
	}

	private static string[] smethod_8(ChartType type)
	{
		switch (type)
		{
		default:
			throw new Exception();
		case ChartType.ClusteredColumn:
		case ChartType.StackedColumn:
		case ChartType.PercentsStackedColumn:
			return new string[3] { "cat", "val", null };
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
			return new string[3] { "cat", "val", "ser" };
		case ChartType.Line:
		case ChartType.StackedLine:
		case ChartType.PercentsStackedLine:
		case ChartType.LineWithMarkers:
		case ChartType.StackedLineWithMarkers:
		case ChartType.PercentsStackedLineWithMarkers:
			return new string[3] { "cat", "val", null };
		case ChartType.Line3D:
			return new string[3] { "cat", "val", "ser" };
		case ChartType.Pie:
		case ChartType.ExplodedPie:
			return new string[3];
		case ChartType.Pie3D:
		case ChartType.ExplodedPie3D:
			return new string[3];
		case ChartType.PieOfPie:
		case ChartType.BarOfPie:
			return new string[3];
		case ChartType.PercentsStackedBar:
		case ChartType.ClusteredBar:
		case ChartType.StackedBar:
			return new string[3] { "val", "cat", null };
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
			return new string[3] { "val", "cat", "ser" };
		case ChartType.Area:
		case ChartType.StackedArea:
		case ChartType.PercentsStackedArea:
			return new string[3] { "cat", "val", null };
		case ChartType.Area3D:
		case ChartType.StackedArea3D:
		case ChartType.PercentsStackedArea3D:
			return new string[3] { "cat", "val", "ser" };
		case ChartType.ScatterWithMarkers:
		case ChartType.ScatterWithSmoothLinesAndMarkers:
		case ChartType.ScatterWithSmoothLines:
		case ChartType.ScatterWithStraightLinesAndMarkers:
		case ChartType.ScatterWithStraightLines:
			return new string[3] { "xVal", "yVal", null };
		case ChartType.HighLowClose:
		case ChartType.OpenHighLowClose:
		case ChartType.VolumeHighLowClose:
		case ChartType.VolumeOpenHighLowClose:
			return new string[3] { "cat", "val", null };
		case ChartType.Surface3D:
		case ChartType.WireframeSurface3D:
			return new string[3] { "cat", "val", "ser" };
		case ChartType.Contour:
		case ChartType.WireframeContour:
			return new string[3] { "cat", "val", "ser" };
		case ChartType.Doughnut:
		case ChartType.ExplodedDoughnut:
			return new string[3];
		case ChartType.Bubble:
		case ChartType.BubbleWith3D:
			return new string[3] { "xVal", "yVal", null };
		case ChartType.Radar:
		case ChartType.RadarWithMarkers:
		case ChartType.FilledRadar:
			return new string[3] { "cat", "val", null };
		}
	}

	private static IAxis[] smethod_9(IChartSeriesGroupCollection seriesGroups, IAxesManager axes)
	{
		bool flag = false;
		foreach (IChartSeriesGroup seriesGroup in seriesGroups)
		{
			switch (seriesGroup.Type)
			{
			case CombinableSeriesTypesGroup.BarChart_HorizClustered:
			case CombinableSeriesTypesGroup.BarChart_HorizStacked:
			case CombinableSeriesTypesGroup.BarChart_HorizPercentsStacked:
				flag = true;
				break;
			case CombinableSeriesTypesGroup.Bar3DChart_HorizClustered:
			case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedBar3D:
			case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedCone:
			case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedCylinder:
			case CombinableSeriesTypesGroup.Bar3DChart_HorizStackedPyramid:
			case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedBar3D:
			case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedCone:
			case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedCylinder:
			case CombinableSeriesTypesGroup.Bar3DChart_HorizPercentsStackedPyramid:
				flag = true;
				break;
			}
			if (flag)
			{
				break;
			}
		}
		if (!flag)
		{
			return new IAxis[5] { axes.HorizontalAxis, axes.VerticalAxis, axes.SecondaryVerticalAxis, axes.SecondaryHorizontalAxis, axes.SeriesAxis };
		}
		return new IAxis[5] { axes.VerticalAxis, axes.HorizontalAxis, axes.SecondaryHorizontalAxis, axes.SecondaryVerticalAxis, axes.SeriesAxis };
	}
}
