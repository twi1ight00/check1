using System.Collections;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the rectangle shape.
///       </summary>
public class RectangleShape : Shape
{
	internal RectangleShape(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.Rectangle, shapeCollection_1)
	{
	}

	/// <summary>
	///       Returns a Characters object that represents a range of characters within the cell text.
	///       </summary>
	/// <param name="startIndex">The index of the start of the character.</param>
	/// <param name="length">The number of characters.</param>
	/// <returns>Characters object.</returns>
	/// <remarks>This method only works on cell with string value.</remarks>
	public new FontSetting Characters(int startIndex, int length)
	{
		return method_63().Characters(startIndex, length);
	}

	/// <summary>
	///       Returns all Characters objects 
	///       that represents a range of characters within the shape.
	///       </summary>
	/// <returns>All Characters objects </returns>
	public new ArrayList GetCharacters()
	{
		return method_63().method_12();
	}

	internal void Copy(RectangleShape rectangleShape_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)rectangleShape_0, copyOptions_0);
	}
}
