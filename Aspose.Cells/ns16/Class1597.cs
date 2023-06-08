using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns22;
using ns25;
using ns7;

namespace ns16;

internal class Class1597
{
	private Class1548 class1548_0;

	private Class1547 class1547_0;

	private WorksheetCollection worksheetCollection_0;

	private Chart chart_0;

	private Hashtable hashtable_0 = new Hashtable();

	private ArrayList arrayList_0 = new ArrayList();

	private Hashtable hashtable_1;

	private ArrayList arrayList_1 = new ArrayList();

	private string string_0;

	private string string_1;

	private bool bool_0;

	internal Class1597(Class1547 class1547_1, Class1548 class1548_1, Chart chart_1, Hashtable hashtable_2)
	{
		class1547_0 = class1547_1;
		class1548_0 = class1548_1;
		chart_0 = chart_1;
		worksheetCollection_0 = class1547_0.workbook_0.Worksheets;
		hashtable_1 = hashtable_2;
	}

	private void method_0()
	{
		int int_ = 0;
		int count = chart_0.NSeries.Count;
		LegendEntryCollection legendEntryCollection = chart_0.Legend.method_44();
		if (legendEntryCollection != null)
		{
			foreach (LegendEntry item in legendEntryCollection)
			{
				if (item.Index >= 0 && item.Index < count)
				{
					Series series = (Series)arrayList_1[item.Index];
					item.Index = series.Index;
				}
			}
		}
		for (int i = 0; i < count; i++)
		{
			Series series2 = chart_0.NSeries[i];
			if (series2.method_22() != null)
			{
				for (int j = 0; j < series2.TrendLines.Count; j++)
				{
					series2.TrendLines[j].method_39(int_++);
				}
			}
		}
		chart_0.int_5 = int_;
	}

	[Attribute0(true)]
	internal void method_1(XmlTextReader xmlTextReader_0)
	{
		method_61(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "txPr")
			{
				Class1570 @class = method_45(xmlTextReader_0);
				if (@class.class1542_0 != null)
				{
					chart_0.ChartArea.method_14(Class1618.smethod_119(@class.class1542_0, worksheetCollection_0));
					chart_0.class1549_0.class1542_0 = @class.class1542_0;
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		chart_0.method_57(Enum19.const_1);
		method_61(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "chart")
			{
				if (xmlTextReader_0.IsEmptyElement)
				{
					throw new CellsException(ExceptionType.InvalidData, "Invalid chart element");
				}
				method_4(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "roundedCorners")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null && text == "1")
				{
					chart_0.IsRectangularCornered = false;
				}
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, chart_0.ChartArea.ShapeProperties);
			}
			else if (xmlTextReader_0.LocalName == "userShapes")
			{
				chart_0.class1549_0.string_0 = xmlTextReader_0.GetAttribute("id", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "style")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					int num = Class1618.smethod_87(text2);
					if (num >= 1 && num <= 48)
					{
						method_2(num);
					}
				}
			}
			else if (xmlTextReader_0.LocalName == "pivotSource" && !xmlTextReader_0.IsEmptyElement)
			{
				method_3(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "AlternateContent")
			{
				chart_0.class1549_0.string_3 = xmlTextReader_0.ReadOuterXml();
				XmlTextReader xmlTextReader = Class1029.smethod_2(new StringReader(chart_0.class1549_0.string_3));
				xmlTextReader.Read();
				xmlTextReader.MoveToContent();
				if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.LocalName == "AlternateContent")
				{
					xmlTextReader.Read();
					xmlTextReader.MoveToContent();
					if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.LocalName == "Choice")
					{
						xmlTextReader.Read();
						xmlTextReader.MoveToContent();
						if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.LocalName == "style")
						{
							xmlTextReader.Skip();
							xmlTextReader.Read();
							xmlTextReader.MoveToContent();
							if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.LocalName == "Fallback")
							{
								xmlTextReader.Read();
								xmlTextReader.MoveToContent();
								if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.LocalName == "style")
								{
									string text3 = smethod_0(xmlTextReader);
									if (text3 != null)
									{
										int num2 = Class1618.smethod_87(text3);
										if (num2 >= 1 && num2 <= 48)
										{
											method_2(num2);
											chart_0.class1549_0.string_3 = null;
										}
									}
								}
							}
						}
					}
				}
				xmlTextReader.Close();
			}
			else if (xmlTextReader_0.LocalName == "extLst")
			{
				chart_0.class1549_0.string_4 = xmlTextReader_0.ReadOuterXml();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		method_0();
	}

	private void method_2(int int_0)
	{
		chart_0.method_1(int_0);
		switch (int_0)
		{
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
		case 48:
			chart_0.ChartArea.Font.Color = Color.White;
			chart_0.ChartArea.Area.Formatting = FormattingType.Custom;
			chart_0.ChartArea.Area.ForegroundColor = Color.Black;
			break;
		}
	}

	[Attribute0(true)]
	private void method_3(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "name")
			{
				string text = xmlTextReader_0.ReadElementString();
				if (text == null || text.Length <= 0)
				{
					continue;
				}
				text = text.Trim();
				if (text[0] == '[')
				{
					int num = text.IndexOf(']');
					if (num != -1)
					{
						text = ((text.Length <= num + 1) ? null : text.Substring(num + 1));
					}
				}
				if (text != null && text.Length > 0)
				{
					chart_0.PivotSource = text;
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal void method_4(XmlTextReader xmlTextReader_0)
	{
		chart_0.PlotVisibleCells = false;
		bool flag = true;
		xmlTextReader_0.Read();
		bool flag2 = false;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "title")
				{
					flag2 = true;
					if (!xmlTextReader_0.IsEmptyElement)
					{
						method_42(xmlTextReader_0, chart_0.Title, bool_1: true);
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				else if (xmlTextReader_0.LocalName == "autoTitleDeleted")
				{
					string text = smethod_0(xmlTextReader_0);
					chart_0.Title.IsDeleted = ((!(text == "0")) ? true : false);
				}
				else if (xmlTextReader_0.LocalName == "plotArea" && !xmlTextReader_0.IsEmptyElement)
				{
					method_7(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "view3D" && !xmlTextReader_0.IsEmptyElement)
				{
					method_5(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "floor" && !xmlTextReader_0.IsEmptyElement)
				{
					method_19(xmlTextReader_0, chart_0.method_27().ShapeProperties);
				}
				else if (xmlTextReader_0.LocalName == "backWall" && !xmlTextReader_0.IsEmptyElement)
				{
					method_19(xmlTextReader_0, chart_0.method_31().ShapeProperties);
				}
				else if (xmlTextReader_0.LocalName == "sideWall" && !xmlTextReader_0.IsEmptyElement)
				{
					method_19(xmlTextReader_0, chart_0.method_33().ShapeProperties);
				}
				else if (xmlTextReader_0.LocalName == "legend" && !xmlTextReader_0.IsEmptyElement)
				{
					flag = false;
					method_6(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "plotVisOnly")
				{
					string text2 = smethod_0(xmlTextReader_0);
					if (text2 != null)
					{
						chart_0.PlotVisibleCells = Class1618.smethod_201(text2);
					}
					else
					{
						chart_0.PlotVisibleCells = true;
					}
				}
				else if (xmlTextReader_0.LocalName == "dispBlanksAs")
				{
					string text3 = smethod_0(xmlTextReader_0);
					if (text3 != null)
					{
						chart_0.PlotEmptyCellsType = Class1618.smethod_204(text3);
					}
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (flag)
		{
			chart_0.ShowLegend = false;
		}
		if (!bool_0 && (chart_0.Type == ChartType.Pie3D || chart_0.Type == ChartType.Pie3DExploded))
		{
			chart_0.RotationAngle = 0;
		}
		if (!flag2)
		{
			chart_0.Title.IsDeleted = true;
		}
	}

	[Attribute0(true)]
	private void method_5(XmlTextReader xmlTextReader_0)
	{
		bool flag = true;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "rotX")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					chart_0.Elevation = Class1618.smethod_87(text);
				}
			}
			else if (xmlTextReader_0.LocalName == "hPercent")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					chart_0.HeightPercent = Class1618.smethod_89(text2);
					flag = false;
				}
			}
			else if (xmlTextReader_0.LocalName == "rotY")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					chart_0.RotationAngle = Class1618.smethod_87(text3);
					bool_0 = true;
				}
			}
			else if (xmlTextReader_0.LocalName == "depthPercent")
			{
				string text4 = smethod_0(xmlTextReader_0);
				if (text4 != null)
				{
					chart_0.DepthPercent = Class1618.smethod_87(text4);
				}
			}
			else if (xmlTextReader_0.LocalName == "rAngAx")
			{
				string text5 = smethod_0(xmlTextReader_0);
				chart_0.RightAngleAxes = ((!(text5 == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "perspective")
			{
				string text6 = smethod_0(xmlTextReader_0);
				if (text6 != null)
				{
					chart_0.Perspective = Class1618.smethod_89(text6);
				}
				chart_0.RightAngleAxes = false;
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (!flag)
		{
			chart_0.AutoScaling = false;
		}
	}

	private void method_6(XmlTextReader xmlTextReader_0)
	{
		Legend legend = chart_0.Legend;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "layout" && !xmlTextReader_0.IsEmptyElement)
			{
				method_44(xmlTextReader_0)?.method_2(chart_0, legend);
			}
			else if (xmlTextReader_0.LocalName == "legendPos")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					legend.method_39(Class1618.smethod_66(text));
				}
			}
			else if (xmlTextReader_0.LocalName == "legendEntry" && !xmlTextReader_0.IsEmptyElement)
			{
				method_60(xmlTextReader_0, legend);
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, legend.ShapeProperties);
			}
			else if (xmlTextReader_0.LocalName == "txPr" && !xmlTextReader_0.IsEmptyElement)
			{
				Class1570 @class = method_45(xmlTextReader_0);
				if (@class.class1542_0 != null)
				{
					@class.method_5(chart_0, bool_3: false);
					legend.method_14(Class1618.smethod_119(@class.class1542_0, worksheetCollection_0));
				}
			}
			else if (xmlTextReader_0.LocalName == "overlay")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 == "1")
				{
					legend.method_49(bool_8: true);
				}
				else
				{
					legend.method_49(bool_8: false);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_7(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.Read();
		chart_0.SeriesAxis.IsVisible = false;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement)
			{
				if (xmlTextReader_0.LocalName == "layout")
				{
					method_44(xmlTextReader_0)?.method_1(chart_0);
				}
				else if (!(xmlTextReader_0.LocalName == "barChart") && !(xmlTextReader_0.LocalName == "bar3DChart"))
				{
					if (!(xmlTextReader_0.LocalName == "lineChart") && !(xmlTextReader_0.LocalName == "line3DChart"))
					{
						if (!(xmlTextReader_0.LocalName == "pieChart") && !(xmlTextReader_0.LocalName == "pie3DChart"))
						{
							if (xmlTextReader_0.LocalName == "ofPieChart")
							{
								method_8(xmlTextReader_0);
							}
							else if (!(xmlTextReader_0.LocalName == "areaChart") && !(xmlTextReader_0.LocalName == "area3DChart"))
							{
								if (xmlTextReader_0.LocalName == "scatterChart")
								{
									method_11(xmlTextReader_0);
								}
								else if (xmlTextReader_0.LocalName == "doughnutChart")
								{
									method_13(xmlTextReader_0);
								}
								else if (xmlTextReader_0.LocalName == "radarChart")
								{
									method_14(xmlTextReader_0);
								}
								else if (xmlTextReader_0.LocalName == "bubbleChart")
								{
									method_12(xmlTextReader_0);
								}
								else if (xmlTextReader_0.LocalName == "stockChart")
								{
									method_15(xmlTextReader_0);
								}
								else if (!(xmlTextReader_0.LocalName == "surfaceChart") && !(xmlTextReader_0.LocalName == "surface3DChart"))
								{
									if (xmlTextReader_0.LocalName == "dateAx")
									{
										method_56(xmlTextReader_0, "dateAx");
									}
									else if (xmlTextReader_0.LocalName == "catAx")
									{
										method_56(xmlTextReader_0, "catAx");
									}
									else if (xmlTextReader_0.LocalName == "valAx")
									{
										method_56(xmlTextReader_0, "valAx");
									}
									else if (xmlTextReader_0.LocalName == "serAx")
									{
										chart_0.SeriesAxis.IsVisible = true;
										method_56(xmlTextReader_0, "serAx");
									}
									else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
									{
										method_43(xmlTextReader_0, chart_0.PlotArea.ShapeProperties);
									}
									else if (xmlTextReader_0.LocalName == "dTable")
									{
										chart_0.ShowDataTable = true;
										ChartDataTable chartDataTable = chart_0.ChartDataTable;
										method_53(xmlTextReader_0, chartDataTable);
									}
									else
									{
										xmlTextReader_0.Skip();
									}
								}
								else
								{
									bool bool_ = xmlTextReader_0.LocalName.IndexOf("3D") != -1;
									method_16(xmlTextReader_0, bool_);
								}
							}
							else
							{
								bool bool_2 = xmlTextReader_0.LocalName.IndexOf("3D") != -1;
								method_9(xmlTextReader_0, bool_2);
							}
						}
						else
						{
							bool bool_3 = xmlTextReader_0.LocalName.IndexOf("3D") != -1;
							method_10(xmlTextReader_0, bool_3);
						}
					}
					else
					{
						bool bool_4 = xmlTextReader_0.LocalName.IndexOf("3D") != -1;
						method_17(xmlTextReader_0, bool_4);
					}
				}
				else
				{
					bool bool_5 = xmlTextReader_0.LocalName.IndexOf("3D") != -1;
					method_20(xmlTextReader_0, bool_5);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (arrayList_0.Count > 0)
		{
			method_54();
		}
	}

	private void method_8(XmlTextReader xmlTextReader_0)
	{
		Class1387 @class = new Class1387(chart_0.method_18());
		chart_0.method_18().Add(@class);
		@class.method_12(ChartType.PiePie);
		new StringBuilder(20);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "ofPieType")
			{
				switch (smethod_0(xmlTextReader_0))
				{
				case "pie":
					@class.method_12(ChartType.PiePie);
					break;
				case "bar":
					@class.method_12(ChartType.PieBar);
					break;
				}
			}
			else if (xmlTextReader_0.LocalName == "gapWidth")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					@class.GapWidth = Class1618.smethod_87(text);
				}
			}
			else if (xmlTextReader_0.LocalName == "splitType")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					@class.SplitType = Class1618.smethod_121(text2);
				}
			}
			else if (xmlTextReader_0.LocalName == "splitPos")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					@class.SplitValue = Class1618.smethod_85(text3);
				}
			}
			else if (xmlTextReader_0.LocalName == "secondPieSize")
			{
				string text4 = smethod_0(xmlTextReader_0);
				if (text4 != null)
				{
					@class.SecondPlotSize = Class1618.smethod_87(text4);
				}
			}
			else if (xmlTextReader_0.LocalName == "serLines")
			{
				method_19(xmlTextReader_0, @class.method_28());
			}
			else if (xmlTextReader_0.LocalName == "varyColors")
			{
				string text5 = smethod_0(xmlTextReader_0);
				if (text5 != null)
				{
					@class.IsColorVaried = ((!(text5 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "ser")
			{
				method_21(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "firstSliceAng")
			{
				string text6 = smethod_0(xmlTextReader_0);
				if (text6 != null)
				{
					@class.FirstSliceAngle = Class1618.smethod_87(text6);
				}
			}
			else if (xmlTextReader_0.LocalName == "dLbls" && !xmlTextReader_0.IsEmptyElement)
			{
				DataLabels dataLabels_ = new DataLabels(chart_0, chart_0);
				method_36(xmlTextReader_0, dataLabels_, null);
				chart_0.NSeries.method_10(@class, dataLabels_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		chart_0.method_19(@class.method_11());
	}

	private void method_9(XmlTextReader xmlTextReader_0, bool bool_1)
	{
		Class1387 @class = new Class1387(chart_0.method_18());
		chart_0.method_18().Add(@class);
		@class.method_12(ChartType.Area);
		string string_ = "standard";
		StringBuilder stringBuilder = new StringBuilder(20);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "grouping")
			{
				string_ = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "varyColors")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					@class.IsColorVaried = ((!(text == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "ser")
			{
				method_21(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "dropLines")
			{
				@class.HasDropLines = true;
				method_19(xmlTextReader_0, @class.method_29());
			}
			else if (xmlTextReader_0.LocalName == "axId")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" ");
					}
					stringBuilder.Append(text2);
				}
			}
			else if (xmlTextReader_0.LocalName == "dLbls" && !xmlTextReader_0.IsEmptyElement)
			{
				DataLabels dataLabels_ = new DataLabels(chart_0, chart_0);
				method_36(xmlTextReader_0, dataLabels_, null);
				chart_0.NSeries.method_10(@class, dataLabels_);
			}
			else if (xmlTextReader_0.LocalName == "gapDepth")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					chart_0.GapDepth = Class1618.smethod_87(text3);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		@class.method_12(Class1618.smethod_113(string_, bool_1));
		hashtable_0.Add(@class, stringBuilder.ToString());
		chart_0.method_19(@class.method_11());
	}

	private void method_10(XmlTextReader xmlTextReader_0, bool bool_1)
	{
		Class1387 @class = new Class1387(chart_0.method_18());
		chart_0.method_18().Add(@class);
		@class.method_12(ChartType.Pie);
		new StringBuilder(20);
		xmlTextReader_0.Read();
		ArrayList arrayList = new ArrayList();
		int int_ = 0;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "varyColors")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					@class.IsColorVaried = ((!(text == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "ser")
			{
				Series series = method_21(xmlTextReader_0, @class);
				if (series.int_3 == -1)
				{
					series.int_3 = int_;
				}
				int_ = series.int_3;
				arrayList.Add(series);
			}
			else if (xmlTextReader_0.LocalName == "firstSliceAng")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					@class.FirstSliceAngle = Class1618.smethod_87(text2);
				}
			}
			else if (xmlTextReader_0.LocalName == "dLbls" && !xmlTextReader_0.IsEmptyElement)
			{
				DataLabels dataLabels_ = new DataLabels(chart_0, chart_0);
				method_36(xmlTextReader_0, dataLabels_, null);
				chart_0.NSeries.method_10(@class, dataLabels_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		bool flag = false;
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series2 = nSeries[i];
			if (series2.Explosion > 0)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			if (bool_1)
			{
				@class.method_13(ChartType.Pie3DExploded);
			}
			else
			{
				@class.method_13(ChartType.PieExploded);
			}
		}
		else if (bool_1)
		{
			@class.method_13(ChartType.Pie3D);
		}
		else
		{
			@class.method_13(ChartType.Pie);
		}
		chart_0.method_19(@class.method_11());
		Series series3 = null;
		foreach (Series item in arrayList)
		{
			if (series3 == null)
			{
				series3 = item;
			}
			else if (item.int_3 < series3.int_3)
			{
				series3 = item;
			}
		}
		if (series3 != null)
		{
			series3.HasLeaderLines = series3.method_35();
		}
	}

	private void method_11(XmlTextReader xmlTextReader_0)
	{
		Class1387 @class = new Class1387(chart_0.method_18());
		chart_0.method_18().Add(@class);
		@class.method_12(ChartType.ScatterConnectedByLinesWithDataMarker);
		string string_ = "marker";
		StringBuilder stringBuilder = new StringBuilder(20);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "scatterStyle")
			{
				string_ = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "ser")
			{
				method_21(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "axId")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" ");
					}
					stringBuilder.Append(text);
				}
			}
			else if (xmlTextReader_0.LocalName == "dLbls" && !xmlTextReader_0.IsEmptyElement)
			{
				DataLabels dataLabels_ = new DataLabels(chart_0, chart_0);
				method_36(xmlTextReader_0, dataLabels_, null);
				chart_0.NSeries.method_10(@class, dataLabels_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		@class.method_12(Class1618.smethod_125(string_));
		hashtable_0.Add(@class, stringBuilder.ToString());
		chart_0.method_19(@class.method_11());
	}

	private void method_12(XmlTextReader xmlTextReader_0)
	{
		Class1387 @class = new Class1387(chart_0.method_18());
		chart_0.method_18().Add(@class);
		@class.method_12(ChartType.Bubble);
		StringBuilder stringBuilder = new StringBuilder(20);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "bubbleScale")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					@class.BubbleScale = Class1618.smethod_87(text);
				}
			}
			else if (xmlTextReader_0.LocalName == "varyColors")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					@class.IsColorVaried = ((!(text2 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "ser")
			{
				method_21(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "showNegBubbles")
			{
				string text3 = smethod_0(xmlTextReader_0);
				@class.ShowNegativeBubbles = ((!(text3 == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "sizeRepresents")
			{
				string text4 = smethod_0(xmlTextReader_0);
				if (text4 == "w")
				{
					@class.SizeRepresents = BubbleSizeRepresents.SizeIsWidth;
				}
			}
			else if (xmlTextReader_0.LocalName == "axId")
			{
				string text5 = smethod_0(xmlTextReader_0);
				if (text5 != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" ");
					}
					stringBuilder.Append(text5);
				}
			}
			else if (xmlTextReader_0.LocalName == "dLbls" && !xmlTextReader_0.IsEmptyElement)
			{
				DataLabels dataLabels_ = new DataLabels(chart_0, chart_0);
				method_36(xmlTextReader_0, dataLabels_, null);
				chart_0.NSeries.method_10(@class, dataLabels_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		bool flag = true;
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == @class && !series.Has3DEffect)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			@class.method_12(ChartType.Bubble3D);
		}
		else
		{
			@class.method_12(ChartType.Bubble);
		}
		hashtable_0.Add(@class, stringBuilder.ToString());
		chart_0.method_19(@class.method_11());
	}

	private void method_13(XmlTextReader xmlTextReader_0)
	{
		Class1387 @class = new Class1387(chart_0.method_18());
		chart_0.method_18().Add(@class);
		@class.method_12(ChartType.Pie);
		StringBuilder stringBuilder = new StringBuilder(20);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "varyColors")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					@class.IsColorVaried = ((!(text == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "ser")
			{
				method_21(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "firstSliceAng")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					@class.FirstSliceAngle = Class1618.smethod_87(text2);
				}
			}
			else if (xmlTextReader_0.LocalName == "holeSize")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					@class.DoughnutHoleSize = Class1618.smethod_87(text3);
				}
			}
			else if (xmlTextReader_0.LocalName == "axId")
			{
				string text4 = smethod_0(xmlTextReader_0);
				if (text4 != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" ");
					}
					stringBuilder.Append(text4);
				}
			}
			else if (xmlTextReader_0.LocalName == "dLbls" && !xmlTextReader_0.IsEmptyElement)
			{
				DataLabels dataLabels_ = new DataLabels(chart_0, chart_0);
				method_36(xmlTextReader_0, dataLabels_, null);
				chart_0.NSeries.method_10(@class, dataLabels_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		bool flag = false;
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.Explosion > 0)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			@class.method_12(ChartType.DoughnutExploded);
		}
		else
		{
			@class.method_12(ChartType.Doughnut);
		}
		chart_0.method_19(@class.method_11());
	}

	private void method_14(XmlTextReader xmlTextReader_0)
	{
		Class1387 @class = new Class1387(chart_0.method_18());
		chart_0.method_18().Add(@class);
		@class.method_12(ChartType.Scatter);
		string text = "standard";
		StringBuilder stringBuilder = new StringBuilder(20);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "radarStyle")
			{
				text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					@class.method_12(Class1618.smethod_128(text));
				}
			}
			else if (xmlTextReader_0.LocalName == "varyColors")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					@class.IsColorVaried = ((!(text2 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "ser")
			{
				method_21(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "axId")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" ");
					}
					stringBuilder.Append(text3);
				}
			}
			else if (xmlTextReader_0.LocalName == "dLbls" && !xmlTextReader_0.IsEmptyElement)
			{
				DataLabels dataLabels_ = new DataLabels(chart_0, chart_0);
				method_36(xmlTextReader_0, dataLabels_, null);
				chart_0.NSeries.method_10(@class, dataLabels_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		@class.method_12(Class1618.smethod_128(text));
		hashtable_0.Add(@class, stringBuilder.ToString());
		chart_0.method_19(@class.method_11());
	}

	private void method_15(XmlTextReader xmlTextReader_0)
	{
		Class1387 @class = new Class1387(chart_0.method_18());
		chart_0.method_18().Add(@class);
		@class.method_12(ChartType.Line);
		StringBuilder stringBuilder = new StringBuilder(20);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "ser")
			{
				method_21(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "hiLowLines")
			{
				@class.HasHiLoLines = true;
				method_19(xmlTextReader_0, @class.method_30());
			}
			else if (xmlTextReader_0.LocalName == "upDownBars")
			{
				@class.HasUpDownBars = true;
				method_18(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "axId")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" ");
					}
					stringBuilder.Append(text);
				}
			}
			else if (xmlTextReader_0.LocalName == "dLbls" && !xmlTextReader_0.IsEmptyElement)
			{
				DataLabels dataLabels_ = new DataLabels(chart_0, chart_0);
				method_36(xmlTextReader_0, dataLabels_, null);
				chart_0.NSeries.method_10(@class, dataLabels_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		hashtable_0.Add(@class, stringBuilder.ToString());
		chart_0.method_19(@class.method_11());
	}

	private void method_16(XmlTextReader xmlTextReader_0, bool bool_1)
	{
		Class1387 @class = new Class1387(chart_0.method_18());
		chart_0.method_18().Add(@class);
		@class.method_12(ChartType.Surface3D);
		bool flag = false;
		StringBuilder stringBuilder = new StringBuilder(20);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "wireframe")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					flag = ((!(text == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "ser")
			{
				method_21(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "axId")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" ");
					}
					stringBuilder.Append(text2);
				}
			}
			else if (xmlTextReader_0.LocalName == "dLbls" && !xmlTextReader_0.IsEmptyElement)
			{
				DataLabels dataLabels_ = new DataLabels(chart_0, chart_0);
				method_36(xmlTextReader_0, dataLabels_, null);
				chart_0.NSeries.method_10(@class, dataLabels_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (flag)
		{
			if (bool_1)
			{
				@class.method_12(ChartType.SurfaceWireframe3D);
			}
			else
			{
				@class.method_12(ChartType.SurfaceContourWireframe);
			}
		}
		else if (bool_1)
		{
			@class.method_12(ChartType.Surface3D);
		}
		else
		{
			@class.method_12(ChartType.SurfaceContour);
		}
		hashtable_0.Add(@class, stringBuilder.ToString());
		chart_0.method_19(@class.method_11());
	}

	private void method_17(XmlTextReader xmlTextReader_0, bool bool_1)
	{
		Class1387 @class = new Class1387(chart_0.method_18());
		chart_0.method_18().Add(@class);
		@class.method_12(ChartType.LineWithDataMarkers);
		if (bool_1)
		{
			@class.method_12(ChartType.Line3D);
		}
		string string_ = "standard";
		StringBuilder stringBuilder = new StringBuilder(20);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "grouping")
			{
				string_ = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "varyColors")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					@class.IsColorVaried = ((!(text == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "ser")
			{
				method_21(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "dropLines")
			{
				@class.HasDropLines = true;
				method_19(xmlTextReader_0, @class.method_29());
			}
			else if (xmlTextReader_0.LocalName == "hiLowLines")
			{
				@class.HasHiLoLines = true;
				method_19(xmlTextReader_0, @class.method_30());
			}
			else if (xmlTextReader_0.LocalName == "upDownBars")
			{
				@class.HasUpDownBars = true;
				method_18(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "axId")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" ");
					}
					stringBuilder.Append(text2);
				}
			}
			else if (xmlTextReader_0.LocalName == "dLbls" && !xmlTextReader_0.IsEmptyElement)
			{
				DataLabels dataLabels_ = new DataLabels(chart_0, chart_0);
				method_36(xmlTextReader_0, dataLabels_, null);
				chart_0.NSeries.method_10(@class, dataLabels_);
			}
			else if (xmlTextReader_0.LocalName == "gapDepth")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					chart_0.GapDepth = Class1618.smethod_87(text3);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		bool bool_2 = true;
		SeriesCollection nSeries = chart_0.NSeries;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Series series = nSeries[i];
			if (series.method_28() == @class && series.method_31() != null && series.MarkerStyle == ChartMarkerType.None)
			{
				bool_2 = false;
				break;
			}
		}
		if (bool_1)
		{
			@class.method_12(ChartType.Line3D);
		}
		else
		{
			@class.method_12(Class1618.smethod_115(bool_2, string_));
		}
		hashtable_0.Add(@class, stringBuilder.ToString());
		chart_0.method_19(@class.method_11());
	}

	private void method_18(XmlTextReader xmlTextReader_0, Class1387 class1387_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "gapWidth")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					class1387_0.GapWidth = Class1618.smethod_87(text);
				}
			}
			else if (xmlTextReader_0.LocalName == "upBars")
			{
				method_19(xmlTextReader_0, class1387_0.UpBars.ShapeProperties);
			}
			else if (xmlTextReader_0.LocalName == "downBars")
			{
				method_19(xmlTextReader_0, class1387_0.DownBars.ShapeProperties);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private bool method_19(XmlTextReader xmlTextReader_0, ShapePropertyCollection shapePropertyCollection_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return false;
		}
		bool result = false;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, shapePropertyCollection_0);
				result = true;
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return result;
	}

	private void method_20(XmlTextReader xmlTextReader_0, bool bool_1)
	{
		Class1387 @class = new Class1387(chart_0.method_18());
		chart_0.method_18().Add(@class);
		@class.method_12(ChartType.Bar);
		string string_ = "col";
		string string_2 = "clustered";
		string text = "box";
		StringBuilder stringBuilder = new StringBuilder(20);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "barDir")
			{
				string_ = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "grouping")
			{
				string_2 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "varyColors")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					@class.IsColorVaried = ((!(text2 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "ser")
			{
				method_21(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "overlap")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					@class.Overlap = Class1618.smethod_87(text3);
				}
			}
			else if (xmlTextReader_0.LocalName == "gapWidth")
			{
				string text4 = smethod_0(xmlTextReader_0);
				if (text4 != null)
				{
					@class.GapWidth = Class1618.smethod_87(text4);
				}
			}
			else if (xmlTextReader_0.LocalName == "gapDepth")
			{
				string text5 = smethod_0(xmlTextReader_0);
				if (text5 != null)
				{
					chart_0.GapDepth = Class1618.smethod_87(text5);
				}
			}
			else if (xmlTextReader_0.LocalName == "axId")
			{
				string text6 = smethod_0(xmlTextReader_0);
				if (text6 != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" ");
					}
					stringBuilder.Append(text6);
				}
			}
			else if (xmlTextReader_0.LocalName == "shape")
			{
				string text7 = smethod_0(xmlTextReader_0);
				if (text7 != null)
				{
					text = text7;
				}
			}
			else if (xmlTextReader_0.LocalName == "dLbls" && !xmlTextReader_0.IsEmptyElement)
			{
				DataLabels dataLabels_ = new DataLabels(chart_0, chart_0);
				method_36(xmlTextReader_0, dataLabels_, null);
				chart_0.NSeries.method_10(@class, dataLabels_);
			}
			else if (xmlTextReader_0.LocalName == "serLines")
			{
				method_19(xmlTextReader_0, @class.method_28());
				@class.method_16(bool_11: true);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		@class.method_13(Class1618.smethod_111(string_, string_2, bool_1, text));
		if (bool_1 && text != null)
		{
			if (@class.method_3() == null)
			{
				@class.method_4(new Class1632(@class));
			}
			@class.method_3().method_2(Class1618.smethod_131(text));
		}
		hashtable_0.Add(@class, stringBuilder.ToString());
		chart_0.method_19(@class.method_11());
	}

	private Series method_21(XmlTextReader xmlTextReader_0, Class1387 class1387_0)
	{
		Series series = new Series(worksheetCollection_0, chart_0.NSeries, 0);
		series.method_29(class1387_0);
		string text = null;
		string text2 = null;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "idx")
			{
				text = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "order")
			{
				text2 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "tx")
			{
				method_40(xmlTextReader_0, series);
			}
			else if (xmlTextReader_0.LocalName == "explosion")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					series.Explosion = Class1618.smethod_87(text3);
				}
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, series.ShapeProperties);
			}
			else if (xmlTextReader_0.LocalName == "extLst")
			{
				series.class929_0.string_0 = xmlTextReader_0.ReadOuterXml();
				if (series.Area.InvertIfNegative)
				{
					XmlTextReader xmlTextReader = Class1029.smethod_2(new StringReader(series.class929_0.string_0));
					xmlTextReader.Read();
					xmlTextReader.MoveToContent();
					if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.LocalName == "extLst")
					{
						method_23(xmlTextReader, series);
					}
					xmlTextReader.Close();
				}
			}
			else if (xmlTextReader_0.LocalName == "invertIfNegative")
			{
				string text4 = smethod_0(xmlTextReader_0);
				if (text4 != null)
				{
					series.Area.InvertIfNegative = ((!(text4 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "marker" && !xmlTextReader_0.IsEmptyElement)
			{
				series.Shadow = method_39(xmlTextReader_0, series.Marker);
			}
			else if (xmlTextReader_0.LocalName == "dPt" && !xmlTextReader_0.IsEmptyElement)
			{
				method_38(xmlTextReader_0, series);
			}
			else if (xmlTextReader_0.LocalName == "dLbls" && !xmlTextReader_0.IsEmptyElement)
			{
				method_36(xmlTextReader_0, series.DataLabels, series);
			}
			else if (xmlTextReader_0.LocalName == "trendline" && !xmlTextReader_0.IsEmptyElement)
			{
				method_34(xmlTextReader_0, series);
			}
			else if (xmlTextReader_0.LocalName == "errBars" && !xmlTextReader_0.IsEmptyElement)
			{
				method_28(xmlTextReader_0, series);
			}
			else if (xmlTextReader_0.LocalName == "cat" && !xmlTextReader_0.IsEmptyElement)
			{
				string[] string_ = method_29(xmlTextReader_0);
				method_22(series, string_, bool_1: false, bool_2: true);
			}
			else if (xmlTextReader_0.LocalName == "val" && !xmlTextReader_0.IsEmptyElement)
			{
				string[] string_2 = method_29(xmlTextReader_0);
				method_22(series, string_2, bool_1: false, bool_2: false);
			}
			else if (xmlTextReader_0.LocalName == "xVal" && !xmlTextReader_0.IsEmptyElement)
			{
				string[] string_3 = method_29(xmlTextReader_0);
				method_22(series, string_3, bool_1: false, bool_2: true);
			}
			else if (xmlTextReader_0.LocalName == "yVal" && !xmlTextReader_0.IsEmptyElement)
			{
				string[] string_4 = method_29(xmlTextReader_0);
				method_22(series, string_4, bool_1: false, bool_2: false);
			}
			else if (xmlTextReader_0.LocalName == "bubbleSize" && !xmlTextReader_0.IsEmptyElement)
			{
				string[] string_5 = method_29(xmlTextReader_0);
				method_22(series, string_5, bool_1: true, bool_2: false);
			}
			else if (xmlTextReader_0.LocalName == "smooth")
			{
				string text5 = smethod_0(xmlTextReader_0);
				if (text5 != null)
				{
					series.Smooth = ((!(text5 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "bubble3D")
			{
				string text6 = smethod_0(xmlTextReader_0);
				if (text6 != null)
				{
					series.Has3DEffect = ((!(text6 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "shape")
			{
				string text7 = smethod_0(xmlTextReader_0);
				if (text7 != null)
				{
					series.method_23(Class1618.smethod_131(text7));
				}
			}
			else if (xmlTextReader_0.LocalName == "pictureOptions")
			{
				method_27(xmlTextReader_0, series);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (text != null)
		{
			series.method_1(Class1618.smethod_87(text));
		}
		if (text2 != null)
		{
			int int_ = (series.int_3 = Class1618.smethod_87(text2));
			chart_0.NSeries.method_7(int_, series);
		}
		else
		{
			chart_0.NSeries.method_8(series);
		}
		arrayList_1.Add(series);
		return series;
	}

	private void method_22(Series series_0, string[] string_2, bool bool_1, bool bool_2)
	{
		if (bool_1)
		{
			try
			{
				if (string_2[0] != null)
				{
					series_0.BubbleSizes = string_2[0];
				}
				if (string_2[1] != null && string_2[1].Length > 2)
				{
					string text = string_2[1].Substring(1, string_2[1].Length - 2);
					ArrayList arrayList = new ArrayList();
					arrayList.AddRange(text.Split(','));
					series_0.method_20().imethod_3(arrayList);
				}
				return;
			}
			catch
			{
				try
				{
					if (string_2[1] != null)
					{
						series_0.BubbleSizes = string_2[1];
					}
					return;
				}
				catch (Exception)
				{
					return;
				}
			}
		}
		if (!bool_2)
		{
			try
			{
				bool flag = false;
				bool flag2 = false;
				if (string_2[0] != null)
				{
					if (string_2[0].ToUpper() == "#REF!")
					{
						flag = true;
						if (string_2[1] != null)
						{
							series_0.Values = string_2[1];
						}
					}
					else
					{
						series_0.Values = string_2[0];
						flag2 = series_0.method_16().imethod_0();
					}
				}
				if ((!flag2 || chart_0.method_5()) && string_2[1] != null && !flag)
				{
					if (string_2[1].Length > 2)
					{
						string text2 = string_2[1].Substring(1, string_2[1].Length - 2);
						ArrayList arrayList2 = new ArrayList();
						arrayList2.AddRange(text2.Split(','));
						series_0.method_16().imethod_3(arrayList2);
					}
					else if (chart_0.PivotSource != null)
					{
						series_0.method_16().imethod_3(new ArrayList());
					}
				}
				return;
			}
			catch
			{
				try
				{
					if (string_2[1] != null)
					{
						series_0.Values = string_2[1];
					}
					return;
				}
				catch (Exception)
				{
					return;
				}
			}
		}
		try
		{
			bool flag3 = false;
			if (string_2[0] != null)
			{
				series_0.XValues = string_2[0];
				flag3 = series_0.method_18().imethod_0();
			}
			if ((!flag3 || chart_0.method_5()) && string_2[1] != null && string_2[1].Length > 2)
			{
				string text3 = string_2[1].Substring(1, string_2[1].Length - 2);
				ArrayList arrayList3 = new ArrayList();
				arrayList3.AddRange(text3.Split(','));
				series_0.method_18().imethod_3(arrayList3);
			}
		}
		catch
		{
			try
			{
				if (string_2[1] != null)
				{
					series_0.XValues = string_2[1];
				}
			}
			catch (Exception)
			{
			}
		}
	}

	[Attribute0(true)]
	private void method_23(XmlTextReader xmlTextReader_0, Series series_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "ext")
			{
				method_24(xmlTextReader_0, series_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_24(XmlTextReader xmlTextReader_0, Series series_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "invertSolidFillFmt")
			{
				method_25(xmlTextReader_0, series_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_25(XmlTextReader xmlTextReader_0, Series series_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "spPr")
			{
				method_26(xmlTextReader_0, series_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_26(XmlTextReader xmlTextReader_0, Series series_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "solidFill")
			{
				InternalColor internalColor = Class1238.smethod_0(xmlTextReader_0, new Class923());
				if (!internalColor.method_2() && series_0.Area.FillFormat.Type == FillType.Solid)
				{
					series_0.Area.FillFormat.SolidFill.internalColor_1 = internalColor;
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_27(XmlTextReader xmlTextReader_0, Series series_0)
	{
		TextureFill textureFill = series_0.Area.FillFormat.TextureFill;
		if (textureFill.PicFormatOption == null)
		{
			textureFill.PicFormatOption = new PicFormatOption();
		}
		PicFormatOption picFormatOption = textureFill.PicFormatOption;
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "pictureFormat")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					picFormatOption.Type = Class1618.smethod_189(text);
				}
			}
			else if (xmlTextReader_0.LocalName == "pictureStackUnit")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					picFormatOption.Scale = Class1618.smethod_85(text2);
				}
			}
			else if (xmlTextReader_0.LocalName == "applyToFront")
			{
				string text3 = smethod_0(xmlTextReader_0);
				picFormatOption.method_5((!(text3 == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "applyToSides")
			{
				string text4 = smethod_0(xmlTextReader_0);
				picFormatOption.method_3((!(text4 == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "applyToEnd")
			{
				string text5 = smethod_0(xmlTextReader_0);
				picFormatOption.method_7((!(text5 == "0")) ? true : false);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_28(XmlTextReader xmlTextReader_0, Series series_0)
	{
		ErrorBar errorBar = null;
		errorBar = ((series_0.method_33() != null) ? series_0.XErrorBar : series_0.YErrorBar);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "errDir")
			{
				string text = smethod_0(xmlTextReader_0);
				errorBar = ((!(text == "y")) ? series_0.XErrorBar : series_0.YErrorBar);
			}
			else if (xmlTextReader_0.LocalName == "errBarType")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					errorBar.method_31(Class1618.smethod_105(text2));
				}
			}
			else if (xmlTextReader_0.LocalName == "errValType")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					errorBar.Type = Class1618.smethod_107(text3);
				}
			}
			else if (xmlTextReader_0.LocalName == "plus" && !xmlTextReader_0.IsEmptyElement)
			{
				string[] array = method_29(xmlTextReader_0);
				try
				{
					if (array[0] != null)
					{
						errorBar.PlusValue = array[0];
					}
				}
				catch
				{
					try
					{
						if (array[1] != null)
						{
							errorBar.PlusValue = array[1];
						}
					}
					catch (Exception)
					{
					}
				}
			}
			else if (xmlTextReader_0.LocalName == "minus" && !xmlTextReader_0.IsEmptyElement)
			{
				string[] array2 = method_29(xmlTextReader_0);
				try
				{
					if (array2[0] != null)
					{
						errorBar.MinusValue = array2[0];
					}
				}
				catch
				{
					try
					{
						if (array2[1] != null)
						{
							errorBar.MinusValue = array2[1];
						}
					}
					catch (Exception)
					{
					}
				}
			}
			else if (xmlTextReader_0.LocalName == "val")
			{
				string text4 = smethod_0(xmlTextReader_0);
				if (text4 != null)
				{
					errorBar.Amount = Class1618.smethod_85(text4);
				}
			}
			else if (xmlTextReader_0.LocalName == "noEndCap")
			{
				string text5 = smethod_0(xmlTextReader_0);
				if (text5 != null)
				{
					errorBar.ShowMarkerTTop = ((!(text5 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, errorBar.ShapeProperties);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private string[] method_29(XmlTextReader xmlTextReader_0)
	{
		string[] array = new string[4] { null, null, null, "0" };
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement)
			{
				if (!(xmlTextReader_0.LocalName == "numRef") && !(xmlTextReader_0.LocalName == "strRef") && !(xmlTextReader_0.LocalName == "multiLvlStrRef"))
				{
					if (xmlTextReader_0.LocalName == "numLit")
					{
						array[0] = method_33(xmlTextReader_0, array);
					}
					else if (xmlTextReader_0.LocalName == "strLit")
					{
						array[0] = method_33(xmlTextReader_0, array);
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				else
				{
					array = method_30(xmlTextReader_0);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return array;
	}

	[Attribute0(true)]
	private string[] method_30(XmlTextReader xmlTextReader_0)
	{
		string[] array = new string[4] { null, null, null, "0" };
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return array;
		}
		string text = null;
		string text2 = null;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement)
			{
				if (xmlTextReader_0.LocalName == "f")
				{
					string text3 = xmlTextReader_0.ReadElementString();
					if (text3[0] != '(' && text3.IndexOf('!') == -1 && text3.IndexOf(',') != -1 && text3[0] != '{')
					{
						text3 = "{" + text3 + "}";
					}
					text = text3;
					if (text.IndexOf("[0]!") != -1)
					{
						text = text.Substring(4);
					}
				}
				else if (!(xmlTextReader_0.LocalName == "numCache") && !(xmlTextReader_0.LocalName == "strCache"))
				{
					if (xmlTextReader_0.LocalName == "multiLvlStrCache")
					{
						text2 = method_31(xmlTextReader_0);
						array[3] = "1";
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				else
				{
					text2 = method_33(xmlTextReader_0, array);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		array[0] = text;
		array[1] = text2;
		return array;
	}

	[Attribute0(true)]
	private string method_31(XmlTextReader xmlTextReader_0)
	{
		StringBuilder stringBuilder = new StringBuilder(50);
		stringBuilder.Append("{");
		xmlTextReader_0.Read();
		int num = 0;
		ArrayList arrayList = new ArrayList();
		int num2 = -1;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "lvl")
			{
				num2++;
				if (xmlTextReader_0.IsEmptyElement)
				{
					xmlTextReader_0.Skip();
					continue;
				}
				xmlTextReader_0.Read();
				int num3 = -1;
				while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
				{
					xmlTextReader_0.MoveToContent();
					if (xmlTextReader_0.NodeType != XmlNodeType.Element)
					{
						xmlTextReader_0.Skip();
					}
					else if (xmlTextReader_0.LocalName == "pt")
					{
						string text = null;
						int num4 = int.Parse(xmlTextReader_0.GetAttribute("idx"));
						xmlTextReader_0.Read();
						while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
						{
							xmlTextReader_0.MoveToContent();
							if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "v" && !xmlTextReader_0.IsEmptyElement)
							{
								text = xmlTextReader_0.ReadElementString();
							}
							else
							{
								xmlTextReader_0.Skip();
							}
						}
						xmlTextReader_0.ReadEndElement();
						if (num4 >= arrayList.Count)
						{
							for (int i = arrayList.Count - 1; i < num4; i++)
							{
								arrayList.Add("");
							}
						}
						if (num4 - num3 > 1)
						{
							for (int j = num3 + 1; j < num4; j++)
							{
								if (num2 > 0)
								{
									arrayList[j] = (string)arrayList[j] + "\n";
								}
							}
						}
						if (num2 > 0)
						{
							arrayList[num4] = (string)arrayList[num4] + "\n";
						}
						if (text != null)
						{
							arrayList[num4] = (string)arrayList[num4] + text;
						}
						num3 = num4;
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				xmlTextReader_0.ReadEndElement();
			}
			else if (xmlTextReader_0.LocalName == "ptCount")
			{
				num = int.Parse(xmlTextReader_0.GetAttribute("val"));
				for (int k = 0; k < num; k++)
				{
					arrayList.Add("");
				}
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		for (int l = 0; l < arrayList.Count; l++)
		{
			if (l == 0)
			{
				stringBuilder.Append(method_32((string)arrayList[l], '\n'));
			}
			else
			{
				stringBuilder.Append("," + method_32((string)arrayList[l], '\n'));
			}
		}
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}

	private string method_32(string string_2, char char_0)
	{
		while (string_2.Length > 0 && string_2[string_2.Length - 1] == char_0)
		{
			string_2 = string_2.Substring(0, string_2.Length - 1);
		}
		return string_2;
	}

	[Attribute0(true)]
	private string method_33(XmlTextReader xmlTextReader_0, string[] string_2)
	{
		StringBuilder stringBuilder = new StringBuilder(50);
		stringBuilder.Append("{");
		xmlTextReader_0.Read();
		int num = 0;
		ArrayList arrayList = new ArrayList();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "pt")
			{
				string value = null;
				int num2 = int.Parse(xmlTextReader_0.GetAttribute("idx"));
				xmlTextReader_0.Read();
				while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
				{
					xmlTextReader_0.MoveToContent();
					if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "v" && !xmlTextReader_0.IsEmptyElement)
					{
						value = xmlTextReader_0.ReadElementString();
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				xmlTextReader_0.ReadEndElement();
				if (num2 >= arrayList.Count)
				{
					for (int i = arrayList.Count - 1; i < num2; i++)
					{
						arrayList.Add("");
					}
				}
				arrayList[num2] = value;
			}
			else if (xmlTextReader_0.LocalName == "formatCode")
			{
				string_2[2] = xmlTextReader_0.ReadElementString();
			}
			else if (xmlTextReader_0.LocalName == "ptCount")
			{
				num = int.Parse(xmlTextReader_0.GetAttribute("val"));
				for (int j = 0; j < num; j++)
				{
					arrayList.Add("");
				}
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		for (int k = 0; k < arrayList.Count; k++)
		{
			if (k == 0)
			{
				stringBuilder.Append((string)arrayList[k]);
			}
			else
			{
				stringBuilder.Append("," + (string)arrayList[k]);
			}
		}
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}

	private void method_34(XmlTextReader xmlTextReader_0, Series series_0)
	{
		Trendline trendline = new Trendline(series_0);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "name")
			{
				trendline.Name = xmlTextReader_0.ReadElementString();
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, trendline.ShapeProperties);
			}
			else if (xmlTextReader_0.LocalName == "trendlineType")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					trendline.method_33(Class1618.smethod_103(text));
				}
			}
			else if (xmlTextReader_0.LocalName == "order")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					trendline.Order = Class1618.smethod_87(text2);
				}
			}
			else if (xmlTextReader_0.LocalName == "period")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					trendline.method_34(Class1618.smethod_87(text3));
				}
			}
			else if (xmlTextReader_0.LocalName == "forward")
			{
				string text4 = smethod_0(xmlTextReader_0);
				if (text4 != null)
				{
					trendline.Forward = Class1618.smethod_85(text4);
				}
			}
			else if (xmlTextReader_0.LocalName == "backward")
			{
				string text5 = smethod_0(xmlTextReader_0);
				if (text5 != null)
				{
					trendline.method_35(Class1618.smethod_85(text5));
				}
			}
			else if (xmlTextReader_0.LocalName == "intercept")
			{
				string text6 = smethod_0(xmlTextReader_0);
				if (text6 != null)
				{
					trendline.Intercept = Class1618.smethod_85(text6);
				}
			}
			else if (xmlTextReader_0.LocalName == "dispEq")
			{
				string text7 = smethod_0(xmlTextReader_0);
				if (text7 != null)
				{
					trendline.DisplayEquation = ((!(text7 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "dispRSqr")
			{
				string text8 = smethod_0(xmlTextReader_0);
				if (text8 != null)
				{
					trendline.DisplayRSquared = ((!(text8 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "trendlineLbl")
			{
				method_35(xmlTextReader_0, trendline.DataLabels);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		series_0.TrendLines.Add(trendline);
	}

	private void method_35(XmlTextReader xmlTextReader_0, DataLabels dataLabels_0)
	{
		xmlTextReader_0.Read();
		bool flag = false;
		bool flag2 = false;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "numFmt")
			{
				flag = true;
				string attribute = xmlTextReader_0.GetAttribute("formatCode");
				if (attribute != null)
				{
					dataLabels_0.method_49(attribute);
				}
				attribute = xmlTextReader_0.GetAttribute("sourceLinked");
				if (attribute != null)
				{
					dataLabels_0.method_52((!(attribute == "0")) ? true : false);
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "txPr")
			{
				flag2 = true;
				Class1570 @class = method_45(xmlTextReader_0);
				if (dataLabels_0 != null)
				{
					@class.method_8(dataLabels_0, worksheetCollection_0);
				}
			}
			else if (xmlTextReader_0.LocalName == "tx")
			{
				Class1570 class2 = method_47(xmlTextReader_0);
				if (class2 != null && dataLabels_0 != null)
				{
					class2.method_8(dataLabels_0, worksheetCollection_0);
				}
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, dataLabels_0.ShapeProperties);
			}
			else if (xmlTextReader_0.LocalName == "layout")
			{
				method_44(xmlTextReader_0)?.method_3(chart_0, dataLabels_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (dataLabels_0 == null)
		{
			method_48("trendlineLbl");
		}
		else if (!flag && flag2)
		{
			dataLabels_0.method_55(bool_16: true);
		}
	}

	private void method_36(XmlTextReader xmlTextReader_0, DataLabels dataLabels_0, Series series_0)
	{
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "dLbl" && series_0 != null)
			{
				method_37(xmlTextReader_0, series_0);
			}
			else if (xmlTextReader_0.LocalName == "numFmt")
			{
				string attribute = xmlTextReader_0.GetAttribute("formatCode");
				if (attribute != null)
				{
					dataLabels_0.method_49(attribute);
				}
				attribute = xmlTextReader_0.GetAttribute("sourceLinked");
				if (attribute != null)
				{
					dataLabels_0.method_52((!(attribute == "0")) ? true : false);
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, dataLabels_0.ShapeProperties);
			}
			else if (xmlTextReader_0.LocalName == "txPr")
			{
				Class1570 @class = method_45(xmlTextReader_0);
				@class.method_8(dataLabels_0, worksheetCollection_0);
			}
			else if (xmlTextReader_0.LocalName == "dLblPos")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					dataLabels_0.method_67(Class1618.smethod_99(text));
				}
			}
			else if (xmlTextReader_0.LocalName == "delete")
			{
				smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "showLegendKey")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					bool bool_ = ((!(text2 == "0")) ? true : false);
					dataLabels_0.method_47(bool_);
				}
			}
			else if (xmlTextReader_0.LocalName == "showVal")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					bool bool_2 = ((!(text3 == "0")) ? true : false);
					dataLabels_0.method_45(Enum127.const_1, bool_2);
				}
			}
			else if (xmlTextReader_0.LocalName == "showBubbleSize")
			{
				string text4 = smethod_0(xmlTextReader_0);
				if (text4 != null && dataLabels_0 != null)
				{
					dataLabels_0.ShowBubbleSize = ((!(text4 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "showCatName")
			{
				string text5 = smethod_0(xmlTextReader_0);
				if (text5 != null)
				{
					bool bool_3 = ((!(text5 == "0")) ? true : false);
					dataLabels_0.method_45(Enum127.const_3, bool_3);
				}
			}
			else if (xmlTextReader_0.LocalName == "showSerName")
			{
				string text6 = smethod_0(xmlTextReader_0);
				if (text6 != null)
				{
					bool bool_4 = ((!(text6 == "0")) ? true : false);
					dataLabels_0.method_45(Enum127.const_5, bool_4);
				}
			}
			else if (xmlTextReader_0.LocalName == "showPercent")
			{
				string text7 = smethod_0(xmlTextReader_0);
				if (text7 != null)
				{
					bool bool_5 = ((!(text7 == "0")) ? true : false);
					dataLabels_0.method_45(Enum127.const_2, bool_5);
				}
			}
			else if (xmlTextReader_0.LocalName == "separator")
			{
				xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.All;
				string text8 = xmlTextReader_0.ReadElementString();
				if (text8 != null)
				{
					dataLabels_0.Separator = Class1618.smethod_109(text8);
				}
				xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
			}
			else if (xmlTextReader_0.LocalName == "showLeaderLines" && series_0 != null)
			{
				string text9 = smethod_0(xmlTextReader_0);
				if (text9 == "1")
				{
					series_0.method_36(bool_3: true);
				}
			}
			else if (xmlTextReader_0.LocalName == "leaderLines")
			{
				method_19(xmlTextReader_0, series_0.method_28().method_31());
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_37(XmlTextReader xmlTextReader_0, Series series_0)
	{
		ChartPoint chartPoint = null;
		DataLabels dataLabels = null;
		xmlTextReader_0.Read();
		bool flag = false;
		bool flag2 = false;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "idx")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					int int_ = Class1618.smethod_87(text);
					chartPoint = series_0.Points.method_1(int_);
					dataLabels = chartPoint.DataLabels;
				}
			}
			else if (xmlTextReader_0.LocalName == "delete")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					dataLabels.IsDeleted = Class1618.smethod_201(text2);
				}
				else
				{
					dataLabels.IsDeleted = true;
				}
			}
			else if (xmlTextReader_0.LocalName == "numFmt")
			{
				flag = true;
				dataLabels.method_55(bool_16: true);
				string attribute = xmlTextReader_0.GetAttribute("formatCode");
				if (attribute != null)
				{
					dataLabels.method_49(attribute);
				}
				attribute = xmlTextReader_0.GetAttribute("sourceLinked");
				if (attribute != null)
				{
					dataLabels.method_52((!(attribute == "0")) ? true : false);
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "showLegendKey")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null && dataLabels != null)
				{
					dataLabels.ShowLegendKey = ((!(text3 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "showVal")
			{
				string text4 = smethod_0(xmlTextReader_0);
				if (text4 != null && dataLabels != null)
				{
					dataLabels.ShowValue = ((!(text4 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "showBubbleSize")
			{
				string text5 = smethod_0(xmlTextReader_0);
				if (text5 != null && dataLabels != null)
				{
					dataLabels.ShowBubbleSize = ((!(text5 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "showCatName")
			{
				string text6 = smethod_0(xmlTextReader_0);
				if (text6 != null && dataLabels != null)
				{
					dataLabels.ShowCategoryName = ((!(text6 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "showSerName")
			{
				string text7 = smethod_0(xmlTextReader_0);
				if (text7 != null && dataLabels != null)
				{
					dataLabels.ShowSeriesName = ((!(text7 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "showPercent")
			{
				string text8 = smethod_0(xmlTextReader_0);
				if (text8 != null && dataLabels != null)
				{
					dataLabels.ShowPercentage = ((!(text8 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "separator")
			{
				xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.All;
				string text9 = smethod_0(xmlTextReader_0);
				if (text9 != null && dataLabels != null)
				{
					dataLabels.Separator = Class1618.smethod_109(text9);
				}
				xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
			}
			else if (xmlTextReader_0.LocalName == "txPr")
			{
				flag2 = true;
				Class1570 @class = method_45(xmlTextReader_0);
				if (dataLabels != null)
				{
					@class.method_8(dataLabels, worksheetCollection_0);
				}
			}
			else if (xmlTextReader_0.LocalName == "tx")
			{
				Class1570 class2 = method_47(xmlTextReader_0);
				if (class2 != null && dataLabels != null)
				{
					class2.method_8(dataLabels, worksheetCollection_0);
				}
			}
			else if (xmlTextReader_0.LocalName == "dLblPos")
			{
				string text10 = smethod_0(xmlTextReader_0);
				if (text10 != null)
				{
					dataLabels.method_67(Class1618.smethod_99(text10));
				}
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, dataLabels.ShapeProperties);
			}
			else if (xmlTextReader_0.LocalName == "layout" && series_0 != null)
			{
				method_44(xmlTextReader_0)?.method_3(chart_0, dataLabels);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (dataLabels == null)
		{
			method_48("dLbl");
		}
		else if (!flag && flag2)
		{
			dataLabels.method_55(bool_16: true);
		}
	}

	private void method_38(XmlTextReader xmlTextReader_0, Series series_0)
	{
		ChartPoint chartPoint = new ChartPoint(series_0, 0);
		string text = null;
		xmlTextReader_0.Read();
		bool flag = false;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "idx")
			{
				text = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "explosion")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					chartPoint.Explosion = Class1618.smethod_87(text2);
				}
				flag = true;
			}
			else if (xmlTextReader_0.LocalName == "invertIfNegative")
			{
				string text3 = smethod_0(xmlTextReader_0);
				chartPoint.Area.InvertIfNegative = ((!(text3 == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, chartPoint.ShapeProperties);
			}
			else if (xmlTextReader_0.LocalName == "marker" && !xmlTextReader_0.IsEmptyElement)
			{
				chartPoint.Shadow = method_39(xmlTextReader_0, chartPoint.Marker);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (text == null)
		{
			method_48("dpt");
		}
		int int_ = Class1618.smethod_87(text);
		if (!flag)
		{
			chartPoint.Explosion = series_0.Explosion;
		}
		chartPoint.int_0 = int_;
		series_0.Points.method_0(chartPoint);
	}

	private bool method_39(XmlTextReader xmlTextReader_0, Marker marker_0)
	{
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "symbol")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					marker_0.MarkerStyle = Class1618.smethod_117(text);
				}
			}
			else if (xmlTextReader_0.LocalName == "size")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					marker_0.MarkerSize = Class1618.smethod_87(text2);
				}
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, marker_0.ShapeProperties);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return marker_0.ShapeProperties.method_8();
	}

	private void method_40(XmlTextReader xmlTextReader_0, Series series_0)
	{
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement)
			{
				if (xmlTextReader_0.LocalName == "v")
				{
					series_0.Name = Class1618.smethod_8(xmlTextReader_0.ReadElementString());
				}
				else if (xmlTextReader_0.LocalName == "strRef")
				{
					xmlTextReader_0.Read();
					while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
					{
						xmlTextReader_0.MoveToContent();
						if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "f" && !xmlTextReader_0.IsEmptyElement)
						{
							string text = xmlTextReader_0.ReadElementString();
							try
							{
								if (text.ToUpper().IndexOf("#REF") == -1)
								{
									series_0.Name = "=" + text;
								}
							}
							catch (Exception)
							{
							}
						}
						else if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "strCache" && !xmlTextReader_0.IsEmptyElement)
						{
							method_41(xmlTextReader_0, series_0);
						}
						else
						{
							xmlTextReader_0.Skip();
						}
					}
					xmlTextReader_0.ReadEndElement();
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_41(XmlTextReader xmlTextReader_0, Series series_0)
	{
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement)
			{
				if (xmlTextReader_0.LocalName == "pt")
				{
					xmlTextReader_0.Read();
					while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
					{
						xmlTextReader_0.MoveToContent();
						if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement)
						{
							if (xmlTextReader_0.LocalName == "v")
							{
								string object_ = xmlTextReader_0.ReadElementString();
								if (series_0.method_13() == null)
								{
									series_0.method_12(object_);
								}
								else
								{
									series_0.string_0 = object_;
								}
							}
							else
							{
								xmlTextReader_0.Skip();
							}
						}
						else
						{
							xmlTextReader_0.Skip();
						}
					}
					xmlTextReader_0.ReadEndElement();
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_42(XmlTextReader xmlTextReader_0, Title title_0, bool bool_1)
	{
		title_0.method_46(bool_10: false);
		Class1570 @class = null;
		Class1570 class2 = null;
		bool flag = false;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "overlay")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text == "1")
				{
					title_0.method_44(bool_10: true);
				}
				else
				{
					title_0.method_44(bool_10: false);
				}
			}
			else if (xmlTextReader_0.IsEmptyElement)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "tx")
			{
				@class = method_47(xmlTextReader_0);
				flag = true;
			}
			else if (xmlTextReader_0.LocalName == "txPr")
			{
				class2 = method_45(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "layout")
			{
				method_44(xmlTextReader_0)?.method_0(chart_0, title_0);
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, title_0.ShapeProperties);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		class2?.method_7(title_0, worksheetCollection_0, bool_1);
		if (flag)
		{
			@class?.method_6(class2?.class1542_0, title_0, worksheetCollection_0, bool_1);
			if (title_0.method_39() == null && title_0.Text == null)
			{
				title_0.Text = "";
			}
		}
		else
		{
			title_0.IsAutoText = true;
		}
		if (class2 != null || @class != null)
		{
			return;
		}
		if (bool_1)
		{
			title_0.IsAutoText = true;
			if (!chart_0.ChartArea.Font.IsModified(StyleModifyFlag.FontWeight))
			{
				title_0.Font.IsBold = true;
			}
			if (chart_0.ChartArea.Font.IsModified(StyleModifyFlag.FontSize))
			{
				title_0.Font.DoubleSize = chart_0.ChartArea.Font.DoubleSize * 1.2;
				return;
			}
			switch (chart_0.Style)
			{
			default:
				title_0.Font.DoubleSize = 18.0;
				break;
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 48:
				title_0.Font.DoubleSize = 18.0;
				title_0.Font.Color = Color.White;
				break;
			case -1:
			case 2:
				title_0.Font.DoubleSize = 18.0;
				break;
			}
		}
		else
		{
			switch (chart_0.Style)
			{
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 48:
				title_0.Font.Color = Color.White;
				break;
			}
		}
	}

	private static string smethod_0(XmlTextReader xmlTextReader_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("val");
		xmlTextReader_0.Skip();
		return attribute;
	}

	private void method_43(XmlTextReader xmlTextReader_0, ShapePropertyCollection shapePropertyCollection_0)
	{
		Class1238 @class = new Class1238(shapePropertyCollection_0, class1548_0, chart_0, hashtable_1);
		@class.Read(xmlTextReader_0, shapePropertyCollection_0.object_0);
	}

	[Attribute0(true)]
	private Class1559 method_44(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return null;
		}
		Class1559 result = null;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "manualLayout" && !xmlTextReader_0.IsEmptyElement)
			{
				result = method_46(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return result;
	}

	private Class1570 method_45(XmlTextReader xmlTextReader_0)
	{
		return smethod_1(xmlTextReader_0);
	}

	[Attribute0(true)]
	private Class1559 method_46(XmlTextReader xmlTextReader_0)
	{
		Class1559 @class = new Class1559();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "layoutTarget")
			{
				@class.string_0 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "xMode")
			{
				@class.string_1 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "yMode")
			{
				@class.string_2 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "wMode")
			{
				@class.string_3 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "hMode")
			{
				@class.string_4 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "x")
			{
				@class.string_5 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "y")
			{
				@class.string_6 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "w")
			{
				@class.string_7 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "h")
			{
				@class.string_8 = smethod_0(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return @class;
	}

	[Attribute0(true)]
	private Class1570 method_47(XmlTextReader xmlTextReader_0)
	{
		Class1570 @class = null;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement)
			{
				if (xmlTextReader_0.LocalName == "rich")
				{
					@class = smethod_1(xmlTextReader_0);
					continue;
				}
				if (!(xmlTextReader_0.LocalName == "numRef") && !(xmlTextReader_0.LocalName == "strRef") && !(xmlTextReader_0.LocalName == "multiLvlStrRef"))
				{
					xmlTextReader_0.Skip();
					continue;
				}
				string[] array = method_30(xmlTextReader_0);
				if (array[0] != null || array[1] != null)
				{
					@class = new Class1570();
					@class.method_4(array[0], array[1]);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return @class;
	}

	[Attribute0(true)]
	private static Class1570 smethod_1(XmlTextReader xmlTextReader_0)
	{
		Class1570 @class = new Class1570();
		xmlTextReader_0.Read();
		bool flag = true;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "bodyPr")
			{
				string attribute = xmlTextReader_0.GetAttribute("rot");
				string attribute2 = xmlTextReader_0.GetAttribute("anchor");
				string attribute3 = xmlTextReader_0.GetAttribute("vert");
				if (attribute != null)
				{
					@class.int_0 = Class1618.smethod_87(attribute) / -60000;
				}
				if (attribute2 != null)
				{
					@class.method_1(Class1618.smethod_95(attribute2));
				}
				if (attribute3 != null && attribute3 == "wordArtVert")
				{
					@class.int_0 = 255;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "p")
			{
				smethod_2(xmlTextReader_0, @class, flag);
				if (flag)
				{
					flag = false;
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return @class;
	}

	[Attribute0(true)]
	internal static void smethod_2(XmlTextReader xmlTextReader_0, Class1570 class1570_0, bool bool_1)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1542 class1542_ = null;
		Class1565 @class = null;
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			if (xmlTextReader_0.LocalName == "pPr")
			{
				smethod_3(xmlTextReader_0, class1570_0);
			}
			else if (xmlTextReader_0.LocalName == "r")
			{
				Class1565 class2 = smethod_4(xmlTextReader_0);
				if (class1570_0.arrayList_0 == null)
				{
					class1570_0.arrayList_0 = new ArrayList();
				}
				class1570_0.arrayList_0.Add(class2);
				if (@class == null)
				{
					@class = class2;
				}
			}
			else if (xmlTextReader_0.LocalName == "defRPr")
			{
				class1570_0.class1542_0 = smethod_5(xmlTextReader_0);
				if (class1570_0.class1542_0 == null)
				{
					class1570_0.bool_2 = true;
				}
			}
			else if (xmlTextReader_0.LocalName == "fld")
			{
				Class1565 class3 = smethod_4(xmlTextReader_0);
				if (class1570_0.arrayList_0 == null)
				{
					class1570_0.arrayList_0 = new ArrayList();
				}
				class1570_0.arrayList_0.Add(class3);
				if (@class == null)
				{
					@class = class3;
				}
			}
			else if (xmlTextReader_0.LocalName == "endParaRPr")
			{
				if (@class == null)
				{
					class1542_ = smethod_5(xmlTextReader_0);
				}
				else
				{
					class1570_0.string_0 = xmlTextReader_0.ReadOuterXml();
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		if (bool_1)
		{
			return;
		}
		if (@class != null)
		{
			@class.string_0 = "\n" + @class.string_0;
			return;
		}
		Class1565 class4 = new Class1565();
		class4.string_0 = "\n";
		class4.class1542_0 = class1542_;
		if (class1570_0.arrayList_0 == null)
		{
			class1570_0.arrayList_0 = new ArrayList();
		}
		class1570_0.arrayList_0.Add(class4);
	}

	[Attribute0(true)]
	private static void smethod_3(XmlTextReader xmlTextReader_0, Class1570 class1570_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("rtl");
		string attribute2 = xmlTextReader_0.GetAttribute("algn");
		if (attribute != null && attribute == "1")
		{
			class1570_0.textDirectionType_0 = TextDirectionType.RightToLeft;
		}
		if (attribute2 != null)
		{
			class1570_0.method_3(Class1618.smethod_97(attribute2));
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			if (xmlTextReader_0.LocalName == "defRPr")
			{
				class1570_0.class1542_0 = smethod_5(xmlTextReader_0);
				if (class1570_0.class1542_0 == null)
				{
					class1570_0.bool_2 = true;
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private static Class1565 smethod_4(XmlTextReader xmlTextReader_0)
	{
		Class1565 @class = new Class1565();
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			if (xmlTextReader_0.LocalName == "rPr")
			{
				Class1542 class1542_ = smethod_5(xmlTextReader_0);
				@class.class1542_0 = class1542_;
			}
			else if (xmlTextReader_0.LocalName == "t")
			{
				xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.All;
				@class.string_0 = Class1618.smethod_8(xmlTextReader_0.ReadElementString());
				xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		return @class;
	}

	private static Class1542 smethod_5(XmlTextReader xmlTextReader_0)
	{
		Class1542 @class = new Class1542();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "lang")
				{
					@class.method_5(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "altLang")
				{
					@class.method_7(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "sz")
				{
					@class.method_16(Class1618.smethod_87(xmlTextReader_0.Value) / 5);
				}
				else if (xmlTextReader_0.LocalName == "b")
				{
					@class.IsBold = ((xmlTextReader_0.Value == "1") ? true : false);
				}
				else if (xmlTextReader_0.LocalName == "i")
				{
					@class.IsItalic = ((xmlTextReader_0.Value == "1") ? true : false);
				}
				else if (xmlTextReader_0.LocalName == "u")
				{
					@class.method_3(Class1618.smethod_77(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "strike")
				{
					if (xmlTextReader_0.Value == "dblStrike" || xmlTextReader_0.Value == "sngStrike")
					{
						@class.IsStrikeout = true;
					}
				}
				else
				{
					if (!(xmlTextReader_0.LocalName == "baseline"))
					{
						continue;
					}
					double num = Class1618.smethod_85(xmlTextReader_0.Value);
					if (num != 0.0)
					{
						if (num > 10000.0)
						{
							@class.IsSubscript = true;
						}
						else if (num < -10000.0)
						{
							@class.IsSuperscript = true;
						}
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			if (@class.method_21())
			{
				return null;
			}
			return @class;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			if (xmlTextReader_0.LocalName == "solidFill")
			{
				@class.method_11(Class1238.smethod_0(xmlTextReader_0, null));
			}
			else if (xmlTextReader_0.LocalName == "latin")
			{
				string attribute = xmlTextReader_0.GetAttribute("typeface");
				if (attribute != null && @class.Name == null)
				{
					@class.Name = attribute;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "ea")
			{
				string attribute2 = xmlTextReader_0.GetAttribute("typeface");
				if (attribute2 != null && @class.Name == null)
				{
					@class.Name = attribute2;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "cs")
			{
				string attribute3 = xmlTextReader_0.GetAttribute("typeface");
				if (attribute3 != null && @class.Name == null)
				{
					@class.Name = attribute3;
				}
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		if (@class.method_21())
		{
			return null;
		}
		return @class;
	}

	private void method_48(string string_2)
	{
		throw new CellsException(ExceptionType.InvalidData, "Miss or invalid idx element of " + string_2);
	}

	private void method_49(Class1546 class1546_0, Class1546 class1546_1)
	{
		if (class1546_0.string_2 != null)
		{
			class1546_1.axis_0.CrossType = Class1618.smethod_72(class1546_0.string_2);
		}
		if (class1546_0.string_3 != null)
		{
			class1546_1.axis_0.CrossAt = Class1618.smethod_85(class1546_0.string_3);
		}
		if (class1546_0.string_4 != null)
		{
			class1546_1.axis_0.AxisBetweenCategories = ((class1546_0.string_4 == "between") ? true : false);
		}
	}

	private Class1546 method_50(string string_2)
	{
		int num = 0;
		Class1546 @class;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				@class = (Class1546)arrayList_0[num];
				if (@class.string_0 == string_2)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}

	private Class1546 method_51(Class1546 class1546_0)
	{
		int num = 0;
		Class1546 @class;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				@class = (Class1546)arrayList_0[num];
				if (@class.string_0 == class1546_0.string_1)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		@class.axis_1 = class1546_0.axis_0;
		class1546_0.axis_1 = @class.axis_0;
		return @class;
	}

	private Axis method_52(string string_2)
	{
		Enum195 enum195_ = Enum195.const_0;
		switch (string_2)
		{
		case "catAx":
			enum195_ = Enum195.const_0;
			break;
		case "valAx":
			enum195_ = Enum195.const_1;
			break;
		case "dateAx":
			enum195_ = Enum195.const_0;
			break;
		case "serAx":
			enum195_ = Enum195.const_2;
			break;
		}
		Axis axis = new Axis(enum195_, bool_15: true, chart_0);
		if (string_2 == "dateAx")
		{
			axis.CategoryType = CategoryType.TimeScale;
		}
		else if (string_2 == "catAx")
		{
			axis.CategoryType = CategoryType.CategoryScale;
		}
		axis.MajorTickMark = TickMarkType.Outside;
		axis.MinorTickMark = TickMarkType.None;
		return axis;
	}

	private void method_53(XmlTextReader xmlTextReader_0, ChartDataTable chartDataTable_0)
	{
		chartDataTable_0.ShowLegendKey = false;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "showHorzBorder")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					chartDataTable_0.HasBorderHorizontal = ((!(text == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "showVertBorder")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 != null)
				{
					chartDataTable_0.HasBorderVertical = ((!(text2 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "showOutline")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					chartDataTable_0.HasBorderOutline = ((!(text3 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "showKeys")
			{
				string text4 = smethod_0(xmlTextReader_0);
				if (text4 != null)
				{
					chartDataTable_0.ShowLegendKey = ((!(text4 == "0")) ? true : false);
				}
			}
			else if (xmlTextReader_0.LocalName == "txPr")
			{
				Class1570 @class = method_45(xmlTextReader_0);
				if (@class.class1542_0 != null)
				{
					@class.method_5(chart_0, bool_3: false);
					chartDataTable_0.method_2(Class1618.smethod_119(@class.class1542_0, worksheetCollection_0));
				}
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, chartDataTable_0.ShapeProperties);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_54()
	{
		bool flag = false;
		int num = Math.Min(arrayList_0.Count, 4);
		int num2 = 0;
		Class1546 @class;
		while (true)
		{
			if (num2 < num)
			{
				@class = (Class1546)arrayList_0[num2];
				if (@class.axis_1 == null)
				{
					Class1546 class2 = method_51(@class);
					if (class2 == null)
					{
						break;
					}
					method_49(@class, class2);
					method_49(class2, @class);
					if (@class.axis_0.Type == Enum195.const_2)
					{
						chart_0.method_22(bool_9: false, @class.axis_0);
					}
					else
					{
						chart_0.method_23(flag, @class.axis_0, class2.axis_0);
						@class.bool_0 = !flag;
						class2.bool_0 = !flag;
						if (!flag)
						{
							flag = true;
						}
					}
				}
				num2++;
				continue;
			}
			IDictionaryEnumerator enumerator = hashtable_0.GetEnumerator();
			string[] array;
			while (true)
			{
				if (!enumerator.MoveNext())
				{
					return;
				}
				Class1387 class3 = (Class1387)enumerator.Key;
				string text = (string)enumerator.Value;
				if (text == null || text == "")
				{
					continue;
				}
				array = text.Split(' ');
				Class1546 class4 = method_50(array[0]);
				Class1546 class5 = method_50(array[1]);
				if (class4 != null)
				{
					if (class5 == null)
					{
						break;
					}
					class3.PlotOnSecondAxis = !class4.bool_0;
					if (class4.axis_0.Type == Enum195.const_2 || !method_55(class3))
					{
						continue;
					}
					Class1546 class6 = class4;
					if (class4.axis_0.Type == Enum195.const_0)
					{
						class6 = class5;
					}
					if (class6.axis_0.Type != Enum195.const_1)
					{
						class6 = method_51(class4);
					}
					if (!class6.bool_1)
					{
						Axis axis_ = class6.axis_0;
						if (axis_.MajorUnit > 0.0)
						{
							axis_.MajorUnit = 100.0 * axis_.MajorUnit;
						}
						if (axis_.MinorUnit > 0.0)
						{
							axis_.MinorUnit = 100.0 * axis_.MinorUnit;
						}
						if (axis_.CrossType == CrossType.Custom && axis_.CrossAt != 0.0)
						{
							axis_.CrossAt = 100.0 * axis_.CrossAt;
						}
						if (!axis_.method_6())
						{
							axis_.MaxValue = 100.0 * (double)axis_.MaxValue;
						}
						if (!axis_.method_3())
						{
							axis_.MinValue = 100.0 * (double)axis_.MinValue;
						}
						class6.bool_1 = true;
					}
					continue;
				}
				throw new CellsException(ExceptionType.InvalidData, "axis " + array[0] + " not found!");
			}
			throw new CellsException(ExceptionType.InvalidData, "axis " + array[1] + " not found!");
		}
		throw new CellsException(ExceptionType.InvalidData, "axis " + @class.string_1 + " not found!");
	}

	private bool method_55(Class1387 class1387_0)
	{
		switch (class1387_0.method_11())
		{
		default:
			return false;
		case ChartType.Area100PercentStacked:
		case ChartType.Area3D100PercentStacked:
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.Column100PercentStacked:
		case ChartType.Column3D100PercentStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.Line100PercentStackedWithDataMarkers:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBar100PercentStacked:
			return true;
		}
	}

	private Axis method_56(XmlTextReader xmlTextReader_0, string string_2)
	{
		Axis axis = method_52(string_2);
		axis.string_0 = string_2;
		Class1546 @class = new Class1546();
		@class.axis_0 = axis;
		arrayList_0.Add(@class);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "axId")
			{
				@class.string_0 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "scaling")
			{
				method_59(xmlTextReader_0, axis);
			}
			else if (xmlTextReader_0.LocalName == "axPos")
			{
				string text = (axis.string_1 = smethod_0(xmlTextReader_0));
				if (!(text == "b") && !(text == "t"))
				{
					continue;
				}
				bool flag = true;
				if (chart_0.class1388_0.Count == 0)
				{
					flag = false;
				}
				for (int i = 0; i < chart_0.class1388_0.Count; i++)
				{
					Class1387 class2 = chart_0.class1388_0[i];
					if (!ChartCollection.smethod_11(class2.method_11()) && !ChartCollection.smethod_17(class2.method_11()))
					{
						flag = false;
					}
				}
				if (flag)
				{
					axis.Type = Enum195.const_0;
				}
			}
			else if (xmlTextReader_0.LocalName == "title" && !xmlTextReader_0.IsEmptyElement)
			{
				axis.Title.IsAutoText = true;
				if (chart_0.Type == ChartType.Bar)
				{
					if (string_2 == "catAx")
					{
						axis.Title.RotationAngle = 90;
					}
					else if (string_2 == "valAx")
					{
						axis.Title.RotationAngle = 0;
					}
				}
				method_42(xmlTextReader_0, axis.Title, bool_1: false);
			}
			else if (xmlTextReader_0.LocalName == "majorGridlines")
			{
				Line majorGridLines = axis.MajorGridLines;
				if (!method_19(xmlTextReader_0, axis.method_31()))
				{
					majorGridLines.method_27(Enum229.const_0);
				}
			}
			else if (xmlTextReader_0.LocalName == "minorGridlines")
			{
				Line minorGridLines = axis.MinorGridLines;
				if (!method_19(xmlTextReader_0, axis.method_32()))
				{
					minorGridLines.method_27(Enum229.const_0);
				}
			}
			else if (xmlTextReader_0.LocalName == "numFmt")
			{
				string attribute = xmlTextReader_0.GetAttribute("formatCode");
				if (attribute != null)
				{
					axis.TickLabels.NumberFormat = attribute;
				}
				attribute = xmlTextReader_0.GetAttribute("sourceLinked");
				if (attribute != null)
				{
					axis.TickLabels.NumberFormatLinked = ((!(attribute == "0")) ? true : false);
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "delete")
			{
				string text2 = smethod_0(xmlTextReader_0);
				axis.IsVisible = ((text2 == "0") ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "majorTickMark")
			{
				string text3 = smethod_0(xmlTextReader_0);
				if (text3 != null)
				{
					axis.MajorTickMark = Class1618.smethod_68(text3);
				}
			}
			else if (xmlTextReader_0.LocalName == "minorTickMark")
			{
				string text4 = smethod_0(xmlTextReader_0);
				if (text4 != null)
				{
					axis.MinorTickMark = Class1618.smethod_68(text4);
				}
			}
			else if (xmlTextReader_0.LocalName == "tickLblPos")
			{
				string text5 = smethod_0(xmlTextReader_0);
				if (text5 != null)
				{
					axis.TickLabelPosition = Class1618.smethod_70(text5);
					if (text5 == "none" && Class1618.smethod_126(chart_0.Type) && axis.Type == Enum195.const_0 && chart_0.class1388_0.Count > 0)
					{
						chart_0.class1388_0[0].HasRadarAxisLabels = false;
					}
				}
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, axis.ShapeProperties);
			}
			else if (xmlTextReader_0.LocalName == "txPr")
			{
				Class1570 class3 = method_45(xmlTextReader_0);
				class3.method_9(axis.TickLabels, chart_0, worksheetCollection_0);
			}
			else if (xmlTextReader_0.LocalName == "crossAx")
			{
				@class.string_1 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "crosses")
			{
				@class.string_2 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "crossesAt")
			{
				@class.string_3 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "auto")
			{
				string text6 = smethod_0(xmlTextReader_0);
				if (text6 != null)
				{
					if (text6 == "1")
					{
						axis.CategoryType = CategoryType.AutomaticScale;
					}
					else if (string_2 == "dateAx")
					{
						axis.CategoryType = CategoryType.TimeScale;
					}
					else
					{
						axis.CategoryType = CategoryType.CategoryScale;
					}
					axis.bool_11 = true;
				}
			}
			else if (xmlTextReader_0.LocalName == "lblAlgn")
			{
				string text7 = smethod_0(xmlTextReader_0);
				if (text7 != null)
				{
					axis.TickLabels.TextDirection = Class1618.smethod_73(text7);
				}
			}
			else if (xmlTextReader_0.LocalName == "baseTimeUnit")
			{
				string text8 = smethod_0(xmlTextReader_0);
				if (text8 != null)
				{
					axis.BaseUnitScale = Class1618.smethod_101(text8);
				}
			}
			else if (xmlTextReader_0.LocalName == "majorUnit")
			{
				string text9 = smethod_0(xmlTextReader_0);
				if (text9 != null)
				{
					double num = Class1618.smethod_85(text9);
					if (num != 0.0)
					{
						axis.MajorUnit = num;
					}
				}
			}
			else if (xmlTextReader_0.LocalName == "majorTimeUnit")
			{
				string text10 = smethod_0(xmlTextReader_0);
				if (text10 != null)
				{
					axis.MajorUnitScale = Class1618.smethod_101(text10);
				}
			}
			else if (xmlTextReader_0.LocalName == "minorUnit")
			{
				string text11 = smethod_0(xmlTextReader_0);
				if (text11 != null)
				{
					axis.MinorUnit = Class1618.smethod_85(text11);
				}
			}
			else if (xmlTextReader_0.LocalName == "minorTimeUnit")
			{
				string text12 = smethod_0(xmlTextReader_0);
				if (text12 != null)
				{
					axis.MinorUnitScale = Class1618.smethod_101(text12);
				}
			}
			else if (xmlTextReader_0.LocalName == "lblOffset")
			{
				string text13 = smethod_0(xmlTextReader_0);
				if (text13 != null)
				{
					axis.TickLabels.Offset = Class1618.smethod_87(text13);
				}
			}
			else if (xmlTextReader_0.LocalName == "tickLblSkip")
			{
				string text14 = smethod_0(xmlTextReader_0);
				if (text14 != null)
				{
					axis.TickLabelSpacing = Class1618.smethod_87(text14);
				}
			}
			else if (xmlTextReader_0.LocalName == "tickMarkSkip")
			{
				string text15 = smethod_0(xmlTextReader_0);
				if (text15 != null)
				{
					axis.TickMarkSpacing = Class1618.smethod_87(text15);
				}
			}
			else if (xmlTextReader_0.LocalName == "crossBetween")
			{
				@class.string_4 = smethod_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "dispUnits")
			{
				axis.method_19(bool_15: false);
				method_57(xmlTextReader_0, axis);
			}
			else if (xmlTextReader_0.LocalName == "noMultiLvlLbl")
			{
				axis.HasMultiLevelLabels = smethod_0(xmlTextReader_0) == "0";
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return axis;
	}

	[Attribute0(true)]
	private void method_57(XmlTextReader xmlTextReader_0, Axis axis_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "builtInUnit")
			{
				string string_ = smethod_0(xmlTextReader_0);
				axis_0.DisplayUnit = Class1618.smethod_182(string_);
			}
			else if (xmlTextReader_0.LocalName == "dispUnitsLbl" && !xmlTextReader_0.IsEmptyElement)
			{
				method_58(xmlTextReader_0, axis_0.DisplayUnitLabel);
				axis_0.method_19(bool_15: true);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_58(XmlTextReader xmlTextReader_0, DisplayUnitLabel displayUnitLabel_0)
	{
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "tx")
			{
				method_47(xmlTextReader_0)?.method_11(displayUnitLabel_0, worksheetCollection_0);
			}
			else if (xmlTextReader_0.LocalName == "txPr")
			{
				Class1570 @class = method_45(xmlTextReader_0);
				if (@class.class1542_0 != null)
				{
					@class.method_5(chart_0, bool_3: false);
					displayUnitLabel_0.method_14(Class1618.smethod_119(@class.class1542_0, worksheetCollection_0));
				}
			}
			else if (xmlTextReader_0.LocalName == "layout" && !xmlTextReader_0.IsEmptyElement)
			{
				method_44(xmlTextReader_0)?.method_4(chart_0, displayUnitLabel_0);
			}
			else if (xmlTextReader_0.LocalName == "spPr" && !xmlTextReader_0.IsEmptyElement)
			{
				method_43(xmlTextReader_0, displayUnitLabel_0.ShapeProperties);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_59(XmlTextReader xmlTextReader_0, Axis axis_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "logBase")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					axis_0.IsLogarithmic = true;
					axis_0.LogBase = Class1618.smethod_85(text);
				}
			}
			else if (xmlTextReader_0.LocalName == "orientation")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (text2 == "maxMin")
				{
					axis_0.IsPlotOrderReversed = true;
				}
				else if (text2 == "minMax")
				{
					axis_0.IsPlotOrderReversed = false;
				}
			}
			else if (xmlTextReader_0.LocalName == "max")
			{
				string string_ = smethod_0(xmlTextReader_0);
				axis_0.MaxValue = Class1618.smethod_85(string_);
			}
			else if (xmlTextReader_0.LocalName == "min")
			{
				string string_2 = smethod_0(xmlTextReader_0);
				axis_0.MinValue = Class1618.smethod_85(string_2);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_60(XmlTextReader xmlTextReader_0, Legend legend_0)
	{
		LegendEntry legendEntry = null;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "idx")
			{
				string text = smethod_0(xmlTextReader_0);
				if (text != null)
				{
					int index = Class1618.smethod_87(text);
					legendEntry = legend_0.LegendEntries[index];
				}
			}
			else if (xmlTextReader_0.LocalName == "delete")
			{
				string text2 = smethod_0(xmlTextReader_0);
				if (legendEntry != null && text2 != "0")
				{
					legendEntry.IsDeleted = true;
				}
			}
			else if (xmlTextReader_0.LocalName == "txPr")
			{
				Class1570 @class = method_45(xmlTextReader_0);
				if (@class.class1542_0 != null && legendEntry != null)
				{
					@class.method_5(chart_0, bool_3: false);
					legendEntry.method_2(Class1618.smethod_119(@class.class1542_0, worksheetCollection_0));
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (legendEntry == null)
		{
			method_48("legendEntry");
		}
	}

	private void method_61(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		xmlTextReader_0.MoveToContent();
		string attribute = xmlTextReader_0.GetAttribute("xmlns:c");
		string attribute2 = xmlTextReader_0.GetAttribute("xmlns:a");
		string pattern = "^http://schemas.openxmlformats.org/drawingml/2006/?\\d?/+chart";
		string pattern2 = "^http://schemas.openxmlformats.org/drawingml/2006/?\\d?/+main";
		if (Regex.IsMatch(attribute, pattern) && Regex.IsMatch(attribute2, pattern2))
		{
			XmlNameTable nameTable = xmlTextReader_0.NameTable;
			string_0 = nameTable.Add(attribute);
			string_1 = nameTable.Add(attribute2);
			if (xmlTextReader_0.NodeType != XmlNodeType.Element || !(xmlTextReader_0.LocalName == "chartSpace"))
			{
				throw new CellsException(ExceptionType.InvalidData, "chartSpace root element eror");
			}
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid xml namespace");
	}
}
