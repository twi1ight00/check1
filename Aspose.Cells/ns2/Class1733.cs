using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns2;

internal class Class1733 : ArrayList
{
	private Worksheet worksheet_0;

	public Class1733(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	[SpecialName]
	internal byte method_0()
	{
		int num = 3;
		if (worksheet_0.GetPanes() != null)
		{
			num = worksheet_0.method_1().method_0();
		}
		return (byte)num;
	}

	[SpecialName]
	internal string method_1()
	{
		int num = method_0();
		if (Count == 0)
		{
			return "A1";
		}
		int num2 = 0;
		Class1732 @class;
		while (true)
		{
			if (num2 < Count)
			{
				@class = (Class1732)this[num2];
				if (@class.method_1() == num)
				{
					break;
				}
				num2++;
				continue;
			}
			return "A1";
		}
		return CellsHelper.CellIndexToName(@class.method_5(), @class.method_7());
	}

	[SpecialName]
	internal void method_2(string string_0)
	{
		CellsHelper.CellNameToIndex(string_0, out var row, out var column);
		int count = Count;
		int num = method_0();
		Class1732 @class;
		if (count == 0)
		{
			@class = new Class1732(num);
			@class.method_0(row, column);
			Add(@class);
			return;
		}
		int num2 = 0;
		while (true)
		{
			if (num2 < Count)
			{
				@class = (Class1732)this[num2];
				if (@class.method_1() == num)
				{
					break;
				}
				num2++;
				continue;
			}
			return;
		}
		@class = new Class1732(num);
		@class.method_0(row, column);
		this[num2] = @class;
	}
}
