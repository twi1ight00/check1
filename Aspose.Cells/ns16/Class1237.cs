using System;
using System.Drawing;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Pivot;
using ns22;

namespace ns16;

internal class Class1237
{
	private Workbook workbook_0;

	private Worksheet worksheet_0;

	private Class1541 class1541_0;

	internal Class1237(Class1541 class1541_1)
	{
		class1541_0 = class1541_1;
		workbook_0 = class1541_1.workbook_0;
		worksheet_0 = class1541_1.worksheet_0;
	}

	internal void Write(XmlTextWriter xmlTextWriter_0, Class1596 class1596_0)
	{
		if (!method_1())
		{
			return;
		}
		Class1363 @class = null;
		if (worksheet_0.class1557_0 != null && worksheet_0.class1557_0.class1363_0.hashtable_0.Count > 0)
		{
			@class = worksheet_0.class1557_0.class1363_0;
		}
		xmlTextWriter_0.WriteStartElement("extLst");
		class1596_0.method_37(xmlTextWriter_0);
		class1596_0.method_36(xmlTextWriter_0);
		if (@class != null)
		{
			object obj = @class.method_0(Enum129.const_6);
			if (obj != null)
			{
				xmlTextWriter_0.WriteRaw((string)obj);
			}
		}
		method_3(xmlTextWriter_0);
		if (@class != null)
		{
			object obj2 = @class.method_0(Enum129.const_7);
			if (obj2 != null)
			{
				method_0(xmlTextWriter_0, (string)obj2);
			}
			obj2 = @class.method_0(Enum129.const_8);
			if (obj2 != null)
			{
				xmlTextWriter_0.WriteRaw((string)obj2);
			}
			obj2 = @class.method_0(Enum129.const_9);
			if (obj2 != null)
			{
				xmlTextWriter_0.WriteRaw((string)obj2);
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_0(XmlTextWriter xmlTextWriter_0, string string_0)
	{
		XmlDocument xmlDocument = Class1188.smethod_1(string_0);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("slicer", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
		foreach (XmlNode item in elementsByTagName)
		{
			XmlElement xmlElement_ = (XmlElement)item;
			XmlAttribute xmlAttribute = Class1188.smethod_7(xmlElement_, "id", Class1618.string_2);
			if (xmlAttribute == null)
			{
				continue;
			}
			foreach (object item2 in worksheet_0.class1557_0.arrayList_4)
			{
				Class1564 @class = (Class1564)item2;
				if (@class.string_0 == xmlAttribute.Value)
				{
					xmlAttribute.Value = @class.string_1;
				}
			}
		}
		xmlTextWriter_0.WriteRaw(Class1188.smethod_8(xmlDocument).OuterXml);
	}

	private bool method_1()
	{
		worksheet_0.SparklineGroupCollection.method_1();
		if (worksheet_0.class1557_0 != null && worksheet_0.class1557_0.class1363_0.hashtable_0.Count > 0)
		{
			return true;
		}
		if (worksheet_0.SparklineGroupCollection.Count > 0)
		{
			return true;
		}
		if (method_2())
		{
			return true;
		}
		return false;
	}

	private bool method_2()
	{
		int num = 0;
		while (true)
		{
			if (num < worksheet_0.ConditionalFormattings.Count)
			{
				FormatConditionCollection formatConditionCollection = worksheet_0.ConditionalFormattings[num];
				if (formatConditionCollection.method_6(bool_2: true))
				{
					break;
				}
				num++;
				continue;
			}
			if (worksheet_0.PivotTables.Count > 0)
			{
				for (int i = 0; i < worksheet_0.PivotTables.Count; i++)
				{
					PivotTable pivotTable = worksheet_0.PivotTables[i];
					PivotFormatConditionCollection pivotFormatConditionCollection_ = pivotTable.pivotFormatConditionCollection_0;
					if (pivotFormatConditionCollection_ != null && pivotFormatConditionCollection_.Count != 0 && (pivotFormatConditionCollection_.method_2() || pivotFormatConditionCollection_.method_1()))
					{
						return true;
					}
				}
			}
			return false;
		}
		return true;
	}

	private void method_3(XmlTextWriter xmlTextWriter_0)
	{
		if (worksheet_0.SparklineGroupCollection.Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("ext");
		xmlTextWriter_0.WriteAttributeString("uri", "{05C60535-1F16-4fd2-B633-F4F36F0B64E0}");
		xmlTextWriter_0.WriteAttributeString("xmlns:x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
		xmlTextWriter_0.WriteStartElement("x14:sparklineGroups");
		xmlTextWriter_0.WriteAttributeString("xmlns:xm", "http://schemas.microsoft.com/office/excel/2006/main");
		foreach (SparklineGroup item in worksheet_0.SparklineGroupCollection)
		{
			method_4(xmlTextWriter_0, item);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_4(XmlTextWriter xmlTextWriter_0, SparklineGroup sparklineGroup_0)
	{
		xmlTextWriter_0.WriteStartElement("x14:sparklineGroup");
		method_8(xmlTextWriter_0, sparklineGroup_0);
		method_6(xmlTextWriter_0, "colorSeries", sparklineGroup_0.SeriesColor);
		method_6(xmlTextWriter_0, "colorNegative", sparklineGroup_0.NegativePointsColor);
		method_6(xmlTextWriter_0, "colorAxis", sparklineGroup_0.HorizontalAxisColor);
		method_6(xmlTextWriter_0, "colorMarkers", sparklineGroup_0.MarkersColor);
		method_6(xmlTextWriter_0, "colorFirst", sparklineGroup_0.FirstPointColor);
		method_6(xmlTextWriter_0, "colorLast", sparklineGroup_0.LastPointColor);
		method_6(xmlTextWriter_0, "colorHigh", sparklineGroup_0.HighPointColor);
		method_6(xmlTextWriter_0, "colorLow", sparklineGroup_0.LowPointColor);
		string horizontalAxisDateRange = sparklineGroup_0.HorizontalAxisDateRange;
		if (horizontalAxisDateRange != null)
		{
			xmlTextWriter_0.WriteElementString("xm:f", horizontalAxisDateRange);
		}
		xmlTextWriter_0.WriteStartElement("x14:sparklines");
		foreach (Sparkline item in sparklineGroup_0.SparklineCollection)
		{
			method_5(xmlTextWriter_0, item);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_5(XmlTextWriter xmlTextWriter_0, Sparkline sparkline_0)
	{
		xmlTextWriter_0.WriteStartElement("x14:sparkline");
		xmlTextWriter_0.WriteElementString("xm:f", sparkline_0.DataRange);
		xmlTextWriter_0.WriteElementString("xm:sqref", CellsHelper.CellIndexToName(sparkline_0.Row, sparkline_0.Column));
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_6(XmlTextWriter xmlTextWriter_0, string string_0, CellsColor cellsColor_0)
	{
		InternalColor internalColor_ = cellsColor_0.internalColor_0;
		xmlTextWriter_0.WriteStartElement("x14:" + string_0);
		if (internalColor_.ColorType == ColorType.Theme)
		{
			xmlTextWriter_0.WriteAttributeString("theme", Class1618.smethod_80(internalColor_.method_4()));
			if (internalColor_.Tint != 0.0)
			{
				xmlTextWriter_0.WriteAttributeString("tint", method_7(internalColor_.Tint));
			}
		}
		else if (internalColor_.ColorType == ColorType.RGB)
		{
			xmlTextWriter_0.WriteAttributeString("rgb", "FF" + Class1618.smethod_64(Color.FromArgb(internalColor_.method_4())));
			if (internalColor_.Tint != 0.0)
			{
				xmlTextWriter_0.WriteAttributeString("tint", method_7(internalColor_.Tint));
			}
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("rgb", "FF" + Class1618.smethod_64(cellsColor_0.Color));
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_7(double double_0)
	{
		double num = 0.0001;
		if (double_0 < 0.0)
		{
			double num2 = double_0 + 0.499984740745262;
			if (Math.Abs(num2) < num)
			{
				return "-0.499984740745262";
			}
			if (num2 > 0.0 && Math.Abs(double_0 + 0.249977111117893) < num)
			{
				return "-0.249977111117893";
			}
		}
		else
		{
			double num3 = double_0 - 0.3999755851924192;
			if (Math.Abs(num3) < num)
			{
				return "0.39997558519241921";
			}
			if (num3 > 0.0)
			{
				num3 = double_0 - 0.499984740745262;
				if (Math.Abs(num3) < num)
				{
					return "0.499984740745262";
				}
				if (num3 > 0.0 && Math.Abs(double_0 - 0.7999816888943144) < num)
				{
					return "0.79998168889431442";
				}
			}
			else
			{
				num3 = double_0 - 0.3499862666707358;
				if (Math.Abs(num3) < num)
				{
					return "0.34998626667073579";
				}
				if (num3 < 0.0 && Math.Abs(double_0 - 0.249977111117893) < num)
				{
					return "0.249977111117893";
				}
			}
		}
		return Class1618.smethod_79(double_0);
	}

	private void method_8(XmlTextWriter xmlTextWriter_0, SparklineGroup sparklineGroup_0)
	{
		if (sparklineGroup_0.VerticalAxisMaxValueType == SparklineAxisMinMaxType.Custom)
		{
			xmlTextWriter_0.WriteAttributeString("manualMax", Class1618.smethod_79(sparklineGroup_0.VerticalAxisMaxValue));
		}
		if (sparklineGroup_0.VerticalAxisMinValueType == SparklineAxisMinMaxType.Custom)
		{
			xmlTextWriter_0.WriteAttributeString("manualMin", Class1618.smethod_79(sparklineGroup_0.VerticalAxisMinValue));
		}
		if (sparklineGroup_0.Type == SparklineType.Line && sparklineGroup_0.LineWeight != 0.75)
		{
			xmlTextWriter_0.WriteAttributeString("lineWeight", Class1618.smethod_79(sparklineGroup_0.LineWeight));
		}
		if (sparklineGroup_0.Type != 0)
		{
			xmlTextWriter_0.WriteAttributeString("type", Class1618.smethod_226(sparklineGroup_0.Type));
		}
		if (sparklineGroup_0.HorizontalAxisDateRange != null)
		{
			xmlTextWriter_0.WriteAttributeString("dateAxis", "1");
		}
		if (sparklineGroup_0.PlotEmptyCellsType != PlotEmptyCellsType.Zero)
		{
			xmlTextWriter_0.WriteAttributeString("displayEmptyCellsAs", Class1618.smethod_205(sparklineGroup_0.PlotEmptyCellsType));
		}
		if (sparklineGroup_0.Type == SparklineType.Line && sparklineGroup_0.ShowMarkers)
		{
			xmlTextWriter_0.WriteAttributeString("markers", "1");
		}
		if (sparklineGroup_0.ShowHighPoint)
		{
			xmlTextWriter_0.WriteAttributeString("high", "1");
		}
		if (sparklineGroup_0.ShowLowPoint)
		{
			xmlTextWriter_0.WriteAttributeString("low", "1");
		}
		if (sparklineGroup_0.ShowFirstPoint)
		{
			xmlTextWriter_0.WriteAttributeString("first", "1");
		}
		if (sparklineGroup_0.ShowLastPoint)
		{
			xmlTextWriter_0.WriteAttributeString("last", "1");
		}
		if (sparklineGroup_0.ShowNegativePoints)
		{
			xmlTextWriter_0.WriteAttributeString("negative", "1");
		}
		if (sparklineGroup_0.ShowHorizontalAxis)
		{
			xmlTextWriter_0.WriteAttributeString("displayXAxis", "1");
		}
		if (sparklineGroup_0.DisplayHidden)
		{
			xmlTextWriter_0.WriteAttributeString("displayHidden", "1");
		}
		if (sparklineGroup_0.VerticalAxisMinValueType != 0)
		{
			xmlTextWriter_0.WriteAttributeString("minAxisType", Class1618.smethod_228(sparklineGroup_0.VerticalAxisMinValueType));
		}
		if (sparklineGroup_0.VerticalAxisMaxValueType != 0)
		{
			xmlTextWriter_0.WriteAttributeString("maxAxisType", Class1618.smethod_228(sparklineGroup_0.VerticalAxisMaxValueType));
		}
		if (sparklineGroup_0.PlotRightToLeft)
		{
			xmlTextWriter_0.WriteAttributeString("rightToLeft", "1");
		}
	}
}
