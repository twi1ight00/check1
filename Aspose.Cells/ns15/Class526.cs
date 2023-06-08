using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns1;
using ns16;
using ns22;
using ns26;
using ns7;
using ns8;

namespace ns15;

internal class Class526
{
	private Class1489 class1489_0;

	private Hashtable hashtable_0;

	internal Class526(Class1489 class1489_1)
	{
		class1489_0 = class1489_1;
		hashtable_0 = new Hashtable();
	}

	internal void method_0(Worksheet worksheet_0, int int_0, int int_1, Hashtable hashtable_1, XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			Class522 @class = new Class522();
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "href":
					@class.method_1(Class1516.smethod_30(xmlTextReader_0.Value));
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
			Chart chart = method_1(worksheet_0, hashtable_1, @class, int_0, int_1);
			chart.ShowLegend = false;
			Stream stream_ = method_25(@class.method_0() + "/content.xml");
			XmlDocument xmlDocument = Class1188.smethod_2(stream_);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("office:automatic-styles");
			method_12(elementsByTagName);
			XmlNodeList elementsByTagName2 = xmlDocument.GetElementsByTagName("office:body");
			method_2(elementsByTagName2, chart);
		}
		xmlTextReader_0.Skip();
	}

	private Chart method_1(Worksheet worksheet_0, Hashtable hashtable_1, Class522 class522_0, int int_0, int int_1)
	{
		int row = -1;
		int column = -1;
		string text = method_21((string)hashtable_1["end-cell-address"]);
		int num = Class733.smethod_5(hashtable_1["x"].ToString());
		int num2 = Class733.smethod_5(hashtable_1["y"].ToString());
		int num3 = Class733.smethod_5(hashtable_1["width"].ToString());
		int num4 = Class733.smethod_5(hashtable_1["height"].ToString());
		int num5 = -1;
		if (text == null)
		{
			num5 = worksheet_0.Charts.AddFloatingChart(class522_0.method_2(), num, num2, num3, num4);
			Chart chart = worksheet_0.Charts[num5];
			chart.ChartObject.method_20(int_0, num2, int_1, num, num4, num3);
			return chart;
		}
		CellsHelper.CellNameToIndex(text, out row, out column);
		num5 = worksheet_0.Charts.Add(class522_0.method_2(), int_0, int_1, row, column);
		Chart chart2 = worksheet_0.Charts[num5];
		chart2.ChartObject.method_20(int_0, num2, int_1, num, num4, num3);
		return chart2;
	}

	private void method_2(XmlNodeList xmlNodeList_0, Chart chart_0)
	{
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			XmlElement xmlElement = (XmlElement)xmlNodeList_0[i];
			XmlNodeList childNodes = xmlElement.ChildNodes;
			for (int j = 0; j < childNodes.Count; j++)
			{
				object obj = childNodes[j];
				if (!(obj is XmlText))
				{
					XmlElement xmlElement2 = (XmlElement)obj;
					string localName;
					if ((localName = xmlElement2.LocalName) != null && localName == "chart")
					{
						method_3(xmlElement2.ChildNodes, chart_0);
					}
				}
			}
		}
	}

	private void method_3(XmlNodeList xmlNodeList_0, Chart chart_0)
	{
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			object obj = xmlNodeList_0[i];
			if (obj is XmlText)
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)obj;
			string localName;
			if ((localName = xmlElement.LocalName) == null || !(localName == "chart"))
			{
				continue;
			}
			string text = Class1618.smethod_172(xmlElement, "class");
			if (text == "chart:stock")
			{
				break;
			}
			chart_0.Type = method_15(text);
			chart_0.ChartObject.HeightCM = (int)method_29(Class1618.smethod_172(xmlElement, "height"));
			chart_0.ChartObject.WidthCM = (int)method_29(Class1618.smethod_172(xmlElement, "width"));
			string text2 = Class1618.smethod_172(xmlElement, "style-name");
			if (!method_18(text2))
			{
				Class522 @class = (Class522)hashtable_0[text2];
				if (!@class.method_3().IsEmpty)
				{
					chart_0.ChartArea.Area.ForegroundColor = @class.method_3();
				}
				else
				{
					chart_0.ChartArea.Area.ForegroundColor = Color.White;
				}
			}
			method_4(xmlElement.ChildNodes, chart_0);
		}
	}

	private void method_4(XmlNodeList xmlNodeList_0, Chart chart_0)
	{
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			object obj = xmlNodeList_0[i];
			if (obj is XmlText)
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)obj;
			switch (xmlElement.LocalName)
			{
			case "plot-area":
			{
				string text2 = Class1618.smethod_172(xmlElement, "style-name");
				string string_3 = method_19(Class1618.smethod_172(xmlElement, "cell-range-address"));
				string string_4 = Class1618.smethod_172(xmlElement, "data-source-has-labels");
				string string_5 = Class1618.smethod_172(xmlElement, "x");
				if (!method_18(string_5))
				{
					chart_0.PlotArea.X = (int)method_5(chart_0, Class1516.smethod_47(method_29(string_5)));
				}
				string string_6 = Class1618.smethod_172(xmlElement, "y");
				if (!method_18(string_6))
				{
					chart_0.PlotArea.Y = (int)method_6(chart_0, Class1516.smethod_47(method_29(string_6)));
				}
				string string_7 = Class1618.smethod_172(xmlElement, "width");
				chart_0.PlotArea.Width = (int)method_5(chart_0, Class1516.smethod_47(method_29(string_7) - method_29(string_5)));
				string string_8 = Class1618.smethod_172(xmlElement, "height");
				chart_0.PlotArea.Height = (int)method_6(chart_0, Class1516.smethod_47(method_29(string_8) - method_29(string_6)));
				string string_9 = Class1618.smethod_172(xmlElement, "transform");
				chart_0.PlotArea.method_44(string_9);
				if (method_18(text2))
				{
					break;
				}
				Class522 class2 = (Class522)hashtable_0[text2];
				if (class2.Is3D)
				{
					switch (chart_0.Type)
					{
					case ChartType.Column:
						if (class2.IsHorizontal)
						{
							chart_0.Type = ChartType.Bar3DClustered;
						}
						else
						{
							chart_0.Type = ChartType.Column3DClustered;
						}
						break;
					case ChartType.Area:
						chart_0.Type = ChartType.Area3D;
						break;
					case ChartType.Pie:
						chart_0.Type = ChartType.Pie3D;
						break;
					case ChartType.Line:
						chart_0.Type = ChartType.Line3D;
						break;
					}
				}
				chart_0.RightAngleAxes = class2.method_24();
				method_8(xmlElement.ChildNodes, chart_0, class2, string_3, string_4);
				break;
			}
			case "legend":
			{
				string string_10 = Class1618.smethod_172(xmlElement, "legend-position");
				if (!method_18(string_10))
				{
					chart_0.Legend.Position = method_30(string_10);
				}
				string string_11 = Class1618.smethod_172(xmlElement, "x");
				if (!method_18(string_11))
				{
					chart_0.Legend.X = (int)method_5(chart_0, Class1516.smethod_47(method_29(string_11)));
				}
				string string_12 = Class1618.smethod_172(xmlElement, "y");
				if (!method_18(string_12))
				{
					chart_0.Legend.Y = (int)method_6(chart_0, Class1516.smethod_47(method_29(string_12)));
				}
				chart_0.ShowLegend = true;
				break;
			}
			case "title":
			{
				string text = Class1618.smethod_172(xmlElement, "style-name");
				if (!method_18(text))
				{
					Class522 @class = (Class522)hashtable_0[text];
					if (@class != null)
					{
						chart_0.Title.Font.Copy(@class.Font);
					}
					if (@class != null && !method_18(@class.RotationAngle))
					{
						chart_0.Title.RotationAngle = method_26(@class.RotationAngle);
					}
					string string_ = Class1618.smethod_172(xmlElement, "x");
					if (!method_18(string_))
					{
						chart_0.Title.X = (int)method_5(chart_0, Class1516.smethod_47(method_29(string_)));
					}
					string string_2 = Class1618.smethod_172(xmlElement, "y");
					if (!method_18(string_2))
					{
						chart_0.Title.Y = (int)method_6(chart_0, Class1516.smethod_47(method_29(string_2)));
					}
				}
				method_7(xmlElement.ChildNodes, chart_0);
				break;
			}
			}
		}
	}

	private double method_5(Chart chart_0, double double_0)
	{
		return double_0 * 4000.0 / chart_0.ChartObject.WidthInch;
	}

	private double method_6(Chart chart_0, double double_0)
	{
		return double_0 * 4000.0 / chart_0.ChartObject.HeightInch;
	}

	private void method_7(XmlNodeList xmlNodeList_0, Chart chart_0)
	{
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			object obj = xmlNodeList_0[i];
			if (!(obj is XmlText))
			{
				XmlElement xmlElement = (XmlElement)obj;
				string localName;
				if ((localName = xmlElement.LocalName) != null && localName == "p")
				{
					chart_0.Title.string_0 = xmlElement.InnerText;
				}
			}
		}
	}

	private void method_8(XmlNodeList xmlNodeList_0, Chart chart_0, Class522 class522_0, string string_0, string string_1)
	{
		int num = -1;
		bool is3D = class522_0.Is3D;
		string text = null;
		string categoryData = null;
		string[] array = null;
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			object obj = xmlNodeList_0[i];
			if (obj is XmlText)
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)obj;
			string localName;
			if ((localName = xmlElement.LocalName) == null)
			{
				continue;
			}
			if (Class1742.dictionary_4 == null)
			{
				Class1742.dictionary_4 = new Dictionary<string, int>(6)
				{
					{ "coordinate-region", 0 },
					{ "light", 1 },
					{ "axis", 2 },
					{ "series", 3 },
					{ "wall", 4 },
					{ "floor", 5 }
				};
			}
			if (!Class1742.dictionary_4.TryGetValue(localName, out var value))
			{
				continue;
			}
			switch (value)
			{
			case 2:
			{
				Class1618.smethod_172(xmlElement, "dimension");
				string text3 = Class1618.smethod_172(xmlElement, "name");
				string text4 = Class1618.smethod_172(xmlElement, "style-name");
				if (!method_18(text4))
				{
					Class522 class2 = (Class522)hashtable_0[text4];
					if (class2 != null)
					{
						switch (text3)
						{
						case "secondary-y":
							chart_0.SecondValueAxis.AxisLine.Color = class2.method_5();
							chart_0.SecondValueAxis.AxisLine.method_4(class2.method_18());
							chart_0.SecondValueAxis.TickLabels.Font.Size = class2.Font.Size;
							chart_0.SecondValueAxis.TickLabelPosition = class2.method_46();
							if (class2.RotationAngle != null)
							{
								chart_0.SecondValueAxis.TickLabels.RotationAngle = method_27(class2.RotationAngle);
							}
							break;
						case "secondary-x":
							chart_0.SecondCategoryAxis.AxisLine.Color = class2.method_5();
							chart_0.SecondCategoryAxis.AxisLine.method_4(class2.method_18());
							chart_0.SecondCategoryAxis.TickLabels.Font.Size = class2.Font.Size;
							chart_0.SecondCategoryAxis.TickLabelPosition = class2.method_46();
							if (class2.RotationAngle != null)
							{
								chart_0.SecondCategoryAxis.TickLabels.RotationAngle = method_27(class2.RotationAngle);
							}
							break;
						case "primary-y":
							chart_0.ValueAxis.AxisLine.Color = class2.method_5();
							chart_0.ValueAxis.AxisLine.method_4(class2.method_18());
							chart_0.ValueAxis.TickLabels.Font.Size = class2.Font.Size;
							chart_0.ValueAxis.TickLabelPosition = class2.method_46();
							if (class2.RotationAngle != null)
							{
								chart_0.ValueAxis.TickLabels.RotationAngle = method_27(class2.RotationAngle);
							}
							break;
						case "primary-x":
							chart_0.CategoryAxis.AxisLine.Color = class2.method_5();
							chart_0.CategoryAxis.AxisLine.method_4(class2.method_18());
							chart_0.CategoryAxis.TickLabels.Font.Size = class2.Font.Size;
							chart_0.CategoryAxis.TickLabelPosition = class2.method_46();
							if (class2.RotationAngle != null)
							{
								chart_0.CategoryAxis.TickLabels.RotationAngle = method_27(class2.RotationAngle);
							}
							break;
						}
					}
				}
				method_9(xmlElement.ChildNodes, chart_0, text3, out categoryData);
				if (text == null)
				{
					text = categoryData;
				}
				break;
			}
			case 3:
			{
				string key = Class1618.smethod_172(xmlElement, "style-name");
				Class522 class3 = (Class522)hashtable_0[key];
				string text5 = method_19(Class1618.smethod_172(xmlElement, "values-cell-range-address"));
				string string_2 = Class1618.smethod_172(xmlElement, "class");
				string text6 = Class1618.smethod_172(xmlElement, "attached-axis");
				Series series = new Series(class1489_0.workbook_0.Worksheets, chart_0.NSeries, ++num);
				ChartType chartType = chart_0.Type;
				string string_3 = Class1618.smethod_172(xmlElement, "label-cell-address");
				if (!method_18(string_3))
				{
					series.Name = "=" + Class1516.smethod_55(string_3);
				}
				if (chart_0.Type != ChartType.DoughnutExploded)
				{
					chartType = method_16(chart_0, string_2, class522_0, class3, is3D);
				}
				bool flag = text6 == "secondary-y";
				for (int j = 0; j < chart_0.method_18().Count; j++)
				{
					if (chart_0.method_18()[j].method_11() == chartType && flag == chart_0.method_18()[j].PlotOnSecondAxis)
					{
						series.method_29(chart_0.method_18()[j]);
					}
				}
				if (series.method_28() == null)
				{
					Class1387 class4 = new Class1387(chart_0.method_18(), chartType, flag);
					chart_0.method_18().Add(class4);
					series.method_29(class4);
				}
				series.Type = chartType;
				if (class522_0.method_20() != null && !"90".Equals(class522_0.method_20()))
				{
					try
					{
						int num2 = int.Parse(class522_0.method_20());
						num2 = 90 - num2;
						if (num2 < 0)
						{
							num2 += 360;
						}
						series.FirstSliceAngle = (short)num2;
					}
					catch
					{
					}
				}
				series.Values = text5;
				if (text5 == null && string_0 != null)
				{
					if (array == null)
					{
						array = method_23(string_0, string_1);
					}
					series.Values = array[num];
				}
				chart_0.NSeries.method_8(series);
				if (class3 != null && !class3.method_3().IsEmpty)
				{
					series.Area.ForegroundColor = class3.method_3();
				}
				if (class3 != null && !class3.method_5().IsEmpty)
				{
					series.Border.Color = class3.method_5();
				}
				if (class3 != null && class3.method_18() != MsoLineDashStyle.Solid)
				{
					series.Border.method_4(class3.method_18());
				}
				if (class3 != null && class3.method_28() != 0)
				{
					series.Border.WeightPt = class3.method_28();
				}
				if (class3 != null)
				{
					if (class3.method_36() != LabelPositionType.BestFit)
					{
						series.DataLabels.Position = class3.method_36();
					}
					series.DataLabels.method_56(class3.method_44());
					if (class3.method_40())
					{
						series.DataLabels.method_47(bool_16: true);
					}
					if (class3.method_42())
					{
						series.DataLabels.method_45(Enum127.const_5, bool_16: true);
					}
					if (class3.method_38() == "value-and-percentage")
					{
						series.DataLabels.method_45(Enum127.const_1, bool_16: true);
						series.DataLabels.method_45(Enum127.const_2, bool_16: true);
					}
					else if (class3.method_38() == "value")
					{
						series.DataLabels.method_45(Enum127.const_1, bool_16: true);
					}
					else if (class3.method_38() == "percentage")
					{
						series.DataLabels.method_45(Enum127.const_2, bool_16: true);
					}
				}
				method_11(xmlElement.ChildNodes, chart_0, series, class3);
				break;
			}
			case 4:
			{
				string text2 = Class1618.smethod_172(xmlElement, "style-name");
				if (method_18(text2))
				{
					break;
				}
				Class522 @class = (Class522)hashtable_0[text2];
				if (!@class.method_3().IsEmpty && @class.Fill != "none")
				{
					if (chart_0.Is3D)
					{
						chart_0.Walls.ForegroundColor = @class.method_3();
					}
					else
					{
						chart_0.PlotArea.Area.ForegroundColor = @class.method_3();
					}
				}
				else if (chart_0.Is3D)
				{
					chart_0.Walls.ForegroundColor = Color.White;
				}
				else
				{
					chart_0.PlotArea.Area.ForegroundColor = Color.White;
				}
				if (!@class.method_5().IsEmpty)
				{
					if (chart_0.Is3D)
					{
						chart_0.Walls.Border.Color = @class.method_5();
					}
					else
					{
						chart_0.PlotArea.Border.Color = @class.method_5();
					}
				}
				break;
			}
			}
		}
		if (!method_18(text) && !method_22(text))
		{
			chart_0.NSeries.CategoryData = method_19(text);
		}
		chart_0.PlotVisibleCells = false;
	}

	private void method_9(XmlNodeList nodeList, Chart chart, string axisName, out string categoryData)
	{
		categoryData = null;
		for (int i = 0; i < nodeList.Count; i++)
		{
			object obj = nodeList[i];
			if (obj is XmlText)
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)obj;
			switch (xmlElement.LocalName)
			{
			case "categories":
				categoryData = Class1618.smethod_172(xmlElement, "cell-range-address");
				break;
			case "grid":
			{
				Class1618.smethod_172(xmlElement, "class");
				string text = Class1618.smethod_172(xmlElement, "style-name");
				if (!method_18(text))
				{
					Class522 @class = (Class522)hashtable_0[text];
					switch (axisName)
					{
					case "secondary-y":
						chart.SecondValueAxis.MajorGridLines.Color = @class.method_5();
						break;
					case "secondary-x":
						chart.SecondCategoryAxis.MajorGridLines.Color = @class.method_5();
						break;
					case "primary-y":
						chart.ValueAxis.MajorGridLines.Color = @class.method_5();
						break;
					case "primary-x":
						chart.CategoryAxis.MajorGridLines.Color = @class.method_5();
						break;
					}
				}
				break;
			}
			case "title":
			{
				string string_ = Class1618.smethod_172(xmlElement, "style-name");
				method_10(xmlElement.ChildNodes, chart, axisName, string_);
				break;
			}
			}
		}
	}

	private void method_10(XmlNodeList xmlNodeList_0, Chart chart_0, string string_0, string string_1)
	{
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			object obj = xmlNodeList_0[i];
			if (obj is XmlText)
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)obj;
			string localName;
			if ((localName = xmlElement.LocalName) == null || !(localName == "p"))
			{
				continue;
			}
			Class522 @class = (Class522)hashtable_0[string_1];
			if (string_0 == "primary-x")
			{
				chart_0.CategoryAxis.Title.string_0 = xmlElement.InnerText;
				if (@class != null && !method_18(@class.RotationAngle))
				{
					chart_0.CategoryAxis.Title.RotationAngle = method_26(@class.RotationAngle);
				}
			}
			if (string_0 == "primary-y")
			{
				chart_0.ValueAxis.Title.string_0 = xmlElement.InnerText;
				if (@class != null && !method_18(@class.RotationAngle))
				{
					chart_0.ValueAxis.Title.RotationAngle = method_26(@class.RotationAngle);
				}
			}
			if (string_0 == "secondary-x")
			{
				chart_0.SecondCategoryAxis.Title.string_0 = xmlElement.InnerText;
				if (@class != null && !method_18(@class.RotationAngle))
				{
					chart_0.SecondCategoryAxis.Title.RotationAngle = method_26(@class.RotationAngle);
				}
			}
			if (string_0 == "secondary-y")
			{
				chart_0.SecondValueAxis.Title.string_0 = xmlElement.InnerText;
				if (@class != null && !method_18(@class.RotationAngle))
				{
					chart_0.SecondValueAxis.Title.RotationAngle = method_26(@class.RotationAngle);
				}
			}
		}
	}

	private void method_11(XmlNodeList xmlNodeList_0, Chart chart_0, Series series_0, Class522 class522_0)
	{
		int num = 0;
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			object obj = xmlNodeList_0[i];
			if (obj is XmlText)
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)obj;
			switch (xmlElement.LocalName)
			{
			case "data-point":
			{
				string text = Class1618.smethod_172(xmlElement, "style-name");
				string text2 = Class1618.smethod_172(xmlElement, "repeated");
				string text3 = class522_0.method_15();
				if (text3 == "none")
				{
					series_0.Points[num].Border.IsVisible = false;
				}
				if (method_18(text2) && method_18(text))
				{
					if (chart_0.Type != ChartType.Scatter && chart_0.Type != ChartType.Line && chart_0.Type != ChartType.LineStacked && chart_0.Type != ChartType.Line100PercentStacked)
					{
						if (!class522_0.method_3().IsEmpty)
						{
							series_0.Points[num].Area.ForegroundColor = class522_0.method_3();
						}
					}
					else
					{
						if (!class522_0.method_5().IsEmpty)
						{
							series_0.Marker.MarkerForegroundColor = class522_0.method_5();
						}
						if (!class522_0.method_3().IsEmpty)
						{
							series_0.Marker.MarkerBackgroundColor = class522_0.method_3();
						}
						if (class522_0.method_13() != ChartMarkerType.None)
						{
							series_0.Marker.MarkerStyle = class522_0.method_13();
						}
						if (class522_0.method_32() != 0.0)
						{
							series_0.Marker.MarkerSize = (int)Class1516.smethod_46(class1489_0.workbook_0.Worksheets, class522_0.method_32());
						}
						if (class522_0.method_34() != 0.0)
						{
							series_0.Marker.Area.Transparency = 1.0 - class522_0.method_34();
						}
					}
					num++;
				}
				else if (!method_18(text2) && method_18(text))
				{
					if (chart_0.Type != ChartType.Scatter && chart_0.Type != ChartType.Line && chart_0.Type != ChartType.LineStacked && chart_0.Type != ChartType.Line100PercentStacked)
					{
						for (int j = 0; j < int.Parse(text2); j++)
						{
							if (class522_0 != null && !class522_0.method_3().IsEmpty)
							{
								series_0.Points[num].Area.ForegroundColor = class522_0.method_3();
							}
							num++;
						}
						break;
					}
					for (int k = 0; k < int.Parse(text2); k++)
					{
						if (!class522_0.method_5().IsEmpty)
						{
							series_0.Marker.MarkerForegroundColor = class522_0.method_5();
						}
						if (!class522_0.method_3().IsEmpty)
						{
							series_0.Marker.MarkerBackgroundColor = class522_0.method_3();
						}
						if (class522_0.method_13() != ChartMarkerType.None)
						{
							series_0.Marker.MarkerStyle = class522_0.method_13();
						}
						if (class522_0.method_32() != 0.0)
						{
							series_0.Marker.MarkerSize = (int)Class1516.smethod_46(class1489_0.workbook_0.Worksheets, class522_0.method_32());
						}
						if (class522_0.method_34() != 0.0)
						{
							series_0.Marker.Area.Transparency = 1.0 - class522_0.method_34();
						}
						num++;
					}
				}
				else if (method_18(text2) && !method_18(text))
				{
					Class522 @class = (Class522)hashtable_0[text];
					if (chart_0.Type != ChartType.Scatter && chart_0.Type != ChartType.Line && chart_0.Type != ChartType.LineStacked && chart_0.Type != ChartType.Line100PercentStacked)
					{
						if (!class522_0.method_3().IsEmpty)
						{
							if (@class.method_3().IsEmpty)
							{
								series_0.Points[num].Area.ForegroundColor = class522_0.method_3();
							}
							else
							{
								series_0.Points[num].Area.ForegroundColor = @class.method_3();
							}
						}
					}
					else
					{
						if (!class522_0.method_5().IsEmpty)
						{
							series_0.Marker.MarkerForegroundColor = class522_0.method_5();
						}
						if (!class522_0.method_3().IsEmpty)
						{
							series_0.Marker.MarkerBackgroundColor = class522_0.method_3();
						}
						if (class522_0.method_13() != ChartMarkerType.None)
						{
							series_0.Marker.MarkerStyle = class522_0.method_13();
						}
						if (class522_0.method_32() != 0.0)
						{
							series_0.Marker.MarkerSize = (int)Class1516.smethod_46(class1489_0.workbook_0.Worksheets, class522_0.method_32());
						}
						if (class522_0.method_34() != 0.0)
						{
							series_0.Marker.Area.Transparency = 1.0 - class522_0.method_34();
						}
					}
					if (!method_18(@class.method_11()))
					{
						series_0.Points[num].Explosion = int.Parse(@class.method_11());
					}
					num++;
				}
				else if (!method_18(text2) && !method_18(text))
				{
					Class522 class2 = (Class522)hashtable_0[text];
					if (chart_0.Type != ChartType.Scatter && chart_0.Type != ChartType.Line && chart_0.Type != ChartType.LineStacked && chart_0.Type != ChartType.Line100PercentStacked)
					{
						for (int l = 0; l < int.Parse(text2); l++)
						{
							if (!class522_0.method_3().IsEmpty)
							{
								series_0.Points[num].Area.ForegroundColor = class2.method_3();
							}
							num++;
						}
					}
					else
					{
						for (int m = 0; m < int.Parse(text2); m++)
						{
							if (!class522_0.method_5().IsEmpty)
							{
								series_0.Marker.MarkerForegroundColor = class522_0.method_5();
							}
							if (!class522_0.method_3().IsEmpty)
							{
								series_0.Marker.MarkerBackgroundColor = class522_0.method_3();
							}
							if (class522_0.method_13() != ChartMarkerType.None)
							{
								series_0.Marker.MarkerStyle = class522_0.method_13();
							}
							if (class522_0.method_32() != 0.0)
							{
								series_0.Marker.MarkerSize = (int)Class1516.smethod_46(class1489_0.workbook_0.Worksheets, class522_0.method_32());
							}
							if (class522_0.method_34() != 0.0)
							{
								series_0.Marker.Area.Transparency = 1.0 - class522_0.method_34();
							}
							num++;
						}
					}
					if (!method_18(class2.method_11()))
					{
						series_0.Points[num].Explosion = int.Parse(class2.method_11());
					}
				}
				else
				{
					num++;
				}
				break;
			}
			default:
				num++;
				break;
			case "domain":
				break;
			}
		}
	}

	private void method_12(XmlNodeList xmlNodeList_0)
	{
		hashtable_0.Clear();
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			XmlElement xmlElement = (XmlElement)xmlNodeList_0[i];
			XmlNodeList childNodes = xmlElement.ChildNodes;
			for (int j = 0; j < childNodes.Count; j++)
			{
				object obj = childNodes[j];
				if (!(obj is XmlText))
				{
					XmlElement xmlElement2 = (XmlElement)obj;
					switch (xmlElement2.LocalName)
					{
					case "style":
					{
						string key = Class1618.smethod_172(xmlElement2, "name");
						Class1618.smethod_172(xmlElement2, "family");
						Class522 value = method_13(xmlElement2.ChildNodes);
						hashtable_0.Add(key, value);
						break;
					}
					}
				}
			}
		}
	}

	private Class522 method_13(XmlNodeList xmlNodeList_0)
	{
		Class522 @class = new Class522();
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			object obj = xmlNodeList_0[i];
			if (obj is XmlText)
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)obj;
			switch (xmlElement.LocalName)
			{
			case "chart-properties":
			{
				string text7 = Class1618.smethod_172(xmlElement, "vertical");
				if (!method_18(text7))
				{
					@class.IsHorizontal = bool.Parse(text7);
				}
				string text8 = Class1618.smethod_172(xmlElement, "stacked");
				if (!method_18(text8))
				{
					@class.method_8(bool.Parse(text8));
				}
				string text9 = Class1618.smethod_172(xmlElement, "percentage");
				if (!method_18(text9))
				{
					@class.method_10(bool.Parse(text9));
				}
				string text10 = Class1618.smethod_172(xmlElement, "deep");
				if (!method_18(text10))
				{
					@class.method_31(bool.Parse(text10));
				}
				string text11 = Class1618.smethod_172(xmlElement, "pie-offset");
				if (!method_18(text11))
				{
					@class.method_12(text11);
				}
				Class1618.smethod_172(xmlElement, "symbol-type");
				string string_6 = Class1618.smethod_172(xmlElement, "symbol-name");
				if (!method_18(string_6))
				{
					@class.method_14(method_24(string_6));
				}
				string text12 = Class1618.smethod_172(xmlElement, "symbol-width");
				Class1618.smethod_172(xmlElement, "symbol-height");
				if (!method_18(text12) && text12.EndsWith("cm"))
				{
					text12 = text12.Substring(0, text12.Length - 2);
					@class.method_33(Class1618.smethod_85(text12));
				}
				string text13 = Class1618.smethod_172(xmlElement, "rotation-angle");
				if (!method_18(text13))
				{
					@class.RotationAngle = text13;
				}
				string text14 = Class1618.smethod_172(xmlElement, "angle-offset");
				if (!method_18(text14))
				{
					@class.method_21(text14);
				}
				string text15 = Class1618.smethod_172(xmlElement, "three-dimensional");
				if (!method_18(text15))
				{
					@class.method_23(bool.Parse(text15));
				}
				string text16 = Class1618.smethod_172(xmlElement, "right-angled-axes");
				if (!method_18(text16))
				{
					@class.method_25(bool.Parse(text16));
				}
				string string_7 = Class1618.smethod_172(xmlElement, "solid-type");
				if (!method_18(string_7))
				{
					@class.method_27(method_14(string_7));
				}
				string string_8 = Class1618.smethod_172(xmlElement, "label-position");
				if (!method_18(string_8))
				{
					@class.method_37(Class1516.smethod_53(string_8));
				}
				string string_9 = Class1618.smethod_172(xmlElement, "axis-label-position");
				if (!method_18(string_9))
				{
					@class.method_47(Class1516.smethod_54(string_9));
				}
				string text17 = Class1618.smethod_172(xmlElement, "data-label-number");
				if (!method_18(text17))
				{
					@class.method_39(text17);
				}
				string text18 = Class1618.smethod_172(xmlElement, "data-label-text");
				if (!method_18(text18))
				{
					@class.method_41((text18 == "true") ? true : false);
				}
				string text19 = Class1618.smethod_172(xmlElement, "data-label-symbol");
				if (!method_18(text19))
				{
					@class.method_43((text19 == "true") ? true : false);
				}
				if (xmlElement.ChildNodes.Count != 1)
				{
					break;
				}
				XmlNodeList childNodes = xmlElement.ChildNodes;
				XmlNode xmlNode = childNodes[0];
				if (xmlNode != null && xmlNode.LocalName == "label-separator")
				{
					string innerText = xmlNode.InnerText;
					if (!method_18(innerText))
					{
						@class.method_45(Class1618.smethod_109(innerText));
					}
				}
				break;
			}
			case "text-properties":
			{
				@class.method_22(class1489_0.workbook_0.Worksheets);
				string string_4 = Class1618.smethod_172(xmlElement, "font-size");
				if (!method_18(string_4))
				{
					@class.Font.Size = (int)method_29(string_4);
				}
				string string_5 = Class1618.smethod_172(xmlElement, "color");
				if (!method_18(string_5))
				{
					@class.Font.Color = Class732.smethod_10(string_5);
				}
				string text5 = Class1618.smethod_172(xmlElement, "font-family");
				if (!method_18(text5))
				{
					@class.Font.Name = text5;
				}
				string text6 = Class1618.smethod_172(xmlElement, "font-weight");
				if (!method_18(text6))
				{
					@class.Font.IsBold = ((text6.ToLower() == "bold") ? true : false);
				}
				break;
			}
			case "graphic-properties":
			{
				string text = Class1618.smethod_172(xmlElement, "fill");
				if (!method_18(text))
				{
					@class.method_17(text);
				}
				string string_ = Class1618.smethod_172(xmlElement, "fill-color");
				if (!method_18(string_))
				{
					@class.method_4(Class732.smethod_10(string_));
				}
				string text2 = Class1618.smethod_172(xmlElement, "stroke");
				if (!method_18(text2))
				{
					@class.method_16(text2);
				}
				string string_2 = Class1618.smethod_172(xmlElement, "stroke-dash");
				if (!method_18(string_2))
				{
					@class.method_19(method_28(string_2));
				}
				string string_3 = Class1618.smethod_172(xmlElement, "stroke-color");
				if (!method_18(string_3))
				{
					@class.method_6(Class732.smethod_10(string_3));
				}
				string text3 = Class1618.smethod_172(xmlElement, "stroke-width");
				if (!method_18(text3))
				{
					double double_ = double.Parse(text3.Substring(0, text3.Length - 2));
					@class.method_29((int)Class1516.smethod_45(class1489_0.workbook_0.Worksheets, double_));
				}
				Class1618.smethod_172(xmlElement, "stroke-opacity");
				Class1618.smethod_172(xmlElement, "edge-rounding");
				string text4 = Class1618.smethod_172(xmlElement, "opacity");
				if (!method_18(text4) && text4.EndsWith("%"))
				{
					@class.method_35(Class1618.smethod_85(text4.Substring(0, text4.Length - 1)) / 100.0);
				}
				break;
			}
			}
		}
		return @class;
	}

	private Bar3DShapeType method_14(string string_0)
	{
		return string_0 switch
		{
			"cone" => Bar3DShapeType.ConeToPoint, 
			"pyramid" => Bar3DShapeType.PyramidToPoint, 
			"cylinder" => Bar3DShapeType.Cylinder, 
			_ => Bar3DShapeType.Box, 
		};
	}

	private ChartType method_15(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_5 == null)
			{
				Class1742.dictionary_5 = new Dictionary<string, int>(8)
				{
					{ "chart:area", 0 },
					{ "chart:line", 1 },
					{ "chart:bar", 2 },
					{ "chart:circle", 3 },
					{ "chart:ring", 4 },
					{ "chart:scatter", 5 },
					{ "chart:radar", 6 },
					{ "chart:stock", 7 }
				};
			}
			if (Class1742.dictionary_5.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return ChartType.Area;
				case 1:
					return ChartType.Line;
				case 2:
					return ChartType.Column;
				case 3:
					return ChartType.Pie;
				case 4:
					return ChartType.Doughnut;
				case 5:
					return ChartType.Scatter;
				case 6:
					return ChartType.Radar;
				case 7:
					return ChartType.StockHighLowClose;
				}
			}
		}
		return ChartType.Column;
	}

	private ChartType method_16(Chart chart_0, string string_0, Class522 class522_0, Class522 class522_1, bool bool_0)
	{
		ChartType type;
		if (string_0 != null && !(string_0 == ""))
		{
			type = chart_0.Type;
			string text = string_0.ToLower();
			string key;
			if ((key = text) != null)
			{
				if (Class1742.dictionary_6 == null)
				{
					Class1742.dictionary_6 = new Dictionary<string, int>(9)
					{
						{ "chart:area", 0 },
						{ "chart:line", 1 },
						{ "chart:bar", 2 },
						{ "chart:circle", 3 },
						{ "chart:ring", 4 },
						{ "chart:scatter", 5 },
						{ "chart:radar", 6 },
						{ "chart:stock", 7 },
						{ "chart:bubble", 8 }
					};
				}
				if (Class1742.dictionary_6.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						break;
					case 1:
						goto IL_0132;
					case 2:
						goto IL_0166;
					case 3:
						goto IL_01c6;
					case 4:
						goto IL_0219;
					case 5:
						goto IL_0230;
					case 6:
						goto IL_0235;
					case 7:
						goto IL_023a;
					case 8:
						goto IL_023f;
					default:
						goto IL_024d;
					}
					if (bool_0)
					{
						type = ChartType.Area3D;
						if (class522_0.method_7())
						{
							type = ChartType.Area3DStacked;
						}
						if (class522_0.method_9())
						{
							type = ChartType.Area3D100PercentStacked;
						}
					}
					else
					{
						type = ChartType.Area;
						if (class522_0.method_7())
						{
							type = ChartType.AreaStacked;
						}
						if (class522_0.method_9())
						{
							type = ChartType.Area100PercentStacked;
						}
					}
					goto IL_0250;
				}
			}
			goto IL_024d;
		}
		return chart_0.Type;
		IL_0230:
		type = ChartType.Scatter;
		goto IL_0250;
		IL_0219:
		type = ChartType.Doughnut;
		if (!method_18(class522_1.method_11()))
		{
			type = ChartType.DoughnutExploded;
		}
		goto IL_0250;
		IL_0250:
		return type;
		IL_0235:
		type = ChartType.Radar;
		goto IL_0250;
		IL_01c6:
		if (chart_0.Type == ChartType.Doughnut)
		{
			type = ChartType.Doughnut;
			if (!method_18(class522_1.method_11()))
			{
				type = ChartType.DoughnutExploded;
			}
		}
		else if (bool_0)
		{
			type = ChartType.Pie3D;
			if (!method_18(class522_1.method_11()))
			{
				type = ChartType.Pie3DExploded;
			}
		}
		else
		{
			type = ChartType.Pie;
			if (!method_18(class522_1.method_11()))
			{
				type = ChartType.PieExploded;
			}
		}
		goto IL_0250;
		IL_0132:
		type = (class522_0.method_7() ? ChartType.LineStacked : (class522_0.method_9() ? ChartType.Line100PercentStacked : ((!bool_0) ? ChartType.Line : ChartType.Line3D)));
		goto IL_0250;
		IL_023f:
		type = ((!bool_0) ? ChartType.Bubble : ChartType.Bubble3D);
		goto IL_0250;
		IL_024d:
		type = ChartType.Column;
		goto IL_0250;
		IL_0166:
		if (bool_0)
		{
			type = method_17(class522_0, class522_1, chart_0.Type);
		}
		else if (class522_0.IsHorizontal)
		{
			type = ChartType.Bar;
			if (class522_0.method_7())
			{
				type = ChartType.BarStacked;
			}
			if (class522_0.method_9())
			{
				type = ChartType.Bar100PercentStacked;
			}
		}
		else
		{
			type = ChartType.Column;
			if (class522_0.method_7())
			{
				type = ChartType.ColumnStacked;
			}
			if (class522_0.method_9())
			{
				type = ChartType.Column100PercentStacked;
			}
		}
		goto IL_0250;
		IL_023a:
		type = ChartType.StockHighLowClose;
		goto IL_0250;
	}

	private ChartType method_17(Class522 class522_0, Class522 class522_1, ChartType chartType_0)
	{
		ChartType result = chartType_0;
		switch (class522_1.method_26())
		{
		case Bar3DShapeType.Box:
			if (class522_1.IsHorizontal)
			{
				result = ChartType.Bar3DClustered;
				if (class522_1.method_7())
				{
					result = ChartType.Bar3DStacked;
				}
				if (class522_1.method_9())
				{
					result = ChartType.Bar3D100PercentStacked;
				}
				break;
			}
			result = ChartType.Column3DClustered;
			if (class522_1.method_30())
			{
				result = ChartType.Column3D;
			}
			if (class522_1.method_7())
			{
				result = ChartType.Column3DStacked;
			}
			if (class522_1.method_9())
			{
				result = ChartType.Column3D100PercentStacked;
			}
			break;
		case Bar3DShapeType.PyramidToPoint:
			if (class522_1.IsHorizontal)
			{
				result = ChartType.PyramidBar;
				if (class522_1.method_7())
				{
					result = ChartType.PyramidBarStacked;
				}
				if (class522_1.method_9())
				{
					result = ChartType.PyramidBar100PercentStacked;
				}
				break;
			}
			result = ChartType.Pyramid;
			if (class522_1.method_30())
			{
				result = ChartType.PyramidColumn3D;
			}
			if (class522_1.method_7())
			{
				result = ChartType.PyramidStacked;
			}
			if (class522_1.method_9())
			{
				result = ChartType.Pyramid100PercentStacked;
			}
			break;
		case Bar3DShapeType.Cylinder:
			if (class522_1.IsHorizontal)
			{
				result = ChartType.CylindricalBar;
				if (class522_1.method_7())
				{
					result = ChartType.CylindricalBarStacked;
				}
				if (class522_1.method_9())
				{
					result = ChartType.CylindricalBar100PercentStacked;
				}
				break;
			}
			result = ChartType.Cylinder;
			if (class522_1.method_30())
			{
				result = ChartType.CylindricalColumn3D;
			}
			if (class522_1.method_7())
			{
				result = ChartType.CylinderStacked;
			}
			if (class522_1.method_9())
			{
				result = ChartType.Cylinder100PercentStacked;
			}
			break;
		case Bar3DShapeType.ConeToPoint:
			if (class522_1.IsHorizontal)
			{
				result = ChartType.ConicalBar;
				if (class522_1.method_7())
				{
					result = ChartType.ConicalBarStacked;
				}
				if (class522_1.method_9())
				{
					result = ChartType.ConicalBar100PercentStacked;
				}
				break;
			}
			result = ChartType.Cone;
			if (class522_1.method_30())
			{
				result = ChartType.ConicalColumn3D;
			}
			if (class522_1.method_7())
			{
				result = ChartType.ConeStacked;
			}
			if (class522_1.method_9())
			{
				result = ChartType.Cone100PercentStacked;
			}
			break;
		}
		return result;
	}

	private bool method_18(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			return false;
		}
		return true;
	}

	private string method_19(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			if (string_0.IndexOf(":") < 0)
			{
				string_0 = string_0.Replace(".", "!");
				return string_0 + ":" + string_0.Split('!')[1];
			}
			string[] array = null;
			array = ((string_0.IndexOf(" '") > -1) ? Regex.Split(string_0, " '") : ((string_0.IndexOf(":") != string_0.LastIndexOf(":")) ? string_0.Split(' ') : new string[1] { string_0 }));
			StringBuilder stringBuilder = new StringBuilder();
			string value = "";
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(value);
				stringBuilder.Append(method_20(array[i]));
				value = ",";
			}
			return stringBuilder.Replace("'", "").ToString();
		}
		return string_0;
	}

	private string method_20(string string_0)
	{
		string[] array = string_0.Split(':');
		string text = array[0];
		string text2 = array[1];
		int num = text.IndexOf(".");
		text2 = ((num != text2.IndexOf(".")) ? text2.Substring(1) : text2.Substring(text2.LastIndexOf(".") + 1));
		StringBuilder stringBuilder = new StringBuilder(text.Replace(".", "!").Replace("$", ""));
		stringBuilder.Append(":");
		stringBuilder.Append(text2.Replace("$", ""));
		return stringBuilder.ToString();
	}

	private string method_21(string string_0)
	{
		return string_0?.Substring(string_0.LastIndexOf(".") + 1);
	}

	private bool method_22(string string_0)
	{
		bool flag = false;
		for (int i = 0; i < class1489_0.workbook_0.Worksheets.Count; i++)
		{
			if (class1489_0.workbook_0.Worksheets[i].Name.IndexOf("local-table") > -1)
			{
				flag = true;
				break;
			}
		}
		if (string_0.IndexOf("local-table") > -1)
		{
			return !flag;
		}
		return false;
	}

	private string[] method_23(string string_0, string string_1)
	{
		string[] array = null;
		if (!method_18(string_0))
		{
			int num = string_0.IndexOf("!");
			int num2 = string_0.IndexOf(":");
			string text = string_0.Substring(0, num + 1);
			string cellName = string_0.Substring(num + 1, num2 - num - 1);
			string cellName2 = string_0.Substring(num2 + 1);
			int row = -1;
			int column = -1;
			int row2 = -1;
			int column2 = -1;
			CellsHelper.CellNameToIndex(cellName, out row, out column);
			CellsHelper.CellNameToIndex(cellName2, out row2, out column2);
			switch (string_1)
			{
			case "row":
				row++;
				break;
			case "column":
				column++;
				break;
			case "both":
				row++;
				column++;
				break;
			}
			array = new string[row2 - row + 1];
			for (int i = 0; i < row2 - row + 1; i++)
			{
				array[i] = text + CellsHelper.CellIndexToName(row + i, column) + ":" + CellsHelper.CellIndexToName(row + i, column2);
			}
		}
		return array;
	}

	private ChartMarkerType method_24(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_7 == null)
			{
				Class1742.dictionary_7 = new Dictionary<string, int>(11)
				{
					{ "square", 0 },
					{ "circle", 1 },
					{ "diamond", 2 },
					{ "arrow-up", 3 },
					{ "arrow-down", 4 },
					{ "arrow-right", 5 },
					{ "arrow-left", 6 },
					{ "plus", 7 },
					{ "star", 8 },
					{ "hourglass", 9 },
					{ "bow-tie", 10 }
				};
			}
			if (Class1742.dictionary_7.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return ChartMarkerType.Square;
				case 1:
					return ChartMarkerType.Circle;
				case 2:
					return ChartMarkerType.Diamond;
				case 3:
					return ChartMarkerType.Triangle;
				case 4:
					return ChartMarkerType.Dot;
				case 5:
					return ChartMarkerType.Dash;
				case 6:
				case 7:
					return ChartMarkerType.SquarePlus;
				case 8:
					return ChartMarkerType.SquareStar;
				case 9:
				case 10:
					return ChartMarkerType.SquareX;
				}
			}
		}
		return ChartMarkerType.Automatic;
	}

	private Stream method_25(string string_0)
	{
		Class746 class746_ = class1489_0.class746_0;
		Class744 @class = class746_.method_38(string_0);
		if (@class == null)
		{
			return null;
		}
		return class746_.method_39(@class);
	}

	private int method_26(string string_0)
	{
		int num = int.Parse(string_0);
		if (num > 90 && num < 270)
		{
			return 180 - num;
		}
		if (num >= 270)
		{
			return 360 - num;
		}
		return num;
	}

	private int method_27(string string_0)
	{
		int num = Class1618.smethod_87(string_0);
		if (num > 90 && num <= 270)
		{
			return 180 - num;
		}
		if (num > 270)
		{
			return 360 - num;
		}
		return num;
	}

	private MsoLineDashStyle method_28(string string_0)
	{
		return string_0 switch
		{
			"_33__20_Dashes_20_3_20_Dots_20__28_var_29_" => MsoLineDashStyle.DashLongDashDot, 
			"_32__20_Dots_20_1_20_Dash" => MsoLineDashStyle.DashDotDot, 
			"Ultrafine_20_2_20_Dots_20_3_20_Dashes" => MsoLineDashStyle.DashLongDash, 
			"Ultrafine_20_Dashed" => MsoLineDashStyle.Dash, 
			"Fine_20_Dotted" => MsoLineDashStyle.DashDot, 
			_ => MsoLineDashStyle.Solid, 
		};
	}

	private double method_29(string string_0)
	{
		if (!string_0.EndsWith("pt") && !string_0.EndsWith("cm"))
		{
			return double.Parse(string_0);
		}
		return double.Parse(string_0.Substring(0, string_0.Length - 2));
	}

	private LegendPositionType method_30(string string_0)
	{
		return string_0 switch
		{
			"top-end" => LegendPositionType.Corner, 
			"start" => LegendPositionType.Left, 
			"bottom" => LegendPositionType.Bottom, 
			"top" => LegendPositionType.Top, 
			_ => LegendPositionType.Right, 
		};
	}
}
