using System.Collections;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents a collection of <see cref="T:Aspose.Cells.Drawing.CheckBox" /> objects in a worksheet.
///       </summary>
/// <example>
///   <code>
///       [C#]
///
///       int index = excel.Worksheets[0].CheckBoxes.Add(15, 15, 20, 100);
///       CheckBox checkBox = excel.Worksheets[0].CheckBoxes[index];
///       checkBox.Text = "Check Box 1";
///
///
///       [Visual Basic]
///
///       Dim index as integer = excel.Worksheets(0).CheckBoxes.Add(15, 15, 20, 100)
///       Dim checkBox as CheckBox = excel.Worksheets(0).CheckBoxes[index];
///       checkBox.Text = "Check Box 1"
///       </code>
/// </example>
public class CheckBoxCollection : CollectionBase
{
	private ShapeCollection shapeCollection_0;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Drawing.CheckBox" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public CheckBox this[int index] => (CheckBox)base.InnerList[index];

	internal CheckBoxCollection(ShapeCollection shapeCollection_1)
	{
		shapeCollection_0 = shapeCollection_1;
	}

	/// <summary>
	///       Adds a checkBox to the collection.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="height">Height of checkBox, in unit of pixel.</param>
	/// <param name="width">Width of checkBox, in unit of pixel.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.CheckBox" /> object index.</returns>
	public int Add(int upperLeftRow, int upperLeftColumn, int height, int width)
	{
		shapeCollection_0.AddCheckBox(upperLeftRow, 0, upperLeftColumn, 0, height, width);
		return base.Count - 1;
	}

	internal void Add(CheckBox checkBox_0)
	{
		base.InnerList.Add(checkBox_0);
	}

	internal void Remove(CheckBox checkBox_0)
	{
		base.InnerList.Remove(checkBox_0);
	}
}
