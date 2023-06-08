using System.Collections.Generic;
using Aspose.Slides;
using ns60;
using ns62;
using ns63;

namespace ns15;

internal class Class1046 : Class1036
{
	internal static void smethod_12(GroupShape domGroupShape, Class2671 groupShapeContainer, Class854 slideDeserializationContext)
	{
		Class1036.smethod_0(domGroupShape, groupShapeContainer, slideDeserializationContext);
		if (groupShapeContainer.ShapePrimaryOptions != null && groupShapeContainer.ClientData != null && groupShapeContainer.ClientData.PlaceholderAtom != null && slideDeserializationContext.FrameToPlaceholder.TryGetValue(groupShapeContainer, out var value))
		{
			Class1062.smethod_0(domGroupShape, value, slideDeserializationContext);
		}
		for (int i = 1; i < groupShapeContainer.Records.Count; i++)
		{
			Class1064.smethod_0(domGroupShape.shapeCollection_1, (Class2639)groupShapeContainer.Records[i], slideDeserializationContext);
		}
		domGroupShape.RawFrameImpl = Class230.smethod_1(groupShapeContainer);
	}

	internal static void smethod_13(GroupShape targetShape, Class854 slideDeserializationContext, Dictionary<uint, IShape> shapeIdToShape)
	{
		foreach (Shape shape in targetShape.Shapes)
		{
			if (shape is AutoShape)
			{
				Class1041.smethod_16((AutoShape)shape);
			}
			else if (shape is Table)
			{
				Class1045.smethod_19((Table)shape, slideDeserializationContext);
			}
			else if (shape is VideoFrame)
			{
				Class1040.smethod_18((VideoFrame)shape);
			}
			else if (shape is Connector)
			{
				Class1042.smethod_16((Connector)shape, slideDeserializationContext, shapeIdToShape);
			}
			else if (shape is GroupShape)
			{
				smethod_13((GroupShape)shape, slideDeserializationContext, shapeIdToShape);
			}
			else if (shape is AudioFrame)
			{
				Class1039.smethod_22((AudioFrame)shape);
			}
		}
	}

	internal static void smethod_14(GroupShape targetShape, List<Class2623> shapes, Class854 slideDeserializationContext)
	{
		targetShape.lineFormat_0 = new LineFormat(targetShape);
		targetShape.method_11(1u);
		for (int i = 1; i < shapes.Count; i++)
		{
			Class1064.smethod_0(targetShape.shapeCollection_1, (Class2639)shapes[i], slideDeserializationContext);
		}
	}
}
