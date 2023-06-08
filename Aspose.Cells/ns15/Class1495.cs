using System;
using System.Text;
using System.Xml;
using Aspose.Cells;
using ns2;
using ns22;
using ns26;

namespace ns15;

internal class Class1495
{
	private XmlTextWriter xmlTextWriter_0;

	private Class1498 class1498_0;

	public Class1495(Class1498 class1498_1)
	{
		class1498_0 = class1498_1;
	}

	[Attribute0(true)]
	internal void Write(XmlTextWriter xmlTextWriter_1)
	{
		xmlTextWriter_0 = xmlTextWriter_1;
		xmlTextWriter_1.WriteStartElement("office:automatic-styles");
		for (int i = 0; i < class1498_0.workbook_0.Worksheets.Count; i++)
		{
			Worksheet worksheet_ = class1498_0.workbook_0.Worksheets[i];
			method_0(worksheet_);
		}
		if (class1498_0.arrayList_6.Count > 0)
		{
			for (int j = 0; j < class1498_0.arrayList_6.Count; j++)
			{
				Font font_ = (Font)class1498_0.arrayList_6[j];
				method_5(j + 1, font_);
			}
		}
		xmlTextWriter_1.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_0(Worksheet worksheet_0)
	{
		PageSetup pageSetup = worksheet_0.PageSetup;
		xmlTextWriter_0.WriteStartElement("style:page-layout");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, "pm" + (worksheet_0.Index + 1));
		method_1(pageSetup);
		method_2(pageSetup);
		method_3(pageSetup);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_1(PageSetup pageSetup_0)
	{
		xmlTextWriter_0.WriteStartElement("style:page-layout-properties");
		if (pageSetup_0.Orientation == PageOrientationType.Landscape)
		{
			xmlTextWriter_0.WriteAttributeString("style", "print-orientation", null, "landscape");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("style", "print-orientation", null, "portrait");
		}
		Class1677.smethod_3(pageSetup_0, out var pageWidthBase, out var pageHeightBase);
		xmlTextWriter_0.WriteAttributeString("fo", "page-width", null, Class1516.smethod_15(Math.Round(pageWidthBase, 4)) + "in");
		xmlTextWriter_0.WriteAttributeString("fo", "page-height", null, Class1516.smethod_15(Math.Round(pageHeightBase, 4)) + "in");
		if (pageSetup_0.IsPercentScale)
		{
			xmlTextWriter_0.WriteAttributeString("style", "scale-to", null, Class1516.smethod_13(pageSetup_0.Zoom) + "%");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("style", "scale-to-X", null, Class1516.smethod_13(pageSetup_0.FitToPagesWide));
			xmlTextWriter_0.WriteAttributeString("style", "scale-to-Y", null, Class1516.smethod_13(pageSetup_0.FitToPagesTall));
		}
		if (pageSetup_0.Order == PrintOrderType.OverThenDown)
		{
			xmlTextWriter_0.WriteAttributeString("style", "print-page-order", null, "ltr");
		}
		else if (pageSetup_0.Order == PrintOrderType.DownThenOver)
		{
			xmlTextWriter_0.WriteAttributeString("style", "print-page-order", null, "ttb");
		}
		xmlTextWriter_0.WriteAttributeString("fo", "margin-left", null, Class1516.smethod_15(Math.Round(pageSetup_0.LeftMarginInch, 4)) + "in");
		xmlTextWriter_0.WriteAttributeString("fo", "margin-right", null, Class1516.smethod_15(Math.Round(pageSetup_0.RightMarginInch, 4)) + "in");
		xmlTextWriter_0.WriteAttributeString("fo", "margin-top", null, Class1516.smethod_15(Math.Round(pageSetup_0.HeaderMarginInch, 4)) + "in");
		xmlTextWriter_0.WriteAttributeString("fo", "margin-bottom", null, Class1516.smethod_15(Math.Round(pageSetup_0.FooterMarginInch, 4)) + "in");
		if (pageSetup_0.IsAutoFirstPageNumber)
		{
			xmlTextWriter_0.WriteAttributeString("style", "first-page-number", null, "continue");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("style", "first-page-number", null, Class1516.smethod_13(pageSetup_0.FirstPageNumber));
		}
		if (pageSetup_0.CenterHorizontally)
		{
			if (pageSetup_0.CenterVertically)
			{
				xmlTextWriter_0.WriteAttributeString("style", "table-centering", null, "both");
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("style", "table-centering", null, "horizontal");
			}
		}
		else if (pageSetup_0.CenterVertically)
		{
			xmlTextWriter_0.WriteAttributeString("style", "table-centering", null, "vertical");
		}
		StringBuilder stringBuilder = new StringBuilder("zero-values");
		if (pageSetup_0.PrintHeadings)
		{
			stringBuilder.Append(" headers");
		}
		if (pageSetup_0.PrintGridlines)
		{
			stringBuilder.Append(" grid");
		}
		if (pageSetup_0.PrintDraft)
		{
			stringBuilder.Append(" charts drawings objects");
		}
		if (pageSetup_0.PrintComments != PrintCommentsType.PrintNoComments)
		{
			stringBuilder.Append(" annotations");
		}
		xmlTextWriter_0.WriteAttributeString("style", "print", null, stringBuilder.ToString());
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_2(PageSetup pageSetup_0)
	{
		xmlTextWriter_0.WriteStartElement("style:header-style");
		method_4(pageSetup_0, bool_0: true);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_3(PageSetup pageSetup_0)
	{
		xmlTextWriter_0.WriteStartElement("style:footer-style");
		method_4(pageSetup_0, bool_0: false);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_4(PageSetup pageSetup_0, bool bool_0)
	{
		xmlTextWriter_0.WriteStartElement("style:header-footer-properties");
		if (bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("fo", "min-height", null, Class1516.smethod_15(Math.Round(pageSetup_0.TopMarginInch - pageSetup_0.HeaderMarginInch, 4)) + "in");
			xmlTextWriter_0.WriteAttributeString("fo", "margin-left", null, "0in");
			xmlTextWriter_0.WriteAttributeString("fo", "margin-right", null, "0in");
			xmlTextWriter_0.WriteAttributeString("fo", "margin-bottom", null, "0in");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("fo", "min-height", null, Class1516.smethod_15(Math.Round(pageSetup_0.BottomMarginInch - pageSetup_0.FooterMarginInch, 4)) + "in");
			xmlTextWriter_0.WriteAttributeString("fo", "margin-left", null, "0in");
			xmlTextWriter_0.WriteAttributeString("fo", "margin-right", null, "0in");
			xmlTextWriter_0.WriteAttributeString("fo", "margin-top", null, "0in");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_5(int int_0, Font font_0)
	{
		xmlTextWriter_0.WriteStartElement("style:style");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, "T" + int_0);
		xmlTextWriter_0.WriteAttributeString("style", "family", null, "text");
		method_6(new Class1501(font_0));
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_6(Class1501 class1501_0)
	{
		FontUnderlineType underline = class1501_0.Underline;
		xmlTextWriter_0.WriteStartElement("style:text-properties ");
		if (!Class1516.smethod_0(class1501_0.Name))
		{
			xmlTextWriter_0.WriteAttributeString("style", "font-name", null, class1501_0.Name);
			xmlTextWriter_0.WriteAttributeString("style", "font-name-asian", null, class1501_0.Name);
		}
		if (class1501_0.IsBold)
		{
			xmlTextWriter_0.WriteAttributeString("fo", "font-weight", null, "bold");
			xmlTextWriter_0.WriteAttributeString("style", "font-weight-asian", null, "bold");
			xmlTextWriter_0.WriteAttributeString("style", "font-weight-complex", null, "bold");
		}
		if (class1501_0.IsItalic)
		{
			xmlTextWriter_0.WriteAttributeString("fo", "font-style", null, "italic");
			xmlTextWriter_0.WriteAttributeString("style", "font-style-asian", null, "italic");
			xmlTextWriter_0.WriteAttributeString("style", "font-style-complex", null, "italic");
		}
		if (class1501_0.IsStrikeout)
		{
			xmlTextWriter_0.WriteAttributeString("style", "text-line-through-style", null, "solid");
		}
		if (class1501_0.Size != 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("fo", "font-size", null, Class1516.smethod_12(class1501_0.Size) + "pt");
		}
		if (!class1501_0.Color.IsEmpty)
		{
			string value = Class1516.smethod_9(class1501_0.Color);
			xmlTextWriter_0.WriteAttributeString("fo", "color", null, value);
		}
		switch (underline)
		{
		case FontUnderlineType.Single:
		case FontUnderlineType.Accounting:
			xmlTextWriter_0.WriteAttributeString("style", "text-underline-style", null, "solid");
			xmlTextWriter_0.WriteAttributeString("style", "text-underline-type", null, "single");
			break;
		case FontUnderlineType.Double:
		case FontUnderlineType.DoubleAccounting:
			xmlTextWriter_0.WriteAttributeString("style", "text-underline-style", null, "solid");
			xmlTextWriter_0.WriteAttributeString("style", "text-underline-type", null, "double");
			break;
		}
		if (class1501_0.IsSuperscript)
		{
			xmlTextWriter_0.WriteAttributeString("style", "text-position", null, "33% 58%");
		}
		if (class1501_0.IsSubscript)
		{
			xmlTextWriter_0.WriteAttributeString("style", "text-position", null, "-33% 58%");
		}
		xmlTextWriter_0.WriteEndElement();
	}
}
