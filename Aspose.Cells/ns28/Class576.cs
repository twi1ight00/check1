using System;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using ns2;
using ns27;
using ns45;

namespace ns28;

internal class Class576 : Class538
{
	private Class1175 class1175_0;

	internal Class576(Class1175 class1175_1)
	{
		method_2(176);
		class1175_0 = class1175_1;
		method_5();
	}

	internal int method_4(byte[] byte_1, int int_0, CellArea cellArea_0)
	{
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_0.StartRow), 0, byte_1, int_0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_0.EndRow), 0, byte_1, int_0 + 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_0.StartColumn), 0, byte_1, int_0 + 4, 2);
		if (cellArea_0.EndColumn > 255)
		{
			Array.Copy(BitConverter.GetBytes((ushort)255), 0, byte_1, int_0 + 6, 2);
		}
		else
		{
			Array.Copy(BitConverter.GetBytes((ushort)cellArea_0.EndColumn), 0, byte_1, int_0 + 6, 2);
		}
		return 8;
	}

	internal void method_5()
	{
		int num = Class1677.smethod_29(class1175_0.string_0);
		num += Class1677.smethod_29(class1175_0.string_1);
		method_0((short)(44 + num));
		byte_0 = new byte[base.Length];
		int num2 = 0;
		PivotTable pivotTable_ = class1175_0.pivotTable_0;
		method_4(byte_0, 0, pivotTable_.TableRange1);
		num2 = 0 + 8;
		CellArea columnRange = pivotTable_.ColumnRange;
		int num3 = columnRange.EndRow + 1;
		if (class1175_0.pivotFieldCollection_1.Count != 0 && class1175_0.pivotFieldCollection_2.Count != 0 && class1175_0.pivotFieldCollection_3.Count == 0)
		{
			num3 = columnRange.EndRow + 1;
		}
		Array.Copy(BitConverter.GetBytes((ushort)pivotTable_.int_4), 0, byte_0, num2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)num3), 0, byte_0, num2 + 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)columnRange.StartColumn), 0, byte_0, num2 + 4, 2);
		num2 += 6;
		if (pivotTable_.class1141_0 != null)
		{
			Array.Copy(BitConverter.GetBytes((short)pivotTable_.class1141_0.Index), 0, byte_0, num2, 2);
		}
		Array.Copy(BitConverter.GetBytes((short)0), 0, byte_0, num2 + 2, 2);
		num2 += 4;
		if (class1175_0.pivotFieldCollection_1.Count < 2)
		{
			Array.Copy(BitConverter.GetBytes((short)1), 0, byte_0, num2, 2);
			Array.Copy(BitConverter.GetBytes(ushort.MaxValue), 0, byte_0, num2 + 2, 2);
		}
		else
		{
			PivotField dataField = pivotTable_.DataField;
			int num4 = dataField.Position;
			switch (dataField.pivotFieldType_0)
			{
			case PivotFieldType.Row:
				Array.Copy(BitConverter.GetBytes((short)1), 0, byte_0, num2, 2);
				if (num4 == pivotTable_.RowFields.Count - 1)
				{
					num4 = -1;
				}
				break;
			case PivotFieldType.Column:
				Array.Copy(BitConverter.GetBytes((short)2), 0, byte_0, num2, 2);
				if (num4 == pivotTable_.ColumnFields.Count - 1)
				{
					num4 = -1;
				}
				break;
			}
			if (num4 == -1)
			{
				Array.Copy(BitConverter.GetBytes(ushort.MaxValue), 0, byte_0, num2 + 2, 2);
			}
			else
			{
				Array.Copy(BitConverter.GetBytes((ushort)num4), 0, byte_0, num2 + 2, 2);
			}
		}
		num2 += 4;
		int count = class1175_0.pivotFieldCollection_0.Count;
		Array.Copy(BitConverter.GetBytes((short)count), 0, byte_0, num2, 2);
		num2 += 2;
		count = class1175_0.pivotFieldCollection_2.Count;
		Array.Copy(BitConverter.GetBytes((short)count), 0, byte_0, num2, 2);
		count = class1175_0.pivotFieldCollection_3.Count;
		Array.Copy(BitConverter.GetBytes((short)count), 0, byte_0, num2 + 2, 2);
		count = class1175_0.pivotFieldCollection_4.Count;
		Array.Copy(BitConverter.GetBytes((short)count), 0, byte_0, num2 + 4, 2);
		count = class1175_0.pivotFieldCollection_1.Count;
		Array.Copy(BitConverter.GetBytes((short)count), 0, byte_0, num2 + 6, 2);
		num2 += 8;
		int[] array = new int[2]
		{
			pivotTable_.method_12(),
			pivotTable_.method_13()
		};
		array[0] = ((array[0] == 0) ? 1 : array[0]);
		array[1] = ((array[1] == 0) ? 1 : array[1]);
		Array.Copy(BitConverter.GetBytes((short)array[0]), 0, byte_0, num2, 2);
		Array.Copy(BitConverter.GetBytes((short)array[1]), 0, byte_0, num2 + 2, 2);
		num2 += 4;
		Array.Copy(BitConverter.GetBytes(class1175_0.ushort_0), 0, byte_0, num2, 2);
		num2 += 2;
		Array.Copy(BitConverter.GetBytes(class1175_0.short_0), 0, byte_0, num2, 2);
		num2 += 2;
		count = class1175_0.string_0.Length;
		Array.Copy(BitConverter.GetBytes((short)count), 0, byte_0, num2, 2);
		num2 += 2;
		count = class1175_0.string_1.Length;
		Array.Copy(BitConverter.GetBytes((short)count), 0, byte_0, num2, 2);
		num2 += 2;
		num2 += Class937.smethod_4(byte_0, num2, class1175_0.string_0);
		num2 += Class937.smethod_4(byte_0, num2, class1175_0.string_1);
	}
}
