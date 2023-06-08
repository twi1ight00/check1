using System.Collections;
using System.IO;
using Aspose.Cells;
using ns29;

namespace ns24;

internal class Class514
{
	private Workbook workbook_0;

	private StreamWriter streamWriter_0;

	public Class514(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
	}

	public void Write(Stream stream_0)
	{
		streamWriter_0 = new StreamWriter(stream_0, workbook_0.Settings.Encoding);
		Write();
		streamWriter_0.Flush();
	}

	internal void Write()
	{
		Cells cells = ((Class1129.smethod_0() != 0) ? workbook_0.Worksheets[workbook_0.Worksheets.ActiveSheetIndex].Cells : workbook_0.Worksheets[0].Cells);
		int maxRow = cells.MaxRow;
		int maxDataColumn = cells.MaxDataColumn;
		streamWriter_0.WriteLine("TABLE");
		streamWriter_0.WriteLine("0,1");
		streamWriter_0.WriteLine("\"EXCEL\"");
		streamWriter_0.WriteLine("VECTORS");
		streamWriter_0.WriteLine("0," + (maxRow + 1));
		streamWriter_0.WriteLine("\"\"");
		streamWriter_0.WriteLine("TUPLES");
		streamWriter_0.WriteLine("0," + (maxDataColumn + 1));
		streamWriter_0.WriteLine("\"\"");
		streamWriter_0.WriteLine("DATA");
		streamWriter_0.WriteLine("0,0");
		streamWriter_0.WriteLine("\"\"");
		int int_ = -1;
		for (int i = 0; i < cells.Rows.Count; i++)
		{
			Row rowByIndex = cells.Rows.GetRowByIndex(i);
			method_0(int_, rowByIndex.Index, maxDataColumn);
			int_ = rowByIndex.Index;
			streamWriter_0.WriteLine("-1,0\r\nBOT");
			_ = rowByIndex.Cells;
			int int_2 = -1;
			IEnumerator enumerator = rowByIndex.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Cell cell = (Cell)enumerator.Current;
				method_1(int_2, cell.Column);
				switch (cell.Type)
				{
				case CellValueType.IsBool:
					streamWriter_0.WriteLine("0,1");
					streamWriter_0.WriteLine(cell.BoolValue ? "TRUE" : "FALSE");
					break;
				case CellValueType.IsError:
					streamWriter_0.WriteLine("0,0");
					streamWriter_0.WriteLine("ERROR");
					break;
				case CellValueType.IsDateTime:
				case CellValueType.IsNumeric:
					streamWriter_0.WriteLine("0," + cell.StringValue);
					streamWriter_0.WriteLine("V");
					break;
				case CellValueType.IsNull:
				case CellValueType.IsString:
					streamWriter_0.WriteLine("1,0");
					streamWriter_0.WriteLine("\"" + cell.StringValue + "\"");
					break;
				}
				int_2 = cell.Column;
			}
			method_1(int_2, maxDataColumn + 1);
		}
		streamWriter_0.WriteLine("-1,0");
		streamWriter_0.WriteLine("EOD");
	}

	internal void method_0(int int_0, int int_1, int int_2)
	{
		for (int_0++; int_0 < int_1; int_0++)
		{
			streamWriter_0.WriteLine("-1,0\r\nBOT");
			method_1(-1, int_2 + 1);
		}
	}

	internal void method_1(int int_0, int int_1)
	{
		for (int_0++; int_0 < int_1; int_0++)
		{
			streamWriter_0.WriteLine("1,0");
			streamWriter_0.WriteLine("\"\"");
		}
	}
}
