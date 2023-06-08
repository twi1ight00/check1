using System.Drawing.Drawing2D;
using ns4;

namespace Aspose.Slides;

public class ShapeElement : IShapeElement
{
	internal Shape shape_0;

	internal GraphicsPath graphicsPath_0;

	internal bool bool_0;

	internal Enum116 enum116_0;

	internal ShapeElementFillSource shapeElementFillSource_0;

	internal ShapeElementStrokeSource shapeElementStrokeSource_0;

	internal Class101 class101_0;

	internal ShapeFrame shapeFrame_0 = new ShapeFrame();

	internal Matrix matrix_0;

	internal bool bool_1;

	public Shape ParentShape => shape_0;

	public GraphicsPath GraphicsPath => graphicsPath_0;

	internal Enum116 ElementType => enum116_0;

	public ShapeElementFillSource FillSource => shapeElementFillSource_0;

	public ShapeElementStrokeSource StrokeSource => shapeElementStrokeSource_0;

	internal void method_0(Matrix m)
	{
		if (m != null)
		{
			graphicsPath_0.Transform(m);
		}
	}

	internal ShapeElement(Shape shape, GraphicsPath path, Enum116 type, bool invisibleForDecoration, ShapeElementFillSource fillSource, ShapeElementStrokeSource strokeSource, Class101 stroke)
	{
		shape_0 = shape;
		graphicsPath_0 = path;
		bool_0 = invisibleForDecoration;
		enum116_0 = type;
		shapeElementFillSource_0 = fillSource;
		shapeElementStrokeSource_0 = strokeSource;
		if (strokeSource == ShapeElementStrokeSource.OwnStroke)
		{
			class101_0 = stroke;
		}
	}
}
