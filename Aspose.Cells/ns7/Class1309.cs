using Aspose.Cells;
using ns12;

namespace ns7;

internal class Class1309
{
	internal byte[] byte_0;

	internal string string_0;

	internal string string_1;

	internal int int_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal bool bool_3;

	internal Worksheet worksheet_0;

	internal string Values
	{
		get
		{
			return worksheet_0.method_2().method_4().method_4(-1, -1, byte_0, 0, 0, bool_0: false);
		}
		set
		{
			string text = value;
			if (value.StartsWith("="))
			{
				text = text.Substring(1);
			}
			if (text.IndexOf(':') != -1 && text.IndexOf('!') == -1)
			{
				text = "'" + worksheet_0.Name + "'!" + text;
			}
			byte_0 = worksheet_0.method_2().Formula.method_3("=" + text, 0, 0, Enum226.const_0, Enum227.const_0, bool_0: false, bool_1: true);
		}
	}

	internal Class1309(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	internal Class1310[] method_0()
	{
		GetRange();
		Cells cells = worksheet_0.method_2()[string_1].Cells;
		Class1310[] array;
		if (int_0 == int_2)
		{
			array = new Class1310[int_3 - int_1 + 1];
			for (int i = 0; i < array.Length; i++)
			{
				Cell cell = cells.CheckCell(int_0, i + int_1);
				Class1310 @class = (array[i] = new Class1310());
				if (cell == null)
				{
					@class.cellValueType_0 = CellValueType.IsNull;
					continue;
				}
				@class.cellValueType_0 = cell.Type;
				@class.object_0 = cell.Value;
			}
		}
		else
		{
			array = new Class1310[int_2 - int_0 + 1];
			for (int j = 0; j < array.Length; j++)
			{
				Cell cell2 = cells.CheckCell(int_0 + j, int_1);
				Class1310 class2 = (array[j] = new Class1310());
				if (cell2 == null)
				{
					class2.cellValueType_0 = CellValueType.IsNull;
					continue;
				}
				class2.cellValueType_0 = cell2.Type;
				class2.object_0 = cell2.Value;
			}
		}
		return array;
	}

	internal void GetRange()
	{
		Class1279.smethod_1(worksheet_0.method_2(), this, byte_0, -1);
	}
}
