using System;
using System.Collections;
using System.Runtime.CompilerServices;
using ns2;
using ns29;

namespace Aspose.Cells;

/// <summary>
///       Represents data validation collection.
///       </summary>
public class ValidationCollection : CollectionBase
{
	private Worksheet worksheet_0;

	private int int_0 = -1;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Validation" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public Validation this[int index] => (Validation)base.InnerList[index];

	internal Worksheet Worksheet => worksheet_0;

	internal ValidationCollection(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	internal int method_0(Validation validation_0)
	{
		base.InnerList.Add(validation_0);
		return base.Count - 1;
	}

	/// <summary>
	///       Adds a data validation to the collection.
	///       </summary>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Validation" /> object index.</returns>
	public int Add()
	{
		Validation value = new Validation(this);
		base.InnerList.Add(value);
		return base.Count - 1;
	}

	/// <summary>
	///       Add a <see cref="T:Aspose.Cells.Validation" /> to the collection.
	///       </summary>
	/// <param name="validation"> A validation object.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Validation" /> object index.</returns>
	public int Add(Validation validation)
	{
		for (int i = 0; i < validation.AreaList.Count; i++)
		{
			CellArea ca = (CellArea)validation.AreaList[i];
			RemoveArea(ca);
		}
		base.InnerList.Add(validation);
		return base.Count - 1;
	}

	/// <summary>
	///       Removes all validation setting on the cell.
	///       </summary>
	/// <param name="row">The row index of the cell.</param>
	/// <param name="column">The column index of the cell.</param>
	public void RemoveACell(int row, int column)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Validation validation = (Validation)enumerator.Current;
				validation.RemoveACell(row, column);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	/// <summary>
	///        Removes all validation setting on the range..
	///        </summary>
	/// <param name="ca">The range which contains the validations setting.</param>
	public void RemoveArea(CellArea ca)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Validation validation = this[i];
			validation.RemoveArea(ca);
			if (validation.AreaList.Count <= 0)
			{
				RemoveAt(i--);
			}
		}
	}

	internal void RemoveArea(CellArea cellArea_0, Validation validation_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Validation validation = this[i];
			validation.RemoveArea(cellArea_0);
			if (validation != validation_0 && validation.AreaList.Count <= 0)
			{
				RemoveAt(i--);
			}
		}
	}

	/// <summary>
	///       Gets a <see cref="T:Aspose.Cells.Validation" /> object in the cell.
	///       </summary>
	/// <param name="row">The row index.</param>
	/// <param name="column">The column index.</param>
	/// <returns>Returns a <see cref="T:Aspose.Cells.Validation" /> object.</returns>
	/// <remarks>
	///       Please call <see cref="M:Aspose.Cells.ValidationCollection.Add(Aspose.Cells.Validation)" /> method 
	///       if you want to apply the modified validation to the cell.
	///       </remarks>
	public Validation GetValidationInCell(int row, int column)
	{
		CellArea cellArea = default(CellArea);
		cellArea.StartRow = row;
		cellArea.EndRow = row;
		cellArea.EndColumn = column;
		cellArea.EndColumn = column;
		for (int i = 0; i < base.Count; i++)
		{
			Validation validation = this[i];
			for (int j = 0; j < validation.AreaList.Count; j++)
			{
				CellArea cellArea2 = (CellArea)validation.AreaList[j];
				if (row >= cellArea2.StartRow && row <= cellArea2.EndRow && column >= cellArea2.StartColumn && column <= cellArea2.EndColumn)
				{
					if (cellArea2.StartRow == cellArea2.EndRow && cellArea2.StartColumn == cellArea2.EndColumn)
					{
						return validation;
					}
					Validation validation2 = new Validation(this);
					validation2.Copy(validation, cellArea, Worksheet, null);
					return validation2;
				}
			}
		}
		Validation validation3 = new Validation(this);
		validation3.AreaList.Add(cellArea);
		return validation3;
	}

	internal void Copy(ValidationCollection validationCollection_0, CopyOptions copyOptions_0)
	{
		for (int i = 0; i < validationCollection_0.Count; i++)
		{
			Validation validation_ = validationCollection_0[i];
			Validation validation = new Validation(this);
			validation.Copy(validation_, copyOptions_0);
			method_0(validation);
		}
		int_0 = validationCollection_0.int_0;
	}

	private void method_1()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Validation validation = (Validation)enumerator.Current;
				validation.method_12(out var _, out var _);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal void method_2(ValidationCollection validationCollection_0, int int_1, int int_2, int int_3, CopyOptions copyOptions_0)
	{
		method_1();
		for (int i = 0; i < validationCollection_0.Count; i++)
		{
			Validation validation = validationCollection_0[i];
			int count = validation.AreaList.Count;
			for (int j = 0; j < count; j++)
			{
				CellArea cellArea_ = (CellArea)validation.AreaList[j];
				object obj = Class1678.smethod_4(cellArea_, int_1, int_3);
				if (obj != null)
				{
					cellArea_ = (CellArea)obj;
					CellArea cellArea_2 = default(CellArea);
					cellArea_2.StartRow = int_2;
					cellArea_2.StartColumn = cellArea_.StartColumn;
					cellArea_2.EndRow = cellArea_.EndRow - cellArea_.StartRow + cellArea_2.StartRow;
					cellArea_2.EndColumn = cellArea_.EndColumn;
					if (validationCollection_0 == this)
					{
						Class1678.smethod_0(validation.AreaList, cellArea_2);
						continue;
					}
					Validation validation2 = new Validation(this);
					validation2.Copy(validation, cellArea_2, worksheet_0, copyOptions_0);
					base.InnerList.Add(validation2);
				}
			}
		}
	}

	internal void method_3(ValidationCollection validationCollection_0, int int_1, int int_2, int int_3, CopyOptions copyOptions_0)
	{
		method_1();
		for (int i = 0; i < validationCollection_0.Count; i++)
		{
			Validation validation = validationCollection_0[i];
			int count = validation.AreaList.Count;
			for (int j = 0; j < count; j++)
			{
				CellArea cellArea_ = (CellArea)validation.AreaList[j];
				object obj = Class1678.smethod_5(cellArea_, int_1, int_3);
				if (obj != null)
				{
					cellArea_ = (CellArea)obj;
					CellArea cellArea_2 = default(CellArea);
					cellArea_2.StartRow = cellArea_.StartRow;
					cellArea_2.EndRow = cellArea_.EndRow;
					cellArea_2.StartColumn = int_2;
					cellArea_2.EndColumn = cellArea_.EndColumn - cellArea_.StartColumn + int_2;
					if (validationCollection_0 == this)
					{
						Class1678.smethod_0(validation.AreaList, cellArea_2);
						continue;
					}
					Validation validation2 = new Validation(this);
					validation2.Copy(validation, cellArea_2, worksheet_0, copyOptions_0);
					base.InnerList.Add(validation2);
				}
			}
		}
	}

	internal void CopyInRange(ValidationCollection validationCollection_0, CellArea cellArea_0, CellArea cellArea_1, CopyOptions copyOptions_0, bool bool_0)
	{
		if (bool_0)
		{
			return;
		}
		method_1();
		for (int i = 0; i < validationCollection_0.Count; i++)
		{
			Validation validation = validationCollection_0[i];
			int count = validation.AreaList.Count;
			for (int j = 0; j < count; j++)
			{
				CellArea cellArea_2 = (CellArea)validation.AreaList[j];
				object obj = Class1678.Intersect(cellArea_2, cellArea_0);
				if (obj != null)
				{
					cellArea_2 = (CellArea)obj;
					CellArea cellArea_3 = default(CellArea);
					cellArea_3.StartRow = cellArea_2.StartRow - cellArea_0.StartRow + cellArea_1.StartRow;
					cellArea_3.StartColumn = cellArea_2.StartColumn - cellArea_0.StartColumn + cellArea_1.StartColumn;
					cellArea_3.EndRow = cellArea_2.EndRow - cellArea_2.StartRow + cellArea_3.StartRow;
					cellArea_3.EndColumn = cellArea_2.EndColumn - cellArea_2.StartColumn + cellArea_3.StartColumn;
					if (validationCollection_0 == this)
					{
						Class1678.smethod_0(validation.AreaList, cellArea_3);
						continue;
					}
					Validation validation2 = new Validation(this);
					validation2.Copy(validation, cellArea_3, worksheet_0, copyOptions_0);
					base.InnerList.Add(validation2);
				}
			}
		}
	}

	internal void method_4(CellArea cellArea_0, int int_1, ShiftType shiftType_0, Worksheet worksheet_1, bool bool_0)
	{
		WorksheetCollection worksheetCollection = worksheet_0.method_2();
		for (int i = 0; i < base.Count; i++)
		{
			Validation validation = this[i];
			if (validation.AreaList == null || validation.AreaList.Count == 0)
			{
				continue;
			}
			_ = validation.AreaList.Count;
			validation.method_12(out var row, out var column);
			bool flag = validation.method_11();
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			switch (shiftType_0)
			{
			case ShiftType.Down:
				Class1678.smethod_14(validation.AreaList, worksheetCollection.Workbook.method_23(), cellArea_0, int_1, arrayList, arrayList2);
				break;
			case ShiftType.Left:
				Class1678.smethod_19(validation.AreaList, worksheetCollection.Workbook.method_23(), cellArea_0, int_1, arrayList, arrayList2);
				break;
			case ShiftType.Right:
				Class1678.smethod_20(validation.AreaList, worksheetCollection.Workbook.method_23(), cellArea_0, int_1, arrayList, arrayList2);
				break;
			case ShiftType.Up:
				Class1678.smethod_15(validation.AreaList, worksheetCollection.Workbook.method_23(), cellArea_0, int_1, arrayList, arrayList2);
				break;
			}
			if (flag)
			{
				validation.AreaList.Clear();
				if (arrayList.Count != 0)
				{
					validation.AreaList.AddRange(arrayList);
					method_5(bool_0: false, validation, cellArea_0, int_1, shiftType_0, worksheet_1, bool_0, row, column);
				}
				if (arrayList2.Count != 0)
				{
					if (arrayList.Count != 0)
					{
						Validation validation2 = new Validation(this);
						validation2.CopyData(validation);
						validation = validation2;
						base.InnerList.Insert(i, validation);
						i++;
					}
					validation.AreaList.AddRange(arrayList2);
					int[] array = validation.method_4();
					row = array[0];
					column = array[1];
					method_5(bool_0: true, validation, cellArea_0, int_1, shiftType_0, worksheet_1, bool_0, row, column);
				}
			}
			else
			{
				validation.AreaList.Clear();
				validation.AreaList.AddRange(arrayList);
				validation.AreaList.AddRange(arrayList2);
				method_5(bool_0: false, validation, cellArea_0, int_1, shiftType_0, worksheet_1, bool_0, row, column);
			}
		}
	}

	private void method_5(bool bool_0, Validation validation_0, CellArea cellArea_0, int int_1, ShiftType shiftType_0, Worksheet worksheet_1, bool bool_1, int int_2, int int_3)
	{
		int num = int_2;
		int num2 = int_3;
		if (bool_0)
		{
			switch (shiftType_0)
			{
			case ShiftType.Down:
				num -= int_1;
				break;
			case ShiftType.Left:
				num2 += int_1;
				break;
			case ShiftType.Right:
				num2 -= int_1;
				break;
			case ShiftType.Up:
				num += int_1;
				break;
			}
		}
		if (validation_0.byte_0 != null)
		{
			byte[] byte_ = validation_0.byte_0;
			Class1674.smethod_19(cellArea_0, int_1, shiftType_0, worksheet_1, bool_1, byte_, 0, byte_.Length - 1, num, num2, int_2, int_3);
			validation_0.byte_0 = byte_;
		}
		if ((validation_0.Operator == OperatorType.Between || validation_0.Operator == OperatorType.NotBetween) && validation_0.byte_1 != null)
		{
			byte[] byte_2 = validation_0.byte_1;
			Class1674.smethod_19(cellArea_0, int_1, shiftType_0, worksheet_1, bool_1, byte_2, 0, byte_2.Length - 1, num, num2, int_2, int_3);
			validation_0.byte_1 = byte_2;
		}
	}

	internal void InsertColumns(int int_1, int int_2)
	{
		if (int_2 == 0)
		{
			return;
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Validation validation = (Validation)enumerator.Current;
				validation.InsertColumns(int_1, int_2, worksheet_0);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal void InsertRows(int int_1, int int_2)
	{
		if (int_2 == 0)
		{
			return;
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Validation validation = (Validation)enumerator.Current;
				validation.InsertRows(int_1, int_2, worksheet_0);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	[SpecialName]
	internal int method_6()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_7(int int_1)
	{
		int_0 = int_1;
	}

	[SpecialName]
	internal bool method_8()
	{
		if (int_0 != -1)
		{
			return true;
		}
		if (base.Count == 0)
		{
			return false;
		}
		string activeCell = worksheet_0.ActiveCell;
		int row = 0;
		int column = 0;
		CellsHelper.CellNameToIndex(activeCell, out row, out column);
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Validation validation = (Validation)enumerator.Current;
				if (validation.Type != ValidationType.List || !validation.InCellDropDown)
				{
					continue;
				}
				ArrayList areaList = validation.AreaList;
				if (areaList == null || areaList.Count == 0)
				{
					continue;
				}
				foreach (CellArea item in areaList)
				{
					if (row >= item.StartRow && row <= item.EndRow && column >= item.StartColumn && column <= item.EndColumn)
					{
						return true;
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return false;
	}

	internal void method_9(byte[] byte_0)
	{
		int num = BitConverter.ToInt32(byte_0, 10);
		if (num != -1)
		{
			worksheet_0.Shapes.method_19(num);
			int_0 = -1;
		}
	}
}
