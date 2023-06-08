using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using Aspose.Cells;
using ns1;
using ns16;
using ns22;
using ns25;
using ns26;
using ns29;

namespace ns15;

internal class Class1512
{
	private Class1489 class1489_0;

	private Workbook workbook_0;

	private XmlTextReader xmlTextReader_0;

	internal Class1512(Class1489 class1489_1)
	{
		class1489_0 = class1489_1;
		workbook_0 = class1489_0.workbook_0;
	}

	internal void Read(Class746 class746_0)
	{
		Class1129.smethod_1();
		if (class746_0.method_40("settings.xml", bool_18: true) == -1)
		{
			return;
		}
		xmlTextReader_0 = Class1521.smethod_0(class746_0, "settings.xml");
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < 3)
			{
				xmlTextReader_0.Read();
				if (Class536.smethod_4(xmlTextReader_0))
				{
					num++;
					continue;
				}
				break;
			}
			string text;
			if ((text = xmlTextReader_0.LocalName.ToLower()) != null && text == "config-item-set")
			{
				string text2 = null;
				if (xmlTextReader_0.HasAttributes)
				{
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						string localName;
						if ((localName = xmlTextReader_0.LocalName) != null && localName == "name")
						{
							text2 = xmlTextReader_0.Value;
						}
					}
					xmlTextReader_0.MoveToElement();
				}
				if (text2 == null)
				{
					xmlTextReader_0.Skip();
					break;
				}
				if (text2.StartsWith("ooo:"))
				{
					text2 = text2.Substring(4);
				}
				string text3;
				if ((text3 = text2) != null && text3 == "view-settings")
				{
					method_0();
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
			break;
		}
	}

	private void method_0()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName)
			{
			case "config-item-map-indexed":
				method_1();
				break;
			case "config-item":
				method_4();
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
	}

	private void method_1()
	{
		bool flag = false;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if ((localName = xmlTextReader_0.LocalName) != null && localName == "name")
				{
					flag = xmlTextReader_0.Value == "Views";
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (flag && !xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Read();
			if (!Class536.smethod_4(xmlTextReader_0))
			{
				return;
			}
			if (xmlTextReader_0.LocalName != "config-item-map-entry")
			{
				xmlTextReader_0.Skip();
				xmlTextReader_0.ReadEndElement();
				return;
			}
			xmlTextReader_0.Read();
			while (Class536.smethod_4(xmlTextReader_0))
			{
				switch (xmlTextReader_0.LocalName)
				{
				case "config-item-map-named":
					method_2();
					break;
				case "config-item":
					method_4();
					break;
				default:
					xmlTextReader_0.Skip();
					break;
				}
			}
		}
		else
		{
			xmlTextReader_0.Skip();
		}
	}

	private void method_2()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			string localName;
			if ((localName = xmlTextReader_0.LocalName) != null && localName == "config-item-map-entry")
			{
				method_3();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_3()
	{
		Worksheet worksheet = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string text;
				if ((text = xmlTextReader_0.LocalName.ToLower()) != null && text == "name")
				{
					worksheet = workbook_0.Worksheets[xmlTextReader_0.Value];
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		string text2 = null;
		string text3 = null;
		int column = 0;
		int row = 0;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 2;
		int num6 = 0;
		int num7 = 100;
		int zoom = 60;
		int num8 = 0;
		int int_ = 0;
		int num9 = 0;
		int num10 = 0;
		int num11 = -1;
		xmlTextReader_0.Read();
		while (true)
		{
			if (Class536.smethod_4(xmlTextReader_0))
			{
				if (xmlTextReader_0.IsEmptyElement)
				{
					break;
				}
				string localName;
				if ((localName = xmlTextReader_0.LocalName) != null && localName == "config-item")
				{
					if (xmlTextReader_0.HasAttributes)
					{
						while (xmlTextReader_0.MoveToNextAttribute())
						{
							switch (xmlTextReader_0.LocalName.ToLower())
							{
							case "type":
								_ = xmlTextReader_0.Value;
								break;
							case "name":
								text2 = xmlTextReader_0.Value;
								break;
							}
						}
						xmlTextReader_0.MoveToElement();
					}
					text3 = xmlTextReader_0.ReadElementString();
					string key;
					if ((key = text2) == null)
					{
						continue;
					}
					if (Class1742.dictionary_113 == null)
					{
						Class1742.dictionary_113 = new Dictionary<string, int>(15)
						{
							{ "HorizontalSplitMode", 0 },
							{ "VerticalSplitMode", 1 },
							{ "CursorPositionX", 2 },
							{ "CursorPositionY", 3 },
							{ "ActiveSplitRange", 4 },
							{ "HorizontalSplitPosition", 5 },
							{ "VerticalSplitPosition", 6 },
							{ "PositionLeft", 7 },
							{ "PositionRight", 8 },
							{ "PositionTop", 9 },
							{ "PositionBottom", 10 },
							{ "ZoomType", 11 },
							{ "ZoomValue", 12 },
							{ "PageViewZoomValue", 13 },
							{ "ShowGrid", 14 }
						};
					}
					if (Class1742.dictionary_113.TryGetValue(key, out var value))
					{
						switch (value)
						{
						case 0:
							num2 = int.Parse(text3);
							break;
						case 1:
							num = int.Parse(text3);
							break;
						case 2:
							column = int.Parse(text3);
							break;
						case 3:
							row = int.Parse(text3);
							break;
						case 4:
							num5 = int.Parse(text3);
							break;
						case 5:
							num4 = int.Parse(text3);
							break;
						case 6:
							num3 = int.Parse(text3);
							break;
						case 7:
							num8 = int.Parse(text3);
							break;
						case 8:
							int_ = int.Parse(text3);
							break;
						case 9:
							int_ = int.Parse(text3);
							break;
						case 10:
							num10 = int.Parse(text3);
							break;
						case 11:
							num6 = int.Parse(text3);
							break;
						case 12:
							num7 = int.Parse(text3);
							break;
						case 13:
							zoom = num7;
							break;
						case 14:
							num11 = ((text3 == "true") ? 1 : 0);
							break;
						}
					}
				}
				else
				{
					xmlTextReader_0.Skip();
				}
				continue;
			}
			if (num11 != -1)
			{
				worksheet.IsGridlinesVisible = num11 == 1;
			}
			if (num6 != 0)
			{
				worksheet.IsPageBreakPreview = true;
				worksheet.Zoom = zoom;
			}
			else
			{
				worksheet.Zoom = num7;
			}
			if (num == 0 && num2 == 0)
			{
				worksheet.ActiveCell = CellsHelper.CellIndexToName(row, column);
				worksheet.FirstVisibleRow = num10;
				worksheet.FirstVisibleColumn = num8;
				return;
			}
			bool flag = num2 == 1 || num == 1;
			worksheet.method_14(!flag);
			PaneCollection paneCollection = worksheet.method_1();
			if (num2 == 0)
			{
				if (flag)
				{
					paneCollection.Split(num3 * 15, 0, num10, 0);
				}
				else
				{
					int int_2 = num3 - num8 + 1;
					paneCollection.method_9(num3, 0, int_2, 0);
				}
				paneCollection.method_8();
				switch (num5)
				{
				case 2:
					paneCollection.method_1(3);
					break;
				case 3:
					paneCollection.method_1(1);
					break;
				}
			}
			else if (num == 0)
			{
				if (flag)
				{
					paneCollection.Split(0, num4 * 15, 0, int_);
				}
				else
				{
					int int_3 = num4 - num9 + 1;
					paneCollection.method_9(0, num4, 0, int_3);
				}
				paneCollection.method_8();
				switch (num5)
				{
				case 0:
					paneCollection.method_1(3);
					break;
				case 2:
					paneCollection.method_1(2);
					break;
				}
			}
			else
			{
				if (flag)
				{
					paneCollection.Split(num3 * 15, num4 * 15, num10, int_);
				}
				else
				{
					int int_4 = num3 - num8;
					int int_5 = num4 - num9;
					paneCollection.method_9(num3, num4, int_4, int_5);
				}
				paneCollection.method_8();
				switch (num5)
				{
				case 0:
					paneCollection.method_1(3);
					break;
				case 1:
					paneCollection.method_1(1);
					break;
				case 2:
					paneCollection.method_1(2);
					break;
				case 3:
					paneCollection.method_1(0);
					break;
				}
			}
			worksheet.method_34().method_2(CellsHelper.CellIndexToName(row, column));
			return;
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_4()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		string text = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "type":
					_ = xmlTextReader_0.Value;
					break;
				case "name":
					text = xmlTextReader_0.Value;
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		string text2 = xmlTextReader_0.ReadElementString();
		string key;
		if ((key = text) == null)
		{
			return;
		}
		if (Class1742.dictionary_114 == null)
		{
			Class1742.dictionary_114 = new Dictionary<string, int>(14)
			{
				{ "ShowZeroValues", 0 },
				{ "AutoCalculate", 1 },
				{ "VisibleAreaTop", 2 },
				{ "VisibleAreaLeft", 3 },
				{ "VisibleAreaWidth", 4 },
				{ "VisibleAreaHeight", 5 },
				{ "ActiveTable", 6 },
				{ "VerticalScrollbarWidth", 7 },
				{ "HorizontalScrollbarWidth", 8 },
				{ "GridColor", 9 },
				{ "HasSheetTabs", 10 },
				{ "HasColumnRowHeaders", 11 },
				{ "IsOutlineSymbolsSet", 12 },
				{ "ShowGrid", 13 }
			};
		}
		if (!Class1742.dictionary_114.TryGetValue(key, out var value))
		{
			return;
		}
		switch (value)
		{
		case 0:
			if (!(text2 == "true"))
			{
				for (int j = 0; j < workbook_0.Worksheets.Count; j++)
				{
					workbook_0.Worksheets[j].DisplayZeros = false;
				}
			}
			break;
		case 1:
			workbook_0.Settings.CalcMode = ((!(text2 == "true")) ? CalcModeType.Manual : CalcModeType.Automatic);
			break;
		case 6:
		{
			Worksheet worksheet = workbook_0.Worksheets[text2];
			if (worksheet != null)
			{
				workbook_0.Worksheets.ActiveSheetIndex = worksheet.Index;
			}
			break;
		}
		case 7:
			if (text2 == "0")
			{
				workbook_0.Settings.IsVScrollBarVisible = false;
			}
			break;
		case 8:
			if (text2 == "0")
			{
				workbook_0.Settings.IsHScrollBarVisible = false;
			}
			else
			{
				workbook_0.Settings.SheetTabBarWidth = int.Parse(text2);
			}
			break;
		case 9:
		{
			int num = int.Parse(text2);
			if (num != 0)
			{
				Color color_ = Color.FromArgb(num);
				for (int k = 0; k < workbook_0.Worksheets.Count; k++)
				{
					workbook_0.Worksheets[k].method_43(color_);
				}
			}
			break;
		}
		case 10:
			if (text2 != "true")
			{
				workbook_0.Settings.ShowTabs = false;
			}
			break;
		case 11:
			if (!(text2 == "true"))
			{
				for (int m = 0; m < workbook_0.Worksheets.Count; m++)
				{
					workbook_0.Worksheets[m].IsRowColumnHeadersVisible = false;
				}
			}
			break;
		case 12:
			if (!(text2 == "true"))
			{
				for (int l = 0; l < workbook_0.Worksheets.Count; l++)
				{
					workbook_0.Worksheets[l].IsOutlineShown = false;
				}
			}
			break;
		case 13:
			if (!(text2 == "true"))
			{
				for (int i = 0; i < workbook_0.Worksheets.Count; i++)
				{
					workbook_0.Worksheets[i].IsGridlinesVisible = false;
				}
			}
			break;
		case 2:
		case 3:
		case 4:
		case 5:
			break;
		}
	}
}
