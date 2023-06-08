using System.Runtime.CompilerServices;
using Aspose.Cells.Pivot;

namespace ns45;

internal class Class1176
{
	private PivotTable pivotTable_0;

	private PivotTableAutoFormatType pivotTableAutoFormatType_0;

	internal int int_0;

	internal string string_0;

	internal PivotTableAutoFormatType AutoFormatType
	{
		get
		{
			return pivotTableAutoFormatType_0;
		}
		set
		{
			pivotTable_0.bool_19 = false;
			pivotTableAutoFormatType_0 = value;
			if (method_4())
			{
				pivotTable_0.class1175_0.method_1(bool_0: false, 496);
			}
			else
			{
				pivotTable_0.class1175_0.method_1(bool_0: true, 1008);
			}
			if (method_3())
			{
				int_0 |= 4;
			}
		}
	}

	internal Class1176(PivotTable pivotTable_1)
	{
		pivotTable_0 = pivotTable_1;
		pivotTableAutoFormatType_0 = PivotTableAutoFormatType.Classic;
		int_0 = 36;
	}

	internal void Copy(Class1176 class1176_0)
	{
		pivotTableAutoFormatType_0 = class1176_0.pivotTableAutoFormatType_0;
		int_0 = class1176_0.int_0;
	}

	internal bool method_0(int int_1)
	{
		return (int_0 & int_1) != 0;
	}

	internal void method_1(bool bool_0, int int_1)
	{
		int_0 &= (ushort)(~int_1);
		int_0 |= (ushort)(bool_0 ? int_1 : 0);
	}

	internal void method_2(PivotTableAutoFormatType pivotTableAutoFormatType_1)
	{
		pivotTable_0.bool_19 = false;
		pivotTableAutoFormatType_0 = pivotTableAutoFormatType_1;
	}

	[SpecialName]
	internal bool method_3()
	{
		switch (pivotTableAutoFormatType_0)
		{
		default:
			return false;
		case PivotTableAutoFormatType.Report1:
		case PivotTableAutoFormatType.Report2:
		case PivotTableAutoFormatType.Report3:
		case PivotTableAutoFormatType.Report4:
		case PivotTableAutoFormatType.Report5:
		case PivotTableAutoFormatType.Report6:
		case PivotTableAutoFormatType.Report7:
		case PivotTableAutoFormatType.Report8:
		case PivotTableAutoFormatType.Report9:
		case PivotTableAutoFormatType.Report10:
			return true;
		}
	}

	[SpecialName]
	internal bool method_4()
	{
		return pivotTableAutoFormatType_0 == PivotTableAutoFormatType.Classic;
	}
}
