using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns22;

namespace ns16;

internal class Class1239
{
	private Class1547 class1547_0;

	private Worksheet worksheet_0;

	private Class1548 class1548_0;

	internal Class1239(Class1547 class1547_1, Class1548 class1548_1)
	{
		class1547_0 = class1547_1;
		class1548_0 = class1548_1;
		worksheet_0 = class1548_1.worksheet_0;
	}

	internal void Read(XmlTextReader xmlTextReader_0, Class1617 class1617_0)
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
			else if (xmlTextReader_0.LocalName == "ext" && !xmlTextReader_0.IsEmptyElement)
			{
				method_4(xmlTextReader_0, class1617_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	internal bool method_0(XmlTextReader xmlTextReader_0, Class1617 class1617_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("uri");
		xmlTextReader_0.GetAttribute("xmlns:x14");
		if (attribute != null && !xmlTextReader_0.IsEmptyElement)
		{
			attribute = attribute.ToUpper();
			if (attribute.Equals("{05C60535-1F16-4FD2-B633-F4F36F0B64E0}"))
			{
				return true;
			}
			Class1363 class1363_ = worksheet_0.class1557_0.class1363_0;
			if (attribute.Equals("{78C0D931-6437-407D-A8EE-F0AAD7539E65}"))
			{
				method_2(xmlTextReader_0, class1617_0);
			}
			else if (attribute.Equals("{CCE6A557-97BC-4B89-ADB6-D9C93CAAB3DF}"))
			{
				method_1(xmlTextReader_0, class1617_0);
			}
			else if (attribute.Equals("{A8765BA9-456A-4DAB-B4F3-ACF838C121DE}"))
			{
				class1363_.Add(Enum129.const_7, xmlTextReader_0.ReadOuterXml());
			}
			else if (attribute.Equals("{FC87AEE6-9EDD-4A0A-B7FB-166176984837}"))
			{
				class1363_.Add(Enum129.const_8, xmlTextReader_0.ReadOuterXml());
			}
			else if (attribute.Equals("{01252117-D84E-4E92-8308-4BE1C098FCBB}"))
			{
				class1363_.Add(Enum129.const_9, xmlTextReader_0.ReadOuterXml());
			}
			else
			{
				xmlTextReader_0.Skip();
			}
			return false;
		}
		xmlTextReader_0.Skip();
		return false;
	}

	private void method_1(XmlTextReader xmlTextReader_0, Class1617 class1617_0)
	{
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "dataValidations")
			{
				class1617_0.method_26(xmlTextReader_0, bool_2: true);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_2(XmlTextReader xmlTextReader_0, Class1617 class1617_0)
	{
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "conditionalFormattings")
			{
				method_3(xmlTextReader_0, class1617_0, bool_0: true);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_3(XmlTextReader xmlTextReader_0, Class1617 class1617_0, bool bool_0)
	{
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "conditionalFormatting")
			{
				class1617_0.method_50(xmlTextReader_0, bool_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal void method_4(XmlTextReader xmlTextReader_0, Class1617 class1617_0)
	{
		if (!method_0(xmlTextReader_0, class1617_0))
		{
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
			else if (xmlTextReader_0.LocalName == "sparklineGroups" && !xmlTextReader_0.IsEmptyElement)
			{
				method_5(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal void method_5(XmlTextReader xmlTextReader_0)
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
			else if (xmlTextReader_0.LocalName == "sparklineGroup" && !xmlTextReader_0.IsEmptyElement)
			{
				method_6(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal void method_6(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		SparklineGroup sparklineGroup = new SparklineGroup(worksheet_0.SparklineGroupCollection);
		worksheet_0.SparklineGroupCollection.Add(sparklineGroup);
		method_8(xmlTextReader_0, sparklineGroup);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "colorSeries")
			{
				sparklineGroup.SeriesColor = method_7(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "colorNegative")
			{
				sparklineGroup.NegativePointsColor = method_7(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "colorAxis")
			{
				sparklineGroup.HorizontalAxisColor = method_7(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "colorMarkers")
			{
				sparklineGroup.MarkersColor = method_7(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "colorFirst")
			{
				sparklineGroup.FirstPointColor = method_7(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "colorLast")
			{
				sparklineGroup.LastPointColor = method_7(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "colorHigh")
			{
				sparklineGroup.HighPointColor = method_7(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "colorLow")
			{
				sparklineGroup.LowPointColor = method_7(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "f")
			{
				sparklineGroup.HorizontalAxisDateRange = xmlTextReader_0.ReadElementString();
			}
			else if (xmlTextReader_0.LocalName == "sparklines")
			{
				method_9(xmlTextReader_0, sparklineGroup);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal CellsColor method_7(XmlTextReader xmlTextReader_0)
	{
		CellsColor cellsColor = class1547_0.workbook_0.CreateCellsColor();
		InternalColor internalColor = new InternalColor(bool_0: false);
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "theme")
				{
					int int_ = Class1618.smethod_87(xmlTextReader_0.Value);
					internalColor.SetColor(ColorType.Theme, int_);
				}
				else if (xmlTextReader_0.LocalName == "tint")
				{
					internalColor.Tint = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "rgb")
				{
					internalColor.SetColor(ColorType.RGB, Class1618.smethod_63(xmlTextReader_0.Value).ToArgb());
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
		cellsColor.internalColor_0 = internalColor;
		return cellsColor;
	}

	[Attribute0(true)]
	internal void method_8(XmlTextReader xmlTextReader_0, SparklineGroup sparklineGroup_0)
	{
		sparklineGroup_0.Type = SparklineType.Line;
		if (!xmlTextReader_0.HasAttributes)
		{
			return;
		}
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (xmlTextReader_0.LocalName == "manualMax")
			{
				sparklineGroup_0.VerticalAxisMaxValue = Class1618.smethod_85(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "manualMin")
			{
				sparklineGroup_0.VerticalAxisMinValue = Class1618.smethod_85(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "type")
			{
				sparklineGroup_0.sparklineType_0 = Class1618.smethod_225(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "lineWeight")
			{
				sparklineGroup_0.LineWeight = Class1618.smethod_85(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "displayEmptyCellsAs")
			{
				sparklineGroup_0.PlotEmptyCellsType = Class1618.smethod_204(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "markers")
			{
				sparklineGroup_0.ShowMarkers = ((!(xmlTextReader_0.Value == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "high")
			{
				sparklineGroup_0.ShowHighPoint = ((!(xmlTextReader_0.Value == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "low")
			{
				sparklineGroup_0.ShowLowPoint = ((!(xmlTextReader_0.Value == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "first")
			{
				sparklineGroup_0.ShowFirstPoint = ((!(xmlTextReader_0.Value == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "last")
			{
				sparklineGroup_0.ShowLastPoint = ((!(xmlTextReader_0.Value == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "negative")
			{
				sparklineGroup_0.ShowNegativePoints = ((!(xmlTextReader_0.Value == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "displayXAxis")
			{
				sparklineGroup_0.ShowHorizontalAxis = ((!(xmlTextReader_0.Value == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "displayHidden")
			{
				sparklineGroup_0.DisplayHidden = ((!(xmlTextReader_0.Value == "0")) ? true : false);
			}
			else if (xmlTextReader_0.LocalName == "minAxisType")
			{
				sparklineGroup_0.VerticalAxisMinValueType = Class1618.smethod_227(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "maxAxisType")
			{
				sparklineGroup_0.VerticalAxisMaxValueType = Class1618.smethod_227(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "rightToLeft")
			{
				sparklineGroup_0.PlotRightToLeft = ((!(xmlTextReader_0.Value == "0")) ? true : false);
			}
		}
		xmlTextReader_0.MoveToElement();
	}

	internal void method_9(XmlTextReader xmlTextReader_0, SparklineGroup sparklineGroup_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		SparklineCollection sparklineCollection = sparklineGroup_0.SparklineCollection;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "sparkline")
			{
				method_10(xmlTextReader_0, sparklineCollection);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal void method_10(XmlTextReader xmlTextReader_0, SparklineCollection sparklineCollection_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Sparkline sparkline = new Sparkline(sparklineCollection_0);
		sparklineCollection_0.method_2(sparkline);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "f")
			{
				sparkline.DataRange = xmlTextReader_0.ReadElementString();
			}
			else if (xmlTextReader_0.LocalName == "sqref")
			{
				int row = 0;
				int column = 0;
				CellsHelper.CellNameToIndex(xmlTextReader_0.ReadElementString(), out row, out column);
				sparkline.method_2(row);
				sparkline.method_3(column);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}
}
