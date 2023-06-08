using System;
using System.Runtime.CompilerServices;
using ns12;
using ns2;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the control form ComboBox.
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
///       cells["B3"].PutValue("Employee:");
///
///       //Set it bold.
///       cells["B3"].Style.Font.IsBold = true;
///
///       //Input some values that denote the input range
///       //for the combo box.
///       cells["A2"].PutValue("Emp001");
///       cells["A3"].PutValue("Emp002");
///       cells["A4"].PutValue("Emp003");
///       cells["A5"].PutValue("Emp004");
///       cells["A6"].PutValue("Emp005");
///       cells["A7"].PutValue("Emp006");
///
///       //Add a new combo box.
///       Aspose.Cells.ComboBox comboBox = sheet.Shapes.AddComboBox(2, 0, 2, 0, 22, 100);
///
///       //Set the linked cell;
///       comboBox.LinkedCell = "A1";
///
///       //Set the input range.
///       comboBox.InputRange = "A2:A7";
///
///       //Set no. of list lines displayed in the combo 
///       //box's list portion.
///       comboBox.DropDownLines = 5;
///
///       //Set the combo box with 3-D shading.
///       comboBox.Shadow = true;
///
///       //AutoFit Columns
///       sheet.AutoFitColumns();
///
///       //Saves the file.
///       workbook.Save(@"d:\test\tstcombobox.xls");
///
///       [VB.NET]
///
///       'Create a new Workbook.
///       Dim workbook As Workbook = New Workbook()
///
///       'Get the first worksheet.
///       Dim sheet As Worksheet = workbook.Worksheets(0)
///
///       'Get the worksheet cells collection.
///       Dim cells As Cells = sheet.Cells
///
///       'Input a value.
///       cells("B3").PutValue("Employee:")
///
///       'Set it bold.
///       cells("B3").Style.Font.IsBold = True
///
///       'Input some values that denote the input range
///       'for the combo box.
///       cells("A2").PutValue("Emp001")
///       cells("A3").PutValue("Emp002")
///       cells("A4").PutValue("Emp003")
///       cells("A5").PutValue("Emp004")
///       cells("A6").PutValue("Emp005")
///       cells("A7").PutValue("Emp006")
///
///       'Add a new combo box.
///       Dim comboBox As Aspose.Cells.ComboBox = sheet.Shapes.AddComboBox(2, 0, 2, 0, 22, 100)
///
///       'Set the linked cell;
///       comboBox.LinkedCell = "A1"
///
///       'Set the input range.
///       comboBox.InputRange = "A2:A7"
///
///       'Set no. of list lines displayed in the combo
///       'box's list portion.
///       comboBox.DropDownLines = 5
///
///       'Set the combo box with 3-D shading.
///       comboBox.Shadow = True
///
///       'AutoFit Columns
///       sheet.AutoFitColumns()
///
///       'Saves the file.
///       workbook.Save("d:\test\tstcombobox.xls")
///
///       </code>
/// </example>
public class ComboBox : Shape
{
	private object object_1;

	private byte[] byte_0;

	internal string[] string_4;

	private ushort ushort_1;

	private bool bool_3;

	private bool bool_4;

	private ushort ushort_2 = 8;

	/// <summary>
	///       Gets or sets the worksheet range used to fill the specified combo box. 
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
					}
					else
					{
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
					}
				}
				catch
				{
					byte_0 = method_25().Formula.method_3("=" + value, 0, 0, Enum226.const_0, Enum227.const_0, bool_0: false, bool_1: false);
				}
				string_4 = null;
			}
			else
			{
				byte_0 = null;
			}
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
			if (!bool_3)
			{
				return -1;
			}
			return ushort_1;
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
					if (value >= 0)
					{
						method_26().Cells.GetCell(cellArea.StartRow, cellArea.StartColumn, bool_2: false).PutValue(value + 1);
					}
					else
					{
						method_26().Cells.GetCell(cellArea.StartRow, cellArea.StartColumn, bool_2: false).PutValue(null);
					}
				}
			}
			if (value == -1)
			{
				bool_3 = false;
				return;
			}
			if (value >= 0 && value <= 65535)
			{
				if (value >= method_72())
				{
					throw new ArgumentException("Invalid selected index.");
				}
				ushort_1 = (ushort)value;
				bool_3 = true;
				return;
			}
			throw new ArgumentException("Invalid selected index.");
		}
	}

	/// <summary>
	///       Gets the selected value of the combox box.
	///       </summary>
	public string SelectedValue
	{
		get
		{
			if (string_4 != null && bool_3 && ushort_1 < string_4.Length)
			{
				return string_4[ushort_1];
			}
			Cell selectedCell = SelectedCell;
			if (selectedCell != null)
			{
				return selectedCell.StringValue;
			}
			return "";
		}
	}

	/// <summary>
	///       Gets the selected cell in the input range of the combo box.
	///       </summary>
	public Cell SelectedCell
	{
		get
		{
			if (byte_0 != null && bool_3)
			{
				Cells cells = method_26().Cells;
				bool isArea;
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
				return cells.GetCell(cellArea.StartRow + ushort_1, cellArea.StartColumn, bool_2: false);
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
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	/// <summary>
	///       Gets or sets the number of list lines displayed in the drop-down portion of a combo box. 
	///       </summary>
	public int DropDownLines
	{
		get
		{
			return ushort_2;
		}
		set
		{
			ushort_2 = (ushort)value;
		}
	}

	internal CellArea CellArea
	{
		get
		{
			bool isArea;
			return Class1279.smethod_2(method_25(), byte_0, 0, 0, 0, out isArea);
		}
	}

	internal ComboBox(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.ComboBox, shapeCollection_1)
	{
		ushort_2 = 8;
		bool_3 = false;
	}

	internal ComboBox(ShapeCollection shapeCollection_1, object object_2)
		: base(shapeCollection_1, MsoDrawingType.ComboBox, shapeCollection_1)
	{
		object_1 = object_2;
		method_27().method_7().method_1(bool_1: true);
	}

	[SpecialName]
	internal object method_69()
	{
		return object_1;
	}

	[SpecialName]
	internal byte[] method_70()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_71(byte[] byte_1)
	{
		byte_0 = byte_1;
	}

	[SpecialName]
	internal int method_72()
	{
		if (string_4 != null)
		{
			return string_4.Length;
		}
		if (byte_0 == null)
		{
			return 0;
		}
		CellArea cellArea = CellArea;
		return cellArea.EndRow - cellArea.StartRow + 1;
	}

	internal void method_73(int int_0)
	{
		ushort_1 = (ushort)int_0;
		bool_3 = true;
	}

	internal void Copy(ComboBox comboBox_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)comboBox_0, copyOptions_0);
		ushort_2 = comboBox_0.ushort_2;
		bool_4 = comboBox_0.bool_4;
		byte_0 = Class1379.Copy(comboBox_0.method_25(), method_25(), comboBox_0.byte_0, 0, 0, 0);
		ushort_1 = comboBox_0.ushort_1;
		bool_3 = comboBox_0.bool_3;
		if (comboBox_0.string_4 != null)
		{
			string_4 = comboBox_0.string_4;
		}
	}
}
