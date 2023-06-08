using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns2;

internal class Class991
{
	internal Enum138 enum138_0;

	internal Cell cell_0;

	internal int int_0;

	internal int int_1;

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal int int_2;

	internal bool bool_3;

	internal int int_3;

	internal int int_4;

	internal string string_0;

	internal string string_1;

	internal int int_5;

	internal int int_6;

	internal bool bool_4;

	internal bool bool_5;

	internal int int_7 = -1;

	internal int int_8;

	internal int int_9;

	internal Enum137 enum137_0;

	internal int int_10 = -1;

	internal string string_2;

	internal string[] string_3;

	internal Hashtable hashtable_0;

	internal bool bool_6;

	internal int int_11 = -1;

	internal Row row_0;

	internal string string_4;

	internal bool bool_7;

	internal int int_12 = -1;

	internal bool bool_8;

	internal bool bool_9;

	internal bool bool_10;

	internal bool bool_11;

	internal bool bool_12;

	internal bool bool_13 = true;

	internal bool bool_14;

	internal int int_13;

	internal bool bool_15;

	internal int int_14;

	internal bool bool_16;

	internal int int_15;

	internal bool bool_17;

	internal int int_16;

	internal int int_17 = 100;

	internal int int_18 = 100;

	internal string[] string_5;

	internal Class991()
	{
		int_4 = 0;
		int_3 = -1;
		bool_1 = true;
		bool_0 = true;
		bool_5 = false;
		enum138_0 = Enum138.const_3;
		enum137_0 = Enum137.const_0;
	}

	internal void method_0()
	{
		int_0 = cell_0.Row;
		int_1 = cell_0.Column;
	}

	[SpecialName]
	internal int method_1()
	{
		return (int_9 - 1) * (1 + int_4) + int_9;
	}

	[SpecialName]
	internal int method_2()
	{
		return (int_9 - 1) * (1 + int_4);
	}

	[SpecialName]
	internal int method_3()
	{
		if (bool_3)
		{
			if (int_3 < 0)
			{
				return (int_9 - 1) * (1 + int_4);
			}
			return (int_3 - 1) * (1 + int_4);
		}
		return 0;
	}
}
