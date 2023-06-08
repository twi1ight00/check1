using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Cells;
using ns1;
using ns10;

namespace ns9;

internal class Class400 : Class316
{
	internal Class400()
	{
	}

	internal void method_6(Cell cell_0, Hashtable hashtable_0)
	{
		int num = 0;
		int num2 = 0;
		byte[] array = cell_0.method_44();
		num2 = array.Length;
		object value = cell_0.Value;
		switch (cell_0.Type)
		{
		case CellValueType.IsBool:
			int_0 = 10;
			byte_0 = new byte[11 + num2];
			if ((bool)value)
			{
				byte_0[8] = 1;
			}
			num = 9;
			break;
		case CellValueType.IsError:
		{
			int_0 = 11;
			byte_0 = new byte[11 + num2];
			string key;
			if ((key = (string)value) != null)
			{
				if (Class1742.dictionary_57 == null)
				{
					Class1742.dictionary_57 = new Dictionary<string, int>(7)
					{
						{ "#NULL!", 0 },
						{ "#DIV/0!", 1 },
						{ "#VALUE!", 2 },
						{ "#REF!", 3 },
						{ "#NAME?", 4 },
						{ "#NUM!", 5 },
						{ "#N/A", 6 }
					};
				}
				if (Class1742.dictionary_57.TryGetValue(key, out var value2))
				{
					switch (value2)
					{
					case 0:
						byte_0[8] = 0;
						break;
					case 1:
						byte_0[8] = 7;
						break;
					case 2:
						byte_0[8] = 15;
						break;
					case 3:
						byte_0[8] = 23;
						break;
					case 4:
						byte_0[8] = 29;
						break;
					case 5:
						byte_0[8] = 36;
						break;
					case 6:
						byte_0[8] = 42;
						break;
					}
				}
			}
			num = 9;
			break;
		}
		case CellValueType.IsDateTime:
		case CellValueType.IsNumeric:
		{
			int_0 = 9;
			byte_0 = new byte[18 + num2];
			double num3 = 0.0;
			num3 = cell_0.DoubleValue;
			Array.Copy(BitConverter.GetBytes(num3), 0, byte_0, 8, 8);
			num = 16;
			break;
		}
		case CellValueType.IsNull:
		case CellValueType.IsString:
		{
			int_0 = 8;
			string text = (string)value;
			if (text == null)
			{
				text = "";
			}
			byte_0 = new byte[14 + text.Length * 2 + num2];
			num = 8;
			Class1217.smethod_7(byte_0, ref num, text);
			break;
		}
		}
		Array.Copy(BitConverter.GetBytes(cell_0.Column), 0, byte_0, 0, 4);
		int value3 = (int)hashtable_0[cell_0.method_35()];
		Array.Copy(BitConverter.GetBytes(value3), 0, byte_0, 4, 4);
		if (cell_0.method_4().method_19().Workbook.Settings.ReCalculateOnOpen)
		{
			byte_0[num] = 2;
		}
		Array.Copy(array, 0, byte_0, num + 2, array.Length);
	}
}
