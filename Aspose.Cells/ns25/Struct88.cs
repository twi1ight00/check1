using System;
using System.Text;
using Aspose.Cells;

namespace ns25;

internal struct Struct88 : IComparable
{
	public int int_0;

	public int int_1;

	public int int_2;

	public int int_3;

	public int CompareTo(object obj)
	{
		Struct88 @struct = (Struct88)obj;
		if (int_0 > @struct.int_0)
		{
			return 1;
		}
		if (int_0 < @struct.int_0)
		{
			return -1;
		}
		if (int_1 > @struct.int_1)
		{
			return 1;
		}
		if (int_1 < @struct.int_1)
		{
			return -1;
		}
		return 0;
	}

	public Struct88(CellArea cellArea_0)
	{
		int_0 = cellArea_0.StartRow;
		int_1 = cellArea_0.StartColumn;
		int_2 = cellArea_0.EndRow;
		int_3 = cellArea_0.EndColumn;
	}

	public Struct88(int int_4, int int_5, int int_6, int int_7)
	{
		int_0 = int_4;
		int_1 = int_5;
		int_2 = int_6;
		int_3 = int_7;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(int_0);
		stringBuilder.Append(",");
		stringBuilder.Append(int_1);
		stringBuilder.Append(' ');
		stringBuilder.Append(int_2);
		stringBuilder.Append(",");
		stringBuilder.Append(int_3);
		return stringBuilder.ToString();
	}
}
