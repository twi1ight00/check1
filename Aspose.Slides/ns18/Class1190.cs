using Aspose.Slides;
using Aspose.Slides.Theme;
using ns16;
using ns19;
using ns24;
using ns53;
using ns55;

namespace ns18;

internal class Class1190 : Class1188
{
	private Class1030 class1030_0;

	private Class1031 class1031_0;

	public Class1030 SlideDeserializationContext => class1030_0;

	public Class1031 SlideSerializationContext => class1031_0;

	public Class1190(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
		class1030_0 = new Class1030(deserializationContext, base.Part);
	}

	public Class1190(Class1342 part, Class1346 serializationContext, IBaseSlide slide)
		: base(part, serializationContext)
	{
		class1031_0 = new Class1031(slide, serializationContext, base.Part);
		Class296 baseSlidePPTXUnsupportedProps = ((BaseSlide)slide).BaseSlidePPTXUnsupportedProps;
		Class350 pPTXUnsupportedProps = ((Presentation)serializationContext.Presentation).PPTXUnsupportedProps;
		Class247.Write(part, pPTXUnsupportedProps.UnknownParts, baseSlidePPTXUnsupportedProps.RelsToUnknownParts);
	}

	protected void method_5(IMasterThemeManager themeManager)
	{
		themeManager.IsOverrideThemeEnabled = false;
		Class1347[] array = base.DeserializationContext.RelationshipsOfCurrentPartEntry.method_0(Class1237.class1338_0);
		if (array.Length > 0)
		{
			Class1209 @class = new Class1209(array[0].TargetPart, base.DeserializationContext);
			@class.method_6(themeManager);
		}
	}

	internal void method_6(IShapeCollection shapes, Class1031 slideSerializationContext)
	{
		foreach (Shape shape in shapes)
		{
			slideSerializationContext.method_1(shape, shape.PPTXUnsupportedProps.ShapeId);
			if (shape is IGroupShape)
			{
				method_6(((IGroupShape)shape).Shapes, slideSerializationContext);
			}
		}
	}
}
