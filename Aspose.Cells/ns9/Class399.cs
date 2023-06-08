using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Cells;
using ns1;

namespace ns9;

internal class Class399 : Class316
{
	internal Class399()
	{
	}

	internal void method_6(Cell cell_0, Hashtable hashtable_0)
	{
		int_0 = 3;
		byte_0 = new byte[9];
		Array.Copy(BitConverter.GetBytes(cell_0.Column), 0, byte_0, 0, 4);
		int value = (int)hashtable_0[cell_0.method_35()];
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 4, 4);
		string stringValue;
		if ((stringValue = cell_0.StringValue) == null)
		{
			return;
		}
		if (Class1742.dictionary_56 == null)
		{
			Class1742.dictionary_56 = new Dictionary<string, int>(7)
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
		if (Class1742.dictionary_56.TryGetValue(stringValue, out var value2))
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
}
