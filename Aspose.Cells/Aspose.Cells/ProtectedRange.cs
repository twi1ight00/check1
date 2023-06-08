using System.Collections;
using System.Runtime.CompilerServices;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       A specified range to be allowed to edit when the sheet protection is ON. 
///       </summary>
public class ProtectedRange
{
	private string string_0;

	private ArrayList arrayList_0;

	private string string_1;

	private ushort ushort_0;

	private ProtectedRangeCollection protectedRangeCollection_0;

	private string string_2;

	internal byte[] byte_0;

	/// <summary>
	///       Gets the Range title. This is used as a descriptor, not as a named range definition.
	///       </summary>
	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	/// <summary>
	///       Gets the <see cref="P:Aspose.Cells.ProtectedRange.CellArea" /> object represents the cell area to be protected.
	///       </summary>
	public CellArea CellArea => (CellArea)arrayList_0[0];

	/// <summary>
	///       Represents the password to protect the range.
	///       </summary>
	public string Password
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			if (value != null && value != "")
			{
				ushort_0 = (ushort)Class1652.smethod_0(value);
			}
			else
			{
				ushort_0 = 0;
			}
		}
	}

	public string SecurityDescriptor
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	internal ProtectedRange(ProtectedRangeCollection protectedRangeCollection_1)
	{
		protectedRangeCollection_0 = protectedRangeCollection_1;
		arrayList_0 = new ArrayList();
	}

	internal ProtectedRange(ProtectedRangeCollection protectedRangeCollection_1, string string_3, CellArea cellArea_0)
	{
		protectedRangeCollection_0 = protectedRangeCollection_1;
		string_0 = string_3;
		arrayList_0 = new ArrayList();
		arrayList_0.Add(cellArea_0);
	}

	internal ProtectedRange(ProtectedRangeCollection protectedRangeCollection_1, string string_3, ArrayList arrayList_1)
	{
		protectedRangeCollection_0 = protectedRangeCollection_1;
		string_0 = string_3;
		arrayList_0 = new ArrayList();
		arrayList_0.AddRange(arrayList_1);
	}

	internal void Copy(ProtectedRange protectedRange_0)
	{
		string_0 = protectedRange_0.string_0;
		string_1 = protectedRange_0.string_1;
		ushort_0 = protectedRange_0.ushort_0;
		string_2 = protectedRange_0.string_2;
		for (int i = 0; i < protectedRange_0.arrayList_0.Count; i++)
		{
			CellArea cellArea = (CellArea)protectedRange_0.arrayList_0[i];
			CellArea cellArea2 = default(CellArea);
			cellArea2.StartRow = cellArea.StartRow;
			cellArea2.StartColumn = cellArea.StartColumn;
			cellArea2.EndRow = cellArea.EndRow;
			cellArea2.EndColumn = cellArea.EndColumn;
			arrayList_0.Add(cellArea2);
		}
	}

	/// <summary>
	///       Gets all referred areas.
	///       </summary>
	/// <returns>Returns all referred areas.</returns>
	public CellArea[] GetAreas()
	{
		CellArea[] array = new CellArea[arrayList_0.Count];
		arrayList_0.CopyTo(array);
		return array;
	}

	[SpecialName]
	internal ArrayList method_0()
	{
		return arrayList_0;
	}

	/// <summary>
	///       Adds a referred area to this 
	///       </summary>
	/// <param name="startRow">The start row.</param>
	/// <param name="startColumn">The start column.</param>
	/// <param name="endRow">The end row.</param>
	/// <param name="endColumn">The end column.</param>
	public void AddArea(int startRow, int startColumn, int endRow, int endColumn)
	{
		CellArea cellArea = default(CellArea);
		cellArea.StartRow = startRow;
		cellArea.StartColumn = startColumn;
		cellArea.EndRow = endRow;
		cellArea.EndColumn = endColumn;
		arrayList_0.Add(cellArea);
	}

	internal void AddArea(CellArea cellArea_0)
	{
		arrayList_0.Add(cellArea_0);
	}

	[SpecialName]
	internal ushort method_1()
	{
		return ushort_0;
	}

	[SpecialName]
	internal void method_2(ushort ushort_1)
	{
		ushort_0 = ushort_1;
	}
}
