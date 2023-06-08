using Aspose.Slides;
using ns24;
using ns62;
using ns7;

namespace ns15;

internal class Class1037 : Class1036
{
	internal static void smethod_12(GeometryShape domGeometryShape, Class2670 shapeContainer, Class854 slideDeserializationContext)
	{
		Class1036.smethod_0(domGeometryShape, shapeContainer, slideDeserializationContext);
	}

	internal static void smethod_13(AutoShape domAutosh, Class2670 pptSpContainer)
	{
		new Class200(domAutosh.Geometry, pptSpContainer.ShapePrimaryOptions);
	}

	internal static void smethod_14(Class540 domGeometry, Class204 domShapeImp)
	{
		new Class200(domGeometry, domShapeImp);
		if (domShapeImp.DefData != null)
		{
			for (int i = 0; i < domShapeImp.DefData.Length; i++)
			{
				domGeometry.Adjustments[i] = new Class341("adj" + i, (long)((double)(domShapeImp.DefData[i] * 1000) / 216.0));
			}
		}
	}
}
