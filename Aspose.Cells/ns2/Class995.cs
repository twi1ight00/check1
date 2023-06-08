using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns27;

namespace ns2;

internal class Class995
{
	internal FormatCondition formatCondition_0;

	internal int int_0 = -1;

	internal Class1685 class1685_0;

	internal Class578 class578_0;

	internal int int_1;

	internal byte[] byte_0;

	internal Class995(int int_2, FormatCondition formatCondition_1, int int_3)
	{
		int_1 = int_2;
		formatCondition_0 = formatCondition_1;
		switch (formatCondition_1.formatConditionType_0)
		{
		case FormatConditionType.CellValue:
		case FormatConditionType.Expression:
			method_3();
			int_0 = int_3;
			return;
		case FormatConditionType.ColorScale:
		case FormatConditionType.DataBar:
		case FormatConditionType.IconSet:
			return;
		}
		method_3();
		byte_0 = formatCondition_1.method_0();
		if (byte_0 != null)
		{
			int_0 = int_3;
		}
	}

	[SpecialName]
	internal bool method_0()
	{
		if (int_0 > -1)
		{
			return int_0 < 3;
		}
		return false;
	}

	[SpecialName]
	internal bool method_1()
	{
		if (class1685_0 != null)
		{
			return true;
		}
		switch (formatCondition_0.formatConditionType_0)
		{
		default:
			return true;
		case FormatConditionType.CellValue:
		case FormatConditionType.Expression:
			return false;
		}
	}

	[SpecialName]
	internal int method_2()
	{
		int num = 4;
		if (class578_0 != null)
		{
			num += class578_0.Length;
		}
		if (class1685_0 != null)
		{
			num += 8 + Class588.smethod_0(class1685_0);
		}
		if (num <= 4)
		{
			return 6;
		}
		return num;
	}

	private void method_3()
	{
		if (formatCondition_0.style_0 != null)
		{
			class578_0 = new Class578(formatCondition_0.style_0);
			class1685_0 = new Class1685();
			class1685_0.method_1(formatCondition_0.style_0);
			if (class1685_0.Count < 1)
			{
				class1685_0 = null;
			}
		}
	}
}
