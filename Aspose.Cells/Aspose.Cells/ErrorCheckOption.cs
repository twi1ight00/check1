using System.Collections;

namespace Aspose.Cells;

/// <summary>
///       Error check setting applied on certain ranges.
///       </summary>
public class ErrorCheckOption
{
	internal ArrayList arrayList_0 = new ArrayList();

	internal int int_0;

	internal ErrorCheckOption()
	{
	}

	/// <summary>
	///       Checks whether given error type will be checked.
	///       </summary>
	/// <param name="errorCheckType">error type can be checked</param>
	/// <returns>return true if given error type will be checked.</returns>
	public bool IsErrorCheck(ErrorCheckType errorCheckType)
	{
		return ((uint)int_0 & (uint)errorCheckType) == 0;
	}

	/// <summary>
	///       Sets whether given error type will be checked.
	///       </summary>
	/// <param name="errorCheckType">error type can be checked.</param>
	/// <param name="isCheck">true if given error type needs to be checked.</param>
	public void SetErrorCheck(ErrorCheckType errorCheckType, bool isCheck)
	{
		if (isCheck)
		{
			int_0 &= (int)(~errorCheckType);
		}
		else
		{
			int_0 |= (int)errorCheckType;
		}
	}

	/// <summary>
	///       Gets the count of ranges that influenced by this setting.
	///       </summary>
	/// <returns>the count of ranges that influenced by this setting.</returns>
	public int GetCountOfRange()
	{
		return arrayList_0.Count;
	}

	/// <summary>
	///       Adds one influenced range by this setting.
	///       </summary>
	/// <param name="ca">the range to be added.</param>
	/// <returns>the index of the added range in the range list of this setting.</returns>
	public int AddRange(CellArea ca)
	{
		arrayList_0.Add(ca);
		return arrayList_0.Count - 1;
	}

	/// <summary>
	///        Gets the influenced range of this setting by given index.
	///       </summary>
	/// <param name="index">the index of range</param>
	/// <returns>return influenced range at given index.</returns>
	public CellArea GetRange(int index)
	{
		if (index < 0 || index >= arrayList_0.Count)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid range index");
		}
		return (CellArea)arrayList_0[index];
	}

	/// <summary>
	///       Removes one range by given index.
	///       </summary>
	/// <param name="index">the index of the range to be removed.</param>
	public void RemoveRange(int index)
	{
		if (index < 0 || index >= arrayList_0.Count)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid range index");
		}
		arrayList_0.RemoveAt(index);
	}
}
