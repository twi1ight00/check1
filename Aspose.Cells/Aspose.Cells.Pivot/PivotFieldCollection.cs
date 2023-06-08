using System.Collections;
using ns45;

namespace Aspose.Cells.Pivot;

/// <summary>
///       Represents a collection of all the PivotField objects 
///       in the PivotTable's specific PivotFields type.
///       </summary>
public class PivotFieldCollection
{
	internal ArrayList arrayList_0;

	internal PivotTable pivotTable_0;

	internal PivotFieldType pivotFieldType_0;

	internal int int_0;

	/// <summary>
	///        Gets the PivotFields type.
	///       </summary>
	public PivotFieldType Type => pivotFieldType_0;

	/// <summary>
	///       Gets the count of the pivotFields.
	///       </summary>
	public int Count => arrayList_0.Count;

	/// <summary>
	///       Gets the PivotField Object at the specific index.
	///       </summary>
	public PivotField this[int index] => (PivotField)arrayList_0[index];

	public PivotField this[string name]
	{
		get
		{
			foreach (PivotField item in arrayList_0)
			{
				if (item.Name != null && item.Name.ToUpper().Equals(name.ToUpper()))
				{
					return item;
				}
			}
			return null;
		}
	}

	internal PivotFieldCollection(PivotTable pivotTable_1, PivotFieldType pivotFieldType_1)
	{
		pivotTable_0 = pivotTable_1;
		arrayList_0 = new ArrayList();
		pivotFieldType_0 = pivotFieldType_1;
	}

	internal PivotFieldCollection(PivotTable pivotTable_1, Class1141 class1141_0)
	{
		pivotTable_0 = pivotTable_1;
		arrayList_0 = new ArrayList();
		pivotFieldType_0 = PivotFieldType.Undefined;
		for (int i = 0; i < class1141_0.int_1; i++)
		{
			PivotField pivotField = new PivotField(this);
			if (i < class1141_0.arrayList_0.Count)
			{
				pivotField.class1161_0 = (Class1161)class1141_0.arrayList_0[i];
			}
			pivotField.Index = i;
			arrayList_0.Add(pivotField);
		}
	}

	internal PivotFieldCollection(PivotTable pivotTable_1, Class1141 class1141_0, int int_1)
	{
		pivotTable_0 = pivotTable_1;
		arrayList_0 = new ArrayList();
		pivotFieldType_0 = PivotFieldType.Undefined;
		for (int i = 0; i < int_1; i++)
		{
			PivotField value = new PivotField(this)
			{
				class1161_0 = new Class1161(class1141_0),
				Index = i
			};
			arrayList_0.Add(value);
		}
	}

	internal void method_0(Class1161 class1161_0)
	{
		PivotField pivotField = new PivotField(this);
		pivotField.class1173_0.ushort_0 = 0;
		pivotField.class1174_0.ushort_0 = 13328;
		pivotField.class1161_0 = class1161_0;
		pivotField.Index = Count;
		arrayList_0.Add(pivotField);
	}

	internal int method_1()
	{
		int num = 0;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			PivotField pivotField = (PivotField)arrayList_0[i];
			if (pivotField.bool_5)
			{
				num++;
			}
		}
		return num;
	}

	/// <summary>
	///       Adds a PivotField Object to the specific type PivotFields.
	///       </summary>
	/// <param name="baseFieldIndex">field index in the base PivotFields.</param>
	/// <returns>the index of  the PivotField Object in this PivotFields.</returns>
	public int AddByBaseIndex(int baseFieldIndex)
	{
		return Add(pivotTable_0.BaseFields[baseFieldIndex]);
	}

	private void method_2(PivotField pivotField_0, int int_1)
	{
		if (pivotField_0.method_6() || pivotField_0.IsCalculatedField)
		{
			return;
		}
		Class1161 class1161_ = pivotField_0.class1161_0;
		if (class1161_ == null)
		{
			return;
		}
		if (class1161_.arrayList_0 == null)
		{
			if (class1161_.method_27())
			{
				throw new CellsException(ExceptionType.PivotTable, "This pivot field has more unique items than can be used in a pivot table.");
			}
			if (class1161_.method_0().class1144_0 != null)
			{
				class1161_.method_0().class1144_0.method_1(class1161_);
			}
			if (class1161_.method_27())
			{
				throw new CellsException(ExceptionType.PivotTable, "This pivot field has more unique items than can be used in a pivot table.");
			}
			if (class1161_.arrayList_0 != null && class1161_.arrayList_0.Count > int_1)
			{
				throw new CellsException(ExceptionType.PivotTable, "This pivot field has more unique items than can be used in a pivot table.");
			}
		}
		else if (class1161_.arrayList_0.Count > int_1)
		{
			throw new CellsException(ExceptionType.PivotTable, "This pivot field has more unique items than can be used in a pivot table.");
		}
	}

	/// <summary>
	///       Adds a PivotField Object to the specific type PivotFields.
	///       </summary>
	/// <param name="pivotField">a PivotField Object.</param>
	/// <returns>the index of  the PivotField Object in this PivotFields.</returns>
	public int Add(PivotField pivotField)
	{
		if (pivotField == null)
		{
			throw new CellsException(ExceptionType.PivotTable, "You could not null to the specific type PivotFields.");
		}
		if (pivotField.pivotFieldCollection_0.pivotFieldType_0 != 0)
		{
			throw new CellsException(ExceptionType.PivotTable, "This pivot field has been dragged to specific area.");
		}
		PivotFieldType pivotFieldType = pivotField.pivotFieldType_0;
		if (pivotFieldType_0 == pivotFieldType)
		{
			return method_7(pivotField);
		}
		pivotTable_0.bool_1 = false;
		switch (pivotFieldType_0)
		{
		case PivotFieldType.Undefined:
			throw new CellsException(ExceptionType.PivotTable, "You could not add field to base fields");
		case PivotFieldType.Row:
		{
			if (!pivotField.DragToRow)
			{
				throw new CellsException(ExceptionType.PivotTable, "This pivot field can't be dragged to the row position");
			}
			if (!pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.method_24())
			{
				method_2(pivotField, 32767);
			}
			if (pivotFieldType == PivotFieldType.Undefined)
			{
				pivotField.InitPivotItems();
			}
			else
			{
				method_9(pivotField);
			}
			pivotField.pivotFieldType_0 = pivotFieldType_0;
			int num2 = arrayList_0.Add(pivotField);
			method_3(num2);
			return num2;
		}
		case PivotFieldType.Column:
		{
			if (!pivotField.DragToColumn)
			{
				throw new CellsException(ExceptionType.PivotTable, "This pivot field can't be dragged to the column position");
			}
			int num = 0;
			num = (pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.method_24() ? 16383 : 255);
			method_2(pivotField, num);
			if (pivotFieldType == PivotFieldType.Undefined)
			{
				pivotField.InitPivotItems();
			}
			else
			{
				method_9(pivotField);
			}
			pivotField.pivotFieldType_0 = pivotFieldType_0;
			arrayList_0.Add(pivotField);
			return Count - 1;
		}
		case PivotFieldType.Page:
			if (!pivotField.DragToPage)
			{
				throw new CellsException(ExceptionType.PivotTable, "This pivot field can't be dragged to the page position");
			}
			if (pivotField.pivotTable_0 != null)
			{
				throw new CellsException(ExceptionType.PivotTable, "You could not add data field to the page fields");
			}
			method_2(pivotField, 32767);
			if (pivotFieldType == PivotFieldType.Undefined)
			{
				pivotField.InitPivotItems();
			}
			else
			{
				method_9(pivotField);
			}
			if (Count + 1 > pivotTable_0.int_0)
			{
				pivotTable_0.int_0 += 2;
			}
			else if (Count + 1 == pivotTable_0.int_0)
			{
				pivotTable_0.int_0++;
			}
			pivotField.class1170_0 = new Class1170(pivotField);
			pivotField.pivotFieldType_0 = pivotFieldType_0;
			arrayList_0.Add(pivotField);
			return Count - 1;
		default:
			return -1;
		case PivotFieldType.Data:
		{
			pivotField.method_5(bool_7: true);
			PivotField pivotField2 = new PivotField(this, pivotField);
			pivotField2.Index = arrayList_0.Add(pivotField2);
			method_6(bool_0: true, Count - 1);
			return Count - 1;
		}
		}
	}

	internal int Add(PivotField pivotField_0, int int_1)
	{
		if (pivotField_0 == null)
		{
			throw new CellsException(ExceptionType.PivotTable, "You could not null to the specific type PivotFields.");
		}
		if (pivotField_0.pivotFieldCollection_0.pivotFieldType_0 != 0)
		{
			throw new CellsException(ExceptionType.PivotTable, "This pivot field has been dragged to specific area.");
		}
		PivotFieldType pivotFieldType = pivotField_0.pivotFieldType_0;
		if (pivotFieldType_0 == pivotFieldType)
		{
			return method_7(pivotField_0);
		}
		pivotTable_0.bool_1 = false;
		switch (pivotFieldType_0)
		{
		case PivotFieldType.Undefined:
			throw new CellsException(ExceptionType.PivotTable, "You could not add field to base fields");
		case PivotFieldType.Row:
			if (!pivotField_0.DragToRow)
			{
				throw new CellsException(ExceptionType.PivotTable, "This pivot field can't be dragged to the row position");
			}
			method_2(pivotField_0, 32767);
			if (pivotFieldType == PivotFieldType.Undefined)
			{
				pivotField_0.InitPivotItems();
			}
			else
			{
				method_9(pivotField_0);
			}
			pivotField_0.pivotFieldType_0 = pivotFieldType_0;
			arrayList_0.Insert(int_1, pivotField_0);
			method_3(int_1);
			return int_1;
		case PivotFieldType.Column:
		{
			if (!pivotField_0.DragToColumn)
			{
				throw new CellsException(ExceptionType.PivotTable, "This pivot field can't be dragged to the column position");
			}
			int num = 0;
			num = (pivotTable_0.pivotTableCollection_0.worksheet_0.Workbook.method_24() ? 16383 : 255);
			method_2(pivotField_0, num);
			if (pivotFieldType == PivotFieldType.Undefined)
			{
				pivotField_0.InitPivotItems();
			}
			else
			{
				method_9(pivotField_0);
			}
			pivotField_0.pivotFieldType_0 = pivotFieldType_0;
			arrayList_0.Insert(int_1, pivotField_0);
			return Count - 1;
		}
		case PivotFieldType.Page:
			if (!pivotField_0.DragToPage)
			{
				throw new CellsException(ExceptionType.PivotTable, "This pivot field can't be dragged to the page position");
			}
			if (pivotField_0.pivotTable_0 != null)
			{
				throw new CellsException(ExceptionType.PivotTable, "You could not add data field to the page fields");
			}
			method_2(pivotField_0, 32767);
			if (pivotFieldType == PivotFieldType.Undefined)
			{
				pivotField_0.InitPivotItems();
			}
			else
			{
				method_9(pivotField_0);
			}
			if (Count + 1 > pivotTable_0.int_0)
			{
				pivotTable_0.int_0 += 2;
			}
			else if (Count + 1 == pivotTable_0.int_0)
			{
				pivotTable_0.int_0++;
			}
			pivotField_0.class1170_0 = new Class1170(pivotField_0);
			pivotField_0.pivotFieldType_0 = pivotFieldType_0;
			arrayList_0.Insert(int_1, pivotField_0);
			return Count - 1;
		default:
			return -1;
		case PivotFieldType.Data:
		{
			if (pivotField_0.pivotTable_0 != null)
			{
				throw new CellsException(ExceptionType.PivotTable, "You could not add data field to the data fields");
			}
			pivotField_0.method_5(bool_7: true);
			PivotField pivotField = new PivotField(this, pivotField_0);
			pivotField.Index = arrayList_0.Add(pivotField);
			method_6(bool_0: true, Count - 1);
			return Count - 1;
		}
		}
	}

	private void method_3(int int_1)
	{
		if (Count <= 1)
		{
			return;
		}
		switch (pivotTable_0.AutoFormatType)
		{
		case PivotTableAutoFormatType.Report4:
		case PivotTableAutoFormatType.Report5:
		case PivotTableAutoFormatType.Report6:
		case PivotTableAutoFormatType.Report7:
		case PivotTableAutoFormatType.Report10:
			if (int_1 == Count - 1)
			{
				this[int_1].InsertBlankRow = false;
				this[int_1 - 1].InsertBlankRow = true;
			}
			else
			{
				this[int_1].InsertBlankRow = true;
			}
			break;
		case PivotTableAutoFormatType.Table6:
			break;
		case PivotTableAutoFormatType.Report1:
		case PivotTableAutoFormatType.Report2:
		case PivotTableAutoFormatType.Report3:
		case PivotTableAutoFormatType.Report8:
		case PivotTableAutoFormatType.Report9:
		case PivotTableAutoFormatType.Table1:
		case PivotTableAutoFormatType.Table2:
		case PivotTableAutoFormatType.Table3:
		case PivotTableAutoFormatType.Table4:
		case PivotTableAutoFormatType.Table5:
		case PivotTableAutoFormatType.Table7:
			if (int_1 == 0)
			{
				this[0].InsertBlankRow = true;
				this[1].InsertBlankRow = false;
			}
			else
			{
				this[int_1].InsertBlankRow = false;
			}
			break;
		}
	}

	internal void method_4(PivotField pivotField_0)
	{
		arrayList_0.Add(pivotField_0);
	}

	internal void method_5(PivotField pivotField_0)
	{
		if (pivotFieldType_0 != 0)
		{
			pivotTable_0.bool_1 = false;
			arrayList_0.Remove(pivotField_0);
			if (pivotFieldType_0 == PivotFieldType.Data)
			{
				pivotField_0.method_5(bool_7: false);
			}
			else
			{
				pivotField_0.pivotFieldType_0 = PivotFieldType.Undefined;
			}
		}
	}

	internal void Remove(PivotField pivotField_0)
	{
		if (pivotFieldType_0 == PivotFieldType.Undefined)
		{
			return;
		}
		pivotTable_0.bool_1 = false;
		int count = pivotTable_0.DataFields.Count;
		arrayList_0.Remove(pivotField_0);
		pivotTable_0.method_11();
		if (pivotFieldType_0 == PivotFieldType.Data)
		{
			pivotField_0.method_5(bool_7: false);
			if (pivotTable_0.pivotField_0.pivotFieldType_0 == PivotFieldType.Row)
			{
				pivotTable_0.RowFields.Remove(pivotTable_0.pivotField_0);
				pivotTable_0.arrayList_0 = null;
			}
			else if (pivotTable_0.pivotField_0.pivotFieldType_0 == PivotFieldType.Column)
			{
				pivotTable_0.ColumnFields.Remove(pivotTable_0.pivotField_0);
				pivotTable_0.arrayList_1 = null;
			}
			pivotTable_0.pivotField_0 = null;
			return;
		}
		if (pivotField_0 == pivotTable_0.pivotField_0 && count > 1)
		{
			pivotTable_0.class1175_0.pivotFieldCollection_1.arrayList_0.Clear();
			pivotTable_0.pivotField_0 = null;
			for (int i = 0; i < pivotTable_0.BaseFields.Count; i++)
			{
				PivotField pivotField = pivotTable_0.BaseFields[i];
				if (pivotField.method_4())
				{
					pivotField.method_5(bool_7: false);
				}
			}
		}
		pivotField_0.pivotFieldType_0 = PivotFieldType.Undefined;
	}

	private void method_6(bool bool_0, int int_1)
	{
		PivotFieldCollection dataFields = pivotTable_0.DataFields;
		PivotField pivotField_ = pivotTable_0.pivotField_0;
		PivotFieldCollection pivotFieldCollection = null;
		if (pivotField_ != null)
		{
			int num = pivotTable_0.RowFields.method_7(pivotField_);
			pivotFieldCollection = ((num != -1) ? pivotTable_0.RowFields : pivotTable_0.ColumnFields);
		}
		if (dataFields.Count <= 1)
		{
			if (pivotField_ != null)
			{
				pivotFieldCollection.Remove(pivotField_);
				pivotTable_0.pivotField_0 = null;
			}
			return;
		}
		if (pivotField_ == null)
		{
			pivotField_ = (pivotTable_0.pivotField_0 = new PivotField(pivotTable_0, dataFields));
			pivotField_.Index = 65534;
			pivotFieldCollection = pivotTable_0.RowFields;
			pivotFieldCollection.arrayList_0.Add(pivotField_);
			return;
		}
		if (bool_0)
		{
			PivotItem pivotItem = new PivotItem(pivotField_.pivotItemCollection_0);
			pivotField_.pivotItemCollection_0.Add(pivotItem);
			pivotItem.Index = int_1;
			pivotItem.pivotField_0 = dataFields[int_1];
			return;
		}
		int count = pivotField_.pivotItemCollection_0.Count;
		pivotField_.pivotItemCollection_0.RemoveAt(int_1);
		if (int_1 == count - 1)
		{
			return;
		}
		int num2 = 0;
		foreach (PivotItem item in pivotField_.pivotItemCollection_0.arrayList_0)
		{
			item.Index = num2++;
		}
	}

	internal int method_7(PivotField pivotField_0)
	{
		int num = -1;
		foreach (PivotField item in arrayList_0)
		{
			num++;
			if (item == pivotField_0)
			{
				return num;
			}
		}
		return -1;
	}

	internal object method_8(string string_0)
	{
		if (string_0 == null)
		{
			return null;
		}
		foreach (PivotField item in arrayList_0)
		{
			if (item.Name.ToUpper().Equals(string_0.ToUpper()))
			{
				return item;
			}
		}
		return null;
	}

	internal void method_9(PivotField pivotField_0)
	{
		Class1175 class1175_ = pivotTable_0.class1175_0;
		switch (pivotField_0.pivotFieldType_0)
		{
		case PivotFieldType.Undefined:
			throw new CellsException(ExceptionType.PivotTable, "Can't remove the base field from BaseFields.");
		case PivotFieldType.Row:
			class1175_.pivotFieldCollection_2.method_5(pivotField_0);
			break;
		case PivotFieldType.Column:
			class1175_.pivotFieldCollection_3.method_5(pivotField_0);
			break;
		case PivotFieldType.Page:
			pivotField_0.class1170_0.pivotField_0 = null;
			pivotField_0.class1170_0 = null;
			class1175_.pivotFieldCollection_4.method_5(pivotField_0);
			break;
		default:
			throw new CellsException(ExceptionType.PivotTable, "Invalid field type");
		case PivotFieldType.Data:
			pivotField_0.pivotFieldCollection_0 = null;
			class1175_.pivotFieldCollection_1.method_5(pivotField_0);
			pivotField_0.pivotField_0.method_5(bool_7: false);
			break;
		}
	}
}
