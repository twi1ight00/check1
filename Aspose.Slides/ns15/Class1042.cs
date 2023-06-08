using System.Collections.Generic;
using Aspose.Slides;
using ns24;
using ns60;
using ns62;

namespace ns15;

internal class Class1042 : Class1037
{
	internal static void smethod_15(Connector targetShape, Class2670 esspContainer, Class854 slideDeserializationContext)
	{
		Class1037.smethod_12(targetShape, esspContainer, slideDeserializationContext);
		ShapeType preset = Class232.smethod_6((int)esspContainer.ShapeProp.ShapeType);
		targetShape.Geometry.Preset = preset;
		Class1052.smethod_0(targetShape.fillFormat_0, esspContainer, slideDeserializationContext);
		IShapeFrame frame = targetShape.Frame;
		Class1056.smethod_0(targetShape.LineFormat, esspContainer, slideDeserializationContext, LineJoinStyle.Miter, (frame.FlipH == NullableBool.True) ^ (frame.FlipV == NullableBool.True));
		if (targetShape.Geometry.Adjustments == null)
		{
			return;
		}
		for (int i = 0; i < targetShape.Geometry.Adjustments.Length; i++)
		{
			Class2911 @class = ((esspContainer.ShapePrimaryOptions != null) ? (esspContainer.ShapePrimaryOptions.Properties[(Enum426)(i + 327)] as Class2911) : null);
			Class341 class2 = targetShape.Geometry.Adjustments[i];
			if (@class != null)
			{
				targetShape.Geometry.Adjustments[i] = new Class341((class2 != null) ? class2.Name : ("adj" + i), (int)((double)(int)@class.Value / 21600.0 * 100000.0));
			}
			else if (class2 == null)
			{
				targetShape.Geometry.Adjustments[i] = new Class341("adj" + i, 0L);
			}
		}
	}

	internal static void smethod_16(Connector connector, Class854 slideDeserializationContext, Dictionary<uint, IShape> shapeIdToShape)
	{
		Class2668 solvers = slideDeserializationContext.DrawingContainer.OfficeArtDg.Solvers;
		if (solvers == null)
		{
			return;
		}
		foreach (Class2623 record in solvers.Records)
		{
			if (record is Class2626 @class && @class.ConnectorId == connector.ShapeId)
			{
				_ = @class.ShapeA;
				if (shapeIdToShape.ContainsKey(@class.ShapeA))
				{
					connector.StartShapeConnectedTo = shapeIdToShape[@class.ShapeA];
					connector.StartShapeConnectionSiteIndex = (uint)@class.ConnectionPointA;
				}
				_ = @class.ShapeB;
				if (shapeIdToShape.ContainsKey(@class.ShapeB))
				{
					connector.EndShapeConnectedTo = shapeIdToShape[@class.ShapeB];
					connector.EndShapeConnectionSiteIndex = (uint)@class.ConnectionPointB;
				}
				break;
			}
		}
	}
}
