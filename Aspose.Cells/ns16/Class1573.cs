using System.Xml;
using Aspose.Cells;
using ns22;

namespace ns16;

internal class Class1573
{
	private Workbook workbook_0;

	private Worksheet worksheet_0;

	private Class1541 class1541_0;

	private PageSetup pageSetup_0;

	internal Class1573(Class1541 class1541_1)
	{
		class1541_0 = class1541_1;
		workbook_0 = class1541_1.workbook_0;
		worksheet_0 = class1541_1.worksheet_0;
		pageSetup_0 = worksheet_0.Charts[0].PageSetup;
	}

	[Attribute0(true)]
	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("chartsheet");
		if (Class1618.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_0);
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_1);
		}
		xmlTextWriter_0.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		method_7(xmlTextWriter_0);
		method_6(xmlTextWriter_0);
		method_0(xmlTextWriter_0);
		method_1(xmlTextWriter_0);
		method_2(xmlTextWriter_0);
		if (class1541_0.class1358_0.string_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("drawing");
			xmlTextWriter_0.WriteAttributeString("r:id", null, class1541_0.class1358_0.string_0);
			xmlTextWriter_0.WriteEndElement();
		}
		if (class1541_0.class1534_1.string_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("legacyDrawing");
			xmlTextWriter_0.WriteAttributeString("r:id", null, class1541_0.class1534_1.string_0);
			xmlTextWriter_0.WriteEndElement();
		}
		if (class1541_0.string_3 != null)
		{
			xmlTextWriter_0.WriteStartElement("picture");
			xmlTextWriter_0.WriteAttributeString("r:id", null, class1541_0.string_3);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_0(XmlTextWriter xmlTextWriter_0)
	{
		if (worksheet_0.class1557_0 != null && worksheet_0.class1557_0.string_4 != null)
		{
			xmlTextWriter_0.WriteRaw(worksheet_0.class1557_0.string_4);
		}
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0)
	{
		PageSetup pageSetup = pageSetup_0;
		xmlTextWriter_0.WriteStartElement("pageMargins");
		xmlTextWriter_0.WriteAttributeString("left", Class1618.smethod_79(pageSetup.LeftMarginInch));
		xmlTextWriter_0.WriteAttributeString("right", Class1618.smethod_79(pageSetup.RightMarginInch));
		xmlTextWriter_0.WriteAttributeString("top", Class1618.smethod_79(pageSetup.TopMarginInch));
		xmlTextWriter_0.WriteAttributeString("bottom", Class1618.smethod_79(pageSetup.BottomMarginInch));
		xmlTextWriter_0.WriteAttributeString("header", Class1618.smethod_79(pageSetup.HeaderMarginInch));
		xmlTextWriter_0.WriteAttributeString("footer", Class1618.smethod_79(pageSetup.FooterMarginInch));
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_2(XmlTextWriter xmlTextWriter_0)
	{
		PageSetup pageSetup = pageSetup_0;
		if (pageSetup != null && pageSetup.method_13())
		{
			xmlTextWriter_0.WriteStartElement("pageSetup");
			if (pageSetup.BlackAndWhite)
			{
				xmlTextWriter_0.WriteAttributeString("blackAndWhite", "1");
			}
			if (pageSetup.PrintComments != PrintCommentsType.PrintNoComments)
			{
				xmlTextWriter_0.WriteAttributeString("cellComments", Class1618.smethod_20(pageSetup.PrintComments));
			}
			if (pageSetup.PrintDraft)
			{
				xmlTextWriter_0.WriteAttributeString("draft", "1");
			}
			if (pageSetup.PrintErrors != PrintErrorsType.PrintErrorsDisplayed)
			{
				xmlTextWriter_0.WriteAttributeString("errors", Class1618.smethod_22(pageSetup.PrintErrors));
			}
			if (!pageSetup.IsAutoFirstPageNumber)
			{
				xmlTextWriter_0.WriteAttributeString("firstPageNumber", Class1618.smethod_80(pageSetup.FirstPageNumber));
				xmlTextWriter_0.WriteAttributeString("useFirstPageNumber", "1");
			}
			if (pageSetup.FitToPagesTall != 1)
			{
				xmlTextWriter_0.WriteAttributeString("fitToHeight", Class1618.smethod_80(pageSetup.FitToPagesTall));
			}
			if (pageSetup.FitToPagesWide != 1)
			{
				xmlTextWriter_0.WriteAttributeString("fitToWidth", Class1618.smethod_80(pageSetup.FitToPagesWide));
			}
			if (pageSetup.PrintQuality > 0)
			{
				xmlTextWriter_0.WriteAttributeString("horizontalDpi", Class1618.smethod_80(pageSetup.PrintQuality));
				xmlTextWriter_0.WriteAttributeString("verticalDpi", Class1618.smethod_80(pageSetup.PrintQuality));
			}
			xmlTextWriter_0.WriteAttributeString("orientation", Class1618.smethod_18(pageSetup.Orientation));
			if (pageSetup.Order != 0)
			{
				xmlTextWriter_0.WriteAttributeString("pageOrder", Class1618.smethod_24(pageSetup.Order));
			}
			if (pageSetup.PaperSize != PaperSizeType.PaperLetter)
			{
				xmlTextWriter_0.WriteAttributeString("paperSize", Class1618.smethod_80((int)pageSetup.PaperSize));
			}
			if (pageSetup.Zoom != 100)
			{
				xmlTextWriter_0.WriteAttributeString("scale", Class1618.smethod_80(pageSetup.Zoom));
			}
			xmlTextWriter_0.WriteEndElement();
			method_3(xmlTextWriter_0, pageSetup);
		}
	}

	private void method_3(XmlTextWriter xmlTextWriter_0, PageSetup pageSetup_1)
	{
		string text = method_5(pageSetup_1.GetFirstPageHeader(0), 0) + method_5(pageSetup_1.GetFirstPageHeader(1), 1) + method_5(pageSetup_1.GetFirstPageHeader(2), 2);
		string text2 = method_5(pageSetup_1.GetFirstPageFooter(0), 0) + method_5(pageSetup_1.GetFirstPageFooter(1), 1) + method_5(pageSetup_1.GetFirstPageFooter(2), 2);
		string text3 = method_5(pageSetup_1.GetEvenHeader(0), 0) + method_5(pageSetup_1.GetEvenHeader(1), 1) + method_5(pageSetup_1.GetEvenHeader(2), 2);
		string text4 = method_5(pageSetup_1.GetEvenFooter(0), 0) + method_5(pageSetup_1.GetEvenFooter(1), 1) + method_5(pageSetup_1.GetEvenFooter(2), 2);
		string text5 = method_5(pageSetup_1.GetHeader(0), 0) + method_5(pageSetup_1.GetHeader(1), 1) + method_5(pageSetup_1.GetHeader(2), 2);
		string text6 = method_5(pageSetup_1.GetFooter(0), 0) + method_5(pageSetup_1.GetFooter(1), 1) + method_5(pageSetup_1.GetFooter(2), 2);
		if (text.Length > 0 || text2.Length > 0 || text3.Length > 0 || text4.Length > 0 || text5.Length > 0 || text6.Length > 0)
		{
			xmlTextWriter_0.WriteStartElement("headerFooter");
			if (pageSetup_1.IsHFDiffOddEven)
			{
				xmlTextWriter_0.WriteAttributeString("differentOddEven", "1");
			}
			if (pageSetup_1.IsHFDiffFirst)
			{
				xmlTextWriter_0.WriteAttributeString("differentFirst", "1");
			}
			if (!pageSetup_1.IsHFScaleWithDoc)
			{
				xmlTextWriter_0.WriteAttributeString("scaleWithDoc", "0");
			}
			if (!pageSetup_1.IsHFAlignMargins)
			{
				xmlTextWriter_0.WriteAttributeString("alignWithMargins", "0");
			}
			if (text5.Length > 0)
			{
				method_4(xmlTextWriter_0, "oddHeader", text5);
			}
			if (text6.Length > 0)
			{
				method_4(xmlTextWriter_0, "oddFooter", text6);
			}
			if (text3.Length > 0)
			{
				method_4(xmlTextWriter_0, "evenHeader", text3);
			}
			if (text4.Length > 0)
			{
				method_4(xmlTextWriter_0, "evenFooter", text4);
			}
			if (text.Length > 0)
			{
				method_4(xmlTextWriter_0, "firstHeader", text);
			}
			if (text2.Length > 0)
			{
				method_4(xmlTextWriter_0, "firstFooter", text2);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_4(XmlTextWriter xmlTextWriter_0, string string_0, string string_1)
	{
		xmlTextWriter_0.WriteStartElement(string_0);
		if (string_1.StartsWith(" ") || string_1.EndsWith(" "))
		{
			xmlTextWriter_0.WriteAttributeString("xml:space", null, "preserve");
		}
		xmlTextWriter_0.WriteString(string_1);
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_5(string string_0, int int_0)
	{
		string result = string_0;
		if (string_0 != null)
		{
			switch (int_0)
			{
			case 0:
				if (string_0.ToUpper().IndexOf("&L") == -1)
				{
					result = "&L" + string_0;
				}
				break;
			case 1:
				if (string_0.ToUpper().IndexOf("&C") == -1)
				{
					result = "&C" + string_0;
				}
				break;
			case 2:
				if (string_0.ToUpper().IndexOf("&R") == -1)
				{
					result = "&R" + string_0;
				}
				break;
			}
		}
		else
		{
			result = "";
		}
		return result;
	}

	[Attribute0(true)]
	private void method_6(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("sheetViews");
		xmlTextWriter_0.WriteStartElement("sheetView");
		if (!worksheet_0.IsGridlinesVisible)
		{
			xmlTextWriter_0.WriteAttributeString("showGridLines", "0");
		}
		if (!worksheet_0.IsRowColumnHeadersVisible)
		{
			xmlTextWriter_0.WriteAttributeString("showRowColHeaders", "0");
		}
		if (worksheet_0.IsSelected || worksheet_0.SheetIndex == workbook_0.Worksheets.ActiveSheetIndex)
		{
			xmlTextWriter_0.WriteAttributeString("tabSelected", "1");
		}
		xmlTextWriter_0.WriteAttributeString("workbookViewId", "0");
		if (worksheet_0.IsPageBreakPreview)
		{
			xmlTextWriter_0.WriteAttributeString("view", "pageBreakPreview");
		}
		if (worksheet_0.Zoom != 100)
		{
			xmlTextWriter_0.WriteAttributeString("zoomScale", Class1618.smethod_80(worksheet_0.Zoom));
		}
		if (worksheet_0.Charts[0].SizeWithWindow)
		{
			xmlTextWriter_0.WriteAttributeString("zoomToFit", "1");
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_7(XmlTextWriter xmlTextWriter_0)
	{
		string text = null;
		if (worksheet_0.class1557_0 != null)
		{
			text = worksheet_0.class1557_0.string_3;
		}
		string text2 = worksheet_0.method_47();
		if (text != null || !pageSetup_0.IsPercentScale || text2 != null || !worksheet_0.internalColor_0.method_2())
		{
			xmlTextWriter_0.WriteStartElement("sheetPr");
			if (text2 != null)
			{
				xmlTextWriter_0.WriteAttributeString("codeName", text2);
			}
			if (text != null)
			{
				xmlTextWriter_0.WriteAttributeString("published", text);
			}
			if (!pageSetup_0.IsPercentScale)
			{
				xmlTextWriter_0.WriteStartElement("pageSetUpPr");
				xmlTextWriter_0.WriteAttributeString("fitToPage", "1");
				xmlTextWriter_0.WriteEndElement();
			}
			if (!worksheet_0.internalColor_0.method_2())
			{
				Class1590.smethod_1(xmlTextWriter_0, worksheet_0.internalColor_0, "tabColor");
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}
}
