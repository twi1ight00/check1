namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the auto shape and drawing object.
///       </summary>
public class CellsDrawing : Shape
{
	internal CellsDrawing(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.CellsDrawing, AutoShapeType.Unknown, shapeCollection_1)
	{
	}

	internal CellsDrawing(ShapeCollection shapeCollection_1, AutoShapeType autoShapeType_0)
		: base(shapeCollection_1, MsoDrawingType.CellsDrawing, autoShapeType_0, shapeCollection_1)
	{
	}

	internal void Copy(CellsDrawing cellsDrawing_0, CopyOptions copyOptions_0)
	{
		Copy((Shape)cellsDrawing_0, copyOptions_0);
	}
}
