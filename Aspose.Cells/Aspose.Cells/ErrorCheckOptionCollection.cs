using System.Collections;

namespace Aspose.Cells;

/// <summary>
///       Represents all erorr check option.
///       </summary>
public class ErrorCheckOptionCollection : CollectionBase
{
	internal Worksheet worksheet_0;

	/// <summary>
	///       Gets <see cref="T:Aspose.Cells.ErrorCheckOption" /> object by the given index.
	///       </summary>
	/// <param name="index">The index</param>
	/// <returns>Return <see cref="T:Aspose.Cells.ErrorCheckOption" /> object </returns>
	public ErrorCheckOption this[int index] => (ErrorCheckOption)base.InnerList[index];

	internal ErrorCheckOptionCollection(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	/// <summary>
	///       Add an error check option.
	///       </summary>
	/// <returns>
	/// </returns>
	public int Add()
	{
		ErrorCheckOption value = new ErrorCheckOption();
		base.InnerList.Add(value);
		return base.InnerList.Count - 1;
	}
}
