using System;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns16;
using ns26;
using ns3;
using ns44;
using ns7;

namespace ns15;

internal class Class525
{
	private Stream6 stream6_0;

	private ChartShape chartShape_0;

	private Chart chart_0;

	private double double_0;

	private double double_1;

	private ChartType chartType_0;

	private bool bool_0;

	private double[][] double_2;

	private Hashtable hashtable_0;

	private int int_0;

	private XmlTextWriter xmlTextWriter_0;

	private string string_0;

	private Interface7 interface7_0;

	private string string_1 = "#878787";

	private string string_2 = "#ffffff";

	private string string_3 = "Chart";

	private string string_4 = "ChartTitle";

	private string string_5 = "CategoryAxisTitle";

	private string string_6 = "ValueAxisTitle";

	private string string_7 = "SecondCategoryAxisTitle";

	private string string_8 = "secondValueAxisTitle";

	private string string_9 = "SeriesAxisTitle";

	private string string_10 = "ChartLegend";

	private string string_11 = "PlotArea";

	private string string_12 = "ValueAxis";

	private string string_13 = "CategoryAxis";

	private string string_14 = "SeriesAxis";

	private string string_15 = "SecondValueAxis";

	private string string_16 = "SecondCategoryAxis";

	private string string_17 = "MajorGridLines_ValueAxis";

	private string string_18 = "MinorGridLines_ValueAxis";

	private string string_19 = "MajorGridLines_CategoryAxis";

	private string string_20 = "MinorGridLines_CategoryAxis";

	private string string_21 = "MajorGridLines_SecondValueAxis";

	private string string_22 = "MinorGridLines_SecondValueAxis";

	private string string_23 = "MajorGridLines_SecondCategoryAxis";

	private string string_24 = "MinorGridLines_SecondCategoryAxis";

	private string string_25 = "Series";

	private string string_26 = "Point";

	private string string_27 = "Walls";

	private string string_28 = "Floor";

	private string string_29;

	private string string_30;

	private string string_31;

	public Class525(Stream6 stream6_1, ChartShape chartShape_1, string string_32)
	{
		double_2 = new double[6][];
		stream6_0 = stream6_1;
		chartShape_0 = chartShape_1;
		chart_0 = chartShape_0.Chart;
		interface7_0 = Class870.smethod_0(chart_0);
		hashtable_0 = new Hashtable();
		string_0 = string_32;
	}

	public void Write()
	{
		method_1();
		chart_0.method_26(bool_9: false);
	}

	private void method_0()
	{
		double_0 = chartShape_0.WidthInch;
		double_1 = chartShape_0.HeightInch;
		chartType_0 = chart_0.Type;
		bool_0 = chart_0.Is3D;
		chart_0.Calculate(bool_9: false, bool_10: false);
	}

	private void method_1()
	{
		method_0();
		xmlTextWriter_0 = Class1522.smethod_1("Object " + string_0 + "/content.xml", stream6_0);
		xmlTextWriter_0.WriteStartDocument();
		xmlTextWriter_0.WriteStartElement("office:document-content");
		method_2();
		method_3();
		method_34();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	private void method_2()
	{
		xmlTextWriter_0.WriteAttributeString("xmlns", "office", null, "urn:oasis:names:tc:opendocument:xmlns:office:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "style", null, "urn:oasis:names:tc:opendocument:xmlns:style:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "text", null, "urn:oasis:names:tc:opendocument:xmlns:text:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "table", null, "urn:oasis:names:tc:opendocument:xmlns:table:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "draw", null, "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "fo", null, "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xlink", null, "http://www.w3.org/1999/xlink");
		xmlTextWriter_0.WriteAttributeString("xmlns", "dc", null, "http://purl.org/dc/elements/1.1/");
		xmlTextWriter_0.WriteAttributeString("xmlns", "meta", null, "urn:oasis:names:tc:opendocument:xmlns:meta:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "number", null, "urn:oasis:names:tc:opendocument:xmlns:datastyle:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "svg", null, "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "chart", null, "urn:oasis:names:tc:opendocument:xmlns:chart:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "dr3d", null, "urn:oasis:names:tc:opendocument:xmlns:dr3d:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "math", null, "http://www.w3.org/1998/Math/MathML");
		xmlTextWriter_0.WriteAttributeString("xmlns", "form", null, "urn:oasis:names:tc:opendocument:xmlns:form:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "script", null, "urn:oasis:names:tc:opendocument:xmlns:script:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "ooo", null, "http://openoffice.org/2004/office");
		xmlTextWriter_0.WriteAttributeString("xmlns", "ooow", null, "http://openoffice.org/2004/writer");
		xmlTextWriter_0.WriteAttributeString("xmlns", "oooc", null, "http://openoffice.org/2004/calc");
		xmlTextWriter_0.WriteAttributeString("xmlns", "dom", null, "http://www.w3.org/2001/xml-events");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xforms", null, "http://www.w3.org/2002/xforms");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
		xmlTextWriter_0.WriteAttributeString("xmlns", "rpt", null, "http://openoffice.org/2005/report");
		xmlTextWriter_0.WriteAttributeString("xmlns", "of", null, "urn:oasis:names:tc:opendocument:xmlns:of:1.2");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xhtml", null, "http://www.w3.org/1999/xhtml");
		xmlTextWriter_0.WriteAttributeString("xmlns", "grddl", null, "http://www.w3.org/2003/g/data-view#");
		xmlTextWriter_0.WriteAttributeString("xmlns", "tableooo", null, "http://openoffice.org/2009/table");
		xmlTextWriter_0.WriteAttributeString("xmlns", "chartooo", null, "http://openoffice.org/2010/chart");
		xmlTextWriter_0.WriteAttributeString("xmlns", "field", null, "urn:openoffice:names:experimental:ooo-ms-interop:xmlns:field:1.0");
		xmlTextWriter_0.WriteAttributeString("office", "version", null, "1.2");
	}

	private void method_3()
	{
		xmlTextWriter_0.WriteStartElement("office:automatic-styles");
		string_29 = method_18(chart_0.CategoryAxis.TickLabels);
		string_30 = method_18(chart_0.ValueAxis.TickLabels);
		if (chart_0.Is3D)
		{
			string_31 = method_18(chart_0.SeriesAxis.TickLabels);
		}
		method_4();
		method_5(chart_0.Title, string_4);
		method_6();
		method_7();
		method_14();
		method_8();
		method_12();
		method_13();
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_4()
	{
		Color foregroundColor = chart_0.ChartArea.Area.ForegroundColor;
		Line border = chart_0.ChartArea.Border;
		_ = chart_0.ChartArea.Area.FillFormat.Type;
		xmlTextWriter_0.WriteStartElement("style:style");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, Class523.string_0 + ++int_0);
		xmlTextWriter_0.WriteAttributeString("style", "family", null, "chart");
		method_21(foregroundColor, border, chart_0.ChartArea.Area.FillFormat);
		xmlTextWriter_0.WriteEndElement();
		hashtable_0.Add(string_3, Class523.string_0 + int_0);
	}

	private void method_5(Title title_0, string string_32)
	{
		if (method_37(title_0))
		{
			Aspose.Cells.Font font = title_0.Font;
			Line border = title_0.Border;
			Color foregroundColor = title_0.Area.ForegroundColor;
			xmlTextWriter_0.WriteStartElement("style:style");
			xmlTextWriter_0.WriteAttributeString("style", "name", null, Class523.string_0 + ++int_0);
			xmlTextWriter_0.WriteAttributeString("style", "family", null, "chart");
			method_21(foregroundColor, border, title_0.Area.FillFormat);
			method_24(font);
			xmlTextWriter_0.WriteEndElement();
			hashtable_0.Add(string_32, Class523.string_0 + int_0);
		}
	}

	private void method_6()
	{
		if (chart_0.ShowLegend)
		{
			Legend legend = chart_0.Legend;
			Color foregroundColor = legend.Area.ForegroundColor;
			Line border = legend.Border;
			Aspose.Cells.Font font = legend.Font;
			xmlTextWriter_0.WriteStartElement("style:style");
			xmlTextWriter_0.WriteAttributeString("style", "name", null, Class523.string_0 + ++int_0);
			xmlTextWriter_0.WriteAttributeString("style", "family", null, "chart");
			if (chart_0.Legend.method_17())
			{
				xmlTextWriter_0.WriteStartElement("style:chart-properties");
				xmlTextWriter_0.WriteAttributeString("chart", "auto-position", null, "true");
				xmlTextWriter_0.WriteEndElement();
			}
			method_21(foregroundColor, border, legend.Area.FillFormat);
			method_24(font);
			xmlTextWriter_0.WriteEndElement();
			hashtable_0.Add(string_10, Class523.string_0 + int_0);
		}
	}

	private void method_7()
	{
		ChartFrame plotArea = chart_0.PlotArea;
		xmlTextWriter_0.WriteStartElement("style:style");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, Class523.string_0 + ++int_0);
		xmlTextWriter_0.WriteAttributeString("style", "family", null, "chart");
		method_25();
		method_21(chart_0.PlotArea.Area.ForegroundColor, chart_0.PlotArea.Border, plotArea.Area.FillFormat);
		xmlTextWriter_0.WriteEndElement();
		hashtable_0.Add(string_11, Class523.string_0 + int_0);
	}

	private void method_8()
	{
		if (interface7_0 == null)
		{
			return;
		}
		int count = interface7_0.NSeries.Count;
		for (int i = 0; i < count; i++)
		{
			Series series = chart_0.NSeries[i];
			xmlTextWriter_0.WriteStartElement("style:style");
			xmlTextWriter_0.WriteAttributeString("style", "name", null, Class523.string_0 + ++int_0);
			xmlTextWriter_0.WriteAttributeString("style", "family", null, "chart");
			xmlTextWriter_0.WriteStartElement("style:chart-properties");
			if (series.FirstSliceAngle != 0)
			{
				xmlTextWriter_0.WriteAttributeString("chart", "angle-offset", null, series.FirstSliceAngle.ToString());
			}
			if (series.Explosion != 0)
			{
				xmlTextWriter_0.WriteAttributeString("chart", "pie-offset", null, series.Explosion.ToString());
			}
			string text = method_11(series.Bar3DShapeType);
			if (text != null)
			{
				xmlTextWriter_0.WriteAttributeString("chart", "solid-type", null, text);
			}
			string text2 = Class1516.smethod_40(series.Marker.MarkerStyle, series.Index);
			if (text2 != "automatic")
			{
				xmlTextWriter_0.WriteAttributeString("chart", "symbol-name", null, text2);
			}
			if (series.Marker.MarkerStyle != ChartMarkerType.None && series.Marker.MarkerStyle != 0)
			{
				xmlTextWriter_0.WriteAttributeString("chart", "symbol-type", null, "named-symbol");
				xmlTextWriter_0.WriteAttributeString("chart", "symbol-width", null, Class1516.smethod_41(series.Marker.MarkerSize) + "cm");
				xmlTextWriter_0.WriteAttributeString("chart", "symbol-height", null, Class1516.smethod_41(series.Marker.MarkerSize) + "cm");
			}
			if (series.DataLabels.ShowValue && series.DataLabels.ShowPercentage)
			{
				xmlTextWriter_0.WriteAttributeString("chart", "data-label-number", null, "value-and-percentage");
			}
			else if (series.DataLabels.ShowValue)
			{
				xmlTextWriter_0.WriteAttributeString("chart", "data-label-number", null, "value");
			}
			else if (series.DataLabels.ShowPercentage)
			{
				xmlTextWriter_0.WriteAttributeString("chart", "data-label-number", null, "percentage");
			}
			if (!series.DataLabels.bool_15 && series.DataLabels.Position != LabelPositionType.Moved)
			{
				string text3 = Class1618.smethod_98(series.DataLabels.Position, series.method_28().method_11());
				if (text3 != null)
				{
					xmlTextWriter_0.WriteAttributeString("chart", "label-position", null, text3);
				}
			}
			if (series.DataLabels.method_58() && series.DataLabels.method_57() != 0)
			{
				string text4 = Class1618.smethod_108(series.DataLabels.method_57());
				xmlTextWriter_0.WriteStartElement("chart:label-separator");
				xmlTextWriter_0.WriteStartElement("text:p");
				xmlTextWriter_0.WriteString(text4);
				xmlTextWriter_0.WriteEndElement();
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
			Interface28 @interface = null;
			if (series.IsVisible)
			{
				@interface = interface7_0.NSeries[i];
			}
			if (@interface == null)
			{
				method_21(series.Area.ForegroundColor, series.Border, series.Area.FillFormat);
			}
			else
			{
				method_21(@interface.Area.ForegroundColor, series.Border, series.Area.FillFormat);
			}
			xmlTextWriter_0.WriteEndElement();
			hashtable_0.Add(string_25 + i, Class523.string_0 + int_0);
			method_9(series, i);
		}
	}

	private void method_9(Series series_0, int int_1)
	{
		ChartPointCollection points = series_0.Points;
		if (points == null || points.Count < 1)
		{
			return;
		}
		ChartPoint chartPoint_ = null;
		int count = points.Count;
		for (int i = 0; i < count; i++)
		{
			ChartPoint chartPoint = points[i];
			if (method_54(chartPoint_, chartPoint))
			{
				xmlTextWriter_0.WriteStartElement("style:style");
				xmlTextWriter_0.WriteAttributeString("style", "name", null, Class523.string_0 + ++int_0);
				xmlTextWriter_0.WriteAttributeString("style", "family", null, "chart");
				if (chartPoint.Explosion != 0)
				{
					method_10(chartPoint);
				}
				method_21(chartPoint.Area.ForegroundColor, chartPoint.Border, chartPoint.Area.FillFormat);
				xmlTextWriter_0.WriteEndElement();
				hashtable_0.Add(string_26 + int_1 + i, Class523.string_0 + int_0);
			}
			chartPoint_ = chartPoint;
		}
	}

	private void method_10(ChartPoint chartPoint_0)
	{
		xmlTextWriter_0.WriteStartElement("style:chart-properties");
		xmlTextWriter_0.WriteAttributeString("chart", "pie-offset", null, Class1618.smethod_80(chartPoint_0.Explosion));
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_11(Bar3DShapeType bar3DShapeType_0)
	{
		switch (bar3DShapeType_0)
		{
		default:
			return null;
		case Bar3DShapeType.PyramidToPoint:
		case Bar3DShapeType.PyramidToMax:
			return "pyramid";
		case Bar3DShapeType.Cylinder:
			return "cylinder";
		case Bar3DShapeType.ConeToPoint:
		case Bar3DShapeType.ConeToMax:
			return "cone";
		}
	}

	private void method_12()
	{
		if (chart_0.Walls != null)
		{
			xmlTextWriter_0.WriteStartElement("style:style");
			xmlTextWriter_0.WriteAttributeString("style", "name", null, Class523.string_0 + ++int_0);
			xmlTextWriter_0.WriteAttributeString("style", "family", null, "chart");
			method_21(chart_0.Walls.ForegroundColor, chart_0.Walls.Border, chart_0.Walls.FillFormat);
			xmlTextWriter_0.WriteEndElement();
			hashtable_0.Add(string_27, Class523.string_0 + int_0);
		}
	}

	private void method_13()
	{
		if (chart_0.Floor != null)
		{
			xmlTextWriter_0.WriteStartElement("style:style");
			xmlTextWriter_0.WriteAttributeString("style", "name", null, Class523.string_0 + ++int_0);
			xmlTextWriter_0.WriteAttributeString("style", "family", null, "chart");
			method_21(chart_0.Floor.ForegroundColor, chart_0.Floor.Border, chart_0.Floor.FillFormat);
			xmlTextWriter_0.WriteEndElement();
			hashtable_0.Add(string_28, Class523.string_0 + int_0);
		}
	}

	private void method_14()
	{
		Axis categoryAxis = chart_0.CategoryAxis;
		Axis valueAxis = chart_0.ValueAxis;
		Axis seriesAxis = chart_0.SeriesAxis;
		Axis secondCategoryAxis = chart_0.SecondCategoryAxis;
		Axis secondValueAxis = chart_0.SecondValueAxis;
		if (categoryAxis.IsVisible)
		{
			method_15(categoryAxis, string_13);
			if (categoryAxis.MinorGridLines.method_26() != Enum229.const_2)
			{
				method_17(categoryAxis.MinorGridLines, string_20, bool_1: true);
			}
			if (categoryAxis.MajorGridLines.method_26() != Enum229.const_2)
			{
				method_17(categoryAxis.MajorGridLines, string_19, bool_1: true);
			}
			method_5(categoryAxis.Title, string_5);
		}
		if (valueAxis.IsVisible || Class1516.smethod_37(chartType_0))
		{
			method_16(valueAxis, string_12);
			if (valueAxis.MinorGridLines.method_26() != Enum229.const_2)
			{
				method_17(valueAxis.MinorGridLines, string_18, bool_1: true);
			}
			if (valueAxis.MajorGridLines.method_26() != Enum229.const_2)
			{
				method_17(valueAxis.MajorGridLines, string_17, bool_1: true);
			}
			method_5(valueAxis.Title, string_6);
		}
		if (seriesAxis.IsVisible)
		{
			method_16(seriesAxis, string_14);
			if (seriesAxis.MinorGridLines.method_26() != Enum229.const_2)
			{
				method_17(seriesAxis.MinorGridLines, string_18, bool_1: true);
			}
			if (seriesAxis.MajorGridLines.method_26() != Enum229.const_2)
			{
				method_17(seriesAxis.MajorGridLines, string_17, bool_1: true);
			}
			method_5(seriesAxis.Title, string_9);
		}
		if (secondCategoryAxis.IsVisible)
		{
			method_15(secondCategoryAxis, string_16);
			if (secondCategoryAxis.MinorGridLines.method_26() != Enum229.const_2)
			{
				method_17(secondCategoryAxis.MinorGridLines, string_24, bool_1: true);
			}
			if (secondCategoryAxis.MajorGridLines.method_26() != Enum229.const_2)
			{
				method_17(secondCategoryAxis.MajorGridLines, string_23, bool_1: true);
			}
			method_5(secondCategoryAxis.Title, string_7);
		}
		if (secondValueAxis.IsVisible)
		{
			method_16(secondValueAxis, string_15);
			if (secondValueAxis.MinorGridLines.method_26() != Enum229.const_2)
			{
				method_17(secondValueAxis.MinorGridLines, string_22, bool_1: true);
			}
			if (secondValueAxis.MajorGridLines.method_26() != Enum229.const_2)
			{
				method_17(secondValueAxis.MajorGridLines, string_21, bool_1: true);
			}
			method_5(secondValueAxis.Title, string_8);
		}
	}

	private void method_15(Axis axis_0, string string_32)
	{
		xmlTextWriter_0.WriteStartElement("style:style");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, Class523.string_0 + ++int_0);
		xmlTextWriter_0.WriteAttributeString("style", "family", null, "chart");
		xmlTextWriter_0.WriteAttributeString("style", "data-style-name", null, string_29);
		method_27(axis_0);
		method_21(axis_0.Area.ForegroundColor, axis_0.AxisLine, axis_0.Area.FillFormat);
		method_24(axis_0.TickLabels.Font);
		xmlTextWriter_0.WriteEndElement();
		hashtable_0.Add(string_32, Class523.string_0 + int_0);
	}

	private void method_16(Axis axis_0, string string_32)
	{
		xmlTextWriter_0.WriteStartElement("style:style");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, Class523.string_0 + ++int_0);
		xmlTextWriter_0.WriteAttributeString("style", "family", null, "chart");
		xmlTextWriter_0.WriteAttributeString("style", "data-style-name", null, string_30);
		method_26(axis_0);
		method_21(axis_0.Area.ForegroundColor, axis_0.AxisLine, axis_0.Area.FillFormat);
		method_24(axis_0.TickLabels.Font);
		xmlTextWriter_0.WriteEndElement();
		hashtable_0.Add(string_32, Class523.string_0 + int_0);
	}

	private void method_17(Line line_0, string string_32, bool bool_1)
	{
		xmlTextWriter_0.WriteStartElement("style:style");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, Class523.string_0 + ++int_0);
		xmlTextWriter_0.WriteAttributeString("style", "family", null, "chart");
		method_22(line_0.Color, line_0, null, bool_1);
		xmlTextWriter_0.WriteEndElement();
		hashtable_0.Add(string_32, Class523.string_0 + int_0);
	}

	private string method_18(TickLabels tickLabels_0)
	{
		string numberFormat = tickLabels_0.NumberFormat;
		if (numberFormat == null)
		{
			return null;
		}
		int int_ = tickLabels_0.method_6();
		ArrayList arrayList = method_19(int_, numberFormat);
		string text = null;
		foreach (Class1502 item in arrayList)
		{
			xmlTextWriter_0.WriteStartElement("number:" + Class1516.smethod_51(item.enum214_0) + "-style");
			xmlTextWriter_0.WriteAttributeString("style", "name", null, item.string_0);
			if (text == null)
			{
				text = item.string_0;
			}
			foreach (Class1506 item2 in item.arrayList_1)
			{
				string text2 = item2.string_0;
				ArrayList arrayList_ = item2.arrayList_0;
				Enum213 enum213_ = item2.enum213_0;
				xmlTextWriter_0.WriteStartElement("number:" + Class1516.smethod_52(enum213_));
				foreach (string[] item3 in arrayList_)
				{
					xmlTextWriter_0.WriteAttributeString("number", item3[0], null, item3[1]);
				}
				if (text2 != null)
				{
					xmlTextWriter_0.WriteString(text2);
				}
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		return text;
	}

	private ArrayList method_19(int int_1, string string_32)
	{
		ArrayList arrayList = new ArrayList();
		if (Class1516.smethod_0(string_32) && int_1 > 0)
		{
			string_32 = Class1682.smethod_0(int_1);
		}
		if (!Class1516.smethod_0(string_32))
		{
			if (string_32.IndexOf("General") != -1)
			{
				method_20(int_1, arrayList);
				return arrayList;
			}
			string[] array = Class1516.smethod_19(string_32);
			if (array.Length > 1)
			{
				Class1502 @class = null;
				for (int i = 0; i < array.Length; i++)
				{
					string text = ((i == array.Length - 1) ? ("N" + int_1) : ("N" + int_1 + "P" + i));
					@class = new Class1502();
					@class.method_0(text, int_1, array[i]);
					if (i != array.Length - 1)
					{
						@class.arrayList_0.Add(new string[2] { "style:volatile", "true" });
					}
					arrayList.Add(@class);
				}
				@class.method_2(array.Length);
			}
			else
			{
				Class1502 class2 = new Class1502();
				class2.method_0("N" + int_1, int_1, string_32);
				arrayList.Add(class2);
			}
		}
		else if (int_1 > 0)
		{
			Class1502 class3 = new Class1502();
			class3.method_1(int_1);
			arrayList.Add(class3);
		}
		return arrayList;
	}

	private void method_20(int int_1, ArrayList arrayList_0)
	{
		Class1502 @class = new Class1502();
		arrayList_0.Add(@class);
		@class.string_0 = "N" + int_1;
		@class.enum214_0 = Enum214.const_1;
		Class1506 class2 = new Class1506(Enum213.const_4, null);
		@class.arrayList_1.Add(class2);
		class2.arrayList_0.Add(new string[2] { "min-integer-digits", "1" });
	}

	private void method_21(Color color_0, Line line_0, FillFormat fillFormat_0)
	{
		xmlTextWriter_0.WriteStartElement("style:graphic-properties");
		xmlTextWriter_0.WriteAttributeString("draw", "stroke", null, method_63(line_0, bool_1: false));
		double weightPt = line_0.WeightPt;
		if (weightPt != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("svg", "stroke-width", null, Class1516.smethod_44(chart_0.method_14(), weightPt) + "cm");
		}
		if (line_0.IsVisible && line_0.Color.Name != null && !line_0.Color.IsEmpty)
		{
			xmlTextWriter_0.WriteAttributeString("svg", "stroke-color", null, method_23(line_0.Color));
		}
		if (!color_0.IsEmpty)
		{
			xmlTextWriter_0.WriteAttributeString("draw", "fill-color", null, method_23(color_0));
		}
		if (fillFormat_0 != null)
		{
			if (fillFormat_0.Type != 0 && !color_0.IsEmpty)
			{
				xmlTextWriter_0.WriteAttributeString("draw", "fill", null, Class1515.smethod_7(fillFormat_0.Type));
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("draw", "fill", null, "none");
			}
		}
		double transparency = line_0.Transparency;
		if (transparency != 0.0)
		{
			string value = (1.0 - transparency) * 100.0 + "%";
			xmlTextWriter_0.WriteAttributeString("draw", "stroke-opacity", null, value);
			xmlTextWriter_0.WriteAttributeString("draw", "opacity", null, value);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_22(Color color_0, Line line_0, FillFormat fillFormat_0, bool bool_1)
	{
		xmlTextWriter_0.WriteStartElement("style:graphic-properties");
		xmlTextWriter_0.WriteAttributeString("draw", "stroke", null, method_63(line_0, bool_1));
		double weightPt = line_0.WeightPt;
		if (weightPt != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("svg", "stroke-width", null, Class1516.smethod_44(chart_0.method_14(), weightPt) + "cm");
		}
		if (line_0.IsVisible && line_0.Color.Name != null && !line_0.Color.IsEmpty)
		{
			xmlTextWriter_0.WriteAttributeString("svg", "stroke-color", null, method_23(line_0.Color));
		}
		if (!color_0.IsEmpty)
		{
			xmlTextWriter_0.WriteAttributeString("draw", "fill-color", null, method_23(color_0));
		}
		if (fillFormat_0 != null)
		{
			xmlTextWriter_0.WriteAttributeString("draw", "fill", null, Class1515.smethod_7(fillFormat_0.Type));
		}
		double transparency = line_0.Transparency;
		if (transparency != 0.0)
		{
			string value = (1.0 - transparency) * 100.0 + "%";
			xmlTextWriter_0.WriteAttributeString("draw", "stroke-opacity", null, value);
			xmlTextWriter_0.WriteAttributeString("draw", "opacity", null, value);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_23(Color color_0)
	{
		string value = Convert.ToString(color_0.R, 16).PadLeft(2, '0');
		string value2 = Convert.ToString(color_0.G, 16).PadLeft(2, '0');
		string value3 = Convert.ToString(color_0.B, 16).PadLeft(2, '0');
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("#");
		stringBuilder.Append(value);
		stringBuilder.Append(value2);
		stringBuilder.Append(value3);
		return stringBuilder.ToString();
	}

	private void method_24(Aspose.Cells.Font font_0)
	{
		xmlTextWriter_0.WriteStartElement("style:text-properties");
		xmlTextWriter_0.WriteAttributeString("fo", "color", null, method_23(font_0.Color));
		xmlTextWriter_0.WriteAttributeString("fo", "font-family", null, font_0.Name);
		if (font_0.IsBold)
		{
			xmlTextWriter_0.WriteAttributeString("fo", "font-weight", null, "bold");
			xmlTextWriter_0.WriteAttributeString("style", "font-weight-asian", null, "bold");
			xmlTextWriter_0.WriteAttributeString("style", "font-weight-complex", null, "bold");
		}
		if (font_0.IsItalic)
		{
			xmlTextWriter_0.WriteAttributeString("fo", "font-style", null, "italic");
			xmlTextWriter_0.WriteAttributeString("fo", "font-style-asian", null, "italic");
			xmlTextWriter_0.WriteAttributeString("fo", "font-style-complex", null, "italic");
		}
		if (font_0.Underline == FontUnderlineType.Single)
		{
			xmlTextWriter_0.WriteAttributeString("fo", "text-underline-style", null, "solid");
			xmlTextWriter_0.WriteAttributeString("fo", "text-underline-width", null, "auto");
		}
		string value = font_0.Size + "pt";
		xmlTextWriter_0.WriteAttributeString("fo", "font-size", null, value);
		xmlTextWriter_0.WriteAttributeString("style", "font-size-asian", null, value);
		xmlTextWriter_0.WriteAttributeString("style", "font-size-complex", null, value);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_25()
	{
		xmlTextWriter_0.WriteStartElement("style:chart-properties");
		if (chart_0.Type == ChartType.CylindricalColumn3D || chart_0.Type == ChartType.Column3D || chart_0.Type == ChartType.PyramidColumn3D)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "deep", null, "true");
		}
		if (Class1516.smethod_39(chartType_0))
		{
			xmlTextWriter_0.WriteAttributeString("chart", "interpolation", null, "cubic-spline");
		}
		if (Class1516.smethod_38(chartType_0))
		{
			xmlTextWriter_0.WriteAttributeString("chart", "solid-type", null, "cylinder");
		}
		if (Class1516.smethod_35(chartType_0))
		{
			xmlTextWriter_0.WriteAttributeString("chart", "vertical", null, "true");
			xmlTextWriter_0.WriteAttributeString("chart", "connect-bars", null, "false");
		}
		if (Class1516.smethod_36(chartType_0))
		{
			xmlTextWriter_0.WriteAttributeString("chart", "percentage", null, "true");
		}
		else if (Class1516.smethod_34(chartType_0))
		{
			xmlTextWriter_0.WriteAttributeString("chart", "stacked", null, "true");
		}
		xmlTextWriter_0.WriteAttributeString("chart", "treat-empty-cells", null, "leave-gap");
		xmlTextWriter_0.WriteAttributeString("chart", "include-hidden-cells", null, "false");
		if (chart_0.Is3D)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "three-dimensional", null, "true");
			xmlTextWriter_0.WriteAttributeString("chart", "right-angled-axes", null, chart_0.RightAngleAxes.ToString().ToLower());
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_26(Axis axis_0)
	{
		xmlTextWriter_0.WriteStartElement("style:chart-properties");
		if (Class1516.smethod_37(chart_0.Type))
		{
			xmlTextWriter_0.WriteAttributeString("chart", "reverse-direction", null, axis_0.IsPlotOrderReversed ? "false" : "true");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("chart", "reverse-direction", null, axis_0.IsPlotOrderReversed ? "true" : "false");
		}
		method_28(axis_0);
		method_30(chart_0.CategoryAxis);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_27(Axis axis_0)
	{
		xmlTextWriter_0.WriteStartElement("style:chart-properties");
		xmlTextWriter_0.WriteAttributeString("chart", "reverse-direction", null, axis_0.IsPlotOrderReversed ? "true" : "false");
		method_28(axis_0);
		method_30(chart_0.ValueAxis);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_28(Axis axis_0)
	{
		xmlTextWriter_0.WriteAttributeString("chart", "logarithmic", null, axis_0.IsLogarithmic ? "true" : "false");
		xmlTextWriter_0.WriteAttributeString("chart", "line-break", null, "false");
		xmlTextWriter_0.WriteAttributeString("chart", "text-overlap", null, "true");
		if (!axis_0.IsVisible)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "visible", null, "false");
		}
		method_29(axis_0);
		method_33(axis_0);
		method_32(axis_0);
		method_31(axis_0);
	}

	private void method_29(Axis axis_0)
	{
		if (!axis_0.IsAutomaticMajorUnit)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "interval-major", null, axis_0.MajorUnit.ToString());
		}
		if (!axis_0.IsAutomaticMinorUnit)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "interval-minor-divisor", null, ((int)(axis_0.MajorUnit / axis_0.MinorUnit + 0.5)).ToString());
		}
		if (!axis_0.IsAutomaticMaxValue)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "maximum", null, axis_0.MaxValue.ToString());
		}
		if (!axis_0.IsAutomaticMinValue)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "minimum", null, axis_0.MinValue.ToString());
		}
	}

	private void method_30(Axis axis_0)
	{
		switch (axis_0.CrossType)
		{
		case CrossType.Maximum:
			xmlTextWriter_0.WriteAttributeString("chart", "axis-position", null, "end");
			break;
		case CrossType.Automatic:
		case CrossType.Custom:
			xmlTextWriter_0.WriteAttributeString("chart", "axis-position", null, axis_0.CrossAt.ToString());
			break;
		}
	}

	private void method_31(Axis axis_0)
	{
		_ = axis_0.TickMarkSpacing;
	}

	private void method_32(Axis axis_0)
	{
		switch (axis_0.TickLabelPosition)
		{
		case TickLabelPositionType.High:
			xmlTextWriter_0.WriteAttributeString("chart", "axis-label-position", null, "outside-start");
			xmlTextWriter_0.WriteAttributeString("chart", "display-label", null, "true");
			break;
		case TickLabelPositionType.Low:
			xmlTextWriter_0.WriteAttributeString("chart", "axis-label-position", null, "outside-end");
			xmlTextWriter_0.WriteAttributeString("chart", "display-label", null, "true");
			break;
		default:
			xmlTextWriter_0.WriteAttributeString("chart", "display-label", null, "true");
			break;
		case TickLabelPositionType.None:
			xmlTextWriter_0.WriteAttributeString("chart", "display-label", null, "false");
			break;
		}
		xmlTextWriter_0.WriteAttributeString("style", "rotation-angle", null, Class1618.smethod_80(axis_0.TickLabels.RotationAngle));
	}

	private void method_33(Axis axis_0)
	{
		switch (axis_0.MinorTickMark)
		{
		case TickMarkType.Inside:
			xmlTextWriter_0.WriteAttributeString("chart", "tick-marks-minor-inner", null, "true");
			break;
		case TickMarkType.Outside:
			xmlTextWriter_0.WriteAttributeString("chart", "tick-marks-minor-outer", null, "true");
			break;
		}
		switch (axis_0.MajorTickMark)
		{
		case TickMarkType.Inside:
			xmlTextWriter_0.WriteAttributeString("chart", "tick-marks-major-inner", null, "true");
			break;
		case TickMarkType.Outside:
			xmlTextWriter_0.WriteAttributeString("chart", "tick-marks-major-outer", null, "true");
			break;
		case TickMarkType.Cross:
		case TickMarkType.None:
			break;
		}
	}

	private void method_34()
	{
		xmlTextWriter_0.WriteStartElement("office:body");
		xmlTextWriter_0.WriteStartElement("office:chart");
		method_35();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_35()
	{
		xmlTextWriter_0.WriteStartElement("chart:chart");
		xmlTextWriter_0.WriteAttributeString("svg", "width", null, Class1516.smethod_49(chartShape_0.WidthCM) + "cm");
		xmlTextWriter_0.WriteAttributeString("svg", "height", null, Class1516.smethod_49(chartShape_0.HeightCM) + "cm");
		xmlTextWriter_0.WriteAttributeString("chart", "class", null, method_62(chartShape_0.Chart.Type));
		xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_3]);
		method_36(chart_0.Title, string_4);
		method_38();
		method_39();
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_36(Title title_0, string string_32)
	{
		if (method_37(title_0))
		{
			xmlTextWriter_0.WriteStartElement("chart:title");
			xmlTextWriter_0.WriteAttributeString("svg", "x", null, Class1516.smethod_49(method_65(title_0.X)) + "in");
			xmlTextWriter_0.WriteAttributeString("svg", "y", null, Class1516.smethod_49(method_66(title_0.Y)) + "in");
			xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_32]);
			xmlTextWriter_0.WriteStartElement("text:p");
			xmlTextWriter_0.WriteString(title_0.Text);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private bool method_37(Title title_0)
	{
		if (title_0 != null && title_0.Text != null && !title_0.IsDeleted && !(title_0.Text == ""))
		{
			return true;
		}
		return false;
	}

	private void method_38()
	{
		if (!chart_0.ShowLegend)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("chart:legend");
		try
		{
			if (chart_0.Legend != null)
			{
				if (chart_0.Legend.Position != LegendPositionType.NotDocked)
				{
					xmlTextWriter_0.WriteAttributeString("chart", "legend-position", null, method_64(chart_0.Legend.Position));
				}
				xmlTextWriter_0.WriteAttributeString("svg", "x", null, Class1516.smethod_49(method_65(chart_0.Legend.X)) + "in");
				xmlTextWriter_0.WriteAttributeString("svg", "y", null, Class1516.smethod_49(method_66(chart_0.Legend.Y)) + "in");
				xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_10]);
				if (chart_0.Legend.Width > 0)
				{
					xmlTextWriter_0.WriteAttributeString("chartooo", "width", null, Class1516.smethod_49(chart_0.ChartObject.WidthCM * (double)chart_0.Legend.Width / 4000.0) + "cm");
				}
				if (chart_0.Legend.Height > 0)
				{
					xmlTextWriter_0.WriteAttributeString("chartooo", "height", null, Class1516.smethod_49(chart_0.ChartObject.HeightCM * (double)chart_0.Legend.Height / 4000.0) + "cm");
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			chart_0.method_26(bool_9: false);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_39()
	{
		xmlTextWriter_0.WriteStartElement("chart:plot-area");
		string text = smethod_0(chart_0);
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("table", "cell-range-address", null, text);
		}
		if (chart_0.PlotArea != null || chart_0.ChartArea != null)
		{
			method_40();
		}
		if (bool_0)
		{
			string text2 = chart_0.PlotArea.method_43();
			if (text2 != null)
			{
				xmlTextWriter_0.WriteAttributeString("dr3d", "transform", null, text2);
				if (Class1516.smethod_37(chartType_0))
				{
					xmlTextWriter_0.WriteAttributeString("dr3d", "vrp", null, method_59());
					xmlTextWriter_0.WriteAttributeString("dr3d", "vpn", null, method_60());
					xmlTextWriter_0.WriteAttributeString("dr3d", "vup", null, method_61());
				}
				xmlTextWriter_0.WriteAttributeString("dr3d", "ambient-color", null, "#cccccc");
				xmlTextWriter_0.WriteAttributeString("dr3d", "shade-mode", null, "flat");
				xmlTextWriter_0.WriteAttributeString("dr3d", "shadow-slant", null, "0");
				xmlTextWriter_0.WriteAttributeString("dr3d", "projection", null, "perspective");
			}
		}
		xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_11]);
		method_41();
		method_46();
		method_48();
		if (method_49(chartType_0))
		{
			foreach (Class1387 item in chart_0.method_18())
			{
				if (item.HasUpDownBars)
				{
					method_57(bool_1: true, item.UpBars);
					method_57(bool_1: false, item.DownBars);
				}
				if (item.HasHiLoLines)
				{
					method_58(item.HiLoLines);
				}
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_40()
	{
		if (chart_0.PlotArea != null)
		{
			double num = method_65(chart_0.PlotArea.X);
			double num2 = method_67(chart_0.PlotArea.Width);
			double num3 = 0.0;
			if (double_2[1] != null)
			{
				num3 += Math.Abs(double_2[1][0]) * 2.0;
				num -= num3;
			}
			if (double_2[3] != null)
			{
				num3 += Math.Abs(double_2[3][0]) * 2.0;
			}
			if (num < 0.0)
			{
				num = 0.0;
			}
			xmlTextWriter_0.WriteAttributeString("svg", "x", null, Class1516.smethod_49(Class1516.smethod_48(num)) + "cm");
			num2 += num3;
			if (num2 > double_0)
			{
				num2 = double_0;
			}
			xmlTextWriter_0.WriteAttributeString("svg", "width", null, Class1516.smethod_49(Class1516.smethod_48(num2)) + "cm");
			num = method_66(chart_0.PlotArea.Y);
			num2 = method_68(chart_0.PlotArea.Height);
			num3 = 0.0;
			if (double_2[2] != null)
			{
				num3 += Math.Abs(double_2[2][1]) * 2.0;
				num -= num3;
			}
			if (double_2[0] != null)
			{
				num3 += Math.Abs(double_2[0][1]) * 2.0;
			}
			if (num < 0.0)
			{
				num = 0.0;
			}
			xmlTextWriter_0.WriteAttributeString("svg", "y", null, Class1516.smethod_49(Class1516.smethod_48(num)) + "cm");
			num2 += num3;
			if (num2 > double_1)
			{
				num2 = double_1;
			}
			xmlTextWriter_0.WriteAttributeString("svg", "height", null, Class1516.smethod_49(Class1516.smethod_48(num2)) + "cm");
		}
	}

	private void method_41()
	{
		switch (chartType_0)
		{
		case ChartType.Doughnut:
		case ChartType.DoughnutExploded:
		case ChartType.Pie:
		case ChartType.Pie3D:
		case ChartType.PiePie:
		case ChartType.PieExploded:
		case ChartType.Pie3DExploded:
		case ChartType.PieBar:
			method_42();
			method_43();
			return;
		}
		method_44(chart_0.CategoryAxis, "primary-x");
		method_44(chart_0.ValueAxis, "primary-y");
		method_44(chart_0.SeriesAxis, "primary-z");
		method_44(chart_0.SecondCategoryAxis, "secondary-x");
		method_44(chart_0.SecondValueAxis, "secondary-y");
	}

	private void method_42()
	{
		if (chart_0.NSeries.Count < 1 || !chart_0.CategoryAxis.IsVisible)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("chart:axis");
		xmlTextWriter_0.WriteAttributeString("chart", "dimension", null, "x");
		xmlTextWriter_0.WriteAttributeString("chart", "name", null, "primary-x");
		xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_13]);
		if (chart_0.NSeries.Count > 0)
		{
			string xValues = chart_0.NSeries[0].XValues;
			if (xValues != null && xValues != "")
			{
				xmlTextWriter_0.WriteStartElement("chart:categories");
				xmlTextWriter_0.WriteAttributeString("table", "cell-range-address", null, smethod_3(xValues));
				xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_13]);
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_43()
	{
		xmlTextWriter_0.WriteStartElement("chart:axis");
		xmlTextWriter_0.WriteAttributeString("chart", "dimension", null, "y");
		xmlTextWriter_0.WriteAttributeString("chart", "name", null, "primary-y");
		xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_12]);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_44(Axis axis_0, string string_32)
	{
		if (!axis_0.IsVisible)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("chart:axis");
		xmlTextWriter_0.WriteAttributeString("chart", "name", null, string_32);
		if (axis_0.Type == Enum195.const_1)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "dimension", null, "y");
			xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_12]);
		}
		else if (axis_0.Type == Enum195.const_0)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "dimension", null, "x");
			xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_13]);
			if (chart_0.NSeries.Count > 0)
			{
				string xValues = chart_0.NSeries[0].XValues;
				if (xValues != null && xValues != "")
				{
					xmlTextWriter_0.WriteStartElement("chart:categories");
					xmlTextWriter_0.WriteAttributeString("table", "cell-range-address", null, smethod_3(xValues));
					xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_13]);
					xmlTextWriter_0.WriteEndElement();
				}
			}
		}
		else if (axis_0.Type == Enum195.const_2)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "dimension", null, "z");
			xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_14]);
		}
		switch (string_32)
		{
		case "secondary-y":
			method_36(axis_0.Title, string_8);
			break;
		case "secondary-x":
			method_36(axis_0.Title, string_7);
			break;
		case "primary-z":
			method_36(axis_0.Title, string_9);
			break;
		case "primary-y":
			method_36(axis_0.Title, string_6);
			break;
		case "primary-x":
			method_36(axis_0.Title, string_5);
			break;
		}
		if (axis_0.MajorGridLines.method_26() != Enum229.const_2)
		{
			method_45(axis_0.MajorGridLines, "major");
		}
		if (axis_0.MinorGridLines.method_26() != Enum229.const_2)
		{
			method_45(axis_0.MinorGridLines, "minor");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_45(Line line_0, string string_32)
	{
		xmlTextWriter_0.WriteStartElement("chart:grid");
		xmlTextWriter_0.WriteAttributeString("chart", "class", null, string_32);
		if (string_32 == "major")
		{
			xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_17]);
		}
		if (string_32 == "minor")
		{
			xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_18]);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_46()
	{
		SeriesCollection nSeries = chart_0.NSeries;
		int count = nSeries.Count;
		for (int i = 0; i < count; i++)
		{
			Series series_ = nSeries[i];
			method_47(series_, string_25 + i);
		}
	}

	private void method_47(Series series_0, string string_32)
	{
		xmlTextWriter_0.WriteStartElement("chart:series");
		if (series_0.method_16() != null)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "values-cell-range-address", null, smethod_2(series_0.method_16()));
		}
		if (!method_49(chartType_0) || !method_50(series_0.method_28().method_11()))
		{
			switch (series_0.method_28().method_11())
			{
			default:
				xmlTextWriter_0.WriteAttributeString("chart", "class", null, Class1516.smethod_33(series_0.Type));
				break;
			case ChartType.Doughnut:
			case ChartType.DoughnutExploded:
				xmlTextWriter_0.WriteAttributeString("chart", "class", null, "circle");
				break;
			}
		}
		if (series_0.Name != null && series_0.Name != "")
		{
			xmlTextWriter_0.WriteAttributeString("chart", "label-cell-address", null, smethod_3(series_0.Name));
		}
		if (series_0.PlotOnSecondAxis && chart_0.SecondValueAxis != null && chart_0.SecondValueAxis.IsVisible)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "attached-axis", null, "secondary-y");
		}
		xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_32]);
		if ((method_51(series_0.method_28().method_11()) || method_52(series_0.method_28().method_11())) && series_0.method_18() != null)
		{
			xmlTextWriter_0.WriteStartElement("chart:domain");
			xmlTextWriter_0.WriteAttributeString("table", "cell-range-address", null, smethod_2(series_0.method_18()));
			xmlTextWriter_0.WriteEndElement();
		}
		if (series_0.TrendLines != null && series_0.TrendLines.Count > 0)
		{
			method_55(series_0.TrendLines[0]);
		}
		if (series_0.YErrorBar.DisplayType != ErrorBarDisplayType.None)
		{
			method_56(series_0.YErrorBar);
		}
		else if (series_0.XErrorBar.DisplayType != ErrorBarDisplayType.None)
		{
			method_56(series_0.XErrorBar);
		}
		method_53(series_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_48()
	{
		string text = (string)hashtable_0[string_11];
		if (bool_0)
		{
			if (chart_0.Walls != null)
			{
				xmlTextWriter_0.WriteStartElement("chart:wall");
				xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_27]);
				xmlTextWriter_0.WriteEndElement();
			}
			if (chart_0.Floor != null)
			{
				xmlTextWriter_0.WriteStartElement("chart:floor");
				xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_28]);
				xmlTextWriter_0.WriteEndElement();
			}
		}
		else if (text != null)
		{
			xmlTextWriter_0.WriteStartElement("chart:wall");
			xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, text);
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private bool method_49(ChartType chartType_1)
	{
		if (chartType_0 != ChartType.StockHighLowClose && chartType_0 != ChartType.StockOpenHighLowClose && chartType_0 != ChartType.StockVolumeHighLowClose && chartType_0 != ChartType.StockVolumeOpenHighLowClose)
		{
			return false;
		}
		return true;
	}

	private bool method_50(ChartType chartType_1)
	{
		if (chartType_0 != ChartType.Line && chartType_0 != ChartType.Line100PercentStacked && chartType_0 != ChartType.Line100PercentStackedWithDataMarkers && chartType_0 != ChartType.Line3D && chartType_0 != ChartType.LineStacked && chartType_0 != ChartType.LineStackedWithDataMarkers && chartType_0 != ChartType.LineWithDataMarkers)
		{
			return false;
		}
		return true;
	}

	private bool method_51(ChartType chartType_1)
	{
		if (chartType_0 != ChartType.Bubble && chartType_0 != ChartType.Bubble3D)
		{
			return false;
		}
		return true;
	}

	private bool method_52(ChartType chartType_1)
	{
		if (chartType_0 != ChartType.Scatter && chartType_0 != ChartType.ScatterConnectedByCurvesWithDataMarker && chartType_0 != ChartType.ScatterConnectedByCurvesWithoutDataMarker && chartType_0 != ChartType.ScatterConnectedByLinesWithDataMarker && chartType_0 != ChartType.ScatterConnectedByLinesWithoutDataMarker)
		{
			return false;
		}
		return true;
	}

	private void method_53(Series series_0)
	{
		ChartPointCollection points = series_0.Points;
		if (points == null || points.Count < 1)
		{
			return;
		}
		ChartPoint chartPoint_ = null;
		int count = points.Count;
		int num = 1;
		for (int i = 0; i < count; i++)
		{
			ChartPoint chartPoint = points[i];
			if (method_54(chartPoint_, chartPoint))
			{
				if (i != 0)
				{
					if (num > 1)
					{
						xmlTextWriter_0.WriteAttributeString("chart", "repeated", null, num.ToString());
					}
					xmlTextWriter_0.WriteEndElement();
					num = 1;
				}
				if (i + 1 <= count)
				{
					xmlTextWriter_0.WriteStartElement("chart:data-point");
					xmlTextWriter_0.WriteAttributeString("chart", "style-name", null, (string)hashtable_0[string_26 + series_0.Index + i]);
				}
			}
			else
			{
				num++;
			}
			chartPoint_ = chartPoint;
		}
		if (num > 1)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "repeated", null, num.ToString());
		}
		if (count > 0)
		{
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private bool method_54(ChartPoint chartPoint_0, ChartPoint chartPoint_1)
	{
		if (chartPoint_0 != null && chartPoint_1.Area.ForegroundColor.Equals(chartPoint_0.Area.ForegroundColor) && chartPoint_1.Border.Color.Equals(chartPoint_0.Border.Color) && chartPoint_1.Border.WeightPt == chartPoint_0.Border.WeightPt)
		{
			return false;
		}
		return true;
	}

	private void method_55(Trendline trendline_0)
	{
		xmlTextWriter_0.WriteStartElement("chart:regression-curve");
		bool flag = false;
		if (trendline_0.DisplayRSquared)
		{
			xmlTextWriter_0.WriteAttributeString("chart", "display-r-square", null, "true");
			if (!trendline_0.DisplayEquation)
			{
				xmlTextWriter_0.WriteAttributeString("chart", "display-equation", null, "false");
			}
			flag = true;
		}
		else if (trendline_0.DisplayEquation)
		{
			flag = true;
		}
		if (flag)
		{
			_ = trendline_0.DataLabels;
			xmlTextWriter_0.WriteStartElement("chart:equation");
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_56(ErrorBar errorBar_0)
	{
		if (errorBar_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("chart:error-indicator");
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_57(bool bool_1, DropBars dropBars_0)
	{
		string localName = (bool_1 ? "chart:stock-gain-marker" : "chart:stock-loss-marker");
		xmlTextWriter_0.WriteStartElement(localName);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_58(Line line_0)
	{
		xmlTextWriter_0.WriteStartElement("chart:stock-range-line");
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_59()
	{
		return "(22754.0383863584 13253.3437095935 31734.872606677)";
	}

	private string method_60()
	{
		return "(0.416199821709347 0.173649045905254 0.892537795986984)";
	}

	private string method_61()
	{
		return "(-0.0733876362771618 0.984807599917971 -0.157379306090273)";
	}

	private string method_62(ChartType chartType_1)
	{
		return Class1516.smethod_33(chartType_1);
	}

	private string method_63(Line line_0, bool bool_1)
	{
		if (!line_0.IsVisible && !bool_1)
		{
			return "none";
		}
		switch (line_0.Style)
		{
		case LineType.Dash:
			return "dash";
		default:
			return "none";
		case LineType.Solid:
		case LineType.Dot:
		case LineType.DashDot:
		case LineType.DashDotDot:
		case LineType.DarkGray:
		case LineType.MediumGray:
		case LineType.LightGray:
			return "solid";
		}
	}

	private string method_64(LegendPositionType legendPositionType_0)
	{
		return legendPositionType_0 switch
		{
			LegendPositionType.Bottom => "bottom", 
			LegendPositionType.Corner => "top-end", 
			LegendPositionType.Top => "top", 
			LegendPositionType.Right => "end", 
			LegendPositionType.Left => "start", 
			_ => "", 
		};
	}

	private double method_65(int int_1)
	{
		return double_0 * (double)int_1 / 4000.0;
	}

	private double method_66(int int_1)
	{
		return double_1 * (double)int_1 / 4000.0;
	}

	private double method_67(int int_1)
	{
		return double_0 * (double)int_1 / 4000.0;
	}

	private double method_68(int int_1)
	{
		return double_1 * (double)int_1 / 4000.0;
	}

	private static string smethod_0(Chart chart_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string value = "";
		foreach (Series item in chart_1.NSeries)
		{
			stringBuilder.Append(value);
			smethod_1(item.method_16(), stringBuilder);
			value = " ";
		}
		if (stringBuilder.Length > 0)
		{
			return stringBuilder.ToString();
		}
		return null;
	}

	private static void smethod_1(Interface45 interface45_0, StringBuilder stringBuilder_0)
	{
		if (interface45_0 != null)
		{
			switch (interface45_0.imethod_13())
			{
			case Enum126.const_2:
			case Enum126.const_3:
			case Enum126.const_5:
				stringBuilder_0.Append(smethod_2(interface45_0));
				break;
			case Enum126.const_4:
				break;
			}
		}
	}

	private static string smethod_2(Interface45 interface45_0)
	{
		string values = interface45_0.Values;
		return smethod_3(values);
	}

	private static string smethod_3(string string_32)
	{
		if (string_32.StartsWith("="))
		{
			string_32 = string_32.Substring(1);
			string_32 = string_32.Replace("$", "");
			if (string_32.IndexOf("!") < 0)
			{
				return string_32;
			}
			string[] array = string_32.Split('!');
			string text = array[0];
			string[] array2 = array[1].Split(':');
			string text2 = "";
			string text3 = "";
			for (int i = 0; i < array2.Length; i++)
			{
				string text4 = text2;
				text2 = text4 + text3 + text + "." + array2[i];
				text3 = ":";
			}
			return text2;
		}
		return string_32;
	}
}
