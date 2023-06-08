using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ns1;
using ns12;
using ns16;
using ns2;
using ns25;

namespace Aspose.Cells;

/// <summary>
///        Represents a defined name for a range of cells.
///        </summary>
/// <example>
///   <code>
///
///        [C#]
///
///        //Instantiating a Workbook object
///        Workbook workbook = new Workbook();
///        //Accessing the first worksheet in the Excel file
///        Worksheet worksheet = workbook.Worksheets[0];
///        //Creating a named range
///        Range range = worksheet.Cells.CreateRange("B4", "G14");
///        //Setting the name of the named range
///        range.Name = "TestRange";
///        //Saving the modified Excel file in default (that is Excel 2000) format
///        workbook.Save("C:\\output.xls");   
///
///        [Visual Basic]
///
///        'Instantiating a Workbook object
///        Dim workbook As Workbook = New Workbook()
///        'Accessing the first worksheet in the Excel file
///        Dim worksheet As Worksheet = workbook.Worksheets(0)
///        'Creating a named range
///        Dim range As Range = worksheet.Cells.CreateRange("B4", "G14")
///        'Setting the name of the named range
///        range.Name = "TestRange"
///        'Saving the modified Excel file in default (that is Excel 2000) format
///        workbook.Save("C:\\output.xls")
///        </code>
/// </example>
public class Name
{
	internal Class1365 class1365_0;

	private ushort ushort_0;

	private byte[] byte_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private byte byte_1;

	private string string_5;

	private byte byte_2;

	private int int_0;

	private WorksheetCollection worksheetCollection_0;

	internal string string_6;

	/// <summary>
	///       Gets and sets the commont of the name.
	///       Only applies for Excel 2007.
	///       </summary>
	public string Comment
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	/// <summary>
	///       Gets the name text of the object.
	///       </summary>
	public string Text
	{
		get
		{
			return string_5;
		}
		set
		{
			worksheetCollection_0.Names.method_19(this, value);
			string_5 = value;
		}
	}

	public string FullText
	{
		get
		{
			if (SheetIndex != 0)
			{
				string text = worksheetCollection_0[int_0 - 1].Name;
				if (Class1677.smethod_21(text))
				{
					text = "'" + text + "'";
				}
				return text + "!" + string_5;
			}
			return string_5;
		}
	}

	/// <summary>
	///       Returns or sets the formula that the name is defined to refer to, beginning with an equal sign.
	///       </summary>
	public string RefersTo
	{
		get
		{
			if (string_6 == null && byte_0 != null)
			{
				string_6 = worksheetCollection_0.method_4().method_4(-1, -1, byte_0, 0, 0, bool_0: true);
			}
			return string_6;
		}
		set
		{
			string_6 = value;
			if (value != null && value != "")
			{
				byte_0 = worksheetCollection_0.Formula.method_3(string_6, 0, 0, Enum226.const_2, Enum227.const_0, bool_0: false, bool_1: true);
			}
		}
	}

	/// <summary>
	///        Gets or sets a R1C1 reference of the <see cref="T:Aspose.Cells.Name" />.
	///       </summary>
	public string R1C1RefersTo
	{
		get
		{
			return worksheetCollection_0.method_5().method_2(-1, -1, byte_0, 0, 0, bool_0: true);
		}
		set
		{
			string refersTo = Class1619.smethod_10(value, 0, 0);
			RefersTo = refersTo;
		}
	}

	/// <summary>
	///       Indicates whether this name is referred by other formulas.
	///       </summary>
	public bool IsReferred
	{
		get
		{
			int num = worksheetCollection_0.Names.method_9(string_5, SheetIndex - 1);
			if (num == -1)
			{
				return false;
			}
			Cell cell = null;
			int num2 = 0;
			while (true)
			{
				if (num2 < worksheetCollection_0.Count)
				{
					Cells cells = worksheetCollection_0[num2].Cells;
					for (int i = 0; i < cells.Rows.Count; i++)
					{
						Row rowByIndex = cells.Rows.GetRowByIndex(i);
						for (int j = 0; j < rowByIndex.method_0(); j++)
						{
							cell = rowByIndex.GetCellByIndex(j);
							if (!cell.IsFormula)
							{
								continue;
							}
							if (cell.method_50() != null)
							{
								if (Class1674.smethod_14(cell.method_50().Formula, -1, -1, num, worksheetCollection_0))
								{
									return true;
								}
							}
							else if (Class1674.smethod_14(cell.method_41(), -1, -1, num, worksheetCollection_0))
							{
								return true;
							}
						}
					}
					Worksheet worksheet = worksheetCollection_0[num2];
					if (worksheet.method_36() != null && worksheet.Charts.Count > 0 && worksheet.Charts.method_4(num))
					{
						break;
					}
					ConditionalFormattingCollection conditionalFormattings = worksheet.ConditionalFormattings;
					for (int k = 0; k < conditionalFormattings.Count; k++)
					{
						FormatConditionCollection formatConditionCollection = conditionalFormattings[k];
						for (int l = 0; l < formatConditionCollection.Count; l++)
						{
							FormatCondition formatCondition = formatConditionCollection[l];
							formatCondition.method_11();
							if (formatCondition.method_0() != null)
							{
								byte[] array = formatCondition.method_0();
								Class1674.smethod_14(array, -1, array.Length - 1, num, worksheetCollection_0);
							}
							if (formatCondition.method_4() != null)
							{
								byte[] array2 = formatCondition.method_4();
								Class1674.smethod_14(array2, -1, array2.Length - 1, num, worksheetCollection_0);
							}
						}
					}
					ValidationCollection validations = worksheet.Validations;
					for (int m = 0; m < validations.Count; m++)
					{
						Validation validation = validations[m];
						if (validation.method_7() != null)
						{
							byte[] array3 = validation.method_7();
							Class1674.smethod_14(array3, 0, array3.Length - 1, num, worksheetCollection_0);
						}
						if (validation.method_9() != null)
						{
							byte[] array4 = validation.method_9();
							Class1674.smethod_14(array4, 0, array4.Length - 1, num, worksheetCollection_0);
						}
					}
					num2++;
					continue;
				}
				return false;
			}
			return true;
		}
	}

	/// <summary>
	///       Indicates whether the name is visible. 
	///       </summary>
	public bool IsVisible
	{
		get
		{
			return !IsHidden;
		}
		set
		{
			IsHidden = !value;
		}
	}

	/// <summary>
	///       Indicates this name belongs to Workbook or Worksheet.
	///       0 = Global name, otherwise index to sheet (one-based)
	///       </summary>
	public int SheetIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal bool IsHidden
	{
		get
		{
			return (ushort_0 & 1) != 0;
		}
		set
		{
			if (value)
			{
				ushort_0 |= 1;
			}
			else
			{
				ushort_0 &= 65534;
			}
		}
	}

	internal Enum184 Type
	{
		get
		{
			if ((ushort_0 & 0x20u) != 0)
			{
				return Enum184.const_0;
			}
			if ((ushort_0 & 4u) != 0)
			{
				return Enum184.const_1;
			}
			return Enum184.const_2;
		}
		set
		{
			switch (value)
			{
			case Enum184.const_0:
				ushort_0 |= 32;
				break;
			case Enum184.const_1:
				ushort_0 |= 4;
				break;
			case Enum184.const_2:
				ushort_0 &= 65499;
				break;
			}
		}
	}

	[SpecialName]
	internal ushort method_0()
	{
		return ushort_0;
	}

	[SpecialName]
	internal void method_1(ushort ushort_1)
	{
		ushort_0 = ushort_1;
	}

	[SpecialName]
	internal byte[] method_2()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_3(byte[] byte_3)
	{
		byte_0 = byte_3;
	}

	[SpecialName]
	internal string method_4()
	{
		return string_0;
	}

	[SpecialName]
	internal void method_5(string string_7)
	{
		string_0 = string_7;
	}

	[SpecialName]
	internal string method_6()
	{
		return string_1;
	}

	[SpecialName]
	internal void method_7(string string_7)
	{
		string_1 = string_7;
	}

	[SpecialName]
	internal string method_8()
	{
		return string_2;
	}

	[SpecialName]
	internal void method_9(string string_7)
	{
		string_2 = string_7;
	}

	[SpecialName]
	internal string method_10()
	{
		return string_3;
	}

	[SpecialName]
	internal void method_11(string string_7)
	{
		string_3 = string_7;
	}

	[SpecialName]
	internal byte method_12()
	{
		return byte_1;
	}

	[SpecialName]
	internal void method_13(byte byte_3)
	{
		byte_1 = byte_3;
	}

	[SpecialName]
	internal WorksheetCollection method_14()
	{
		return worksheetCollection_0;
	}

	internal Name(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
	}

	internal Name(WorksheetCollection worksheetCollection_1, string string_7)
	{
		worksheetCollection_0 = worksheetCollection_1;
		string_5 = string_7;
	}

	internal void method_15(string string_7)
	{
		string_5 = string_7;
		Type = Enum184.const_0;
		string key;
		if ((key = string_7) == null)
		{
			return;
		}
		if (Class1742.dictionary_220 == null)
		{
			Class1742.dictionary_220 = new Dictionary<string, int>(14)
			{
				{ "CONSOLIDATE_AREA", 0 },
				{ "AUTO_OPEN", 1 },
				{ "AUTO_CLOSE", 2 },
				{ "EXTRACT", 3 },
				{ "DATABASE", 4 },
				{ "CRITERIA", 5 },
				{ "PRINT_AREA", 6 },
				{ "PRINT_TITLES", 7 },
				{ "RECORDER", 8 },
				{ "DATA_FORM", 9 },
				{ "AUTO_ACTIVATE", 10 },
				{ "AUTO_DEACTIVATE", 11 },
				{ "SHEET_TITLE", 12 },
				{ "_FILTERDATABASE", 13 }
			};
		}
		if (Class1742.dictionary_220.TryGetValue(key, out var value))
		{
			switch (value)
			{
			case 0:
				byte_2 = 0;
				break;
			case 1:
				byte_2 = 1;
				break;
			case 2:
				byte_2 = 2;
				break;
			case 3:
				byte_2 = 3;
				break;
			case 4:
				byte_2 = 4;
				break;
			case 5:
				byte_2 = 5;
				break;
			case 6:
				byte_2 = 6;
				break;
			case 7:
				byte_2 = 7;
				break;
			case 8:
				byte_2 = 8;
				break;
			case 9:
				byte_2 = 9;
				break;
			case 10:
				byte_2 = 10;
				break;
			case 11:
				byte_2 = 11;
				break;
			case 12:
				byte_2 = 12;
				break;
			case 13:
				byte_2 = 13;
				break;
			}
		}
	}

	internal string method_16()
	{
		return string_5;
	}

	internal void method_17(string string_7)
	{
		string_5 = string_7;
	}

	internal void method_18(string string_7)
	{
		string_6 = string_7;
	}

	internal void method_19(string string_7)
	{
		string_6 = string_7;
		if (string_7 != null && !(string_7 == ""))
		{
			byte_0 = worksheetCollection_0.Formula.method_3(string_6, 0, 0, Enum226.const_2, Enum227.const_0, bool_0: false, bool_1: true);
			if (worksheetCollection_0.Formula.method_2())
			{
				byte_0 = null;
			}
			else
			{
				string_6 = null;
			}
		}
	}

	[SpecialName]
	internal bool method_20()
	{
		return (ushort_0 & 4) != 0;
	}

	[SpecialName]
	internal bool method_21()
	{
		return (ushort_0 & 8) != 0;
	}

	[SpecialName]
	internal void method_22(bool bool_0)
	{
		if (bool_0)
		{
			ushort_0 |= 8;
		}
		else
		{
			ushort_0 &= 65407;
		}
	}

	internal void method_23()
	{
		string_6 = null;
	}

	[SpecialName]
	internal int method_24()
	{
		int result = -1;
		if (method_14().Workbook.method_24())
		{
			if (byte_0 != null && byte_0.Length > 2)
			{
				switch (byte_0[4])
				{
				case 58:
				case 59:
				case 90:
				case 91:
				case 122:
				case 123:
				{
					int num = BitConverter.ToUInt16(byte_0, 5);
					int num2 = worksheetCollection_0.method_32().method_12(num);
					if (num2 == worksheetCollection_0.method_36())
					{
						result = worksheetCollection_0.method_32().method_13(num);
					}
					break;
				}
				}
			}
		}
		else if (byte_0 != null && byte_0.Length > 2)
		{
			switch (byte_0[2])
			{
			case 58:
			case 59:
			case 90:
			case 91:
			case 122:
			case 123:
			{
				int num3 = BitConverter.ToUInt16(byte_0, 3);
				int num4 = worksheetCollection_0.method_32().method_12(num3);
				if (num4 == worksheetCollection_0.method_36())
				{
					result = worksheetCollection_0.method_32().method_13(num3);
				}
				break;
			}
			}
		}
		return result;
	}

	[SpecialName]
	internal byte method_25()
	{
		return byte_2;
	}

	internal void method_26(WorksheetCollection worksheetCollection_1, int int_1, string string_7, string string_8)
	{
		if (string_7[0] == '=')
		{
			RefersTo = string_7;
		}
		else
		{
			byte_0 = Class1279.smethod_4(worksheetCollection_1, int_1, string_7);
		}
		int_0 = int_1 + 1;
		method_15(string_8);
	}

	internal void SetRange(int int_1, CellArea cellArea_0)
	{
		byte_0 = Class1279.SetRange(worksheetCollection_0, int_1, cellArea_0);
		string_6 = null;
	}

	internal void method_27(byte[] byte_3)
	{
		ushort_0 = BitConverter.ToUInt16(byte_3, 0);
		byte_1 = byte_3[2];
		int_0 = BitConverter.ToUInt16(byte_3, 8);
		int num = 14;
		byte b = byte_3[3];
		if (Type == Enum184.const_0)
		{
			byte_2 = byte_3[15];
			num = 16;
			switch (byte_2)
			{
			case 0:
				string_5 = "CONSOLIDATE_AREA";
				break;
			case 1:
				string_5 = "AUTO_OPEN";
				break;
			case 2:
				string_5 = "AUTO_CLOSE";
				break;
			case 3:
				string_5 = "EXTRACT";
				break;
			case 4:
				string_5 = "DATABASE";
				break;
			case 5:
				string_5 = "CRITERIA";
				break;
			case 6:
				string_5 = "PRINT_AREA";
				break;
			case 7:
				string_5 = "PRINT_TITLES";
				break;
			case 8:
				string_5 = "RECORDER";
				break;
			case 9:
				string_5 = "DATA_FORM";
				break;
			case 10:
				string_5 = "AUTO_ACTIVATE";
				break;
			case 11:
				string_5 = "AUTO_DEACTIVATE";
				break;
			case 12:
				string_5 = "SHEET_TITLE";
				break;
			case 13:
				string_5 = "_FILTERDATABASE";
				break;
			}
		}
		else
		{
			if (byte_3[14] == 0)
			{
				byte[] array = new byte[2 * b];
				for (int i = 0; i < 2 * b; i++)
				{
					if (i % 2 == 0)
					{
						array[i] = byte_3[15 + i / 2];
					}
				}
				string_5 = Encoding.Unicode.GetString(array);
				num += b + 1;
			}
			else
			{
				string_5 = Encoding.Unicode.GetString(byte_3, 15, b * 2);
				num += 2 * b + 1;
			}
			if (string_5 != null && string_5.IndexOf(' ') != -1)
			{
				string_5 = string_5.Replace(" ", "");
			}
			if (string_5 != null)
			{
				string text = string_5.ToUpper();
				string key;
				if ((key = text) != null)
				{
					if (Class1742.dictionary_221 == null)
					{
						Class1742.dictionary_221 = new Dictionary<string, int>(14)
						{
							{ "CONSOLIDATE_AREA", 0 },
							{ "AUTO_OPEN", 1 },
							{ "AUTO_CLOSE", 2 },
							{ "EXTRACT", 3 },
							{ "DATABASE", 4 },
							{ "CRITERIA", 5 },
							{ "PRINT_AREA", 6 },
							{ "PRINT_TITLES", 7 },
							{ "RECORDER", 8 },
							{ "DATA_FORM", 9 },
							{ "AUTO_ACTIVATE", 10 },
							{ "AUTO_DEACTIVATE", 11 },
							{ "SHEET_TITLE", 12 },
							{ "_FILTERDATABASE", 13 }
						};
					}
					if (Class1742.dictionary_221.TryGetValue(key, out var value))
					{
						switch (value)
						{
						case 0:
							byte_2 = 0;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 1:
							byte_2 = 1;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 2:
							byte_2 = 2;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 3:
							byte_2 = 3;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 4:
							byte_2 = 4;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 5:
							byte_2 = 5;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 6:
							byte_2 = 6;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 7:
							byte_2 = 7;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 8:
							byte_2 = 8;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 9:
							byte_2 = 9;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 10:
							byte_2 = 10;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 11:
							byte_2 = 11;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 12:
							byte_2 = 12;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						case 13:
							byte_2 = 13;
							string_5 = text;
							Type = Enum184.const_0;
							break;
						}
					}
				}
			}
		}
		int num2 = BitConverter.ToUInt16(byte_3, 4);
		if (byte_3[10] + byte_3[11] + byte_3[12] + byte_3[13] == 0)
		{
			if (num2 != 0)
			{
				byte_0 = new byte[byte_3.Length - num + 2];
				Array.Copy(byte_3, 4, byte_0, 0, 2);
				Array.Copy(byte_3, num, byte_0, 2, byte_0.Length - 2);
			}
			return;
		}
		if (num2 != 0)
		{
			byte_0 = new byte[num2 + 2];
			Array.Copy(byte_3, 4, byte_0, 0, 2);
			Array.Copy(byte_3, num, byte_0, 2, byte_0.Length - 2);
			num += byte_0.Length - 2;
		}
		if (byte_3[10] != 0)
		{
			if (byte_3[num] == 0)
			{
				string_0 = Encoding.ASCII.GetString(byte_3, num + 1, byte_3[10]);
				num += 1 + byte_3[10];
			}
			else
			{
				string_0 = Encoding.Unicode.GetString(byte_3, num + 1, byte_3[10] * 2);
				num += 1 + byte_3[10] * 2;
			}
		}
		if (byte_3[11] != 0)
		{
			if (byte_3[num] == 0)
			{
				string_1 = Encoding.ASCII.GetString(byte_3, num + 1, byte_3[11]);
				num += 1 + byte_3[11];
			}
			else
			{
				string_1 = Encoding.Unicode.GetString(byte_3, num + 1, byte_3[11] * 2);
				num += 1 + byte_3[11] * 2;
			}
		}
		if (byte_3[12] != 0)
		{
			if (byte_3[num] == 0)
			{
				string_2 = Encoding.ASCII.GetString(byte_3, num + 1, byte_3[12]);
				num += 1 + byte_3[12];
			}
			else
			{
				string_2 = Encoding.Unicode.GetString(byte_3, num + 1, byte_3[12] * 2);
				num += 1 + byte_3[12] * 2;
			}
		}
		if (byte_3[13] != 0)
		{
			if (byte_3[num] == 0)
			{
				string_3 = Encoding.ASCII.GetString(byte_3, num + 1, byte_3[13]);
				num += 1 + byte_3[13];
			}
			else
			{
				string_3 = Encoding.Unicode.GetString(byte_3, num + 1, byte_3[13] * 2);
				num += 1 + byte_3[13] * 2;
			}
		}
	}

	internal byte[] method_28()
	{
		if (byte_0 == null)
		{
			return null;
		}
		if (method_14().Workbook.method_24())
		{
			byte[] array = new byte[byte_0.Length - 8];
			Array.Copy(byte_0, 4, array, 0, array.Length);
			return array;
		}
		byte[] array2 = new byte[byte_0.Length - 2];
		Array.Copy(byte_0, 2, array2, 0, array2.Length);
		return array2;
	}

	internal void Copy(Name name_0)
	{
		byte_2 = name_0.byte_2;
		int_0 = name_0.int_0;
		string_5 = name_0.string_5;
		ushort_0 = name_0.ushort_0;
		byte_0 = Class1379.Copy(name_0.worksheetCollection_0, worksheetCollection_0, name_0.byte_0, -1, 0, 0);
		string_4 = name_0.string_4;
		string_0 = name_0.string_0;
		string_1 = name_0.string_1;
		string_2 = name_0.string_2;
		byte_1 = name_0.byte_1;
		string_6 = name_0.string_6;
		string_3 = name_0.string_3;
	}

	internal void method_29(Name name_0)
	{
		ushort_0 = name_0.ushort_0;
		byte_2 = name_0.byte_2;
		string_4 = name_0.string_4;
		string_0 = name_0.string_0;
		string_1 = name_0.string_1;
		string_2 = name_0.string_2;
		byte_1 = name_0.byte_1;
		string_3 = name_0.string_3;
		if (name_0.byte_0 != null && name_0.byte_0.Length > 2)
		{
			byte_0 = Class1379.Copy(name_0.worksheetCollection_0, worksheetCollection_0, name_0.byte_0, -1, 0, 0);
		}
		else
		{
			string_6 = name_0.string_6;
		}
	}

	internal void method_30(Name name_0, Hashtable hashtable_0, int int_1)
	{
		ushort_0 = name_0.ushort_0;
		byte_2 = name_0.byte_2;
		string_4 = name_0.string_4;
		string_0 = name_0.string_0;
		string_1 = name_0.string_1;
		string_2 = name_0.string_2;
		byte_1 = name_0.byte_1;
		string_6 = name_0.string_6;
		string_3 = name_0.string_3;
		if (name_0.byte_0 != null && name_0.byte_0.Length > 2)
		{
			byte_0 = Class1379.Copy(name_0.worksheetCollection_0, worksheetCollection_0, name_0.byte_0, -1, 0, 0);
			Class1674.smethod_10(method_14(), hashtable_0, bool_0: false, int_1, -1, -1, byte_0);
		}
	}

	internal void method_31()
	{
		int_0--;
	}

	internal bool method_32()
	{
		return Class1279.smethod_0(worksheetCollection_0, byte_0, -1);
	}

	/// <summary>
	///       Returns a string represents the current Range object.
	///       </summary>
	/// <returns>
	/// </returns>
	public override string ToString()
	{
		return $"Aspose.Cells.Name [ {Text}; ReferTo:{RefersTo}]";
	}

	internal int[] GetCellArea(int int_1, int int_2, bool bool_0)
	{
		int[] array = Class1279.GetRange(worksheetCollection_0, byte_0, -1, bool_0: true, int_1, int_2);
		if (array == null && byte_0 != null && bool_0)
		{
			Class1658 @class = new Class1658(worksheetCollection_0.Workbook);
			Class1661 class2 = worksheetCollection_0.Formula.method_9(this, null);
			if (class2 != null && class2.method_3() != null)
			{
				switch (class2.method_3())
				{
				case "OFFSET":
				case "INDIRECT":
				case ":":
				{
					object obj = @class.method_2(class2, null);
					if (obj != null && obj is Struct87)
					{
						Struct87 @struct = (Struct87)obj;
						array = new int[5]
						{
							worksheetCollection_0.method_32().method_8(@struct.int_0, @struct.int_1),
							@struct.cellArea_0.StartRow,
							@struct.cellArea_0.StartColumn,
							@struct.cellArea_0.EndRow,
							@struct.cellArea_0.EndColumn
						};
					}
					break;
				}
				}
			}
		}
		return array;
	}

	internal Range CreateRange()
	{
		int num = 0;
		int num2 = (num = 0);
		int num3 = 0;
		int[] cellArea = GetCellArea(0, 0, bool_0: true);
		if (cellArea == null)
		{
			return null;
		}
		num = cellArea[0];
		int num4 = cellArea[1];
		int num5 = cellArea[2];
		num2 = cellArea[3];
		num3 = cellArea[4];
		if (num3 < num5)
		{
			int num6 = num5;
			num5 = num3;
			num3 = num6;
		}
		int num7 = worksheetCollection_0.method_32().method_12(num);
		if (num7 != worksheetCollection_0.method_36())
		{
			return null;
		}
		int num8 = worksheetCollection_0.method_32().method_13(num);
		if (num8 >= 0 && num8 <= worksheetCollection_0.Count)
		{
			Cells cells = worksheetCollection_0[num8].Cells;
			Range range = cells.CreateRange(num4, num5, num2 - num4 + 1, num3 - num5 + 1);
			if (int_0 != 0)
			{
				range.method_0(worksheetCollection_0[int_0 - 1].Name + "!" + string_5);
			}
			else
			{
				range.method_0(string_5);
			}
			return range;
		}
		return null;
	}

	internal void InsertRows(int int_1, int int_2, int int_3)
	{
		Class1674.InsertRows(worksheetCollection_0[int_1], bool_0: false, int_2, int_3, int_2, int_2, -1, -1, byte_0);
		string_6 = null;
	}

	internal void InsertColumns(int int_1, int int_2, int int_3)
	{
		Class1674.InsertColumns(worksheetCollection_0[int_1], bool_0: false, int_2, int_3, int_2, int_2, -1, -1, byte_0);
		string_6 = null;
	}

	/// <summary>
	///       Gets all ranges which referred by this name.
	///       </summary>
	/// <returns>All ranges.</returns>
	public Range[] GetRanges()
	{
		if (byte_0 != null && byte_0.Length > 2)
		{
			ArrayList ranges = Class1674.GetRanges(byte_0, -1, -1, worksheetCollection_0, null);
			if (ranges != null && ranges.Count != 0)
			{
				Range[] array = new Range[ranges.Count];
				for (int i = 0; i < ranges.Count; i++)
				{
					array[i] = (Range)ranges[i];
				}
				return array;
			}
			return null;
		}
		return null;
	}

	/// <summary>
	///       Gets the range if this name refers to a range.
	///       </summary>
	/// <returns>The range.</returns>
	public Range GetRange()
	{
		Range range = CreateRange();
		if (range == null)
		{
			string refersTo = RefersTo;
			if (refersTo != null && refersTo.StartsWith("=OFFSET("))
			{
				Class1658 @class = new Class1658(worksheetCollection_0.Workbook);
				Class1661 class1661_ = worksheetCollection_0.Formula.method_9(this, null);
				if (@class.method_2(class1661_, null) is Struct87 @struct)
				{
					if (@struct.int_1 < 0 || @struct.int_1 > worksheetCollection_0.Count)
					{
						return null;
					}
					range = new Range(@struct.cellArea_0.StartRow, @struct.cellArea_0.StartColumn, @struct.cellArea_0.EndRow - @struct.cellArea_0.StartRow + 1, @struct.cellArea_0.EndColumn - @struct.cellArea_0.StartRow, worksheetCollection_0[@struct.int_1].Cells);
				}
			}
		}
		return range;
	}

	internal void method_33()
	{
		byte_0 = null;
		string_6 = null;
	}
}
