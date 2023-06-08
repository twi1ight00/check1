using System;
using System.Collections;
using System.Text;
using ns2;
using ns29;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.Hyperlink" /> objects.
///       </summary>
/// <example>
///   <code>
///
///
///       [C#]
///
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///
///       //Obtaining the reference of the newly added worksheet by passing its sheet index
///       Worksheet worksheet = workbook.Worksheets[0];
///
///       //Get Hyperlinks Collection
///       HyperlinkCollection hyperlinks = worksheet.Hyperlinks;
///
///       //Adding a hyperlink to a URL at "A1" cell
///       hyperlinks.Add("A1", 1, 1, "http://www.aspose.com");
///
///       //Saving the Excel file
///       workbook.Save("D:\\book1.xls");
///
///       [VB.NET]
///
///       'Instantiating a Workbook object
///       Dim workbook As New Workbook()
///
///       'Obtaining the reference of the newly added worksheet by passing its sheet index
///       Dim worksheet As Worksheet = workbook.Worksheets(0)
///
///       'Get Hyperlinks Collection
///       Dim hyperlinks As HyperlinkCollection = worksheet.Hyperlinks
///
///       'Adding a hyperlink to a URL at "A1" cell
///       hyperlinks.Add("A1", 1, 1, "http://www.aspose.com")
///
///       'Saving the Excel file
///       workbook.Save("D:\book1.xls")
///       </code>
/// </example>
public class HyperlinkCollection : CollectionBase
{
	private object object_0;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Hyperlink" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public Hyperlink this[int index] => (Hyperlink)base.InnerList[index];

	internal Worksheet Worksheet
	{
		get
		{
			if (object_0 is Worksheet)
			{
				return (Worksheet)object_0;
			}
			return null;
		}
	}

	internal HyperlinkCollection(object object_1)
	{
		object_0 = object_1;
	}

	/// <summary>
	///       Adds a hyperlink to a specified cell or a range of cells.
	///       </summary>
	/// <param name="firstRow">First row of the hyperlink range.</param>
	/// <param name="firstColumn">First column of the hyperlink range.</param>
	/// <param name="totalRows">Number of rows in this hyperlink range.</param>
	/// <param name="totalColumns">Number of columns of this hyperlink range.</param>
	/// <param name="address">Address of the hyperlink.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Hyperlink" /> object index.</returns>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       Worksheet worksheet = excel.Worksheets[0];
	///       worksheet.Hyperlinks.Add("A4", 1, 1, "http://www.aspose.com");
	///       worksheet.Hyperlinks.Add("A5", 1, 1, "c:\\book1.xls");
	///
	///       [Visual Basic]
	///
	///       Dim worksheet as Worksheet = excel.Worksheets(0)
	///       worksheet.Hyperlinks.Add("A4", 1, 1, "http://www.aspose.com")
	///       worksheet.Hyperlinks.Add("A5", 1, 1, "c:\\book1.xls")
	///
	///       </code>
	/// </example>
	public int Add(int firstRow, int firstColumn, int totalRows, int totalColumns, string address)
	{
		Class1677.smethod_26(firstRow, firstColumn, firstRow + totalRows - 1, firstColumn + totalColumns - 1);
		string text = address.ToLower();
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = firstRow;
		cellArea_.StartColumn = firstColumn;
		cellArea_.EndRow = firstRow + totalRows - 1;
		cellArea_.EndColumn = firstColumn + totalColumns - 1;
		Hyperlink hyperlink = new Hyperlink(this, cellArea_);
		hyperlink.method_2(address);
		if (!text.StartsWith("http:") && !text.StartsWith("www.") && !text.StartsWith("https:") && !text.StartsWith("mailto:"))
		{
			hyperlink.method_1(bool_2: true);
			if (address.Length > 2 && address[1] == ':')
			{
				hyperlink.method_0(bool_2: true);
			}
		}
		if (text.StartsWith("www."))
		{
			hyperlink.Address = "http://" + address;
		}
		else
		{
			hyperlink.Address = address;
		}
		base.InnerList.Add(hyperlink);
		return base.Count - 1;
	}

	private int method_0(int int_0, int int_1, int int_2, int int_3, string string_0)
	{
		Class1677.smethod_26(int_0, int_1, int_0 + int_2 - 1, int_1 + int_3 - 1);
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = int_0;
		cellArea_.StartColumn = int_1;
		cellArea_.EndRow = int_0 + int_2 - 1;
		cellArea_.EndColumn = int_1 + int_3 - 1;
		Hyperlink hyperlink = new Hyperlink(this, cellArea_);
		hyperlink.Address = string_0;
		hyperlink.method_3(string_0);
		hyperlink.method_1(bool_2: true);
		if (string_0.Length > 2 && string_0[1] == ':')
		{
			hyperlink.method_0(bool_2: true);
		}
		base.InnerList.Add(hyperlink);
		return base.InnerList.Count - 1;
	}

	internal int method_1(int int_0, int int_1, int int_2, int int_3, string string_0)
	{
		Class1677.smethod_26(int_0, int_1, int_0 + int_2 - 1, int_1 + int_3 - 1);
		string text = string_0.ToLower();
		if (!text.StartsWith("http:") && !text.StartsWith("www.") && !text.StartsWith("https:") && !text.StartsWith("mailto:"))
		{
			return method_0(int_0, int_1, int_2, int_3, string_0);
		}
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = int_0;
		cellArea_.StartColumn = int_1;
		cellArea_.EndRow = int_0 + int_2 - 1;
		cellArea_.EndColumn = int_1 + int_3 - 1;
		Hyperlink hyperlink = new Hyperlink(this, cellArea_);
		hyperlink.Address = string_0;
		hyperlink.method_3(string_0);
		base.InnerList.Add(hyperlink);
		return base.InnerList.Count - 1;
	}

	/// <summary>
	///       Adds a hyperlink to a specified cell or a range of cells.
	///       </summary>
	/// <param name="cellName">Cell name.</param>
	/// <param name="totalRows">Number of rows in this hyperlink range.</param>
	/// <param name="totalColumns">Number of columns of this hyperlink range.</param>
	/// <param name="address">Address of the hyperlink.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Hyperlink" /> object index.</returns>
	public int Add(string cellName, int totalRows, int totalColumns, string address)
	{
		CellsHelper.CellNameToIndex(cellName, out var row, out var column);
		return Add(row, column, totalRows, totalColumns, address);
	}

	/// <summary>
	///       Adds a hyperlink to a specified cell or a range of cells.
	///       </summary>
	/// <param name="startCellName">The top-left cell of the range.</param>
	/// <param name="endCellName">The bottom-right cell of the range.</param>
	/// <param name="address">Address of the hyperlink.</param>
	/// <param name="textToDisplay">The text to be displayed for the specified hyperlink.</param>
	/// <param name="screenTip">The screenTip text for the specified hyperlink.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Hyperlink" /> object index.</returns>
	public int Add(string startCellName, string endCellName, string address, string textToDisplay, string screenTip)
	{
		CellsHelper.CellNameToIndex(startCellName, out var row, out var column);
		CellsHelper.CellNameToIndex(endCellName, out var row2, out var column2);
		int num = Add(row, column, row2 - row + 1, column2 - column + 1, address);
		Hyperlink hyperlink = this[num];
		if (textToDisplay != null && textToDisplay != "")
		{
			hyperlink.TextToDisplay = textToDisplay;
		}
		if (screenTip != null && screenTip != "")
		{
			hyperlink.ScreenTip = screenTip;
		}
		return num;
	}

	internal int Add(Hyperlink hyperlink_0)
	{
		base.InnerList.Add(hyperlink_0);
		return base.InnerList.Count - 1;
	}

	internal void method_2(int int_0)
	{
		base.InnerList.RemoveAt(int_0);
	}

	/// <summary>
	///       Remove the hyperlink  at the specified index.
	///       </summary>
	/// <param name="index">The zero based index of the element.</param>
	public new void RemoveAt(int index)
	{
		Hyperlink hyperlink = (Hyperlink)base.InnerList[index];
		base.InnerList.RemoveAt(index);
		Worksheet worksheet = Worksheet;
		if (worksheet == null)
		{
			return;
		}
		CellArea area = hyperlink.Area;
		RowCollection rows = worksheet.Cells.Rows;
		for (int i = area.StartRow; i <= area.EndRow; i++)
		{
			Row row = rows.GetRow(i, bool_0: true, bool_1: false);
			if (row != null)
			{
				for (int j = area.StartColumn; j <= area.EndColumn; j++)
				{
					row.GetCellOrNull(j)?.method_30(null);
				}
			}
		}
	}

	/// <summary>
	///       Clears all hyperlinks.
	///       </summary>
	public new void Clear()
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				Hyperlink hyperlink = (Hyperlink)base.InnerList[num];
				Worksheet worksheet = Worksheet;
				if (worksheet == null)
				{
					break;
				}
				CellArea area = hyperlink.Area;
				RowCollection rows = worksheet.Cells.Rows;
				for (int i = area.StartRow; i <= area.EndRow; i++)
				{
					Row row = rows.GetRow(i, bool_0: true, bool_1: false);
					if (row != null)
					{
						for (int j = area.StartColumn; j <= area.EndColumn; j++)
						{
							row.GetCellOrNull(j)?.method_30(null);
						}
					}
				}
				num++;
				continue;
			}
			base.InnerList.Clear();
			break;
		}
	}

	internal void Copy(HyperlinkCollection hyperlinkCollection_0)
	{
		for (int i = 0; i < hyperlinkCollection_0.InnerList.Count; i++)
		{
			Hyperlink hyperlink_ = (Hyperlink)hyperlinkCollection_0.InnerList[i];
			Hyperlink hyperlink = new Hyperlink();
			hyperlink.Copy(hyperlink_);
			base.InnerList.Add(hyperlink);
		}
	}

	internal void InsertRows(int int_0, int int_1)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Hyperlink hyperlink = this[i];
			CellArea area = hyperlink.Area;
			bool bool_ = false;
			area = Class1678.InsertRows(area, int_0, int_1, ref bool_);
			if (bool_)
			{
				RemoveAt(i--);
			}
			else
			{
				hyperlink.method_4(area);
			}
		}
	}

	internal void InsertColumns(int int_0, int int_1)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Hyperlink hyperlink = this[i];
			CellArea area = hyperlink.Area;
			bool bool_ = false;
			area = Class1678.InsertColumns(area, int_0, int_1, ref bool_);
			if (bool_)
			{
				RemoveAt(i--);
			}
			else
			{
				hyperlink.method_4(area);
			}
		}
	}

	internal void method_3(CellArea cellArea_0, int int_0, ShiftType shiftType_0)
	{
		switch (shiftType_0)
		{
		case ShiftType.Right:
			method_5(cellArea_0, int_0);
			break;
		case ShiftType.Down:
			method_4(cellArea_0, int_0);
			break;
		}
	}

	private void method_4(CellArea cellArea_0, int int_0)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Hyperlink hyperlink = this[i];
			CellArea area = hyperlink.Area;
			if (cellArea_0.StartColumn <= area.StartColumn && cellArea_0.EndColumn >= area.EndColumn)
			{
				if (cellArea_0.StartRow <= area.StartRow)
				{
					area.StartRow += int_0;
					area.EndRow += int_0;
				}
				else if (cellArea_0.StartRow <= area.EndRow)
				{
					area.EndRow += int_0;
				}
				hyperlink.method_4(area);
			}
		}
	}

	private void method_5(CellArea cellArea_0, int int_0)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Hyperlink hyperlink = this[i];
			CellArea area = hyperlink.Area;
			if (cellArea_0.StartRow <= area.StartRow && cellArea_0.EndRow >= area.EndRow)
			{
				if (cellArea_0.StartColumn <= area.StartColumn)
				{
					area.StartColumn += int_0;
					area.EndColumn += int_0;
				}
				else if (cellArea_0.StartColumn <= area.EndColumn)
				{
					area.EndColumn += int_0;
				}
			}
		}
	}

	internal void method_6(HyperlinkCollection hyperlinkCollection_0, CellArea cellArea_0, CellArea cellArea_1)
	{
		int count = hyperlinkCollection_0.Count;
		for (int i = 0; i < count; i++)
		{
			Hyperlink hyperlink = hyperlinkCollection_0[i];
			object obj = Class1678.Intersect(hyperlink.Area, cellArea_0);
			if (obj != null)
			{
				CellArea cellArea = (CellArea)obj;
				int num = cellArea.StartRow - cellArea_0.StartRow;
				int num2 = cellArea.StartColumn - cellArea_0.StartColumn;
				int firstRow = cellArea_1.StartRow + num;
				int firstColumn = cellArea_1.StartColumn + num2;
				int index = Add(firstRow, firstColumn, cellArea.EndRow - cellArea.StartRow + 1, cellArea.EndColumn - cellArea.StartColumn + 1, hyperlink.Address);
				if (hyperlink.TextToDisplay != null)
				{
					this[index].TextToDisplay = hyperlink.TextToDisplay;
				}
				if (hyperlink.ScreenTip != null)
				{
					this[index].ScreenTip = hyperlink.ScreenTip;
				}
			}
		}
	}

	internal void CopyColumns(HyperlinkCollection hyperlinkCollection_0, int int_0, int int_1, int int_2)
	{
		int num = int_0 + int_2 - 1;
		int count = hyperlinkCollection_0.Count;
		for (int i = 0; i < count; i++)
		{
			Hyperlink hyperlink = hyperlinkCollection_0[i];
			CellArea area = hyperlink.Area;
			int num2 = ((int_0 > area.StartColumn) ? int_0 : area.EndColumn);
			int num3 = ((num < area.EndColumn) ? num : area.EndColumn);
			if (num2 <= num3)
			{
				int num4 = num2 - int_0;
				CellArea cellArea_ = default(CellArea);
				cellArea_.StartRow = area.StartRow;
				cellArea_.EndRow = area.EndRow;
				cellArea_.StartColumn = int_1 + num4;
				cellArea_.EndColumn = cellArea_.StartColumn + num3 - num2;
				Hyperlink hyperlink2 = new Hyperlink(this, cellArea_);
				hyperlink2.CopyData(hyperlink);
				Add(hyperlink2);
			}
		}
	}

	internal void method_7(byte[] byte_0)
	{
		int num = BitConverter.ToUInt16(byte_0, 0);
		int num2 = BitConverter.ToUInt16(byte_0, 2);
		int num3 = byte_0[4];
		int num4 = byte_0[6];
		if (num4 < num3)
		{
			int num5 = num4;
			num4 = num3;
			num3 = num5;
		}
		string text = null;
		int num6 = 28;
		byte[] array = new byte[4];
		Array.Copy(byte_0, 28, array, 0, 4);
		num6 = 28 + 4;
		if ((array[0] & 0x10u) != 0)
		{
			int num7 = BitConverter.ToInt32(byte_0, num6);
			num6 += 4;
			int num8 = num7 + num7 - 2;
			text = Encoding.Unicode.GetString(byte_0, num6, num8);
			num6 += num8 + 2;
		}
		if ((array[0] & 0x80u) != 0)
		{
			int num7 = BitConverter.ToInt32(byte_0, num6);
			num6 += 4 + num7 + num7;
		}
		string text2 = "";
		if (((uint)array[0] & (true ? 1u : 0u)) != 0)
		{
			bool flag = (array[1] & 1) != 0;
			bool flag2 = false;
			if (!flag)
			{
				if (byte_0[num6] == 3 && byte_0[num6 + 1] == 3)
				{
					text2 = method_8(byte_0, ref num6);
					flag2 = true;
				}
				else
				{
					num6 += 16;
				}
			}
			if (!flag2)
			{
				int num7 = BitConverter.ToInt32(byte_0, num6);
				num6 += 4;
				int num8 = num7 - 2;
				if (flag)
				{
					num8 += num7;
				}
				text2 = Encoding.Unicode.GetString(byte_0, num6, num8);
				int num9 = text2.IndexOf('\0');
				if (num9 != -1)
				{
					text2 = text2.Substring(0, num9);
				}
				num6 += num8 + 2;
			}
			if ((array[0] & 8u) != 0)
			{
				int num10 = BitConverter.ToInt32(byte_0, num6);
				if (4 + num10 * 2 + num6 <= byte_0.Length)
				{
					num6 += 4;
					string @string = Encoding.Unicode.GetString(byte_0, num6, (num10 - 1) * 2);
					text2 = text2 + "#" + @string;
				}
			}
		}
		else if (num6 < byte_0.Length)
		{
			int num7 = BitConverter.ToInt32(byte_0, num6);
			num6 += 4;
			int num8 = num7 + num7 - 2;
			text2 = Encoding.Unicode.GetString(byte_0, num6, num8);
		}
		int index = method_1(num, num3, num2 - num + 1, num4 - num3 + 1, text2);
		if (text != null && text != "")
		{
			this[index].method_3(text);
		}
	}

	private string method_8(byte[] byte_0, ref int int_0)
	{
		int_0 += 16;
		int num = BitConverter.ToInt16(byte_0, int_0);
		int_0 += 2;
		int num2 = BitConverter.ToInt32(byte_0, int_0);
		int_0 += 4;
		string text = Encoding.Default.GetString(byte_0, int_0, num2 - 1);
		if (num > 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < num; i++)
			{
				stringBuilder.Append("..\\");
			}
			text = stringBuilder.ToString() + text;
		}
		int_0 += num2 + 24;
		int num3 = BitConverter.ToInt32(byte_0, int_0);
		if (num3 != 0)
		{
			num2 = BitConverter.ToInt32(byte_0, int_0 + 4);
			text = Encoding.Unicode.GetString(byte_0, int_0 + 10, num2);
		}
		int_0 += 4 + num3;
		return text;
	}
}
