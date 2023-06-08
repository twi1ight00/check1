using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Cells;
using ns14;
using ns29;

namespace ns59;

internal class Class1731
{
	private bool bool_0;

	private Cells cells_0;

	private TxtLoadOptions txtLoadOptions_0;

	private Hashtable hashtable_0;

	private Class512 class512_0;

	private Class513 class513_0;

	private Class530 class530_0;

	private Hashtable hashtable_1;

	private ICustomParser[] icustomParser_0;

	private Class1731(Cells cells_1, TxtLoadOptions txtLoadOptions_1)
	{
		cells_0 = cells_1;
		txtLoadOptions_0 = txtLoadOptions_1;
		icustomParser_0 = txtLoadOptions_1.PreferredParsers;
		if (icustomParser_0 != null)
		{
			class530_0 = new Class530();
		}
		if (txtLoadOptions_1.ConvertNumericData)
		{
			class512_0 = cells_1.method_19().Workbook.Settings.method_3().method_6();
			class530_0 = new Class530();
			if (txtLoadOptions_1.method_3())
			{
				hashtable_1 = new Hashtable();
			}
		}
		if (txtLoadOptions_1.ConvertDateTimeData)
		{
			class513_0 = cells_1.method_19().Workbook.Settings.method_3().method_7();
			if (!txtLoadOptions_1.ConvertNumericData)
			{
				class530_0 = new Class530();
				if (txtLoadOptions_1.method_3())
				{
					hashtable_1 = new Hashtable();
				}
			}
		}
		hashtable_0 = cells_1.method_19().class1301_0.method_0();
	}

	internal static void Read(string string_0, Cells cells_1, int int_0, int int_1, TxtLoadOptions txtLoadOptions_1)
	{
		new Class1731(cells_1, txtLoadOptions_1).Read(string_0, int_0, int_1);
	}

	internal static void Read(StreamReader streamReader_0, Cells cells_1, int int_0, int int_1, TxtLoadOptions txtLoadOptions_1)
	{
		new Class1731(cells_1, txtLoadOptions_1).Read(streamReader_0, int_0, int_1);
	}

	private Class530 method_0(string string_0, int int_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			if (icustomParser_0 != null)
			{
				ICustomParser customParser = icustomParser_0[(int_0 < icustomParser_0.Length) ? int_0 : (icustomParser_0.Length - 1)];
				if (customParser != null)
				{
					object obj = customParser.ParseObject(string_0);
					if (obj != null)
					{
						class530_0.method_0(CellValueType.IsUnknown, obj);
						class530_0.method_2(customParser.GetFormat());
						return class530_0;
					}
				}
			}
			switch (string_0.ToUpper())
			{
			case "FALSE":
				class530_0.method_0(CellValueType.IsBool, false);
				class530_0.method_2(null);
				return class530_0;
			case "TRUE":
				class530_0.method_0(CellValueType.IsBool, true);
				class530_0.method_2(null);
				return class530_0;
			default:
				if (hashtable_0[string_0] != null)
				{
					return null;
				}
				if (txtLoadOptions_0.ConvertNumericData && class512_0.ParseObject(string_0) != null)
				{
					return class512_0.method_0();
				}
				if (txtLoadOptions_0.ConvertDateTimeData && class513_0.ParseObject(string_0) != null)
				{
					Class530 @class = class513_0.method_0();
					if (@class.method_1() == CellValueType.IsDateTime)
					{
						double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)@class.Value, cells_0.method_19().Workbook.Settings.Date1904);
						if (doubleFromDateTime < 0.0)
						{
							return null;
						}
						@class.method_0(CellValueType.IsNumeric, doubleFromDateTime);
					}
					return @class;
				}
				return null;
			}
		}
		return null;
	}

	private void method_1(Row row_0, int int_0, int int_1, StringBuilder stringBuilder_0)
	{
		if (stringBuilder_0.Length == 0)
		{
			return;
		}
		Cell cell = row_0.GetCell(int_0);
		string text = stringBuilder_0.ToString();
		if ((txtLoadOptions_0.ConvertNumericData || txtLoadOptions_0.ConvertDateTimeData) && text.Length < 30)
		{
			object obj = (txtLoadOptions_0.method_3() ? hashtable_1[text] : null);
			if (obj != null)
			{
				if (bool_0)
				{
					Cell cell2 = (Cell)obj;
					cell.PutValue(cell2.Value);
					cell.method_37(cell2.method_36());
				}
				else if (obj is Cell)
				{
					Cell cell3 = (Cell)obj;
					cell.PutValue(cell3.Value);
				}
				else
				{
					object[] array = (object[])obj;
					cell.PutValue(((Cell)array[0]).Value);
					method_3(cell, (string)array[1]);
				}
			}
			else
			{
				Class530 @class = method_0(text, int_0 - int_1);
				if (@class != null)
				{
					method_2(cell, @class.Value, @class.method_1());
					string text2 = @class.method_3();
					if (text2 != null)
					{
						method_3(cell, text2);
					}
					if (txtLoadOptions_0.method_3() && @class.method_1() == CellValueType.IsNumeric)
					{
						if (!bool_0 && text2 != null)
						{
							hashtable_1.Add(text, new object[2] { cell, text2 });
						}
						else
						{
							hashtable_1.Add(text, cell);
						}
					}
				}
				else
				{
					cell.method_7(text);
				}
			}
		}
		else
		{
			cell.PutValue(text);
		}
		stringBuilder_0.Remove(0, stringBuilder_0.Length);
	}

	private void method_2(Cell cell_0, object object_0, CellValueType cellValueType_0)
	{
		switch (cellValueType_0)
		{
		case CellValueType.IsBool:
			cell_0.PutValue((bool)object_0);
			return;
		case CellValueType.IsDateTime:
			cell_0.PutValue((DateTime)object_0);
			return;
		case CellValueType.IsNumeric:
		{
			double num = (double)object_0;
			if (num < 2147483647.0 && num > -2147483648.0 && num == (double)(int)num)
			{
				cell_0.PutValue((int)num);
			}
			else
			{
				cell_0.PutValue(num);
			}
			return;
		}
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
		{
			double num2 = (double)object_0;
			if (num2 < 2147483647.0 && num2 > -2147483648.0 && num2 == (double)(int)num2)
			{
				cell_0.PutValue((int)num2);
			}
			else
			{
				cell_0.PutValue(num2);
			}
			break;
		}
		case TypeCode.DateTime:
			cell_0.PutValue((DateTime)object_0);
			break;
		default:
			cell_0.PutValue(object_0);
			break;
		case TypeCode.String:
			cell_0.PutValue((string)object_0);
			break;
		}
	}

	private void method_3(Cell cell_0, string string_0)
	{
		Style style = cell_0.method_28();
		style.Custom = string_0;
		cell_0.method_30(style);
	}

	private void method_4(int int_0, int int_1)
	{
		if (cells_0.Rows.Count < 1)
		{
			bool_0 = true;
			return;
		}
		foreach (Row row in cells_0.Rows)
		{
			if (row.Index < int_0)
			{
				continue;
			}
			if (row.method_10() == 15)
			{
				if (row.method_0() < 1 || row.LastCell.Column < int_1)
				{
					continue;
				}
				foreach (Cell cell in row.Cells)
				{
					if (cell.Column >= int_1 && cell.int_1 != -1 && cell.int_1 != 15)
					{
						bool_0 = false;
						return;
					}
				}
				continue;
			}
			bool_0 = false;
			return;
		}
		bool_0 = true;
	}

	private void Read(string string_0, int int_0, int int_1)
	{
		FileStream stream = File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		StreamReader streamReader = (txtLoadOptions_0.bool_8 ? new StreamReader(stream) : new StreamReader(stream, txtLoadOptions_0.Encoding));
		if (txtLoadOptions_0.method_2())
		{
			method_5(streamReader, int_0, int_1);
		}
		else
		{
			method_6(streamReader, int_0, int_1);
		}
		streamReader.Close();
	}

	private void Read(StreamReader streamReader_0, int int_0, int int_1)
	{
		if (txtLoadOptions_0.method_2())
		{
			method_5(streamReader_0, int_0, int_1);
		}
		else
		{
			method_6(streamReader_0, int_0, int_1);
		}
	}

	private void method_5(StreamReader streamReader_0, int int_0, int int_1)
	{
		char separator = txtLoadOptions_0.Separator;
		streamReader_0.BaseStream.Seek(0L, SeekOrigin.Begin);
		Class1129.smethod_1();
		method_4(int_0, int_1);
		Row row_ = null;
		int int_2 = 0;
		int num = int_0;
		StringBuilder stringBuilder = new StringBuilder();
		while (streamReader_0.Peek() != -1)
		{
			string text = streamReader_0.ReadLine();
			int_2 = int_1;
			row_ = cells_0.Rows.GetRow(num++, bool_0: false, bool_1: false);
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == '"')
				{
					if (stringBuilder.Length != 0)
					{
						stringBuilder.Append(text[i]);
						continue;
					}
					bool flag = true;
					i++;
					while (flag)
					{
						for (; i < text.Length; i++)
						{
							char c = text[i];
							if (c == '"')
							{
								if (i + 1 == text.Length)
								{
									flag = false;
								}
								else if (text[i + 1] == '"')
								{
									stringBuilder.Append(text[i]);
									i++;
								}
								else
								{
									flag = false;
								}
							}
							else
							{
								stringBuilder.Append(text[i]);
							}
							if (!flag)
							{
								break;
							}
						}
						if (flag)
						{
							if (streamReader_0.Peek() == -1)
							{
								break;
							}
							stringBuilder.Append("\n");
							text = streamReader_0.ReadLine();
							i = 0;
						}
					}
				}
				else if (text[i] == separator)
				{
					method_1(row_, int_2++, int_1, stringBuilder);
					if (separator != ' ')
					{
						continue;
					}
					for (i++; i < text.Length; i++)
					{
						if (text[i] != ' ')
						{
							i--;
							break;
						}
					}
				}
				else
				{
					stringBuilder.Append(text[i]);
				}
			}
			if (stringBuilder.Length > 0)
			{
				method_1(row_, int_2++, int_1, stringBuilder);
			}
		}
		if (stringBuilder.Length > 0)
		{
			method_1(row_, int_2, int_1, stringBuilder);
		}
	}

	private void method_6(StreamReader streamReader_0, int int_0, int int_1)
	{
		string separatorString = txtLoadOptions_0.SeparatorString;
		streamReader_0.BaseStream.Seek(0L, SeekOrigin.Begin);
		Class1129.smethod_1();
		method_4(int_0, int_1);
		Row row_ = null;
		int int_2 = 0;
		int num = int_0;
		StringBuilder stringBuilder = new StringBuilder();
		while (streamReader_0.Peek() != -1)
		{
			string text = streamReader_0.ReadLine();
			int_2 = int_1;
			row_ = cells_0.Rows.GetRow(num++, bool_0: false, bool_1: false);
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == '"')
				{
					if (stringBuilder.Length != 0)
					{
						stringBuilder.Append(text[i]);
						continue;
					}
					bool flag = true;
					i++;
					while (flag)
					{
						for (; i < text.Length; i++)
						{
							char c = text[i];
							if (c == '"')
							{
								if (i + 1 == text.Length)
								{
									flag = false;
								}
								else if (text[i + 1] == '"')
								{
									stringBuilder.Append(text[i]);
									i++;
								}
								else
								{
									flag = false;
								}
							}
							else
							{
								stringBuilder.Append(text[i]);
							}
							if (!flag)
							{
								break;
							}
						}
						if (flag && streamReader_0.Peek() != -1)
						{
							stringBuilder.Append("\n");
							text = streamReader_0.ReadLine();
							i = 0;
						}
					}
				}
				else if (text[i] == separatorString[0])
				{
					bool flag2 = true;
					for (int j = 1; j < separatorString.Length && i + j < text.Length; j++)
					{
						if (text[i + j] != separatorString[j])
						{
							flag2 = false;
							break;
						}
					}
					if (flag2)
					{
						method_1(row_, int_2++, int_1, stringBuilder);
						i += separatorString.Length - 1;
					}
					else
					{
						stringBuilder.Append(text[i]);
					}
				}
				else
				{
					stringBuilder.Append(text[i]);
				}
			}
			if (stringBuilder.Length > 0)
			{
				method_1(row_, int_2++, int_1, stringBuilder);
			}
		}
		if (stringBuilder.Length > 0)
		{
			method_1(row_, int_2, int_1, stringBuilder);
		}
		streamReader_0.Close();
	}
}
