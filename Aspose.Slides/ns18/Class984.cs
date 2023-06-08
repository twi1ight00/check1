using Aspose.Slides;
using ns56;

namespace ns18;

internal class Class984
{
	public static void smethod_0(IGeometryShape geometryShape, Class1922 shapeStyleElementData)
	{
		if (shapeStyleElementData != null)
		{
			((GeometryShape)geometryShape).method_14();
			IShapeStyle shapeStyle = geometryShape.ShapeStyle;
			Class930.smethod_1(shapeStyle.LineColor, shapeStyleElementData.LnRef.Color);
			shapeStyle.LineStyleIndex = (ushort)shapeStyleElementData.LnRef.Idx;
			Class930.smethod_1(shapeStyle.FillColor, shapeStyleElementData.FillRef.Color);
			shapeStyle.FillStyleIndex = (short)shapeStyleElementData.FillRef.Idx;
			Class930.smethod_1(shapeStyle.EffectColor, shapeStyleElementData.EffectRef.Color);
			shapeStyle.EffectStyleIndex = shapeStyleElementData.EffectRef.Idx;
			Class930.smethod_1(shapeStyle.FontColor, shapeStyleElementData.FontRef.Color);
			shapeStyle.FontCollectionIndex = shapeStyleElementData.FontRef.Idx;
		}
	}

	public static void smethod_1(IShapeStyle shapeStyle, Class1922.Delegate1633 addStyle)
	{
		if (shapeStyle != null)
		{
			Class1922 @class = addStyle();
			Class930.smethod_4(shapeStyle.LineColor, @class.LnRef.delegate2773_0);
			@class.LnRef.Idx = shapeStyle.LineStyleIndex;
			Class930.smethod_4(shapeStyle.FillColor, @class.FillRef.delegate2773_0);
			@class.FillRef.Idx = (uint)shapeStyle.FillStyleIndex;
			Class930.smethod_4(shapeStyle.EffectColor, @class.EffectRef.delegate2773_0);
			@class.EffectRef.Idx = shapeStyle.EffectStyleIndex;
			Class930.smethod_4(shapeStyle.FontColor, @class.FontRef.delegate2773_0);
			@class.FontRef.Idx = shapeStyle.FontCollectionIndex;
		}
	}
}
