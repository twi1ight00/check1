using System.Collections;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.Drawing.TextBox" /> objects.
///       </summary>
public class TextBoxCollection : CollectionBase
{
	private ShapeCollection shapeCollection_0;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Drawing.TextBox" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public TextBox this[int index] => (TextBox)base.InnerList[index];

	internal TextBoxCollection(ShapeCollection shapeCollection_1)
	{
		shapeCollection_0 = shapeCollection_1;
	}

	/// <summary>
	///       Adds a textbox to the collection.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	/// <param name="height">Height of textbox, in unit of pixel.</param>
	/// <param name="width">Width of textbox, in unit of pixel.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Drawing.TextBox" /> object index.</returns>
	public int Add(int upperLeftRow, int upperLeftColumn, int height, int width)
	{
		shapeCollection_0.AddTextBox(upperLeftRow, 0, upperLeftColumn, 0, height, width);
		return base.Count - 1;
	}

	/// <summary>
	///       Remove a text box from the file.
	///       </summary>
	/// <param name="index">The text box index.</param>
	public new void RemoveAt(int index)
	{
		shapeCollection_0.method_26(this[index]);
	}

	internal int Add(TextBox textBox_0)
	{
		base.InnerList.Add(textBox_0);
		return base.Count - 1;
	}

	internal void Remove(TextBox textBox_0)
	{
		base.InnerList.Remove(textBox_0);
	}
}
