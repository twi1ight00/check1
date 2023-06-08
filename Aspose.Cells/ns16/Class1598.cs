using System.Globalization;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns22;

namespace ns16;

internal class Class1598
{
	private Class1547 class1547_0;

	private string string_0;

	private string string_1;

	private Worksheet worksheet_0;

	private Class1548 class1548_0;

	private PageSetup pageSetup_0;

	internal Class1598(Class1547 class1547_1, Class1548 class1548_1)
	{
		class1547_0 = class1547_1;
		class1548_0 = class1548_1;
		worksheet_0 = class1548_1.worksheet_0;
		worksheet_0.Charts.Add(new Chart(worksheet_0));
		worksheet_0.Type = SheetType.Chart;
		pageSetup_0 = worksheet_0.Charts[0].PageSetup;
	}

	[Attribute0(true)]
	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_14(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "sheetViews")
				{
					method_12(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "sheetPr")
				{
					method_5(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "pageMargins")
				{
					method_11(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "pageSetup")
				{
					method_8(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "headerFooter")
				{
					method_7(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "legacyDrawing")
				{
					method_6(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "drawing")
				{
					method_4(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "sheetProtection")
				{
					method_3(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "picture")
				{
					method_1(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "customSheetViews")
				{
					method_0(xmlTextReader_0);
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
	}

	[Attribute0(true)]
	private void method_0(XmlTextReader xmlTextReader_0)
	{
		worksheet_0.class1557_0.string_4 = xmlTextReader_0.ReadOuterXml();
	}

	[Attribute0(true)]
	private void method_1(XmlTextReader xmlTextReader_0)
	{
		class1548_0.string_5 = xmlTextReader_0.GetAttribute("id", string_1);
		xmlTextReader_0.Skip();
		if (class1548_0.string_5 == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid Picture r:id element");
		}
	}

	private void method_2()
	{
		Protection protection = worksheet_0.Protection;
		protection.AllowEditingContent = true;
		protection.AllowEditingObject = true;
	}

	[Attribute0(true)]
	private void method_3(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			method_2();
			Protection protection = worksheet_0.Protection;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.NamespaceURI != "")
				{
					continue;
				}
				if (xmlTextReader_0.LocalName == "password")
				{
					protection.method_3(ushort.Parse(xmlTextReader_0.Value, NumberStyles.HexNumber));
				}
				else if (xmlTextReader_0.LocalName == "sheet")
				{
					if (xmlTextReader_0.Value == "0")
					{
						protection.AllowEditingContent = true;
					}
					else
					{
						protection.AllowEditingContent = false;
					}
				}
				else if (xmlTextReader_0.LocalName == "objects")
				{
					if (xmlTextReader_0.Value == "0")
					{
						protection.AllowEditingObject = true;
					}
					else
					{
						protection.AllowEditingObject = false;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_4(XmlTextReader xmlTextReader_0)
	{
		class1548_0.string_4 = xmlTextReader_0.GetAttribute("id", string_1);
		xmlTextReader_0.Skip();
		if (class1548_0.string_4 == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid legacyDrawing element");
		}
	}

	[Attribute0(true)]
	private void method_5(XmlTextReader xmlTextReader_0)
	{
		worksheet_0.class1557_0.string_3 = xmlTextReader_0.GetAttribute("published");
		string attribute = xmlTextReader_0.GetAttribute("codeName");
		if (attribute != null)
		{
			worksheet_0.method_46(attribute);
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "sheetPr")
			{
				xmlTextReader_0.Read();
				while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
				{
					xmlTextReader_0.MoveToContent();
					if (xmlTextReader_0.LocalName == "pageSetUpPr")
					{
						string attribute2 = xmlTextReader_0.GetAttribute("fitToPage");
						if (attribute2 != null && attribute2 == "1")
						{
							pageSetup_0.IsPercentScale = true;
						}
						xmlTextReader_0.Skip();
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				xmlTextReader_0.ReadEndElement();
			}
			else if (xmlTextReader_0.LocalName == "tabColor")
			{
				worksheet_0.internalColor_0 = Class1611.smethod_2(xmlTextReader_0, class1547_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_6(XmlTextReader xmlTextReader_0)
	{
		class1548_0.string_2 = xmlTextReader_0.GetAttribute("id", string_1);
		xmlTextReader_0.Skip();
		if (class1548_0.string_2 == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid legacyDrawing element");
		}
		string text = class1548_0.method_3(class1548_0.string_2);
		if (text[0] == '/')
		{
			worksheet_0.class1557_0.string_2 = "xl" + text.Substring(3);
		}
		else
		{
			worksheet_0.class1557_0.string_2 = "xl" + text.Substring(2);
		}
	}

	[Attribute0(true)]
	private void method_7(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		PageSetup pageSetup = pageSetup_0;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "oddHeader")
				{
					string[] array = smethod_0(xmlTextReader_0.ReadElementString());
					for (int i = 0; i < 3; i++)
					{
						if (array[i] != null)
						{
							pageSetup.SetHeader(i, array[i]);
						}
					}
				}
				else if (xmlTextReader_0.LocalName == "oddFooter")
				{
					string[] array2 = smethod_0(xmlTextReader_0.ReadElementString());
					for (int j = 0; j < 3; j++)
					{
						if (array2[j] != null)
						{
							pageSetup.SetFooter(j, array2[j]);
						}
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

	private static string[] smethod_0(string string_2)
	{
		string[] array = new string[3];
		int num = 1;
		int num2 = 0;
		for (int i = 0; i < string_2.Length; i++)
		{
			if (string_2[i] != '&' || i + 1 >= string_2.Length)
			{
				continue;
			}
			char c = string_2[i + 1];
			if (c <= 'R')
			{
				if (c != 'C')
				{
					if (c != 'L')
					{
						if (c != 'R')
						{
							continue;
						}
						goto IL_005e;
					}
					goto IL_0063;
				}
			}
			else if (c != 'c')
			{
				if (c != 'l')
				{
					if (c != 'r')
					{
						continue;
					}
					goto IL_005e;
				}
				goto IL_0063;
			}
			int num3 = 1;
			goto IL_006b;
			IL_0063:
			num3 = 0;
			goto IL_006b;
			IL_006b:
			if (i - num2 > 0)
			{
				array[num] = string_2.Substring(num2, i - num2);
			}
			num = num3;
			num2 = i + 2;
			continue;
			IL_005e:
			num3 = 2;
			goto IL_006b;
		}
		if (num2 < string_2.Length)
		{
			array[num] = string_2.Substring(num2);
		}
		return array;
	}

	[Attribute0(true)]
	private void method_8(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return;
		}
		PageSetup pageSetup = pageSetup_0;
		method_10(pageSetup);
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (xmlTextReader_0.NamespaceURI != "")
			{
				continue;
			}
			if (xmlTextReader_0.LocalName == "blackAndWhite" && xmlTextReader_0.Value == "1")
			{
				pageSetup.BlackAndWhite = true;
			}
			else if (xmlTextReader_0.LocalName == "cellComments")
			{
				pageSetup.PrintComments = Class1618.smethod_21(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "draft" && xmlTextReader_0.Value == "1")
			{
				pageSetup.PrintDraft = true;
			}
			else if (xmlTextReader_0.LocalName == "errors")
			{
				pageSetup.PrintErrors = Class1618.smethod_23(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "firstPageNumber")
			{
				pageSetup.FirstPageNumber = Class1618.smethod_87(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "fitToHeight")
			{
				pageSetup.FitToPagesTall = Class1618.smethod_87(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "fitToWidth")
			{
				pageSetup.FitToPagesWide = Class1618.smethod_87(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "horizontalDpi")
			{
				method_9(pageSetup, xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "verticalDpi")
			{
				method_9(pageSetup, xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "orientation")
			{
				pageSetup.Orientation = Class1618.smethod_19(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "pageOrder")
			{
				pageSetup.Order = Class1618.smethod_25(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "paperSize")
			{
				pageSetup.PaperSize = (PaperSizeType)Class1618.smethod_87(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "scale")
			{
				int num = Class1618.smethod_87(xmlTextReader_0.Value);
				if (num >= 10 && num <= 400)
				{
					pageSetup.Zoom = num;
				}
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
	}

	private void method_9(PageSetup pageSetup_1, string string_2)
	{
		try
		{
			pageSetup_1.PrintQuality = Class1618.smethod_87(string_2);
		}
		catch
		{
		}
	}

	private void method_10(PageSetup pageSetup_1)
	{
		pageSetup_1.BlackAndWhite = false;
		pageSetup_1.PrintComments = PrintCommentsType.PrintNoComments;
		pageSetup_1.PrintDraft = false;
		pageSetup_1.PrintErrors = PrintErrorsType.PrintErrorsDisplayed;
		pageSetup_1.FirstPageNumber = 1;
		pageSetup_1.FitToPagesTall = 1;
		pageSetup_1.FitToPagesWide = 1;
		pageSetup_1.PrintQuality = 600;
		pageSetup_1.Order = PrintOrderType.DownThenOver;
		pageSetup_1.PaperSize = PaperSizeType.PaperLetter;
		pageSetup_1.Zoom = 100;
	}

	[Attribute0(true)]
	private void method_11(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return;
		}
		PageSetup pageSetup = pageSetup_0;
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (!(xmlTextReader_0.NamespaceURI != ""))
			{
				if (xmlTextReader_0.LocalName == "left")
				{
					pageSetup.LeftMarginInch = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "right")
				{
					pageSetup.RightMarginInch = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "top")
				{
					pageSetup.TopMarginInch = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "bottom")
				{
					pageSetup.BottomMarginInch = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "header")
				{
					pageSetup.HeaderMarginInch = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "footer")
				{
					pageSetup.FooterMarginInch = Class1618.smethod_85(xmlTextReader_0.Value);
				}
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_12(XmlTextReader xmlTextReader_0)
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "sheetView")
				{
					method_13(xmlTextReader_0);
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

	[Attribute0(true)]
	private void method_13(XmlTextReader xmlTextReader_0)
	{
		bool flag = false;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != ""))
				{
					if (xmlTextReader_0.LocalName == "showGridLines")
					{
						worksheet_0.IsGridlinesVisible = Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "showRowColHeaders")
					{
						worksheet_0.IsRowColumnHeadersVisible = Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "tabSelected")
					{
						worksheet_0.IsSelected = Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "view")
					{
						worksheet_0.IsPageBreakPreview = xmlTextReader_0.Value == "pageBreakPreview";
					}
					else if (xmlTextReader_0.LocalName == "zoomScale")
					{
						worksheet_0.Zoom = Class1618.smethod_87(xmlTextReader_0.Value);
						flag = true;
					}
					else if (xmlTextReader_0.LocalName == "topLeftCell")
					{
						string value = xmlTextReader_0.Value;
						int row = 0;
						int column = 0;
						CellsHelper.CellNameToIndex(value, out row, out column);
						worksheet_0.FirstVisibleRow = row;
						worksheet_0.FirstVisibleColumn = column;
					}
					else if (xmlTextReader_0.LocalName == "zoomToFit")
					{
						worksheet_0.Charts[0].SizeWithWindow = Class1618.smethod_201(xmlTextReader_0.Value);
						flag = true;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
			if (!flag)
			{
				worksheet_0.Charts[0].SizeWithWindow = false;
			}
		}
		xmlTextReader_0.Skip();
	}

	private void method_14(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || xmlTextReader_0.LocalName != "chartsheet")
		{
			throw new CellsException(ExceptionType.InvalidData, "chartsheet root element eror");
		}
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add(namespaceURI);
		string_1 = nameTable.Add("http://schemas.openxmlformats.org/officeDocument/2006/relationships");
	}
}
