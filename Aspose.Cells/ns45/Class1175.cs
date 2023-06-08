using Aspose.Cells.Pivot;

namespace ns45;

internal class Class1175
{
	internal PivotTable pivotTable_0;

	internal PivotFieldCollection pivotFieldCollection_0;

	internal PivotFieldCollection pivotFieldCollection_1;

	internal PivotFieldCollection pivotFieldCollection_2;

	internal PivotFieldCollection pivotFieldCollection_3;

	internal PivotFieldCollection pivotFieldCollection_4;

	internal string string_0;

	internal string string_1;

	internal ushort ushort_0;

	internal short short_0;

	internal Class1175(PivotTable pivotTable_1)
	{
		pivotTable_0 = pivotTable_1;
		string_1 = "Data";
		ushort_0 = 527;
		short_0 = 1;
		pivotFieldCollection_0 = new PivotFieldCollection(pivotTable_0, PivotFieldType.Undefined);
		pivotFieldCollection_3 = new PivotFieldCollection(pivotTable_0, PivotFieldType.Column);
		pivotFieldCollection_2 = new PivotFieldCollection(pivotTable_0, PivotFieldType.Row);
		pivotFieldCollection_1 = new PivotFieldCollection(pivotTable_0, PivotFieldType.Data);
		pivotFieldCollection_4 = new PivotFieldCollection(pivotTable_0, PivotFieldType.Page);
	}

	internal Class1175(PivotTable pivotTable_1, string string_2)
	{
		pivotTable_0 = pivotTable_1;
		string_0 = string_2;
		string_1 = "Data";
		ushort_0 = 527;
		short_0 = 1;
		pivotFieldCollection_0 = new PivotFieldCollection(pivotTable_0, pivotTable_0.class1141_0);
		pivotFieldCollection_3 = new PivotFieldCollection(pivotTable_0, PivotFieldType.Column);
		pivotFieldCollection_2 = new PivotFieldCollection(pivotTable_0, PivotFieldType.Row);
		pivotFieldCollection_1 = new PivotFieldCollection(pivotTable_0, PivotFieldType.Data);
		pivotFieldCollection_4 = new PivotFieldCollection(pivotTable_0, PivotFieldType.Page);
	}

	internal void method_0(int int_0)
	{
		pivotFieldCollection_0 = new PivotFieldCollection(pivotTable_0, pivotTable_0.class1141_0, int_0);
	}

	internal void Copy(Class1175 class1175_0)
	{
		string_0 = class1175_0.string_0;
		string_1 = class1175_0.string_1;
		ushort_0 = class1175_0.ushort_0;
		short_0 = class1175_0.short_0;
		int num = 0;
		int num2 = 0;
		foreach (PivotField item in class1175_0.pivotFieldCollection_0.arrayList_0)
		{
			pivotTable_0.BaseFields[num2].Copy(item);
			num2++;
		}
		foreach (PivotField item2 in class1175_0.pivotFieldCollection_1.arrayList_0)
		{
			num = pivotTable_0.AddFieldToArea(PivotFieldType.Data, item2.BaseIndex);
			pivotTable_0.DataFields[num].Copy(item2);
		}
		foreach (PivotField item3 in class1175_0.pivotFieldCollection_3.arrayList_0)
		{
			if (item3.BaseIndex >= 0)
			{
				num = pivotTable_0.AddFieldToArea(PivotFieldType.Column, item3.BaseIndex);
				if (num >= 0 && num < pivotTable_0.ColumnFields.Count)
				{
					pivotTable_0.ColumnFields[num].Copy(item3);
				}
			}
			else if (pivotTable_0.DataField.pivotFieldType_0 == PivotFieldType.Row)
			{
				pivotTable_0.RowFields.method_9(pivotTable_0.DataField);
				pivotTable_0.DataField.pivotFieldType_0 = PivotFieldType.Column;
				pivotTable_0.ColumnFields.arrayList_0.Add(pivotTable_0.DataField);
			}
		}
		foreach (PivotField item4 in class1175_0.pivotFieldCollection_2.arrayList_0)
		{
			if (item4.BaseIndex >= 0)
			{
				num = pivotTable_0.AddFieldToArea(PivotFieldType.Row, item4.BaseIndex);
				if (num >= 0 && num < pivotTable_0.RowFields.Count)
				{
					pivotTable_0.RowFields[num].Copy(item4);
				}
			}
			else if (pivotTable_0.DataField.pivotFieldType_0 == PivotFieldType.Column)
			{
				pivotTable_0.ColumnFields.method_9(pivotTable_0.DataField);
				pivotTable_0.DataField.pivotFieldType_0 = PivotFieldType.Row;
				pivotTable_0.RowFields.arrayList_0.Add(pivotTable_0.DataField);
			}
		}
		foreach (PivotField item5 in class1175_0.pivotFieldCollection_4.arrayList_0)
		{
			num = pivotTable_0.AddFieldToArea(PivotFieldType.Page, item5.BaseIndex);
			if (num >= 0 && num < pivotTable_0.PageFields.Count)
			{
				pivotTable_0.PageFields[num].Copy(item5);
			}
		}
	}

	internal void method_1(bool bool_0, int int_0)
	{
		ushort_0 &= (ushort)(~int_0);
		ushort_0 |= (ushort)(bool_0 ? int_0 : 0);
	}

	internal bool method_2(int int_0)
	{
		return (ushort_0 & int_0) != 0;
	}
}
