using System;
using System.Collections;
using System.Globalization;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns2;
using ns22;
using ns7;

namespace ns16;

internal class Class1572
{
	private Chart chart_0;

	private Workbook workbook_0;

	private Class1533 class1533_0;

	private Hashtable hashtable_0;

	internal Class1572(Class1533 class1533_1)
	{
		class1533_0 = class1533_1;
		chart_0 = class1533_1.chart_0;
		workbook_0 = class1533_1.class1540_0.workbook_0;
	}

	private void method_0()
	{
		if (chart_0.Legend.method_44() != null)
		{
			hashtable_0 = new Hashtable();
			int num = 0;
			int count = chart_0.NSeries.Count;
			Class1388 @class = chart_0.method_18();
			for (int i = 0; i < @class.Count; i++)
			{
				Class1387 class2 = @class[i];
				for (int j = 0; j < chart_0.NSeries.Count; j++)
				{
					Series series = chart_0.NSeries[j];
					if (series.method_28() != class2 || series.Type != class2.method_11())
					{
						continue;
					}
					hashtable_0.Add(j, num);
					series.method_2(num);
					num++;
					if (series.method_22() != null && series.method_22().Count > 0)
					{
						for (int k = 0; k < series.TrendLines.Count; k++)
						{
							hashtable_0.Add(series.TrendLines[k].method_38() + chart_0.NSeries.Count, count++);
						}
					}
				}
			}
		}
		else
		{
			hashtable_0 = null;
		}
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		method_0();
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("c:chartSpace", null);
		xmlTextWriter_0.WriteAttributeString("xmlns", "c", null, "http://schemas.openxmlformats.org/drawingml/2006/chart");
		xmlTextWriter_0.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		xmlTextWriter_0.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		smethod_5(xmlTextWriter_0, "roundedCorners", chart_0.IsRectangularCornered ? "0" : "1");
		method_1(xmlTextWriter_0);
		if (chart_0.PivotSource != null)
		{
			method_3(xmlTextWriter_0);
		}
		method_5(xmlTextWriter_0);
		method_66(xmlTextWriter_0, chart_0.ChartArea.ShapeProperties);
		if (chart_0.ChartArea.method_12() != null)
		{
			method_63(xmlTextWriter_0, chart_0.ChartArea.method_12(), bool_0: false, 0, null);
		}
		method_4(xmlTextWriter_0);
		method_2(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
		chart_0.method_26(bool_9: false);
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0)
	{
		if (chart_0.class1549_0 != null && chart_0.class1549_0.string_3 != null)
		{
			xmlTextWriter_0.WriteRaw(chart_0.class1549_0.string_3);
		}
		else if (chart_0.method_2() != -1)
		{
			xmlTextWriter_0.WriteStartElement("mc:AlternateContent");
			xmlTextWriter_0.WriteAttributeString("xmlns:mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			xmlTextWriter_0.WriteStartElement("mc:Choice");
			xmlTextWriter_0.WriteAttributeString("Requires", "c14");
			xmlTextWriter_0.WriteAttributeString("xmlns:c14", "http://schemas.microsoft.com/office/drawing/2007/8/2/chart");
			smethod_5(xmlTextWriter_0, "style", Class1618.smethod_80(chart_0.method_2() + 100));
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("mc:Fallback");
			smethod_5(xmlTextWriter_0, "style", Class1618.smethod_80(chart_0.method_2()));
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_2(XmlTextWriter xmlTextWriter_0)
	{
		if (chart_0.class1549_0 != null && chart_0.class1549_0.string_4 != null)
		{
			xmlTextWriter_0.WriteRaw(chart_0.class1549_0.string_4);
		}
	}

	private void method_3(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("c:pivotSource", null);
		xmlTextWriter_0.WriteStartElement("c:name", null);
		xmlTextWriter_0.WriteString("[0]" + chart_0.PivotSource);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_4(XmlTextWriter xmlTextWriter_0)
	{
		if (class1533_0.class1358_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("c:userShapes", null);
			xmlTextWriter_0.WriteAttributeString("r:id", "rId1");
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_5(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("c:chart", null);
		if (chart_0.method_20() != null)
		{
			method_12(xmlTextWriter_0, chart_0.method_20(), bool_0: true);
		}
		method_6(xmlTextWriter_0);
		method_13(xmlTextWriter_0);
		method_51(xmlTextWriter_0);
		if (chart_0.PlotVisibleCells)
		{
			smethod_5(xmlTextWriter_0, "plotVisOnly", "1");
		}
		else
		{
			smethod_5(xmlTextWriter_0, "plotVisOnly", "0");
		}
		smethod_5(xmlTextWriter_0, "dispBlanksAs", Class1618.smethod_205(chart_0.PlotEmptyCellsType));
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_6(XmlTextWriter xmlTextWriter_0)
	{
		if (method_11())
		{
			method_10(xmlTextWriter_0);
			method_9(xmlTextWriter_0);
			method_7(xmlTextWriter_0);
			method_8(xmlTextWriter_0);
		}
	}

	private void method_7(XmlTextWriter xmlTextWriter_0)
	{
		Walls walls = chart_0.method_32();
		if (walls != null)
		{
			xmlTextWriter_0.WriteStartElement("c:sideWall", null);
			method_66(xmlTextWriter_0, walls.ShapeProperties);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_8(XmlTextWriter xmlTextWriter_0)
	{
		Walls walls = chart_0.method_30();
		if (walls != null)
		{
			xmlTextWriter_0.WriteStartElement("c:backWall", null);
			method_66(xmlTextWriter_0, walls.ShapeProperties);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_9(XmlTextWriter xmlTextWriter_0)
	{
		Floor floor = chart_0.method_28();
		if (floor != null)
		{
			xmlTextWriter_0.WriteStartElement("c:floor", null);
			method_66(xmlTextWriter_0, floor.ShapeProperties);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_10(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("c:view3D", null);
		smethod_5(xmlTextWriter_0, "rotX", Class1618.smethod_80(chart_0.Elevation));
		if (!chart_0.AutoScaling)
		{
			smethod_5(xmlTextWriter_0, "hPercent", Class1618.smethod_83(chart_0.HeightPercent));
		}
		smethod_5(xmlTextWriter_0, "rotY ", Class1618.smethod_80(chart_0.RotationAngle));
		smethod_5(xmlTextWriter_0, "depthPercent", Class1618.smethod_80(chart_0.DepthPercent));
		if (!chart_0.RightAngleAxes)
		{
			smethod_5(xmlTextWriter_0, "rAngAx", "0");
		}
		else
		{
			smethod_5(xmlTextWriter_0, "rAngAx", "1");
		}
		smethod_5(xmlTextWriter_0, "perspective", Class1618.smethod_83(chart_0.Perspective));
		xmlTextWriter_0.WriteEndElement();
	}

	private bool method_11()
	{
		Class1388 @class = chart_0.method_18();
		int num = 0;
		while (true)
		{
			if (num < @class.Count)
			{
				Class1387 class2 = @class[num];
				ChartType chartType = class2.method_11();
				if (ChartCollection.smethod_0(chartType) && chartType != ChartType.Bubble3D)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private void method_12(XmlTextWriter xmlTextWriter_0, Title title_0, bool bool_0)
	{
		if (bool_0)
		{
			smethod_6(xmlTextWriter_0, "c", "autoTitleDeleted", title_0.IsDeleted ? "1" : "0");
		}
		if (title_0.IsDeleted)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("c:title", null);
		if (title_0.Text != null)
		{
			method_61(xmlTextWriter_0, title_0);
		}
		bool bool_ = ((title_0.method_17() && title_0.IsAutoSize) ? true : false);
		string string_ = "factor";
		if (title_0.method_1() && title_0.method_3())
		{
			string_ = "edge";
		}
		method_65(xmlTextWriter_0, title_0, string_, bool_0: true, bool_, title_0.IsInnerMode);
		if (title_0.bool_8)
		{
			if (!title_0.method_43())
			{
				smethod_5(xmlTextWriter_0, "overlay", "0");
			}
			else
			{
				smethod_5(xmlTextWriter_0, "overlay", "1");
			}
		}
		method_66(xmlTextWriter_0, title_0.ShapeProperties);
		if ((title_0.Text == null || title_0.LinkedSource != null) && title_0.method_12() != null)
		{
			method_63(xmlTextWriter_0, title_0.Font, bool_0: false, title_0.RotationAngle, null);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_13(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("c:plotArea", null);
		if (chart_0.PlotArea.method_41())
		{
			chart_0.Calculate(bool_9: false, bool_10: false);
			chart_0.PlotArea.method_19(bool_5: false);
			chart_0.PlotArea.method_21(bool_5: false);
			chart_0.PlotArea.IsAutoSize = false;
			chart_0.PlotArea.method_31(bool_5: false);
			chart_0.PlotArea.IsInnerMode = false;
		}
		bool bool_ = (((chart_0.method_10() & 0x18) != 24 && chart_0.PlotArea.method_18() && chart_0.PlotArea.method_20() && chart_0.PlotArea.IsAutoSize) ? true : false);
		method_65(xmlTextWriter_0, chart_0.PlotArea, "edge", bool_0: false, bool_, chart_0.PlotArea.IsInnerMode);
		Class1532 @class = new Class1532();
		Class1388 class2 = chart_0.method_18();
		for (int i = 0; i < class2.Count; i++)
		{
			Class1387 class3 = class2[i];
			ChartType chartType = class3.method_11();
			if (!ChartCollection.smethod_7(chartType) && !ChartCollection.smethod_10(chartType))
			{
				if (ChartCollection.smethod_14(chartType))
				{
					method_23(xmlTextWriter_0, class3);
				}
				else
				{
					switch (chartType)
					{
					default:
						if (ChartCollection.smethod_16(chartType))
						{
							method_19(xmlTextWriter_0, class3);
						}
						else if (ChartCollection.smethod_11(chartType))
						{
							method_17(xmlTextWriter_0, class3);
						}
						else if (ChartCollection.smethod_13(chartType))
						{
							method_20(xmlTextWriter_0, class3);
						}
						else if (Class1618.smethod_126(chartType))
						{
							method_18(xmlTextWriter_0, class3);
						}
						else if (ChartCollection.smethod_17(chartType))
						{
							method_15(xmlTextWriter_0, class3);
						}
						else if (ChartCollection.smethod_18(chartType))
						{
							method_14(xmlTextWriter_0, class3);
						}
						else if (ChartCollection.smethod_5(chartType))
						{
							method_16(xmlTextWriter_0, class3);
						}
						break;
					case ChartType.PiePie:
					case ChartType.PieBar:
						method_21(xmlTextWriter_0, class3);
						break;
					case ChartType.Pie:
					case ChartType.Pie3D:
					case ChartType.PieExploded:
					case ChartType.Pie3DExploded:
						method_22(xmlTextWriter_0, class3);
						break;
					}
				}
			}
			else
			{
				method_24(xmlTextWriter_0, class3);
			}
			@class.method_0(class3);
		}
		if (@class.bool_8)
		{
			if (@class.bool_4)
			{
				method_47(xmlTextWriter_0, chart_0.CategoryAxis, chart_0.ValueAxis, @class.bool_6, @class.bool_2, bool_2: true);
				method_47(xmlTextWriter_0, chart_0.ValueAxis, chart_0.CategoryAxis, @class.bool_6, @class.bool_2, bool_2: true);
			}
			else if (@class.bool_0)
			{
				method_45(xmlTextWriter_0, chart_0.CategoryAxis, chart_0.ValueAxis, @class.bool_6, @class.bool_2);
				method_47(xmlTextWriter_0, chart_0.ValueAxis, chart_0.CategoryAxis, @class.bool_6, @class.bool_2, bool_2: false);
			}
			if (@class.bool_1)
			{
				if (@class.bool_5)
				{
					method_47(xmlTextWriter_0, chart_0.SecondCategoryAxis, chart_0.SecondValueAxis, @class.bool_7, @class.bool_3, bool_2: true);
					method_47(xmlTextWriter_0, chart_0.SecondValueAxis, chart_0.SecondCategoryAxis, @class.bool_7, @class.bool_3, bool_2: true);
				}
				else
				{
					method_45(xmlTextWriter_0, chart_0.SecondCategoryAxis, chart_0.SecondValueAxis, @class.bool_7, @class.bool_3);
					method_47(xmlTextWriter_0, chart_0.SecondValueAxis, chart_0.SecondCategoryAxis, @class.bool_7, @class.bool_3, bool_2: false);
				}
			}
			if (@class.bool_9)
			{
				method_44(xmlTextWriter_0);
			}
		}
		if (chart_0.ShowDataTable)
		{
			method_52(xmlTextWriter_0);
		}
		method_66(xmlTextWriter_0, chart_0.PlotArea.ShapeProperties);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_14(XmlTextWriter xmlTextWriter_0, Class1387 class1387_0)
	{
		xmlTextWriter_0.WriteStartElement("c:stockChart", null);
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == class1387_0)
			{
				method_25(xmlTextWriter_0, series, i);
			}
		}
		if (class1387_0.HasHiLoLines)
		{
			xmlTextWriter_0.WriteStartElement("c:hiLowLines", null);
			method_66(xmlTextWriter_0, class1387_0.method_30());
			xmlTextWriter_0.WriteEndElement();
		}
		if (class1387_0.HasUpDownBars)
		{
			xmlTextWriter_0.WriteStartElement("c:upDownBars", null);
			if (class1387_0.GapWidth != 150)
			{
				smethod_5(xmlTextWriter_0, "gapWidth", Class1618.smethod_80(class1387_0.GapWidth));
			}
			xmlTextWriter_0.WriteStartElement("c:upBars", null);
			DropBars upBars = class1387_0.UpBars;
			method_66(xmlTextWriter_0, upBars.ShapeProperties);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("c:downBars", null);
			upBars = class1387_0.DownBars;
			method_66(xmlTextWriter_0, upBars.ShapeProperties);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
		method_53(xmlTextWriter_0, class1387_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_15(XmlTextWriter xmlTextWriter_0, Class1387 class1387_0)
	{
		xmlTextWriter_0.WriteStartElement("c:bubbleChart", null);
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == class1387_0)
			{
				method_25(xmlTextWriter_0, series, i);
			}
		}
		if (class1387_0.BubbleScale != 100)
		{
			smethod_5(xmlTextWriter_0, "bubbleScale", Class1618.smethod_80(class1387_0.BubbleScale));
		}
		if (class1387_0.ShowNegativeBubbles)
		{
			smethod_5(xmlTextWriter_0, "showNegBubbles", "1");
		}
		if (class1387_0.SizeRepresents == BubbleSizeRepresents.SizeIsWidth)
		{
			smethod_5(xmlTextWriter_0, "sizeRepresents", "w");
		}
		method_53(xmlTextWriter_0, class1387_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_16(XmlTextWriter xmlTextWriter_0, Class1387 class1387_0)
	{
		if (class1387_0.method_11() != ChartType.Surface3D && class1387_0.method_11() != ChartType.SurfaceWireframe3D)
		{
			xmlTextWriter_0.WriteStartElement("c:surfaceChart", null);
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("c:surface3DChart", null);
		}
		if (class1387_0.method_11() == ChartType.SurfaceContourWireframe || class1387_0.method_11() == ChartType.SurfaceWireframe3D)
		{
			smethod_5(xmlTextWriter_0, "wireframe", "1");
		}
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == class1387_0)
			{
				method_25(xmlTextWriter_0, series, i);
			}
		}
		method_53(xmlTextWriter_0, class1387_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_17(XmlTextWriter xmlTextWriter_0, Class1387 class1387_0)
	{
		xmlTextWriter_0.WriteStartElement("c:scatterChart", null);
		string string_ = Class1618.smethod_124(class1387_0.method_11());
		smethod_5(xmlTextWriter_0, "scatterStyle", string_);
		string string_2 = (class1387_0.IsColorVaried ? "1" : "0");
		smethod_5(xmlTextWriter_0, "varyColors", string_2);
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == class1387_0)
			{
				method_25(xmlTextWriter_0, series, i);
			}
		}
		method_53(xmlTextWriter_0, class1387_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_18(XmlTextWriter xmlTextWriter_0, Class1387 class1387_0)
	{
		xmlTextWriter_0.WriteStartElement("c:radarChart", null);
		string string_ = Class1618.smethod_127(class1387_0.method_11());
		smethod_5(xmlTextWriter_0, "radarStyle", string_);
		string string_2 = (class1387_0.IsColorVaried ? "1" : "0");
		smethod_5(xmlTextWriter_0, "varyColors", string_2);
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == class1387_0)
			{
				method_25(xmlTextWriter_0, series, i);
			}
		}
		method_53(xmlTextWriter_0, class1387_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_19(XmlTextWriter xmlTextWriter_0, Class1387 class1387_0)
	{
		bool flag;
		if (flag = ChartCollection.smethod_0(class1387_0.method_11()))
		{
			xmlTextWriter_0.WriteStartElement("c:area3DChart", null);
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("c:areaChart", null);
		}
		string string_ = Class1618.smethod_112(class1387_0.method_11());
		smethod_5(xmlTextWriter_0, "grouping", string_);
		string string_2 = (class1387_0.IsColorVaried ? "1" : "0");
		smethod_5(xmlTextWriter_0, "varyColors", string_2);
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == class1387_0)
			{
				method_25(xmlTextWriter_0, series, i);
			}
		}
		if (class1387_0.HasDropLines)
		{
			xmlTextWriter_0.WriteStartElement("c:dropLines", null);
			method_66(xmlTextWriter_0, class1387_0.method_29());
			xmlTextWriter_0.WriteEndElement();
		}
		if (flag && chart_0.GapDepth != 150)
		{
			smethod_5(xmlTextWriter_0, "gapDepth", Class1618.smethod_80(chart_0.GapDepth));
		}
		method_53(xmlTextWriter_0, class1387_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_20(XmlTextWriter xmlTextWriter_0, Class1387 class1387_0)
	{
		xmlTextWriter_0.WriteStartElement("c:doughnutChart", null);
		string string_ = (class1387_0.IsColorVaried ? "1" : "0");
		smethod_5(xmlTextWriter_0, "varyColors", string_);
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == class1387_0)
			{
				method_25(xmlTextWriter_0, series, i);
			}
		}
		if (class1387_0.FirstSliceAngle != 0)
		{
			smethod_5(xmlTextWriter_0, "firstSliceAng", Class1618.smethod_80(class1387_0.FirstSliceAngle));
		}
		smethod_5(xmlTextWriter_0, "holeSize", Class1618.smethod_80(class1387_0.DoughnutHoleSize));
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_21(XmlTextWriter xmlTextWriter_0, Class1387 class1387_0)
	{
		xmlTextWriter_0.WriteStartElement("c:ofPieChart", null);
		string string_ = ((class1387_0.method_11() == ChartType.PieBar) ? "bar" : "pie");
		smethod_5(xmlTextWriter_0, "ofPieType", string_);
		string_ = (class1387_0.IsColorVaried ? "1" : "0");
		smethod_5(xmlTextWriter_0, "varyColors", string_);
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == class1387_0)
			{
				method_25(xmlTextWriter_0, series, i);
			}
		}
		if (class1387_0.GapWidth != 150)
		{
			smethod_5(xmlTextWriter_0, "gapWidth", Class1618.smethod_80(class1387_0.GapWidth));
		}
		if (!class1387_0.IsAutoSplit)
		{
			string_ = Class1618.smethod_120(class1387_0.SplitType);
			smethod_5(xmlTextWriter_0, "splitType", string_);
			smethod_5(xmlTextWriter_0, "splitPos", Class1618.smethod_79(class1387_0.SplitValue));
		}
		smethod_5(xmlTextWriter_0, "secondPieSize", Class1618.smethod_80(class1387_0.SecondPlotSize));
		Line seriesLines = class1387_0.SeriesLines;
		if (seriesLines != null)
		{
			xmlTextWriter_0.WriteStartElement("c:serLines", null);
			method_66(xmlTextWriter_0, class1387_0.method_28());
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_22(XmlTextWriter xmlTextWriter_0, Class1387 class1387_0)
	{
		if (class1387_0.method_11() != ChartType.Pie3D && class1387_0.method_11() != ChartType.Pie3DExploded)
		{
			xmlTextWriter_0.WriteStartElement("c:pieChart", null);
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("c:pie3DChart", null);
		}
		string string_ = (class1387_0.IsColorVaried ? "1" : "0");
		smethod_5(xmlTextWriter_0, "varyColors", string_);
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == class1387_0)
			{
				method_25(xmlTextWriter_0, series, i);
			}
		}
		if (class1387_0.FirstSliceAngle != 0)
		{
			smethod_5(xmlTextWriter_0, "firstSliceAng", Class1618.smethod_80(class1387_0.FirstSliceAngle));
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_23(XmlTextWriter xmlTextWriter_0, Class1387 class1387_0)
	{
		if (class1387_0.method_11() == ChartType.Line3D)
		{
			xmlTextWriter_0.WriteStartElement("c:line3DChart", null);
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("c:lineChart", null);
		}
		string string_ = Class1618.smethod_114(class1387_0.method_11());
		smethod_5(xmlTextWriter_0, "grouping", string_);
		string string_2 = (class1387_0.IsColorVaried ? "1" : "0");
		smethod_5(xmlTextWriter_0, "varyColors", string_2);
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == class1387_0)
			{
				method_25(xmlTextWriter_0, series, i);
			}
		}
		if (class1387_0.HasDropLines)
		{
			xmlTextWriter_0.WriteStartElement("c:dropLines", null);
			method_66(xmlTextWriter_0, class1387_0.method_29());
			xmlTextWriter_0.WriteEndElement();
		}
		if (class1387_0.HasHiLoLines)
		{
			xmlTextWriter_0.WriteStartElement("c:hiLowLines", null);
			method_66(xmlTextWriter_0, class1387_0.method_30());
			xmlTextWriter_0.WriteEndElement();
		}
		if (class1387_0.HasUpDownBars)
		{
			xmlTextWriter_0.WriteStartElement("c:upDownBars", null);
			if (class1387_0.GapWidth != 150)
			{
				smethod_5(xmlTextWriter_0, "gapWidth", Class1618.smethod_80(class1387_0.GapWidth));
			}
			xmlTextWriter_0.WriteStartElement("c:upBars", null);
			DropBars upBars = class1387_0.UpBars;
			method_66(xmlTextWriter_0, upBars.ShapeProperties);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("c:downBars", null);
			upBars = class1387_0.DownBars;
			method_66(xmlTextWriter_0, upBars.ShapeProperties);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
		smethod_5(xmlTextWriter_0, "marker", "1");
		if (class1387_0.method_11() == ChartType.Line3D && chart_0.GapDepth != 150)
		{
			smethod_5(xmlTextWriter_0, "gapDepth", Class1618.smethod_80(chart_0.GapDepth));
		}
		method_53(xmlTextWriter_0, class1387_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_24(XmlTextWriter xmlTextWriter_0, Class1387 class1387_0)
	{
		bool flag;
		if (flag = ChartCollection.smethod_0(class1387_0.method_11()))
		{
			xmlTextWriter_0.WriteStartElement("c:bar3DChart", null);
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("c:barChart", null);
		}
		Class1618.smethod_110(class1387_0.method_11(), out var barDir, out var grouping);
		smethod_5(xmlTextWriter_0, "barDir", barDir);
		smethod_5(xmlTextWriter_0, "grouping", grouping);
		string string_ = (class1387_0.IsColorVaried ? "1" : "0");
		smethod_5(xmlTextWriter_0, "varyColors", string_);
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == class1387_0)
			{
				method_25(xmlTextWriter_0, series, i);
			}
		}
		if (class1387_0.Overlap != 0)
		{
			smethod_5(xmlTextWriter_0, "overlap", Class1618.smethod_80(class1387_0.Overlap));
		}
		if (class1387_0.GapWidth != 150)
		{
			smethod_5(xmlTextWriter_0, "gapWidth", Class1618.smethod_80(class1387_0.GapWidth));
		}
		if (flag && chart_0.GapDepth != 150)
		{
			smethod_5(xmlTextWriter_0, "gapDepth", Class1618.smethod_80(chart_0.GapDepth));
		}
		if (flag)
		{
			string text = Class1618.smethod_129(class1387_0.method_11());
			if (text != null)
			{
				smethod_5(xmlTextWriter_0, "shape", text);
			}
		}
		Line seriesLines = class1387_0.SeriesLines;
		if (class1387_0.HasSeriesLines && seriesLines != null)
		{
			xmlTextWriter_0.WriteStartElement("c:serLines", null);
			method_66(xmlTextWriter_0, class1387_0.method_28());
			xmlTextWriter_0.WriteEndElement();
		}
		method_53(xmlTextWriter_0, class1387_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_25(XmlTextWriter xmlTextWriter_0, Series series_0, int int_0)
	{
		ChartType chartType = series_0.method_28().method_11();
		bool flag = ChartCollection.smethod_7(chartType) || ChartCollection.smethod_10(chartType);
		bool flag2 = ChartCollection.smethod_14(chartType) || ChartCollection.smethod_18(chartType);
		bool flag3 = ChartCollection.smethod_3(chartType) || ChartCollection.smethod_13(chartType);
		bool flag4 = ChartCollection.smethod_16(chartType);
		bool flag5 = ChartCollection.smethod_11(chartType);
		bool flag6 = Class1618.smethod_126(chartType);
		bool flag7 = ChartCollection.smethod_17(chartType);
		bool flag8 = ChartCollection.smethod_0(chartType);
		ChartCollection.smethod_5(chartType);
		xmlTextWriter_0.WriteStartElement("c:ser", null);
		smethod_5(xmlTextWriter_0, "idx", Class1618.smethod_80(series_0.method_0()));
		smethod_5(xmlTextWriter_0, "order", Class1618.smethod_80(int_0));
		method_57(xmlTextWriter_0, series_0);
		if (chartType == ChartType.Surface3D || chartType == ChartType.SurfaceWireframe3D)
		{
			series_0.ShapeProperties.method_10();
		}
		method_66(xmlTextWriter_0, series_0.ShapeProperties);
		if (flag3)
		{
			smethod_5(xmlTextWriter_0, "explosion", Class1618.smethod_80(series_0.Explosion));
		}
		if (flag || flag7)
		{
			smethod_5(xmlTextWriter_0, "invertIfNegative", series_0.Area.InvertIfNegative ? "1" : "0");
			if (series_0.Area.InvertIfNegative && series_0.class929_0.string_0 != null)
			{
				xmlTextWriter_0.WriteRaw(series_0.class929_0.string_0);
			}
		}
		if (flag || flag4)
		{
			method_26(xmlTextWriter_0, series_0);
		}
		if ((flag2 || flag5 || flag6) && series_0.method_31() != null)
		{
			method_36(xmlTextWriter_0, series_0.Marker, series_0.Shadow, series_0);
		}
		if (series_0.method_3() != null)
		{
			ChartPointCollection points = series_0.Points;
			for (int i = 0; i < points.method_4(); i++)
			{
				ChartPoint chartPoint = points.method_7(i);
				if (!chartPoint.IsAuto)
				{
					xmlTextWriter_0.WriteStartElement("c:dPt", null);
					smethod_5(xmlTextWriter_0, "idx", Class1618.smethod_80(chartPoint.int_0));
					if (flag3 && chartPoint.Explosion != series_0.Explosion)
					{
						smethod_5(xmlTextWriter_0, "explosion", Class1618.smethod_80(chartPoint.Explosion));
					}
					if (flag)
					{
						smethod_5(xmlTextWriter_0, "invertIfNegative", chartPoint.Area.InvertIfNegative ? "1" : "0");
					}
					method_66(xmlTextWriter_0, chartPoint.ShapeProperties);
					if ((flag2 || flag5 || flag6) && chartPoint.method_7() != null)
					{
						method_36(xmlTextWriter_0, chartPoint.Marker, chartPoint.Shadow, chartPoint);
					}
					xmlTextWriter_0.WriteEndElement();
				}
			}
		}
		method_39(xmlTextWriter_0, series_0);
		if (!flag3 && !flag6 && series_0.method_22() != null && series_0.TrendLines.Count > 0)
		{
			method_55(xmlTextWriter_0, series_0.TrendLines);
		}
		if (!flag3 && !flag6 && series_0.method_33() != null && series_0.YErrorBar.DisplayType != ErrorBarDisplayType.None)
		{
			method_54(xmlTextWriter_0, series_0.YErrorBar);
		}
		if (flag5 && series_0.method_32() != null && series_0.XErrorBar.DisplayType != ErrorBarDisplayType.None)
		{
			method_54(xmlTextWriter_0, series_0.XErrorBar);
		}
		if (!flag5 && !flag7)
		{
			method_27(xmlTextWriter_0, series_0);
			method_35(xmlTextWriter_0, series_0);
		}
		else
		{
			if (series_0.method_18() != null)
			{
				xmlTextWriter_0.WriteStartElement("c:xVal", null);
				method_29(xmlTextWriter_0, series_0.method_18(), bool_0: true, bool_1: false);
				xmlTextWriter_0.WriteEndElement();
			}
			if (series_0.method_16() != null)
			{
				xmlTextWriter_0.WriteStartElement("c:yVal", null);
				method_29(xmlTextWriter_0, series_0.method_16(), bool_0: false, bool_1: false);
				xmlTextWriter_0.WriteEndElement();
			}
		}
		if (flag7)
		{
			if (series_0.method_20() != null)
			{
				xmlTextWriter_0.WriteStartElement("c:bubbleSize", null);
				method_29(xmlTextWriter_0, series_0.method_20(), bool_0: false, bool_1: false);
				xmlTextWriter_0.WriteEndElement();
			}
			if (series_0.Has3DEffect)
			{
				smethod_5(xmlTextWriter_0, "bubble3D", "1");
			}
		}
		if (flag2 || flag5)
		{
			if (series_0.Smooth)
			{
				smethod_5(xmlTextWriter_0, "smooth", "1");
			}
			else
			{
				smethod_5(xmlTextWriter_0, "smooth", "0");
			}
		}
		if (flag && flag8)
		{
			string text = Class1618.smethod_130(series_0.Bar3DShapeType);
			if (text != null)
			{
				smethod_5(xmlTextWriter_0, "shape", text);
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_26(XmlTextWriter xmlTextWriter_0, Series series_0)
	{
		if (series_0.method_5() == null || series_0.Area.Formatting != FormattingType.Custom || series_0.Area.FillFormat.SetType != FormatSetType.IsTextureSet)
		{
			return;
		}
		TextureFill textureFill = series_0.Area.FillFormat.TextureFill;
		if (!textureFill.method_3())
		{
			PicFormatOption picFormatOption = textureFill.PicFormatOption;
			xmlTextWriter_0.WriteStartElement("c:pictureOptions", null);
			if (!picFormatOption.method_4())
			{
				smethod_6(xmlTextWriter_0, "c", "applyToFront", "0");
			}
			if (!picFormatOption.method_2())
			{
				smethod_6(xmlTextWriter_0, "c", "applyToSides", "0");
			}
			if (!picFormatOption.method_6())
			{
				smethod_6(xmlTextWriter_0, "c", "applyToEnd", "0");
			}
			string string_ = Class1618.smethod_188(picFormatOption.Type);
			smethod_6(xmlTextWriter_0, "c", "pictureFormat", string_);
			if (picFormatOption.Type == FillPictureType.StackAndScale)
			{
				smethod_6(xmlTextWriter_0, "c", "pictureStackUnit", Class1618.smethod_79(picFormatOption.Scale));
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_27(XmlTextWriter xmlTextWriter_0, Series series_0)
	{
		Interface45 @interface = series_0.method_18();
		if (@interface != null)
		{
			xmlTextWriter_0.WriteStartElement("c:cat", null);
			bool bool_ = Class922.smethod_0(@interface, chart_0.method_14());
			method_29(xmlTextWriter_0, @interface, bool_0: true, bool_);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private string method_28(Interface45 interface45_0)
	{
		string text = interface45_0.Values;
		if (text != null)
		{
			if (interface45_0.imethod_13() == Enum126.const_4 && text.IndexOf('!') == -1)
			{
				text = ((text[0] != '=') ? ("[0]!" + text) : ("[0]!" + text.Substring(1)));
			}
			text = Class1618.smethod_93(text);
			if ((interface45_0.imethod_13() == Enum126.const_1 || interface45_0.imethod_13() == Enum126.const_6) && text[0] != '(' && text.IndexOf(',') != -1 && text[0] != '{')
			{
				text = "{" + text + "}";
			}
			return text;
		}
		return null;
	}

	private void method_29(XmlTextWriter xmlTextWriter_0, Interface45 interface45_0, bool bool_0, bool bool_1)
	{
		if (interface45_0.imethod_4() != null && interface45_0.imethod_4().Length > 0)
		{
			string text = method_28(interface45_0);
			if (text != null)
			{
				bool flag = true;
				string text2 = "numRef";
				if (bool_1)
				{
					text2 = "multiLvlStrRef";
				}
				else if (bool_0)
				{
					text2 = ((flag = method_31(interface45_0)) ? "numRef" : "strRef");
				}
				xmlTextWriter_0.WriteStartElement("c:" + text2, null);
				xmlTextWriter_0.WriteStartElement("c:f", null);
				xmlTextWriter_0.WriteString(text);
				xmlTextWriter_0.WriteEndElement();
				if (bool_1)
				{
					method_33(xmlTextWriter_0, interface45_0);
				}
				else
				{
					text2 = (flag ? "numCache" : "strCache");
					method_34(xmlTextWriter_0, interface45_0, text2);
				}
				xmlTextWriter_0.WriteEndElement();
			}
		}
		else
		{
			string string_ = ((interface45_0.imethod_13() == Enum126.const_1) ? "numLit" : "strLit");
			if (interface45_0.imethod_13() == Enum126.const_6 && !bool_0 && method_30(interface45_0.imethod_2()))
			{
				string_ = "numLit";
			}
			method_34(xmlTextWriter_0, interface45_0, string_);
		}
	}

	private bool method_30(ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			try
			{
				string text = arrayList_0[i].ToString();
				if (text == "" || Class1677.smethod_19(text))
				{
					continue;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
		return true;
	}

	private bool method_31(Interface45 interface45_0)
	{
		if (interface45_0.imethod_13() == Enum126.const_1)
		{
			return true;
		}
		int int_ = 0;
		ArrayList arrayList = interface45_0.imethod_7(interface45_0.imethod_1(), bool_1: false, ref int_);
		if (arrayList != null && arrayList.Count != 0)
		{
			if (int_ == 1)
			{
				for (int i = 0; i < arrayList.Count; i++)
				{
					Class1196 @class = (Class1196)arrayList[i];
					if (@class.cellValueType_0 == CellValueType.IsString)
					{
						return false;
					}
				}
			}
			else
			{
				int count = arrayList.Count;
				_ = ((ArrayList)arrayList[0]).Count;
				for (int j = 0; j < count; j++)
				{
					ArrayList arrayList2 = (ArrayList)arrayList[j];
					for (int k = 0; k < arrayList2.Count; k++)
					{
						Class1196 class2 = (Class1196)arrayList2[k];
						if (class2.cellValueType_0 == CellValueType.IsString)
						{
							return false;
						}
					}
				}
			}
			return true;
		}
		return false;
	}

	private void method_32(ArrayList arrayList_0, ArrayList arrayList_1)
	{
		int num = 0;
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			string text = (string)arrayList_1[i];
			string[] array = text.Split('\n');
			if (array.Length > num)
			{
				num = array.Length;
			}
			arrayList.Add(array);
		}
		for (int j = 0; j < num; j++)
		{
			ArrayList arrayList2 = new ArrayList(arrayList_1.Count);
			for (int k = 0; k < arrayList.Count; k++)
			{
				string[] array2 = (string[])arrayList[k];
				if (j >= array2.Length)
				{
					arrayList2.Add("");
				}
				else
				{
					arrayList2.Add(array2[j]);
				}
			}
			arrayList_0.Add(arrayList2);
		}
	}

	private void method_33(XmlTextWriter xmlTextWriter_0, Interface45 interface45_0)
	{
		string text = "multiLvlStrCache";
		if (interface45_0.imethod_2() != null && interface45_0.imethod_2().Count > 0)
		{
			ArrayList arrayList = interface45_0.imethod_2();
			int count = arrayList.Count;
			if (count <= 0)
			{
				return;
			}
			xmlTextWriter_0.WriteStartElement("c:" + text, null);
			smethod_6(xmlTextWriter_0, "c", "ptCount", Class1618.smethod_80(count));
			ArrayList arrayList2 = new ArrayList();
			method_32(arrayList2, arrayList);
			for (int i = 0; i < arrayList2.Count; i++)
			{
				ArrayList arrayList3 = (ArrayList)arrayList2[i];
				xmlTextWriter_0.WriteStartElement("c:lvl", null);
				for (int j = 0; j < arrayList3.Count; j++)
				{
					string text2 = (string)arrayList3[j];
					if (text2 != null && text2.Length > 0)
					{
						xmlTextWriter_0.WriteStartElement("c:pt", null);
						xmlTextWriter_0.WriteAttributeString("idx", Class1618.smethod_80(j));
						xmlTextWriter_0.WriteStartElement("c:v", null);
						xmlTextWriter_0.WriteString(text2);
						xmlTextWriter_0.WriteEndElement();
						xmlTextWriter_0.WriteEndElement();
					}
				}
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if ((interface45_0.imethod_2() != null && chart_0.PivotSource != null) || (interface45_0.imethod_11() > 0 && interface45_0.IsVisible))
		{
			xmlTextWriter_0.WriteStartElement("c:" + text, null);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_34(XmlTextWriter xmlTextWriter_0, Interface45 interface45_0, string string_0)
	{
		if (interface45_0.imethod_2() != null && interface45_0.imethod_2().Count > 0)
		{
			ArrayList arrayList = interface45_0.imethod_2();
			int count = arrayList.Count;
			if (count <= 0)
			{
				return;
			}
			xmlTextWriter_0.WriteStartElement("c:" + string_0, null);
			smethod_6(xmlTextWriter_0, "c", "ptCount", Class1618.smethod_80(count));
			for (int i = 0; i < count; i++)
			{
				object obj = arrayList[i];
				if (obj != null && obj.ToString().Length > 0)
				{
					xmlTextWriter_0.WriteStartElement("c:pt", null);
					xmlTextWriter_0.WriteAttributeString("idx", Class1618.smethod_80(i));
					xmlTextWriter_0.WriteStartElement("c:v", null);
					xmlTextWriter_0.WriteString(obj.ToString());
					xmlTextWriter_0.WriteEndElement();
					xmlTextWriter_0.WriteEndElement();
				}
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if ((interface45_0.imethod_2() != null && chart_0.PivotSource != null) || (interface45_0.imethod_11() > 0 && interface45_0.IsVisible))
		{
			xmlTextWriter_0.WriteStartElement("c:" + string_0, null);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_35(XmlTextWriter xmlTextWriter_0, Series series_0)
	{
		if (series_0.method_16() != null)
		{
			xmlTextWriter_0.WriteStartElement("c:val", null);
			method_29(xmlTextWriter_0, series_0.method_16(), bool_0: false, bool_1: false);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_36(XmlTextWriter xmlTextWriter_0, Marker marker_0, bool bool_0, object object_0)
	{
		ChartMarkerType markerStyle = marker_0.MarkerStyle;
		xmlTextWriter_0.WriteStartElement("c:marker", null);
		if (markerStyle == ChartMarkerType.None)
		{
			smethod_5(xmlTextWriter_0, "symbol", "none");
		}
		else
		{
			if (markerStyle != 0)
			{
				bool flag = true;
				if (object_0 is ChartPoint)
				{
					Series series = ((ChartPoint)object_0).method_0();
					Marker marker = series.method_31();
					if (marker != null && marker.MarkerStyle == markerStyle)
					{
						flag = false;
					}
				}
				if (flag)
				{
					string string_ = Class1618.smethod_116(markerStyle);
					smethod_5(xmlTextWriter_0, "symbol", string_);
				}
			}
			if (!marker_0.bool_0)
			{
				smethod_5(xmlTextWriter_0, "size", Class1618.smethod_80(marker_0.MarkerSize));
			}
			if (!marker_0.ShapeProperties.method_8())
			{
				marker_0.ShapeProperties.method_9(bool_0);
			}
			method_66(xmlTextWriter_0, marker_0.ShapeProperties);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private bool method_37(Series series_0)
	{
		DataLabels dataLabels = series_0.method_24();
		if (dataLabels != null)
		{
			return true;
		}
		if (series_0.method_3() != null)
		{
			ChartPointCollection points = series_0.Points;
			for (int i = 0; i < points.method_4(); i++)
			{
				ChartPoint chartPoint = points.method_7(i);
				if (chartPoint.method_9() != null)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void method_38(XmlTextWriter xmlTextWriter_0, DataLabels dataLabels_0, int int_0)
	{
		xmlTextWriter_0.WriteStartElement("c:layout", null);
		xmlTextWriter_0.WriteStartElement("c:manualLayout", null);
		if (dataLabels_0.method_34())
		{
			if (!dataLabels_0.IsDefaultPosBeSet)
			{
				dataLabels_0.Chart.Calculate(bool_9: false, bool_10: false);
			}
			dataLabels_0.OffsetX = dataLabels_0.X - dataLabels_0.DefaultX;
			dataLabels_0.OffsetY = dataLabels_0.Y - dataLabels_0.DefaultY;
		}
		smethod_5(xmlTextWriter_0, "x", Class1618.smethod_79((double)dataLabels_0.OffsetX / 4000.0));
		smethod_5(xmlTextWriter_0, "y", Class1618.smethod_79((double)dataLabels_0.OffsetY / 4000.0));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_39(XmlTextWriter xmlTextWriter_0, Series series_0)
	{
		if (!method_37(series_0))
		{
			return;
		}
		ChartType chartType_ = series_0.method_28().method_11();
		DataLabels dataLabels = series_0.method_24();
		xmlTextWriter_0.WriteStartElement("c:dLbls", null);
		if (series_0.method_3() != null)
		{
			ChartPointCollection points = series_0.Points;
			for (int i = 0; i < points.method_4(); i++)
			{
				ChartPoint chartPoint = points.method_7(i);
				if ((chartPoint.method_9() == null || dataLabels == null || dataLabels.method_59(chartPoint.method_9())) && (dataLabels != null || chartPoint.method_9() == null))
				{
					continue;
				}
				DataLabels dataLabels2 = chartPoint.method_9();
				xmlTextWriter_0.WriteStartElement("c:dLbl", null);
				smethod_6(xmlTextWriter_0, "c", "idx", Class1618.smethod_80(chartPoint.int_0));
				if (!dataLabels2.IsDeleted && dataLabels2.method_66())
				{
					if (!dataLabels2.method_17() || dataLabels2.method_34())
					{
						method_38(xmlTextWriter_0, dataLabels2, 1);
					}
					if (dataLabels2.method_41() != null && dataLabels2.method_41().Length > 0)
					{
						method_62(xmlTextWriter_0, dataLabels2);
					}
					else if (dataLabels == null || !smethod_9(dataLabels.method_44(), dataLabels2.method_44()) || dataLabels2.RotationAngle != 0 || (dataLabels2.method_54() && dataLabels2.method_60() is ChartPoint))
					{
						Font font = dataLabels2.method_12();
						if (font == null && dataLabels2.RotationAngle != 0)
						{
							font = dataLabels2.Font;
						}
						method_63(xmlTextWriter_0, font, bool_0: false, dataLabels2.RotationAngle, dataLabels2);
					}
					if (dataLabels2.method_54())
					{
						xmlTextWriter_0.WriteStartElement("c:numFmt", null);
						string value = method_68(dataLabels2);
						xmlTextWriter_0.WriteAttributeString("formatCode", value);
						if (dataLabels2.method_53())
						{
							xmlTextWriter_0.WriteAttributeString("sourceLinked", "1");
						}
						xmlTextWriter_0.WriteEndElement();
					}
					if (!method_66(xmlTextWriter_0, dataLabels2.ShapeProperties) && dataLabels2.RotationAngle != 0)
					{
						xmlTextWriter_0.WriteElementString("c:spPr", null);
					}
					bool bool_ = false;
					if (!dataLabels2.bool_15 && dataLabels2.Position != LabelPositionType.Moved)
					{
						string text = Class1618.smethod_98(dataLabels2.Position, chartType_);
						if (text != null)
						{
							bool_ = true;
							smethod_6(xmlTextWriter_0, "c", "dLblPos", text);
						}
					}
					method_40(xmlTextWriter_0, dataLabels2, bool_0: true, bool_);
				}
				else
				{
					xmlTextWriter_0.WriteElementString("c:delete", "1");
				}
				xmlTextWriter_0.WriteEndElement();
			}
		}
		if (dataLabels != null)
		{
			xmlTextWriter_0.WriteStartElement("c:numFmt", null);
			string value2 = method_68(dataLabels);
			xmlTextWriter_0.WriteAttributeString("formatCode", value2);
			if (dataLabels.NumberFormatLinked)
			{
				xmlTextWriter_0.WriteAttributeString("sourceLinked", "1");
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("sourceLinked", "0");
			}
			xmlTextWriter_0.WriteEndElement();
			method_66(xmlTextWriter_0, dataLabels.ShapeProperties);
			if (!smethod_9(chart_0.ChartArea.method_12(), dataLabels.method_44()) || dataLabels.RotationAngle != 0)
			{
				Font font_ = dataLabels.method_12();
				if (dataLabels.RotationAngle != 0)
				{
					font_ = dataLabels.Font;
				}
				method_63(xmlTextWriter_0, font_, bool_0: false, dataLabels.RotationAngle, dataLabels);
			}
			if (!dataLabels.bool_15)
			{
				string text2 = Class1618.smethod_98(dataLabels.Position, chartType_);
				if (text2 != null)
				{
					smethod_6(xmlTextWriter_0, "c", "dLblPos", text2);
				}
			}
			method_40(xmlTextWriter_0, dataLabels, bool_0: false, bool_1: false);
			if (!dataLabels.method_65())
			{
				smethod_6(xmlTextWriter_0, "c", "delete", "1");
			}
		}
		else
		{
			smethod_6(xmlTextWriter_0, "c", "delete", "1");
		}
		if (series_0.method_28().method_24() != null)
		{
			xmlTextWriter_0.WriteStartElement("c:leaderLines", null);
			method_66(xmlTextWriter_0, series_0.method_28().method_31());
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_40(XmlTextWriter xmlTextWriter_0, DataLabels dataLabels_0, bool bool_0, bool bool_1)
	{
		string text = null;
		if (dataLabels_0.method_58() && dataLabels_0.method_57() != 0)
		{
			text = Class1618.smethod_108(dataLabels_0.method_57());
			if (bool_0)
			{
				bool_1 = true;
			}
		}
		if (!dataLabels_0.bool_14 && !dataLabels_0.method_34())
		{
			if (bool_1)
			{
				if (dataLabels_0.ShowValue)
				{
					smethod_5(xmlTextWriter_0, "showVal", "1");
				}
				if (dataLabels_0.ShowBubbleSize)
				{
					smethod_5(xmlTextWriter_0, "showBubbleSize", "1");
				}
				if (dataLabels_0.ShowCategoryName)
				{
					smethod_5(xmlTextWriter_0, "showCatName", "1");
				}
				if (dataLabels_0.ShowSeriesName)
				{
					smethod_5(xmlTextWriter_0, "showSerName", "1");
				}
			}
		}
		else
		{
			smethod_5(xmlTextWriter_0, "showLegendKey", dataLabels_0.ShowLegendKey ? "1" : "0");
			string string_ = (dataLabels_0.ShowValue ? "1" : "0");
			smethod_5(xmlTextWriter_0, "showVal", string_);
			string_ = (dataLabels_0.ShowBubbleSize ? "1" : "0");
			smethod_5(xmlTextWriter_0, "showBubbleSize", string_);
			string_ = (dataLabels_0.ShowCategoryName ? "1" : "0");
			smethod_5(xmlTextWriter_0, "showCatName", string_);
			string_ = (dataLabels_0.ShowSeriesName ? "1" : "0");
			smethod_5(xmlTextWriter_0, "showSerName", string_);
		}
		if (!ChartCollection.smethod_3(dataLabels_0.Type) && !ChartCollection.smethod_13(dataLabels_0.Type) && !ChartCollection.smethod_14(dataLabels_0.Type))
		{
			if (dataLabels_0.bool_14)
			{
				smethod_5(xmlTextWriter_0, "showPercent", "0");
			}
			else if (bool_1)
			{
				smethod_5(xmlTextWriter_0, "showPercent", "0");
			}
		}
		else
		{
			if (dataLabels_0.method_61())
			{
				string string_2 = (((Series)dataLabels_0.method_60()).HasLeaderLines ? "1" : "0");
				smethod_5(xmlTextWriter_0, "showLeaderLines", string_2);
			}
			if (dataLabels_0.bool_14)
			{
				string string_3 = (dataLabels_0.ShowPercentage ? "1" : "0");
				smethod_5(xmlTextWriter_0, "showPercent", string_3);
			}
			else if (bool_1 && dataLabels_0.ShowPercentage)
			{
				smethod_5(xmlTextWriter_0, "showPercent", "1");
			}
		}
		if (text != null)
		{
			xmlTextWriter_0.WriteElementString("c:separator", text);
		}
	}

	private void method_41(XmlTextWriter xmlTextWriter_0, Axis axis_0, bool bool_0)
	{
		string string_ = "minMax";
		if (axis_0.IsPlotOrderReversed)
		{
			string_ = "maxMin";
		}
		xmlTextWriter_0.WriteStartElement("c:scaling", null);
		if (axis_0.IsLogarithmic)
		{
			smethod_5(xmlTextWriter_0, "logBase", Class1618.smethod_79(axis_0.LogBase));
		}
		smethod_5(xmlTextWriter_0, "orientation", string_);
		if (!axis_0.method_6())
		{
			string string_2 = method_42(axis_0.MaxValue, bool_0);
			smethod_5(xmlTextWriter_0, "max", string_2);
		}
		if (!axis_0.method_3())
		{
			string string_3 = method_42(axis_0.MinValue, bool_0);
			smethod_5(xmlTextWriter_0, "min", string_3);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_42(object object_0, bool bool_0)
	{
		if (object_0 is double num)
		{
			if (bool_0)
			{
				num *= 0.01;
			}
			return Class1618.smethod_79(num);
		}
		if (object_0 is DateTime dateTime)
		{
			return Class1618.smethod_79(dateTime.ToOADate());
		}
		return object_0.ToString();
	}

	private void method_43(XmlTextWriter xmlTextWriter_0, Axis axis_0)
	{
		if (axis_0.method_20() != null)
		{
			method_12(xmlTextWriter_0, axis_0.method_20(), bool_0: false);
		}
		if ((axis_0.method_26() != null && axis_0.MajorGridLines.IsVisible) || Class1618.smethod_126(chart_0.Type))
		{
			xmlTextWriter_0.WriteStartElement("c:majorGridlines", null);
			method_66(xmlTextWriter_0, axis_0.method_31());
			xmlTextWriter_0.WriteEndElement();
		}
		if (axis_0.method_28() != null && axis_0.MinorGridLines.IsVisible)
		{
			xmlTextWriter_0.WriteStartElement("c:minorGridlines", null);
			method_66(xmlTextWriter_0, axis_0.method_32());
			xmlTextWriter_0.WriteEndElement();
		}
		if (axis_0.IsVisible)
		{
			smethod_5(xmlTextWriter_0, "delete", "0");
			xmlTextWriter_0.WriteStartElement("c:numFmt", null);
			if (!axis_0.TickLabels.NumberFormatLinked)
			{
				string value = method_67(axis_0.TickLabels);
				xmlTextWriter_0.WriteAttributeString("formatCode", value);
				xmlTextWriter_0.WriteAttributeString("sourceLinked", "0");
			}
			else
			{
				string value2 = method_67(axis_0.TickLabels);
				xmlTextWriter_0.WriteAttributeString("formatCode", value2);
				xmlTextWriter_0.WriteAttributeString("sourceLinked", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else
		{
			smethod_5(xmlTextWriter_0, "delete", "1");
		}
		string string_ = Class1618.smethod_67(axis_0.MajorTickMark);
		smethod_5(xmlTextWriter_0, "majorTickMark", string_);
		string_ = Class1618.smethod_67(axis_0.MinorTickMark);
		smethod_5(xmlTextWriter_0, "minorTickMark", string_);
		string string_2 = Class1618.smethod_69(axis_0.TickLabelPosition);
		if (Class1618.smethod_126(chart_0.Type) && axis_0.Type == Enum195.const_0 && chart_0.class1388_0.Count > 0 && !chart_0.class1388_0[0].HasRadarAxisLabels)
		{
			string_2 = "none";
		}
		smethod_5(xmlTextWriter_0, "tickLblPos", string_2);
		method_66(xmlTextWriter_0, axis_0.ShapeProperties);
		if (!smethod_9(chart_0.ChartArea.method_12(), axis_0.TickLabels.method_0()) || axis_0.TickLabels.RotationAngle != 0)
		{
			Font font = axis_0.TickLabels.method_0();
			if (font == null && axis_0.TickLabels.RotationAngle != 0)
			{
				font = axis_0.TickLabels.Font;
			}
			method_63(xmlTextWriter_0, font, axis_0.TickLabels.method_5(), axis_0.TickLabels.RotationAngle, null);
		}
	}

	private void method_44(XmlTextWriter xmlTextWriter_0)
	{
		Axis seriesAxis = chart_0.SeriesAxis;
		xmlTextWriter_0.WriteStartElement("c:serAx", null);
		smethod_5(xmlTextWriter_0, "axId", Class1618.smethod_80(seriesAxis.GetHashCode()));
		method_41(xmlTextWriter_0, seriesAxis, bool_0: false);
		string string_ = "b";
		smethod_5(xmlTextWriter_0, "axPos", string_);
		method_43(xmlTextWriter_0, seriesAxis);
		Axis valueAxis = chart_0.ValueAxis;
		smethod_5(xmlTextWriter_0, "crossAx", Class1618.smethod_80(valueAxis.GetHashCode()));
		if (valueAxis.CrossType != CrossType.Custom)
		{
			string string_2 = Class1618.smethod_71(valueAxis.CrossType);
			smethod_5(xmlTextWriter_0, "crosses", string_2);
		}
		else
		{
			double crossAt = valueAxis.CrossAt;
			smethod_5(xmlTextWriter_0, "crossesAt", Class1618.smethod_79(crossAt));
		}
		smethod_5(xmlTextWriter_0, "tickLblSkip", Class1618.smethod_80(seriesAxis.TickLabelSpacing));
		smethod_5(xmlTextWriter_0, "tickMarkSkip", Class1618.smethod_80(seriesAxis.TickMarkSpacing));
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_45(XmlTextWriter xmlTextWriter_0, Axis axis_0, Axis axis_1, bool bool_0, bool bool_1)
	{
		if (axis_0.CategoryType == CategoryType.TimeScale)
		{
			xmlTextWriter_0.WriteStartElement("c:dateAx", null);
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("c:catAx", null);
		}
		smethod_5(xmlTextWriter_0, "axId", Class1618.smethod_80(axis_0.GetHashCode()));
		method_41(xmlTextWriter_0, axis_0, bool_0: false);
		string string_ = method_46(axis_0, axis_1, bool_0: false, bool_1);
		smethod_5(xmlTextWriter_0, "axPos", string_);
		method_43(xmlTextWriter_0, axis_0);
		smethod_5(xmlTextWriter_0, "crossAx", Class1618.smethod_80(axis_1.GetHashCode()));
		if (axis_1.CrossType != CrossType.Custom)
		{
			string string_2 = Class1618.smethod_71(axis_1.CrossType);
			smethod_5(xmlTextWriter_0, "crosses", string_2);
		}
		else
		{
			double num = axis_1.CrossAt;
			if (bool_0)
			{
				num *= 0.01;
			}
			smethod_5(xmlTextWriter_0, "crossesAt", Class1618.smethod_79(num));
		}
		if (axis_0.bool_11)
		{
			if (axis_0.CategoryType == CategoryType.AutomaticScale)
			{
				smethod_5(xmlTextWriter_0, "auto", "1");
			}
			else
			{
				smethod_5(xmlTextWriter_0, "auto", "0");
			}
		}
		if (axis_0.CategoryType == CategoryType.TimeScale)
		{
			if (!axis_0.method_22())
			{
				string string_3 = Class1618.smethod_100(axis_0.BaseUnitScale);
				smethod_5(xmlTextWriter_0, "baseTimeUnit", string_3);
			}
			if (!axis_0.method_7())
			{
				smethod_5(xmlTextWriter_0, "majorUnit", Class1618.smethod_79(axis_0.MajorUnit));
				string string_4 = Class1618.smethod_100(axis_0.MajorUnitScale);
				smethod_5(xmlTextWriter_0, "majorTimeUnit", string_4);
			}
			if (!axis_0.method_9())
			{
				smethod_5(xmlTextWriter_0, "minorUnit", Class1618.smethod_79(axis_0.MinorUnit));
				string string_5 = Class1618.smethod_100(axis_0.MinorUnitScale);
				smethod_5(xmlTextWriter_0, "minorTimeUnit", string_5);
			}
		}
		else
		{
			smethod_5(xmlTextWriter_0, "lblOffset", Class1618.smethod_80(axis_0.TickLabels.Offset));
			if (!axis_0.method_16())
			{
				smethod_5(xmlTextWriter_0, "tickLblSkip", Class1618.smethod_80(axis_0.TickLabelSpacing));
			}
			if (axis_0.TickMarkSpacing != 1)
			{
				smethod_5(xmlTextWriter_0, "tickMarkSkip", Class1618.smethod_80(axis_0.TickMarkSpacing));
			}
		}
		smethod_5(xmlTextWriter_0, "noMultiLvlLbl", axis_0.HasMultiLevelLabels ? "0" : "1");
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_46(Axis axis_0, Axis axis_1, bool bool_0, bool bool_1)
	{
		string text = null;
		if (bool_0)
		{
			if (axis_0.Type == Enum195.const_0)
			{
				return axis_1.IsPlotOrderReversed ? "t" : "b";
			}
			if (bool_1)
			{
				return axis_1.IsPlotOrderReversed ? "t" : "b";
			}
			return axis_1.IsPlotOrderReversed ? "r" : "l";
		}
		if (bool_1)
		{
			return axis_1.IsPlotOrderReversed ? "r" : "l";
		}
		return axis_1.IsPlotOrderReversed ? "t" : "b";
	}

	private void method_47(XmlTextWriter xmlTextWriter_0, Axis axis_0, Axis axis_1, bool bool_0, bool bool_1, bool bool_2)
	{
		xmlTextWriter_0.WriteStartElement("c:valAx", null);
		smethod_5(xmlTextWriter_0, "axId", Class1618.smethod_80(axis_0.GetHashCode()));
		method_41(xmlTextWriter_0, axis_0, bool_0);
		string string_ = method_46(axis_0, axis_1, bool_0: true, bool_1);
		smethod_5(xmlTextWriter_0, "axPos", string_);
		method_43(xmlTextWriter_0, axis_0);
		smethod_5(xmlTextWriter_0, "crossAx", Class1618.smethod_80(axis_1.GetHashCode()));
		if (axis_1.CrossType != CrossType.Custom)
		{
			string string_2 = Class1618.smethod_71(axis_1.CrossType);
			smethod_5(xmlTextWriter_0, "crosses", string_2);
		}
		else
		{
			smethod_5(xmlTextWriter_0, "crossesAt", Class1618.smethod_79(axis_1.CrossAt));
		}
		string string_3 = "midCat";
		if (!bool_2 && axis_1.AxisBetweenCategories)
		{
			string_3 = "between";
		}
		smethod_5(xmlTextWriter_0, "crossBetween", string_3);
		method_48(xmlTextWriter_0, axis_0);
		if (!axis_0.method_7())
		{
			double num = axis_0.MajorUnit;
			if (bool_0)
			{
				num *= 0.01;
			}
			smethod_5(xmlTextWriter_0, "majorUnit", Class1618.smethod_79(num));
		}
		if (!axis_0.method_9())
		{
			double num2 = axis_0.MinorUnit;
			if (bool_0)
			{
				num2 *= 0.01;
			}
			smethod_5(xmlTextWriter_0, "minorUnit", Class1618.smethod_79(num2));
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_48(XmlTextWriter xmlTextWriter_0, Axis axis_0)
	{
		xmlTextWriter_0.WriteStartElement("c:dispUnits", null);
		if (axis_0.DisplayUnit != 0)
		{
			smethod_5(xmlTextWriter_0, "builtInUnit", Class1618.smethod_183(axis_0.DisplayUnit));
		}
		if (axis_0.method_18() != null && axis_0.IsDisplayUnitLabelShown)
		{
			method_49(xmlTextWriter_0, axis_0.DisplayUnitLabel);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_49(XmlTextWriter xmlTextWriter_0, DisplayUnitLabel displayUnitLabel_0)
	{
		xmlTextWriter_0.WriteStartElement("c:dispUnitsLbl", null);
		bool bool_ = (displayUnitLabel_0.IsAutoSize ? true : false);
		bool bool_2 = ((displayUnitLabel_0.method_17() && displayUnitLabel_0.IsAutoSize) ? true : false);
		method_65(xmlTextWriter_0, displayUnitLabel_0, "edge", bool_, bool_2, displayUnitLabel_0.IsInnerMode);
		if (displayUnitLabel_0.Text != null)
		{
			method_50(xmlTextWriter_0, displayUnitLabel_0);
		}
		method_66(xmlTextWriter_0, displayUnitLabel_0.ShapeProperties);
		if (!smethod_9(chart_0.ChartArea.method_12(), displayUnitLabel_0.method_12()))
		{
			method_63(xmlTextWriter_0, displayUnitLabel_0.Font, bool_0: false, displayUnitLabel_0.RotationAngle, null);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_50(XmlTextWriter xmlTextWriter_0, DisplayUnitLabel displayUnitLabel_0)
	{
		if (displayUnitLabel_0.Text != null && displayUnitLabel_0.LinkedSource != null)
		{
			xmlTextWriter_0.WriteStartElement("c:tx", null);
			if (displayUnitLabel_0.LinkedSource != null)
			{
				string text = displayUnitLabel_0.method_39();
				method_59(xmlTextWriter_0, displayUnitLabel_0.LinkedSource, (text != null) ? new string[1] { text } : null);
			}
			else
			{
				xmlTextWriter_0.WriteStartElement("c:rich", null);
				method_60(xmlTextWriter_0, displayUnitLabel_0.TextVerticalAlignment, bool_0: false, displayUnitLabel_0.RotationAngle);
				xmlTextWriter_0.WriteElementString("a:lstStyle", null);
				Class1360 class1360_ = Class1360.smethod_4(displayUnitLabel_0, workbook_0);
				smethod_1(xmlTextWriter_0, class1360_);
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_51(XmlTextWriter xmlTextWriter_0)
	{
		if (!chart_0.ShowLegend)
		{
			return;
		}
		Legend legend = chart_0.Legend;
		xmlTextWriter_0.WriteStartElement("c:legend", null);
		string string_ = Class1618.smethod_65(legend.Position);
		smethod_5(xmlTextWriter_0, "legendPos", string_);
		method_56(xmlTextWriter_0, legend);
		bool bool_ = (legend.IsAutoSize ? true : false);
		bool bool_2 = ((legend.method_17() && legend.IsAutoSize) ? true : false);
		method_65(xmlTextWriter_0, legend, "edge", bool_, bool_2, legend.IsInnerMode);
		if (legend.bool_7)
		{
			if (!legend.method_48())
			{
				smethod_5(xmlTextWriter_0, "overlay", "0");
			}
			else
			{
				smethod_5(xmlTextWriter_0, "overlay", "1");
			}
		}
		method_66(xmlTextWriter_0, legend.ShapeProperties);
		if (!smethod_9(chart_0.ChartArea.method_12(), legend.method_12()))
		{
			method_63(xmlTextWriter_0, legend.Font, bool_0: false, 0, null);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_52(XmlTextWriter xmlTextWriter_0)
	{
		ChartDataTable chartDataTable = chart_0.method_25();
		if (chartDataTable != null)
		{
			xmlTextWriter_0.WriteStartElement("c:dTable", null);
			if (chartDataTable.HasBorderHorizontal)
			{
				smethod_5(xmlTextWriter_0, "showHorzBorder", "1");
			}
			if (chartDataTable.HasBorderVertical)
			{
				smethod_5(xmlTextWriter_0, "showVertBorder", "1");
			}
			if (chartDataTable.HasBorderOutline)
			{
				smethod_5(xmlTextWriter_0, "showOutline", "1");
			}
			if (chartDataTable.ShowLegendKey)
			{
				smethod_5(xmlTextWriter_0, "showKeys", "1");
			}
			if (chartDataTable.method_4() != null)
			{
				method_66(xmlTextWriter_0, chartDataTable.ShapeProperties);
			}
			if (!smethod_9(chart_0.ChartArea.method_12(), chartDataTable.method_0()))
			{
				method_63(xmlTextWriter_0, chartDataTable.Font, bool_0: false, 0, null);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_53(XmlTextWriter xmlTextWriter_0, Class1387 class1387_0)
	{
		string string_;
		string string_2;
		if (!class1387_0.PlotOnSecondAxis)
		{
			string_ = Class1618.smethod_80(chart_0.CategoryAxis.GetHashCode());
			string_2 = Class1618.smethod_80(chart_0.ValueAxis.GetHashCode());
		}
		else
		{
			string_ = Class1618.smethod_80(chart_0.SecondCategoryAxis.GetHashCode());
			string_2 = Class1618.smethod_80(chart_0.SecondValueAxis.GetHashCode());
		}
		smethod_5(xmlTextWriter_0, "axId", string_);
		smethod_5(xmlTextWriter_0, "axId", string_2);
		if (ChartCollection.smethod_6(class1387_0.method_11()))
		{
			string string_3 = Class1618.smethod_80(chart_0.SeriesAxis.GetHashCode());
			smethod_5(xmlTextWriter_0, "axId", string_3);
		}
	}

	private void method_54(XmlTextWriter xmlTextWriter_0, ErrorBar errorBar_0)
	{
		xmlTextWriter_0.WriteStartElement("c:errBars", null);
		string string_ = (errorBar_0.method_33() ? "y" : "x");
		smethod_6(xmlTextWriter_0, "c", "errDir", string_);
		string_ = Class1618.smethod_104(errorBar_0.DisplayType);
		smethod_6(xmlTextWriter_0, "c", "errBarType", string_);
		string_ = Class1618.smethod_106(errorBar_0.Type);
		smethod_6(xmlTextWriter_0, "c", "errValType", string_);
		if (errorBar_0.Type == ErrorBarType.Custom)
		{
			if (errorBar_0.method_35() != null)
			{
				xmlTextWriter_0.WriteStartElement("c:plus", null);
				method_29(xmlTextWriter_0, errorBar_0.method_35(), bool_0: false, bool_1: false);
				xmlTextWriter_0.WriteEndElement();
			}
			if (errorBar_0.method_37() != null)
			{
				xmlTextWriter_0.WriteStartElement("c:minus", null);
				method_29(xmlTextWriter_0, errorBar_0.method_37(), bool_0: false, bool_1: false);
				xmlTextWriter_0.WriteEndElement();
			}
		}
		else if (errorBar_0.Type != ErrorBarType.StError)
		{
			smethod_6(xmlTextWriter_0, "c", "val", Class1618.smethod_79(errorBar_0.Amount));
		}
		if (!errorBar_0.ShowMarkerTTop)
		{
			smethod_6(xmlTextWriter_0, "c", "noEndCap", "1");
		}
		method_66(xmlTextWriter_0, errorBar_0.ShapeProperties);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_55(XmlTextWriter xmlTextWriter_0, TrendlineCollection trendlineCollection_0)
	{
		for (int i = 0; i < trendlineCollection_0.Count; i++)
		{
			Trendline trendline = trendlineCollection_0[i];
			xmlTextWriter_0.WriteStartElement("c:trendline", null);
			if (!trendline.IsNameAuto)
			{
				xmlTextWriter_0.WriteElementString("c:name", trendline.Name);
			}
			method_66(xmlTextWriter_0, trendline.ShapeProperties);
			string string_ = Class1618.smethod_102(trendline.Type);
			smethod_6(xmlTextWriter_0, "c", "trendlineType", string_);
			if (trendline.Type == TrendlineType.Polynomial)
			{
				smethod_6(xmlTextWriter_0, "c", "order", Class1618.smethod_80(trendline.Order));
			}
			if (trendline.Type == TrendlineType.MovingAverage)
			{
				smethod_6(xmlTextWriter_0, "c", "period", Class1618.smethod_80(trendline.Period));
			}
			if (trendline.Type != TrendlineType.MovingAverage)
			{
				if (trendline.Forward != 0.0)
				{
					smethod_6(xmlTextWriter_0, "c", "forward", Class1618.smethod_79(trendline.Forward));
				}
				if (trendline.Backward != 0.0)
				{
					smethod_6(xmlTextWriter_0, "c", "backward", Class1618.smethod_79(trendline.Backward));
				}
				if (trendline.Type != TrendlineType.Logarithmic && trendline.Type != TrendlineType.Power && trendline.Intercept != 0.0)
				{
					smethod_6(xmlTextWriter_0, "c", "intercept", Class1618.smethod_79(trendline.Intercept));
				}
				if (trendline.DisplayEquation)
				{
					smethod_6(xmlTextWriter_0, "c", "dispEq", "1");
				}
				if (trendline.DisplayRSquared)
				{
					smethod_6(xmlTextWriter_0, "c", "dispRSqr", "1");
				}
			}
			DataLabels dataLabels = trendline.method_36();
			if (dataLabels != null)
			{
				xmlTextWriter_0.WriteStartElement("c:trendlineLbl", null);
				if (!dataLabels.method_18() || dataLabels.method_34())
				{
					method_38(xmlTextWriter_0, dataLabels, 2);
				}
				if (dataLabels.method_41() != null && dataLabels.method_41().Length > 0)
				{
					method_62(xmlTextWriter_0, dataLabels);
				}
				else if (dataLabels.method_44() != null || dataLabels.RotationAngle != 0)
				{
					Font font = dataLabels.method_12();
					if (font == null && dataLabels.RotationAngle != 0)
					{
						font = dataLabels.Font;
					}
					method_63(xmlTextWriter_0, font, bool_0: false, dataLabels.RotationAngle, dataLabels);
				}
				if (dataLabels.method_54())
				{
					xmlTextWriter_0.WriteStartElement("c:numFmt", null);
					string value = method_68(dataLabels);
					xmlTextWriter_0.WriteAttributeString("formatCode", value);
					if (dataLabels.method_53())
					{
						xmlTextWriter_0.WriteAttributeString("sourceLinked", "1");
					}
					xmlTextWriter_0.WriteEndElement();
				}
				if (!method_66(xmlTextWriter_0, dataLabels.ShapeProperties) && dataLabels.RotationAngle != 0)
				{
					xmlTextWriter_0.WriteElementString("c:spPr", null);
				}
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_56(XmlTextWriter xmlTextWriter_0, Legend legend_0)
	{
		if (legend_0.method_44() == null)
		{
			return;
		}
		int count = legend_0.LegendEntries.Count;
		if (count == 0)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			LegendEntry legendEntry = legend_0.LegendEntries.method_1(i);
			_ = chart_0.NSeries[i];
			bool flag = smethod_9(legend_0.method_12(), legendEntry.method_0());
			if (!legendEntry.IsDeleted && flag)
			{
				continue;
			}
			xmlTextWriter_0.WriteStartElement("c:legendEntry", null);
			int num = legendEntry.Index;
			if (hashtable_0 != null)
			{
				object obj = hashtable_0[num];
				if (obj != null)
				{
					num = (int)obj;
				}
			}
			smethod_5(xmlTextWriter_0, "idx", Class1618.smethod_80(num));
			if (legendEntry.IsDeleted)
			{
				smethod_5(xmlTextWriter_0, "delete", "1");
			}
			else if (!flag)
			{
				method_63(xmlTextWriter_0, legendEntry.method_0(), bool_0: false, 0, null);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_57(XmlTextWriter xmlTextWriter_0, Series series_0)
	{
		if (series_0.Name == null || series_0.Name.Length == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("c:tx", null);
		if (series_0.Name[0] != '=')
		{
			xmlTextWriter_0.WriteStartElement("c:v", null);
			xmlTextWriter_0.WriteString(Class1618.smethod_4(series_0.Name));
			xmlTextWriter_0.WriteEndElement();
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("c:strRef", null);
			xmlTextWriter_0.WriteStartElement("c:f", null);
			xmlTextWriter_0.WriteString(series_0.Name.Substring(1));
			xmlTextWriter_0.WriteEndElement();
			if (series_0.string_0 != null)
			{
				xmlTextWriter_0.WriteStartElement("c:strCache", null);
				xmlTextWriter_0.WriteStartElement("c:ptCount", null);
				xmlTextWriter_0.WriteAttributeString("val", "1");
				xmlTextWriter_0.WriteEndElement();
				xmlTextWriter_0.WriteStartElement("c:pt", null);
				xmlTextWriter_0.WriteAttributeString("idx", "0");
				xmlTextWriter_0.WriteStartElement("c:v", null);
				xmlTextWriter_0.WriteString(series_0.string_0);
				xmlTextWriter_0.WriteEndElement();
				xmlTextWriter_0.WriteEndElement();
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_58(XmlTextWriter xmlTextWriter_0, string string_0)
	{
		string_0 = Class1618.smethod_93(string_0);
		xmlTextWriter_0.WriteStartElement("c:strRef", null);
		xmlTextWriter_0.WriteStartElement("c:f", null);
		xmlTextWriter_0.WriteString(string_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_59(XmlTextWriter xmlTextWriter_0, string string_0, string[] string_1)
	{
		string_0 = Class1618.smethod_93(string_0);
		xmlTextWriter_0.WriteStartElement("c:strRef", null);
		xmlTextWriter_0.WriteStartElement("c:f", null);
		xmlTextWriter_0.WriteString(string_0);
		xmlTextWriter_0.WriteEndElement();
		if (string_1 != null && string_1.Length != 0)
		{
			xmlTextWriter_0.WriteStartElement("c:strCache", null);
			xmlTextWriter_0.WriteStartElement("c:ptCount", null);
			xmlTextWriter_0.WriteAttributeString("val", Class1618.smethod_80(string_1.Length));
			xmlTextWriter_0.WriteEndElement();
			for (int i = 0; i < string_1.Length; i++)
			{
				xmlTextWriter_0.WriteStartElement("c:pt", null);
				xmlTextWriter_0.WriteAttributeString("idx", Class1618.smethod_80(i));
				xmlTextWriter_0.WriteElementString("c:v", string_1[i]);
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_60(XmlTextWriter xmlTextWriter_0, TextAlignmentType textAlignmentType_0, bool bool_0, int int_0)
	{
		xmlTextWriter_0.WriteStartElement("a:bodyPr", null);
		if (!bool_0)
		{
			if (int_0 == 255)
			{
				xmlTextWriter_0.WriteAttributeString("vert", "wordArtVert");
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("rot", Class1618.smethod_80(int_0 * -60000));
			}
		}
		if (textAlignmentType_0 != TextAlignmentType.Top)
		{
			string value = Class1618.smethod_94(textAlignmentType_0);
			xmlTextWriter_0.WriteAttributeString("anchor", value);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private static void smethod_0(XmlTextWriter xmlTextWriter_0, TextAlignmentType textAlignmentType_0, TextDirectionType textDirectionType_0)
	{
		xmlTextWriter_0.WriteStartElement("a:pPr", null);
		if (textAlignmentType_0 != TextAlignmentType.Left)
		{
			string value = Class1618.smethod_96(textAlignmentType_0);
			xmlTextWriter_0.WriteAttributeString("algn", value);
		}
		if (textDirectionType_0 == TextDirectionType.RightToLeft)
		{
			xmlTextWriter_0.WriteAttributeString("rtl", "1");
		}
		xmlTextWriter_0.WriteElementString("a:defRPr", null);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_61(XmlTextWriter xmlTextWriter_0, Title title_0)
	{
		string linkedSource = title_0.LinkedSource;
		if (linkedSource != null || title_0.Text != null)
		{
			xmlTextWriter_0.WriteStartElement("c:tx", null);
			if (linkedSource != null)
			{
				method_58(xmlTextWriter_0, linkedSource);
			}
			else
			{
				xmlTextWriter_0.WriteStartElement("c:rich", null);
				method_60(xmlTextWriter_0, title_0.TextVerticalAlignment, bool_0: false, title_0.RotationAngle);
				xmlTextWriter_0.WriteElementString("a:lstStyle", null);
				Class1360 class1360_ = Class1360.smethod_0(title_0, workbook_0);
				smethod_1(xmlTextWriter_0, class1360_);
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	internal static void smethod_1(XmlTextWriter xmlTextWriter_0, Class1360 class1360_0)
	{
		xmlTextWriter_0.WriteStartElement("a", "p", null);
		smethod_0(xmlTextWriter_0, class1360_0.textAlignmentType_0, class1360_0.textDirectionType_0);
		Font font_ = class1360_0.font_0;
		if (class1360_0.arrayList_0 != null && class1360_0.arrayList_0.Count != 0)
		{
			int count = class1360_0.arrayList_0.Count;
			for (int i = 0; i < count; i++)
			{
				FontSetting fontSetting = (FontSetting)class1360_0.arrayList_0[i];
				if (i == 0 && fontSetting.StartIndex != 0)
				{
					smethod_3(xmlTextWriter_0, font_, class1360_0.string_0.Substring(0, fontSetting.StartIndex), class1360_0.workbook_0, class1360_0.bool_0);
				}
				Font font = fontSetting.method_2();
				if (font == null)
				{
					font = font_;
				}
				string string_ = class1360_0.string_0.Substring(fontSetting.StartIndex, fontSetting.Length);
				smethod_3(xmlTextWriter_0, font, string_, class1360_0.workbook_0, class1360_0.bool_0);
				if (i == count - 1 && fontSetting.StartIndex + fontSetting.Length < class1360_0.string_0.Length)
				{
					smethod_3(xmlTextWriter_0, font_, class1360_0.string_0.Substring(fontSetting.StartIndex + fontSetting.Length), class1360_0.workbook_0, class1360_0.bool_0);
				}
			}
		}
		else
		{
			smethod_3(xmlTextWriter_0, font_, class1360_0.string_0, class1360_0.workbook_0, class1360_0.bool_0);
		}
		if (class1360_0.class1363_0 != null)
		{
			object obj = class1360_0.class1363_0.method_0(Enum129.const_0);
			if (obj != null)
			{
				xmlTextWriter_0.WriteRaw((string)obj);
			}
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	internal static void smethod_2(XmlTextWriter xmlTextWriter_0, Class1360 class1360_0)
	{
		xmlTextWriter_0.WriteStartElement("a", "p", null);
		smethod_0(xmlTextWriter_0, class1360_0.textAlignmentType_0, class1360_0.textDirectionType_0);
		smethod_4(xmlTextWriter_0, class1360_0.font_0, "endParaRPr", class1360_0.workbook_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_62(XmlTextWriter xmlTextWriter_0, DataLabels dataLabels_0)
	{
		if (dataLabels_0.method_41() != null || dataLabels_0.LinkedSource != null)
		{
			xmlTextWriter_0.WriteStartElement("c:tx", null);
			if (dataLabels_0.LinkedSource != null)
			{
				string text = dataLabels_0.method_41();
				method_59(xmlTextWriter_0, dataLabels_0.LinkedSource, (text != null) ? new string[1] { text } : null);
			}
			else
			{
				xmlTextWriter_0.WriteStartElement("c:rich", null);
				method_60(xmlTextWriter_0, dataLabels_0.TextVerticalAlignment, bool_0: false, dataLabels_0.RotationAngle);
				xmlTextWriter_0.WriteElementString("a:lstStyle", null);
				Class1360 class1360_ = Class1360.smethod_1(dataLabels_0, workbook_0);
				smethod_1(xmlTextWriter_0, class1360_);
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_63(XmlTextWriter xmlTextWriter_0, Font font_0, bool bool_0, int int_0, DataLabels dataLabels_0)
	{
		if (font_0 == null)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("c:txPr", null);
		TextAlignmentType textAlignmentType_ = TextAlignmentType.Top;
		if (dataLabels_0 != null)
		{
			textAlignmentType_ = dataLabels_0.TextVerticalAlignment;
		}
		method_60(xmlTextWriter_0, textAlignmentType_, bool_0, int_0);
		xmlTextWriter_0.WriteElementString("a:lstStyle", null);
		xmlTextWriter_0.WriteStartElement("a:p", null);
		if (font_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("a:pPr", null);
			if (dataLabels_0 != null)
			{
				if (dataLabels_0.TextHorizontalAlignment != TextAlignmentType.Left)
				{
					string value = Class1618.smethod_96(dataLabels_0.TextHorizontalAlignment);
					xmlTextWriter_0.WriteAttributeString("algn", value);
				}
				if (dataLabels_0.TextDirection == TextDirectionType.RightToLeft)
				{
					xmlTextWriter_0.WriteAttributeString("rtl", "1");
				}
			}
			smethod_4(xmlTextWriter_0, font_0, "defRPr", workbook_0);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private static void smethod_3(XmlTextWriter xmlTextWriter_0, Font font_0, string string_0, Workbook workbook_1, bool bool_0)
	{
		if (bool_0)
		{
			xmlTextWriter_0.WriteStartElement("a", "fld", null);
			xmlTextWriter_0.WriteAttributeString("id", "{" + Guid.NewGuid().ToString(null, CultureInfo.InvariantCulture) + "}");
			xmlTextWriter_0.WriteAttributeString("type", "TxLink");
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("a", "r", null);
		}
		smethod_4(xmlTextWriter_0, font_0, "rPr", workbook_1);
		xmlTextWriter_0.WriteStartElement("a", "t", null);
		xmlTextWriter_0.WriteString(Class1618.smethod_4(string_0));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private static void smethod_4(XmlTextWriter xmlTextWriter_0, Font font_0, string string_0, Workbook workbook_1)
	{
		xmlTextWriter_0.WriteStartElement("a", string_0, null);
		xmlTextWriter_0.WriteAttributeString("lang", "en-US");
		if (font_0 != null)
		{
			if (font_0.IsModified(StyleModifyFlag.FontSize))
			{
				xmlTextWriter_0.WriteAttributeString("sz", Class1618.smethod_80(font_0.method_16() * 5));
			}
			if (font_0.IsModified(StyleModifyFlag.FontWeight))
			{
				xmlTextWriter_0.WriteAttributeString("b", font_0.IsBold ? "1" : "0");
			}
			if (font_0.IsModified(StyleModifyFlag.FontItalic))
			{
				xmlTextWriter_0.WriteAttributeString("i", font_0.IsItalic ? "1" : "0");
			}
			xmlTextWriter_0.WriteAttributeString("u", Class1618.smethod_76(font_0.Underline));
			if (font_0.IsStrikeout)
			{
				xmlTextWriter_0.WriteAttributeString("strike", "sngStrike");
			}
			xmlTextWriter_0.WriteAttributeString("baseline", Class1618.smethod_80(smethod_8(font_0)));
			if (!font_0.InternalColor.method_2())
			{
				xmlTextWriter_0.WriteStartElement("a", "solidFill", null);
				Class1236.smethod_0(xmlTextWriter_0, font_0.InternalColor, -1, workbook_1);
				xmlTextWriter_0.WriteEndElement();
			}
			if (font_0.IsModified(StyleModifyFlag.FontName))
			{
				smethod_7(xmlTextWriter_0, "a", "latin", "typeface", font_0.Name);
				smethod_7(xmlTextWriter_0, "a", "ea", "typeface", font_0.Name);
				smethod_7(xmlTextWriter_0, "a", "cs", "typeface", font_0.Name);
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_64(XmlTextWriter xmlTextWriter_0, Class1559 class1559_0)
	{
		xmlTextWriter_0.WriteStartElement("c:layout", null);
		xmlTextWriter_0.WriteStartElement("c:manualLayout", null);
		if (class1559_0.string_0 != null)
		{
			smethod_5(xmlTextWriter_0, "layoutTarget", class1559_0.string_0);
		}
		if (class1559_0.string_1 != null)
		{
			smethod_5(xmlTextWriter_0, "xMode", class1559_0.string_1);
		}
		if (class1559_0.string_2 != null)
		{
			smethod_5(xmlTextWriter_0, "yMode", class1559_0.string_2);
		}
		if (class1559_0.string_3 != null)
		{
			smethod_5(xmlTextWriter_0, "wMode", class1559_0.string_3);
		}
		if (class1559_0.string_4 != null)
		{
			smethod_5(xmlTextWriter_0, "hMode", class1559_0.string_4);
		}
		if (class1559_0.string_5 != null)
		{
			smethod_5(xmlTextWriter_0, "x", class1559_0.string_5);
		}
		if (class1559_0.string_6 != null)
		{
			smethod_5(xmlTextWriter_0, "y", class1559_0.string_6);
		}
		if (class1559_0.string_7 != null)
		{
			smethod_5(xmlTextWriter_0, "w", class1559_0.string_7);
		}
		if (class1559_0.string_8 != null)
		{
			smethod_5(xmlTextWriter_0, "h", class1559_0.string_8);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_65(XmlTextWriter xmlTextWriter_0, ChartFrame chartFrame_0, string string_0, bool bool_0, bool bool_1, bool bool_2)
	{
		bool flag = chartFrame_0 is PlotArea;
		PlotArea plotArea = null;
		if (flag)
		{
			plotArea = (PlotArea)chartFrame_0;
		}
		if (chartFrame_0.class1559_0 != null)
		{
			method_64(xmlTextWriter_0, chartFrame_0.class1559_0);
		}
		else if (!bool_1 && !(chart_0.ChartObject.WidthPt <= 0.0) && chart_0.ChartObject.HeightPt > 0.0)
		{
			xmlTextWriter_0.WriteStartElement("c:layout", null);
			xmlTextWriter_0.WriteStartElement("c:manualLayout", null);
			if (bool_2)
			{
				smethod_5(xmlTextWriter_0, "layoutTarget", "inner");
			}
			smethod_5(xmlTextWriter_0, "xMode", string_0);
			smethod_5(xmlTextWriter_0, "yMode", string_0);
			if (bool_2 && flag)
			{
				smethod_5(xmlTextWriter_0, "x", Class1618.smethod_79((double)plotArea.InnerX / 4000.0));
				smethod_5(xmlTextWriter_0, "y", Class1618.smethod_79((double)plotArea.InnerY / 4000.0));
			}
			else
			{
				smethod_5(xmlTextWriter_0, "x", Class1618.smethod_79((double)chartFrame_0.method_23() / 4000.0));
				smethod_5(xmlTextWriter_0, "y", Class1618.smethod_79((double)chartFrame_0.method_25() / 4000.0));
			}
			if (!bool_0)
			{
				double double_ = (double)chartFrame_0.Width / 4000.0;
				double double_2 = (double)chartFrame_0.Height / 4000.0;
				if (bool_2 && flag)
				{
					smethod_5(xmlTextWriter_0, "w", Class1618.smethod_79((double)plotArea.InnerWidth / 4000.0));
					smethod_5(xmlTextWriter_0, "h", Class1618.smethod_79((double)plotArea.InnerHeight / 4000.0));
				}
				else
				{
					smethod_5(xmlTextWriter_0, "w", Class1618.smethod_79(double_));
					smethod_5(xmlTextWriter_0, "h", Class1618.smethod_79(double_2));
				}
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
		else
		{
			xmlTextWriter_0.WriteElementString("c:layout", null);
		}
	}

	private bool method_66(XmlTextWriter xmlTextWriter_0, ShapePropertyCollection shapePropertyCollection_0)
	{
		return Class1236.Write(xmlTextWriter_0, class1533_0, shapePropertyCollection_0);
	}

	[Attribute0(true)]
	private static void smethod_5(XmlTextWriter xmlTextWriter_0, string string_0, string string_1)
	{
		xmlTextWriter_0.WriteStartElement("c:" + string_0, null);
		xmlTextWriter_0.WriteAttributeString("val", string_1);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private static void smethod_6(XmlTextWriter xmlTextWriter_0, string string_0, string string_1, string string_2)
	{
		xmlTextWriter_0.WriteStartElement(string_0 + ":" + string_1, null);
		xmlTextWriter_0.WriteAttributeString("val", string_2);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private static void smethod_7(XmlTextWriter xmlTextWriter_0, string string_0, string string_1, string string_2, string string_3)
	{
		xmlTextWriter_0.WriteStartElement(string_0 + ":" + string_1, null);
		xmlTextWriter_0.WriteAttributeString(string_2, string_3);
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_67(TickLabels tickLabels_0)
	{
		if (tickLabels_0.Number == 0 && tickLabels_0.NumberFormat == null)
		{
			return "General";
		}
		if (tickLabels_0.NumberFormat != null)
		{
			return tickLabels_0.NumberFormat;
		}
		return Class1618.smethod_78(tickLabels_0.Number);
	}

	private string method_68(DataLabels dataLabels_0)
	{
		if (dataLabels_0.method_53())
		{
			return "General";
		}
		if (dataLabels_0.method_48() != null)
		{
			return dataLabels_0.method_48();
		}
		return Class1618.smethod_78(dataLabels_0.method_50());
	}

	private static int smethod_8(Font font_0)
	{
		if (font_0.IsSubscript)
		{
			return 30000;
		}
		if (font_0.IsSuperscript)
		{
			return -25000;
		}
		return 0;
	}

	private static bool smethod_9(Font font_0, Font font_1)
	{
		if (font_0 == null)
		{
			return font_1 == null;
		}
		if (font_1 == null)
		{
			return true;
		}
		return font_0.method_18(font_1);
	}
}
