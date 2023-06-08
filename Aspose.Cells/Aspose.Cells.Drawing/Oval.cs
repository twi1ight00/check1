namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the oval shape.
///       </summary>
public class Oval : Shape
{
	internal Oval(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.Oval, shapeCollection_1)
	{
	}

	internal void Copy(Oval oval_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)oval_0, copyOptions_0);
	}
}
