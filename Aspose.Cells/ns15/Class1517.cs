using System.Collections;
using System.Xml;
using Aspose.Cells;
using ns16;
using ns22;
using ns26;

namespace ns15;

internal class Class1517
{
	private Class1498 class1498_0;

	private Workbook workbook_0;

	private XmlTextWriter xmlTextWriter_0;

	internal Class1517(Class1498 class1498_1)
	{
		class1498_0 = class1498_1;
		workbook_0 = class1498_1.workbook_0;
	}

	internal void Write(ArrayList arrayList_0, Stream6 stream6_0)
	{
		xmlTextWriter_0 = Class1522.smethod_1("settings.xml", stream6_0);
		Class1504 value = new Class1504("text/xml", "settings.xml");
		arrayList_0.Add(value);
		xmlTextWriter_0.WriteStartDocument();
		xmlTextWriter_0.WriteStartElement("office:document-settings");
		xmlTextWriter_0.WriteAttributeString("xmlns", "office", null, "urn:oasis:names:tc:opendocument:xmlns:office:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xlink", null, "http://www.w3.org/1999/xlink");
		xmlTextWriter_0.WriteAttributeString("xmlns", "config", null, "urn:oasis:names:tc:opendocument:xmlns:config:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "ooo", null, "http://openoffice.org/2004/office");
		xmlTextWriter_0.WriteAttributeString("office", "version", null, "1.1");
		xmlTextWriter_0.WriteStartElement("office:settings");
		method_0();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	internal void method_0()
	{
		xmlTextWriter_0.WriteStartElement("config:config-item-set");
		xmlTextWriter_0.WriteAttributeString("config", "name", null, "ooo:view-settings");
		method_1();
		xmlTextWriter_0.WriteEndElement();
	}

	internal void method_1()
	{
		xmlTextWriter_0.WriteStartElement("config:config-item-map-indexed");
		xmlTextWriter_0.WriteAttributeString("config", "name", null, "Views");
		method_2();
		xmlTextWriter_0.WriteEndElement();
	}

	internal void method_2()
	{
		xmlTextWriter_0.WriteStartElement("config:config-item-map-entry");
		method_5("ViewId", "string", "View1");
		method_3();
		Worksheet worksheet = workbook_0.Worksheets[workbook_0.Worksheets.ActiveSheetIndex];
		method_5("ActiveTable", "string", worksheet.Name);
		method_5("ShowPageBreakPreview", "boolean", worksheet.IsPageBreakPreview ? "true" : "false");
		method_5("ShowZeroValues", "boolean", worksheet.DisplayZeros ? "true" : "false");
		method_5("HasColumnRowHeaders", "boolean", worksheet.IsRowColumnHeadersVisible ? "true" : "false");
		method_5("ShowGrid", "boolean", worksheet.IsGridlinesVisible ? "true" : "false");
		if (worksheet.method_42().IsEmpty)
		{
			method_5("GridColor", "long", "12632256");
		}
		else
		{
			method_5("GridColor", "long", Class1516.smethod_13(worksheet.method_42().ToArgb() & 0xFFFFFF));
		}
		method_5("HasSheetTabs", "boolean", workbook_0.Settings.ShowTabs ? "true" : "false");
		method_5("HorizontalScrollbarWidth", "int", Class1516.smethod_13(workbook_0.Settings.SheetTabBarWidth));
		if (worksheet.IsPageBreakPreview)
		{
			method_5("ShowPageBreaks", "boolean", "true");
			method_5("ZoomValue", "int", Class1516.smethod_13(worksheet.Zoom));
			method_5("PageViewZoomValue", "int", Class1516.smethod_13(worksheet.Zoom));
		}
		if (!worksheet.IsOutlineShown)
		{
			method_5("IsOutlineSymbolsSet", "boolean", "false");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	internal void method_3()
	{
		xmlTextWriter_0.WriteStartElement("config:config-item-map-named");
		xmlTextWriter_0.WriteAttributeString("config", "name", null, "Tables");
		for (int i = 0; i < workbook_0.Worksheets.Count; i++)
		{
			method_4(workbook_0.Worksheets[i]);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	internal void method_4(Worksheet worksheet_0)
	{
		xmlTextWriter_0.WriteStartElement("config:config-item-map-entry");
		xmlTextWriter_0.WriteAttributeString("config", "name", null, worksheet_0.Name);
		string activeCell = worksheet_0.ActiveCell;
		if (activeCell != "A1")
		{
			CellsHelper.CellNameToIndex(activeCell, out var row, out var column);
			method_5("CursorPositionX", "int", Class1516.smethod_13(column));
			method_5("CursorPositionY", "int", Class1516.smethod_13(row));
		}
		PaneCollection panes = worksheet_0.GetPanes();
		if (panes != null)
		{
			short short_ = 1;
			if (worksheet_0.method_13())
			{
				short_ = 2;
			}
			if (panes.method_4() == 0)
			{
				method_5("HorizontalSplitMode", "short", Class1516.smethod_14(short_));
				method_5("VerticalSplitMode", "short", "0");
				if (worksheet_0.method_13())
				{
					method_5("HorizontalSplitPosition", "int", Class1516.smethod_13(panes.Column));
				}
				else
				{
					method_5("HorizontalSplitPosition", "int", Class1516.smethod_13((int)((double)((float)(panes.method_6() * 4) / 60f) + 0.5)));
				}
				method_5("VerticalSplitPosition", "int", "0");
				switch (panes.method_0())
				{
				case 1:
					method_5("ActiveSplitRange", "short", "3");
					break;
				case 3:
					method_5("ActiveSplitRange", "short", "2");
					break;
				}
			}
			else if (panes.method_6() == 0)
			{
				method_5("HorizontalSplitMode", "short", "0");
				method_5("VerticalSplitMode", "short", Class1516.smethod_14(short_));
				method_5("HorizontalSplitPosition", "int", "0");
				if (worksheet_0.method_13())
				{
					method_5("VerticalSplitPosition", "int", Class1516.smethod_13(panes.Row));
				}
				else
				{
					method_5("VerticalSplitPosition", "int", Class1516.smethod_13((int)((double)((float)(panes.method_4() * 4) / 60f) + 0.5)));
				}
				switch (panes.method_0())
				{
				case 2:
					method_5("ActiveSplitRange", "short", "2");
					break;
				case 3:
					method_5("ActiveSplitRange", "short", "0");
					break;
				}
			}
			else
			{
				method_5("HorizontalSplitMode", "short", Class1516.smethod_14(short_));
				method_5("VerticalSplitMode", "short", Class1516.smethod_14(short_));
				if (worksheet_0.method_13())
				{
					method_5("HorizontalSplitPosition", "int", Class1516.smethod_13(panes.Column));
					method_5("VerticalSplitPosition", "int", Class1516.smethod_13(panes.Row));
				}
				else
				{
					method_5("HorizontalSplitPosition", "int", Class1516.smethod_13((int)((double)((float)(panes.method_6() * 4) / 60f) + 0.5)));
					method_5("VerticalSplitPosition", "int", Class1516.smethod_13((int)((double)((float)(panes.method_4() * 4) / 60f) + 0.5)));
				}
				switch (panes.method_0())
				{
				case 0:
					method_5("ActiveSplitRange", "short", "3");
					break;
				case 1:
					method_5("ActiveSplitRange", "short", "1");
					break;
				case 2:
					method_5("ActiveSplitRange", "short", "2");
					break;
				case 3:
					method_5("ActiveSplitRange", "short", "0");
					break;
				}
			}
			method_5("PositionLeft", "int", Class1516.smethod_13(worksheet_0.FirstVisibleColumn));
			method_5("PositionTop", "int", Class1516.smethod_13(worksheet_0.FirstVisibleRow));
			if (worksheet_0.method_13())
			{
				method_5("PositionRight", "int", Class1516.smethod_13(worksheet_0.FirstVisibleColumn + panes.method_6()));
				method_5("PositionBottom", "int", Class1516.smethod_13(worksheet_0.FirstVisibleRow + panes.method_4()));
			}
			else
			{
				method_5("PositionRight", "int", Class1516.smethod_13(panes.Column));
				method_5("PositionBottom", "int", Class1516.smethod_13(panes.Row));
			}
		}
		else
		{
			method_5("PositionLeft", "int", Class1516.smethod_13(worksheet_0.FirstVisibleColumn));
			method_5("PositionTop", "int", "0");
			method_5("PositionRight", "int", "0");
			method_5("PositionBottom", "int", Class1516.smethod_13(worksheet_0.FirstVisibleRow));
		}
		method_5("ZoomType", "short", "0");
		method_5("ZoomValue", "int", Class1516.smethod_13(worksheet_0.Zoom));
		method_5("PageViewZoomValue", "int", Class1516.smethod_13(worksheet_0.Zoom));
		method_5("PageViewZoomValue", "boolean", worksheet_0.IsGridlinesVisible ? "1" : "0");
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	internal void method_5(string string_0, string string_1, string string_2)
	{
		xmlTextWriter_0.WriteStartElement("config:config-item");
		xmlTextWriter_0.WriteAttributeString("config", "name", null, string_0);
		xmlTextWriter_0.WriteAttributeString("config", "type", null, string_1);
		xmlTextWriter_0.WriteString(string_2);
		xmlTextWriter_0.WriteEndElement();
	}
}
