using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Properties;
using ns1;
using ns16;
using ns2;
using ns22;
using ns25;
using ns8;

namespace ns50;

internal class Class1630
{
	private static void smethod_0(WorksheetCollection worksheetCollection_0)
	{
		if (Class972.smethod_0() == Enum134.const_0)
		{
			Worksheet worksheet_ = worksheetCollection_0[worksheetCollection_0.Add()];
			Class1677.smethod_36(worksheet_);
		}
	}

	private static void smethod_1(WorksheetCollection worksheetCollection_0)
	{
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			Cells cells = worksheetCollection_0[i].Cells;
			ArrayList mergedCells = cells.MergedCells;
			for (int j = 0; j < mergedCells.Count; j++)
			{
				CellArea cellArea = (CellArea)mergedCells[j];
				int num = cells.method_40(cellArea.StartRow, cellArea.StartColumn);
				if (num == -1)
				{
					num = 15;
				}
				int num2 = num;
				int num3 = num;
				if (cellArea.StartRow != cellArea.EndRow || cellArea.StartColumn != cellArea.EndColumn)
				{
					num2 = cells.method_40(cellArea.EndRow, cellArea.EndColumn);
					if (num2 == -1)
					{
						num2 = 15;
					}
				}
				if (num == num2)
				{
					num3 = num2;
				}
				else
				{
					Style style = worksheetCollection_0.method_45(num);
					Style style2 = worksheetCollection_0.method_45(num2);
					if (style.method_9())
					{
						if (style2.method_9())
						{
							Style style3 = new Style(worksheetCollection_0);
							style3.Copy(style);
							style3.Borders[BorderType.RightBorder].Copy(style2.Borders[BorderType.RightBorder]);
							style3.Borders[BorderType.BottomBorder].Copy(style2.Borders[BorderType.BottomBorder]);
							num3 = worksheetCollection_0.method_59(style3);
						}
						else
						{
							num3 = num;
						}
					}
					else if (style2.method_9())
					{
						num3 = num2;
					}
				}
				if (num3 != num)
				{
					cells.GetCell(cellArea.StartRow, cellArea.StartColumn, bool_2: false).method_37(num3);
				}
			}
		}
	}

	internal static void smethod_2(Workbook workbook_0, Stream stream_0, SaveOptions saveOptions_0)
	{
		smethod_0(workbook_0.Worksheets);
		workbook_0.Worksheets.method_27();
		smethod_1(workbook_0.Worksheets);
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stream_0, Encoding.UTF8);
		bool flag = true;
		bool bool_ = true;
		bool bool_2 = false;
		if (saveOptions_0 != null && saveOptions_0 is SpreadsheetML2003SaveOptions)
		{
			flag = ((SpreadsheetML2003SaveOptions)saveOptions_0).IsIndentedFormatting;
			bool_ = ((SpreadsheetML2003SaveOptions)saveOptions_0).LimitAsXls;
			bool_2 = ((SpreadsheetML2003SaveOptions)saveOptions_0).ExportColumnIndexOfCell;
		}
		if (flag)
		{
			xmlTextWriter.Formatting = Formatting.Indented;
		}
		xmlTextWriter.WriteStartDocument();
		xmlTextWriter.WriteRaw("<?mso-application progid=\"Excel.Sheet\"?>");
		xmlTextWriter.WriteStartElement("Workbook");
		xmlTextWriter.WriteAttributeString("xmlns", "o", null, "urn:schemas-microsoft-com:office:office");
		xmlTextWriter.WriteAttributeString("xmlns", "x", null, "urn:schemas-microsoft-com:office:excel");
		xmlTextWriter.WriteAttributeString("xmlns", "ss", null, "urn:schemas-microsoft-com:office:spreadsheet");
		xmlTextWriter.WriteAttributeString(null, "xmlns", null, "urn:schemas-microsoft-com:office:spreadsheet");
		xmlTextWriter.WriteAttributeString("xmlns", "x2", null, "urn:schemas-microsoft-com:office:excel2");
		xmlTextWriter.WriteAttributeString("xmlns", "html", null, "http://www.w3.org/TR/REC-html40");
		xmlTextWriter.WriteAttributeString("xmlns", "dt", null, "uuid:C2F41010-65B3-11d1-A29F-00AA00C14882");
		smethod_3(xmlTextWriter, workbook_0);
		for (int i = 0; i < workbook_0.Worksheets.Count; i++)
		{
			Worksheet worksheet = workbook_0.Worksheets[i];
			smethod_13(xmlTextWriter, worksheet, workbook_0, flag, bool_, bool_2);
			if (workbook_0.SaveOptions.ClearData)
			{
				worksheet.Cells.Clear();
			}
		}
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Flush();
	}

	private static void smethod_3(XmlTextWriter xmlTextWriter_0, Workbook workbook_0)
	{
		xmlTextWriter_0.WriteStartElement("x:ExcelWorkbook", null);
		xmlTextWriter_0.WriteElementString("x:ActiveSheet", null, XmlConvert.ToString(workbook_0.Worksheets.ActiveSheetIndex));
		if (!workbook_0.Settings.ShowTabs)
		{
			xmlTextWriter_0.WriteElementString("x:HideWorkbookTabs", null, null);
		}
		if (!workbook_0.Settings.IsHScrollBarVisible)
		{
			xmlTextWriter_0.WriteElementString("x:HideHorizontalScrollBar", null, null);
		}
		if (!workbook_0.Settings.IsVScrollBarVisible)
		{
			xmlTextWriter_0.WriteElementString("x:HideVerticalScrollBar", null, null);
		}
		switch (workbook_0.Settings.CalcMode)
		{
		case CalcModeType.AutomaticExceptTable:
			xmlTextWriter_0.WriteElementString("x:Calculation", null, "SemiAutomaticCalculation");
			break;
		case CalcModeType.Manual:
			xmlTextWriter_0.WriteElementString("x:Calculation", null, "ManualCalculation");
			break;
		}
		if (!workbook_0.Settings.RecalculateBeforeSave)
		{
			xmlTextWriter_0.WriteElementString("x:DoNotCalculateBeforeSave", null, null);
		}
		xmlTextWriter_0.WriteEndElement();
		if (workbook_0.Worksheets.BuiltInDocumentProperties.Count != 0)
		{
			xmlTextWriter_0.WriteStartElement("o:DocumentProperties", null);
			foreach (DocumentProperty builtInDocumentProperty in workbook_0.Worksheets.BuiltInDocumentProperties)
			{
				string text = null;
				string name;
				if ((name = builtInDocumentProperty.Name) != null)
				{
					if (Class1742.dictionary_190 == null)
					{
						Class1742.dictionary_190 = new Dictionary<string, int>(21)
						{
							{ "Title", 0 },
							{ "Subject", 1 },
							{ "Author", 2 },
							{ "Keywords", 3 },
							{ "Comments", 4 },
							{ "Last Author", 5 },
							{ "Revision Number", 6 },
							{ "Application Name", 7 },
							{ "Total Editing Time", 8 },
							{ "Last Print Date", 9 },
							{ "Number of Pages", 10 },
							{ "Number of Words", 11 },
							{ "Number of Characters", 12 },
							{ "Category", 13 },
							{ "Format", 14 },
							{ "Manager", 15 },
							{ "Company", 16 },
							{ "HyperlinkBase", 17 },
							{ "Number of Bytes", 18 },
							{ "Number of Lines", 19 },
							{ "Number of Paragraphs", 20 }
						};
					}
					if (Class1742.dictionary_190.TryGetValue(name, out var value))
					{
						switch (value)
						{
						case 0:
							break;
						case 1:
							goto IL_02d2;
						case 2:
							goto IL_02dd;
						case 3:
							goto IL_02e8;
						case 4:
							goto IL_02f3;
						case 5:
							goto IL_02fe;
						case 6:
							goto IL_0306;
						case 7:
							goto IL_030e;
						case 8:
							goto IL_0316;
						case 9:
							goto IL_031e;
						case 10:
							goto IL_0326;
						case 11:
							goto IL_032e;
						case 12:
							goto IL_0336;
						case 13:
							goto IL_033e;
						case 14:
							goto IL_0346;
						case 15:
							goto IL_034e;
						case 16:
							goto IL_0356;
						case 17:
							goto IL_035e;
						case 18:
							goto IL_0366;
						case 19:
							goto IL_036e;
						case 20:
							goto IL_0376;
						default:
							goto IL_037e;
						}
						text = "Title";
						goto IL_0380;
					}
				}
				goto IL_037e;
				IL_02e8:
				text = "Keywords";
				goto IL_0380;
				IL_02dd:
				text = "Author";
				goto IL_0380;
				IL_0380:
				if (text != null && builtInDocumentProperty.Value != null)
				{
					string text2 = builtInDocumentProperty.Value.ToString();
					if (text2 != "")
					{
						xmlTextWriter_0.WriteElementString("o:" + text, null, builtInDocumentProperty.Value.ToString());
					}
				}
				continue;
				IL_02d2:
				text = "Subject";
				goto IL_0380;
				IL_037e:
				text = null;
				goto IL_0380;
				IL_0376:
				text = "Paragraphs";
				goto IL_0380;
				IL_036e:
				text = "Lines";
				goto IL_0380;
				IL_0366:
				text = "Bytes";
				goto IL_0380;
				IL_035e:
				text = "HyperlinkBase";
				goto IL_0380;
				IL_0356:
				text = "Company";
				goto IL_0380;
				IL_034e:
				text = "Manager";
				goto IL_0380;
				IL_0346:
				text = "PresentationFormat";
				goto IL_0380;
				IL_033e:
				text = "Category";
				goto IL_0380;
				IL_0336:
				text = "Characters";
				goto IL_0380;
				IL_032e:
				text = "Words";
				goto IL_0380;
				IL_0326:
				text = "Pages";
				goto IL_0380;
				IL_031e:
				text = "LastPrinted";
				goto IL_0380;
				IL_0316:
				text = "TotalTime";
				goto IL_0380;
				IL_030e:
				text = "AppName";
				goto IL_0380;
				IL_0306:
				text = "Revision";
				goto IL_0380;
				IL_02fe:
				text = "LastAuthor";
				goto IL_0380;
				IL_02f3:
				text = "Description";
				goto IL_0380;
			}
			xmlTextWriter_0.WriteEndElement();
			if (workbook_0.Worksheets.CustomDocumentProperties.Count != 0)
			{
				xmlTextWriter_0.WriteStartElement("o:CustomDocumentProperties", null);
				foreach (DocumentProperty customDocumentProperty in workbook_0.Worksheets.CustomDocumentProperties)
				{
					if (customDocumentProperty.Type != PropertyType.Blob && !(customDocumentProperty.Name.ToUpper() == "_PID_LINKBASE") && !customDocumentProperty.IsLink)
					{
						string text3 = customDocumentProperty.Name.Replace(" ", "_x0020_");
						xmlTextWriter_0.WriteStartElement("o:" + text3, null);
						if (customDocumentProperty.IsLinkedToContent)
						{
							xmlTextWriter_0.WriteAttributeString("link", customDocumentProperty.Source);
						}
						string text4 = null;
						string text5 = null;
						switch (customDocumentProperty.Type)
						{
						case PropertyType.Boolean:
							text4 = "boolean";
							break;
						case PropertyType.DateTime:
							text4 = "dateTime.tz";
							text5 = ((DateTime)customDocumentProperty.Value).ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff", CultureInfo.InvariantCulture);
							break;
						case PropertyType.Double:
							text4 = "float";
							text5 = Class1618.smethod_79(customDocumentProperty.ToDouble());
							break;
						case PropertyType.Number:
							text4 = "float";
							text5 = Class1618.smethod_80(customDocumentProperty.ToInt());
							break;
						}
						if (text4 != null)
						{
							xmlTextWriter_0.WriteAttributeString("dt:dt", null, text4);
						}
						if (text5 == null)
						{
							text5 = customDocumentProperty.Value.ToString();
						}
						xmlTextWriter_0.WriteString(text5);
						xmlTextWriter_0.WriteEndElement();
					}
				}
				xmlTextWriter_0.WriteEndElement();
			}
		}
		smethod_4(xmlTextWriter_0, workbook_0);
		bool flag = false;
		foreach (Name name2 in workbook_0.Worksheets.Names)
		{
			if (name2.RefersTo != null && name2.RefersTo.Length != 0 && name2.SheetIndex == 0)
			{
				if (!flag)
				{
					xmlTextWriter_0.WriteStartElement("ss:Names", null);
					flag = true;
				}
				xmlTextWriter_0.WriteStartElement("ss:NamedRange", null);
				xmlTextWriter_0.WriteAttributeString("ss:Name", null, name2.Text);
				if (name2.IsHidden)
				{
					xmlTextWriter_0.WriteAttributeString("ss:Hidden", null, "1");
				}
				try
				{
					string value2 = Class1619.smethod_5(name2, workbook_0.Worksheets);
					xmlTextWriter_0.WriteAttributeString("ss:RefersTo", null, value2);
				}
				catch
				{
					throw new CellsException(ExceptionType.InvalidData, name2.Text + name2.RefersTo);
				}
				xmlTextWriter_0.WriteEndElement();
			}
		}
		if (flag)
		{
			xmlTextWriter_0.WriteEndElement();
		}
		smethod_20(workbook_0, xmlTextWriter_0);
	}

	[Attribute0(true)]
	private static void smethod_4(XmlTextWriter xmlTextWriter_0, Workbook workbook_0)
	{
		bool flag = false;
		for (int i = 8; i < 64; i++)
		{
			if ((int)workbook_0.Worksheets.method_24().method_0()[i] != Class1631.int_0[i - 8])
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("o:OfficeDocumentSettings");
		xmlTextWriter_0.WriteStartElement("o:Colors");
		for (int j = 8; j < 64; j++)
		{
			if ((int)workbook_0.Worksheets.method_24().method_0()[j] != Class1631.int_0[j - 8])
			{
				int int_ = workbook_0.Worksheets.method_24().method_7(j).ToArgb();
				string text = "#" + Class1025.smethod_7(int_).Substring(2);
				xmlTextWriter_0.WriteStartElement("o:Color");
				xmlTextWriter_0.WriteStartElement("o:Index");
				xmlTextWriter_0.WriteString((j - 8).ToString());
				xmlTextWriter_0.WriteEndElement();
				xmlTextWriter_0.WriteStartElement("o:RGB");
				xmlTextWriter_0.WriteString(text);
				xmlTextWriter_0.WriteEndElement();
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	private static void smethod_5(XmlTextWriter xmlTextWriter_0, Worksheet worksheet_0, Workbook workbook_0)
	{
		xmlTextWriter_0.WriteStartElement("ss:Names", null);
		foreach (Name name in workbook_0.Worksheets.Names)
		{
			if (name.RefersTo != null && (name.RefersTo.Length != 0 || name.method_2() == null) && name.SheetIndex == worksheet_0.Index + 1)
			{
				xmlTextWriter_0.WriteStartElement("ss:NamedRange", null);
				xmlTextWriter_0.WriteAttributeString("ss:Name", null, name.Text);
				if (name.IsHidden)
				{
					xmlTextWriter_0.WriteAttributeString("ss:Hidden", null, "1");
				}
				string value = workbook_0.Worksheets.method_5().method_2(-1, -1, name.method_2(), 0, 0, bool_0: true);
				xmlTextWriter_0.WriteAttributeString("ss:RefersTo", null, value);
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private static void smethod_6(XmlTextWriter xmlTextWriter_0, Worksheet worksheet_0, Workbook workbook_0)
	{
		HorizontalPageBreakCollection horizontalPageBreaks = worksheet_0.HorizontalPageBreaks;
		VerticalPageBreakCollection verticalPageBreaks = worksheet_0.VerticalPageBreaks;
		if (horizontalPageBreaks.Count == 0 && verticalPageBreaks.Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("x:PageBreaks", null);
		if (horizontalPageBreaks.Count != 0)
		{
			xmlTextWriter_0.WriteStartElement("x:RowBreaks", null);
			foreach (HorizontalPageBreak item in horizontalPageBreaks)
			{
				xmlTextWriter_0.WriteStartElement("x:RowBreak", null);
				xmlTextWriter_0.WriteStartElement("x:Row", null);
				xmlTextWriter_0.WriteString(Class1618.smethod_80(item.Row));
				xmlTextWriter_0.WriteEndElement();
				if (item.StartColumn != 1)
				{
					xmlTextWriter_0.WriteStartElement("x:ColStart", null);
					xmlTextWriter_0.WriteString(Class1618.smethod_80(item.StartColumn));
					xmlTextWriter_0.WriteEndElement();
				}
				int num = ((item.EndColumn > 255) ? 255 : item.EndColumn);
				if (num != 255)
				{
					xmlTextWriter_0.WriteStartElement("x:ColEnd", null);
					xmlTextWriter_0.WriteString(Class1618.smethod_80(num));
					xmlTextWriter_0.WriteEndElement();
				}
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		if (verticalPageBreaks.Count != 0)
		{
			xmlTextWriter_0.WriteStartElement("x:ColBreaks", null);
			foreach (VerticalPageBreak item2 in verticalPageBreaks)
			{
				xmlTextWriter_0.WriteStartElement("x:ColBreak", null);
				xmlTextWriter_0.WriteStartElement("x:Column", null);
				xmlTextWriter_0.WriteString(Class1618.smethod_80(item2.Column));
				xmlTextWriter_0.WriteEndElement();
				if (item2.StartRow != 1)
				{
					xmlTextWriter_0.WriteStartElement("x:RowStart", null);
					xmlTextWriter_0.WriteString(Class1618.smethod_80(item2.StartRow));
					xmlTextWriter_0.WriteEndElement();
				}
				int num2 = ((item2.EndRow > 65535) ? 65535 : item2.EndRow);
				if (num2 != 65535)
				{
					xmlTextWriter_0.WriteStartElement("x:RowEnd", null);
					xmlTextWriter_0.WriteString(Class1618.smethod_80(num2));
					xmlTextWriter_0.WriteEndElement();
				}
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private static void smethod_7(XmlTextWriter xmlTextWriter_0, Worksheet worksheet_0, Workbook workbook_0)
	{
		for (int i = 0; i < worksheet_0.Validations.Count; i++)
		{
			Validation validation = worksheet_0.Validations[i];
			string[] array = Class1619.smethod_4(validation, worksheet_0);
			StringBuilder stringBuilder = new StringBuilder();
			xmlTextWriter_0.WriteStartElement("x:DataValidation", null);
			if (validation.AreaList.Count > 0)
			{
				_ = (CellArea)validation.AreaList[0];
			}
			xmlTextWriter_0.WriteStartElement("x:Range", null);
			for (int j = 0; j < validation.AreaList.Count; j++)
			{
				if (j != 0)
				{
					stringBuilder.Append(',');
				}
				CellArea cellArea = (CellArea)validation.AreaList[j];
				stringBuilder.Append('R');
				stringBuilder.Append(cellArea.StartRow + 1);
				stringBuilder.Append('C');
				stringBuilder.Append(cellArea.StartColumn + 1);
				if (cellArea.StartRow != cellArea.EndRow || cellArea.StartColumn != cellArea.EndColumn)
				{
					stringBuilder.Append(':');
					stringBuilder.Append('R');
					stringBuilder.Append(cellArea.EndRow + 1);
					stringBuilder.Append('C');
					stringBuilder.Append(cellArea.EndColumn + 1);
				}
			}
			xmlTextWriter_0.WriteString(stringBuilder.ToString());
			xmlTextWriter_0.WriteEndElement();
			if (validation.Type != 0)
			{
				xmlTextWriter_0.WriteStartElement("x:Type", null);
				switch (validation.Type)
				{
				case Aspose.Cells.ValidationType.AnyValue:
					xmlTextWriter_0.WriteString("AnyValue");
					break;
				case Aspose.Cells.ValidationType.WholeNumber:
					xmlTextWriter_0.WriteString("Whole");
					break;
				case Aspose.Cells.ValidationType.Decimal:
					xmlTextWriter_0.WriteString("Decimal");
					break;
				case Aspose.Cells.ValidationType.List:
					xmlTextWriter_0.WriteString("List");
					break;
				case Aspose.Cells.ValidationType.Date:
					xmlTextWriter_0.WriteString("Date");
					break;
				case Aspose.Cells.ValidationType.Time:
					xmlTextWriter_0.WriteString("Time");
					break;
				case Aspose.Cells.ValidationType.TextLength:
					xmlTextWriter_0.WriteString("TextLength");
					break;
				case Aspose.Cells.ValidationType.Custom:
					xmlTextWriter_0.WriteString("Custom");
					break;
				}
				xmlTextWriter_0.WriteEndElement();
			}
			if (validation.Type == Aspose.Cells.ValidationType.List)
			{
				if (array[0] != null && array[0].EndsWith("\"") && (array[0].StartsWith("\"") || array[0].StartsWith("=\"")))
				{
					xmlTextWriter_0.WriteStartElement("CellRangeList");
					xmlTextWriter_0.WriteEndElement();
				}
				if (array[0] != null)
				{
					xmlTextWriter_0.WriteStartElement("x:Value", null);
					string text = array[0];
					if (text[0] == '=')
					{
						text = text.Substring(1);
					}
					if (text[0] == '"' && text[text.Length - 1] == '"')
					{
						text = text.Replace('\0', ',');
					}
					xmlTextWriter_0.WriteString(text);
					xmlTextWriter_0.WriteEndElement();
				}
			}
			else
			{
				if (validation.Operator != OperatorType.None)
				{
					xmlTextWriter_0.WriteStartElement("x:Qualifier", null);
					switch (validation.Operator)
					{
					case OperatorType.Between:
						xmlTextWriter_0.WriteString("Between");
						break;
					case OperatorType.Equal:
						xmlTextWriter_0.WriteString("Equal");
						break;
					case OperatorType.GreaterThan:
						xmlTextWriter_0.WriteString("Greater");
						break;
					case OperatorType.GreaterOrEqual:
						xmlTextWriter_0.WriteString("GreaterOrEqual");
						break;
					case OperatorType.LessThan:
						xmlTextWriter_0.WriteString("Less");
						break;
					case OperatorType.LessOrEqual:
						xmlTextWriter_0.WriteString("LessOrEqual");
						break;
					case OperatorType.NotBetween:
						xmlTextWriter_0.WriteString("NotBetween");
						break;
					case OperatorType.NotEqual:
						xmlTextWriter_0.WriteString("NotEqual");
						break;
					}
					xmlTextWriter_0.WriteEndElement();
				}
				if ((validation.Operator == OperatorType.Between || validation.Operator == OperatorType.NotBetween) && array[0] != null)
				{
					xmlTextWriter_0.WriteStartElement("x:Min", null);
					string text2 = array[0];
					if (text2[0] == '=')
					{
						text2 = text2.Substring(1);
					}
					xmlTextWriter_0.WriteString(text2);
					xmlTextWriter_0.WriteEndElement();
				}
				if ((validation.Operator == OperatorType.Between || validation.Operator == OperatorType.NotBetween) && validation.Formula2 != null)
				{
					xmlTextWriter_0.WriteStartElement("x:Max", null);
					string text3 = array[1];
					if (text3[0] == '=')
					{
						text3 = text3.Substring(1);
					}
					xmlTextWriter_0.WriteString(text3);
					xmlTextWriter_0.WriteEndElement();
				}
				if (validation.Operator != 0 && validation.Operator != OperatorType.NotBetween && array[0] != null)
				{
					xmlTextWriter_0.WriteStartElement("x:Value", null);
					string text4 = array[0];
					if (text4[0] == '=')
					{
						text4 = text4.Substring(1);
					}
					xmlTextWriter_0.WriteString(text4);
					xmlTextWriter_0.WriteEndElement();
				}
			}
			if (!validation.IgnoreBlank)
			{
				xmlTextWriter_0.WriteStartElement("x:UseBlank", null);
				xmlTextWriter_0.WriteEndElement();
			}
			if (!validation.InCellDropDown)
			{
				xmlTextWriter_0.WriteStartElement("x:ComboHide", null);
				xmlTextWriter_0.WriteEndElement();
			}
			if (validation.method_5() != 0)
			{
				xmlTextWriter_0.WriteStartElement("x:IMEMode", null);
				switch (validation.method_5())
				{
				case Enum228.const_1:
					xmlTextWriter_0.WriteString("1");
					break;
				case Enum228.const_2:
					xmlTextWriter_0.WriteString("2");
					break;
				}
				xmlTextWriter_0.WriteEndElement();
			}
			if (!validation.ShowInput)
			{
				xmlTextWriter_0.WriteStartElement("x:InputHide", null);
				xmlTextWriter_0.WriteEndElement();
			}
			if (!Class1619.smethod_15(validation.InputTitle))
			{
				xmlTextWriter_0.WriteStartElement("x:InputTitle", null);
				xmlTextWriter_0.WriteString(validation.InputTitle);
				xmlTextWriter_0.WriteEndElement();
			}
			if (!Class1619.smethod_15(validation.InputMessage))
			{
				xmlTextWriter_0.WriteStartElement("x:InputMessage", null);
				xmlTextWriter_0.WriteString(validation.InputMessage);
				xmlTextWriter_0.WriteEndElement();
			}
			if (!validation.ShowError)
			{
				xmlTextWriter_0.WriteStartElement("x:ErrorHide", null);
				xmlTextWriter_0.WriteEndElement();
			}
			if (validation.AlertStyle != ValidationAlertType.Stop)
			{
				xmlTextWriter_0.WriteStartElement("x:ErrorStyle", null);
				switch (validation.AlertStyle)
				{
				case ValidationAlertType.Information:
					xmlTextWriter_0.WriteString("Info");
					break;
				case ValidationAlertType.Warning:
					xmlTextWriter_0.WriteString("Warn");
					break;
				}
				xmlTextWriter_0.WriteEndElement();
			}
			if (!Class1619.smethod_15(validation.ErrorMessage))
			{
				xmlTextWriter_0.WriteStartElement("x:ErrorMessage", null);
				xmlTextWriter_0.WriteString(validation.ErrorMessage);
				xmlTextWriter_0.WriteEndElement();
			}
			if (!Class1619.smethod_15(validation.ErrorTitle))
			{
				xmlTextWriter_0.WriteStartElement("x:ErrorTitle", null);
				xmlTextWriter_0.WriteString(validation.ErrorTitle);
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private static void smethod_8(XmlTextWriter xmlTextWriter_0, Worksheet worksheet_0, Workbook workbook_0)
	{
		xmlTextWriter_0.WriteStartElement("WorksheetOptions", null);
		xmlTextWriter_0.WriteAttributeString("xmlns", null, null, "urn:schemas-microsoft-com:office:excel");
		if (!worksheet_0.IsVisible)
		{
			xmlTextWriter_0.WriteStartElement("Visible", null);
			xmlTextWriter_0.WriteString("SheetHidden");
			xmlTextWriter_0.WriteEndElement();
		}
		if (!worksheet_0.IsRowColumnHeadersVisible)
		{
			xmlTextWriter_0.WriteStartElement("DoNotDisplayHeadings", null);
			xmlTextWriter_0.WriteEndElement();
		}
		if (worksheet_0.Zoom != 100)
		{
			xmlTextWriter_0.WriteStartElement("Zoom", null);
			xmlTextWriter_0.WriteString(Class1618.smethod_80(worksheet_0.Zoom));
			xmlTextWriter_0.WriteEndElement();
		}
		PageSetup pageSetup = worksheet_0.PageSetup;
		xmlTextWriter_0.WriteStartElement("PageSetup", null);
		if (pageSetup.Orientation != PageOrientationType.Portrait || pageSetup.CenterHorizontally || pageSetup.CenterVertically || !pageSetup.IsAutoFirstPageNumber)
		{
			xmlTextWriter_0.WriteStartElement("Layout", null);
			if (pageSetup.Orientation != PageOrientationType.Portrait)
			{
				xmlTextWriter_0.WriteAttributeString("x:Orientation", null, "Landscape");
			}
			if (pageSetup.CenterHorizontally)
			{
				xmlTextWriter_0.WriteAttributeString("x:CenterHorizontal", null, "1");
			}
			if (pageSetup.CenterVertically)
			{
				xmlTextWriter_0.WriteAttributeString("x:CenterVertical", null, "1");
			}
			if (!pageSetup.IsAutoFirstPageNumber)
			{
				xmlTextWriter_0.WriteAttributeString("x:StartPageNumber", null, Class1618.smethod_80(pageSetup.FirstPageNumber));
			}
			xmlTextWriter_0.WriteEndElement();
		}
		string header = pageSetup.GetHeader(0);
		string header2 = pageSetup.GetHeader(1);
		string header3 = pageSetup.GetHeader(2);
		if (pageSetup.HeaderMargin != 1.27 || (header != null && header.Length > 0) || (header2 != null && header2.Length > 0) || (header3 != null && header3.Length > 0))
		{
			xmlTextWriter_0.WriteStartElement("Header", null);
			if (pageSetup.HeaderMargin != 1.27)
			{
				xmlTextWriter_0.WriteAttributeString("x:Margin", null, Class1618.smethod_79(pageSetup.HeaderMargin / 2.54));
			}
			if ((header != null && header.Length > 0) || (header2 != null && header2.Length > 0) || (header3 != null && header3.Length > 0))
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (header != null)
				{
					stringBuilder.Append(header);
				}
				if (header2 != null)
				{
					stringBuilder.Append(header2);
				}
				if (header3 != null)
				{
					stringBuilder.Append(header3);
				}
				xmlTextWriter_0.WriteAttributeString("x:Data", null, stringBuilder.ToString());
			}
			xmlTextWriter_0.WriteEndElement();
		}
		header = pageSetup.GetFooter(0);
		header2 = pageSetup.GetFooter(1);
		header3 = pageSetup.GetFooter(2);
		if (pageSetup.FooterMargin != 1.27 || (header != null && header.Length > 0) || (header2 != null && header2.Length > 0) || (header3 != null && header3.Length > 0))
		{
			xmlTextWriter_0.WriteStartElement("Footer", null);
			if (pageSetup.FooterMargin != 1.27)
			{
				xmlTextWriter_0.WriteAttributeString("x:Margin", null, Class1618.smethod_79(pageSetup.FooterMargin / 2.54));
			}
			if ((header != null && header.Length > 0) || (header2 != null && header2.Length > 0) || (header3 != null && header3.Length > 0))
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				if (header != null)
				{
					stringBuilder2.Append(header);
				}
				if (header2 != null)
				{
					stringBuilder2.Append(header2);
				}
				if (header3 != null)
				{
					stringBuilder2.Append(header3);
				}
				xmlTextWriter_0.WriteAttributeString("x:Data", null, stringBuilder2.ToString());
			}
			xmlTextWriter_0.WriteEndElement();
		}
		if (pageSetup.TopMargin != 2.54 || pageSetup.BottomMargin != 2.54 || pageSetup.LeftMargin != 1.905 || pageSetup.RightMargin != 1.905)
		{
			xmlTextWriter_0.WriteStartElement("PageMargins", null);
			if (pageSetup.TopMargin != 2.54)
			{
				xmlTextWriter_0.WriteAttributeString("x:Top", null, Class1618.smethod_79(pageSetup.TopMargin / 2.54));
			}
			if (pageSetup.BottomMargin != 2.54)
			{
				xmlTextWriter_0.WriteAttributeString("x:Bottom", null, Class1618.smethod_79(pageSetup.BottomMargin / 2.54));
			}
			if (pageSetup.LeftMargin != 1.905)
			{
				xmlTextWriter_0.WriteAttributeString("x:Left", null, Class1618.smethod_79(pageSetup.LeftMargin / 2.54));
			}
			if (pageSetup.RightMargin != 1.905)
			{
				xmlTextWriter_0.WriteAttributeString("x:Right", null, Class1618.smethod_79(pageSetup.RightMargin / 2.54));
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
		if (!pageSetup.IsPercentScale)
		{
			xmlTextWriter_0.WriteStartElement("FitToPage", null);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteStartElement("Print", null);
		if (pageSetup.method_13())
		{
			xmlTextWriter_0.WriteElementString("ValidPrinterInfo", null);
		}
		if (pageSetup.FitToPagesWide != 1)
		{
			xmlTextWriter_0.WriteStartElement("FitWidth", null);
			xmlTextWriter_0.WriteString(Class1618.smethod_80(pageSetup.FitToPagesWide));
			xmlTextWriter_0.WriteEndElement();
		}
		if (pageSetup.FitToPagesTall != 1)
		{
			xmlTextWriter_0.WriteStartElement("FitHeight", null);
			xmlTextWriter_0.WriteString(Class1618.smethod_80(pageSetup.FitToPagesTall));
			xmlTextWriter_0.WriteEndElement();
		}
		if (pageSetup.Order == PrintOrderType.OverThenDown)
		{
			xmlTextWriter_0.WriteStartElement("LeftToRight", null);
			xmlTextWriter_0.WriteEndElement();
		}
		if (pageSetup.BlackAndWhite)
		{
			xmlTextWriter_0.WriteStartElement("BlackAndWhite", null);
			xmlTextWriter_0.WriteEndElement();
		}
		if (pageSetup.PrintDraft)
		{
			xmlTextWriter_0.WriteStartElement("DraftQuality", null);
			xmlTextWriter_0.WriteEndElement();
		}
		if (pageSetup.PrintComments != PrintCommentsType.PrintNoComments)
		{
			xmlTextWriter_0.WriteStartElement("CommentsLayout", null);
			if (pageSetup.PrintComments == PrintCommentsType.PrintSheetEnd)
			{
				xmlTextWriter_0.WriteString("SheetEnd");
			}
			else if (pageSetup.PrintComments == PrintCommentsType.PrintInPlace)
			{
				xmlTextWriter_0.WriteString("InPlace");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		if (pageSetup.PrintErrors != PrintErrorsType.PrintErrorsDisplayed)
		{
			xmlTextWriter_0.WriteStartElement("PrintErrors", null);
			switch (pageSetup.PrintErrors)
			{
			case PrintErrorsType.PrintErrorsBlank:
				xmlTextWriter_0.WriteString("Blank");
				break;
			case PrintErrorsType.PrintErrorsDash:
				xmlTextWriter_0.WriteString("Dash");
				break;
			case PrintErrorsType.PrintErrorsNA:
				xmlTextWriter_0.WriteString("NA");
				break;
			}
			xmlTextWriter_0.WriteEndElement();
		}
		if (pageSetup.Zoom != 100)
		{
			xmlTextWriter_0.WriteStartElement("Scale", null);
			xmlTextWriter_0.WriteString(Class1618.smethod_80(pageSetup.Zoom));
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteStartElement("PaperSizeIndex", null);
		PaperSizeType paperSize = pageSetup.PaperSize;
		if (paperSize == PaperSizeType.PaperLetter)
		{
			xmlTextWriter_0.WriteString("119");
		}
		else
		{
			xmlTextWriter_0.WriteString(Class1618.smethod_80((int)pageSetup.PaperSize));
		}
		xmlTextWriter_0.WriteEndElement();
		int num = pageSetup.PrintQuality;
		if (num != 300)
		{
			if (num < 0)
			{
				num = 600;
			}
			xmlTextWriter_0.WriteStartElement("HorizontalResolution", null);
			xmlTextWriter_0.WriteString(Class1618.smethod_80(num));
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("VerticalResolution", null);
			xmlTextWriter_0.WriteString(Class1618.smethod_80(num));
			xmlTextWriter_0.WriteEndElement();
		}
		if (pageSetup.PrintGridlines)
		{
			xmlTextWriter_0.WriteStartElement("Gridlines", null);
			xmlTextWriter_0.WriteEndElement();
		}
		if (pageSetup.PrintHeadings)
		{
			xmlTextWriter_0.WriteStartElement("RowColHeadings", null);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
		if (!worksheet_0.IsGridlinesVisible)
		{
			xmlTextWriter_0.WriteStartElement("DoNotDisplayGridlines", null);
			xmlTextWriter_0.WriteEndElement();
		}
		if (!worksheet_0.DisplayZeros)
		{
			xmlTextWriter_0.WriteStartElement("DoNotDisplayZeros", null);
			xmlTextWriter_0.WriteEndElement();
		}
		if (worksheet_0.method_41() != -1 && worksheet_0.method_41() < 64)
		{
			xmlTextWriter_0.WriteStartElement("TabColorIndex", null);
			xmlTextWriter_0.WriteString(Class1618.smethod_80(worksheet_0.method_41()));
			xmlTextWriter_0.WriteEndElement();
		}
		smethod_9(xmlTextWriter_0, worksheet_0);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private static void smethod_9(XmlTextWriter xmlTextWriter_0, Worksheet worksheet_0)
	{
		if (worksheet_0.FirstVisibleRow != 0)
		{
			xmlTextWriter_0.WriteElementString("TopRowVisible", Class1618.smethod_80(worksheet_0.FirstVisibleRow));
		}
		if (worksheet_0.FirstVisibleColumn != 0)
		{
			xmlTextWriter_0.WriteElementString("LeftColumnVisible", Class1618.smethod_80(worksheet_0.FirstVisibleColumn));
		}
		if (worksheet_0.GetPanes() != null)
		{
			PaneCollection paneCollection = worksheet_0.method_1();
			if (worksheet_0.method_13() && 0 == 0)
			{
				xmlTextWriter_0.WriteElementString("FreezePanes", null);
				xmlTextWriter_0.WriteElementString("FrozenNoSplit", null);
			}
			if ((double)paneCollection.method_4() != 0.0)
			{
				xmlTextWriter_0.WriteElementString("SplitHorizontal", Class1618.smethod_80(paneCollection.method_4()));
				xmlTextWriter_0.WriteElementString("TopRowBottomPane", Class1618.smethod_80(paneCollection.Row));
			}
			if ((double)paneCollection.method_6() != 0.0)
			{
				xmlTextWriter_0.WriteElementString("SplitVertical", Class1618.smethod_80(paneCollection.method_6()));
				xmlTextWriter_0.WriteElementString("LeftColumnRightPane", Class1618.smethod_80(paneCollection.Column));
			}
			xmlTextWriter_0.WriteElementString("ActivePane", Class1618.smethod_84(paneCollection.method_0()));
		}
		if (worksheet_0.method_34() == null || worksheet_0.method_34().Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("Panes");
		for (int i = 0; i < worksheet_0.method_34().Count; i++)
		{
			Class1732 @class = (Class1732)worksheet_0.method_34()[i];
			xmlTextWriter_0.WriteStartElement("Pane");
			xmlTextWriter_0.WriteElementString("Number", Class1618.smethod_84(@class.method_1()));
			if (@class.method_5() != 0)
			{
				xmlTextWriter_0.WriteElementString("ActiveRow", Class1618.smethod_80(@class.method_5()));
			}
			if (@class.method_7() != 0)
			{
				xmlTextWriter_0.WriteElementString("ActiveCol", Class1618.smethod_80(@class.method_7()));
			}
			string value = Class1618.smethod_31(@class.method_3(), 0, @class.method_3().Count);
			xmlTextWriter_0.WriteElementString("RangeSelection", value);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private static Class1371 smethod_10(Cells cells_0, int int_0, int int_1, ArrayList arrayList_0, int int_2)
	{
		bool flag = false;
		Hyperlink hyperlink = null;
		Comment comment = null;
		Cell cell = cells_0.CheckCell(int_0, int_1);
		if (int_2 < arrayList_0.Count)
		{
			Struct88 @struct = (Struct88)arrayList_0[int_2];
			if (@struct.int_0 == int_0 && @struct.int_1 == int_1)
			{
				flag = true;
			}
		}
		HyperlinkCollection hyperlinks = cells_0.method_3().Hyperlinks;
		for (int i = 0; i < hyperlinks.Count; i++)
		{
			Hyperlink hyperlink2 = cells_0.method_3().Hyperlinks[i];
			if (hyperlink2.Area.StartColumn <= int_1 && int_1 <= hyperlink2.Area.EndColumn && hyperlink2.Area.StartRow <= int_0 && int_0 <= hyperlink2.Area.EndRow)
			{
				hyperlink = hyperlink2;
				break;
			}
		}
		CommentCollection comments = cells_0.method_3().Comments;
		for (int j = 0; j < comments.Count; j++)
		{
			Comment comment2 = comments[j];
			if (comment2.Row == int_0 && comment2.Column == int_1)
			{
				comment = comment2;
				break;
			}
		}
		if (!flag && cell == null && hyperlink == null && comment == null)
		{
			return null;
		}
		Class1371 @class = new Class1371();
		@class.bool_0 = flag;
		if (flag)
		{
			@class.struct88_0 = (Struct88)arrayList_0[int_2];
		}
		@class.cell_0 = cell;
		@class.hyperlink_0 = hyperlink;
		@class.comment_0 = comment;
		return @class;
	}

	private static bool smethod_11(Worksheet worksheet_0, Row row_0, int int_0, ArrayList arrayList_0, int int_1)
	{
		if (row_0 != null)
		{
			if (row_0.method_0() != 0)
			{
				return true;
			}
			if (row_0.method_27() || row_0.IsHidden || row_0.InnerHeight != worksheet_0.Cells.StandardHeight)
			{
				return true;
			}
		}
		for (int i = int_1; i < arrayList_0.Count; i++)
		{
			Struct88 @struct = (Struct88)arrayList_0[int_1];
			if (@struct.int_0 != int_0)
			{
				if (@struct.int_0 > int_0)
				{
					break;
				}
				continue;
			}
			return true;
		}
		HyperlinkCollection hyperlinks = worksheet_0.Hyperlinks;
		int num = 0;
		while (true)
		{
			if (num < hyperlinks.Count)
			{
				Hyperlink hyperlink = hyperlinks[num];
				if (hyperlink.Area.StartRow <= int_0 && hyperlink.Area.EndRow >= int_0)
				{
					break;
				}
				num++;
				continue;
			}
			CommentCollection comments = worksheet_0.Comments;
			int num2 = 0;
			while (true)
			{
				if (num2 < comments.Count)
				{
					Comment comment = comments[num2];
					if (comment.Row == int_0)
					{
						break;
					}
					num2++;
					continue;
				}
				return false;
			}
			return true;
		}
		return true;
	}

	private static void smethod_12(Worksheet worksheet, ArrayList mergeAreas, bool isTotal, bool limitAsXls, out int maxRow, out int maxColumn)
	{
		maxRow = -1;
		if (worksheet.Cells.Rows.Count > 0)
		{
			maxRow = worksheet.Cells.Rows.GetRowByIndex(worksheet.Cells.Rows.Count - 1).int_0;
		}
		maxColumn = worksheet.Cells.method_22(0);
		for (int i = 0; i < mergeAreas.Count; i++)
		{
			Struct88 @struct = (Struct88)mergeAreas[i];
			if (isTotal)
			{
				if (@struct.int_2 > maxRow)
				{
					maxRow = @struct.int_2;
				}
				if (@struct.int_3 > maxColumn)
				{
					maxColumn = @struct.int_3;
				}
			}
			else
			{
				if (@struct.int_0 > maxRow)
				{
					maxRow = @struct.int_0;
				}
				if (@struct.int_1 > maxColumn)
				{
					maxColumn = @struct.int_1;
				}
			}
		}
		HyperlinkCollection hyperlinks = worksheet.Hyperlinks;
		for (int j = 0; j < hyperlinks.Count; j++)
		{
			Hyperlink hyperlink = hyperlinks[j];
			if (hyperlink.Area.EndRow > maxRow)
			{
				maxRow = hyperlink.Area.EndRow;
			}
			if (hyperlink.Area.EndColumn > maxColumn)
			{
				maxColumn = hyperlink.Area.EndColumn;
			}
		}
		CommentCollection comments = worksheet.Comments;
		for (int k = 0; k < comments.Count; k++)
		{
			Comment comment = comments[k];
			if (comment.Row > maxRow)
			{
				maxRow = comment.Row;
			}
			if (comment.Column > maxColumn)
			{
				maxColumn = comment.Column;
			}
		}
		if (limitAsXls && maxColumn > 255)
		{
			maxColumn = 255;
		}
	}

	private static void smethod_13(XmlTextWriter xmlTextWriter_0, Worksheet worksheet_0, Workbook workbook_0, bool bool_0, bool bool_1, bool bool_2)
	{
		xmlTextWriter_0.WriteStartElement("Worksheet");
		xmlTextWriter_0.WriteAttributeString("ss:Name", null, worksheet_0.Name);
		Cells cells = worksheet_0.Cells;
		if (bool_1)
		{
			cells.method_6();
		}
		if (worksheet_0.method_0() != null && !worksheet_0.Protection.AllowEditingObject)
		{
			xmlTextWriter_0.WriteAttributeString("ss:Protected", null, "1");
		}
		smethod_5(xmlTextWriter_0, worksheet_0, workbook_0);
		xmlTextWriter_0.WriteStartElement("ss:Table", null);
		Class1133 @class = worksheet_0.Cells.method_18();
		ArrayList arrayList = new ArrayList(@class.Count);
		for (int i = 0; i < @class.Count; i++)
		{
			arrayList.Add(new Struct88(@class[i]));
		}
		arrayList.Sort();
		smethod_19(xmlTextWriter_0, worksheet_0, workbook_0, arrayList, bool_1);
		int num = -1;
		Struct88 @struct = default(Struct88);
		Hashtable hashtable = new Hashtable();
		int num2 = 0;
		int maxRow = -1;
		int maxColumn = -1;
		smethod_12(worksheet_0, arrayList, isTotal: false, bool_1, out maxRow, out maxColumn);
		int num3 = 0;
		RowCollection rows = cells.Rows;
		for (int j = 0; j <= maxRow; j++)
		{
			Row row = null;
			if (num3 < rows.Count)
			{
				Row rowByIndex = rows.GetRowByIndex(num3);
				int int_ = rowByIndex.int_0;
				if (int_ == j)
				{
					num3++;
					row = rowByIndex;
				}
			}
			if (!smethod_11(worksheet_0, row, j, arrayList, num2))
			{
				continue;
			}
			xmlTextWriter_0.WriteStartElement("Row", null);
			xmlTextWriter_0.WriteAttributeString("ss:Index", null, Class1618.smethod_80(j + 1));
			if (row != null)
			{
				double innerHeight = row.InnerHeight;
				if (innerHeight != cells.StandardHeight)
				{
					xmlTextWriter_0.WriteAttributeString("ss:Height", null, Class1618.smethod_79(innerHeight));
				}
				if (row.method_27())
				{
					xmlTextWriter_0.WriteAttributeString("ss:StyleID", null, "S" + Class1618.smethod_80(row.method_10()));
				}
				if (row.IsHidden)
				{
					xmlTextWriter_0.WriteAttributeString("ss:Hidden", null, "1");
				}
			}
			num = -1;
			for (int k = 0; k <= maxColumn; k++)
			{
				if (hashtable[k] != null)
				{
					Struct88 struct2 = (Struct88)hashtable[k];
					if (j > struct2.int_2)
					{
						hashtable.Remove(k);
					}
					else if (j <= struct2.int_2 && j >= struct2.int_0)
					{
						k = struct2.int_3;
						continue;
					}
				}
				Class1371 class2 = smethod_10(cells, j, k, arrayList, num2);
				if (class2 == null)
				{
					continue;
				}
				xmlTextWriter_0.WriteStartElement("Cell", null);
				if (bool_2 || k - num > 1)
				{
					xmlTextWriter_0.WriteAttributeString("ss:Index", null, Class1618.smethod_80(k + 1));
				}
				num = k;
				if (class2.bool_0)
				{
					@struct = class2.struct88_0;
					hashtable[k] = @struct;
					xmlTextWriter_0.WriteAttributeString("ss:MergeAcross", null, Class1618.smethod_80(@struct.int_3 - k));
					k = @struct.int_3;
					xmlTextWriter_0.WriteAttributeString("ss:MergeDown", null, Class1618.smethod_80(@struct.int_2 - j));
					num2++;
				}
				int num4 = 15;
				int num5 = -1;
				if (class2.cell_0 != null)
				{
					num4 = class2.cell_0.method_35();
					num5 = class2.cell_0.method_36();
				}
				bool flag = false;
				if (num4 != 15)
				{
					bool flag2 = false;
					int num6 = cells.Rows.GetRow(j, bool_0: false, bool_1: false).method_10();
					if (num6 != 15 && num6 != 4095 && num6 > 0)
					{
						flag2 = true;
					}
					if (flag2)
					{
						if (num4 != num6)
						{
							flag = true;
						}
					}
					else
					{
						int num7 = cells.Columns[(byte)k].method_5();
						if (num4 != num7)
						{
							flag = true;
						}
					}
				}
				else if (num5 == 15)
				{
					if (cells.Rows.GetRow(j, bool_0: false, bool_1: false).method_27())
					{
						flag = true;
					}
					if (!flag)
					{
						flag = cells.Columns[(byte)k].method_10();
					}
				}
				if (flag)
				{
					if (num5 == 15)
					{
						xmlTextWriter_0.WriteAttributeString("ss:StyleID", null, "Default");
					}
					else
					{
						xmlTextWriter_0.WriteAttributeString("ss:StyleID", null, "S" + num4);
					}
				}
				if (class2.hyperlink_0 != null)
				{
					string text = class2.hyperlink_0.Address;
					if (class2.hyperlink_0.method_5(worksheet_0.method_2()) == 2)
					{
						text = "#" + text;
					}
					xmlTextWriter_0.WriteAttributeString("ss:HRef", null, text);
					if (class2.hyperlink_0.ScreenTip != null && class2.hyperlink_0.ScreenTip != "")
					{
						xmlTextWriter_0.WriteAttributeString("x:HRefScreenTip", null, class2.hyperlink_0.ScreenTip);
					}
				}
				if (class2.cell_0 != null)
				{
					Cell cell_ = class2.cell_0;
					string text2 = "String";
					string text3 = null;
					switch (cell_.Type)
					{
					case CellValueType.IsBool:
						text2 = "Boolean";
						text3 = (cell_.BoolValue ? "1" : "0");
						break;
					case CellValueType.IsDateTime:
						if (cell_.DoubleValue < 0.0)
						{
							text2 = "Number";
							text3 = Class1618.smethod_79(cell_.DoubleValue);
						}
						else
						{
							text2 = "DateTime";
							text3 = cell_.DateTimeValue.ToString("yyyy-MM-dd\\THH:mm:ss.fff", CultureInfo.InvariantCulture);
						}
						break;
					case CellValueType.IsNumeric:
						text2 = "Number";
						text3 = Class1618.smethod_79(cell_.DoubleValue);
						break;
					}
					if (text3 == null && cell_.Value != null)
					{
						text3 = cell_.Value.ToString();
					}
					if (cell_.method_20() == Enum199.const_4 && cell_.Formula != null && cell_.Formula.Length > 0)
					{
						if (cell_.IsInArray)
						{
							if (cell_.IsArrayHeader)
							{
								CellArea cellArea = cell_.method_50().CellArea;
								StringBuilder stringBuilder = new StringBuilder();
								stringBuilder.Append("RC:");
								stringBuilder.Append('R');
								if (cellArea.EndRow != cell_.Row)
								{
									stringBuilder.Append('[');
									stringBuilder.Append(cellArea.EndRow - cell_.Row);
									stringBuilder.Append(']');
								}
								stringBuilder.Append('C');
								if (cellArea.EndColumn != cell_.Column)
								{
									stringBuilder.Append('[');
									stringBuilder.Append(cellArea.EndColumn - cell_.Column);
									stringBuilder.Append(']');
								}
								xmlTextWriter_0.WriteAttributeString("ss:ArrayRange", null, stringBuilder.ToString());
								xmlTextWriter_0.WriteAttributeString("ss:Formula", null, workbook_0.Worksheets.method_5().method_0(cell_));
							}
						}
						else
						{
							xmlTextWriter_0.WriteAttributeString("ss:Formula", null, workbook_0.Worksheets.method_5().method_0(cell_));
						}
					}
					if (text3 != null && text3.Length > 0)
					{
						xmlTextWriter_0.Formatting = Formatting.None;
						bool flag3;
						if (flag3 = cell_.IsRichText())
						{
							xmlTextWriter_0.WriteStartElement("ss:Data", null);
						}
						else
						{
							xmlTextWriter_0.WriteStartElement("Data", null);
						}
						xmlTextWriter_0.WriteAttributeString("ss:Type", null, text2);
						if (flag3)
						{
							xmlTextWriter_0.WriteAttributeString(null, "xmlns", null, "http://www.w3.org/TR/REC-html40");
							FontSetting[] characters = cell_.GetCharacters();
							foreach (FontSetting fontSetting in characters)
							{
								smethod_15(xmlTextWriter_0, fontSetting, text3.Substring(fontSetting.StartIndex, fontSetting.Length));
							}
						}
						else if (text2 == "String")
						{
							if (text3.IndexOf('\n') != -1)
							{
								text3 = Class1486.smethod_2(text3);
								xmlTextWriter_0.WriteRaw(text3);
							}
							else
							{
								xmlTextWriter_0.WriteString(text3);
							}
						}
						else
						{
							xmlTextWriter_0.WriteString(text3);
						}
						xmlTextWriter_0.WriteEndElement();
						if (bool_0)
						{
							xmlTextWriter_0.Formatting = Formatting.Indented;
						}
					}
				}
				if (class2.comment_0 != null)
				{
					smethod_14(xmlTextWriter_0, class2.comment_0);
				}
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
		smethod_8(xmlTextWriter_0, worksheet_0, workbook_0);
		smethod_6(xmlTextWriter_0, worksheet_0, workbook_0);
		smethod_7(xmlTextWriter_0, worksheet_0, workbook_0);
		smethod_16(xmlTextWriter_0, worksheet_0);
		Class1628 class3 = new Class1628(xmlTextWriter_0, worksheet_0, workbook_0);
		class3.Write();
		xmlTextWriter_0.WriteEndElement();
	}

	private static void smethod_14(XmlTextWriter xmlTextWriter_0, Comment comment_0)
	{
		if (comment_0.Note == null || !(comment_0.Note != ""))
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("ss:Comment", null);
		if (comment_0.IsVisible)
		{
			xmlTextWriter_0.WriteAttributeString("ss:ShowAlways", null, "1");
		}
		xmlTextWriter_0.Formatting = Formatting.None;
		xmlTextWriter_0.WriteStartElement("ss:Data", null);
		Class1737 @class = comment_0.method_2();
		string text = @class.Text;
		if (@class.method_12() != null && @class.method_12().Count != 0)
		{
			xmlTextWriter_0.WriteAttributeString(null, "xmlns", null, "http://www.w3.org/TR/REC-html40");
			ArrayList characters = @class.GetCharacters();
			for (int i = 0; i < characters.Count; i++)
			{
				FontSetting fontSetting = (FontSetting)characters[i];
				smethod_15(xmlTextWriter_0, fontSetting, text.Substring(fontSetting.StartIndex, fontSetting.Length));
			}
		}
		else if (text.IndexOf('\n') != -1)
		{
			text = Class1486.smethod_2(text);
			xmlTextWriter_0.WriteRaw(text);
		}
		else
		{
			xmlTextWriter_0.WriteString(text);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.Formatting = Formatting.Indented;
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private static void smethod_15(XmlWriter xmlWriter_0, FontSetting fontSetting_0, string string_0)
	{
		Aspose.Cells.Font font = fontSetting_0.Font;
		if (font != null)
		{
			int num = 0;
			if (font.IsBold)
			{
				xmlWriter_0.WriteStartElement("B", null);
				num++;
			}
			if (font.IsItalic)
			{
				xmlWriter_0.WriteStartElement("I", null);
				num++;
			}
			if (font.IsSubscript)
			{
				xmlWriter_0.WriteStartElement("Sub", null);
				num++;
			}
			if (font.IsSuperscript)
			{
				xmlWriter_0.WriteStartElement("Sup", null);
				num++;
			}
			if (font.IsStrikeout)
			{
				xmlWriter_0.WriteStartElement("S", null);
				num++;
			}
			if (font.Underline != 0)
			{
				xmlWriter_0.WriteStartElement("U", null);
				switch (font.Underline)
				{
				case FontUnderlineType.Double:
					xmlWriter_0.WriteAttributeString("html:Style", null, "text-underline:double");
					break;
				case FontUnderlineType.Accounting:
					xmlWriter_0.WriteAttributeString("html:Style", null, "text-underline:single-accounting");
					break;
				case FontUnderlineType.DoubleAccounting:
					xmlWriter_0.WriteAttributeString("html:Style", null, "text-underline:double-accounting");
					break;
				}
				num++;
			}
			xmlWriter_0.WriteStartElement("Font", null);
			xmlWriter_0.WriteAttributeString("html:Face", null, font.Name);
			xmlWriter_0.WriteAttributeString("html:Color", null, Class1619.smethod_1(font.Color));
			xmlWriter_0.WriteAttributeString("html:Size", null, Class1618.smethod_79(font.DoubleSize));
			if (string_0.IndexOf('\n') != -1)
			{
				string_0 = Class1486.smethod_2(string_0);
				xmlWriter_0.WriteRaw(string_0);
			}
			else
			{
				xmlWriter_0.WriteString(string_0);
			}
			xmlWriter_0.WriteEndElement();
			for (int i = 0; i < num; i++)
			{
				xmlWriter_0.WriteEndElement();
			}
		}
		else
		{
			xmlWriter_0.WriteStartElement("Font", null);
			if (string_0.IndexOf('\n') != -1)
			{
				string_0 = Class1486.smethod_2(string_0);
				xmlWriter_0.WriteRaw(string_0);
			}
			else
			{
				xmlWriter_0.WriteString(string_0);
			}
			xmlWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private static void smethod_16(XmlTextWriter xmlTextWriter_0, Worksheet worksheet_0)
	{
		if (worksheet_0.method_24() <= 0)
		{
			return;
		}
		AutoFilter autoFilter = worksheet_0.AutoFilter;
		string value = Class1618.smethod_16(autoFilter.method_7());
		xmlTextWriter_0.WriteStartElement("AutoFilter");
		xmlTextWriter_0.WriteAttributeString("x:Range", null, value);
		xmlTextWriter_0.WriteAttributeString(null, "xmlns", null, "urn:schemas-microsoft-com:office:excel");
		if (worksheet_0.AutoFilter.method_5() != null && worksheet_0.AutoFilter.method_5().Count > 0)
		{
			FilterColumnCollection filterColumnCollection = worksheet_0.AutoFilter.method_5();
			for (int i = 0; i < filterColumnCollection.Count; i++)
			{
				FilterColumn byIndex = filterColumnCollection.GetByIndex(i);
				if (byIndex == null)
				{
					continue;
				}
				Class1194 @class = new Class1194(byIndex);
				if (@class.method_5())
				{
					xmlTextWriter_0.WriteStartElement("AutoFilterColumn");
					xmlTextWriter_0.WriteAttributeString("x:Index", Class1618.smethod_80(byIndex.FieldIndex + 1));
					string text = "Top";
					@class.method_0(out var isTop, out var isPercent, out var items);
					text = (isTop ? ((!isPercent) ? "Top" : "TopPercent") : ((!isPercent) ? "Bottom" : "BottomPercent"));
					xmlTextWriter_0.WriteAttributeString("x:Type", text);
					xmlTextWriter_0.WriteAttributeString("x:Value", Class1618.smethod_80(items));
					xmlTextWriter_0.WriteEndElement();
				}
				else
				{
					if (@class.filterOperatorType_0 == FilterOperatorType.None && @class.filterOperatorType_1 == FilterOperatorType.None)
					{
						continue;
					}
					xmlTextWriter_0.WriteStartElement("AutoFilterColumn");
					xmlTextWriter_0.WriteAttributeString("x:Index", Class1618.smethod_80(byIndex.FieldIndex + 1));
					if (@class.filterOperatorType_1 == FilterOperatorType.None)
					{
						if (@class.object_1 == null && (@class.filterOperatorType_0 == FilterOperatorType.Equal || @class.filterOperatorType_1 == FilterOperatorType.NotEqual))
						{
							if (@class.filterOperatorType_0 == FilterOperatorType.Equal)
							{
								xmlTextWriter_0.WriteAttributeString("x:Type", "Blanks");
							}
							else
							{
								xmlTextWriter_0.WriteAttributeString("x:Type", "NonBlanks");
							}
						}
						else
						{
							xmlTextWriter_0.WriteAttributeString("x:Type", "Custom");
							xmlTextWriter_0.WriteStartElement("AutoFilterCondition");
							xmlTextWriter_0.WriteAttributeString("x:Operator", smethod_17(@class.filterOperatorType_0));
							if (@class.object_1 != null)
							{
								xmlTextWriter_0.WriteAttributeString("x:Value", AutoFilter.smethod_0(@class.object_1));
							}
							xmlTextWriter_0.WriteEndElement();
						}
					}
					else
					{
						xmlTextWriter_0.WriteAttributeString("x:Type", "Custom");
						if (@class.method_1())
						{
							xmlTextWriter_0.WriteStartElement("AutoFilterAnd");
						}
						else
						{
							xmlTextWriter_0.WriteStartElement("AutoFilterOr");
						}
						xmlTextWriter_0.WriteStartElement("AutoFilterCondition");
						xmlTextWriter_0.WriteAttributeString("x:Operator", smethod_17(@class.filterOperatorType_0));
						if (@class.object_1 != null)
						{
							xmlTextWriter_0.WriteAttributeString("x:Value", AutoFilter.smethod_0(@class.object_1));
						}
						xmlTextWriter_0.WriteEndElement();
						xmlTextWriter_0.WriteStartElement("AutoFilterCondition");
						xmlTextWriter_0.WriteAttributeString("x:Operator", smethod_17(@class.filterOperatorType_1));
						if (@class.object_0 != null)
						{
							xmlTextWriter_0.WriteAttributeString("x:Value", AutoFilter.smethod_0(@class.object_0));
						}
						xmlTextWriter_0.WriteEndElement();
						xmlTextWriter_0.WriteEndElement();
					}
					xmlTextWriter_0.WriteEndElement();
				}
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	internal static string smethod_17(FilterOperatorType filterOperatorType_0)
	{
		return filterOperatorType_0 switch
		{
			FilterOperatorType.LessOrEqual => "LessThanOrEqual", 
			FilterOperatorType.LessThan => "LessThan", 
			FilterOperatorType.Equal => "Equals", 
			FilterOperatorType.GreaterThan => "GreaterThan", 
			FilterOperatorType.NotEqual => "DoesNotEqual", 
			FilterOperatorType.GreaterOrEqual => "GreaterThanOrEqual", 
			_ => "Equals", 
		};
	}

	private static void smethod_18(XmlTextWriter xmlTextWriter_0, Worksheet worksheet_0, Column column_0, int int_0)
	{
		int num = column_0.method_5();
		double num2 = (float)worksheet_0.Cells.method_17(column_0.Index) * 72f / (float)worksheet_0.method_2().method_76();
		xmlTextWriter_0.WriteStartElement("Column", null);
		xmlTextWriter_0.WriteAttributeString("ss:Index", null, Class1618.smethod_80(column_0.Index + 1));
		if (int_0 != 0)
		{
			xmlTextWriter_0.WriteAttributeString("ss:Span", null, Class1618.smethod_80(int_0));
		}
		if (num >= 0 && num != 15)
		{
			xmlTextWriter_0.WriteAttributeString("ss:StyleID", null, "S" + Class1618.smethod_80(num));
		}
		if (column_0.IsHidden)
		{
			xmlTextWriter_0.WriteAttributeString("ss:Hidden", null, "1");
		}
		if (num2 >= 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("ss:AutoFitWidth", null, "0");
			xmlTextWriter_0.WriteAttributeString("ss:Width", null, Class1618.smethod_79(num2));
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private static void smethod_19(XmlTextWriter xmlTextWriter_0, Worksheet worksheet_0, Workbook workbook_0, ArrayList arrayList_0, bool bool_0)
	{
		Cells cells = worksheet_0.Cells;
		xmlTextWriter_0.WriteAttributeString("ss:DefaultRowHeight", null, Class1618.smethod_79(cells.StandardHeight));
		int maxColumn = -1;
		int maxRow = -1;
		smethod_12(worksheet_0, arrayList_0, isTotal: true, bool_0, out maxRow, out maxColumn);
		ColumnCollection columns = worksheet_0.Cells.Columns;
		if (columns.Count > 0)
		{
			Column columnByIndex = columns.GetColumnByIndex(columns.Count - 1);
			if (columnByIndex.Index > maxColumn)
			{
				maxColumn = columnByIndex.Index;
			}
		}
		double num = Class1677.smethod_1(columns.Width, workbook_0.Worksheets);
		if (columns.column_0 != null && columns.column_0.IsHidden)
		{
			xmlTextWriter_0.WriteAttributeString("ss:DefaultColumnWidth", null, "0");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("ss:DefaultColumnWidth", null, Class1618.smethod_79(num * 72.0 / (double)worksheet_0.method_2().method_76()));
		}
		if (bool_0)
		{
			maxColumn = ((maxColumn > 255) ? 255 : maxColumn);
			maxRow = ((maxRow > 65535) ? 65535 : maxRow);
		}
		if (cells.Count != 0)
		{
			xmlTextWriter_0.WriteAttributeString("ss:ExpandedRowCount", null, Class1618.smethod_80(maxRow + 1));
		}
		if (cells.Count != 0 || maxColumn != 0)
		{
			xmlTextWriter_0.WriteAttributeString("ss:ExpandedColumnCount", null, Class1618.smethod_80(maxColumn + 1));
		}
		if (columns.column_0 != null && columns.column_0.method_5() > 15)
		{
			xmlTextWriter_0.WriteAttributeString("ss:StyleID", null, "S" + Class1618.smethod_80(columns.column_0.method_5()));
		}
		int num2 = 16383;
		if (bool_0)
		{
			num2 = 255;
		}
		Column column = null;
		if (columns.column_0 != null && columns.column_0.Index != 0 && columns.column_0.method_18())
		{
			num2 = columns.column_0.Index;
			column = new Column(0, worksheet_0, columns.Width);
		}
		int num3 = 0;
		int num4;
		for (num4 = 0; num4 < columns.Count; num4++)
		{
			Column columnByIndex2 = columns.GetColumnByIndex(num4);
			if (columnByIndex2.Index - num3 != 0 && column != null && num3 < num2)
			{
				int num5 = ((num2 > columnByIndex2.Index) ? columnByIndex2.Index : num2);
				column.method_0(num3);
				smethod_18(xmlTextWriter_0, worksheet_0, column, num5 - num3 - 1);
				num3 = num5;
			}
			int num6 = 0;
			for (int i = num4 + 1; i < columns.Count; i++)
			{
				Column columnByIndex3 = columns.GetColumnByIndex(i);
				if (columnByIndex3.Index != columnByIndex2.Index + 1 + num6 || !columnByIndex2.method_9(columnByIndex3))
				{
					break;
				}
				num6++;
			}
			smethod_18(xmlTextWriter_0, worksheet_0, columnByIndex2, num6);
			num4 += num6;
			num3 = columnByIndex2.Index + 1 + num6;
		}
	}

	private static void smethod_20(Workbook workbook_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("Styles", null);
		Hashtable hashtable = new Hashtable();
		Class1683 @class = workbook_0.Worksheets.method_58();
		for (int i = 0; i < @class.Count; i++)
		{
			Style style = workbook_0.Worksheets.method_58()[i];
			if (style.method_10())
			{
				hashtable[i] = null;
				Style style2 = style;
				while (style2.method_12() != 4095 && style2.method_12() > 0 && !hashtable.Contains(style2.method_12()))
				{
					hashtable[style2.method_12()] = null;
					style2 = @class[style2.method_12()];
				}
			}
		}
		StyleCollection styles = workbook_0.Styles;
		for (int j = 0; j < styles.Count; j++)
		{
			Style style3 = styles[j];
			Style style4 = style3;
			while (style4.method_12() != 4095 && style4.method_12() > 0 && !hashtable.Contains(style4.method_12()))
			{
				hashtable[style4.method_12()] = null;
				style4 = ((style4.method_12() >= @class.Count) ? styles[style4.method_12() - @class.Count] : @class[style4.method_12()]);
			}
		}
		ArrayList arrayList = new ArrayList(hashtable.Count);
		IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
		while (enumerator.MoveNext())
		{
			arrayList.Add(enumerator.Key);
		}
		arrayList.Sort();
		Hashtable hashtable2 = new Hashtable();
		for (int k = 0; k < arrayList.Count; k++)
		{
			int num = (int)arrayList[k];
			Style style5 = ((num < @class.Count) ? @class[num] : workbook_0.Styles[num - @class.Count]);
			if (style5.method_10())
			{
				Style style6 = @class[style5.method_12()];
				if (style6.method_33(style5))
				{
					if (style6.Name != null && style6.Name != "")
					{
						if (hashtable2[style6.Name] == null)
						{
							style5.method_3(style6.Name);
							hashtable2[style6.Name] = 0;
						}
						else
						{
							style5.method_3(null);
						}
					}
				}
				else if (style5.Name != null && style5.Name != "" && hashtable2[style5.Name] != null)
				{
					style5.method_3(null);
				}
			}
			smethod_21(workbook_0, style5, num, xmlTextWriter_0);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private static void smethod_21(Workbook workbook_0, Style style_0, int int_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("Style", null);
		string value = ((int_0 == 15) ? "Default" : ("S" + int_0));
		xmlTextWriter_0.WriteAttributeString("ss:ID", null, value);
		int num = style_0.method_12();
		bool flag = false;
		if (int_0 == 15)
		{
			Style style = workbook_0.Worksheets.method_58()[0];
			if (style_0.Font.method_18(style.Font))
			{
				xmlTextWriter_0.WriteAttributeString("ss:Name", null, "Normal");
			}
		}
		else if (num != 4095 && num > 0)
		{
			flag = true;
			xmlTextWriter_0.WriteAttributeString("ss:Parent", null, "S" + num);
		}
		else if (style_0.Name != null && style_0.Name.Length != 0)
		{
			xmlTextWriter_0.WriteAttributeString("ss:Name", null, style_0.Name);
		}
		if (style_0.method_21() || style_0.HorizontalAlignment != TextAlignmentType.General || style_0.VerticalAlignment != TextAlignmentType.Center || style_0.IsTextWrapped || style_0.IndentLevel != 0 || style_0.ShrinkToFit || style_0.RotationAngle != 0 || style_0.TextDirection != 0)
		{
			xmlTextWriter_0.WriteStartElement("ss:Alignment", null);
			if (style_0.HorizontalAlignment != TextAlignmentType.General)
			{
				xmlTextWriter_0.WriteAttributeString("ss:Horizontal", null, style_0.HorizontalAlignment switch
				{
					TextAlignmentType.Center => "Center", 
					TextAlignmentType.CenterAcross => "CenterAcrossSelection", 
					TextAlignmentType.Distributed => "Distributed", 
					TextAlignmentType.Fill => "Fill", 
					TextAlignmentType.Justify => "Justify", 
					TextAlignmentType.Left => "Left", 
					TextAlignmentType.Right => "Right", 
					_ => "Automatic", 
				});
			}
			if (style_0.IsModified(StyleModifyFlag.VerticalAlignment) || style_0.VerticalAlignment != TextAlignmentType.Center)
			{
				xmlTextWriter_0.WriteAttributeString("ss:Vertical", null, style_0.VerticalAlignment switch
				{
					TextAlignmentType.Top => "Top", 
					TextAlignmentType.Bottom => "Bottom", 
					TextAlignmentType.Center => "Center", 
					TextAlignmentType.Distributed => "Distributed", 
					TextAlignmentType.Justify => "Justify", 
					_ => "Automatic", 
				});
			}
			if (style_0.IsTextWrapped)
			{
				xmlTextWriter_0.WriteAttributeString("ss:WrapText", null, "1");
			}
			if (style_0.IndentLevel != 0)
			{
				xmlTextWriter_0.WriteAttributeString("ss:Indent", null, Class1618.smethod_80(style_0.IndentLevel));
			}
			if (style_0.ShrinkToFit)
			{
				xmlTextWriter_0.WriteAttributeString("ss:ShrinkToFit", null, "1");
			}
			if (style_0.RotationAngle == 255)
			{
				xmlTextWriter_0.WriteAttributeString("ss:VerticalText", null, "1");
			}
			else if (style_0.RotationAngle != 0)
			{
				xmlTextWriter_0.WriteAttributeString("ss:Rotate", null, Class1618.smethod_80(style_0.RotationAngle));
			}
			switch (style_0.TextDirection)
			{
			case TextDirectionType.LeftToRight:
				xmlTextWriter_0.WriteAttributeString("ss:ReadingOrder", null, "LeftToRight");
				break;
			case TextDirectionType.RightToLeft:
				xmlTextWriter_0.WriteAttributeString("ss:ReadingOrder", null, "RightToLeft");
				break;
			}
			xmlTextWriter_0.WriteEndElement();
		}
		if (smethod_25(style_0))
		{
			xmlTextWriter_0.WriteStartElement("ss:Borders", null);
			BorderCollection borders = style_0.Borders;
			if (borders[BorderType.LeftBorder].LineStyle != 0)
			{
				smethod_26(borders[BorderType.LeftBorder], xmlTextWriter_0, "Left");
			}
			if (borders[BorderType.TopBorder].LineStyle != 0)
			{
				smethod_26(borders[BorderType.TopBorder], xmlTextWriter_0, "Top");
			}
			if (borders[BorderType.RightBorder].LineStyle != 0)
			{
				smethod_26(borders[BorderType.RightBorder], xmlTextWriter_0, "Right");
			}
			if (borders[BorderType.BottomBorder].LineStyle != 0)
			{
				smethod_26(borders[BorderType.BottomBorder], xmlTextWriter_0, "Bottom");
			}
			if (borders.method_8() != 0)
			{
				if (borders[BorderType.DiagonalUp].LineStyle != 0)
				{
					smethod_26(borders[BorderType.DiagonalUp], xmlTextWriter_0, "DiagonalRight");
				}
				if (borders[BorderType.DiagonalDown].LineStyle != 0)
				{
					smethod_26(borders[BorderType.DiagonalDown], xmlTextWriter_0, "DiagonalLeft");
				}
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if (((style_0.Name != null && style_0.Name != "") || flag) && style_0.method_23())
		{
			xmlTextWriter_0.WriteStartElement("ss:Borders", null);
			xmlTextWriter_0.WriteEndElement();
		}
		smethod_24(style_0.Font, xmlTextWriter_0);
		if (style_0.Pattern != 0)
		{
			smethod_23(style_0, xmlTextWriter_0);
		}
		else if (style_0.Name != null && style_0.Name != "" && (style_0.method_15() & 0x40u) != 0)
		{
			xmlTextWriter_0.WriteStartElement("ss:Interior", null);
			xmlTextWriter_0.WriteEndElement();
		}
		if (style_0.Number == 0 && (style_0.Custom == null || style_0.Custom.Length == 0))
		{
			if (style_0.method_17())
			{
				if (style_0.Name != null && style_0.Name != "")
				{
					xmlTextWriter_0.WriteStartElement("ss:NumberFormat", null);
					xmlTextWriter_0.WriteEndElement();
				}
				else if (style_0.method_12() != 4095 && style_0.method_12() != -1)
				{
					xmlTextWriter_0.WriteStartElement("ss:NumberFormat", null);
					xmlTextWriter_0.WriteEndElement();
				}
			}
		}
		else
		{
			smethod_22(style_0, xmlTextWriter_0);
		}
		if (style_0.method_27())
		{
			xmlTextWriter_0.WriteStartElement("ss:Protection", null);
			xmlTextWriter_0.WriteAttributeString("ss:Protected", null, style_0.IsLocked ? "1" : "0");
			xmlTextWriter_0.WriteAttributeString("x:HideFormula", null, style_0.IsFormulaHidden ? "1" : "0");
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private static void smethod_22(Style style_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("ss:NumberFormat", null);
		string text = "General";
		if (style_0.Custom != null && style_0.Custom.Length != 0)
		{
			text = style_0.Custom;
		}
		else if (style_0.Number != 0)
		{
			text = style_0.method_5().Workbook.Settings.method_3().method_8(style_0.Number);
			if (text == null)
			{
				text = "General";
			}
		}
		xmlTextWriter_0.WriteAttributeString("ss:Format", null, text);
		xmlTextWriter_0.WriteEndElement();
	}

	private static void smethod_23(Style style_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("ss:Interior", null);
		if (style_0.Pattern != BackgroundType.Solid)
		{
			if (!style_0.ForegroundColor.IsEmpty)
			{
				xmlTextWriter_0.WriteAttributeString("ss:PatternColor", null, Class1619.smethod_1(style_0.ForegroundColor));
			}
			if (!style_0.BackgroundColor.IsEmpty)
			{
				xmlTextWriter_0.WriteAttributeString("ss:Color", null, Class1619.smethod_1(style_0.BackgroundColor));
			}
		}
		else if (!style_0.ForegroundColor.IsEmpty)
		{
			xmlTextWriter_0.WriteAttributeString("ss:Color", null, Class1619.smethod_1(style_0.ForegroundColor));
		}
		string text = null;
		switch (style_0.Pattern)
		{
		case BackgroundType.Solid:
			text = "Solid";
			break;
		case BackgroundType.Gray50:
			text = "Gray50";
			break;
		case BackgroundType.Gray75:
			text = "Gray75";
			break;
		case BackgroundType.Gray25:
			text = "Gray25";
			break;
		case BackgroundType.HorizontalStripe:
			text = "HorzStripe";
			break;
		case BackgroundType.VerticalStripe:
			text = "VertStripe";
			break;
		case BackgroundType.ReverseDiagonalStripe:
			text = "ReverseDiagStripe";
			break;
		case BackgroundType.DiagonalStripe:
			text = "DiagStripe";
			break;
		case BackgroundType.DiagonalCrosshatch:
			text = "DiagCross";
			break;
		case BackgroundType.ThickDiagonalCrosshatch:
			text = "ThickDiagCross";
			break;
		case BackgroundType.ThinHorizontalStripe:
			text = "ThinHorzStripe";
			break;
		case BackgroundType.ThinVerticalStripe:
			text = "ThinVertStripe";
			break;
		case BackgroundType.ThinReverseDiagonalStripe:
			text = "ThinReverseDiagStripe";
			break;
		case BackgroundType.ThinDiagonalStripe:
			text = "ThinDiagStripe";
			break;
		case BackgroundType.ThinHorizontalCrosshatch:
			text = "ThinHorzCross";
			break;
		case BackgroundType.ThinDiagonalCrosshatch:
			text = "ThinDiagCross";
			break;
		case BackgroundType.Gray12:
			text = "Gray125";
			break;
		case BackgroundType.Gray6:
			text = "Gray0625";
			break;
		}
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("ss:Pattern", null, text);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private static void smethod_24(Aspose.Cells.Font font_0, XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("ss:Font", null);
		if (font_0.IsBold)
		{
			xmlTextWriter_0.WriteAttributeString("ss:Bold", null, "1");
		}
		if (!font_0.Color.IsEmpty && font_0.Color != Color.Black)
		{
			xmlTextWriter_0.WriteAttributeString("ss:Color", null, Class1619.smethod_1(font_0.Color));
		}
		xmlTextWriter_0.WriteAttributeString("ss:FontName", null, font_0.Name);
		xmlTextWriter_0.WriteAttributeString("ss:Size", null, Class1618.smethod_80(font_0.Size));
		if (font_0.IsItalic)
		{
			xmlTextWriter_0.WriteAttributeString("ss:Italic", null, "1");
		}
		if (font_0.IsStrikeout)
		{
			xmlTextWriter_0.WriteAttributeString("ss:StrikeThrough", null, "1");
		}
		string text = null;
		switch (font_0.Underline)
		{
		case FontUnderlineType.Single:
			text = "Single";
			break;
		case FontUnderlineType.Double:
			text = "Double";
			break;
		case FontUnderlineType.Accounting:
			text = "SingleAccounting";
			break;
		case FontUnderlineType.DoubleAccounting:
			text = "DoubleAccounting";
			break;
		}
		if (text != null)
		{
			xmlTextWriter_0.WriteAttributeString("ss:Underline", null, text);
		}
		if (font_0.IsSubscript)
		{
			xmlTextWriter_0.WriteAttributeString("ss:VerticalAlign", null, "Subscript");
		}
		else if (font_0.IsSuperscript)
		{
			xmlTextWriter_0.WriteAttributeString("ss:VerticalAlign", null, "Superscript");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private static bool smethod_25(Style style_0)
	{
		BorderCollection borders = style_0.Borders;
		if (borders[BorderType.BottomBorder].LineStyle == CellBorderType.None && borders[BorderType.DiagonalDown].LineStyle == CellBorderType.None && borders[BorderType.DiagonalUp].LineStyle == CellBorderType.None && borders[BorderType.LeftBorder].LineStyle == CellBorderType.None && borders[BorderType.RightBorder].LineStyle == CellBorderType.None)
		{
			return borders[BorderType.TopBorder].LineStyle != CellBorderType.None;
		}
		return true;
	}

	private static void smethod_26(Border border_0, XmlTextWriter xmlTextWriter_0, string string_0)
	{
		xmlTextWriter_0.WriteStartElement("ss:Border", null);
		xmlTextWriter_0.WriteAttributeString("ss:Position", null, string_0);
		xmlTextWriter_0.WriteAttributeString("ss:Color", null, Class1619.smethod_1(border_0.Color));
		smethod_27(border_0.LineStyle, out var lineStyle, out var weight);
		xmlTextWriter_0.WriteAttributeString("ss:LineStyle", null, lineStyle);
		xmlTextWriter_0.WriteAttributeString("ss:Weight", null, Class1618.smethod_79(weight));
		xmlTextWriter_0.WriteEndElement();
	}

	private static void smethod_27(CellBorderType borderType, out string lineStyle, out double weight)
	{
		lineStyle = "Continuous";
		weight = 1.0;
		switch (borderType)
		{
		case CellBorderType.None:
			lineStyle = "None";
			weight = 0.0;
			break;
		case CellBorderType.Thin:
			lineStyle = "Continuous";
			weight = 1.0;
			break;
		case CellBorderType.Medium:
			lineStyle = "Continuous";
			weight = 2.0;
			break;
		case CellBorderType.Dashed:
			lineStyle = "Dash";
			weight = 1.0;
			break;
		case CellBorderType.Dotted:
			lineStyle = "Dot";
			weight = 1.0;
			break;
		case CellBorderType.Thick:
			lineStyle = "Continuous";
			weight = 3.0;
			break;
		case CellBorderType.Double:
			lineStyle = "Double";
			weight = 3.0;
			break;
		case CellBorderType.Hair:
			lineStyle = "Continuous";
			weight = 0.0;
			break;
		case CellBorderType.MediumDashed:
			lineStyle = "Dash";
			weight = 2.0;
			break;
		case CellBorderType.DashDot:
			lineStyle = "DashDot";
			weight = 1.0;
			break;
		case CellBorderType.MediumDashDot:
			lineStyle = "DashDot";
			weight = 2.0;
			break;
		case CellBorderType.DashDotDot:
			lineStyle = "DashDotDot";
			weight = 1.0;
			break;
		case CellBorderType.MediumDashDotDot:
			lineStyle = "DashDotDot";
			weight = 2.0;
			break;
		case CellBorderType.SlantedDashDot:
			lineStyle = "SlantDashDot";
			weight = 2.0;
			break;
		}
	}
}
