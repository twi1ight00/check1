using System;
using System.IO;
using Aspose.Cells;
using ns14;
using ns2;

namespace ns59;

internal class Class1727
{
	internal static void Write(Stream stream_0, Workbook workbook_0, TxtSaveOptions txtSaveOptions_0)
	{
		StreamWriter streamWriter = (txtSaveOptions_0.bool_7 ? new StreamWriter(stream_0) : new StreamWriter(stream_0, txtSaveOptions_0.Encoding));
		smethod_0(streamWriter, workbook_0.Worksheets, txtSaveOptions_0);
		streamWriter.Flush();
		if (txtSaveOptions_0.ClearData)
		{
			workbook_0.Initialize();
		}
		else
		{
			workbook_0.method_1();
		}
	}

	private static void smethod_0(StreamWriter streamWriter_0, WorksheetCollection worksheetCollection_0, TxtSaveOptions txtSaveOptions_0)
	{
		Class515 class515_ = worksheetCollection_0.Workbook.Settings.method_3().method_9();
		string separatorString = txtSaveOptions_0.SeparatorString;
		string value = ((txtSaveOptions_0.QuoteType != TxtValueQuoteType.Always) ? separatorString : ("\"\"" + separatorString));
		Cells cells = ((Class972.smethod_0() != 0) ? worksheetCollection_0[worksheetCollection_0.ActiveSheetIndex].Cells : worksheetCollection_0[0].Cells);
		int num = 0;
		int num2 = -1;
		int num3 = cells.MaxDataColumn;
		if (num3 < 0)
		{
			num3 = 0;
		}
		RowCollection rows = cells.Rows;
		for (int i = 0; i < rows.Count; i++)
		{
			Row rowByIndex = rows.GetRowByIndex(i);
			for (int j = 0; j < rowByIndex.int_0 - num2 - 1; j++)
			{
				streamWriter_0.Write("\r\n");
			}
			num = 0;
			for (int k = 0; k < rowByIndex.method_0(); k++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(k);
				if (cellByIndex.Type == CellValueType.IsNull)
				{
					continue;
				}
				if (num > 0)
				{
					streamWriter_0.Write(separatorString);
				}
				if (cellByIndex.Column > num)
				{
					for (; num < cellByIndex.Column; num++)
					{
						streamWriter_0.Write(value);
					}
				}
				num++;
				object obj = cellByIndex.method_26();
				string text;
				if (obj == null)
				{
					text = "";
				}
				else
				{
					Class518 @class = cellByIndex.method_22().Format(class515_, obj);
					text = ((!@class.method_4()) ? @class.method_6(0, bool_1: true) : "###############################################################################################################################################################################################################################################################");
				}
				bool flag = false;
				switch (txtSaveOptions_0.QuoteType)
				{
				case TxtValueQuoteType.Normal:
					if (text.Length > 0 && !(flag = text.IndexOf('"') > -1) && !(flag = text.IndexOf('\n') > -1))
					{
						flag = text.IndexOf(separatorString) > -1;
					}
					break;
				case TxtValueQuoteType.Always:
					flag = true;
					break;
				case TxtValueQuoteType.Minimum:
					if (text.Length > 0 && !(flag = text[0] == '"') && !(flag = text.IndexOf('\n') > -1))
					{
						flag = text.IndexOf(separatorString) > -1;
					}
					break;
				}
				if (flag)
				{
					string text2 = text.Replace("\"", "\"\"");
					text2 = '"' + text2 + '"';
					streamWriter_0.Write(text2);
				}
				else
				{
					streamWriter_0.Write(text);
				}
			}
			if (num < num3)
			{
				streamWriter_0.Write(separatorString);
				for (; num < num3; num++)
				{
					streamWriter_0.Write(value);
				}
				if (txtSaveOptions_0.QuoteType == TxtValueQuoteType.Always)
				{
					streamWriter_0.Write("\"\"");
				}
			}
			streamWriter_0.Write("\r\n");
			num2 = rowByIndex.int_0;
		}
		if (Class972.smethod_0() == Enum134.const_0)
		{
			string value2 = "\r\nThis file is created with " + Class1677.smethod_35() + " for evaluation only with an Evaluation License. \r\nIt is strictly prohibited from using it in the production of any software. \r\nAny violation of this provision shall require a mandatory purchase of pay license \r\nas well as expose the user to other legal recourse for collection and punitive damages. \r\nCopyright 2003 - " + DateTime.Now.Year + " Aspose Pty Ltd.";
			streamWriter_0.Write(value2);
		}
	}
}
