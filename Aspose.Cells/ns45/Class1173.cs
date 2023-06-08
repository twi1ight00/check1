using System.Runtime.CompilerServices;
using Aspose.Cells.Pivot;

namespace ns45;

internal class Class1173
{
	internal ushort ushort_0;

	internal string string_0;

	internal PivotField pivotField_0;

	internal Class1173(PivotField pivotField_1)
	{
		pivotField_0 = pivotField_1;
		ushort_0 = 1;
	}

	internal void Copy(Class1173 class1173_0)
	{
		string_0 = class1173_0.string_0;
		ushort_0 = class1173_0.ushort_0;
	}

	[SpecialName]
	internal short method_0()
	{
		if (ushort_0 == 1)
		{
			return 1;
		}
		if (ushort_0 == 0)
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < 16; i++)
		{
			num += (ushort_0 >> i) & 1;
		}
		return (short)num;
	}
}
