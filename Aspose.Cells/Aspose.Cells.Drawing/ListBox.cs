using System;
using System.Collections;
using System.Runtime.CompilerServices;
using ns12;
using ns2;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents a list box object.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Create a new Workbook.
///       Workbook workbook = new Workbook();
///
///       //Get the first worksheet.
///       Worksheet sheet = workbook.Worksheets[0];
///
///       //Get the worksheet cells collection.
///       Cells cells = sheet.Cells;
///
///       //Input a value.
///       cells["B3"].PutValue("Choose Dept:");
///
///       //Set it bold.
///       cells["B3"].Style.Font.IsBold = true;
///
///       //Input some values that denote the input range
///       //for the list box.
///       cells["A2"].PutValue("Sales");
///       cells["A3"].PutValue("Finance");
///       cells["A4"].PutValue("MIS");
///       cells["A5"].PutValue("R&amp;D");
///       cells["A6"].PutValue("Marketing");
///       cells["A7"].PutValue("HRA");
///
///       //Add a new list box.
///       ListBox listBox = sheet.Shapes.AddListBox(2, 0, 3, 0, 122, 100);
///
///       //Set the placement type.
///       listBox.Placement = PlacementType.FreeFloating;
///
///       //Set the linked cell.
///       listBox.LinkedCell = "A1";
///
///       //Set the input range.
///       listBox.InputRange = "A2:A7";
///
///       //Set the selection tyle.
///       listBox.SelectionType = SelectionType.Single;
///
///       //Set the list box with 3-D shading.
///       listBox.Shadow = true;
///
///       //Saves the file.
///       workbook.Save(@"d:\test\tstlistbox.xls");
///
///       [VB.NET]
///
///       'Create a new Workbook.
///       Dim workbook As Aspose.Cells.Workbook = New Aspose.Cells.Workbook()
///
///       'Get the first worksheet.
///       Dim sheet As Worksheet = workbook.Worksheets(0)
///
///       'Get the worksheet cells collection.
///       Dim cells As Cells = sheet.Cells
///
///       'Input a value.
///       cells("B3").PutValue("Choose Dept:")
///
///       'Set it bold.
///       cells("B3").Style.Font.IsBold = True
///
///       'Input some values that denote the input range
///       'for the list box.
///       cells("A2").PutValue("Sales")
///       cells("A3").PutValue("Finance")
///       cells("A4").PutValue("MIS")
///       cells("A5").PutValue("R&amp;D")
///       cells("A6").PutValue("Marketing")
///       cells("A7").PutValue("HRA")
///
///       'Add a new list box.
///       Dim listBox As Aspose.Cells.ListBox = sheet.Shapes.AddListBox(2, 0, 3, 0, 122, 100)
///
///       'Set the placement type.
///       listBox.Placement = PlacementType.FreeFloating
///
///       'Set the linked cell.
///       listBox.LinkedCell = "A1"
///
///       'Set the input range.
///       listBox.InputRange = "A2:A7"
///
///       'Set the selection tyle.
///       listBox.SelectionType = SelectionType.Single
///
///       'Set the list box with 3-D shading.
///       listBox.Shadow = True
///
///       'Saves the file.
///       workbook.Save("d:\test\tstlistbox.xls")
///       </code>
/// </example>
public class ListBox : Shape
{
	private byte[] byte_0;

	private ArrayList arrayList_0;

	private bool bool_3;

	private SelectionType selectionType_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3 = 1;

	private int int_4 = 8;

	/// <summary>
	///       Gets or sets the worksheet range used to fill the specified list box. 
	///       </summary>
	public string InputRange
	{
		get
		{
			if (byte_0 == null)
			{
				return null;
			}
			string text = method_25().method_4().method_4(0, byte_0.Length, byte_0, 0, 0, bool_0: false);
			if (text != null && text != "" && text[0] == '=')
			{
				return text.Substring(1);
			}
			return text;
		}
		set
		{
			if (value != null && !(value == ""))
			{
				bool isValid = false;
				try
				{
					byte[] array = Class1675.smethod_1(method_25(), method_26().Index, value, externRef: false, validName: true, convertName: false, out isValid);
					if (isValid)
					{
						byte_0 = array;
						return;
					}
					int[] array2 = method_25().Names.method_10(method_26().Index, value, bool_0: false, bool_1: false);
					int num = array2[1];
					if (num != -1)
					{
						array = new byte[5] { 35, 0, 0, 0, 0 };
						Array.Copy(BitConverter.GetBytes(num + 1), 0, array, 1, 2);
						byte_0 = array;
					}
					else
					{
						byte_0 = null;
					}
					return;
				}
				catch
				{
					byte_0 = method_25().Formula.method_3("=" + value, 0, 0, Enum226.const_0, Enum227.const_0, bool_0: false, bool_1: false);
					return;
				}
			}
			byte_0 = null;
		}
	}

	/// <summary>
	///       Gets the number of items in the list box.
	///       </summary>
	public int ItemCount
	{
		get
		{
			if (byte_0 == null)
			{
				return 0;
			}
			CellArea cellArea = CellArea;
			return cellArea.EndRow - cellArea.StartRow + 1;
		}
	}

	/// <summary>
	///       Gets or sets the index number of the currently selected item in a list box or combo box.
	///       Zero-based.
	///       </summary>
	/// <remarks>-1 presents no item is selected.</remarks>
	public int SelectedIndex
	{
		get
		{
			if (arrayList_0 != null && arrayList_0.Count != 0)
			{
				return (ushort)arrayList_0[0];
			}
			return -1;
		}
		set
		{
			if (method_58() != null)
			{
				byte[] data = method_58();
				bool isArea = false;
				CellArea cellArea = Class1279.smethod_2(method_25(), data, 0, 0, 0, out isArea);
				if (isArea)
				{
					Cell cell = method_26().Cells.GetCell(cellArea.StartRow, cellArea.StartColumn, bool_2: false);
					if (selectionType_0 == SelectionType.Multi)
					{
						if (cell.Type == CellValueType.IsNumeric)
						{
							int num = cell.IntValue;
							int itemCount = ItemCount;
							if (num > itemCount)
							{
								num = itemCount;
							}
							cell.PutValue(num);
						}
						else
						{
							cell.PutValue(0);
						}
					}
					else if (value >= 0)
					{
						int num2 = value + 1;
						int itemCount2 = ItemCount;
						if (num2 > itemCount2)
						{
							num2 = itemCount2;
						}
						cell.PutValue(num2);
					}
					else
					{
						cell.PutValue(null);
					}
				}
			}
			if (value == -1)
			{
				arrayList_0 = null;
				return;
			}
			if (value >= 0 && value <= 65535)
			{
				if (arrayList_0 == null)
				{
					arrayList_0 = new ArrayList();
				}
				arrayList_0.Clear();
				arrayList_0.Add((ushort)value);
				return;
			}
			throw new ArgumentException("Invalid selected index.");
		}
	}

	/// <summary>
	///       Gets the selected cells.
	///       Returns null if the input range is not set or no item is selected
	///       </summary>
	public Cell[] SelectedCells
	{
		get
		{
			if (byte_0 != null && arrayList_0 != null && arrayList_0.Count != 0)
			{
				ArrayList arrayList = new ArrayList();
				Cells cells = method_26().Cells;
				bool isArea = false;
				CellArea cellArea = Class1279.smethod_2(method_25(), byte_0, 0, 0, 0, out isArea);
				int num = Class1674.smethod_4(method_25(), byte_0, 0);
				if (num != -1)
				{
					int num2 = method_25().method_32().method_13(num);
					if (num2 < 0 || num2 >= method_25().Count)
					{
						return null;
					}
					cells = method_25()[num2].Cells;
				}
				foreach (ushort item in arrayList_0)
				{
					arrayList.Add(cells.GetCell(cellArea.StartRow + item, cellArea.StartColumn, bool_2: false));
				}
				Cell[] array = new Cell[arrayList.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = (Cell)arrayList[i];
				}
				return array;
			}
			return null;
		}
	}

	/// <summary>
	///       Indicates whether the combobox has 3-D shading.
	///       </summary>
	public bool Shadow
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	/// <summary>
	///       Gets or sets the selection mode of the specified list box. 
	///       </summary>
	public SelectionType SelectionType
	{
		get
		{
			return selectionType_0;
		}
		set
		{
			selectionType_0 = value;
		}
	}

	public int PageChange
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

	internal CellArea CellArea
	{
		get
		{
			bool isArea = false;
			return Class1279.smethod_2(method_25(), byte_0, 0, 0, 0, out isArea);
		}
	}

	internal int IncrementalChange
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	internal ListBox(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.ListBox, shapeCollection_1)
	{
	}

	[SpecialName]
	internal byte[] method_69()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_70(byte[] byte_1)
	{
		byte_0 = byte_1;
	}

	internal void method_71(int int_5)
	{
		if (int_5 == -1)
		{
			arrayList_0 = null;
			return;
		}
		arrayList_0 = new ArrayList();
		arrayList_0.Add((ushort)int_5);
	}

	/// <summary>
	///       Sets whether the item is selected
	///       </summary>
	/// <param name="itemIndex">The item idex</param>
	/// <param name="isSelected">Whether the item is selected.
	///       True means that this item should be selected.
	///       False means that this item should be unselected.
	///       </param>
	public void SelectedItem(int itemIndex, bool isSelected)
	{
		if (itemIndex >= 0 && itemIndex < ItemCount)
		{
			if (SelectionType != 0 && arrayList_0 != null && arrayList_0.Count != 0)
			{
				bool flag = false;
				for (int i = 0; i < arrayList_0.Count; i++)
				{
					if ((ushort)arrayList_0[i] == itemIndex)
					{
						flag = true;
						if (!isSelected)
						{
							arrayList_0.RemoveAt(i);
						}
						break;
					}
				}
				if (isSelected && !flag)
				{
					arrayList_0.Add((ushort)itemIndex);
				}
			}
			else if (isSelected)
			{
				SelectedIndex = itemIndex;
			}
			else
			{
				SelectedIndex = -1;
			}
			return;
		}
		throw new ArgumentException("Invalid selected index.");
	}

	/// <summary>
	///       Indicates whether the item is selected.
	///       </summary>
	/// <param name="itemIndex">The item index.</param>
	/// <returns>whether the item is selected.</returns>
	public bool IsSelected(int itemIndex)
	{
		if (arrayList_0 != null && arrayList_0.Count != 0)
		{
			foreach (ushort item in arrayList_0)
			{
				if (item == itemIndex)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	[SpecialName]
	internal ArrayList method_72()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal void method_73(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}

	[SpecialName]
	internal int method_74()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_75(int int_5)
	{
		int_0 = int_5;
	}

	[SpecialName]
	internal int method_76()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_77(int int_5)
	{
		int_1 = int_5;
	}

	[SpecialName]
	internal int method_78()
	{
		return int_2;
	}

	[SpecialName]
	internal void method_79(int int_5)
	{
		int_2 = int_5;
	}

	internal void Copy(ListBox listBox_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)listBox_0, copyOptions_0);
		selectionType_0 = listBox_0.selectionType_0;
		bool_3 = listBox_0.bool_3;
		byte_0 = Class1379.Copy(listBox_0.method_25(), method_25(), listBox_0.byte_0, 0, 0, 0);
		if (listBox_0.arrayList_0 != null)
		{
			arrayList_0 = new ArrayList();
			{
				foreach (ushort item in listBox_0.arrayList_0)
				{
					arrayList_0.Add(item);
				}
				return;
			}
		}
		arrayList_0 = null;
	}
}
